using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2M.DataCollector.Library
{
    public class MachineState
    {
        public bool UseMomentsForMaintenance { set; get; }
        public string DivisionId { set; get; }
        
        public abstract class StateInfo
        {
            public DateTime TimeStamp { set; get; }
            public bool? Connected { set; get; }
            public bool? Auto { set; get; }
            public bool? Shutdowned { set; get; }
            public string Article { set; get; }
            public int? Cycles { set; get; }
            public int? Moments { set; get; }
            public int? Rejected { set; get; }
            public bool FlowErrorActive { set; get; }
            public bool ValidAuto { set; get; }
            public bool ChangeOverActive { set; get; }
            public DateTime LastUpdatedAuto { set; get; }
        }

        public class PendingState : StateInfo
        {
            public List<string> ActiveStops { set; get; }

            public PendingState()
            {
                this.ActiveStops = new List<string>();
            }
        }

        public class StoredState : StateInfo
        {
            public string ActiveStop { set; get; }

            public StoredState()
            {
                this.ActiveStop = "";
            }
        }

        public class ActionSettings
        {
            public bool IgnoreArticleStateChange { set; get; }
            public string PanelIpAddress { get; set; }
            public int PanelTcpPort { get; set; }
            public int AllowedCycleDiff { get; set; }
            public int MinValidAutoTime { get; set; }
            public bool AllowNegativeScrap { get; set; }
            public string AccessPath { get; set; }
            
            public ActionSettings()
            {
                this.IgnoreArticleStateChange = false;
                this.PanelIpAddress = "";
                this.PanelTcpPort = 0;
                this.AllowedCycleDiff = 5;
                this.AllowNegativeScrap = false;
                this.MinValidAutoTime = 0;
                this.AccessPath = "";
            }
        }

        public PendingState Pending { set; get; }
        public StoredState Stored { set; get; }
        public ActionSettings Settings { set; get; }
        
        public MachineState(string divisionId)
        {
            this.DivisionId = divisionId;
            this.Pending = new PendingState();
            this.Stored = new StoredState();
            this.Settings = new ActionSettings();
       
            ClearAll();
        }

        public void ClearAll()
        {
            this.UseMomentsForMaintenance = false;
            
            ClearPending();
            ClearStored();
        }

        public void ClearPending()
        {
            this.Pending.TimeStamp = DateTime.MinValue;
            this.Pending.Connected = null;
            this.Pending.Auto = null;
            this.Pending.Shutdowned = null;
            this.Pending.Article = "";
            this.Pending.Cycles = null;
            this.Pending.Moments = null;
            this.Pending.Rejected = null;
            this.Pending.ActiveStops.Clear();
            this.Pending.FlowErrorActive = false;
            this.Pending.ValidAuto = false;
            this.Pending.ChangeOverActive = false;
            this.Pending.LastUpdatedAuto = DateTime.MaxValue;
        }

        public void ClearStored()
        {
            this.Stored.TimeStamp = DateTime.MinValue;
            this.Stored.Connected = null;
            this.Stored.Auto = null;
            this.Stored.Shutdowned = null;
            this.Stored.Article = "";
            this.Stored.Cycles = null;
            this.Stored.Moments = null;
            this.Stored.Rejected = 0;
            this.Stored.ActiveStop = "";
            this.Stored.FlowErrorActive = false;
            this.Stored.ValidAuto = false;
            this.Stored.ChangeOverActive = false;
            this.Stored.LastUpdatedAuto = DateTime.MaxValue;
        }

        public bool VerifyPending()
        {
            if (!this.Pending.Connected.HasValue)
                return false;

            if (this.Pending.Connected.Value)
            {
                if (!this.Pending.Auto.HasValue)
                    return false;

                if (!this.Pending.Cycles.HasValue)
                    return false;

                if (this.UseMomentsForMaintenance && !this.Pending.Moments.HasValue)
                    return false;

                if (!this.Pending.Shutdowned.HasValue)
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine(String.Format("TimeStamp - Stored: {0} Pending: {1}", this.Stored.TimeStamp, this.Pending.TimeStamp));
            strBuilder.AppendLine(String.Format("Connected - Stored: {0} Pending: {1}", this.Stored.Connected, this.Pending.Connected));
            strBuilder.AppendLine(String.Format("Auto - Stored: {0} Pending: {1}", this.Stored.Auto, this.Pending.Auto));
            strBuilder.AppendLine(String.Format("Shutdowned - Stored: {0} Pending: {1}", this.Stored.Shutdowned, this.Pending.Shutdowned));
            strBuilder.AppendLine(String.Format("Article - Stored: {0} Pending: {1}", this.Stored.Article, this.Pending.Article));
            strBuilder.AppendLine(String.Format("Cycles - Stored: {0} Pending: {1}", this.Stored.Cycles, this.Pending.Cycles));
            strBuilder.AppendLine(String.Format("Moments - Stored: {0} Pending: {1}", this.Stored.Moments, this.Pending.Moments));
            strBuilder.AppendLine(String.Format("Rejected - Stored: {0} Pending: {1}", this.Stored.Rejected, this.Pending.Rejected));
            strBuilder.AppendLine(String.Format("Flow Error Active - Stored: {0} Pending: {1}", this.Stored.FlowErrorActive, this.Pending.FlowErrorActive));
            strBuilder.AppendLine(String.Format("ValidAuto - Stored: {0} Pending: {1}", this.Stored.ValidAuto, this.Pending.ValidAuto));
            strBuilder.AppendLine(String.Format("ChangeOver Active - Stored: {0} Pending: {1}", this.Stored.ChangeOverActive, this.Pending.ChangeOverActive));
            strBuilder.AppendLine(String.Format("ActiveStop - Stored: {0} Pending: {1} ({2})", this.Stored.ActiveStop, this.Pending.ActiveStops.Count > 0 ? this.Pending.ActiveStops[0] : "", this.Pending.ActiveStops.Count));
            strBuilder.AppendLine(String.Format("LastUpdatedAuto - Stored: {0} Pending: {1}", this.Stored.LastUpdatedAuto, this.Pending.LastUpdatedAuto));
            return strBuilder.ToString();
        }
    }
}
