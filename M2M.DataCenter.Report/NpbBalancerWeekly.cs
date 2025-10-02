using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.Reporting.Charting;
using System.Collections.Generic;
using M2M.DataCenter.Localization;
using M2M.DataCenter.Utilities;
using System.Collections;

namespace M2M.DataCenter.Reports
{
    /// <summary>
    /// Summary description for Machine.
    /// </summary>
    [Description("Npb")]
    [DisplayName("03")]
    public partial class NpbBalancerWeekly : Telerik.Reporting.Report
    {
        #region Properties

        AggregatedDataContainer m_AggregatedDataContainer = null;
		bool m_MasterStoppageGraphLoaded = false;
        List<string> m_Divisions = null;

		private Dictionary<string, int> m_PaletteMapper = new Dictionary<string, int>();
       
        #endregion

        public NpbBalancerWeekly()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            SetLocalizedStrings();

            this.ReportParameters["ModuleId"].AvailableValues.DataSource = M2MDataCenter.GetGroupings(GroupingType.Module);
            this.ReportParameters["ModuleId"].AvailableValues.ValueMember = "GroupingId";
            this.ReportParameters["ModuleId"].AvailableValues.DisplayMember = "DisplayName";

            ArrayList years = new ArrayList();
            for (int i = DateTime.Today.Year; i >= 2005; i--)
            {
                years.Add(i);
            }
            this.ReportParameters["Year"].AvailableValues.DataSource = years;
            this.ReportParameters["Year"].AvailableValues.ValueMember = "Item";

            ArrayList weeks = new ArrayList();

            for (int i = 1; i <= 53; i++)
            {
                weeks.Add(i);
            }

            this.ReportParameters["Week"].AvailableValues.DataSource = weeks;
            this.ReportParameters["Week"].AvailableValues.ValueMember = "Item";
            
            int week = DateTime.Today.AddDays(-7).GetWeek();
            this.ReportParameters["Year"].Value = week == 1 ? DateTime.Today.AddYears(-1).Year : DateTime.Today.Year;
            this.ReportParameters["Week"].Value = week;
  
        }

        private void SetLocalizedStrings()
        {
            #region Report parameters
            this.ReportParameters["ModuleId"].Text = ResourceStrings.GetString("Npb.Module");
            this.ReportParameters["Year"].Text = ResourceStrings.GetString("Year");
            this.ReportParameters["Week"].Text = ResourceStrings.GetString("Week");
            #endregion

            #region Page header
            tbHeader.Value = ResourceStrings.GetString("Npb.Report.WeeklySummary.Header");
            tbDivisionPrompt.Value = ResourceStrings.GetString("Npb.Module#:");
            tbDatePrompt.Value = ResourceStrings.GetString("Period#:");
            #endregion

            #region Machines
            
            textBox13.Value = ResourceStrings.GetString("Oee");
            textBox1.Value = ResourceStrings.GetString("PreviousOee.Abbr");
            textBox17.Value = ResourceStrings.GetString("Availability.Abbr");
            textBox19.Value = ResourceStrings.GetString("Performance.Abbr");
            textBox21.Value = ResourceStrings.GetString("Quality.Abbr");
            textBox6.Value = ResourceStrings.GetString("ProductionTime.Abbr");
            textBox4.Value = ResourceStrings.GetString("Downtime");
            textBox7.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            textBox5.Format = String.Format("{0} {1}", "{0:N1}", ResourceStrings.GetString("#-Hours.Abbr"));
            #endregion

            #region Downtime charts
            textBox23.Value = ResourceStrings.GetString("StopDistribution");
            textBox14.Value = ResourceStrings.GetString("StopTimeDistribution");
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
            int groupingId = Convert.ToInt32(ReportParameters["ModuleId"].Value);

            DateTime startDate = Extensions.FirstDateOfWeek(Convert.ToInt32(ReportParameters["Year"].Value), Convert.ToInt32(ReportParameters["Week"].Value));
            DateTime endDate = startDate.AddDays(7);

            if (startDate > DateTime.Now)
                endDate = startDate;
            else if (endDate > DateTime.Now)
                endDate = DateTime.Now;

            m_AggregatedDataContainer = new AggregatedDataContainer(groupingId, null, null, -1, startDate, endDate, M2MDataCenter.GetAvailableCategories());
            m_AggregatedDataContainer.OeeData.PreviousOee = new MachineOee(groupingId, null, null, -1, startDate.AddDays(-21), startDate);
            m_Divisions = m_AggregatedDataContainer.DivisionIdList;

            (sender as Telerik.Reporting.Processing.Report).DataSource = m_AggregatedDataContainer;
            
        }

        

