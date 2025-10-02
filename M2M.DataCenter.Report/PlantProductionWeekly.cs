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
    [DisplayName("09")]
    public partial class PlantProductionWeekly : Telerik.Reporting.Report
    {
        #region Properties

        
        ProductionData m_ProductionData = null;

        #endregion

        public PlantProductionWeekly()
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
            tbHeader.Value = ResourceStrings.GetString("Report.PlantProductionWeekly.Header");
            tbSubHeader.Value = ResourceStrings.GetString("#+Report.PlantProductionWeekly.SubHeader");
            textBox9.Value = ResourceStrings.GetString("StateType.Auto");
            textBox10.Value = ResourceStrings.GetString("Downtime");
            textBox11.Value = ResourceStrings.GetString("StateType.NoProduction");
            textBox12.Value = ResourceStrings.GetString("StateType.NotConnected");
            textBox13.Value = ResourceStrings.GetString("NonScheduled");
            #endregion
            
            #region Page footer
            textBox45.Value = ResourceStrings.GetString("Page");
            textBox46.Value = ResourceStrings.GetString("#-Of");
            textBox50.Value = ResourceStrings.GetString("Copyright");
            textBox44.Value = ResourceStrings.GetString("GeneratedBy");
            #endregion
        }

        public static string GetDocumentName(object year, object week)
        {
            return String.Format(ResourceStrings.GetString("Report.PlantProductionWeekly.DocumentName"), year, week);
        }

        private void Report_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report report = sender as Telerik.Reporting.Processing.Report;
            
            DateTime startTime = Extensions.FirstDateOfWeek(Convert.ToInt32(report.Parameters["Year"].Value), Convert.ToInt32(report.Parameters["Week"].Value));
            DateTime endTime = new Csla.SmartDate(startTime.AddDays(7));
            
            m_ProductionData = new ProductionData();
            m_ProductionData.Year = Convert.ToInt32(report.Parameters["Year"].Value);
            m_ProductionData.Week = String.Format("{0}. {1}", ResourceStrings.GetString("#-Week.Abbr"), report.Parameters["Week"].Value);
            m_ProductionData.PeriodicData = new List<MachineOee>();
            
            for(DateTime d = startTime; d < endTime; d = d.AddDays(1))
            {
                m_ProductionData.PeriodicData.Add(new MachineOee(0, null, null, -1, d, d.AddDays(1), null));
            }

            report.DataSource = m_ProductionData;
            
        }

        public static DateTime GetDate(object sender, object index)
        {
            var textBox = (Telerik.Reporting.Processing.ReportItem)sender;

            var panel = (Telerik.Reporting.Processing.Panel)textBox.ParentElement;

            var detail = (Telerik.Reporting.Processing.DetailSection)panel.ParentElement;

            var group = (Telerik.Reporting.Processing.Group)detail.ParentElement;

            var report = (Telerik.Reporting.Processing.Report)group.ParentElement;

            ProductionData prodData = (ProductionData)report.DataSource;

            return prodData.PeriodicData[(int)index].PeriodStart;
        }

        private void graph1_NeedDataSource(object sender, EventArgs e)
        {
            SetGraphDataSource(sender, 0);
        }

        private void graph2_NeedDataSource(object sender, EventArgs e)
        {
            SetGraphDataSource(sender, 1);
        }

        private void graph3_NeedDataSource(object sender, EventArgs e)
        {
            SetGraphDataSource(sender, 2);
        }

        private void graph4_NeedDataSource(object sender, EventArgs e)
        {
            SetGraphDataSource(sender, 3);
        }

        private void graph5_NeedDataSource(object sender, EventArgs e)
        {
            SetGraphDataSource(sender, 4);
        }

        private void graph6_NeedDataSource(object sender, EventArgs e)
        {
            SetGraphDataSource(sender, 5);
        }

        private void graph7_NeedDataSource(object sender, EventArgs e)
        {
            SetGraphDataSource(sender, 6);
        }

        private void SetGraphDataSource(object sender, int index)
        {

            var graph = (Telerik.Reporting.Processing.DataItem)sender;

            var panel = (Telerik.Reporting.Processing.Panel)graph.ParentElement;

            var detail = (Telerik.Reporting.Processing.DetailSection)panel.ParentElement;

            var group = (Telerik.Reporting.Processing.Group)detail.ParentElement;

            var report = (Telerik.Reporting.Processing.Report)group.ParentElement;

            ProductionData prodData = (ProductionData)report.DataSource;

            graph.DataSource = prodData.PeriodicData[index].GetDataForAllDivisions();
        }

        
    }
    
}