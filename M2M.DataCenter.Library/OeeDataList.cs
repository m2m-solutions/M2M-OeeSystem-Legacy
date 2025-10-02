using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using System.Collections.Generic;

namespace M2M.DataCenter
{
	[Serializable()]
	public class OeeDataList : ReadOnlyListBase<OeeDataList, OeeDataListItem>
	{
		#region Business Methods

		private double m_AutoTime = 0;
        private double m_ProductionTime = 0;
		private double m_NoProductionTime = 0;
        private double m_NotConnectedTime = 0;
        private double m_StopTime = 0;
        private double m_ActualStopTime = 0;
        private double m_FlowErrorTime = 0;
        private double m_ChangeOverTime = 0;
		private double m_TotalTime = 0;
		private int m_ProducedItems = 0;
		private int m_DiscardedItems = 0;
        private Criteria m_CurrentCriteria = null;
        
		public double TotalTime
		{
			get
			{
				return m_TotalTime;
			}
		}

		public double TotalAutoTime
		{
			get
			{
				return m_AutoTime;
			}
		}

        public double TotalProductionTime
        {
            get
            {
                return m_ProductionTime;
            }
        }

        public double TotalNoProductionTime
		{
			get
			{
				return m_NoProductionTime;
			}
		}

        public double TotalNotConnectedTime
        {
            get
            {
                return m_NotConnectedTime;
            }
        }

        public double TotalFlowErrorTime
        {
            get
            {
                return m_FlowErrorTime;
            }
        }

        public double TotalChangeOverTime
        {
            get
            {
                return m_ChangeOverTime;
            }
        }

        public double TotalStopTime
		{
			get
			{
				return m_StopTime;
			}
		}

        public double TotalActualStopTime
        {
            get
            {
                return m_ActualStopTime;
            }
        }

		public int ProducedItems
		{
			get
			{
				return m_ProducedItems;
			}
		}

		public int DiscardedItems
		{
			get
			{
				return m_DiscardedItems;
			}
		}

		internal void CalculateSums()
		{
			foreach (OeeDataListItem item in this)
			{
				m_AutoTime += item.AutoTime;
				m_TotalTime += item.TotalTime;
                m_NoProductionTime += item.NoProductionTime;
                m_NotConnectedTime += item.NotConnectedTime;
                m_FlowErrorTime += item.FlowErrorTime;
                m_ChangeOverTime += item.ChangeOverTime;
				m_ProducedItems += item.ProducedItems;
				m_DiscardedItems += item.DiscardedItems;
                m_ProductionTime += item.ProductionTime;
                m_StopTime += item.StopTime;
                m_ActualStopTime += item.ActualStopTime;
    		}
		}

