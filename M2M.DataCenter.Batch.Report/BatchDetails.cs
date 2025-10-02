using System;
using System.ComponentModel;
using System.Collections;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.Batch.Report
{
    /// <summary>
    /// Summary description for BatchDetails.
    /// </summary>

    [Description("Innehåller händelselista för ett specifikt chassinummer")]
    [DisplayName("Uppföljning av chassinummer")]
    public partial class BatchDetails : Telerik.Reporting.Report
    {
        private BatchData m_BatchData = null;
        public BatchDetails()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            SetLocalizedStrings();

            ArrayList prevCounts = new ArrayList();
            for (int i = 0; i <= 50; i++)
            {
                prevCounts.Add(i);
            }

            this.ReportParameters["PrevCount"].AvailableValues.DataSource = prevCounts;
            this.ReportParameters["PrevCount"].AvailableValues.ValueMember = "Item";
            //this.ReportParameters["PrevCount"].Value = 10;
        }

        private void SetLocalizedStrings()
        {
            #region Report parameters
            this.ReportParameters["BatchNumber"].Text = ResourceStrings.GetString("BatchNumber");
            this.ReportParameters["PrevCount"].Text = ResourceStrings.GetString("NumberOfPreviousEvents");
            #endregion

            #region Page header
            textBox25.Value = ResourceStrings.GetString("Report.BatchDetails.HeaderLeft");
            textBox28.Value = ResourceStrings.GetString("Division#:");
            textBox24.Value = ResourceStrings.GetString("Machine#:");
            textBox14.Value = ResourceStrings.GetString("Date#:");
            #endregion

            #region Page footer
            textBox45.Value = ResourceStrings.GetString("Report.Footer.Page");
            textBox46.Value = ResourceStrings.GetString("Report.Footer.LabelOf");
            textBox50.Value = ResourceStrings.GetString("Report.Footer.Center");
            textBox44.Value = ResourceStrings.GetString("Report.Footer.Right");
            #endregion
        }

        private void BatchDetails_NeedDataSource(object sender, EventArgs e)
        {
            string batchNumber = (string)ReportParameters["BatchNumber"].Value;
            int prevCount = Convert.ToInt32(ReportParameters["PrevCount"].Value);

            m_BatchData = new BatchData(batchNumber, prevCount);

            (sender as Telerik.Reporting.Processing.Report).DataSource = m_BatchData;
        }

        private void tableArticles_NeedDataSource(object sender, EventArgs e)
        {
            (sender as Telerik.Reporting.Processing.Table).DataSource = m_BatchData.Events;
        }

    }
}