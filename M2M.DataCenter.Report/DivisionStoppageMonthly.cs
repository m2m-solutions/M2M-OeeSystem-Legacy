using System;
using System.ComponentModel;
using System.Collections.Generic;
using M2M.DataCenter.Localization;
using System.Web;

namespace M2M.DataCenter.Reports
{
    /// <summary>
    /// Summary description for Machine.
    /// </summary>
    [Description("Default")]
    [DisplayName("15")]
    public partial class DivisionStoppageMonthly : Telerik.Reporting.Report
    {
        #region Properties

        AggregatedDataContainer m_AggregatedDataContainer = null;
        bool m_MasterStoppageGraphLoaded = false;
        StoppageOrderBy m_OrderBy = StoppageOrderBy.Downtime;
    
        #endregion

        public DivisionStoppageMonthly()
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
            textBox25.Value = ResourceStrings.GetString("#+Report.DivisionStoppageMonthly.SubHeader");
            textBox26.Value = ResourceStrings.GetString("Report.DivisionStoppageMonthly.Header");
            textBox24.Value = ResourceStrings.GetString("Division#:");
            textBox49.Value = ResourceStrings.GetString("Shift#:");
            textBox55.Value = ResourceStrings.GetString("Categories#:");
            #endregion

            #region Overview
            textBox29.Value = ResourceStrings.GetString("ScheduledTime#:");
            tbTotalTime.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox30.Value = ResourceStrings.GetString("AvailableProductionTime#:");
            tbProductionTime.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox23.Value = ResourceStrings.GetString("MachineNotInProduction#:");
            textBox17.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox10.Value = ResourceStrings.GetString("MachineNotConnected#:");
            textBox11.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox4.Value = ResourceStrings.GetString("EffectiveProductionTime#:");
            textBox5.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox3.Value = ResourceStrings.GetString("Downtime#:");
            textBox31.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox33.Value = ResourceStrings.GetString("TotalStopCount#:");
            textBox32.Value = ResourceStrings.GetString("IdentifiedStopTime#:");
            tbStopTime.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox2.Value = ResourceStrings.GetString("OtherStopTime#:");
            textBox1.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox57.Value = ResourceStrings.GetString("ActualDowntime#:");
            textBox38.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox53.Value = ResourceStrings.GetString("FlowErrorDowntime#:");
            textBox54.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            #endregion

            #region Downtime charts
            textBox12.Value = ResourceStrings.GetString("StopDistribution");
            textBox12.GrowAndCenterControl();
            textBox13.Value = ResourceStrings.GetString("StopTimeDistribution");
            textBox13.GrowAndCenterControl();
            #endregion

            #region Downtime
            textBox34.Value = ResourceStrings.GetString("Machine");
            textBox19.Value = ResourceStrings.GetString("TimeConsumed.Total");
            textBox22.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox20.Value = ResourceStrings.GetString("NumberOfStops");
            textBox6.Value = ResourceStrings.GetString("TimeConsumed.Average");
            textBox7.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox8.Value = ResourceStrings.GetString("PartOfTotalStops");
            textBox36.Value = ResourceStrings.GetString("Category");
            #endregion

            #region Page footer
            textBox45.Value = ResourceStrings.GetString("Page");
            textBox46.Value = ResourceStrings.GetString("#-Of");
            textBox50.Value = ResourceStrings.GetString("Copyright");
            textBox44.Value = ResourceStrings.GetString("GeneratedBy");
            #endregion
        }

        public static string GetDocumentName(object division, object year, object month)
        {
            return String.Format(ResourceStrings.GetString("Report.DivisionStoppageMonthly.DocumentName"), M2MDataCenter.GetDivision(division.ToString()).DisplayName, year, month);
        }

        private void Machine_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report report = sender as Telerik.Reporting.Processing.Report;
            string divisionId = (string)report.Parameters["DivisionId"].Value;
            int shift = Convert.ToInt32(report.Parameters["ShiftType"].Value);
            DateTime startDate = new DateTime(Convert.ToInt32(report.Parameters["Year"].Value), Convert.ToInt32(report.Parameters["Month"].Value), 1);
            DateTime endDate = startDate.AddMonths(1);
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
        
            report.DataSource = m_AggregatedDataContainer;
        }

        private void list1_NeedDataSource(object sender, EventArgs e)
        {
            (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.GetTotalData();
        }

        private void chartStopCount_NeedDataSource(object sender, EventArgs e)
        {
            try
            {
                List<AggregatedStoppageDataListItem> stoppageData = m_AggregatedDataContainer.GetTopStopCounts(5, true);

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
                List<AggregatedStoppageDataListItem> stoppageData = m_AggregatedDataContainer.GetTopStopTimes(5, true);

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
            (sender as Telerik.Reporting.Processing.Table).DataSource = m_OrderBy == StoppageOrderBy.Downtime ? m_AggregatedDataContainer.GetTopStopTimes(-1, true) : m_AggregatedDataContainer.GetTopStopCounts(-1, true);
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