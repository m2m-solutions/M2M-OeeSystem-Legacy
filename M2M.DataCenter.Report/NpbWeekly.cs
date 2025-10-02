using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using M2M.DataCenter.Localization;
using M2M.DataCenter.Utilities;
using System.Web;

namespace M2M.DataCenter.Reports
{
    /// <summary>
    /// Summary description for Machine.
    /// </summary>
    [Description("Npb")]
    [DisplayName("03")]
    public partial class NpbWeekly : Telerik.Reporting.Report
    {
        #region Properties

        AggregatedDataContainer m_AggregatedDataContainer = null;
		List<string> m_Divisions = null;
		
        #endregion

        public NpbWeekly()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            SetLocalizedStrings();

            this.pictureBox1.Value = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("~/CustomerSpecifics/CustomerLogo.png"));
            this.pictureBoxLogo.Value = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("~/CustomerSpecifics/ReportLogo.png"));
  
        }

        private void SetLocalizedStrings()
        {
            #region Page header
            textBox32.Value = ResourceStrings.GetString("Report.NpbWeekly.Header");
            tbDivisionPrompt.Value = ResourceStrings.GetString("Npb.Module#:");
            #endregion

            #region Machines
            
            textBox13.Value = ResourceStrings.GetString("Oee");
            textBox17.Value = ResourceStrings.GetString("Availability.Abbr");
            textBox85.Value = ResourceStrings.GetString("AvailabilityLoss.Abbr");
            textBox115.Value = ResourceStrings.GetString("AvailabilityLossBasedOnActualStops.Abbr");
            textBox1.Value = ResourceStrings.GetString("AvailabilityLossBasedOnFlowErrors.Abbr");
            textBox19.Value = ResourceStrings.GetString("Performance.Abbr");
            textBox21.Value = ResourceStrings.GetString("Quality.Abbr");
            textBox6.Value = ResourceStrings.GetString("ProductionTime.Abbr");
            textBox4.Value = ResourceStrings.GetString("Downtime");
            textBox8.Value = ResourceStrings.GetString("ProducedItems.Abbr");
            textBox10.Value = ResourceStrings.GetString("Stops");
            textBox7.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox5.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            #endregion

            #region Downtime unit 1
            textBox34.Value = ResourceStrings.GetString("Category");
            textBox23.Value = ResourceStrings.GetString("TimeConsumed.Total");
            textBox26.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox24.Value = ResourceStrings.GetString("Stops");
            textBox28.Value = ResourceStrings.GetString("TimeConsumed.Average");
            textBox29.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox30.Value = ResourceStrings.GetString("PartOfTotalStops");
            #endregion

            #region Downtime unit 2
            textBox49.Value = ResourceStrings.GetString("Category");
            textBox36.Value = ResourceStrings.GetString("TimeConsumed.Total");
            textBox39.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox37.Value = ResourceStrings.GetString("Stops");
            textBox41.Value = ResourceStrings.GetString("TimeConsumed.Average");
            textBox42.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox43.Value = ResourceStrings.GetString("PartOfTotalStops");
            #endregion

            #region Downtime unit 3
            textBox64.Value = ResourceStrings.GetString("Category");
            textBox55.Value = ResourceStrings.GetString("TimeConsumed.Total");
            textBox58.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox56.Value = ResourceStrings.GetString("Stops");
            textBox60.Value = ResourceStrings.GetString("TimeConsumed.Average");
            textBox61.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox62.Value = ResourceStrings.GetString("PartOfTotalStops");
            #endregion

            #region Downtime unit 4
            textBox96.Value = ResourceStrings.GetString("Category");
            textBox87.Value = ResourceStrings.GetString("TimeConsumed.Total");
            textBox90.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox88.Value = ResourceStrings.GetString("Stops");
            textBox92.Value = ResourceStrings.GetString("TimeConsumed.Average");
            textBox93.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox94.Value = ResourceStrings.GetString("PartOfTotalStops");
            #endregion

            #region Downtime unit 5
            textBox111.Value = ResourceStrings.GetString("Category");
            textBox102.Value = ResourceStrings.GetString("TimeConsumed.Total");
            textBox105.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox103.Value = ResourceStrings.GetString("Stops");
            textBox107.Value = ResourceStrings.GetString("TimeConsumed.Average");
            textBox108.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox109.Value = ResourceStrings.GetString("PartOfTotalStops");
            #endregion

            #region Downtime unit 6
            textBox141.Value = ResourceStrings.GetString("Category");
            textBox132.Value = ResourceStrings.GetString("TimeConsumed.Total");
            textBox135.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox133.Value = ResourceStrings.GetString("Stops");
            textBox137.Value = ResourceStrings.GetString("TimeConsumed.Average");
            textBox138.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox139.Value = ResourceStrings.GetString("PartOfTotalStops");
            #endregion

            #region Downtime unit 7
            textBox156.Value = ResourceStrings.GetString("Category");
            textBox147.Value = ResourceStrings.GetString("TimeConsumed.Total");
            textBox150.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox148.Value = ResourceStrings.GetString("Stops");
            textBox152.Value = ResourceStrings.GetString("TimeConsumed.Average");
            textBox153.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox154.Value = ResourceStrings.GetString("PartOfTotalStops");
            #endregion

            #region Downtime unit 8
            textBox171.Value = ResourceStrings.GetString("Category");
            textBox162.Value = ResourceStrings.GetString("TimeConsumed.Total");
            textBox165.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox163.Value = ResourceStrings.GetString("Stops");
            textBox167.Value = ResourceStrings.GetString("TimeConsumed.Average");
            textBox168.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox169.Value = ResourceStrings.GetString("PartOfTotalStops");
            #endregion

            #region Downtime unit 9
            textBox200.Value = ResourceStrings.GetString("Category");
            textBox191.Value = ResourceStrings.GetString("TimeConsumed.Total");
            textBox194.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox192.Value = ResourceStrings.GetString("Stops");
            textBox196.Value = ResourceStrings.GetString("TimeConsumed.Average");
            textBox197.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox198.Value = ResourceStrings.GetString("PartOfTotalStops");
            #endregion

            #region Downtime unit 10
            textBox243.Value = ResourceStrings.GetString("Category");
            textBox234.Value = ResourceStrings.GetString("TimeConsumed.Total");
            textBox237.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox235.Value = ResourceStrings.GetString("Stops");
            textBox239.Value = ResourceStrings.GetString("TimeConsumed.Average");
            textBox240.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox241.Value = ResourceStrings.GetString("PartOfTotalStops");
            #endregion

            #region Page footer
            textBox45.Value = ResourceStrings.GetString("Page");
            textBox46.Value = ResourceStrings.GetString("#-Of");
            textBox50.Value = ResourceStrings.GetString("Copyright");
            textBox44.Value = ResourceStrings.GetString("GeneratedBy");
            #endregion
        }

        private void Machine_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report report = sender as Telerik.Reporting.Processing.Report;
            int groupingId = Convert.ToInt32(report.Parameters["ModuleId"].Value);

            DateTime startDate = Extensions.FirstDateOfWeek(Convert.ToInt32(report.Parameters["Year"].Value), Convert.ToInt32(report.Parameters["Week"].Value));
            DateTime endDate = startDate.AddDays(7);

            if (startDate > DateTime.Now)
                endDate = startDate;
            else if (endDate > DateTime.Now)
                endDate = DateTime.Now;

            List<int> categories = new List<int>();
            foreach (int category in M2MDataCenter.GetAvailableCategories())
            {
                if (!M2MDataCenter.GetCategoryItem(category).FlowError)
                    categories.Add(category);
            }

            m_AggregatedDataContainer = new AggregatedDataContainer(groupingId, null, null, -1, startDate, endDate, categories);
            m_Divisions = m_AggregatedDataContainer.DivisionIdList;

            panelUnit1.Visible = false;
            panelUnit2.Visible = false;
            panelUnit3.Visible = false;
            panelUnit4.Visible = false;
            panelUnit5.Visible = false;
            panelUnit6.Visible = false;
            panelUnit7.Visible = false;
            panelUnit8.Visible = false;
            panelUnit9.Visible = false;
            panelUnit10.Visible = false;

            if (m_Divisions.Count > 0)
            {
                panelUnit1.Visible = true;
                textBoxUnit1.Value = M2MDataCenter.GetDivision(m_Divisions[0]).DisplayName;
                textBoxUnit1.GrowAndCenterControl();
            }
            if (m_Divisions.Count > 1)
            {
                panelUnit2.Visible = true;
                textBoxUnit2.Value = M2MDataCenter.GetDivision(m_Divisions[1]).DisplayName;
                textBoxUnit2.GrowAndCenterControl();
            }
            if (m_Divisions.Count > 2)
            {
                panelUnit3.Visible = true;
                textBoxUnit3.Value = M2MDataCenter.GetDivision(m_Divisions[2]).DisplayName;
                textBoxUnit3.GrowAndCenterControl();
            }
            if (m_Divisions.Count > 3)
            {
                panelUnit4.Visible = true;
                textBoxUnit4.Value = M2MDataCenter.GetDivision(m_Divisions[3]).DisplayName;
                textBoxUnit4.GrowAndCenterControl();
            }
            if (m_Divisions.Count > 4)
            {
                panelUnit5.Visible = true;
                textBoxUnit5.Value = M2MDataCenter.GetDivision(m_Divisions[4]).DisplayName;
                textBoxUnit5.GrowAndCenterControl();
            }
            if (m_Divisions.Count > 5)
            {
                panelUnit6.Visible = true;
                textBoxUnit6.Value = M2MDataCenter.GetDivision(m_Divisions[5]).DisplayName;
                textBoxUnit6.GrowAndCenterControl();
            }
            if (m_Divisions.Count > 6)
            {
                panelUnit7.Visible = true;
                textBoxUnit7.Value = M2MDataCenter.GetDivision(m_Divisions[6]).DisplayName;
                textBoxUnit7.GrowAndCenterControl();
            }
            if (m_Divisions.Count > 7)
            {
                panelUnit8.Visible = true;
                textBoxUnit8.Value = M2MDataCenter.GetDivision(m_Divisions[7]).DisplayName;
                textBoxUnit8.GrowAndCenterControl();
            }
            if (m_Divisions.Count > 8)
            {
                panelUnit9.Visible = true;
                textBoxUnit9.Value = M2MDataCenter.GetDivision(m_Divisions[8]).DisplayName;
                textBoxUnit9.GrowAndCenterControl();
            }
            if (m_Divisions.Count > 9)
            {
                panelUnit10.Visible = true;
                textBoxUnit10.Value = M2MDataCenter.GetDivision(m_Divisions[9]).DisplayName;
                textBoxUnit10.GrowAndCenterControl();
            }
            report.DataSource = m_AggregatedDataContainer;
            
        }

        

        private void tableMachines_NeedDataSource(object sender, EventArgs e)
        {
            (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.GetDataForAllDivisions();
        }

        public static string GetDocumentName(object grouping, object year, object week)
        {
            return String.Format(ResourceStrings.GetString("Report.NpbWeekly.DocumentName"), M2MDataCenter.GetGrouping(Convert.ToInt32(grouping)).DisplayName, year, week);
        }

        private void table1Stops_NeedDataSource(object sender, EventArgs e)
        {
            if (m_Divisions.Count > 0)
                (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.GetTopStopTimes(m_Divisions[0], 7, true);
        }

        private void table2Stops_NeedDataSource(object sender, EventArgs e)
        {
            if (m_Divisions.Count > 1)
                (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.GetTopStopTimes(m_Divisions[1], 7, true);
        }

        private void table3Stops_NeedDataSource(object sender, EventArgs e)
        {
            if (m_Divisions.Count > 2)
                (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.GetTopStopTimes(m_Divisions[2], 7, true);
        }

        private void table4Stops_NeedDataSource(object sender, EventArgs e)
        {
            if (m_Divisions.Count > 3)
                (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.GetTopStopTimes(m_Divisions[3], 7, true);
        }

        private void table5Stops_NeedDataSource(object sender, EventArgs e)
        {
            if (m_Divisions.Count > 4)
                (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.GetTopStopTimes(m_Divisions[4], 7, true);
        }

        private void table6Stops_NeedDataSource(object sender, EventArgs e)
        {
            if (m_Divisions.Count > 5)
                (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.GetTopStopTimes(m_Divisions[5], 7, true);
        }

        private void table7Stops_NeedDataSource(object sender, EventArgs e)
        {
            if (m_Divisions.Count > 6)
                (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.GetTopStopTimes(m_Divisions[6], 7, true);
        }

        private void table8Stops_NeedDataSource(object sender, EventArgs e)
        {
            if (m_Divisions.Count > 7)
                (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.GetTopStopTimes(m_Divisions[7], 7, true);
        }

        private void table9Stops_NeedDataSource(object sender, EventArgs e)
        {
            if (m_Divisions.Count > 8)
                (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.GetTopStopTimes(m_Divisions[4], 8, true);
        }

        private void table10Stops_NeedDataSource(object sender, EventArgs e)
        {
            if (m_Divisions.Count > 9)
                (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.GetTopStopTimes(m_Divisions[9], 7, true);
        }
    }
}