        public List<AggregatedOeeDataItem> GetTotalData(bool aggregateData)
        {
            List<AggregatedOeeDataItem> oeeData = new List<AggregatedOeeDataItem>();

            var grouped = this.OrderBy(a => a.DivisionId).GroupBy(a => a.DivisionId);

            double totalAutoTime = 0;
            double totalAutoTimeForPerformance = 0;
            double totalStopTimeForStations = 0;
            double totalScheduledTime = 0;
            double totalNoProductionTime = 0;
            double totalNotConnectedTime = 0;
            long totalProducedItems = 0;
            long totalDiscardedItems = this.Sum(a => (long)a.DiscardedItems);
            double totalProductionTime = 0;
            double totalStopTime = 0;
            double totalActualStopTime = 0;
            double totalFlowErrorTime = 0;
            double totalChangeOverTime = 0;
            int machineCount = 0;

            foreach (var group in grouped)
            {
                totalAutoTime += (aggregateData) ? group.Where(a => a.AggregateAvailability).Sum(a => a.AutoTime) : group.Sum(a => a.AutoTime);
                totalStopTime += (aggregateData) ? group.Where(a => a.AggregateAvailability).Sum(a => a.StopTime) : group.Sum(a => a.StopTime);
                totalActualStopTime += (aggregateData) ? group.Where(a => a.AggregateAvailability).Sum(a => a.ActualStopTime) : group.Sum(a => a.ActualStopTime);
                totalFlowErrorTime += (aggregateData) ? group.Where(a => a.AggregateAvailability).Sum(a => a.FlowErrorTime) : group.Sum(a => a.FlowErrorTime);
                totalChangeOverTime += (aggregateData) ? group.Where(a => a.AggregateAvailability).Sum(a => a.ChangeOverTime) : group.Sum(a => a.ChangeOverTime);
                totalProductionTime += (aggregateData) ? group.Where(a => a.AggregateAvailability).Sum(a => a.ProductionTime) : group.Sum(a => a.ProductionTime);
                totalAutoTimeForPerformance += (aggregateData) ? group.Where(a => a.AggregatePerformance).Sum(a => a.AutoTime) : group.Sum(a => a.AutoTime);
                totalScheduledTime += (aggregateData) ? group.Where(a => a.AggregateAvailability).Sum(a => a.TotalTime) : group.Sum(a => a.TotalTime);
                totalNoProductionTime += (aggregateData) ? group.Where(a => a.AggregateAvailability).Sum(a => a.NoProductionTime) : group.Sum(a => a.NoProductionTime);
                totalNotConnectedTime += (aggregateData) ? group.Where(a => a.AggregateAvailability).Sum(a => a.NotConnectedTime) : group.Sum(a => a.NotConnectedTime);
                totalProducedItems += (aggregateData) ? group.Where(a => a.AggregateCounter).Sum(a => (long)a.ProducedItems) : group.Sum(a => (long)a.ProducedItems);
                double stopTimeForStations = group.Sum(a => a.TotalTime) - group.Sum(a => a.NoProductionTime) - group.Sum(a => a.NotConnectedTime) - group.Sum(a => a.AutoTime);
                if (stopTimeForStations > 0)
                    totalStopTimeForStations += stopTimeForStations;
                machineCount += M2MDataCenter.GetMachineList(group.Key).Where(a => a.AggregateAvailability).Count();
            }

            AggregatedOeeDataItem timePart = new AggregatedOeeDataItem();
            timePart.XType = XTypes.None;
            timePart.AutoTime = TimeSpan.FromSeconds(totalAutoTime);
            timePart.ScheduledTime = TimeSpan.FromSeconds(totalScheduledTime);
            
            timePart.NoProductionTime = TimeSpan.FromSeconds(totalNoProductionTime);
            timePart.NotConnectedTime = TimeSpan.FromSeconds(totalNotConnectedTime);
            timePart.StopTimeForStations = TimeSpan.FromSeconds(totalStopTimeForStations);
            timePart.FlowErrorTime = TimeSpan.FromSeconds(totalFlowErrorTime);
            timePart.ChangeOverTime = TimeSpan.FromSeconds(totalChangeOverTime);
            timePart.Produced = totalProducedItems;
            timePart.Discarded = totalDiscardedItems;

            if (totalScheduledTime > 0)
            {
                timePart.AvailabilityBasedOnScheduledTime = totalAutoTime / totalScheduledTime;
                timePart.ScheduledTimeAverage = TimeSpan.FromSeconds(totalScheduledTime / machineCount);
            }

            if (totalProductionTime > 0)
            {
                timePart.Availability = totalAutoTime / totalProductionTime;
                timePart.AvailabilityBasedOnActualStops = (totalAutoTime + totalFlowErrorTime) / totalProductionTime;
                timePart.AvailabilityBasedOnFlowErrors = (totalAutoTime + totalActualStopTime) / totalProductionTime;
                timePart.AvailabilityLoss = totalStopTime / totalProductionTime;
                timePart.AvailabilityLossBasedOnActualStops = (totalActualStopTime) / totalProductionTime;
                timePart.AvailabilityLossBasedOnFlowErrors = totalFlowErrorTime / totalProductionTime;
            }

            if (totalProducedItems > 0)
                timePart.Quality = 1.0 - (double)totalDiscardedItems / (double)totalProducedItems;

            if (totalAutoTimeForPerformance > 0 || M2MDataCenter.GetAvailableModules().Contains("Npb") && totalScheduledTime > 0)
            {
                if(totalAutoTimeForPerformance > 0)
                    timePart.Performance = 0;

                foreach (var item in this)
                {
                    if (aggregateData && !item.AggregatePerformance)
                        continue;

                    double? idealRunRate = M2MDataCenter.GetIdealCycleTime(item.DivisionId, item.MachineId, item.ArticleNumber.Trim());

                    if (idealRunRate != null && item.RunRate != 0)
                    {
                        if (totalAutoTimeForPerformance > 0)
                            timePart.Performance += ((double)idealRunRate / item.RunRate) * (item.AutoTime / totalAutoTimeForPerformance);

                        if (M2MDataCenter.GetAvailableModules().Contains("Npb") && totalScheduledTime > 0)
                        {
                            //timePart.MaxPossibleProducedNpb += (item.TotalTime / (double)idealRunRate * 1000);
                            //timePart.MaxPossibleProducedDuringAutoNpb += (item.AutoTime / (double)idealRunRate * 1000);
                        }
                    }
                }
            }

            oeeData.Add(timePart);

            return oeeData;
        }

