using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Telerik.Reporting.Charting;
using System.Collections.Generic;
using M2M.DataCenter.Localization;
using System.Web;

namespace M2M.DataCenter.Reports
{
    /// <summary>
    /// Summary description for Machine.
    /// </summary>
    [Description("Default")]
    [DisplayName("11")]
    public partial class DivisionOeeDaily : Telerik.Reporting.Report
    {
        #region Properties

        AggregatedDataContainer m_AggregatedDataContainer = null;
		bool m_MasterStoppageGraphLoaded = false;
        StoppageOrderBy m_OrderBy = StoppageOrderBy.Downtime;
       
        #endregion

        public DivisionOeeDaily()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            SetLocalizedStrings();
            
            this.pictureBoxLogo.Value = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("~/CustomerSpecifics/ReportLogo.png"));
        }

        private void SetLocalizedStrings()
        {
            #region Page header
            tbHeaderLeft.Value = ResourceStrings.GetString("#+Report.DivisionOeeDaily.SubHeader");
            tbHeader.Value = ResourceStrings.GetString("Report.DivisionOeeDaily.Header");
            tbDivisionPrompt.Value = ResourceStrings.GetString("Division#:");
            tbShiftPrompt.Value = ResourceStrings.GetString("Shift#:");
            tbCategoriesPrompt.Value = ResourceStrings.GetString("Categories#:");
            #endregion

            #region Overview
            textBox29.Value = ResourceStrings.GetString("ScheduledTime#:");
            tbTotalTime.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox30.Value = ResourceStrings.GetString("AvailableProductionTime#:");
            tbProductionTime.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox32.Value = ResourceStrings.GetString("MachineNotInProduction#:");
            tbStopTime.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox1.Value = ResourceStrings.GetString("MachineNotConnected#:");
            textBox3.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox51.Value = ResourceStrings.GetString("EffectiveProductionTime#:");
            textBox52.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox54.Value = ResourceStrings.GetString("Downtime#:");
            textBox53.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox4.Value = ResourceStrings.GetString("ActualDowntime#:");
            textBox5.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox7.Value = ResourceStrings.GetString("FlowErrorDowntime#:");
            textBox6.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox33.Value = ResourceStrings.GetString("Oee#:");
            textBox34.Value = ResourceStrings.GetString("AvailabilityWithAbbr#:");
            textBox36.Value = ResourceStrings.GetString("PerformanceWithAbbr#:");
            textBox37.Value = ResourceStrings.GetString("QualityWithAbbr#:");
            textBox8.Value = ResourceStrings.GetString("AvailabilityLossWithAbbr#:");
            textBox11.Value = ResourceStrings.GetString("BasedOnActualStopsWithAbbr#:");
            textBox55.Value = ResourceStrings.GetString("BasedOnFlowErrorsWithAbbr#:");
            #endregion

            #region Oee charts
            textBox25.Value = ResourceStrings.GetString("OeeOverview");
            textBox25.GrowAndCenterControl();
            #endregion

            #region Machines
            textBox24.Value = ResourceStrings.GetString("Machines");
            textBox24.GrowAndCenterControl();
            textBox13.Value = ResourceStrings.GetString("Oee");
            textBox67.Value = ResourceStrings.GetString("Availability.Abbr");
            textBox19.Value = ResourceStrings.GetString("Performance.Abbr");
            textBox21.Value = ResourceStrings.GetString("Quality.Abbr");
            textBox63.Value = ResourceStrings.GetString("AvailabilityLoss.Abbr");
            textBox61.Value = ResourceStrings.GetString("AvailabilityLossBasedOnActualStops.Abbr");
            textBox59.Value = ResourceStrings.GetString("AvailabilityLossBasedOnFlowErrors.Abbr");
            
            #endregion

            #region Downtime charts
            textBox23.Value = ResourceStrings.GetString("StopDistribution");
            textBox23.GrowAndCenterControl();
            textBox14.Value = ResourceStrings.GetString("StopTimeDistribution");
            textBox14.GrowAndCenterControl();
            #endregion

            #region Downtime
            textBox57.Value = ResourceStrings.GetString("Machine");
            textBox28.Value = ResourceStrings.GetString("TimeConsumed.Total");
            textBox38.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox31.Value = ResourceStrings.GetString("NumberOfStops");
            textBox40.Value = ResourceStrings.GetString("TimeConsumed.Average");
            textBox41.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox42.Value = ResourceStrings.GetString("PartOfTotalStops");
            textBox65.Value = ResourceStrings.GetString("Category");
            #endregion

            #region Page footer
            textBox45.Value = ResourceStrings.GetString("Page");
            textBox46.Value = ResourceStrings.GetString("#-Of");
            textBox50.Value = ResourceStrings.GetString("Copyright");
            textBox44.Value = ResourceStrings.GetString("GeneratedBy");
            #endregion
        }

        public static string GetDocumentName(object division, object endDate)
        {
            return String.Format(ResourceStrings.GetString("Report.DivisionOeeDaily.DocumentName"), M2MDataCenter.GetDivision(division.ToString()).DisplayName, endDate);
        }

        private void Machine_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report report = sender as Telerik.Reporting.Processing.Report;
            string divisionId = (string)report.Parameters["DivisionId"].Value;
            int shift = Convert.ToInt32(report.Parameters["ShiftType"].Value);
            DateTime startDate = (DateTime)report.Parameters["Date"].Value;
            DateTime endDate = startDate.AddDays(1);
            m_OrderBy = (StoppageOrderBy)Convert.ToInt32(report.Parameters["OrderBy"].Value);
            object[] temp = (object[])report.Parameters["Category"].Value;
            
            List<int> categories = new List<int>();
            for (int i = 0; i < temp.Length; i++)
            {
                categories.Add(Convert.ToInt32(temp[i]));
            }

            if (startDate > DateTime.Now)
                endDate = startDate;
            else if (endDate > DateTime.Now)
                endDate = DateTime.Now;

            m_AggregatedDataContainer = new AggregatedDataContainer(0, divisionId, null, shift, startDate, endDate, categories);

            report.DataSource = m_AggregatedDataContainer.OeeData;
            
        }

        private void chartTotalOee_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Chart chart = sender as Telerik.Reporting.Processing.Chart;
            List<AggregatedOeeDataItem> oeeData = m_AggregatedDataContainer.OeeData.GetTotalData();
            
                Telerik.Reporting.Chart chartDef = (Telerik.Reporting.Chart)chart.ItemDefinition;
                ChartSeriesCollection sc = chartDef.Series;
                sc.Clear();

                sc.Add(ReportUtilities.CreateOeeChartSeries(ResourceStrings.GetString("Oee.Abbr"), true, OeePart.Oee, oeeData.Sum(a => a.Oee) > 0.07));
                sc.Add(ReportUtilities.CreateOeeChartSeries(ResourceStrings.GetString("AvailabilityLoss"), true, OeePart.Availability, oeeData.Sum(a => a.AvailabilityLoss) > 0.07));
                sc.Add(ReportUtilities.CreateOeeChartSeries(ResourceStrings.GetString("PerformanceLoss"), true, OeePart.Performance, oeeData.Sum(a => a.RunRateLoss) > 0.07));
                sc.Add(ReportUtilities.CreateOeeChartSeries(ResourceStrings.GetString("QualityLoss"), true, OeePart.Quality, oeeData.Sum(a => a.QualityLoss) > 0.07));

                chart.DataSource = oeeData;
        }

        private void tableMachines_NeedDataSource(object sender, EventArgs e)
        {
            (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.OeeData.GetDataForAllMachines();
        }


        private void list1_NeedDataSource(object sender, EventArgs e)
        {
            List<AggregatedOeeDataItem> oeeData = m_AggregatedDataContainer.OeeData.GetTotalData();
            if (oeeData.Count > 0 && oeeData[0].RunRateLoss < 0)
            {
                tbPerformance.Style.Color = Color.Red;
            }
            else
            {
                tbPerformance.Style.Color = Color.Black;
            }

            (sender as Telerik.Reporting.Processing.Table).DataSource = oeeData;
        }

        private void chartStopCount_NeedDataSource(object sender, EventArgs e)
        {
			try
			{
                List<AggregatedStoppageDataListItem> stoppageData = m_AggregatedDataContainer.StoppageData.GetMachineTopStopCounts(5, true);

                if (!m_MasterStoppageGraphLoaded)
                {
                    ReportUtilities.LoadMasterStoppageGraph(sender, stoppageData, true);
                    m_MasterStoppageGraphLoaded = true;
                }
                else
                {
                    ReportUtilities.LoadSlaveStoppageGraph(sender, stoppageData, true);
                    m_MasterStoppageGraphLoaded = false;
                }
			}
			catch (System.Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
        }

        private void chartStopTime_NeedDataSource(object sender, EventArgs e)
        {
			try
			{
                List<AggregatedStoppageDataListItem> stoppageData = m_AggregatedDataContainer.StoppageData.GetMachineTopStopTimes(5, true);

                if (!m_MasterStoppageGraphLoaded)
                {
                    ReportUtilities.LoadMasterStoppageGraph(sender, stoppageData, true);
                    m_MasterStoppageGraphLoaded = true;
                }
                else
                {
                    ReportUtilities.LoadSlaveStoppageGraph(sender, stoppageData, true);
                    m_MasterStoppageGraphLoaded = false;
                }
			}
			catch (System.Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
        }

        private void tableStops_NeedDataSource(object sender, EventArgs e)
        {
            try
            {
                (sender as Telerik.Reporting.Processing.Table).DataSource = m_OrderBy == StoppageOrderBy.Downtime ? m_AggregatedDataContainer.StoppageData.GetMachineTopStopTimes(-1, true) : m_AggregatedDataContainer.StoppageData.GetMachineTopStopCounts(-1, true);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void ColumnNumberOfDatabound(object sender, EventArgs e)
        {
            (sender as Telerik.Reporting.Processing.TextBox).Style.Font.Bold = m_OrderBy == StoppageOrderBy.NumberOfStops;
        }

        private void ColumnDowntimeDatabound(object sender, EventArgs e)
        {
            (sender as Telerik.Reporting.Processing.TextBox).Style.Font.Bold = m_OrderBy == StoppageOrderBy.Downtime;
        }

        
    }
}