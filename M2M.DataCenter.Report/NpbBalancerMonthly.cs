using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using M2M.DataCenter.Localization;
using Telerik.Reporting.Charting;
using System.Drawing;
using System.Threading;
using System.Globalization;

namespace M2M.DataCenter.Reports
{
    /// <summary>
    /// Summary description for Machine.
    /// </summary>
    [Description("Npb")]
    [DisplayName("04")]
    public partial class NpbBalancerMonthly : Telerik.Reporting.Report
    {
        #region Properties

        AggregatedDataContainer m_AggregatedDataContainer = null;
        bool m_MasterStoppageGraphLoaded = false;
       
        private Dictionary<string, int> m_PaletteMapper = new Dictionary<string, int>();

        #endregion

        public NpbBalancerMonthly()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            string culture = CultureList.GetCulture(M2MDataCenter.User.Settings.Culture);

            if (culture != "")
            {
                this.Culture = new CultureInfo(culture);
            }

            SetLocalizedStrings();

            this.ReportParameters["DivisionId"].AvailableValues.DataSource = M2MDataCenter.GetDivisionsAccessibleForUser();
            this.ReportParameters["DivisionId"].AvailableValues.ValueMember = "DivisionId";
            this.ReportParameters["DivisionId"].AvailableValues.DisplayMember = "DisplayName";
            
            ArrayList years = new ArrayList();
            for (int i = DateTime.Today.Year; i >= 2005; i--)
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
            this.ReportParameters["DivisionId"].Text = ResourceStrings.GetString("Npb.Unit");
            this.ReportParameters["Year"].Text = ResourceStrings.GetString("Year");
            this.ReportParameters["Month"].Text = ResourceStrings.GetString("Month");
            #endregion

            #region Page header
            textBox26.Value = ResourceStrings.GetString("Npb.Report.MachineMonthly.Header");
            textBox24.Value = ResourceStrings.GetString("Npb.Module#:");
            textBox17.Value = ResourceStrings.GetString("Npb.Unit#:");
            textBox15.Value = ResourceStrings.GetString("Period#:");
            #endregion

            #region Overview
            textBox29.Value = ResourceStrings.GetString("AvailableProductionTime#:");
            tbTotalTime.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
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
            textBox59.Value = ResourceStrings.GetString("Npb.InternalValues");
            textBox39.Value = ResourceStrings.GetString("Oee");
            textBox53.Value = ResourceStrings.GetString("PreviousOee.Abbr");
            textBox42.Value = ResourceStrings.GetString("Availability.Abbr");
            textBox48.Value = ResourceStrings.GetString("Performance.Abbr");
            textBox51.Value = ResourceStrings.GetString("Quality.Abbr");
            textBox57.Value = ResourceStrings.GetString("ProductionTime.Abbr");
            textBox55.Value = ResourceStrings.GetString("Downtime");
            #endregion

            #region Downtime charts
            textBox12.Value = ResourceStrings.GetString("StopDistribution");
            textBox13.Value = ResourceStrings.GetString("StopTimeDistribution");
            #endregion



            #region Downtime
            textBox76.Value = ResourceStrings.GetString("Machine");
            textBox34.Value = ResourceStrings.GetString("Category");
            textBox19.Value = ResourceStrings.GetString("TimeConsumed.Total");
            textBox22.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox20.Value = ResourceStrings.GetString("NumberOfStops");
            textBox6.Value = ResourceStrings.GetString("TimeConsumed.Average");
            textBox7.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Minutes.Abbr"));
            textBox8.Value = ResourceStrings.GetString("PartOfTotalStops");
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

            DateTime startDate = new DateTime(Convert.ToInt32(ReportParameters["Year"].Value), Convert.ToInt32(ReportParameters["Month"].Value), 1);
            DateTime endDate = startDate.AddMonths(1);


            m_AggregatedDataContainer = new AggregatedDataContainer(0, divisionId, null, -1, startDate, endDate, M2MDataCenter.GetAvailableCategories());
            m_AggregatedDataContainer.OeeData.PreviousOee = new MachineOee(0, divisionId, null, -1, startDate.AddMonths(-3), startDate);
            
            (sender as Telerik.Reporting.Processing.Report).DataSource = m_AggregatedDataContainer;
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
            (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.GetTopStopTimes(M2MDataCenter.SystemSettings.StoppageListCount, false);
        }

        private void chartTotalOee_NeedDataSource(object sender, EventArgs e)
        {

        }