        public List<AggregatedOeeDataItem> GetPeriodicDataForWeightedStoppages(Intervals interval)
        {
            List<AggregatedOeeDataItem> oeeList = new List<AggregatedOeeDataItem>();

            if (interval < Intervals.Daily || interval > Intervals.Monthly)
                return oeeList;

            DateTime currentDate = m_CurrentCriteria.StartTime.Date;

            while (currentDate < m_CurrentCriteria.EndTime.Date)
            {
                DateTime currentStopDate = new DateTime();

                switch (interval)
                {
                    case Intervals.Daily:
                        currentStopDate = currentDate.AddDays(1);
                        break;
                    case Intervals.Weekly:
                        currentStopDate = currentDate.AddDays(7);
                        break;
                    case Intervals.Monthly:
                        currentStopDate = currentDate.AddMonths(1);
                        break;
                }

                var groupedOee = this.Where(d => d.StartTime >= currentDate).Where(a => a.StartTime < currentStopDate).ToList();

                AggregatedOeeDataItem timePart = new AggregatedOeeDataItem();
                timePart.DivisionId = m_CurrentCriteria.DivisionId;
                timePart.MachineId = m_CurrentCriteria.MachineId;
                timePart.Machine = M2MDataCenter.GetMachine(m_CurrentCriteria.MachineId).DisplayName;
                timePart.AutoTime = TimeSpan.FromSeconds(groupedOee.Sum( a => a.AutoTime));
                timePart.ScheduledTime = TimeSpan.FromSeconds(groupedOee.Sum( a => a.TotalTime));
                timePart.NoProductionTime = TimeSpan.FromSeconds(groupedOee.Sum( a => a.NoProductionTime));
                timePart.NotConnectedTime = TimeSpan.FromSeconds(groupedOee.Sum( a => a.NotConnectedTime));
                timePart.FlowErrorTime = TimeSpan.FromSeconds(groupedOee.Sum( a => a.FlowErrorTime));
                timePart.ChangeOverTime = TimeSpan.FromSeconds(groupedOee.Sum(a => a.ChangeOverTime));
                timePart.Date = currentDate;
                oeeList.Add(timePart);
                currentDate = currentStopDate;
            }

            return oeeList;
        }

