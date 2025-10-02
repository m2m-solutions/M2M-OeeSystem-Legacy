using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using M2M.DataCenter.Localization;
using Telerik.Reporting.Charting;
using System.Drawing;
using System.Globalization;
using System.Web;

namespace M2M.DataCenter.Reports
{
    /// <summary>
    /// Summary description for Machine.
    /// </summary>
    [Description("Npb")]
    [DisplayName("02")]
    public partial class NpbMonthly : Telerik.Reporting.Report
    {
        #region Properties

        AggregatedDataContainer m_AggregatedDataContainer = null;
        bool m_MasterStoppageGraphLoaded = false;
       
        private Dictionary<string, int> m_PaletteMapper = new Dictionary<string, int>();

        #endregion

        public NpbMonthly()
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
            textBox26.Value = ResourceStrings.GetString("Report.NpbMonthly.Header");
            textBox24.Value = ResourceStrings.GetString("Npb.Module#:");
            textBox17.Value = ResourceStrings.GetString("Npb.Unit#:");
            #endregion

            #region Overview
            textBox29.Value = ResourceStrings.GetString("AvailableProductionTime#:");
            tbProductionTime.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox4.Value = ResourceStrings.GetString("ActualProductionTime#:");
            tbActualTime.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox3.Value = ResourceStrings.GetString("Downtime#:");
            tbStopTime.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox33.Value = ResourceStrings.GetString("TotalStopCount#:");
            textBox32.Value = ResourceStrings.GetString("ProducedItemsInThousands#:");
            textBox2.Value = ResourceStrings.GetString("Oee#:");
            textBox1.Value = ResourceStrings.GetString("AvailabilityWithAbbr#:");
            textBox36.Value = ResourceStrings.GetString("PerformanceWithAbbr#:");
            textBox37.Value = ResourceStrings.GetString("QualityWithAbbr#:");
            textBox30.Value = ResourceStrings.GetString("PreviousOee#:");
            #endregion

            #region Oee charts
            chartPeriodicOee.Series[0].Name = ResourceStrings.GetString("Oee.Abbr");
            chartPeriodicOee.Series[1].Name = ResourceStrings.GetString("AvailabilityLoss");
            chartPeriodicOee.Series[2].Name = ResourceStrings.GetString("PerformanceLoss");
            chartPeriodicOee.Series[3].Name = ResourceStrings.GetString("QualityLoss");
            #endregion

            #region Units
            textBox12.Value = ResourceStrings.GetString("Npb.InternalValues");
            textBox12.GrowAndCenterControl();
            textBox39.Value = ResourceStrings.GetString("Oee");
            textBox30.Value = ResourceStrings.GetString("Availability.Abbr");
            textBox85.Value = ResourceStrings.GetString("AvailabilityLoss.Abbr");
            textBox115.Value = ResourceStrings.GetString("AvailabilityLossBasedOnActualStops.Abbr");
            textBox38.Value = ResourceStrings.GetString("AvailabilityLossBasedOnFlowErrors.Abbr");
            textBox48.Value = ResourceStrings.GetString("Performance.Abbr");
            textBox51.Value = ResourceStrings.GetString("Quality.Abbr");
            textBox57.Value = ResourceStrings.GetString("ProductionTime.Abbr");
            textBox55.Value = ResourceStrings.GetString("Downtime");
            textBox5.Value = ResourceStrings.GetString("ProducedItems.Abbr");
            textBox11.Value = ResourceStrings.GetString("Stops");
            #endregion

            #region Downtime charts
            textBox15.Value = ResourceStrings.GetString("StopDistribution");
            textBox15.GrowAndCenterControl();
            textBox13.Value = ResourceStrings.GetString("StopTimeDistribution");
            textBox13.GrowAndCenterControl();
            #endregion



            #region Downtime
            textBox34.Value = ResourceStrings.GetString("Category");
            textBox19.Value = ResourceStrings.GetString("TimeConsumed.Total");
            textBox22.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox20.Value = ResourceStrings.GetString("NumberOfStops");
            textBox6.Value = ResourceStrings.GetString("TimeConsumed.Average");
            textBox7.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox8.Value = ResourceStrings.GetString("PartOfTotalStops");
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
            string divisionId = (string)report.Parameters["DivisionId"].Value;

            DateTime startDate = new DateTime(Convert.ToInt32(report.Parameters["Year"].Value), Convert.ToInt32(report.Parameters["Month"].Value), 1);
            DateTime endDate = startDate.AddMonths(1);

            m_AggregatedDataContainer = new AggregatedDataContainer(0, divisionId, null, -1, startDate, endDate, M2MDataCenter.GetAvailableCategories());
           
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
                    LoadMasterStoppageGraph(sender, stoppageData);
                else
                    LoadSlaveStoppageGraph(sender, stoppageData);
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
                    LoadMasterStoppageGraph(sender, stoppageData);
                else
                    LoadSlaveStoppageGraph(sender, stoppageData);
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            
        }

