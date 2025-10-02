using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using M2M.DataCenter.Localization;
using System.Web;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter.Reports
{
    /// <summary>
    /// Summary description for Machine.
    /// </summary>
    [Description("ChangeOver")]
    [DisplayName("29")]
    public partial class ChangeOverWeekly : Telerik.Reporting.Report
    {
        #region Properties

        List<ChangeOverData> m_ArticleData = null;
        
        #endregion

        public ChangeOverWeekly()
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
            tbHeader.Value = ResourceStrings.GetString("Report.ChangeOverWeekly.Header");
            tbSubHeader.Value = ResourceStrings.GetString("#+Report.ChangeOverWeekly.SubHeader");
            tbDivisionPrompt.Value = ResourceStrings.GetString("Division#:");
            tbMachinePrompt.Value = ResourceStrings.GetString("Machine#:");
            tbArticle.Value = ResourceStrings.GetString("Article#:");
            #endregion

            #region Details
            textBox1.Value = ResourceStrings.GetString("PreviousArticle");
            textBox16.Value = ResourceStrings.GetString("From");
            textBox29.Value = ResourceStrings.GetString("To");
            textBox13.Value = ResourceStrings.GetString("TimeConsumed");
            textBox21.Value = ResourceStrings.GetString("TimeConsumed.Average");
            textBox19.Value = ResourceStrings.GetString("Total#:");
            textBox7.Value = ResourceStrings.GetString("Subtotal#:");
            textBox11.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox10.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox8.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox15.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox12.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
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
            return String.Format(ResourceStrings.GetString("Report.ChangeOverWeekly.DocumentName"), M2MDataCenter.GetMachine(machine.ToString()).DisplayName, year, week);
        }

        private void Report_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report report = sender as Telerik.Reporting.Processing.Report;
            
            string divisionId = (string)report.Parameters["DivisionId"].Value;
            string machineId = (string)report.Parameters["MachineId"].Value;
            string article = (string)report.Parameters["Article"].Value;
            DateTime startDate = Extensions.FirstDateOfWeek(Convert.ToInt32(report.Parameters["Year"].Value), Convert.ToInt32(report.Parameters["Week"].Value));
            DateTime endDate = startDate.AddDays(7);

            if (startDate > DateTime.Now)
                endDate = startDate;
            else if (endDate > DateTime.Now)
                endDate = DateTime.Now;

            ChangeOverContainer changeOvers = new ChangeOverContainer(0, divisionId, machineId, article, startDate, endDate);

            m_ArticleData = changeOvers.GetChangeOversPerArticle();
            
            (sender as Telerik.Reporting.Processing.Report).DataSource = m_ArticleData;
        }

        private void textBox4_ItemDataBound(object sender, EventArgs e)
        {
            (sender as Telerik.Reporting.Processing.TextBox).GrowAndCenterControl();
        }

        public static string GetArticle(object sender)
        {
            var dataObject = (Telerik.Reporting.Processing.IDataObject)sender;
            var article = dataObject["Article"] as string;

            return article;
        }

        

        private void crosstab1_NeedDataSource(object sender, EventArgs e)
        {
            var crossTab = (Telerik.Reporting.Processing.DataItem)sender;

            var section = (Telerik.Reporting.Processing.DetailSection)crossTab.ParentElement;

            List<ChangeOverItem> changeOvers = ((ChangeOverData)section.DataObject.RawData).Items;

            if (changeOvers != null)
                crossTab.DataSource = changeOvers;
            else
            {
                section.Visible = false;
            }
            (sender as Telerik.Reporting.Processing.Table).DataSource = changeOvers;
        }

        
    }
    
}