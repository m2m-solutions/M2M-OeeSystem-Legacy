using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using M2M.DataCenter;

namespace M2M.ChangeOver.Library
{
    public class Engine
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly System.Timers.Timer m_Timer = new System.Timers.Timer();
        private int m_CurrentInterval = 60 * 1000;
        
        public Engine()
		{
			
		}

        public void RunOnce()
        {
            Execute();
        }

		public void Start()
		{
            try
            {
                m_Timer.Interval = M2MDataCenter.SystemSettings.ChangeCalculateInterval * 60 * 1000;
                m_Timer.AutoReset = false;
                m_Timer.Elapsed += new System.Timers.ElapsedEventHandler(OnElapsedTime);
                m_Timer.Start();

                logger.Info("Change-over calculator service started");

            }
            catch (Exception ex)
            {
                logger.ErrorException("Start failed", ex);
                throw ex;
            }
        }

		public void Stop()
		{
            m_Timer.Stop();
            logger.Info("Change-over calculator stopped");
		}

        private void Execute()
        {
            try
            {
                List<ChangeOverCalculateRequest> pendingRemoveList = new List<ChangeOverCalculateRequest>();
                ChangeOverCalculateRequestCollection requests = ChangeOverCalculateRequestCollection.GetChangeOverCalculateRequestCollection();
                logger.Trace("ChangeOverCalculateRequestCollection count: {0}", requests.Count);
                
                Guid lastValidAuto = Guid.Empty;
                foreach (ChangeOverCalculateRequest request in requests)
                {
                    logger.Trace("Processing request. EventId {0}, MachineId {1}, Timestamp {2}", request.EventId, request.MachineId, request.Timestamp.Date);
                    if (!ChangeOverHelper.IsValidRequest(request.EventId))
                    {
                        logger.Warn("Remove and skip request. Request not valid");
                        pendingRemoveList.Add(request);
                        continue;
                    }

                    EventItem validAutoItem = ChangeOverHelper.GetValidAuto(request.MachineId, request.Timestamp.Date);

                    if (validAutoItem != null)
                    {
                        if (validAutoItem.EventId == lastValidAuto)
                        {
                            logger.Trace("Remove and skip request. Already processed");
                            pendingRemoveList.Add(request);
                            continue;
                        }
                        lastValidAuto = validAutoItem.EventId;
                        string previousArticle = ChangeOverHelper.GetPreviousArticle(request);
                        List<EventItem> involvedEvents = ChangeOverHelper.GetInvolvedEvents(request, validAutoItem);
                        logger.Trace("Valid auto found. {0} events involved", involvedEvents.Count());
                        EventItem currentEvent = null;
                        foreach (EventItem involvedEvent in involvedEvents)
                        {
                            if (involvedEvent.Override)
                            {
                                logger.Trace("Override eventId: {0}", involvedEvent.EventId);
                                ChangeOverHelper.OverrideEvent(involvedEvent.EventId);
                                if (currentEvent == null)
                                {
                                    currentEvent = new EventItem();
                                    currentEvent.EventId = Guid.NewGuid();
                                    currentEvent.EventRaised = involvedEvent.EventRaised;
                                    currentEvent.MachineId = involvedEvent.MachineId;
                                    currentEvent.Article = involvedEvent.Article;
                                }
                                //ignore information etc
                                if(involvedEvent.TimeForNextEvent > currentEvent.TimeForNextEvent)
                                    currentEvent.TimeForNextEvent = involvedEvent.TimeForNextEvent;
                            }
                            else
                            {
                                // We have found a production switch or some kind of connection loss
                                if (currentEvent != null)
                                {
                                    ChangeOverHelper.InsertEvent(currentEvent, request.EventId);
                                    ChangeOverHelper.OverrideStates(currentEvent);
                                    logger.Trace("New Event inserted and states overrided. EventId: {0} MachineId {1}, EventRaised {2}, TimeForNextEvent {3}", currentEvent.EventId, currentEvent.MachineId, currentEvent.EventRaised, currentEvent.TimeForNextEvent);
                                    ChangeOverHelper.AddData(validAutoItem, request.Timestamp.Date, currentEvent.EventRaised, involvedEvent.EventRaised, previousArticle, false);
                                    currentEvent = null;
                                }
                            }
                        }

                        if (currentEvent != null)
                        {
                            ChangeOverHelper.InsertEvent(currentEvent, request.EventId);
                            ChangeOverHelper.OverrideStates(currentEvent);
                            logger.Trace("New Event inserted and states overrided. EventId: {0} MachineId {1}, EventRaised {2}, TimeForNextEvent {3}", currentEvent.EventId, currentEvent.MachineId, currentEvent.EventRaised, currentEvent.TimeForNextEvent);
                            ChangeOverHelper.AddData(validAutoItem, request.Timestamp.Date, currentEvent.EventRaised, validAutoItem.EventRaised, previousArticle, true);
                        }

                        ChangeOverHelper.UpdateArticleNumber(request, validAutoItem);
                        
                        pendingRemoveList.Add(request);
                        
                        if (request.Timestamp < DateTime.Today)
                        {
                            // Pre-calculate
                            DateTime date = request.Timestamp.Date.Date;
                            while (date < DateTime.Today)
                            {
                                DateTime next = date.AddDays(1);
                                ChangeOverHelper.InsertCalculateRequest(M2MDataCenter.GetMachine(request.MachineId).DivisionId, request.MachineId, date, next);
                                date = next;
                            }
                        }
                    }
                    
                }

                if (pendingRemoveList.Count > 0)
                {
                    if (pendingRemoveList.Count == requests.Count)
                    {
                        requests.Clear();
                    }
                    else
                    {
                        foreach (ChangeOverCalculateRequest pendingRemoveRequest in pendingRemoveList)
                        {
                            requests.Remove(pendingRemoveRequest);
                        }
                    }
                    requests.Save();
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("Failed to execute requests", ex);
            }
        }

        private void OnElapsedTime(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                Execute();

                M2MDataCenter.ReloadSystemSettings();
                m_CurrentInterval = M2MDataCenter.SystemSettings.ChangeCalculateInterval * 60 * 1000;
                logger.Trace("Interval: {0}", m_Timer.Interval);
            }
            catch (Exception ex)
            {
                logger.ErrorException("Previously unhandled exception", ex);
            }
            finally
            {
                m_Timer.Interval = m_CurrentInterval;
            }
        }
	}
}