        public List<AggregatedOeeDataItem> GetPeriodicData(Intervals interval, bool aggregateData)
        {
            List<AggregatedOeeDataItem> oeeData = new List<AggregatedOeeDataItem>();

            var grouped = this.OrderBy(s => s.StartTime.Date.Date).GroupBy(c => c.StartTime.Date.Date);

            foreach (var group in grouped)
            {
                double totalAutoTime = 0;
                double totalScheduledTime = 0;
                double totalNoProductionTime = 0;
                double totalNotConnectedTime = 0;
                long totalProducedItems = 0;
                long totalDiscardedItems = 0;
                double totalAutoTimeForPerformance = 0;
                double totalProductionTime = 0;
                double totalStopTime = 0;
                double totalActualStopTime = 0;
                double totalFlowErrorTime = 0;
                double totalChangeOverTime = 0;

                var divisions = group.GroupBy(a => a.DivisionId);

                foreach (var division in divisions)
                {
                    totalAutoTime += aggregateData ? division.Where(a => a.AggregateAvailability).Sum(a => a.AutoTime) : division.Sum(a => a.AutoTime);
                    totalStopTime += (aggregateData) ? division.Where(a => a.AggregateAvailability).Sum(a => a.StopTime) : division.Sum(a => a.StopTime);
                    totalActualStopTime += (aggregateData) ? division.Where(a => a.AggregateAvailability).Sum(a => a.ActualStopTime) : division.Sum(a => a.ActualStopTime);
                    totalFlowErrorTime += (aggregateData) ? division.Where(a => a.AggregateAvailability).Sum(a => a.FlowErrorTime) : division.Sum(a => a.FlowErrorTime);
                    totalChangeOverTime += (aggregateData) ? division.Where(a => a.AggregateAvailability).Sum(a => a.ChangeOverTime) : division.Sum(a => a.ChangeOverTime);
                    totalProductionTime += (aggregateData) ? division.Where(a => a.AggregateAvailability).Sum(a => a.ProductionTime) : division.Sum(a => a.ProductionTime);
                    totalAutoTimeForPerformance += aggregateData ? division.Where(a => a.AggregatePerformance).Sum(a => a.AutoTime) : division.Sum(a => a.AutoTime);
                    totalScheduledTime += aggregateData ? division.Where(a => a.AggregateAvailability).Sum(a => a.TotalTime) : division.Sum(a => a.TotalTime);
                    totalNoProductionTime += aggregateData ? division.Where(a => a.AggregateAvailability).Sum(a => a.NoProductionTime) : division.Sum(a => a.NoProductionTime);
                    totalNotConnectedTime += aggregateData ? division.Where(a => a.AggregateAvailability).Sum(a => a.NotConnectedTime) : division.Sum(a => a.NotConnectedTime);
                    totalProducedItems += aggregateData ? division.Where(a => a.AggregateCounter).Sum(a => (long)a.ProducedItems) : division.Sum(a => (long)a.ProducedItems);
                    totalDiscardedItems += division.Sum(a => (long)a.DiscardedItems);
                }

                AggregatedOeeDataItem timePart = new AggregatedOeeDataItem();
                timePart.XType = XTypes.Period;
                timePart.Interval = interval;
                timePart.Date = group.Key;
                timePart.AutoTime = TimeSpan.FromSeconds(totalAutoTime);
                timePart.ScheduledTime = TimeSpan.FromSeconds(totalScheduledTime);
                timePart.NoProductionTime = TimeSpan.FromSeconds(totalNoProductionTime);
                timePart.NotConnectedTime = TimeSpan.FromSeconds(totalNotConnectedTime);
                timePart.FlowErrorTime = TimeSpan.FromSeconds(totalFlowErrorTime);
                timePart.ChangeOverTime = TimeSpan.FromSeconds(totalChangeOverTime);
                timePart.Produced = totalProducedItems;
                timePart.Discarded = totalDiscardedItems;

                if (totalScheduledTime > 0)
                    timePart.AvailabilityBasedOnScheduledTime = totalAutoTime / totalScheduledTime;

                if (totalProductionTime > 0)
                {
                    timePart.Availability = totalAutoTime / totalProductionTime;
                    timePart.AvailabilityBasedOnActualStops = (totalAutoTime + totalFlowErrorTime) / totalProductionTime;
                    timePart.AvailabilityBasedOnFlowErrors = (totalAutoTime + totalActualStopTime) / totalProductionTime;
                    timePart.AvailabilityLoss = totalStopTime / totalProductionTime;
                    timePart.AvailabilityLossBasedOnActualStops = (totalActualStopTime) / totalProductionTime;
                    timePart.AvailabilityLossBasedOnFlowErrors = totalFlowErrorTime / totalProductionTime;
                }

                if (totalProducedItems > 0)
                    timePart.Quality = 1.0 - (double)totalDiscardedItems / (double)totalProducedItems;

                if (totalAutoTimeForPerformance > 0)
                {
                    timePart.Performance = 0;

                    foreach (var subGroup in group.GroupBy(c => c.ArticleNumber))
                    {
                        foreach (var item in subGroup)
                        {
                            if (aggregateData && !item.AggregatePerformance)
                                continue;

                            timePart.Interval = interval;
                            timePart.Date = item.StartTime.Date.Date;

                            double? idealRunRate = M2MDataCenter.GetIdealCycleTime(item.DivisionId, item.MachineId, item.ArticleNumber.Trim());

                            if (idealRunRate != null && item.RunRate != 0)
                            {
                                timePart.Performance += ((double)idealRunRate / item.RunRate) * (item.AutoTime / totalAutoTimeForPerformance);
                            }
                        }
                    }
                }

                oeeData.Add(timePart);
            }

            return oeeData;
        }