        private void LoadMasterStoppageGraph(object sender, List<AggregatedStoppageDataListItem> stoppageData)
        {
            try
            {
                m_PaletteMapper.Clear();

                int index = 0;
                foreach (AggregatedStoppageDataListItem item in stoppageData)
                {
                    m_PaletteMapper.Add(string.Format("{0}.{1}", item.MachineId, item.Reason), index);
					index++;
                }

                Telerik.Reporting.Processing.Chart chart = sender as Telerik.Reporting.Processing.Chart;
                Telerik.Reporting.Chart chartDef = (Telerik.Reporting.Chart)chart.ItemDefinition;

                chartDef.CustomPalettes[0].Items.Clear();
                chartDef.CustomPalettes[0].Items.AddRange(ChartHelper.GetPalette(m_PaletteMapper));

                chart.DataSource = stoppageData;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            m_MasterStoppageGraphLoaded = true;
        }

        private void LoadSlaveStoppageGraph(object sender, List<AggregatedStoppageDataListItem> stoppageData)
        {
            try
            {
                Dictionary<string, int> paletteMapper = new Dictionary<string, int>();

                foreach (AggregatedStoppageDataListItem item in stoppageData)
                {
                    if (m_PaletteMapper.ContainsKey(string.Format("{0}.{1}", item.MachineId, item.Reason)))
                        paletteMapper.Add(string.Format("{0}.{1}", item.MachineId, item.Reason), m_PaletteMapper[string.Format("{0}.{1}", item.MachineId, item.Reason)]);
                    else
                        paletteMapper.Add(string.Format("{0}.{1}", item.MachineId, item.Reason), ChartHelper.GetFirstAvailableIndex(m_PaletteMapper, paletteMapper));
                }

                Telerik.Reporting.Processing.Chart chart = sender as Telerik.Reporting.Processing.Chart;
                Telerik.Reporting.Chart chartDef = (Telerik.Reporting.Chart)chart.ItemDefinition;

                chartDef.CustomPalettes[0].Items.Clear();
                chartDef.CustomPalettes[0].Items.AddRange(ChartHelper.GetPalette(paletteMapper));

                chart.DataSource = stoppageData;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            m_MasterStoppageGraphLoaded = false;
        }

        private void tableStops_NeedDataSource(object sender, EventArgs e)
        {
            (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.GetTopStopTimes(0, false).OrderByDescending(s => s.ElapsedTime).OrderBy(s => s.Machine);
        }

        private void chartTotalOee_NeedDataSource(object sender, EventArgs e)
        {

        }

        private void chartPeriodicOee_NeedDataSource(object sender, EventArgs e)
        {
            List<AggregatedOeeDataItem> oeeData = m_AggregatedDataContainer.OeeData.GetPeriodicData(Intervals.Daily);

            if (oeeData.Count == 0)
                return;

            double minValue = oeeData.Min(a => a.Oee);
            Telerik.Reporting.Processing.Chart chart = sender as Telerik.Reporting.Processing.Chart;
            Telerik.Reporting.Chart chartDef = (Telerik.Reporting.Chart)chart.ItemDefinition;
            if (minValue <= 0.30)
            {
                chartDef.PlotArea.YAxis.MinValue = 0;
                chartDef.PlotArea.YAxis.Step = 20;
            }
            else if (minValue <= 0.50)
            {
                chartDef.PlotArea.YAxis.MinValue = 20;
                chartDef.PlotArea.YAxis.Step = 20;
            }
            else if (minValue <= 0.70)
            {
                chartDef.PlotArea.YAxis.MinValue = 40;
                chartDef.PlotArea.YAxis.Step = 10;
            }
            else if (minValue <= 0.90)
            {
                chartDef.PlotArea.YAxis.MinValue = 50;
                chartDef.PlotArea.YAxis.Step = 10;
            }
            else
            {
                chartDef.PlotArea.YAxis.MinValue = 80;
                chartDef.PlotArea.YAxis.Step = 5;
            }
            (sender as Telerik.Reporting.Processing.Chart).DataSource = oeeData;
        }

        private void tableMachines_NeedDataSource(object sender, EventArgs e)
        {
            (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.GetDataForAllMachines();
        }

        public static string GetDocumentName(object division, object year, object month)
        {
            return String.Format(ResourceStrings.GetString("Report.NpbMonthly.DocumentName"), M2MDataCenter.GetDivision((string)division).DisplayName, year, month);
        }

        private static string lastMachine = "";
        private static bool border = false;
        private static int index = 0;
        public static Telerik.Reporting.Drawing.BorderType GetBorderTop(object sender)
        {
            Telerik.Reporting.Drawing.BorderType result = Telerik.Reporting.Drawing.BorderType.None;
            var dataObject = (Telerik.Reporting.Processing.IDataObject)sender;
            var machine = dataObject["Machine"] as string;

            if (index % 7 == 0)
                border = lastMachine != "" && lastMachine != machine;

            if (border)
            {
                result = Telerik.Reporting.Drawing.BorderType.Solid;
            }

            index++;
            
            lastMachine = machine;
                            
            return result;
        }
    }
}