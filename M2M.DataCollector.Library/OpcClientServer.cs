using Csla;
using M2M.DataCenter;
using M2M.DataCenter.Localization;
using M2M.DataCenter.OPC;
using NLog;
using OPC;
using OPCDA.NET;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;



namespace M2M.DataCollector.Library
{
    [Serializable]
    public class OpcClientServer
    {
        #region Properties
       public OpcClientServer()
        {
            
        }

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private OpcServer m_OpcServer = null;
        private OpcGroup m_SubscribeGroup = null;
        private TagDefinitionList m_TagDefinitions = null;
        private readonly Dictionary<string, MachineState> m_MachineStates = new Dictionary<string, MachineState>();
        private readonly Dictionary<string, List<Guid>> m_SendPanelTags = new Dictionary<string, List<Guid>>();
        private readonly Dictionary<Guid, AutoResetEvent> m_SendPanelThreads = new Dictionary<Guid, AutoResetEvent>();
        private readonly object m_SendPanelThreadLock = new object();
        
        #endregion

        #region Action methods

        public void Start()
        {

            try
            {
                string culture = CultureList.GetCulture(M2MDataCenter.SystemSettings.Culture);

                if (culture != "")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
                }

                
                m_OpcServer = new OpcServer();
                m_OpcServer.ErrorsAsExecptions = true;
                string opcServer = ApplicationSettings.OpcServerName;
                logger.Info("Connecting to {0}", opcServer);
                m_OpcServer.Connect(opcServer);
                
                m_OpcServer.ShutdownRequested += new ShutdownRequestEventHandler(m_OpcServer_ShutdownRequested);
                logger.Info("OpcServer succesfully connected");

                CollectData();
            }
            catch (Exception ex)
            {
                logger.ErrorException("Server start exception", ex);
                throw ex;
            }
        }

        public void Stop(bool shutdownRequested = false)
        {
            logger.Info("Stopping service");

            try
            {
                if (m_SubscribeGroup != null)
                    m_SubscribeGroup.Remove(true);

                logger.Info("OpcSubscription removed");
                RememberState();
                logger.Info("States remembered");
                if (m_OpcServer != null && (m_OpcServer.ServerName != "CodeSys.OPC.DA" || !shutdownRequested))
                    m_OpcServer.Disconnect();
                logger.Info("OpcServer disconnected");
            }
            catch (Exception ex)
            {
                logger.ErrorException("Server stop exception", ex);
            }
        }

        public void Pause()
        {
            try
            {
                if (m_SubscribeGroup != null)
                    m_SubscribeGroup.Remove(false);

                RememberState();
                m_MachineStates.Clear();
                

            }
            catch (Exception ex)
            {
                logger.ErrorException("Server pause exception", ex);
            }
        }

        public void Continue()
        {
            try
            {
                CollectData();
            }
            catch (Exception ex)
            {
                logger.ErrorException("Server continue exception", ex);
            }
        }

        #endregion

        #region Handlers

        private void SubscribeGroup_DataChanged(object sender, DataChangeEventArgs e)
        {
            DateTime start = DateTime.Now;
            
            try
            {
                logger.Trace("DataChange Number of items {0}, masterError: {1}, masterQuality {2}", e.sts.Length, e.masterError, e.masterQuality);
                HandleDataChange(e);
                logger.Trace("DataChange, time consumed {0}", DateTime.Now.Subtract(start));
            }
            catch (Exception ex)
            {
                logger.FatalException("Previous unhandled exception in HandleDataChange.", ex);
            }
        }

        

        private void m_OpcServer_ShutdownRequested(object sender, ShutdownRequestEventArgs e)
        {
            logger.Error("Shutdown requested for opc server {0}, reason: {1}", ApplicationSettings.OpcServerName, e.shutdownReason);
            Stop(true);
        }

        private void HandleDataChange(DataChangeEventArgs e)
        {
            string culture = CultureList.GetCulture(M2MDataCenter.SystemSettings.Culture);

            if (culture != "")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            }


            List<ExtendedOpcState> extStates = new List<ExtendedOpcState>();
            foreach (OPCItemState state in e.sts)
            {
                extStates.Add(new ExtendedOpcState(state, m_TagDefinitions.GetByHandle(state.HandleClient)));
            }
            //var sortedStates = extStates.OrderBy(s => s.State.TimeStamp).ThenByDescending(s => s.Tag.Priority);
            var sortedStates = extStates.OrderByDescending(s => s.Tag.Priority);

            logger.Trace("========================================================================");