        public AggregatedOeeDataItem GetMachineData(string machineId)
        {
            var machineData = this.Where(a => a.MachineId == machineId);

            double totalAutoTime = machineData.Sum(a => a.AutoTime);
            double totalScheduledTime = machineData.Sum(a => a.TotalTime);
            double totalNoProductionTime = machineData.Sum(a => a.NoProductionTime);
            double totalNotConnectedTime = machineData.Sum(a => a.NotConnectedTime);
            long totalProducedItems = machineData.Sum(a => (long)a.ProducedItems);
            long totalDiscardedItems = machineData.Sum(a => (long)a.DiscardedItems);
            double totalStopTime = machineData.Sum(a => a.StopTime);
            double totalActualStopTime = machineData.Sum(a => a.ActualStopTime);
            double totalFlowErrorTime = machineData.Sum(a => a.FlowErrorTime);
            double totalChangeOverTime = machineData.Sum(a => a.ChangeOverTime);
            double totalProductionTime = machineData.Sum(a => a.ProductionTime);

            AggregatedOeeDataItem timePart = new AggregatedOeeDataItem();
            timePart.XType = XTypes.Machine;
            timePart.MachineId = machineId;
            timePart.Machine = M2MDataCenter.GetMachine(machineId).DisplayName;
            timePart.AutoTime = TimeSpan.FromSeconds(totalAutoTime);
            timePart.ScheduledTime = TimeSpan.FromSeconds(totalScheduledTime);
            timePart.NoProductionTime = TimeSpan.FromSeconds(totalNoProductionTime);
            timePart.NotConnectedTime = TimeSpan.FromSeconds(totalNotConnectedTime);
            timePart.FlowErrorTime = TimeSpan.FromSeconds(totalFlowErrorTime);
            timePart.ChangeOverTime = TimeSpan.FromSeconds(totalChangeOverTime);
            timePart.Produced = totalProducedItems;
            timePart.Discarded = totalDiscardedItems;

            if (totalScheduledTime > 0)
                timePart.AvailabilityBasedOnScheduledTime = totalAutoTime / totalScheduledTime;

            if (totalProductionTime > 0)
            {
                timePart.Availability = totalAutoTime / totalProductionTime;
                timePart.AvailabilityBasedOnActualStops = (totalAutoTime + totalFlowErrorTime) / totalProductionTime;
                timePart.AvailabilityBasedOnFlowErrors = (totalAutoTime + totalActualStopTime) / totalProductionTime;
                timePart.AvailabilityLoss = totalStopTime / totalProductionTime;
                timePart.AvailabilityLossBasedOnActualStops = (totalActualStopTime) / totalProductionTime;
                timePart.AvailabilityLossBasedOnFlowErrors = totalFlowErrorTime / totalProductionTime;
            }

            if (totalProducedItems > 0)
                timePart.Quality = 1.0 - (double)totalDiscardedItems / (double)totalProducedItems;

            if (totalAutoTime > 0)
            {
                timePart.Performance = 0;

                foreach (var item in machineData)
                {
                    double? idealRunRate = M2MDataCenter.GetIdealCycleTime(item.DivisionId, item.MachineId, item.ArticleNumber.Trim());

                    if (idealRunRate != null && item.RunRate != 0)
                    {
                        timePart.Performance += ((double)idealRunRate / item.RunRate) * (item.AutoTime / totalAutoTime);
                    }
                }
            }

            return timePart;
        }

