using System;
using Csla;
using OPC;
using M2M.DataCenter;
using NLog;

namespace M2M.Integrator.Tekla.Library
{
    [Serializable]
    public class ServiceDataCollector
    {
        private System.Timers.Timer m_Timer = new System.Timers.Timer();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        public ServiceDataCollector()
        {

        }

        public void Start()
        {

            try
            {
                TeklaSettingCollection settings = TeklaSettingCollection.GetSettingCollection();
                m_Timer.Interval = settings.PollInterval;
                m_Timer.AutoReset = false;
                m_Timer.Elapsed += new System.Timers.ElapsedEventHandler(OnElapsedTime);

                m_Timer.Start();

                logger.Info("Collecting service data started");

            }
            catch (Exception ex)
            {
                logger.ErrorException("Collecting service data start failed.", ex);
            }
        }

        public void Stop()
        {
            m_Timer.Stop();
            logger.Info("Collecting service data stopped");
        }

        private void OnElapsedTime(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                PlainMachineList machines = PlainMachineList.GetMachineList();
                logger.Trace("Number of machines: {0}", machines.Count);
                foreach (PlainMachineListItem machine in machines)
                {
                    logger.Trace("Machine: {0}", machine.MachineId);
                    if (Maintenance.Exists(machine.MachineId))
                    {
                        Maintenance maintenance = Maintenance.GetMaintenanceObject(machine.MachineId);
                        int moments = maintenance.Moments;
                        Decimal uptime = maintenance.Uptime;

                        if (moments != maintenance.MomentsTransferred)
                        {
                            logger.Trace("Transferring moments. New: {0} Previous: {1}", moments, maintenance.MomentsTransferred);
                            JournalPost journalPost = JournalPost.NewJournalPost();
                            journalPost.MachineId = machine.MachineId;
                            journalPost.JournalDate = new SmartDate(DateTime.Now);
                            journalPost.EntryUnit = EntryUnit.ProducedItems;
                            journalPost.EntryValue = (moments - maintenance.MomentsTransferred);
                            journalPost.Save();

                            maintenance.MomentsTransferred = moments;
                        }

                        if (uptime != maintenance.UptimeTransferred)
                        {
                            logger.Trace("Transferring uptime. New: {0} Previous: {1}", uptime, maintenance.UptimeTransferred);
                            JournalPost journalPost = JournalPost.NewJournalPost();
                            journalPost.MachineId = machine.MachineId;
                            journalPost.JournalDate = new SmartDate(DateTime.Now);
                            journalPost.EntryUnit = EntryUnit.Hours;
                            journalPost.EntryValue = uptime - maintenance.UptimeTransferred;
                            journalPost.Save();

                            maintenance.UptimeTransferred = uptime;
                        }

                        maintenance.Save();
                    }
                }
                
                
            }
            catch (OPCException ex)
            {
                logger.ErrorException("Transferring data failed", ex);
            }
            catch (Exception ex)
            {
                logger.ErrorException("Transferring data failed", ex);
            }

            TeklaSettingCollection settings = TeklaSettingCollection.GetSettingCollection();
            m_Timer.Interval = settings.PollInterval;
            logger.Trace("Interval: {0}", settings.PollInterval);
        }
    }
}
