using System;
using System.Linq;
using System.Globalization;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter
{
    public enum XTypes
    {
        None = 0,
        Period = 1,
        Article = 2,
        Machine = 3,
        Division = 4
    }

    public class AggregatedOeeDataItem
    {
        private double m_Availability = 0.0;
        private double m_AvailabilityBasedOnScheduledTime = 0.0;
        private double m_AvailabilityBasedOnActualStops = 0.0;
        private double m_AvailabilityBasedOnFlowErrors = 0.0;
        private double m_AvailabilityLoss = 0.0;
        private double m_AvailabilityLossBasedOnActualStops = 0.0;
        private double m_AvailabilityLossBasedOnFlowErrors = 0.0;
        private double m_Performance = 1.0;
        private double m_Quality = 1.0;
        private string m_Division = "";
        private string m_Machine = "";
        private string m_MachineShortName = "";
        private string m_DivisionId = "";
        private string m_MachineId = "";
        private string m_ArticleNumber = "";
        private Intervals m_Interval = Intervals.NotDefined;
        private DateTime m_Date;
        private XTypes m_XType = XTypes.None;
        private TimeSpan m_AutoTime = new TimeSpan(0);
        private TimeSpan m_ScheduledTime = new TimeSpan(0);
        private TimeSpan m_ScheduledTimeAverage = new TimeSpan(0);
        private TimeSpan m_NotScheduledTime = new TimeSpan(0);
        private TimeSpan m_NoProductionTime = new TimeSpan(0);
        private TimeSpan m_NotConnectedTime = new TimeSpan(0);
        private TimeSpan m_FlowErrorTime = new TimeSpan(0);
        private TimeSpan m_ChangeOverTime = new TimeSpan(0);
        private double m_Produced = 0.0;
        private double m_Discarded = 0.0;
        private double m_IdealRunRate = 0.0;
      
        public AggregatedOeeDataItem()
        {

        }

        public XTypes XType
        {
            get
            {
                return m_XType;
            }
            set
            {
                m_XType = value;
            }
        }

        public TimeSpan AutoTime
        {
            get
            {
                return m_AutoTime;
            }
            set
            {
                m_AutoTime = value;
            }
        }

        public double AutoTimeInMinutes
        {
            get { return AutoTime.TotalMinutes; }
        }

        public double AutoTimeInHours
        {
            get { return AutoTime.TotalHours; }
        }

        public double AutoTimeInSeconds
        {
            get { return AutoTime.TotalSeconds; }
        }

        public TimeSpan ScheduledTime
        {
            get
            {
                return m_ScheduledTime;
            }
            set
            {
                m_ScheduledTime = value;
            }
        }

        public TimeSpan ScheduledTimeAverage
        {
            get
            {
                return m_ScheduledTimeAverage;
            }
            set
            {
                m_ScheduledTimeAverage = value;
            }
        }

        public double ScheduledTimeInMinutes
        {
            get { return ScheduledTime.TotalMinutes; }
        }

        public double ScheduledTimeInHours
        {
            get { return ScheduledTime.TotalHours; }
        }

        public double ScheduledTimeInSeconds
        {
            get { return ScheduledTime.TotalSeconds; }
        }

        public TimeSpan NotScheduledTime
        {
            get
            {
                return m_NotScheduledTime;
            }
            set
            {
                m_NotScheduledTime = value;
            }
        }

        public double NotScheduledTimeInMinutes
        {
            get { return NotScheduledTime.TotalMinutes; }
        }

        public double NotScheduledTimeInHours
        {
            get { return NotScheduledTime.TotalHours; }
        }

        public double NotScheduledTimeInSeconds
        {
            get { return NotScheduledTime.TotalSeconds; }
        }

        public TimeSpan StopTimeForStations
        {
            get;
            set;
        }

        public TimeSpan StopTime
        {
            get
            {
                return ActualProductionTime - m_AutoTime;
            }
        }

        public double StopTimeInMinutes
        {
            get { return StopTime.TotalMinutes; }
        }

        public double StopTimeInHours
        {
            get { return StopTime.TotalHours; }
        }

        public double StopTimeInSeconds
        {
            get { return StopTime.TotalSeconds; }
        }

        public TimeSpan FlowErrorTime
        {
            get
            {
                return m_FlowErrorTime;
            }
            set
            {
                m_FlowErrorTime = value;
            }
        }

        public double FlowErrorTimeInMinutes
        {
            get { return FlowErrorTime.TotalMinutes; }
        }

        public double FlowErrorTimeInHours
        {
            get { return FlowErrorTime.TotalHours; }
        }

        public double FlowErrorTimeInSeconds
        {
            get { return FlowErrorTime.TotalSeconds; }
        }

        public TimeSpan ChangeOverTime
        {
            get
            {
                return m_ChangeOverTime;
            }
            set
            {
                m_ChangeOverTime = value;
            }
        }

        public double ChangeOverTimeInMinutes
        {
            get { return ChangeOverTime.TotalMinutes; }
        }

        public double ChangeOverTimeInHours
        {
            get { return ChangeOverTime.TotalHours; }
        }

        public double ChnageOverTimeInSeconds
        {
            get { return ChangeOverTime.TotalSeconds; }
        }

        public TimeSpan ActualStopTime
        {
            get
            {
                return StopTime - FlowErrorTime;
            }
        }

        public double ActualStopTimeInMinutes
        {
            get { return ActualStopTime.TotalMinutes; }
        }

        public double ActualStopTimeInHours
        {
            get { return ActualStopTime.TotalHours; }
        }

        public double ActualStopTimeInSeconds
        {
            get { return ActualStopTime.TotalSeconds; }
        }

        public TimeSpan ActualProductionTime
        {
            get
            {
                return m_ScheduledTime - m_NoProductionTime - NotConnectedTime;
            }
        }

        public double ActualProductionTimeInMinutes
        {
            get { return ActualProductionTime.TotalMinutes; }
        }

        public double ActualProductionTimeInHours
        {
            get { return ActualProductionTime.TotalHours; }
        }

        public double ActualProductionTimeInSeconds
        {
            get { return ActualProductionTime.TotalSeconds; }
        }

        public TimeSpan NoProductionTime
        {
            get
            {
                return m_NoProductionTime;
            }
            set
            {
                m_NoProductionTime = value;
            }
        }

        public double NoProductionTimeInMinutes
        {
            get { return NoProductionTime.TotalMinutes; }
        }

        public double NoProductionTimeInHours
        {
            get { return NoProductionTime.TotalHours; }
        }

        public double NoProductionTimeInSeconds
        {
            get { return NoProductionTime.TotalSeconds; }
        }

        public TimeSpan NotConnectedTime
        {
            get
            {
                return m_NotConnectedTime;
            }
            set
            {
                m_NotConnectedTime = value;
            }
        }

        public double NotConnectedTimeInMinutes
        {
            get { return NotConnectedTime.TotalMinutes; }
        }

        public double NotConnectedTimeInHours
        {
            get { return NotConnectedTime.TotalHours; }
        }

        public double NotConnectedTimeInSeconds
        {
            get { return NotConnectedTime.TotalSeconds; }
        }

        public double Produced
        {
            get
            {
                return m_Produced;
            }
            set
            {
                m_Produced = value;
            }
        }

        public double Discarded
        {
            get
            {
                return m_Discarded;
            }
            set
            {
                m_Discarded = value;
            }
        }

        public int IdealProducedItems
        {
            get
            {
                if (m_Performance <= 0)
                    return 0;

                return (int)Math.Round(m_Produced / m_Performance, 0);
            }
        }

        public int IdealProducedItems2
        {
            get
            {
                if (m_Performance <= 0 || m_Availability <= 0)
                    return 0;

                return (int)Math.Round(Produced/ (m_Availability * m_Performance), 0);
            }
        }

        public double RunRate
        {
            get
            {
                if (ActualProductionTime.Ticks > 0)
                    return Produced / (ActualProductionTime.TotalHours);

                return 0;
            }
        }

        public double IdealRunRate
        {
            get
            {
                return m_IdealRunRate;
            }
            set
            {
                m_IdealRunRate = value;
            }
        }
        
        public double Availability
        {
            get
            {
                return m_Availability;
            }
            set
            {
                m_Availability = value;
            }
        }

        public double AvailabilityBasedOnScheduledTime
        {
            get
            {
                return m_AvailabilityBasedOnScheduledTime;
            }
            set
            {
                m_AvailabilityBasedOnScheduledTime = value;
            }
        }

        public double AvailabilityBasedOnActualStops
        {
            get
            {
                return m_AvailabilityBasedOnActualStops;
            }
            set
            {
                m_AvailabilityBasedOnActualStops = value;
            }
        }

        public double AvailabilityBasedOnFlowErrors
        {
            get
            {
                return m_AvailabilityBasedOnFlowErrors;
            }
            set
            {
                m_AvailabilityBasedOnFlowErrors = value;
            }
        }

        public double Performance
        {
            get
            {

                return m_Performance;
            }
            set
            {
                m_Performance = value;
            }
        }

        public double Quality
        {
            get
            {
                return m_Quality;
            }
            set
            {
                m_Quality = value;
            }
        }

        public double Oee
        {
            get
            {
                return Availability * Performance * Quality;
            }
        }

        public string ArticleNumber
        {
            get
            {
                return m_ArticleNumber;
            }
            set
            {
                m_ArticleNumber = value;
            }
        }

        public string Division
        {
            get
            {
                return m_Division;
            }
            set
            {
                m_Division = value;
            }
        }

        public string Machine
        {
            get
            {
                return m_Machine;
            }
            set
            {
                m_Machine = value;
            }
        }

        public string MachineShortName
        {
            get
            {
                return m_MachineShortName;
            }
            set
            {
                m_MachineShortName = value;
            }
        }

        public string DivisionId
        {
            get
            {
                return m_DivisionId;
            }
            set
            {
                m_DivisionId = value;
            }
        }

        public string MachineId
        {
            get
            {
                return m_MachineId;
            }
            set
            {
                m_MachineId = value;
            }
        }

       
        public double OeeNpb
        {
            get
            {
                return AvailabilityBasedOnScheduledTime * Performance * Quality;
            }
        }

        public double PerformanceNpb
        {
            get
            {
                return AvailabilityBasedOnScheduledTime * Performance;
            }
        }

        public double ProductionTimeNpb
        {
            get
            {
                return ScheduledTimeInHours * PerformanceNpb;
            }
        }

        public double NonAvailability
        {
            get
            {
                return (1.0 - Availability) * LossRatio;
            }
        }


        public double NonAvailabilityNpb
        {
            get
            {
                return (1.0 - Availability) * LossRatioNpb;
            }
        }

        public double RunRateLoss
        {
            get
            {
                return (1.0 - Performance) * LossRatio;
            }
        }

        public double RunRateLossNpb
        {
            get
            {
                return 1.0 - OeeNpb - QualityLossNpb - NonAvailabilityNpb;
            }
        }

        private double LossRatio
        {
            get
            {
                if (Oee == 1.0)
                    return 1.0;
                return (1.0 - Oee) / (3.0 - Availability - Performance - Quality);
            }
        }

        private double LossRatioNpb
        {
            get
            {
                if (OeeNpb == 1.0)
                    return 1.0;
                return (1.0 - OeeNpb) / (3.0 - AvailabilityLossBasedOnActualStops - Performance - Quality);
            }
        }

        
        public double QualityLossNpb
        {
            get
            {
                return (1.0 - Quality) * LossRatioNpb;
            }
        }

        public double QualityLoss
        {
            get
            {
                return (1.0 - Quality) * LossRatio;
            }
        }

        public double AvailabilityLoss
        {
            get
            {
                return m_AvailabilityLoss;
            }
            set
            {
                m_AvailabilityLoss = value;
            }
        }

        public double AvailabilityLossBasedOnActualStops
        {
            get
            {
                return m_AvailabilityLossBasedOnActualStops;
            }
            set
            {
                m_AvailabilityLossBasedOnActualStops = value;
            }
        }

        public double AvailabilityLossBasedOnFlowErrors
        {
            get
            {
                return m_AvailabilityLossBasedOnFlowErrors;
            }
            set
            {
                m_AvailabilityLossBasedOnFlowErrors = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return m_Date;
            }
            set
            {
                m_Date = value;
            }
        }

        public double DateAsDouble
        {
            get
            {
                return m_Date.ToOADate();
            }
        }

        public Intervals Interval
        {
            get
            {
                return m_Interval;
            }
            set
            {
                m_Interval = value;
            }
        }

        public string XLabel
        {
            get
            {
                switch (m_XType)
                {
                    case XTypes.Period:
                        switch (m_Interval)
                        {
                            case Intervals.Daily:
                                return m_Date.ToString("MMM dd");
                            case Intervals.Weekly:
                                CultureInfo culture = CultureInfo.CurrentCulture;
                                int weekNumber = culture.Calendar.GetWeekOfYear(m_Date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                                return String.Format("v {0}", weekNumber);
                            case Intervals.Monthly:
                                return m_Date.ToString("yyyy MMM");
                            case Intervals.Quarterly:
                                Quarter quarter = m_Date.GetQuarter();
                                return String.Format("{0} Q{1}", m_Date.ToString("yyyy"), (int)quarter);
                            case Intervals.Yearly:
                                return m_Date.ToString("yyyy");
                        }
                        break;
                    case XTypes.Article:
                        return m_ArticleNumber;
                    case XTypes.Machine:
                        return m_Machine;
                    case XTypes.Division:
                        return m_Division;
                }

                return "";
            }
        }
    }
}
