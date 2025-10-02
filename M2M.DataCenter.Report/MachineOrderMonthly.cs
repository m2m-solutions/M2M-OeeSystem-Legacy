using System;
using System.ComponentModel;
using System.Collections;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.Reports
{
    /// <summary>
    /// Summary description for Machine.
    /// </summary>
    [Description("Innehåller körordrar för en enskild maskin")]
    [DisplayName("Månadsrapport - Körordrar")]
    public partial class MachineOrderMonthly : Telerik.Reporting.Report
    {
        #region Properties

        MachineOrder m_OrderData = null;
       
        #endregion

        public MachineOrderMonthly()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();
            SetLocalizedStrings();

            this.ReportParameters["DivisionId"].AvailableValues.DataSource = M2MDataCenter.GetDivisionList();
            this.ReportParameters["DivisionId"].AvailableValues.ValueMember = "DivisionId";
            this.ReportParameters["DivisionId"].AvailableValues.DisplayMember = "DisplayName";

            this.ReportParameters["MachineId"].AvailableValues.DataSource = M2MDataCenter.GetMachineList();
            this.ReportParameters["MachineId"].AvailableValues.ValueMember = "MachineId";
            this.ReportParameters["MachineId"].AvailableValues.DisplayMember = "DisplayName";
            this.ReportParameters["MachineId"].AvailableValues.Filters.AddRange(new Telerik.Reporting.Data.Filter[] {
            new Telerik.Reporting.Data.Filter("=Fields.DivisionId", Telerik.Reporting.Data.FilterOperator.Equal, "=Parameters.DivisionId")});

            ArrayList years = new ArrayList();
            for(int i=DateTime.Today.Year; i >= 2005; i--)
            {
                years.Add(i);
            }
            this.ReportParameters["Year"].AvailableValues.DataSource = years;
            this.ReportParameters["Year"].AvailableValues.ValueMember = "Item";
            
            SortedList months = new SortedList();
            for (int i = 12; i >= 1; i--)
            {
                months.Add(i, String.Format("{0:dMM}", new DateTime(2009, i, 1).ToString("MMMM")));
            }
            
            this.ReportParameters["Month"].AvailableValues.DataSource = months;
            this.ReportParameters["Month"].AvailableValues.ValueMember = "Key";
            this.ReportParameters["Month"].AvailableValues.DisplayMember = "Value";

            this.ReportParameters["Year"].Value = DateTime.Today.Month == 1 ? DateTime.Today.AddYears(-1).Year : DateTime.Today.Year;
            this.ReportParameters["Month"].Value = DateTime.Today.AddMonths(-1).Month;
   
            
        }

        private void SetLocalizedStrings()
        {
            #region Report parameters
            this.ReportParameters["DivisionId"].Text = ResourceStrings.GetString("Division");
            this.ReportParameters["MachineId"].Text = ResourceStrings.GetString("Machine");
            this.ReportParameters["Year"].Text = ResourceStrings.GetString("Year");
            this.ReportParameters["Month"].Text = ResourceStrings.GetString("Month");
            #endregion

            #region Page header
            textBox25.Value = ResourceStrings.GetString("Report.MachineOrderMonthly.HeaderLeft");
            textBox26.Value = ResourceStrings.GetString("Report.MachineOrderMonthly.Header");
            textBox28.Value = ResourceStrings.GetString("Division#:");
            textBox24.Value = ResourceStrings.GetString("Machine#:");
            textBox14.Value = ResourceStrings.GetString("Period#:");
            #endregion

            #region Article grid
            textBox2.Value = ResourceStrings.GetString("Articles");
            textBox13.Value = ResourceStrings.GetString("OrderStart");
            textBox8.Value = ResourceStrings.GetString("SetupTime");
            textBox4.Value = ResourceStrings.GetString("ProductionTime.Abbr");
            textBox17.Value = ResourceStrings.GetString("ProducedItems.Abbr");
            textBox19.Value = ResourceStrings.GetString("Pace");
            textBox1.Value = ResourceStrings.GetString("TimePerUnit");
            textBox3.Format = String.Format("{0} {1}", "{0:N0}", ResourceStrings.GetString("#-MilliSeconds.Abbr"));
            textBox10.Value = ResourceStrings.GetString("OrderStop");
            #endregion

            #region Page footer
            textBox45.Value = ResourceStrings.GetString("Report.Footer.Page");
            textBox46.Value = ResourceStrings.GetString("Report.Footer.LabelOf");
            textBox50.Value = ResourceStrings.GetString("Report.Footer.Center");
            textBox44.Value = ResourceStrings.GetString("Report.Footer.Right");
            #endregion
        }

        private void Machine_NeedDataSource(object sender, EventArgs e)
        {
            string divisionId = (string)ReportParameters["DivisionId"].Value;
            string machineId = (string)ReportParameters["MachineId"].Value;
            DateTime startDate = new DateTime(Convert.ToInt32(ReportParameters["Year"].Value), Convert.ToInt32(ReportParameters["Month"].Value), 1);
            DateTime endDate = startDate.AddMonths(1);

            if (startDate > DateTime.Now)
                endDate = startDate;
            else if (endDate > DateTime.Now)
                endDate = DateTime.Now;

            m_OrderData = new MachineOrder(divisionId, machineId, startDate, endDate);

            (sender as Telerik.Reporting.Processing.Report).DataSource = m_OrderData;
            
        }

        private void tableArticles_NeedDataSource(object sender, EventArgs e)
        {
            (sender as Telerik.Reporting.Processing.Table).DataSource = m_OrderData.GetOrders();
        }
    }
}