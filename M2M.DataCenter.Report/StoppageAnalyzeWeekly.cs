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
    [Description("Default")]
    [DisplayName("17")]
    public partial class StoppageAnalyzeWeekly : Telerik.Reporting.Report
    {
        #region Properties

        List<StoppageSummary> m_List = null;

        #endregion

        public StoppageAnalyzeWeekly()
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
            tbHeader.Value = ResourceStrings.GetString("Report.StoppageAnalyzeWeekly.Header");
            tbSubHeader.Value = ResourceStrings.GetString("#+Report.StoppageAnalyzeWeekly.SubHeader");
            tbDivisionPrompt.Value = ResourceStrings.GetString("Division#:");
            textBox1.Value = ResourceStrings.GetString("Shift#:");
            tbCategory.Value = ResourceStrings.GetString("Categories#:");
            tbStopReason.Value = ResourceStrings.GetString("DowntimeCause#:");
            tbComment.Value = ResourceStrings.GetString("Report.StoppageAnalyze.Comment");
            textBox5.Value = ResourceStrings.GetString("Shows#:");
            #endregion

            #region Page footer
            textBox45.Value = ResourceStrings.GetString("Page");
            textBox46.Value = ResourceStrings.GetString("#-Of");
            textBox50.Value = ResourceStrings.GetString("Copyright");
            textBox44.Value = ResourceStrings.GetString("GeneratedBy");
            #endregion
        }

        public static string GetDocumentName(object division, object category, object reason, object year, object week)
        {
            string text = reason != null ? reason.ToString() : M2MDataCenter.GetCategoryDisplayName((int)category);

            return String.Format(ResourceStrings.GetString("Report.StoppageAnalyzeWeekly.DocumentName"), M2MDataCenter.GetDivision(division.ToString()).DisplayName, text, year, week);
        }

        private void Report_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report report = sender as Telerik.Reporting.Processing.Report;
            
            string divisionId = (string)report.Parameters["DivisionId"].Value;
            int shift = Convert.ToInt32(report.Parameters["ShiftType"].Value);
            DateTime endTime = Extensions.FirstDateOfWeek(Convert.ToInt32(report.Parameters["Year"].Value), Convert.ToInt32(report.Parameters["Week"].Value)).AddDays(7);
            DateTime startTime = new Csla.SmartDate(endTime.AddDays(-12*7));
            int category = Convert.ToInt32(report.Parameters["Category"].Value);
            string stopReason = (string)report.Parameters["StopReason"].Value;
            AnalyzeShowType showType = (AnalyzeShowType)Convert.ToInt32(report.Parameters["ShowType"].Value);
            m_List = new List<StoppageSummary>();
            
            PlainMachineList machines = M2MDataCenter.GetMachineList(divisionId);

            double maxValue = 0;

            foreach (PlainMachineListItem machine in machines)
            {
                StoppageSummary summary = new StoppageSummary(divisionId, machine.MachineId, null, shift, startTime, endTime, category, stopReason, showType);
                m_List.Add(summary);
                double temp = summary.GetMaxValue(Intervals.Weekly);
                if (temp > maxValue)
                    maxValue = temp;
            }

            foreach (StoppageSummary summary in m_List)
            {
                summary.MaxValue = maxValue;
            }
            
            report.DataSource = m_List;
        }

        private void textBox4_ItemDataBound(object sender, EventArgs e)
        {
            (sender as Telerik.Reporting.Processing.TextBox).GrowAndCenterControl();
        }

        private void graph1_NeedDataSource(object sender, EventArgs e)
        {
            var graph = (Telerik.Reporting.Processing.DataItem)sender;
            
            var section = (Telerik.Reporting.Processing.DetailSection)graph.ParentElement;

            List<AggregatedStoppageDataListItem> stoppages = ((StoppageSummary)section.DataObject.RawData).GetPeriodicStops(Intervals.Weekly);

            if (stoppages != null)
                graph.DataSource = stoppages;
            else
            {
                section.Visible = false;
            }
        }

        public static string GetMachineName(object sender)
        {
            var dataObject = (Telerik.Reporting.Processing.IDataObject)sender;
            var machine = dataObject["Machine"] as string;
            
            return machine;
        }
    }
    
}