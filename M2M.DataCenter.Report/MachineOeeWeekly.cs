using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Telerik.Reporting.Charting;
using M2M.DataCenter.Utilities;
using M2M.DataCenter.Localization;
using System.Collections.Generic;
using System.Web;

namespace M2M.DataCenter.Reports
{
    /// <summary>
    /// Summary description for Machine.
    /// </summary>
    [Description("Default")]
    [DisplayName("22")]
    public partial class MachineOeeWeekly : Telerik.Reporting.Report
    {
        #region Properties

        MachineOee m_OeeData = null;
       
        #endregion

        public MachineOeeWeekly()
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
            textBox25.Value = ResourceStrings.GetString("#+Report.MachineOeeWeekly.SubHeader");
            textBox26.Value = ResourceStrings.GetString("Report.MachineOeeWeekly.Header");
            textBox28.Value = ResourceStrings.GetString("Division#:");
            textBox24.Value = ResourceStrings.GetString("Machine#:");
            textBox49.Value = ResourceStrings.GetString("Shift#:");
            #endregion

            #region Overview
            textBox29.Value = ResourceStrings.GetString("ScheduledTime#:");
            tbTotalTime.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox30.Value = ResourceStrings.GetString("AvailableProductionTime#:");
            tbProductionTime.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox32.Value = ResourceStrings.GetString("MachineNotInProduction#:");
            tbStopTime.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox39.Value = ResourceStrings.GetString("MachineNotConnected#:");
            textBox40.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox4.Value = ResourceStrings.GetString("EffectiveProductionTime#:");
            textBox5.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox38.Value = ResourceStrings.GetString("Downtime#:");
            textBox35.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox57.Value = ResourceStrings.GetString("ActualDowntime#:");
            textBox56.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox53.Value = ResourceStrings.GetString("FlowErrorDowntime#:");
            textBox54.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox33.Value = ResourceStrings.GetString("Oee#:");
            textBox34.Value = ResourceStrings.GetString("AvailabilityWithAbbr#:");
            textBox36.Value = ResourceStrings.GetString("PerformanceWithAbbr#:");
            textBox37.Value = ResourceStrings.GetString("QualityWithAbbr#:");
            textBox52.Value = ResourceStrings.GetString("AvailabilityLossWithAbbr#:");
            textBox42.Value = ResourceStrings.GetString("BasedOnActualStopsWithAbbr#:");
            textBox55.Value = ResourceStrings.GetString("BasedOnFlowErrorsWithAbbr#:");
            #endregion

            #region Oee charts
            textBox1.Value = ResourceStrings.GetString("OeeOverview");
            textBox1.GrowAndCenterControl();
            textBox3.Value = ResourceStrings.GetString("OeePerDay");
            textBox3.GrowAndCenterControl();
            chartPeriodicOee.Series[0].Name = ResourceStrings.GetString("Oee.Abbr");
            chartPeriodicOee.Series[1].Name = ResourceStrings.GetString("AvailabilityLoss");
            chartPeriodicOee.Series[2].Name = ResourceStrings.GetString("PerformanceLoss");
            chartPeriodicOee.Series[3].Name = ResourceStrings.GetString("QualityLoss");
            #endregion

            #region Articles
            textBox2.Value = ResourceStrings.GetString("Articles");
            textBox2.GrowAndCenterControl();
            textBox13.Value = ResourceStrings.GetString("Oee");
            textBox17.Value = ResourceStrings.GetString("Availability.Abbr");
            textBox62.Value = ResourceStrings.GetString("AvailabilityLoss.Abbr");
            textBox60.Value = ResourceStrings.GetString("AvailabilityLossBasedOnActualStops.Abbr");
            textBox58.Value = ResourceStrings.GetString("AvailabilityLossBasedOnFlowErrors.Abbr");
            textBox19.Value = ResourceStrings.GetString("Performance.Abbr");
            textBox21.Value = ResourceStrings.GetString("Quality.Abbr");
            textBox6.Value = ResourceStrings.GetString("PaceWithUnit");
            textBox8.Value = ResourceStrings.GetString("IdealPaceWithUnit");
            textBox10.Value = ResourceStrings.GetString("ProducedItems");
            #endregion

            #region Page footer
            textBox45.Value = ResourceStrings.GetString("Page");
            textBox46.Value = ResourceStrings.GetString("#-Of");
            textBox50.Value = ResourceStrings.GetString("Copyright");
            textBox44.Value = ResourceStrings.GetString("GeneratedBy");
            #endregion
        }

        public static string GetDocumentName(object machine, object year, object week)
        {
            return String.Format(ResourceStrings.GetString("Report.MachineOeeWeekly.DocumentName"), M2MDataCenter.GetMachine(machine.ToString()).DisplayName, year, week);
        }

        private void Machine_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report report = sender as Telerik.Reporting.Processing.Report;
            string divisionId = (string)report.Parameters["DivisionId"].Value;
            string machineId = (string)report.Parameters["MachineId"].Value;
            int shift = Convert.ToInt32(report.Parameters["ShiftType"].Value);
            DateTime startDate = Extensions.FirstDateOfWeek(Convert.ToInt32(report.Parameters["Year"].Value), Convert.ToInt32(report.Parameters["Week"].Value));
            DateTime endDate = startDate.AddDays(7);

            if (startDate > DateTime.Now)
                endDate = startDate;
            else if (endDate > DateTime.Now)
                endDate = DateTime.Now;

            m_OeeData = new MachineOee(0, divisionId, machineId, shift, startDate, endDate, null);
            
            report.DataSource = m_OeeData;
            
        }

        private void chartTotalOee_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Chart chart = sender as Telerik.Reporting.Processing.Chart; 
            List<AggregatedOeeDataItem> oeeData = m_OeeData.GetTotalData();
            
            Telerik.Reporting.Chart chartDef = (Telerik.Reporting.Chart)chart.ItemDefinition;
            ChartSeriesCollection sc = chartDef.Series;
            sc.Clear();


            sc.Add(ReportUtilities.CreateOeeChartSeries(ResourceStrings.GetString("Oee.Abbr"), true, OeePart.Oee, oeeData.Sum(a => a.Oee) > 0.07));
            sc.Add(ReportUtilities.CreateOeeChartSeries(ResourceStrings.GetString("AvailabilityLoss"), true, OeePart.Availability, oeeData.Sum(a => a.AvailabilityLoss) > 0.07));
            sc.Add(ReportUtilities.CreateOeeChartSeries(ResourceStrings.GetString("PerformanceLoss"), true, OeePart.Performance, oeeData.Sum(a => a.RunRateLoss) > 0.07));
            sc.Add(ReportUtilities.CreateOeeChartSeries(ResourceStrings.GetString("QualityLoss"), true, OeePart.Quality, oeeData.Sum(a => a.QualityLoss) > 0.07));
                
            chart.DataSource = oeeData;
        }
        
        private void chartPeriodicOee_NeedDataSource(object sender, EventArgs e)
        {
            (sender as Telerik.Reporting.Processing.Chart).DataSource = m_OeeData.GetPeriodicData(Intervals.Daily);
        }

        private void tableArticles_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Table table = sender as Telerik.Reporting.Processing.Table;
            table.DataSource = m_OeeData.GetArticleData((string)table.Report.Parameters["MachineId"].Value);
        }

        private void table1_NeedDataSource(object sender, EventArgs e)
        {
            
        }

        private void list1_NeedDataSource(object sender, EventArgs e)
        {
            List<AggregatedOeeDataItem> oeeData = m_OeeData.GetTotalData();
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

        
    }
}