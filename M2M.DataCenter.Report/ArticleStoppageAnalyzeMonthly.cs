using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using M2M.DataCenter.Localization;
using System.Web;
using Csla;

namespace M2M.DataCenter.Reports
{
    /// <summary>
    /// Summary description for Machine.
    /// </summary>
    [Description("Default")]
    [DisplayName("20")]
    public partial class ArticleStoppageAnalyzeMonthly : Telerik.Reporting.Report
    {
        #region Properties

        List<StoppageSummary> m_List = null;
        
        #endregion

        public ArticleStoppageAnalyzeMonthly()
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
            tbHeader.Value = ResourceStrings.GetString("Report.ArticleStoppageAnalyzeMonthly.Header");
            tbSubHeader.Value = ResourceStrings.GetString("#+Report.ArticleStoppageAnalyzeMonthly.SubHeader");
            tbDivisionPrompt.Value = ResourceStrings.GetString("Division#:");
            textBox8.Value = ResourceStrings.GetString("Machine#:");
            textBox1.Value = ResourceStrings.GetString("Shift#:");
            tbCategory.Value = ResourceStrings.GetString("Categories#:");
            tbStopReason.Value = ResourceStrings.GetString("DowntimeCause#:");
            textBox5.Value = ResourceStrings.GetString("Shows#:");
            #endregion

            #region Page footer
            textBox45.Value = ResourceStrings.GetString("Page");
            textBox46.Value = ResourceStrings.GetString("#-Of");
            textBox50.Value = ResourceStrings.GetString("Copyright");
            textBox44.Value = ResourceStrings.GetString("GeneratedBy");
            #endregion
        }

        public static string GetDocumentName(object machine, object category, object reason, object year, object month)
        {
            string text = reason != null ? reason.ToString() : M2MDataCenter.GetCategoryDisplayName((int)category);
            return String.Format(ResourceStrings.GetString("Report.ArticleStoppageAnalyzeMonthly.DocumentName"), M2MDataCenter.GetMachine(machine.ToString()).DisplayName, text, year, month);
        }

        private void Report_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report report = sender as Telerik.Reporting.Processing.Report;
            
            string divisionId = (string)report.Parameters["DivisionId"].Value;
            string machineId = (string)report.Parameters["MachineId"].Value;
            int shift = Convert.ToInt32(report.Parameters["ShiftType"].Value);
            DateTime endTime = (new DateTime(Convert.ToInt32(report.Parameters["Year"].Value), Convert.ToInt32(report.Parameters["Month"].Value), 1)).AddMonths(1);
            DateTime startTime = new Csla.SmartDate(endTime.AddMonths(-12));
            int category = Convert.ToInt32(report.Parameters["Category"].Value);
            string stopReason = (string)report.Parameters["StopReason"].Value;
            AnalyzeShowType showType = (AnalyzeShowType)Convert.ToInt32(report.Parameters["ShowType"].Value);
            m_List = new List<StoppageSummary>();

            ArticlesInProductionList.Criteria criteria = new ArticlesInProductionList.Criteria();
            
            criteria.DivisionId = divisionId;
            criteria.MachineId = machineId;
            criteria.StartDate = new SmartDate(startTime);
            criteria.EndDate = new SmartDate(endTime);
            criteria.Shift = Convert.ToInt32(shift);

            ArticlesInProductionList articles = ArticlesInProductionList.GetArticlesInProductionList(criteria);

            double maxValue = 0;

            foreach (ArticlesInProductionListItem article in articles)
            {
                StoppageSummary summary = new StoppageSummary(divisionId, machineId, article.ArticleNumber, shift, startTime, endTime, category, stopReason, showType);
                m_List.Add(summary);
                double temp = summary.GetMaxValue(Intervals.Monthly);
                if (temp > maxValue)
                    maxValue = temp;
            }

            foreach (StoppageSummary summary in m_List)
            {
                summary.MaxValue = maxValue;
            }
            
            (sender as Telerik.Reporting.Processing.Report).DataSource = m_List;
        }

        private void textBox4_ItemDataBound(object sender, EventArgs e)
        {
            (sender as Telerik.Reporting.Processing.TextBox).GrowAndCenterControl();
        }

        private void graph1_NeedDataSource(object sender, EventArgs e)
        {
            var graph = (Telerik.Reporting.Processing.DataItem)sender;
            
            var section = (Telerik.Reporting.Processing.DetailSection)graph.ParentElement;

            List<AggregatedStoppageDataListItem> stoppages = ((StoppageSummary)section.DataObject.RawData).GetPeriodicStops(Intervals.Monthly);

            if (stoppages != null)
                graph.DataSource = stoppages;
            else
            {
                section.Visible = false;
            }
        }

        public static string GetArticle(object sender)
        {
            var dataObject = (Telerik.Reporting.Processing.IDataObject)sender;
            var machine = dataObject["Article"] as string;
            
            return machine;
        }

        
    }
    
}