        public AggregatedOeeDataItem GetDivisionData(string divisionId, bool aggregateData)
        {
            var divisionData = this.Where(a => a.DivisionId == divisionId);

            double totalAutoTime = aggregateData ? divisionData.Where(a => a.AggregateAvailability).Sum(a => a.AutoTime) : divisionData.Sum(a => a.AutoTime);
            double totalAutoTimeForPerformance = aggregateData ? divisionData.Where(a => a.AggregatePerformance).Sum(a => a.AutoTime) : divisionData.Sum(a => a.AutoTime);
            double totalScheduledTime = aggregateData ? divisionData.Where(a => a.AggregateAvailability).Sum(a => a.TotalTime) : divisionData.Sum(a => a.TotalTime);
            double totalNoProductionTime = aggregateData ? divisionData.Where(a => a.AggregateAvailability).Sum(a => a.NoProductionTime) : divisionData.Sum(a => a.NoProductionTime);
            double totalNotConnectedTime = aggregateData ? divisionData.Where(a => a.AggregateAvailability).Sum(a => a.NotConnectedTime) : divisionData.Sum(a => a.NotConnectedTime);
            long totalProducedItems = aggregateData ? divisionData.Where(a => a.AggregateCounter).Sum(a => (long)a.ProducedItems) : divisionData.Sum(a => (long)a.ProducedItems);
            long totalDiscardedItems = divisionData.Sum(a => (long)a.DiscardedItems);
            double totalStopTime = aggregateData ? divisionData.Where(a => a.AggregateAvailability).Sum(a => a.StopTime) : divisionData.Sum(a => a.StopTime);
            double totalActualStopTime = aggregateData ? divisionData.Where(a => a.AggregateAvailability).Sum(a => a.ActualStopTime) : divisionData.Sum(a => a.ActualStopTime);
            double totalFlowErrorTime = aggregateData ? divisionData.Where(a => a.AggregateAvailability).Sum(a => a.FlowErrorTime) : divisionData.Sum(a => a.FlowErrorTime);
            double totalChangeOverTime = aggregateData ? divisionData.Where(a => a.AggregateAvailability).Sum(a => a.ChangeOverTime) : divisionData.Sum(a => a.ChangeOverTime);
            double totalProductionTime = aggregateData ? divisionData.Where(a => a.AggregateAvailability).Sum(a => a.ProductionTime) : divisionData.Sum(a => a.ProductionTime);

            AggregatedOeeDataItem timePart = new AggregatedOeeDataItem();
            timePart.XType = XTypes.Division;
            timePart.DivisionId = divisionId;
            timePart.Division = M2MDataCenter.GetDivision(divisionId).DisplayName;
            timePart.AutoTime = TimeSpan.FromSeconds(totalAutoTime);
            timePart.ScheduledTime = TimeSpan.FromSeconds(totalScheduledTime);
            timePart.NoProductionTime = TimeSpan.FromSeconds(totalNoProductionTime);
            timePart.NotConnectedTime = TimeSpan.FromSeconds(totalNotConnectedTime);
            timePart.FlowErrorTime = TimeSpan.FromSeconds(totalFlowErrorTime);
            timePart.ChangeOverTime = TimeSpan.FromSeconds(totalChangeOverTime);
            timePart.Produced = totalProducedItems;
            timePart.Discarded = totalDiscardedItems;

            if (totalScheduledTime > 0)
                timePart.AvailabilityBasedOnScheduledTime = totalAutoTime / totalScheduledTime;

            if (totalProductionTime > 0)
            {
                timePart.Availability = totalAutoTime / totalProductionTime;
                timePart.AvailabilityBasedOnActualStops = (totalAutoTime + totalFlowErrorTime) / totalProductionTime;
                timePart.AvailabilityBasedOnFlowErrors = (totalAutoTime + totalActualStopTime) / totalProductionTime;
                timePart.AvailabilityLoss = totalStopTime / totalProductionTime;
                timePart.AvailabilityLossBasedOnActualStops = (totalActualStopTime) / totalProductionTime;
                timePart.AvailabilityLossBasedOnFlowErrors = totalFlowErrorTime / totalProductionTime;
            }

            if (totalProducedItems > 0)
                timePart.Quality = 1.0 - (double)totalDiscardedItems / (double)totalProducedItems;

            if (totalAutoTimeForPerformance > 0)
            {
                timePart.Performance = 0;

                foreach (var item in divisionData)
                {
                    if (aggregateData && !item.AggregatePerformance)
                        continue;

                    double? idealRunRate = M2MDataCenter.GetIdealCycleTime(item.DivisionId, item.MachineId, item.ArticleNumber.Trim());

                    if (idealRunRate != null && item.RunRate != 0)
                    {
                        timePart.Performance += ((double)idealRunRate / item.RunRate) * (item.AutoTime / totalAutoTimeForPerformance);
                    }
                }
            }

            return timePart;
        }

