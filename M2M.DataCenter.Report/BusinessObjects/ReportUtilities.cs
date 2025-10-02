using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Telerik.Reporting.Charting;

namespace M2M.DataCenter
{
    public static class ReportUtilities
    {
        public static void GrowAndCenterControl(this Telerik.Reporting.TextBox textBox)
        {
            if (textBox.Parent is Telerik.Reporting.Panel)
            {
                float sizeNeeded = MeasureStringWidth(textBox.Value, new Font(new FontFamily(textBox.Style.Font.Name), textBox.Style.Font.Size.Value, textBox.Style.Font.Style ));
                float widthAvailable = (textBox.Parent as Telerik.Reporting.Panel).Size.Width.Value;
                float center = widthAvailable / 2.0f;
                float left = center - sizeNeeded / 2.0f;
                textBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(left > 0.0f ? left : 0.0f, Telerik.Reporting.Drawing.UnitType.Cm), textBox.Location.Y);
                textBox.Width = new Telerik.Reporting.Drawing.Unit(sizeNeeded < widthAvailable ? sizeNeeded : widthAvailable, Telerik.Reporting.Drawing.UnitType.Cm);
            }
        }

        public static void GrowAndCenterControl(this Telerik.Reporting.Processing.TextBox textBox)
        {
            if (textBox.ParentElement is Telerik.Reporting.Processing.Panel)
            {
                float sizeNeeded = MeasureStringWidth(textBox.Text, new Font(new FontFamily(textBox.Style.Font.Name), textBox.Style.Font.Size.Value, textBox.Style.Font.Style));
                float widthAvailable = (textBox.ParentElement as Telerik.Reporting.Processing.Panel).Size.Width.Value;
                float center = widthAvailable / 2.0f;
                float left = center - sizeNeeded / 2.0f;
                textBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(left > 0.0f ? left : 0.0f, Telerik.Reporting.Drawing.UnitType.Cm), textBox.Location.Y);
                textBox.Width = new Telerik.Reporting.Drawing.Unit(sizeNeeded < widthAvailable ? sizeNeeded : widthAvailable, Telerik.Reporting.Drawing.UnitType.Cm);
            }
        }

        private static float MeasureStringWidth(string s, Font font)
        {
            SizeF result;
            using (var image = new Bitmap(1, 1))
            {
                using (var g = Graphics.FromImage(image))
                {
                    result = g.MeasureString(s, font);
                }
            }

            return result.Width/96.0f*2.54f + 0.5f;
        }

        public static ChartSeries CreateOeeChartSeries(string name, bool vertical, OeePart oeePart)
        {
            return CreateOeeChartSeries(name, vertical, oeePart, false);
        }

        public static ChartSeries CreateOeeChartSeries(string name, bool vertical, OeePart oeePart, bool showLabel)
        {
            ChartSeries chartSeries = new ChartSeries(name, ChartSeriesType.StackedBar100);

            chartSeries.Name = name;

            chartSeries.Appearance.Border.Color = Color.Black;

            switch (oeePart)
            {
                case OeePart.Oee:
                    chartSeries.Appearance.FillStyle.MainColor = Color.DarkBlue;
                    chartSeries.Appearance.FillStyle.SecondColor = Color.Blue;
                    chartSeries.Appearance.LabelAppearance.Visible = showLabel;
                    chartSeries.DataYColumn = "Oee";
                    break;
                case OeePart.Availability:
                    chartSeries.Appearance.FillStyle.MainColor = Color.RoyalBlue;
                    chartSeries.Appearance.FillStyle.SecondColor = Color.LightBlue;
                    chartSeries.Appearance.LabelAppearance.Visible = showLabel;
                    chartSeries.DataYColumn = "NonAvailability";
                    break;
                case OeePart.Performance:
                    chartSeries.Appearance.FillStyle.MainColor = Color.LightGray;
                    chartSeries.Appearance.FillStyle.SecondColor = Color.WhiteSmoke;
                    chartSeries.Appearance.LabelAppearance.Visible = showLabel;
                    chartSeries.DataYColumn = "RunRateLoss";
                    break;
                case OeePart.Quality:
                    chartSeries.Appearance.FillStyle.MainColor = Color.White;
                    chartSeries.Appearance.FillStyle.SecondColor = Color.White;
                    chartSeries.Appearance.LabelAppearance.Visible = showLabel;
                    chartSeries.DataYColumn = "QualityLoss";
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

        private static readonly Dictionary<string, int> PaletteMapper = new Dictionary<string, int>();

        public static void LoadMasterStoppageGraph(object sender, List<AggregatedStoppageDataListItem> stoppageData, bool includeMachine)
        {
            try
            {
                PaletteMapper.Clear();

                int index = 0;
                foreach (AggregatedStoppageDataListItem item in stoppageData)
                {
                    string reason = includeMachine ? item.ReasonWithMachinePrefix : item.Reason;
                    PaletteMapper.Add(reason, index);
                    index++;
                }

                Telerik.Reporting.Processing.Chart chart = sender as Telerik.Reporting.Processing.Chart;
                Telerik.Reporting.Chart chartDef = (Telerik.Reporting.Chart)chart.ItemDefinition;

                chartDef.CustomPalettes[0].Items.Clear();
                chartDef.CustomPalettes[0].Items.AddRange(ChartHelper.GetPalette(PaletteMapper));

                chart.DataSource = stoppageData;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public static void LoadSlaveStoppageGraph(object sender, List<AggregatedStoppageDataListItem> stoppageData, bool includeMachine)
        {
            try
            {
                Dictionary<string, int> paletteMapper = new Dictionary<string, int>();

                foreach (AggregatedStoppageDataListItem item in stoppageData)
                {
                    string reason = includeMachine ? item.ReasonWithMachinePrefix : item.Reason;
                    if (PaletteMapper.ContainsKey(reason))
                        paletteMapper.Add(reason, PaletteMapper[reason]);
                    else
                        paletteMapper.Add(reason, ChartHelper.GetFirstAvailableIndex(PaletteMapper, paletteMapper));
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
        }

    }
}