        private ChartSeries CreateChartSeries(string name, bool vertical, OeePart oeePart)
        {
            ChartSeries chartSeries = new ChartSeries(name, ChartSeriesType.StackedBar100);

            chartSeries.Name = name;

            chartSeries.Appearance.Border.Color = Color.Black;

            switch (oeePart)
            {
                case OeePart.Oee:
                    chartSeries.Appearance.FillStyle.MainColor = Color.DarkBlue;
                    chartSeries.Appearance.FillStyle.SecondColor = Color.Blue;
                    chartSeries.DataYColumn = "Oee";
                    break;
                case OeePart.Availability:
                    chartSeries.Appearance.FillStyle.MainColor = Color.RoyalBlue;
                    chartSeries.Appearance.FillStyle.SecondColor = Color.LightBlue;
                    chartSeries.DataYColumn = "NonAvailability";
                    break;
                case OeePart.Performance:
                    chartSeries.Appearance.FillStyle.MainColor = Color.LightGray;
                    chartSeries.Appearance.FillStyle.SecondColor = Color.WhiteSmoke;
                    chartSeries.DataYColumn = "RunRateLoss";
                    break;
                case OeePart.Quality:
                    chartSeries.Appearance.FillStyle.MainColor = Color.White;
                    chartSeries.Appearance.FillStyle.SecondColor = Color.White;
                    chartSeries.Appearance.LabelAppearance.Visible = false;
                    chartSeries.DataYColumn = "QualityLoss";
                    break;
                case OeePart.NotSet:
                    chartSeries.Appearance.FillStyle.MainColor = Color.Red;
                    chartSeries.Appearance.FillStyle.SecondColor = Color.DarkOrange;
                    chartSeries.DataYColumn = "Oee";

                    ChartSeriesItem item = new ChartSeriesItem();
                    item.YValue = 1.0;
                    chartSeries.Items.Add(item);

                    break;
            }

            if (vertical)
            {
                chartSeries.Appearance.BarWidthPercent = 30;
                chartSeries.DefaultLabelValue = "#Y{#0.0%}";
                chartSeries.Appearance.FillStyle.FillSettings.GradientMode = Telerik.Reporting.Charting.Styles.GradientFillStyle.Vertical;
                chartSeries.Appearance.LabelAppearance.LabelLocation = Telerik.Reporting.Charting.Styles.StyleSeriesItemLabel.ItemLabelLocation.Outside;
                chartSeries.Appearance.LabelAppearance.Position.Auto = false;
                chartSeries.Appearance.LabelAppearance.Position.AlignedPosition = Telerik.Reporting.Charting.Styles.AlignedPositions.Top;
                chartSeries.Appearance.LabelAppearance.Position.X = 0;
                chartSeries.Appearance.LabelAppearance.Position.Y = 0;
                chartSeries.Appearance.LegendDisplayMode = Telerik.Reporting.Charting.ChartSeriesLegendDisplayMode.SeriesName;
            }
            else
            {
                chartSeries.Appearance.BarWidthPercent = 30;
                chartSeries.DefaultLabelValue = "";
                chartSeries.Appearance.FillStyle.FillSettings.GradientMode = Telerik.Reporting.Charting.Styles.GradientFillStyle.Horizontal;
                chartSeries.Appearance.LabelAppearance.Visible = false;
                chartSeries.Appearance.LegendDisplayMode = Telerik.Reporting.Charting.ChartSeriesLegendDisplayMode.ItemLabels;
            }







            return chartSeries;
        }

        private void chartPeriodicOee_NeedDataSource(object sender, EventArgs e)
        {
            List<AggregatedOeeDataItem> oeeData = m_AggregatedDataContainer.OeeData.GetPeriodicData(Intervals.Daily);

            double minValue = oeeData.Min(a => a.Oee);
            Telerik.Reporting.Processing.Chart chart = sender as Telerik.Reporting.Processing.Chart;
            Telerik.Reporting.Chart chartDef = (Telerik.Reporting.Chart)chart.ItemDefinition;
            if (minValue <= 30)
            {
                chartDef.PlotArea.YAxis.MinValue = 0;
                chartDef.PlotArea.YAxis.Step = 20;
            }
            else if (minValue <= 50)
            {
                chartDef.PlotArea.YAxis.MinValue = 20;
                chartDef.PlotArea.YAxis.Step = 20;
            }
            else if (minValue <= 70)
            {
                chartDef.PlotArea.YAxis.MinValue = 40;
                chartDef.PlotArea.YAxis.Step = 10;
            }
            else if (minValue <= 90)
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
            (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.OeeData.GetMachineData();
        }

        public static string GetDocumentName(object division, object year, object month)
        {
            return String.Format(ResourceStrings.GetString("Npb.Report.MachineMonthly.DocumentName"), M2MDataCenter.GetDivision((string)division).DisplayName, year, month);
        }
    }
}