        public List<AggregatedOeeDataItem> GetArticleData(string machineId)
        {
            List<AggregatedOeeDataItem> oeeData = new List<AggregatedOeeDataItem>();

            var grouped = this.Where(a => a.MachineId == machineId).OrderBy(a => a.ArticleNumber.Trim()).GroupBy(a => a.ArticleNumber.Trim());

            foreach (var group in grouped)
            {
                double totalAutoTime = group.Sum(a => a.AutoTime);
                double totalScheduledTime = group.Sum(a => a.TotalTime);
                double totalNoProductionTime = group.Sum(a => a.NoProductionTime);
                double totalNotConnectedTime = group.Sum(a => a.NotConnectedTime);
                long totalProducedItems = group.Sum(a => (long)a.ProducedItems);
                long totalDiscardedItems = group.Sum(a => (long)a.DiscardedItems);
                double totalStopTime = group.Sum(a => a.StopTime);
                double totalActualStopTime = group.Sum(a => a.ActualStopTime);
                double totalFlowErrorTime = group.Sum(a => a.FlowErrorTime);
                double totalChangeOverTime = group.Sum(a => a.ChangeOverTime);
                double totalProductionTime = group.Sum(a => a.ProductionTime);

                AggregatedOeeDataItem timePart = new AggregatedOeeDataItem();
                timePart.XType = XTypes.Article;
                timePart.ArticleNumber = group.Key;
                timePart.AutoTime = TimeSpan.FromSeconds(totalAutoTime);
                timePart.ScheduledTime = TimeSpan.FromSeconds(totalScheduledTime);
                timePart.NoProductionTime = TimeSpan.FromSeconds(totalNoProductionTime);
                timePart.NotConnectedTime = TimeSpan.FromSeconds(totalNotConnectedTime);
                timePart.FlowErrorTime = TimeSpan.FromSeconds(totalFlowErrorTime);
                timePart.ChangeOverTime = TimeSpan.FromSeconds(totalFlowErrorTime);
                timePart.Produced = totalProducedItems;
                timePart.Discarded = totalDiscardedItems;
                timePart.IdealRunRate = 60 * 60 * 1000 / ((double)M2MDataCenter.GetIdealCycleTime(M2MDataCenter.GetMachine(machineId).DivisionId, machineId, group.Key));

                if (totalScheduledTime > 0)
                    timePart.AvailabilityBasedOnScheduledTime = totalAutoTime / totalScheduledTime;

                if (totalProductionTime > 0)
                {
                    timePart.Availability = totalAutoTime / totalProductionTime;
                    timePart.AvailabilityBasedOnActualStops = (totalAutoTime + totalFlowErrorTime) / totalProductionTime;
                    timePart.AvailabilityBasedOnFlowErrors = (totalAutoTime + totalActualStopTime) / totalProductionTime;
                    timePart.AvailabilityLoss = totalStopTime / totalProductionTime;
                    timePart.AvailabilityLossBasedOnActualStops = (totalActualStopTime) / totalProductionTime;
                    timePart.AvailabilityLossBasedOnFlowErrors = totalFlowErrorTime / totalProductionTime;
                }

                if (totalProducedItems > 0)
                    timePart.Quality = 1.0 - (double)totalDiscardedItems / (double)totalProducedItems;

                if (totalAutoTime > 0)
                {
                    timePart.Performance = 0;

                    foreach (var item in group)
                    {
                        double? idealRunRate = M2MDataCenter.GetIdealCycleTime(item.DivisionId, item.MachineId, item.ArticleNumber.Trim());

                        if (idealRunRate != null && item.RunRate != 0)
                        {
                            timePart.Performance += ((double)idealRunRate / item.RunRate) * (item.AutoTime / totalAutoTime);
                        }
                    }
                }

                oeeData.Add(timePart);
            }

            return oeeData;
        }

		#endregion
		#region Authorization Rules

		public static bool CanGetObject()
		{
			return true;
		}

		#endregion

		#region Factory Methods

		public static OeeDataList GetOeeDataList(Criteria criteria)
		{
			return DataPortal.Fetch<OeeDataList>(criteria);
		}

		private OeeDataList()
		{
			/* require use of factory methods */
		}

		#endregion

		#region Data Access

		[Serializable()]
		public class Criteria
		{
            private int m_GroupingId = 0;
			private string m_DivisionId = null;
			private string m_MachineId = null;
			private int m_Shift = -1;
			private string m_ArticleNumber = null;
			private SmartDate m_StartTime = new SmartDate(new DateTime(2000, 1, 1));
			private SmartDate m_EndTime = new SmartDate(DateTime.Today);
			private SqlConnection m_Connection = null;
            private bool m_CalculateSums = true;
	