            foreach (ExtendedOpcState extState in sortedStates)
            {
                logger.Trace("======================================");
                OPCItemState state = extState.State;
                TagDefinitionList.TagDefinition tagDefinition = extState.Tag;
                
                if (HRESULTS.Succeeded(state.Error))
                {
                    try
                    {
                        logger.Trace("Incoming - tag: {0}, value: {1}, quality: {2}", tagDefinition.TagId, state.DataValue, state.Quality);
                        MachineState machineState = m_MachineStates[tagDefinition.MachineId];
                        
                        if(!machineState.Stored.Connected.Value && tagDefinition.TagType != TagType.ConnectionCheck)
                            continue;

                        if (state.Quality != 192 && tagDefinition.TagType != TagType.ConnectionCheck)
                        {
                            logger.Trace("Bad quality from OPC. TagId: {0}", tagDefinition.TagId);
                            continue;
                        }

                        if (state.DataValue == null && tagDefinition.TagType != TagType.ConnectionCheck)
                        {
                            logger.Error("Null value from OPC. TagId: {0}", tagDefinition.TagId);
                            continue;
                        }

                        machineState.Pending.TimeStamp = state.TimeStampNet.ToLocalTime();

                        switch (tagDefinition.TagType)
                        {
                            case TagType.ConnectionCheck:
                                machineState.Pending.Connected = (state.Quality == 192) && CheckInversion((bool)state.DataValue, tagDefinition.InvertedSignal);
                                
                                logger.Trace(machineState.ToString());

                                if (!machineState.Pending.Connected.Value && machineState.Stored.Connected.Value)
                                {
                                    logger.Debug("Connection failure detected");
                                    machineState.Stored.TimeStamp = machineState.Pending.TimeStamp;

                                    if (machineState.Stored.Auto.Value)
                                    {
                                        double elapsedTime = ResetAuto(tagDefinition.MachineId);

                                        Maintenance maintenance = Maintenance.GetMaintenanceObject(tagDefinition.MachineId);
                                        maintenance.Uptime += Convert.ToDecimal(elapsedTime);
                                        maintenance.Save();

                                    }
                                    else if (machineState.Stored.Shutdowned.Value)
                                    {
                                        ResetShutdown(tagDefinition.MachineId);
                                    }
                                    else if (machineState.Stored.FlowErrorActive)
                                    {
                                        ResetFlowError(tagDefinition.MachineId);
                                    }

                                    SetDisconnected(tagDefinition.MachineId);

                                    if(state.Quality == 192)
                                        ActivateStop(tagDefinition.MachineId, m_TagDefinitions.GetSpecialTagId(machineState.Settings.AccessPath, TagType.CommunicationError));
                                    else
                                        ActivateStop(tagDefinition.MachineId, m_TagDefinitions.GetSpecialTagId(machineState.Settings.AccessPath, TagType.CommunicationBadQuality));

                                    machineState.Stored.Connected = false;
                                    machineState.Stored.Auto = false;
                                    machineState.Stored.Shutdowned = false;
                                    machineState.Stored.FlowErrorActive = false;

                                    RealTimeValues realTimeValues = RealTimeValues.GetRealTimeValues(tagDefinition.MachineId);
                                    realTimeValues.IsConnected = machineState.Stored.Connected.Value;
                                    realTimeValues.Auto = machineState.Stored.Auto.Value;
                                    realTimeValues.ProductionSwitch = !machineState.Stored.Shutdowned.Value;
                                    realTimeValues.FlowErrorActive = false;
                                    realTimeValues.LastChanged = new SmartDate(machineState.Stored.TimeStamp);
                                    realTimeValues.Save();
                                }

                                if (machineState.Pending.Connected.Value && !machineState.Stored.Connected.Value)
                                {
                                    logger.Debug("Connection established detected");
                                    machineState.Stored.TimeStamp = machineState.Pending.TimeStamp;
                                    machineState.Stored.Connected = true;

                                    ResetDisconnected(tagDefinition.MachineId);

                                    RealTimeValues realTimeValues = RealTimeValues.GetRealTimeValues(tagDefinition.MachineId);
                                    realTimeValues.IsConnected = machineState.Stored.Connected.Value;
                                    realTimeValues.LastChanged = new SmartDate(machineState.Stored.TimeStamp);

                                    if (machineState.Pending.Shutdowned == true)
                                    {
                                        machineState.Stored.Shutdowned = true;
                                        machineState.Stored.ActiveStop = "";
                                        realTimeValues.ProductionSwitch = false;
                                        machineState.Pending.ActiveStops.Clear();

                                        if (machineState.Stored.FlowErrorActive)
                                        {
                                            ResetFlowError(tagDefinition.MachineId);
                                            machineState.Stored.FlowErrorActive = false;
                                            realTimeValues.FlowErrorActive = false;
                                        }

                                        SetShutdown(tagDefinition);
                                    }
                                    else if (machineState.Pending.Auto == true)
                                    {
                                        machineState.Stored.Auto = true;
                                        machineState.Stored.ActiveStop = "";
                                        realTimeValues.Auto = true;
                                        machineState.Pending.ActiveStops.Clear();

                                        if (machineState.Stored.FlowErrorActive)
                                        {
                                            ResetFlowError(tagDefinition.MachineId);
                                            machineState.Stored.FlowErrorActive = false;
                                            realTimeValues.FlowErrorActive = false;
                                        }

                                        SetAuto(tagDefinition.MachineId);

                                    }

                                    realTimeValues.Save();
                                    //if (machineState.Stored.ActiveStop == "" && machineState.Pending.ActiveStops.Count > 0)
                                    //    machineState.Stored.ActiveStop = machineState.Pending.ActiveStops[0];

                                    if (!machineState.Stored.Shutdowned.Value && !machineState.Stored.Auto.Value)
                                    {
                                        if (machineState.Stored.ActiveStop != "")
                                        {
                                            ReActivateStop(tagDefinition.MachineId, machineState.Stored.ActiveStop);
                                        }
                                        else
                                        {
                                            ActivateStop(tagDefinition.MachineId, m_TagDefinitions.GetSpecialTagId(machineState.Settings.AccessPath, TagType.UnidentifiedStop));
                                        }
                                    }
                                }
                                break;
                            case TagType.ArticleNumber:
                                {
                                    string article = FixDataString(state.DataValue, tagDefinition.DataType);
                                    
                                    if(article != "" && machineState.Stored.Article != article)
                                    {
                                        machineState.Stored.TimeStamp = machineState.Pending.TimeStamp;
                                        machineState.Pending.Article = article;
                                        logger.Trace("Article change detected - Stored: {0}, Pending: {1}", machineState.Stored.Article, machineState.Pending.Article);

                                        bool reActivateStop = true;

                                        if (machineState.Stored.Auto.Value)
                                        {
                                            double elapsedTime = ResetAuto(tagDefinition.MachineId);

                                            Maintenance maintenance = Maintenance.GetMaintenanceObject(tagDefinition.MachineId);
                                            maintenance.Uptime += Convert.ToDecimal(elapsedTime);
                                            maintenance.Save();
                                            reActivateStop = false;
                                        }
                                        else if (machineState.Stored.Shutdowned.Value)
                                        {
                                            ResetShutdown(tagDefinition.MachineId);
                                            reActivateStop = false;
                                        }
                                        else if (machineState.Stored.FlowErrorActive)
                                        {
                                            ResetFlowError(tagDefinition.MachineId);
                                        }

                                        ResetArticle(tagDefinition.MachineId);
                                    
                                        machineState.Stored.Article = machineState.Pending.Article;

                                        RealTimeValues realTimeValues = RealTimeValues.GetRealTimeValues(tagDefinition.MachineId);
                                        realTimeValues.ArticleNumber = machineState.Settings.IgnoreArticleStateChange ? "" : machineState.Stored.Article;
                                        realTimeValues.LastChanged =  new SmartDate(machineState.Stored.TimeStamp);
                                        realTimeValues.Save();
                                    
                                        SetArticle(tagDefinition.MachineId);

                                        if (reActivateStop)
                                        {
                                            Event prevEvent = Event.GetActiveEvent(tagDefinition.MachineId);
                                            if (!prevEvent.EventRaised.IsEmpty)
                                            {
                                                Event newEvent = Event.NewEvent();
                                                newEvent.TagId = prevEvent.TagId;
                                                newEvent.DivisionId = prevEvent.DivisionId;
                                                newEvent.MachineId = prevEvent.MachineId;
                                                newEvent.ArticleNumber = machineState.Stored.Article;
                                                newEvent.EventRaised = machineState.Stored.TimeStamp;
                                                newEvent.CurrentNumberOfItems = prevEvent.CurrentNumberOfItems;
                                                newEvent.ReasonCode = prevEvent.ReasonCode;
                                                newEvent.Save();
                                            }
                                        }

                                        if (machineState.Stored.Auto.Value)
                                        {
                                            SetAuto(tagDefinition.MachineId);
                                        }
                                        else if (machineState.Stored.Shutdowned.Value)
                                        {
                                            SetShutdown(tagDefinition);
                                        }
                                        else if (machineState.Stored.FlowErrorActive)
                                        {
                                            SetFlowError(tagDefinition.MachineId, machineState.Stored.TimeStamp);
                                        }
                                    }
                                }
                                break;
                            case TagType.Auto:
                                {
                                    machineState.Pending.Auto = CheckInversion((bool)state.DataValue, tagDefinition.InvertedSignal);
                                    if (machineState.Stored.Auto != machineState.Pending.Auto)
                                    {
                                        logger.Debug("Auto state change detected on {0} - Stored: {1}, Pending: {2}", tagDefinition.MachineId, machineState.Stored.Auto, machineState.Pending.Auto);
                                        if (!machineState.Stored.Shutdowned.Value)
                                        {
                                            machineState.Stored.TimeStamp = machineState.Pending.TimeStamp;
                                            machineState.Stored.Auto = machineState.Pending.Auto;

                                            RealTimeValues realTimeValues = RealTimeValues.GetRealTimeValues(tagDefinition.MachineId);
                                            realTimeValues.Auto = machineState.Stored.Auto.Value;
                                            realTimeValues.LastChanged =  new SmartDate(machineState.Stored.TimeStamp);
                                            realTimeValues.Save();
                                            
                                            if (machineState.Stored.Auto.Value)
                                            {
                                                machineState.Pending.ActiveStops.Clear();

                                                if (machineState.Stored.FlowErrorActive)
                                                {
                                                    ResetFlowError(tagDefinition.MachineId);
                                                    machineState.Stored.FlowErrorActive = false;
                                                    realTimeValues = RealTimeValues.GetRealTimeValues(tagDefinition.MachineId);
                                                    realTimeValues.LastChanged = new SmartDate(machineState.Stored.TimeStamp);
                                                    realTimeValues.FlowErrorActive = false;
                                                    realTimeValues.Save();
                                                }
                                                
                                        
                                                SetAuto(tagDefinition.MachineId);
                                            }
                                            else
                                            {
                                                double elapsedTime = ResetAuto(tagDefinition.MachineId);

                                                machineState.Stored.ActiveStop = "";

                                                if (machineState.Pending.ActiveStops.Count > 0)
                                                    machineState.Stored.ActiveStop = machineState.Pending.ActiveStops[0];

                                                if (machineState.Stored.ActiveStop != "")
                                                {
                                                    ActivateStop(tagDefinition.MachineId, machineState.Stored.ActiveStop);
                                                }
                                                else
                                                {
                                                    ActivateStop(tagDefinition.MachineId, m_TagDefinitions.GetSpecialTagId(machineState.Settings.AccessPath, TagType.UnidentifiedStop));
                                                }

                                                Maintenance maintenance = Maintenance.GetMaintenanceObject(tagDefinition.MachineId);
                                                maintenance.Uptime += Convert.ToDecimal(elapsedTime);
                                                maintenance.Save();
                                            }

                                            
                                        }
                                        else
                                        {
                                            logger.Debug("Machine {0} in shutdown state - ignoring auto", tagDefinition.MachineId);
                                        }
                                    }
                                }
                                break;
                            case TagType.Cycles:
                                {
                                    machineState.Stored.TimeStamp = machineState.Pending.TimeStamp;
                                    int value = Convert.ToInt32(state.DataValue);
                                 
                                    if(machineState.Pending.Cycles.HasValue) // newly initiated if not
                                        machineState.Stored.Cycles = VerifyCycleCount(tagDefinition.MachineId, machineState.Stored.Cycles.Value, machineState.Pending.Cycles.Value, value);
                                    machineState.Pending.Cycles = value;
                                    
                                    RealTimeValues realTimeValues = RealTimeValues.GetRealTimeValues(tagDefinition.MachineId);
                                    logger.Debug("Cycle values on {0}, Incoming: {1}, Previous pending (lastRead): {2}, Previous stored (current): {3}, New pending (lastRead): {4}, New stored (current): {5}", tagDefinition.MachineId, state.DataValue, realTimeValues.LastReadCycleCount, realTimeValues.CurrentCycleCount, machineState.Pending.Cycles, machineState.Stored.Cycles);
                                    realTimeValues.CurrentCycleCount = machineState.Stored.Cycles.Value;
                                    realTimeValues.LastReadCycleCount = machineState.Pending.Cycles.Value;
                                    realTimeValues.LastChanged = machineState.Stored.TimeStamp;
                                    realTimeValues.Save();

                                    if (!machineState.UseMomentsForMaintenance)
                                    {
                                        Maintenance maintenance = Maintenance.GetMaintenanceObject(tagDefinition.MachineId);
                                        maintenance.Moments = machineState.Stored.Cycles.Value;
                                        maintenance.MomentsLastRead = machineState.Pending.Cycles.Value;
                                        maintenance.Save();
                                    }

                                    if (!machineState.Stored.Shutdowned.Value && !machineState.Stored.Auto.Value)
                                    {
                                        // This belongs to previous auto
                                        UpdateLastAuto(tagDefinition.MachineId);
                                    }

                                    if ( machineState.Stored.Auto.Value && machineState.Pending.TimeStamp.Subtract(machineState.Stored.LastUpdatedAuto).TotalSeconds >= Math.Max(machineState.Settings.MinValidAutoTime, 60))
                                    {
                                        UpdateActiveAuto(tagDefinition.MachineId);
                                    }
                                }
                                break;
                            case TagType.Informational:
                                {
                                    if (!machineState.Stored.Shutdowned.Value)
                                    {
                                        machineState.Stored.TimeStamp = machineState.Pending.TimeStamp;
                                        bool value = CheckInversion((bool)state.DataValue, tagDefinition.InvertedSignal);

                                        if (value)
                                        {
                                            WriteInformation(tagDefinition.MachineId, tagDefinition.TagId);
                                        }
                                    }
                                    else
                                    {
                                        logger.Debug("Machine {0} in shutdown state - ignoring info", tagDefinition.MachineId);
                                    }
                                }
                                break;
                            case TagType.Moments:
                                {
                                    machineState.Stored.TimeStamp = machineState.Pending.TimeStamp;
                                    
                                    int value = Convert.ToInt32(state.DataValue);

                                    if (machineState.Pending.Moments.HasValue) // newly initiated
                                        machineState.Stored.Moments = VerifyCycleCount(tagDefinition.MachineId, machineState.Stored.Moments.Value, machineState.Pending.Moments.Value, value);
                                    machineState.Pending.Moments = value;

                                    Maintenance maintenance = Maintenance.GetMaintenanceObject(tagDefinition.MachineId);
                                    maintenance.Moments = machineState.Stored.Moments.Value;
                                    maintenance.MomentsLastRead = machineState.Pending.Moments.Value;
                                    maintenance.Save();
                                }
                                break;
                            case TagType.Rejected:
                                {
                                    machineState.Stored.TimeStamp = machineState.Pending.TimeStamp;

                                    int value = Convert.ToInt32(state.DataValue);
                                    if (machineState.Pending.Rejected.HasValue) // newly initiated if not
                                        machineState.Stored.Rejected = VerifyRejectedCount(tagDefinition.MachineId, machineState.Stored.Rejected.Value, machineState.Pending.Rejected.Value, value);
                                    machineState.Pending.Rejected = value;
                                    
                                    RealTimeValues realTimeValues = RealTimeValues.GetRealTimeValues(tagDefinition.MachineId);
                                    logger.Debug("Rejection values on {0}, Incoming: {1}, Previous pending (lastRead): {2}, Previous stored (current): {3}, New pending (lastRead): {4}, New stored (current): {5}", tagDefinition.MachineId, state.DataValue, realTimeValues.LastReadRejectedCount, realTimeValues.CurrentRejectedCount, machineState.Pending.Rejected, machineState.Stored.Rejected);
                                    realTimeValues.CurrentRejectedCount = machineState.Stored.Rejected.Value;
                                    realTimeValues.LastReadRejectedCount = machineState.Pending.Rejected.Value;
                                    realTimeValues.LastChanged = machineState.Stored.TimeStamp;
                                    realTimeValues.Save();

                                    if (!machineState.Stored.Shutdowned.Value && !machineState.Stored.Auto.Value)
                                    {
                                        // This belongs to previous auto
                                        UpdateLastAuto(tagDefinition.MachineId);
                                    }
                                }
                                break;
                            case TagType.ProductionSwitch:
                                {
                                    machineState.Stored.TimeStamp = machineState.Pending.TimeStamp;
                                    bool inProd = CheckInversion((bool)state.DataValue, tagDefinition.InvertedSignal);
                                    machineState.Pending.Shutdowned = !inProd;

                                    if (machineState.Stored.Shutdowned != machineState.Pending.Shutdowned)
                                    {
                                        logger.Trace("Shutdown state change detected - Stored: {0}, Pending: {1}", machineState.Stored.Shutdowned, machineState.Pending.Shutdowned);
                                        if (machineState.Pending.Shutdowned.Value)
                                        {
                                            if (machineState.Stored.Auto.Value)
                                            {
                                                machineState.Stored.Auto = false;
                                                double elapsedTime = ResetAuto(tagDefinition.MachineId);

                                                Maintenance maintenance = Maintenance.GetMaintenanceObject(tagDefinition.MachineId);
                                                maintenance.Uptime += Convert.ToDecimal(elapsedTime);
                                                maintenance.Save();
                                            }
                                            else if (machineState.Stored.FlowErrorActive)
                                            {
                                                ResetFlowError(tagDefinition.MachineId);
                                                machineState.Stored.FlowErrorActive = false;
                                            }

                                            machineState.Stored.Shutdowned = true;

                                            SetShutdown(tagDefinition);
                                        }
                                        else
                                        {
                                            machineState.Stored.Shutdowned = false;

                                            ResetShutdown(tagDefinition.MachineId);

                                            if (machineState.Pending.Auto.Value)
                                            {
                                                machineState.Stored.Auto = true;

                                                if (machineState.Stored.FlowErrorActive)
                                                {
                                                    ResetFlowError(tagDefinition.MachineId);
                                                    machineState.Stored.FlowErrorActive = false;
                                                }

                                                SetAuto(tagDefinition.MachineId);
                                            }
                                            else
                                            {
                                               // machineState.Stored.ActiveStop = "";
                                                //bool verifyPanelRequest = machineState.Stored.ActiveStop == "";
                                                //if (machineState.Stored.ActiveStop == "" && machineState.Pending.ActiveStops.Count > 0)
                                                //    machineState.Stored.ActiveStop = machineState.Pending.ActiveStops[0];

                                                if (machineState.Stored.ActiveStop != "")
                                                {
                                                    ReActivateStop(tagDefinition.MachineId, machineState.Stored.ActiveStop);
                                                }
                                                else
                                                {
                                                    ActivateStop(tagDefinition.MachineId, m_TagDefinitions.GetSpecialTagId(machineState.Settings.AccessPath, TagType.UnidentifiedStop));
                                                }
                                            }
                                        }

                                        RealTimeValues realTimeValues = RealTimeValues.GetRealTimeValues(tagDefinition.MachineId);
                                        realTimeValues.ProductionSwitch = !machineState.Stored.Shutdowned.Value;
                                        realTimeValues.Auto = machineState.Stored.Auto.Value;
                                        realTimeValues.FlowErrorActive = machineState.Stored.FlowErrorActive;
                                        realTimeValues.LastChanged = new SmartDate(machineState.Stored.TimeStamp);
                                        realTimeValues.Save();
                                    }
                                }
                                break;
                            case TagType.Stop:
                                {
                                    bool value = CheckInversion((bool)state.DataValue, tagDefinition.InvertedSignal);

                                    if (value)
                                    {

                                        if (machineState.Pending.ActiveStops.Count > 10)
                                        {
                                            logger.Trace("Too many active stops. Stop not added -  - {0}", tagDefinition.TagId);

                                        }
                                        else
                                        {
                                            logger.Trace("Stop added - {0} Count before add: {1}", tagDefinition.TagId, machineState.Pending.ActiveStops.Count);
                                            machineState.Pending.ActiveStops.Add(tagDefinition.TagId);

                                            if (!machineState.Stored.Shutdowned.Value)
                                            {

                                                if (!machineState.Stored.Auto.Value)
                                                {
                                                    // Check if this is a primary alert
                                                    if (machineState.Stored.ActiveStop == "")
                                                    {
                                                        machineState.Stored.TimeStamp = machineState.Pending.TimeStamp;
                                                        machineState.Stored.ActiveStop = machineState.Pending.ActiveStops[0];
                                                        ActivateStop(tagDefinition.MachineId, machineState.Stored.ActiveStop, true);
                                                    }
                                                    //else if (M2MDataCenter.SystemSettings.LogSecondaryAlerts)
                                                    //{
                                                    //    LogSecondaryAlert(tagDefinition.MachineId, machineState.Pending.ActiveStops[machineState.Pending.ActiveStops.Count - 1]);
                                                    //}

                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (machineState.Pending.ActiveStops.Remove(tagDefinition.TagId))
                                        {
                                            logger.Trace("Stop removed - {0} Count before remove: {1}", tagDefinition.TagId, machineState.Pending.ActiveStops.Count);
                                        }

                                        if (tagDefinition.SendPanelRequest && tagDefinition.RequestDelay > 0)
                                        {
                                            lock (m_SendPanelThreadLock)
                                            {
                                                if(m_SendPanelTags.ContainsKey(tagDefinition.TagId) && m_SendPanelTags[tagDefinition.TagId].Count > 0)
                                                {
                                                    Guid eventId = m_SendPanelTags[tagDefinition.TagId][m_SendPanelTags[tagDefinition.TagId].Count -1];
                                                    if (m_SendPanelThreads.ContainsKey(eventId))
                                                        m_SendPanelThreads[eventId].Set();
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                        }

              
                    }
                    catch (Exception ex)
                    {
                        logger.ErrorException(String.Format("Exception while handling data from opc. TagId: {0}, Value: {1}, Timestamp: {2}", tagDefinition.TagId, state.DataValue, state.TimeStampNet), ex);
                    }
                }
                else
                {
                    logger.Warn("Error from opc. Item '" + tagDefinition.TagId + "' reports error 0x" + state.Error.ToString("X"));
                }

                logger.Trace("======================================");
            }
            logger.Trace("========================================================================");

        }

        #endregion

        #region Database methods

        private void CollectData()
        {
            logger.Info("Initialize settings");
            M2MDataCenter.ReloadSystemSettings();

            try
            {
                LoadDefinitions();
            }
            catch (Exception ex)
            {
                logger.ErrorException("Failed to load definitions", ex);
                throw ex;
            }
        
            //----- create the OPC group for data change callback handling
            //      The item client handle is the array index of the associated write item
            m_SubscribeGroup = m_OpcServer.AddGroup("DataChangeGroup", false, 200, 2);

            //for (int i = 1; i <= M2MDataCenter.SystemSettings.LoadOpcItemsRetryAttempts; i++)
            //{
                OPCItemResult[] result;

                //Todo: Check out ValidateItems and Refresh2
                // add all data change callback items to group
                m_SubscribeGroup.AddItems(m_TagDefinitions.GetSubscribeItemDefs(), out result);

                int errors = 0;
                for (int j = 0; j < result.Length; ++j)
                {
                    if (!HRESULTS.Succeeded(result[j].Error))
                    {
                        errors++;
                        m_TagDefinitions.GetByHandle(j).Loaded = false;
                        logger.Warn("Failed to add item to data change callback group, error 0x{0}, TagId: {1}", result[j].Error.ToString("X"), m_TagDefinitions.GetByHandle(j).TagId);
                    }
                    else
                    {
                        m_TagDefinitions.GetByHandle(j).Loaded = true;
                    }
                }
              //  logger.Info("Loading items. Attempt: {0}", i);
            if (errors > 0)
            {
                logger.Error("Number of items not loaded: {0}/{1}", errors, result.Length);
            }
            else
            {
                logger.Info("All items successfully loaded: {0}", result.Length);
            }

            // if more than half are errors bail out and let service restart. This probably indicates that OPC servern does not have connection with machine 
            if (2 *errors - result.Length > 0)
            {
                logger.Error("Too many tag errors. Let the service restart. This probably indicates that OPC servern does not have connection with machine.");
                Environment.Exit(1);
            }
                //    Thread.Sleep(M2MDataCenter.SystemSettings.LoadOpcItemsRetryInterval);
           // }

            try
            {
                LogShutdownReason();
            }
            catch (Exception ex)
            {
                logger.ErrorException("Failed to log shutdown reason", ex);
            }

            logger.Info("Starting subscription");
            // data changed callback handler
            m_SubscribeGroup.DataChanged += new DataChangeEventHandler(SubscribeGroup_DataChanged);
            m_SubscribeGroup.Active = true;
            m_SubscribeGroup.AdviseIOPCDataCallback();
        }

        private void LoadDefinitions()
        {
            try
            {
                m_TagDefinitions = new TagDefinitionList();
                m_TagDefinitions.LoadItemDefs();

                m_MachineStates.Clear();

                foreach (string machineId in m_TagDefinitions.GetMachines())
                {
                    MachineState machineState = new MachineState(M2MDataCenter.GetMachine(machineId).DivisionId);
                    MachineSettingList settings = MachineSettingList.GetMachineSettingList(machineId);

                    logger.Info("Settings for {0}:", machineId);
                    
                    if (settings != null)
                    {
                        machineState.Settings.IgnoreArticleStateChange = settings.IgnoreArticleStateChange;
                        machineState.Settings.PanelIpAddress = settings.PanelIpAddress;
                        machineState.Settings.PanelTcpPort = settings.PanelTcpPort;
                        machineState.Settings.AllowedCycleDiff = settings.AllowedCycleDiff;
                        machineState.Settings.AllowNegativeScrap = settings.AllowNegativeScrap;
                        machineState.Settings.MinValidAutoTime = settings.MinValidAutoTime;
                        machineState.Settings.AccessPath = settings.AccessPath;
                    }

                    logger.Info("IgnoreArticleStateChange: {0}", machineState.Settings.IgnoreArticleStateChange);
                    logger.Info("PanelIpAddress: {0}", machineState.Settings.PanelIpAddress);
                    logger.Info("PanelTcpPort: {0}", machineState.Settings.PanelTcpPort);
                    logger.Info("AllowedCycleDiff: {0}", machineState.Settings.AllowedCycleDiff);
                    logger.Info("AllowNegativeScrap: {0}", machineState.Settings.AllowNegativeScrap);
                    logger.Info("MinValidAutoTime: {0}", machineState.Settings.MinValidAutoTime);
                    logger.Info("AccessPath: {0}", machineState.Settings.AccessPath);

                    TagInfoCollection tagInfos = TagInfoCollection.GetTagInfoCollection(machineId);

                    if (!tagInfos.Contains(machineId, TagType.CommunicationError.ToString()))
                    {
                        TagInfo tagInfo = tagInfos.Add(machineId, machineState.Settings.AccessPath, TagType.CommunicationError.ToString());
                        tagInfo.TagType = TagType.CommunicationError;
                        tagInfo.DisplayName = ResourceStrings.GetString(TagType.CommunicationError);
                    }

                    if (!tagInfos.Contains(machineId, TagType.CommunicationBadQuality.ToString()))
                    {
                        TagInfo tagInfo = tagInfos.Add(machineId, machineState.Settings.AccessPath, TagType.CommunicationBadQuality.ToString());
                        tagInfo.TagType = TagType.CommunicationBadQuality;
                        tagInfo.DisplayName = ResourceStrings.GetString(TagType.CommunicationBadQuality);
                    }

                    if (!tagInfos.Contains(machineId, TagType.UnidentifiedStop.ToString()))
                    {
                        TagInfo tagInfo = tagInfos.Add(machineId, machineState.Settings.AccessPath, TagType.UnidentifiedStop.ToString());
                        tagInfo.TagType = TagType.UnidentifiedStop;
                        tagInfo.DisplayName = ResourceStrings.GetString(TagType.UnidentifiedStop);
                    }

                    if (!tagInfos.Contains(machineId, TagType.ExpectedRestart.ToString()))
                    {
                        TagInfo tagInfo = tagInfos.Add(machineId, machineState.Settings.AccessPath, TagType.ExpectedRestart.ToString());
                        tagInfo.TagType = TagType.ExpectedRestart;
                        tagInfo.DisplayName = ResourceStrings.GetString(TagType.ExpectedRestart);
                    }

                    if (!tagInfos.Contains(machineId, TagType.UnexpectedRestart.ToString()))
                    {
                        TagInfo tagInfo = tagInfos.Add(machineId, machineState.Settings.AccessPath, TagType.UnexpectedRestart.ToString());
                        tagInfo.TagType = TagType.UnexpectedRestart;
                        tagInfo.DisplayName = ResourceStrings.GetString(TagType.UnexpectedRestart);
                    }

                    if (!tagInfos.Contains(machineId, TagType.InitiatingCommunication.ToString()))
                    {
                        TagInfo tagInfo = tagInfos.Add(machineId, machineState.Settings.AccessPath, TagType.InitiatingCommunication.ToString());
                        tagInfo.TagType = TagType.InitiatingCommunication;
                        tagInfo.DisplayName = ResourceStrings.GetString(TagType.InitiatingCommunication);
                    }

                    tagInfos.Save();

                    RealTimeValues realTimeValues = null;
                    if (RealTimeValues.Exists(machineId))
                    {
                        realTimeValues = RealTimeValues.GetRealTimeValues(machineId);
                    }
                    else
                    {
                        realTimeValues = RealTimeValues.NewRealTimeValues(machineId);
                        realTimeValues = realTimeValues.Save();
                    }

                    Maintenance maintenance = null;
                    if (Maintenance.Exists(machineId))
                    {
                        maintenance = Maintenance.GetMaintenanceObject(machineId);
                    }
                    else
                    {
                        maintenance = Maintenance.NewMaintenanceObject(machineId);
                        maintenance = maintenance.Save();
                    }
                    
                    machineState.Stored.TimeStamp =  realTimeValues.LastChanged.Date;
                    machineState.Stored.Article = realTimeValues.ArticleNumber;
                    machineState.Stored.Auto = realTimeValues.Auto;
                    machineState.Stored.Connected = realTimeValues.IsConnected;
                    machineState.Stored.Cycles = realTimeValues.CurrentCycleCount;
                    machineState.Stored.Rejected = realTimeValues.CurrentRejectedCount;
                    machineState.Stored.Moments = maintenance.Moments;
                    machineState.Stored.Shutdowned = !realTimeValues.ProductionSwitch;
                    machineState.Stored.FlowErrorActive = realTimeValues.FlowErrorActive;
                    
                    m_MachineStates.Add(machineId, machineState);

                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("Error in loading items", ex);
                throw ex;
            }
        }

        private void LogShutdownReason()
        {
            DateTime timeStamp = DateTime.Now;
            foreach (string machineId in m_MachineStates.Keys)
            {
                MachineState machineState = m_MachineStates[machineId];

                logger.Trace(machineState.ToString());

                if (machineState.Stored.Connected.Value || machineState.Stored.Auto.Value || machineState.Stored.Shutdowned.Value || machineState.Stored.FlowErrorActive)
                {
                    logger.Error("Unhandled shutdown detected - {0}", machineId);

                    if (machineState.Stored.Auto.Value)
                    {
                        double elapsedTime = ResetAuto(machineId);

                        Maintenance maintenance = Maintenance.GetMaintenanceObject(machineId);
                        maintenance.Uptime += Convert.ToDecimal(elapsedTime);
                        maintenance.Save();

                        machineState.Stored.Auto = false;
                    }
                    else if (machineState.Stored.Shutdowned.Value)
                    {
                        ResetShutdown(machineId);
                        machineState.Stored.Shutdowned = false;
                    }
                    else if (machineState.Stored.FlowErrorActive)
                    {
                        ResetFlowError(machineId);
                        machineState.Stored.FlowErrorActive = false;
                    }

                    SetDisconnected(machineId);
                    ActivateStop(machineId, m_TagDefinitions.GetSpecialTagId(machineState.Settings.AccessPath, TagType.UnexpectedRestart));
                    machineState.Stored.Connected = false;
                    machineState.Stored.TimeStamp = timeStamp;
                    ActivateStop(machineId, m_TagDefinitions.GetSpecialTagId(machineState.Settings.AccessPath, TagType.InitiatingCommunication));

                    RealTimeValues realTimeValues = RealTimeValues.GetRealTimeValues(machineId);
                    realTimeValues.LastChanged = new SmartDate(timeStamp);
                    realTimeValues.IsConnected = false;
                    realTimeValues.ProductionSwitch = true;
                    realTimeValues.FlowErrorActive = false;
                    realTimeValues.Auto = false;
                    realTimeValues.Save();
                }
                else
                {
                    machineState.Stored.TimeStamp = timeStamp;
                    ActivateStop(machineId, m_TagDefinitions.GetSpecialTagId(machineState.Settings.AccessPath, TagType.InitiatingCommunication));
                    logger.Warn("Handled shutdown detected - {0}", machineId);
                }
            }
        }

        private void RememberState()
        {
            try
            {
                DateTime timeStamp = DateTime.Now;
                logger.Trace("m_MachineStates {0}", m_MachineStates != null ? m_MachineStates.Count.ToString() : "Null");

                foreach (string machineId in m_MachineStates.Keys)
                {
                    logger.Trace("Storing current state for {0}", machineId);
                    MachineState machineState = m_MachineStates[machineId];

                    logger.Trace(machineState.ToString());

                    machineState.Stored.TimeStamp = timeStamp;

                    if (machineState.Stored.Connected.Value)
                    {
                        if (machineState.Stored.Auto.Value)
                        {
                            double elapsedTime = ResetAuto(machineId);

                            Maintenance maintenance = Maintenance.GetMaintenanceObject(machineId);
                            maintenance.Uptime += Convert.ToDecimal(elapsedTime);
                            maintenance.Save();
                        }
                        else if (machineState.Stored.Shutdowned.Value)
                        {
                            ResetShutdown(machineId);
                        }
                        else if (machineState.Stored.FlowErrorActive)
                        {
                            ResetFlowError(machineId);
                        }

                        SetDisconnected(machineId);

                        RealTimeValues realTimeValues = RealTimeValues.GetRealTimeValues(machineId);
                        realTimeValues.LastChanged = new SmartDate(timeStamp);
                        realTimeValues.IsConnected = false;
                        realTimeValues.ProductionSwitch = true;
                        realTimeValues.Auto = false;
                        realTimeValues.FlowErrorActive = false;
                        realTimeValues.Save();
                    }

                    machineState.Stored.Connected = false;
                    machineState.Stored.Shutdowned = false;
                    machineState.Stored.Auto = false;
                    machineState.Stored.FlowErrorActive = false;
                    
                    ActivateStop(machineId, m_TagDefinitions.GetSpecialTagId(machineState.Settings.AccessPath, TagType.ExpectedRestart));
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("Failed to store current state", ex);
            }
        }

        private void ReActivateStop(string machineId, string tagId)
        {
            MachineState machineState = m_MachineStates[machineId];

            Event latestEvent = Event.GetLatestEvent(machineId, tagId);
            if (latestEvent.EventRaised.IsEmpty)
            {
                logger.Warn("ReactivateStop error - tag: {0} - {1}", tagId, machineId);
                ActivateStop(machineId, tagId);
                return;
            }
            
            logger.Trace("Stop reactivated - tag: {0} - {1}", tagId, machineId);

            Event newEvent = Event.NewEvent();
            newEvent.TagId = tagId;
            newEvent.DivisionId = machineState.DivisionId;
            newEvent.MachineId = machineId;
            newEvent.ArticleNumber = machineState.Stored.Article;
            newEvent.EventRaised = machineState.Stored.TimeStamp;
            newEvent.CurrentNumberOfItems = machineState.Stored.Cycles.Value;
            newEvent.ReasonCode = latestEvent.ReasonCode;
            newEvent = newEvent.Save();

            Guid eventId = newEvent.EventId;
            SmartDate eventRaised = newEvent.EventRaised;

            if (m_TagDefinitions.GetByTagId(tagId) != null && M2MDataCenter.GetCategoryItem(m_TagDefinitions.GetByTagId(tagId).CategoryId).FlowError)
            {
                SetFlowError(machineId, eventRaised);
            }

            try
            {
                if (m_TagDefinitions.GetByTagId(tagId) != null && m_TagDefinitions.GetByTagId(tagId).SendPanelRequest)
                {
                    RealTimeValues realTimeValues = RealTimeValues.GetRealTimeValues(machineId);
                    if (!realTimeValues.ChangeOverActive || newEvent.ReasonCode == 0)
                    {

                        lock (m_SendPanelThreadLock)
                        {
                            if (!m_SendPanelThreads.ContainsKey(eventId))
                            {
                                AutoResetEvent handle = new AutoResetEvent(false);
                                m_SendPanelThreads.Add(eventId, handle);
                                if (!m_SendPanelTags.ContainsKey(tagId))
                                {
                                    m_SendPanelTags.Add(tagId, new List<Guid>());
                                }
                                m_SendPanelTags[tagId].Add(eventId);

                                object[] parameters = new object[] { handle, m_TagDefinitions.GetByTagId(tagId).RequestDelay, eventId, eventRaised, tagId, machineId, m_TagDefinitions.GetByTagId(tagId).DisplayName };

                                Thread workingthread = new Thread(new ParameterizedThreadStart(SendPanelRequest));
                                workingthread.Start(parameters);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("SenPanelRequest error", ex);
            }
        }

        private void ActivateStop(string machineId, string tagId, bool overWriteUnidentified)
        {
            MachineState machineState = m_MachineStates[machineId];

            Guid eventId = Guid.Empty;
            SmartDate eventRaised = new SmartDate();

            if (overWriteUnidentified)
            {
                // update active stop if unidentified 
                logger.Trace("Stop updated - tag: {0} - {1}", tagId, machineId);


                Event activeEvent = Event.GetActiveEvent(machineId, m_TagDefinitions.GetSpecialTagId(machineState.Settings.AccessPath, TagType.UnidentifiedStop));
                if (!activeEvent.EventRaised.IsEmpty)
                {
                    eventId = activeEvent.EventId;
                    eventRaised = activeEvent.EventRaised;

                    activeEvent.TagId = tagId;
                    activeEvent.Save();
                    eventId = activeEvent.EventId;
                }
            }
            
            if(eventId == Guid.Empty)
            {
                logger.Trace("Stop activated - tag: {0} - {1}", tagId, machineId);

                Event newEvent = Event.NewEvent();
                newEvent.TagId = tagId;
                newEvent.DivisionId = machineState.DivisionId;
                newEvent.MachineId = machineId;
                newEvent.ArticleNumber = machineState.Stored.Article;
                newEvent.EventRaised = machineState.Stored.TimeStamp;
                newEvent.CurrentNumberOfItems = machineState.Stored.Cycles.Value;
                newEvent = newEvent.Save();

                eventId = newEvent.EventId;
                eventRaised = newEvent.EventRaised;
            }

            if (m_TagDefinitions.GetByTagId(tagId) != null &&  M2MDataCenter.GetCategoryItem(m_TagDefinitions.GetByTagId(tagId).CategoryId).FlowError)
            {
                SetFlowError(machineId, eventRaised);
            }
            
            try
            {
                if (m_TagDefinitions.GetByTagId(tagId) != null && m_TagDefinitions.GetByTagId(tagId).SendPanelRequest)
                {
                    RealTimeValues realTimeValues = RealTimeValues.GetRealTimeValues(machineId);
                    if (!realTimeValues.ChangeOverActive)
                    {
                        
                        lock (m_SendPanelThreadLock)
                        {
                            if (!m_SendPanelThreads.ContainsKey(eventId))
                            {
                                AutoResetEvent handle = new AutoResetEvent(false);
                                m_SendPanelThreads.Add(eventId, handle);
                                if (!m_SendPanelTags.ContainsKey(tagId))
                                {
                                    m_SendPanelTags.Add(tagId, new List<Guid>());
                                }
                                m_SendPanelTags[tagId].Add(eventId);

                                object[] parameters = new object[] { handle, m_TagDefinitions.GetByTagId(tagId).RequestDelay, eventId, eventRaised, tagId, machineId, m_TagDefinitions.GetByTagId(tagId).DisplayName };

                                Thread workingthread = new Thread(new ParameterizedThreadStart(SendPanelRequest));
                                workingthread.Start(parameters);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("SenPanelRequest error", ex); 
            }
        }

        private void ActivateStop(string machineId, string tagId)
        {
            ActivateStop(machineId, tagId, false);
        }

        //private void LogSecondaryAlert(string machineId, string tagId)
        //{
        //    logger.Trace("Secondary alert - tag: {0} - {1}", tagId, machineId);
        //    MachineState machineState = m_MachineStates[machineId];

        //    Event newEvent = Event.NewEvent();
        //    newEvent.TagId = tagId;
        //    newEvent.DivisionId = machineState.DivisionId;
        //    newEvent.MachineId = machineId;
        //    newEvent.ArticleNumber = machineState.Stored.Article;
        //    newEvent.EventRaised = machineState.Stored.TimeStamp;
        //    newEvent.EventRaised = machineState.Stored.TimeStamp;
        //    newEvent.CurrentNumberOfItems = machineState.Stored.Cycles.Value;
        //    newEvent.Save();
        //}

        private void WriteInformation(string machineId, string tagId)
        {
            logger.Trace("New informational value: {0} - {1}", tagId, machineId);
            MachineState machineState = m_MachineStates[machineId];

            Event newEvent = Event.NewEvent();
            newEvent.TagId = tagId;
            newEvent.DivisionId = machineState.DivisionId;
            newEvent.MachineId = machineId;
            newEvent.ArticleNumber = machineState.Stored.Article;
            newEvent.EventRaised = machineState.Stored.TimeStamp;
            newEvent.CurrentNumberOfItems = machineState.Stored.Cycles.Value;
            newEvent.TimeForNextEvent = newEvent.EventRaised;
            newEvent.Save();
        }

        private void SetFlowError(string machineId, SmartDate timestamp)
        {
            logger.Trace("Setting flow error - {0}", machineId);
            MachineState machineState = m_MachineStates[machineId];

            State newState = State.NewState();
            newState.MachineId = machineId;
            newState.StateType = StateType.FlowError;
            newState.ArticleNumber = machineState.Settings.IgnoreArticleStateChange ? "" : machineState.Stored.Article;
            newState.TimeStampOnSet = timestamp;
            newState.NumberOfItemsOnSet = machineState.Stored.Cycles.Value;
            newState.NumberOfRejectedOnSet = machineState.Stored.Rejected.Value;
            newState.Save();

            RealTimeValues realTimeValues = RealTimeValues.GetRealTimeValues(machineId);
            realTimeValues.LastChanged = timestamp;
            realTimeValues.FlowErrorActive = true;
            realTimeValues.Save();

            machineState.Stored.FlowErrorActive = true;
        }

        private void ResetFlowError(string machineId)
        {
            logger.Trace("Resetting flow error - {0}", machineId);
            MachineState machineState = m_MachineStates[machineId];

            State lastState = State.GetLatestActiveState(machineId, StateType.FlowError);

            if (lastState.TimeStampOnReset.IsEmpty)
            {
                lastState.TimeStampOnReset = machineState.Stored.TimeStamp;
                lastState.NumberOfItemsOnReset = machineState.Stored.Cycles.Value;
                lastState.NumberOfRejectedOnReset = machineState.Stored.Rejected.Value;
                lastState.Save();
            }
        }

        private void SetShutdown(TagDefinitionList.TagDefinition tagDef)
        {
            logger.Trace("Setting shutdown - {0}", tagDef.MachineId);
            MachineState machineState = m_MachineStates[tagDef.MachineId];

            if (machineState.Stored.FlowErrorActive)
                ResetFlowError(tagDef.MachineId);

            State newState = State.NewState();
            newState.MachineId = tagDef.MachineId;
            newState.StateType = StateType.NoProduction;
            newState.ArticleNumber = machineState.Settings.IgnoreArticleStateChange ? "" : machineState.Stored.Article;
            newState.TimeStampOnSet = machineState.Stored.TimeStamp;
            newState.NumberOfItemsOnSet = machineState.Stored.Cycles.Value;
            newState.NumberOfRejectedOnSet = machineState.Stored.Rejected.Value;
            newState.Save();

            Event newEvent = Event.NewEvent();
            newEvent.DivisionId = machineState.DivisionId;
            newEvent.TagId = m_TagDefinitions.GetByTagType(tagDef.MachineId, TagType.ProductionSwitch).TagId;
            newEvent.MachineId = tagDef.MachineId;
            newEvent.ArticleNumber = machineState.Stored.Article;
            newEvent.EventRaised = machineState.Stored.TimeStamp;
            newEvent.CurrentNumberOfItems = machineState.Stored.Cycles.Value;
            newEvent = newEvent.Save();

            if (tagDef.SendPanelRequest)
            {
                RealTimeValues realTimeValues = RealTimeValues.GetRealTimeValues(newEvent.MachineId);
                if (!realTimeValues.ChangeOverActive)
                {
                    if (realTimeValues.FirstValidAutoFound)
                    {
                        realTimeValues.FirstValidAutoFound = false;
                        realTimeValues.Save();
                    }

                    lock (m_SendPanelThreadLock)
                    {
                        if (!m_SendPanelThreads.ContainsKey(newEvent.EventId))
                        {
                            AutoResetEvent handle = new AutoResetEvent(false);
                            m_SendPanelThreads.Add(newEvent.EventId, handle);
                            if (!m_SendPanelTags.ContainsKey(newEvent.TagId))
                            {
                                m_SendPanelTags.Add(newEvent.TagId, new List<Guid>());
                            }
                            m_SendPanelTags[newEvent.TagId].Add(newEvent.EventId);

                            object[] parameters = new object[] { handle, m_TagDefinitions.GetByTagId(newEvent.TagId).RequestDelay, newEvent.EventId, newEvent.EventRaised, newEvent.TagId, newEvent.MachineId, m_TagDefinitions.GetByTagId(newEvent.TagId).DisplayName };

                            Thread workingthread = new Thread(new ParameterizedThreadStart(SendPanelRequest));
                            workingthread.Start(parameters);
                        }
                    }
                    
                }
            }
        }

        private void ResetShutdown(string machineId)
        {
            logger.Trace("Resetting shutdown - {0}", machineId);
            MachineState machineState = m_MachineStates[machineId];

            State lastState = State.GetLatestActiveState(machineId, StateType.NoProduction);

            if (lastState.TimeStampOnReset.IsEmpty)
            {
                lastState.TimeStampOnReset = machineState.Stored.TimeStamp;
                lastState.NumberOfItemsOnReset = machineState.Stored.Cycles.Value;
                lastState.NumberOfRejectedOnReset = machineState.Stored.Rejected.Value;
                lastState.Save();
            }
        }

        private void SetDisconnected(string machineId)
        {
            logger.Trace("Setting disconnected - {0}", machineId);
            MachineState machineState = m_MachineStates[machineId];

            State newState = State.NewState();
            newState.MachineId = machineId;
            newState.StateType = StateType.NotConnected;
            newState.ArticleNumber = machineState.Settings.IgnoreArticleStateChange ? "" : machineState.Stored.Article;
            newState.TimeStampOnSet = machineState.Stored.TimeStamp;
            newState.NumberOfItemsOnSet = machineState.Stored.Cycles.Value;
            newState.NumberOfRejectedOnSet = machineState.Stored.Rejected.Value;
            newState.Save();

        }

        private void ResetDisconnected(string machineId)
        {
            logger.Trace("Resetting disconnected - {0}", machineId);
            MachineState machineState = m_MachineStates[machineId];

            State lastState = State.GetLatestActiveState(machineId, StateType.NotConnected);

            if (!lastState.TimeStampOnSet.IsEmpty && lastState.TimeStampOnReset.IsEmpty)
            {
                lastState.TimeStampOnReset = machineState.Stored.TimeStamp;
                lastState.NumberOfItemsOnReset = machineState.Stored.Cycles.Value;
                lastState.NumberOfRejectedOnReset = machineState.Stored.Rejected.Value;
                lastState.Save();
            }
        }

        private void SetAuto(string machineId)
        {
            logger.Debug("Setting auto - {0}", machineId);
            MachineState machineState = m_MachineStates[machineId];

            State newState = State.NewState();
            newState.MachineId = machineId;
            newState.StateType = StateType.Auto;
            newState.ArticleNumber = machineState.Settings.IgnoreArticleStateChange ? "" : machineState.Stored.Article;
            newState.TimeStampOnSet = machineState.Stored.TimeStamp;
            newState.NumberOfItemsOnSet = machineState.Stored.Cycles.Value;
            newState.NumberOfRejectedOnSet = machineState.Stored.Rejected.Value;
            newState.Save();

            Event newEvent = Event.NewEvent();
            newEvent.TagId = m_TagDefinitions.GetByTagType(machineId, TagType.Auto).TagId;
            newEvent.DivisionId = machineState.DivisionId;
            newEvent.MachineId = machineId;
            newEvent.ArticleNumber = machineState.Stored.Article;
            newEvent.EventRaised = machineState.Stored.TimeStamp;
            newEvent.CurrentNumberOfItems = machineState.Stored.Cycles.Value;
            newEvent.Save();

            machineState.Stored.LastUpdatedAuto = machineState.Stored.TimeStamp;
        }

        private double ResetAuto(string machineId)
        {
            logger.Debug("Resetting auto - {0}", machineId);
            MachineState machineState = m_MachineStates[machineId];

            State lastState = State.GetLatestActiveState(machineId, StateType.Auto);
            if (!lastState.TimeStampOnSet.IsEmpty && lastState.TimeStampOnReset.IsEmpty)
            {
                lastState.TimeStampOnReset = machineState.Stored.TimeStamp;
                lastState.NumberOfItemsOnReset = machineState.Stored.Cycles.Value;
                lastState.NumberOfRejectedOnReset = machineState.Stored.Rejected.Value;
                lastState.Save();
            }
            else
                logger.Warn("No pending auto found  - {0}", machineId);
            logger.Trace(machineState.ToString());
            
            return UpdateActiveAuto(machineId);
        }

        private double UpdateActiveAuto(string machineId)
        {
            MachineState machineState = m_MachineStates[machineId];
            TimeSpan elapsedTime = new TimeSpan(0);
            Event activeEvent = Event.GetActiveEvent(machineId, m_TagDefinitions.GetByTagType(machineId, TagType.Auto).TagId);
            if (!activeEvent.EventRaised.IsEmpty)
            {
                int runRate = 0;
                elapsedTime = machineState.Stored.TimeStamp.Subtract(activeEvent.EventRaised.Date);
                int itemsProduced = machineState.Stored.Cycles.Value - activeEvent.CurrentNumberOfItems;

                if (elapsedTime.TotalSeconds > machineState.Settings.MinValidAutoTime && itemsProduced > 0)
                {
                    runRate = (int)Math.Round(elapsedTime.TotalMilliseconds / (double)itemsProduced);
                    activeEvent.RunRate = runRate;
                    activeEvent.Save();

                    RealTimeValues realTimeValues = RealTimeValues.GetRealTimeValues(machineId);

                    if (realTimeValues.ChangeOverActive || !realTimeValues.FirstValidAutoFound )
                    {
                        realTimeValues.ChangeOverActive = false;
                        realTimeValues.FirstValidAutoFound = true;
                        realTimeValues.Save();
                    }
                }

                machineState.Stored.LastUpdatedAuto = machineState.Stored.TimeStamp;

                logger.Trace("Auto update - elapsed time: {0} h, items produced: {1}, runrate: {2}", elapsedTime.TotalHours, itemsProduced, runRate);
            }

            return elapsedTime.TotalHours;
        }

        private void UpdateLastAuto(string machineId)
        {
            logger.Trace("Updating last auto - {0}", machineId);
                       
            MachineState machineState = m_MachineStates[machineId];

            State lastState = State.GetLatestState(machineId, StateType.Auto, new SmartDate(DateTime.Today));
            if (!lastState.TimeStampOnSet.IsEmpty)
            {
                lastState.NumberOfItemsOnReset = machineState.Stored.Cycles.Value;
                lastState.NumberOfRejectedOnReset = machineState.Stored.Rejected.Value;
                lastState.Save();
            }
        }

        private void SetArticle(string machineId)
        {
            MachineState machineState = m_MachineStates[machineId];
            if (machineState.Settings.IgnoreArticleStateChange)
            {
                logger.Trace("Ignore article state set: {0}", machineId);
                return;
            }
            
            logger.Trace("Setting article: {0} - {1}", machineState.Stored.Article, machineId);

            State newState = State.NewState();
            newState.MachineId = machineId;
            newState.StateType = StateType.ArticleSwitch;
            newState.ArticleNumber = machineState.Stored.Article;
            newState.TimeStampOnSet = machineState.Stored.TimeStamp;
            newState.NumberOfItemsOnSet = machineState.Stored.Cycles.Value;
            newState.NumberOfRejectedOnSet = machineState.Stored.Rejected.Value;
            newState.Save();
        }

        private void ResetArticle(string machineId)
        {
            MachineState machineState = m_MachineStates[machineId];

            if (machineState.Settings.IgnoreArticleStateChange)
            {
                logger.Trace("Ignore article state reset: {0}", machineId);
                return;
            }

            logger.Trace("Resetting article - {0}", machineId);

            State lastState = State.GetLatestActiveState(machineId, StateType.ArticleSwitch);

            if (!lastState.TimeStampOnSet.IsEmpty && lastState.TimeStampOnReset.IsEmpty)
            {
                lastState.TimeStampOnReset = machineState.Stored.TimeStamp;
                lastState.NumberOfItemsOnReset = machineState.Stored.Cycles.Value;
                lastState.NumberOfRejectedOnReset = machineState.Stored.Rejected.Value;
                lastState.Save();
            }
        }

        #endregion

        #region Helpers

        private int VerifyCycleCount(string machineId, int previousCurrent, int previousRead, int currentRead)
        {
            if (currentRead == 0) 
            {
                logger.Warn("Read cycle count is 0 on {0}", machineId);
                return previousCurrent;
            }

            int diff = currentRead - previousRead;

            if (diff <= -m_MachineStates[machineId].Settings.AllowedCycleDiff || diff > m_MachineStates[machineId].Settings.AllowedCycleDiff)
            {
                logger.Warn("Invalid cycle diff {0} on {1}", diff, machineId);
                return previousCurrent;
            }

            return previousCurrent + diff;
        }

        private int VerifyRejectedCount(string machineId, int previousCurrent, int previousRead, int currentRead)
        {
            int diff = currentRead - previousRead;

            if (diff <= (m_MachineStates[machineId].Settings.AllowNegativeScrap ? -m_MachineStates[machineId].Settings.AllowedCycleDiff : 0) || diff > m_MachineStates[machineId].Settings.AllowedCycleDiff)
            {
                logger.Warn("Invalid rejected diff {0} on {1}", diff, machineId);
                return previousCurrent;
            }

            return previousCurrent + diff;
        }

        private string FixDataString(object datastring, VarEnum dataType)
        {
            string retValue = "";

            try
            {
                if (dataType == VarEnum.VT_BSTR)
                {
                    string tmp = (string)datastring;
                    int index = tmp.IndexOf('\0');

                    if (index >= 0)
                    {
                        logger.Debug("String data needs fix: {0}, index: {1}", tmp, index);

                        if (index > 0)
                        {
                            retValue = tmp.Substring(0, index);
                        }
                    }
                    else
                        retValue = tmp;
                }
                else
                {
                    retValue = Convert.ToString(datastring);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("Failed to fix string data", ex);
            }

            return retValue;
        }

        #endregion
        //{ handle, m_TagDefinitions.GetByTagId(tagId).RequestDelay, eventId, eventRaised, tagId, machineId, m_TagDefinitions.GetByTagId(tagId).DisplayName }
        public void SendPanelRequest(object parameters)
        {
            logger.Trace("SendPanelRequest called ok");
            object[] p = parameters as object[];
            AutoResetEvent handle = p[0] as AutoResetEvent;
            int requestDelay = (int)p[1];
            Guid eventId = (Guid)p[2];
            SmartDate eventRaised = (SmartDate)p[3];
            string tagId = p[4] as string;
            string machineId = p[5] as string;
            string displayName = p[6] as string;
            
            try
            {
                if (handle.WaitOne(requestDelay * 1000))
                    return;

                PanelRequest request = PanelRequest.NewRequest();
                request.EventId = eventId;
                request.EventRaised = eventRaised;
                request.TagId = tagId;
                request.MachineId = machineId;
                request.DisplayName = displayName;
                request.Save();
                logger.Trace("SendPanelRequest updated");
            }
            catch (Exception ex)
            {
                logger.ErrorException("Alarm notification failed", ex);
            }
            finally
            {
                lock (m_SendPanelThreadLock)
                {
                    m_SendPanelThreads.Remove(eventId);
                    m_SendPanelTags[tagId].Remove(eventId);
                }
            }

        }

        public bool CheckInversion(bool value, bool inverted)
        {
            return inverted ? !value : value;
        }
    }
}