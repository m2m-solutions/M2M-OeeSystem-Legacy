using System;
using System.Linq;
using M2M.DataCenter.Utilities;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter
{
    public class AggregatedCombinedDataItem
    {
        private readonly AggregatedStoppageDataListItem stoppageData;
        private readonly AggregatedOeeDataItem oeeData;

        public string DivisionId
        {
            get
            {
                return this.stoppageData.DivisionId;
            }
        }

        public string MachineId { get { return this.stoppageData.MachineId; } }
        public string Category { get { return this.stoppageData.Category; } }
        public string Reason { get { return this.stoppageData.Reason; } }
        public int NumberOfStops { get { return this.stoppageData.NumberOfStops; } }
        public TimeSpan RegisteredStopTime { get { return this.stoppageData.ElapsedTime; } }
        public double StopTimePart { get { return this.stoppageData.TimePart; } }
        public double AverageTimeBetweenStops { get { return this.stoppageData.AverageTimeBetweenStops; } }
        public string AverageTimeBetweenStopsString { get { return this.stoppageData.AverageTimeBetweenStopsString; } }
        public TimeSpan ScheduledTime { get { return this.oeeData.ScheduledTime; } }
        public TimeSpan ScheduledTimeAverage { get { return this.oeeData.ScheduledTimeAverage; } }
        public TimeSpan ProductionTime { get { return this.oeeData.ActualProductionTime; } }
        public TimeSpan NoProductionTime { get { return this.oeeData.NoProductionTime; } }
        public TimeSpan AutoTime { get { return this.oeeData.AutoTime; } }
        public TimeSpan NotConnectedTime { get { return this.oeeData.NotConnectedTime; } }
        public TimeSpan StopTime { get { return this.oeeData.StopTime; } }
        public TimeSpan StopTimeForStations { get { return this.oeeData.StopTimeForStations; } }
        public TimeSpan UnregisteredStopTime { get { return StopTimeForStations - RegisteredStopTime; } }
        public TimeSpan ActualStopTime { get { return this.oeeData.ActualStopTime; } }
        public TimeSpan FlowErrorTime { get { return this.oeeData.FlowErrorTime; } }
        public double ProducedItems { get { return this.oeeData.Produced; } }
        public double DiscardedItems { get { return this.oeeData.Discarded; } }
        public double Availability { get { return this.oeeData.Availability; } }
        public double AvailabilityBasedOnActualStops { get { return this.oeeData.AvailabilityBasedOnActualStops; } }
        public double AvailabilityBasedOnFlowErrors { get { return this.oeeData.AvailabilityBasedOnFlowErrors; } }
        public double AvailabilityLoss { get { return this.oeeData.AvailabilityLoss; } }
        public double AvailabilityLossBasedOnActualStops { get { return this.oeeData.AvailabilityLossBasedOnActualStops; } }
        public double AvailabilityLossBasedOnFlowErrors { get { return this.oeeData.AvailabilityLossBasedOnFlowErrors; } }
        public double Performance { get { return this.oeeData.Performance; } }
        public double Quality { get { return this.oeeData.Quality; } }
        public double Oee { get { return this.oeeData.Oee; } }
        public double OeeNpb { get { return this.oeeData.OeeNpb; } }
        public double PerformanceNpb { get { return this.oeeData.PerformanceNpb; } }
        public double ProductionTimeNpb { get { return this.oeeData.ProductionTimeNpb; } }
        public double ProducedItemsInThousands { get { return Math.Round(this.oeeData.Produced / 1000); } }
        public double DiscardedItemsInThousands { get { return Math.Round(this.oeeData.Discarded / 1000); } }

        public double RegisteredStopTimeInSeconds { get { return RegisteredStopTime.TotalSeconds; } }
        public double RegisteredStopTimeInMinutes { get { return RegisteredStopTime.TotalMinutes; } }
        public double RegisteredStopTimeInHours { get { return RegisteredStopTime.TotalHours; } }

        public double StopTimeInSeconds { get { return StopTime.TotalSeconds; } }
        public double StopTimeInMinutes { get { return StopTime.TotalMinutes; } }
        public double StopTimeInHours { get { return StopTime.TotalHours; } }

        public double ActualStopTimeInSeconds { get { return ActualStopTime.TotalSeconds; } }
        public double ActualStopTimeInMinutes { get { return ActualStopTime.TotalMinutes; } }
        public double ActualStopTimeInHours { get { return ActualStopTime.TotalHours; } }

        public double FlowErrorTimeInSeconds { get { return FlowErrorTime.TotalSeconds; } }
        public double FlowErrorTimeInMinutes { get { return FlowErrorTime.TotalMinutes; } }
        public double FlowErrorTimeInHours { get { return FlowErrorTime.TotalHours; } }

        public double UnregisteredStopTimeInSeconds { get { return UnregisteredStopTime.TotalSeconds; } }
        public double UnregisteredStopTimeInMinutes { get { return UnregisteredStopTime.TotalMinutes; } }
        public double UnregisteredStopTimeInHours { get { return UnregisteredStopTime.TotalHours; } }
        
        public double ScheduledTimeInHours { get { return ScheduledTime.TotalHours; } }
        public double ScheduledTimeAverageInHours { get { return ScheduledTimeAverage.TotalHours; } }
        public double ActualProductionTimeInHours { get { return ProductionTime.TotalHours; } }
        public double AutoTimeInHours { get { return AutoTime.TotalHours; } }
        public double NoProductionTimeInHours { get { return NoProductionTime.TotalHours; } }
        public double NotConnectedTimeInHours { get { return NotConnectedTime.TotalHours; } }

        public string ReasonAbbr { get { return this.Reason.SafeSubstring(M2MDataCenter.SystemSettings.StoppageGraphLegendMax, true); } }
        public string ReasonAbbrForList { get { return this.Reason.SafeSubstring(M2MDataCenter.SystemSettings.StoppageListReasonMax, true); } }
        public string ReasonWithDivisionPrefix { get { return BuildReasonString(true, false); } }
        public string ReasonWithMachinePrefix { get { return BuildReasonString(false, true); } }
        public string ReasonWithFullPrefix { get { return BuildReasonString(true, true); } }

        public string DivisionAbbreviated
        {
            get
            {
                PlainDivisionListItem division = M2MDataCenter.GetDivision(DivisionId);
                if (division == null)
                    return "";
                return division.ShortName;
            }
        }

        public string MachineAbbreviated
        {
            get
            {
                PlainMachineListItem machine = M2MDataCenter.GetMachine(DivisionId, MachineId);
                if (machine == null)
                    return "";
                return machine.ShortName;
            }
        }

        private string BuildReasonString(bool showDivision, bool showMachine)
        {
            if (!showDivision && !showMachine || Reason == ResourceStrings.GetString("Other"))
                return ReasonAbbr;

            string reason = "";

            if (showDivision)
                reason += DivisionAbbreviated + ":";

            if (showMachine)
                reason += MachineAbbreviated + ":";

            int length = M2MDataCenter.SystemSettings.StoppageGraphLegendMax - reason.Length;

            return reason + Reason.SafeSubstring(length, true);
        }

        public string Division
        {
            get
            {
                if (DivisionId == null)
                    return "";
                return M2MDataCenter.GetDivision(DivisionId).DisplayName;
            }
        }

        public string Machine
        {
            get
            {
                if (DivisionId == null || MachineId == null)
                    return "";
                return M2MDataCenter.GetMachine(DivisionId, MachineId).DisplayName;
            }
        }

        public AggregatedCombinedDataItem(AggregatedStoppageDataListItem stoppageData, AggregatedOeeDataItem oeeData)
        {
            this.stoppageData = stoppageData;
            this.oeeData = oeeData;
        }
    }
}