			public Criteria()
			{
			}

            public int GroupingId
            {
                get { return m_GroupingId; }
                set { m_GroupingId = value; }
            }

			public string DivisionId
			{
				get { return m_DivisionId; }
				set { m_DivisionId = value; }
			}

			public string MachineId
			{
				get { return m_MachineId; }
				set { m_MachineId = value; }
			}

			public int Shift
			{
				get { return m_Shift; }
				set { m_Shift = value; }
			}

			public string ArticleNumber
			{
				get { return m_ArticleNumber; }
				set { m_ArticleNumber = value; }
			}

			public SmartDate StartTime
			{
				get { return m_StartTime; }
				set { m_StartTime = value; }
			}

			public SmartDate EndTime
			{
				get { return m_EndTime; }
				set { m_EndTime = value; }
			}

			public bool CalculateSums
            {
                get { return m_CalculateSums; }
                set { m_CalculateSums = value; }
            }
			
			public SqlConnection SqlConnection
			{
				get { return m_Connection; }
				set { m_Connection = value; }
			}
		}

		private void DataPortal_Fetch(Criteria criteria)
		{
			RaiseListChangedEvents = false;
			IsReadOnly = false;

			if (criteria.SqlConnection != null)
				Fetch(criteria.SqlConnection, criteria);
			else
			{
				using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
				{
					connection.Open();

					Fetch(connection, criteria);
				}
			}

			IsReadOnly = true;
			RaiseListChangedEvents = true;
		}

		private void Fetch(SqlConnection connection, Criteria criteria)
		{
            m_CurrentCriteria = criteria;
			using (SqlCommand command = connection.CreateCommand())
			{
				string whereClause = "";

                if (criteria.GroupingId > 0)
                {
                    if (whereClause != "")
                        whereClause += " AND ";

                    M2MDataCenter.GetDivisionList(criteria.GroupingId);
                    whereClause += "GroupingId=@GroupingId";
                    command.Parameters.AddWithValue(@"@GroupingId", criteria.GroupingId);
                }

				if (!String.IsNullOrEmpty(criteria.DivisionId))
				{
					if (whereClause != "")
						whereClause += " AND ";

					whereClause += "DivisionId=@DivisionId";
					command.Parameters.AddWithValue(@"@DivisionId", criteria.DivisionId);
				}

				if (!String.IsNullOrEmpty(criteria.MachineId))
				{
					if (whereClause != "")
						whereClause += " AND ";

					whereClause += "MachineId=@MachineId";
					command.Parameters.AddWithValue(@"@MachineId", criteria.MachineId);
				}

				if (!String.IsNullOrEmpty(criteria.ArticleNumber))
				{
					if (whereClause != "")
						whereClause += " AND ";

					whereClause += "ArticleNumber=@ArticleNumber";
					command.Parameters.AddWithValue(@"@ArticleNumber", criteria.ArticleNumber);
				}

				if (criteria.Shift >= 0)
				{
					if (whereClause != "")
						whereClause += " AND ";

					whereClause += "Shift=@Shift";
					command.Parameters.AddWithValue(@"@Shift", criteria.Shift);
				}

				if (whereClause != "")
					whereClause += " AND ";

				whereClause += "StartTime < @EndTime AND EndTime > @StartTime";

				command.Parameters.AddWithValue(@"@EndTime", criteria.EndTime.DBValue);
				command.Parameters.AddWithValue(@"@StartTime", criteria.StartTime.DBValue);

				command.CommandType = CommandType.Text;
				command.CommandText = @"SELECT " +
										@"OeeDataId," +
										@"DivisionId," +
										@"MachineId," +
										@"Shift," +
                                        @"GroupingId," +
										@"ArticleNumber," +
										@"StartTime," +
										@"EndTime," +
										@"AutoTime," +
										@"NoProductionTime," +
                                        @"NotConnectedTime," +
                                        @"FlowErrorTime," +
                                        @"ChangeOverTime," +
										@"ProducedItems," +
										@"DiscardedItems" +
                                        @" FROM OeeData WITH (NOLOCK)" +
										@" WHERE " + whereClause;

				using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
				{
					while (dr.Read())
					{
						Add(OeeDataListItem.GetOeeDataListItem(dr));
					}
				}

				if(criteria.CalculateSums)
				    CalculateSums();

			}
		}

		#endregion
	}
}