        private void tableMachines_NeedDataSource(object sender, EventArgs e)
        {
            (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.OeeData.GetDivisionData();
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
            try
            {
                (sender as Telerik.Reporting.Processing.Table).DataSource = m_AggregatedDataContainer.StoppageData.GetMachineTopStopTimes(12, true);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
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

        private void chart1StopCount_NeedDataSource(object sender, EventArgs e)
        {
            try
            {
                if (m_Divisions.Count < 1)
                    return;

                Telerik.Reporting.Processing.Chart chart = sender as Telerik.Reporting.Processing.Chart;
                chart.Parent.Visible = true;
                Telerik.Reporting.Chart chartDef = (Telerik.Reporting.Chart)chart.ItemDefinition;
                chartDef.ChartTitle.TextBlock.Text = M2MDataCenter.GetDivision(m_Divisions[0]).DisplayName;
               
                List<AggregatedStoppageDataListItem> stoppageData = m_AggregatedDataContainer.GetTopStopCounts(m_Divisions[0], 5, true);

                if (!m_MasterStoppageGraphLoaded)
                    LoadMasterStoppageGraph(sender, stoppageData);
                else
                    LoadSlaveStoppageGraph(sender, stoppageData);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void chart1StopTime_NeedDataSource(object sender, EventArgs e)
        {
            try
            {
                if (m_Divisions.Count < 1)
                    return;

                Telerik.Reporting.Processing.Chart chart = sender as Telerik.Reporting.Processing.Chart;
                chart.Parent.Visible = true;

                List<AggregatedStoppageDataListItem> stoppageData = m_AggregatedDataContainer.GetTopStopTimes(m_Divisions[0], 5, true);

                if (!m_MasterStoppageGraphLoaded)
                    LoadMasterStoppageGraph(sender, stoppageData);
                else
                    LoadSlaveStoppageGraph(sender, stoppageData);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void chart2StopCount_NeedDataSource(object sender, EventArgs e)
        {
            try
            {
                if (m_Divisions.Count < 2)
                    return;

                Telerik.Reporting.Processing.Chart chart = sender as Telerik.Reporting.Processing.Chart;
                chart.Parent.Visible = true;
                Telerik.Reporting.Chart chartDef = (Telerik.Reporting.Chart)chart.ItemDefinition;
                chartDef.ChartTitle.TextBlock.Text = M2MDataCenter.GetDivision(m_Divisions[1]).DisplayName;

                List<AggregatedStoppageDataListItem> stoppageData = m_AggregatedDataContainer.GetTopStopCounts(m_Divisions[1], 5, true);

                if (!m_MasterStoppageGraphLoaded)
                    LoadMasterStoppageGraph(sender, stoppageData);
                else
                    LoadSlaveStoppageGraph(sender, stoppageData);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void chart2StopTime_NeedDataSource(object sender, EventArgs e)
        {
            try
            {
                if (m_Divisions.Count < 2)
                    return;

                Telerik.Reporting.Processing.Chart chart = sender as Telerik.Reporting.Processing.Chart;
                chart.Parent.Visible = true;

                List<AggregatedStoppageDataListItem> stoppageData = m_AggregatedDataContainer.GetTopStopTimes(m_Divisions[1], 5, true);

                if (!m_MasterStoppageGraphLoaded)
                    LoadMasterStoppageGraph(sender, stoppageData);
                else
                    LoadSlaveStoppageGraph(sender, stoppageData);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void chart3StopCount_NeedDataSource(object sender, EventArgs e)
        {
            try
            {
                if (m_Divisions.Count < 3)
                    return;

                Telerik.Reporting.Processing.Chart chart = sender as Telerik.Reporting.Processing.Chart;
                chart.Parent.Visible = true;
                Telerik.Reporting.Chart chartDef = (Telerik.Reporting.Chart)chart.ItemDefinition;
                chartDef.ChartTitle.TextBlock.Text = M2MDataCenter.GetDivision(m_Divisions[2]).DisplayName;

                List<AggregatedStoppageDataListItem> stoppageData = m_AggregatedDataContainer.GetTopStopCounts(m_Divisions[2], 5, true);

                if (!m_MasterStoppageGraphLoaded)
                    LoadMasterStoppageGraph(sender, stoppageData);
                else
                    LoadSlaveStoppageGraph(sender, stoppageData);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void chart3StopTime_NeedDataSource(object sender, EventArgs e)
        {
            try
            {
                if (m_Divisions.Count < 3)
                    return;

                Telerik.Reporting.Processing.Chart chart = sender as Telerik.Reporting.Processing.Chart;
                chart.Parent.Visible = true;

                List<AggregatedStoppageDataListItem> stoppageData = m_AggregatedDataContainer.GetTopStopTimes(m_Divisions[2], 5, true);

                if (!m_MasterStoppageGraphLoaded)
                    LoadMasterStoppageGraph(sender, stoppageData);
                else
                    LoadSlaveStoppageGraph(sender, stoppageData);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void chart4StopCount_NeedDataSource(object sender, EventArgs e)
        {
            try
            {
                if (m_Divisions.Count < 4)
                    return;

                Telerik.Reporting.Processing.Chart chart = sender as Telerik.Reporting.Processing.Chart;
                chart.Parent.Visible = true;
                Telerik.Reporting.Chart chartDef = (Telerik.Reporting.Chart)chart.ItemDefinition;
                chartDef.ChartTitle.TextBlock.Text = M2MDataCenter.GetDivision(m_Divisions[3]).DisplayName;

                List<AggregatedStoppageDataListItem> stoppageData = m_AggregatedDataContainer.GetTopStopCounts(m_Divisions[3], 5, true);

                if (!m_MasterStoppageGraphLoaded)
                    LoadMasterStoppageGraph(sender, stoppageData);
                else
                    LoadSlaveStoppageGraph(sender, stoppageData);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void chart4StopTime_NeedDataSource(object sender, EventArgs e)
        {
            try
            {
                if (m_Divisions.Count < 4)
                    return;

                Telerik.Reporting.Processing.Chart chart = sender as Telerik.Reporting.Processing.Chart;
                chart.Parent.Visible = true;

                List<AggregatedStoppageDataListItem> stoppageData = m_AggregatedDataContainer.GetTopStopTimes(m_Divisions[3], 5, true);

                if (!m_MasterStoppageGraphLoaded)
                    LoadMasterStoppageGraph(sender, stoppageData);
                else
                    LoadSlaveStoppageGraph(sender, stoppageData);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void chart5StopCount_NeedDataSource(object sender, EventArgs e)
        {
            try
            {
                if (m_Divisions.Count < 5)
                    return;

                Telerik.Reporting.Processing.Chart chart = sender as Telerik.Reporting.Processing.Chart;
                chart.Parent.Visible = true;
                Telerik.Reporting.Chart chartDef = (Telerik.Reporting.Chart)chart.ItemDefinition;
                chartDef.ChartTitle.TextBlock.Text = M2MDataCenter.GetDivision(m_Divisions[4]).DisplayName;

                List<AggregatedStoppageDataListItem> stoppageData = m_AggregatedDataContainer.GetTopStopCounts(m_Divisions[4], 5, true);

                if (!m_MasterStoppageGraphLoaded)
                    LoadMasterStoppageGraph(sender, stoppageData);
                else
                    LoadSlaveStoppageGraph(sender, stoppageData);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void chart5StopTime_NeedDataSource(object sender, EventArgs e)
        {
            try
            {
                if (m_Divisions.Count < 5)
                    return;

                Telerik.Reporting.Processing.Chart chart = sender as Telerik.Reporting.Processing.Chart;
                chart.Parent.Visible = true;

                List<AggregatedStoppageDataListItem> stoppageData = m_AggregatedDataContainer.GetTopStopTimes(m_Divisions[4], 5, true);

                if (!m_MasterStoppageGraphLoaded)
                    LoadMasterStoppageGraph(sender, stoppageData);
                else
                    LoadSlaveStoppageGraph(sender, stoppageData);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public static string GetDocumentName(object grouping, object year, object week)
        {
            return String.Format(ResourceStrings.GetString("Npb.Report.WeeklySummary.DocumentName"), M2MDataCenter.GetGrouping(Convert.ToInt32(grouping)).DisplayName, year, week);
        }
        
    }
}