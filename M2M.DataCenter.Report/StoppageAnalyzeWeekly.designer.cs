namespace M2M.DataCenter.Reports
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class StoppageAnalyzeWeekly
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.PageFooterSection pageFooterSection1;
            Telerik.Reporting.TextBox tbShapeRow1;
            Telerik.Reporting.GraphGroup graphGroup1 = new Telerik.Reporting.GraphGroup();
            Telerik.Reporting.Drawing.ColorPalette colorPalette1 = new Telerik.Reporting.Drawing.ColorPalette();
            Telerik.Reporting.CategoryScale categoryScale1 = new Telerik.Reporting.CategoryScale();
            Telerik.Reporting.NumericalScale numericalScale1 = new Telerik.Reporting.NumericalScale();
            Telerik.Reporting.GraphGroup graphGroup2 = new Telerik.Reporting.GraphGroup();
            Telerik.Reporting.NumericalScale numericalScale2 = new Telerik.Reporting.NumericalScale();
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup3 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup4 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup5 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup6 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup7 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup8 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.CategoryScale categoryScale2 = new Telerik.Reporting.CategoryScale();
            Telerik.Reporting.CategoryScale categoryScale3 = new Telerik.Reporting.CategoryScale();
            Telerik.Reporting.NumericalScale numericalScale3 = new Telerik.Reporting.NumericalScale();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter5 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter6 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter7 = new Telerik.Reporting.ReportParameter();
            this.textBox44 = new Telerik.Reporting.TextBox();
            this.textBox50 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox46 = new Telerik.Reporting.TextBox();
            this.textBox47 = new Telerik.Reporting.TextBox();
            this.textBox45 = new Telerik.Reporting.TextBox();
            this.pictureBoxLogo = new Telerik.Reporting.PictureBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.panel5 = new Telerik.Reporting.Panel();
            this.panel6 = new Telerik.Reporting.Panel();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.graph1 = new Telerik.Reporting.Graph();
            this.cartesianCoordinateSystem1 = new Telerik.Reporting.CartesianCoordinateSystem();
            this.graphAxis5 = new Telerik.Reporting.GraphAxis();
            this.graphAxis6 = new Telerik.Reporting.GraphAxis();
            this.lineSeries1 = new Telerik.Reporting.LineSeries();
            this.lineSeries2 = new Telerik.Reporting.LineSeries();
            this.graphAxis2 = new Telerik.Reporting.GraphAxis();
            this.tbHeader = new Telerik.Reporting.TextBox();
            this.tbDivisionPrompt = new Telerik.Reporting.TextBox();
            this.tbDivisionName = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.panelLogo = new Telerik.Reporting.Panel();
            this.tbSubHeader = new Telerik.Reporting.TextBox();
            this.panel4 = new Telerik.Reporting.Panel();
            this.shape1 = new Telerik.Reporting.Shape();
            this.tbShapeRow2 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.tbCategory = new Telerik.Reporting.TextBox();
            this.tbStopReason = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox32 = new Telerik.Reporting.TextBox();
            this.textBox100 = new Telerik.Reporting.TextBox();
            this.tbComment = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.panel3 = new Telerik.Reporting.Panel();
            this.textBox68 = new Telerik.Reporting.TextBox();
            this.table2 = new Telerik.Reporting.Table();
            this.textBox69 = new Telerik.Reporting.TextBox();
            this.textBox70 = new Telerik.Reporting.TextBox();
            this.textBox71 = new Telerik.Reporting.TextBox();
            this.textBox72 = new Telerik.Reporting.TextBox();
            this.textBox73 = new Telerik.Reporting.TextBox();
            this.textBox74 = new Telerik.Reporting.TextBox();
            this.textBox75 = new Telerik.Reporting.TextBox();
            this.textBox78 = new Telerik.Reporting.TextBox();
            this.textBox79 = new Telerik.Reporting.TextBox();
            this.textBox80 = new Telerik.Reporting.TextBox();
            this.textBox81 = new Telerik.Reporting.TextBox();
            this.textBox82 = new Telerik.Reporting.TextBox();
            this.textBox83 = new Telerik.Reporting.TextBox();
            this.textBox84 = new Telerik.Reporting.TextBox();
            this.graphAxis1 = new Telerik.Reporting.GraphAxis();
            this.graphAxis3 = new Telerik.Reporting.GraphAxis();
            this.graphAxis4 = new Telerik.Reporting.GraphAxis();
            pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            tbShapeRow1 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageFooterSection1
            // 
            pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.0054166316986084D);
            pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox44,
            this.textBox50,
            this.textBox2,
            this.textBox46,
            this.textBox47,
            this.textBox45,
            this.pictureBoxLogo});
            pageFooterSection1.Name = "pageFooterSection1";
            pageFooterSection1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            pageFooterSection1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            pageFooterSection1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            pageFooterSection1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            // 
            // textBox44
            // 
            this.textBox44.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.026458332315087318D), Telerik.Reporting.Drawing.Unit.Cm(0.10583332926034927D));
            this.textBox44.Name = "textBox44";
            this.textBox44.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.1973986625671387D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox44.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox44.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat;
            this.textBox44.Style.Color = System.Drawing.Color.Black;
            this.textBox44.Style.Font.Bold = false;
            this.textBox44.Style.Font.Name = "Calibri";
            this.textBox44.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox44.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox44.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox44.StyleName = "";
            this.textBox44.Value = "Genererad av M2M OeeSystem";
            // 
            // textBox50
            // 
            this.textBox50.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.7733330726623535D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox50.Name = "textBox50";
            this.textBox50.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.2916665077209473D), Telerik.Reporting.Drawing.Unit.Cm(0.37041667103767395D));
            this.textBox50.Style.Color = System.Drawing.Color.Gray;
            this.textBox50.Style.Font.Name = "Calibri";
            this.textBox50.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox50.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox50.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox50.Value = "Copyright© 2009, M2M Solutions AB";
            // 
            // textBox2
            // 
            this.textBox2.CanShrink = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.74780780076980591D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.37000000476837158D), Telerik.Reporting.Drawing.Unit.Cm(0.37000000476837158D));
            this.textBox2.Style.Color = System.Drawing.Color.Gray;
            this.textBox2.Style.Font.Italic = true;
            this.textBox2.Style.Font.Name = "Calibri";
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox2.TextWrap = false;
            this.textBox2.Value = "= PageNumber";
            // 
            // textBox46
            // 
            this.textBox46.CanShrink = true;
            this.textBox46.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.1178078651428223D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox46.Name = "textBox46";
            this.textBox46.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.427083283662796D), Telerik.Reporting.Drawing.Unit.Cm(0.37000000476837158D));
            this.textBox46.Style.Color = System.Drawing.Color.Gray;
            this.textBox46.Style.Font.Italic = true;
            this.textBox46.Style.Font.Name = "Calibri";
            this.textBox46.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox46.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox46.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox46.TextWrap = false;
            this.textBox46.Value = "av";
            // 
            // textBox47
            // 
            this.textBox47.CanShrink = true;
            this.textBox47.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.5448908805847168D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox47.Name = "textBox47";
            this.textBox47.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.37000000476837158D), Telerik.Reporting.Drawing.Unit.Cm(0.37000000476837158D));
            this.textBox47.Style.Color = System.Drawing.Color.Gray;
            this.textBox47.Style.Font.Italic = true;
            this.textBox47.Style.Font.Name = "Calibri";
            this.textBox47.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox47.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox47.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox47.TextWrap = false;
            this.textBox47.Value = "= PageCount";
            // 
            // textBox45
            // 
            this.textBox45.CanShrink = true;
            this.textBox45.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.026558253914117813D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox45.Name = "textBox45";
            this.textBox45.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.72124993801116943D), Telerik.Reporting.Drawing.Unit.Cm(0.37000000476837158D));
            this.textBox45.Style.Color = System.Drawing.Color.Gray;
            this.textBox45.Style.Font.Italic = true;
            this.textBox45.Style.Font.Name = "Calibri";
            this.textBox45.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox45.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox45.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox45.TextWrap = false;
            this.textBox45.Value = "Sida";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(16.889999389648438D), Telerik.Reporting.Drawing.Unit.Cm(0.34354165196418762D));
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.559999942779541D), Telerik.Reporting.Drawing.Unit.Cm(0.63999998569488525D));
            this.pictureBoxLogo.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBoxLogo.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            // 
            // tbShapeRow1
            // 
            tbShapeRow1.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            tbShapeRow1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.49000000953674316D));
            tbShapeRow1.Name = "tbShapeRow1";
            tbShapeRow1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.3572964668273926D), Telerik.Reporting.Drawing.Unit.Cm(0.61635404825210571D));
            tbShapeRow1.Style.Color = System.Drawing.Color.White;
            tbShapeRow1.Style.Font.Bold = true;
            tbShapeRow1.Style.Font.Name = "Calibri";
            tbShapeRow1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16D);
            tbShapeRow1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            tbShapeRow1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            tbShapeRow1.Value = "=Fields.Week";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(4.762700080871582D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel5,
            this.graph1});
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.detail.Style.Font.Italic = true;
            this.detail.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.detail.Style.Visible = true;
            // 
            // panel5
            // 
            this.panel5.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel6,
            this.textBox4});
            this.panel5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.026558253914117813D), Telerik.Reporting.Drawing.Unit.Cm(0.19843749701976776D));
            this.panel5.Name = "panel5";
            this.panel5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(0.35718747973442078D));
            // 
            // panel6
            // 
            this.panel6.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.panel6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.22489582002162933D));
            this.panel6.Name = "panel6";
            this.panel6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(0.13229167461395264D));
            this.panel6.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.panel6.Style.BackgroundImage.MimeType = "";
            this.panel6.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.RepeatX;
            this.panel6.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel6.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.panel6.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            // 
            // textBox4
            // 
            this.textBox4.CanShrink = false;
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.627291202545166D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.textBox4.Multiline = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6799999475479126D), Telerik.Reporting.Drawing.Unit.Cm(0.34000000357627869D));
            this.textBox4.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox4.Style.Font.Italic = false;
            this.textBox4.Style.Font.Name = "Calibri";
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox4.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox4.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.TextWrap = false;
            this.textBox4.Value = "= M2M.DataCenter.Reports.StoppageAnalyzeWeekly.GetMachineName(ReportItem.DataObje" +
    "ct)";
            this.textBox4.ItemDataBound += new System.EventHandler(this.textBox4_ItemDataBound);
            // 
            // graph1
            // 
            graphGroup1.Groupings.Add(new Telerik.Reporting.Grouping("=Fields.Index"));
            graphGroup1.Label = "=Fields.WeekAsString";
            graphGroup1.Name = "categoryGroup1";
            this.graph1.CategoryGroups.Add(graphGroup1);
            colorPalette1.Colors.Add(System.Drawing.Color.DodgerBlue);
            this.graph1.ColorPalette = colorPalette1;
            this.graph1.CoordinateSystems.Add(this.cartesianCoordinateSystem1);
            this.graph1.Legend.Style.LineColor = System.Drawing.Color.LightGray;
            this.graph1.Legend.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.graph1.Legend.Style.Visible = false;
            this.graph1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.58228355646133423D));
            this.graph1.Name = "graph1";
            this.graph1.PlotAreaStyle.Font.Name = "Arial";
            this.graph1.PlotAreaStyle.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.graph1.PlotAreaStyle.LineColor = System.Drawing.Color.LightGray;
            this.graph1.PlotAreaStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.graph1.Series.Add(this.lineSeries1);
            this.graph1.Series.Add(this.lineSeries2);
            this.graph1.SeriesGroups.Add(graphGroup2);
            this.graph1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.599899291992188D), Telerik.Reporting.Drawing.Unit.Cm(4.1804156303405762D));
            this.graph1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.graph1.NeedDataSource += new System.EventHandler(this.graph1_NeedDataSource);
            // 
            // cartesianCoordinateSystem1
            // 
            this.cartesianCoordinateSystem1.Name = "cartesianCoordinateSystem1";
            this.cartesianCoordinateSystem1.Style.Font.Name = "Calibri";
            this.cartesianCoordinateSystem1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.cartesianCoordinateSystem1.XAxis = this.graphAxis5;
            this.cartesianCoordinateSystem1.YAxis = this.graphAxis6;
            // 
            // graphAxis5
            // 
            this.graphAxis5.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis5.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis5.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis5.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis5.MinorGridLineStyle.Visible = false;
            this.graphAxis5.Name = "GraphAxis1";
            this.graphAxis5.Scale = categoryScale1;
            // 
            // graphAxis6
            // 
            this.graphAxis6.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis6.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis6.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis6.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis6.MinorGridLineStyle.Visible = false;
            this.graphAxis6.Name = "GraphAxis2";
            this.graphAxis6.Scale = numericalScale1;
            // 
            // lineSeries1
            // 
            this.lineSeries1.CategoryGroup = graphGroup1;
            this.lineSeries1.CoordinateSystem = this.cartesianCoordinateSystem1;
            this.lineSeries1.DataPointLabel = "=Fields.WeightedNumberOfStops";
            this.lineSeries1.DataPointLabelFormat = "{0:N2}";
            this.lineSeries1.DataPointLabelStyle.Font.Name = "Calibri";
            this.lineSeries1.DataPointLabelStyle.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.lineSeries1.DataPointLabelStyle.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D);
            this.lineSeries1.DataPointStyle.Visible = false;
            this.lineSeries1.LegendItem.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.lineSeries1.LegendItem.Style.LineColor = System.Drawing.Color.Transparent;
            this.lineSeries1.LegendItem.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.lineSeries1.LineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.lineSeries1.MarkerMaxSize = Telerik.Reporting.Drawing.Unit.Pixel(50D);
            this.lineSeries1.MarkerMinSize = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.lineSeries1.MarkerSize = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            graphGroup2.Label = "=Fields.WeightedNumberOfStops";
            graphGroup2.Name = "seriesGroup1";
            this.lineSeries1.SeriesGroup = graphGroup2;
            this.lineSeries1.Size = null;
            this.lineSeries1.Y = "=Fields.WeightedNumberOfStops";
            // 
            // lineSeries2
            // 
            this.lineSeries2.CategoryGroup = graphGroup1;
            this.lineSeries2.CoordinateSystem = this.cartesianCoordinateSystem1;
            this.lineSeries2.DataPointStyle.Visible = false;
            this.lineSeries2.LegendItem.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.lineSeries2.LegendItem.Style.LineColor = System.Drawing.Color.Transparent;
            this.lineSeries2.LegendItem.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.lineSeries2.LineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.lineSeries2.LineStyle.Visible = false;
            this.lineSeries2.MarkerMaxSize = Telerik.Reporting.Drawing.Unit.Pixel(50D);
            this.lineSeries2.MarkerMinSize = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.lineSeries2.MarkerSize = Telerik.Reporting.Drawing.Unit.Pixel(5D);
            this.lineSeries2.SeriesGroup = graphGroup2;
            this.lineSeries2.Size = null;
            this.lineSeries2.Y = "=Fields.MaxValue";
            // 
            // graphAxis2
            // 
            this.graphAxis2.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis2.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis2.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis2.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis2.MinorGridLineStyle.Visible = false;
            this.graphAxis2.Name = "GraphAxis2";
            this.graphAxis2.Scale = numericalScale2;
            // 
            // tbHeader
            // 
            this.tbHeader.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.44979164004325867D), Telerik.Reporting.Drawing.Unit.Cm(0.59531247615814209D));
            this.tbHeader.Name = "tbHeader";
            this.tbHeader.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.9766650199890137D), Telerik.Reporting.Drawing.Unit.Cm(0.63219147920608521D));
            this.tbHeader.Style.Color = System.Drawing.Color.Black;
            this.tbHeader.Style.Font.Name = "Calibri";
            this.tbHeader.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.tbHeader.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbHeader.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbHeader.Style.Visible = true;
            this.tbHeader.StyleName = "Title";
            this.tbHeader.Value = "Analys stopporsaker";
            // 
            // tbDivisionPrompt
            // 
            this.tbDivisionPrompt.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.0836324691772461D), Telerik.Reporting.Drawing.Unit.Cm(0.10593342781066895D));
            this.tbDivisionPrompt.Name = "tbDivisionPrompt";
            this.tbDivisionPrompt.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8941673040390015D), Telerik.Reporting.Drawing.Unit.Cm(0.39416661858558655D));
            this.tbDivisionPrompt.Style.Color = System.Drawing.Color.Gray;
            this.tbDivisionPrompt.Style.Font.Italic = true;
            this.tbDivisionPrompt.Style.Font.Name = "Calibri";
            this.tbDivisionPrompt.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbDivisionPrompt.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbDivisionPrompt.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbDivisionPrompt.Style.Visible = true;
            this.tbDivisionPrompt.StyleName = "Title";
            this.tbDivisionPrompt.Value = "Avdelning/linje:";
            // 
            // tbDivisionName
            // 
            this.tbDivisionName.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.0309133529663086D), Telerik.Reporting.Drawing.Unit.Cm(0.10593342781066895D));
            this.tbDivisionName.Name = "tbDivisionName";
            this.tbDivisionName.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6642873287200928D), Telerik.Reporting.Drawing.Unit.Cm(0.39406669139862061D));
            this.tbDivisionName.Style.Color = System.Drawing.Color.Black;
            this.tbDivisionName.Style.Font.Name = "Calibri";
            this.tbDivisionName.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbDivisionName.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbDivisionName.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbDivisionName.Style.Visible = true;
            this.tbDivisionName.StyleName = "Title";
            this.tbDivisionName.Value = "= Fields.Division";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(2.6800000667572021D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panelLogo,
            this.panel4,
            this.tbDivisionPrompt,
            this.textBox1,
            this.tbCategory,
            this.tbStopReason,
            this.tbDivisionName,
            this.textBox3,
            this.textBox32,
            this.textBox100,
            this.tbComment,
            this.textBox5,
            this.textBox6});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            this.pageHeaderSection1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.pageHeaderSection1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.pageHeaderSection1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.pageHeaderSection1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            // 
            // panelLogo
            // 
            this.panelLogo.Docking = Telerik.Reporting.DockingStyle.Left;
            this.panelLogo.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.tbHeader,
            this.tbSubHeader});
            this.panelLogo.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.4264564514160156D), Telerik.Reporting.Drawing.Unit.Cm(2.6800000667572021D));
            this.panelLogo.Style.BackgroundImage.MimeType = "";
            this.panelLogo.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat;
            // 
            // tbSubHeader
            // 
            this.tbSubHeader.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.44979164004325867D), Telerik.Reporting.Drawing.Unit.Cm(1.2277039289474487D));
            this.tbSubHeader.Name = "tbSubHeader";
            this.tbSubHeader.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.9766650199890137D), Telerik.Reporting.Drawing.Unit.Cm(0.41831764578819275D));
            this.tbSubHeader.Style.Color = System.Drawing.Color.Gray;
            this.tbSubHeader.Style.Font.Italic = true;
            this.tbSubHeader.Style.Font.Name = "Calibri";
            this.tbSubHeader.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.tbSubHeader.Style.LineColor = System.Drawing.Color.Black;
            this.tbSubHeader.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbSubHeader.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbSubHeader.Style.Visible = true;
            this.tbSubHeader.StyleName = "Title";
            this.tbSubHeader.Value = "12 VECKOR";
            // 
            // panel4
            // 
            this.panel4.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.shape1,
            tbShapeRow1,
            this.tbShapeRow2});
            this.panel4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.663751602172852D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel4.Name = "panel4";
            this.panel4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.3599998950958252D), Telerik.Reporting.Drawing.Unit.Cm(2.6800000667572021D));
            this.panel4.Style.BackgroundImage.MimeType = "";
            this.panel4.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat;
            this.panel4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            // 
            // shape1
            // 
            this.shape1.Docking = Telerik.Reporting.DockingStyle.Top;
            this.shape1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.shape1.Name = "shape1";
            this.shape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.EllipseShape(0D);
            this.shape1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.3599998950958252D), Telerik.Reporting.Drawing.Unit.Cm(2.35788893699646D));
            this.shape1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(177)))), ((int)(((byte)(24)))));
            this.shape1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(177)))), ((int)(((byte)(24)))));
            this.shape1.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Cm(0D);
            // 
            // tbShapeRow2
            // 
            this.tbShapeRow2.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.tbShapeRow2.Format = "{0:yyyy}";
            this.tbShapeRow2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(1.1399999856948853D));
            this.tbShapeRow2.Name = "tbShapeRow2";
            this.tbShapeRow2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.357297420501709D), Telerik.Reporting.Drawing.Unit.Cm(0.61635404825210571D));
            this.tbShapeRow2.Style.Color = System.Drawing.Color.White;
            this.tbShapeRow2.Style.Font.Bold = true;
            this.tbShapeRow2.Style.Font.Name = "Calibri";
            this.tbShapeRow2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16D);
            this.tbShapeRow2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tbShapeRow2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbShapeRow2.Value = "= Fields.PeriodEnd";
            // 
            // textBox1
            // 
            this.textBox1.Anchoring = Telerik.Reporting.AnchoringStyles.Top;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.0836324691772461D), Telerik.Reporting.Drawing.Unit.Cm(0.50029993057250977D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8941673040390015D), Telerik.Reporting.Drawing.Unit.Cm(0.39416682720184326D));
            this.textBox1.Style.Color = System.Drawing.Color.Gray;
            this.textBox1.Style.Font.Italic = true;
            this.textBox1.Style.Font.Name = "Calibri";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Style.Visible = true;
            this.textBox1.StyleName = "Title";
            this.textBox1.Value = "Skift:";
            // 
            // tbCategory
            // 
            this.tbCategory.Anchoring = Telerik.Reporting.AnchoringStyles.Top;
            this.tbCategory.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.0836291313171387D), Telerik.Reporting.Drawing.Unit.Cm(0.90528851747512817D));
            this.tbCategory.Name = "tbCategory";
            this.tbCategory.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8941673040390015D), Telerik.Reporting.Drawing.Unit.Cm(0.39416682720184326D));
            this.tbCategory.Style.Color = System.Drawing.Color.Gray;
            this.tbCategory.Style.Font.Italic = true;
            this.tbCategory.Style.Font.Name = "Calibri";
            this.tbCategory.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbCategory.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbCategory.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbCategory.Style.Visible = true;
            this.tbCategory.StyleName = "Title";
            this.tbCategory.Value = "Kategori:";
            // 
            // tbStopReason
            // 
            this.tbStopReason.Anchoring = Telerik.Reporting.AnchoringStyles.Top;
            this.tbStopReason.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.0836324691772461D), Telerik.Reporting.Drawing.Unit.Cm(1.3022630214691162D));
            this.tbStopReason.Name = "tbStopReason";
            this.tbStopReason.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8941673040390015D), Telerik.Reporting.Drawing.Unit.Cm(0.3941670358181D));
            this.tbStopReason.Style.Color = System.Drawing.Color.Gray;
            this.tbStopReason.Style.Font.Italic = true;
            this.tbStopReason.Style.Font.Name = "Calibri";
            this.tbStopReason.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbStopReason.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbStopReason.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbStopReason.Style.Visible = true;
            this.tbStopReason.StyleName = "Title";
            this.tbStopReason.Value = "Stopporsak:";
            // 
            // textBox3
            // 
            this.textBox3.Format = "";
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.0309133529663086D), Telerik.Reporting.Drawing.Unit.Cm(0.50280845165252686D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6642873287200928D), Telerik.Reporting.Drawing.Unit.Cm(0.3941670358181D));
            this.textBox3.Style.Color = System.Drawing.Color.Black;
            this.textBox3.Style.Font.Name = "Calibri";
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Style.Visible = true;
            this.textBox3.StyleName = "Title";
            this.textBox3.Value = "= Fields.Shift";
            // 
            // textBox32
            // 
            this.textBox32.Angle = 0D;
            this.textBox32.Format = "";
            this.textBox32.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.0309133529663086D), Telerik.Reporting.Drawing.Unit.Cm(0.90789645910263062D));
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.351804256439209D), Telerik.Reporting.Drawing.Unit.Cm(0.3941670358181D));
            this.textBox32.Style.Color = System.Drawing.Color.Black;
            this.textBox32.Style.Font.Name = "Calibri";
            this.textBox32.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox32.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox32.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox32.Style.Visible = true;
            this.textBox32.StyleName = "";
            this.textBox32.Value = "= Fields.Category";
            // 
            // textBox100
            // 
            this.textBox100.Format = "";
            this.textBox100.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.0309162139892578D), Telerik.Reporting.Drawing.Unit.Cm(1.3022630214691162D));
            this.textBox100.Name = "textBox100";
            this.textBox100.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.2225303649902344D), Telerik.Reporting.Drawing.Unit.Cm(0.3941670358181D));
            this.textBox100.Style.Color = System.Drawing.Color.Black;
            this.textBox100.Style.Font.Name = "Calibri";
            this.textBox100.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox100.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox100.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox100.Style.Visible = true;
            this.textBox100.StyleName = "Title";
            this.textBox100.Value = "= Fields.StopReason";
            // 
            // tbComment
            // 
            this.tbComment.Anchoring = Telerik.Reporting.AnchoringStyles.Top;
            this.tbComment.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.707798957824707D), Telerik.Reporting.Drawing.Unit.Cm(2.2018470764160156D));
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.5456476211547852D), Telerik.Reporting.Drawing.Unit.Cm(0.3941670358181D));
            this.tbComment.Style.Color = System.Drawing.Color.Black;
            this.tbComment.Style.Font.Italic = false;
            this.tbComment.Style.Font.Name = "Calibri";
            this.tbComment.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbComment.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbComment.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbComment.Style.Visible = true;
            this.tbComment.StyleName = "Title";
            this.tbComment.Value = "Visar endast maskiner/stationer med stopp inom vald kategori/stopporsak";
            // 
            // textBox5
            // 
            this.textBox5.Anchoring = Telerik.Reporting.AnchoringStyles.Top;
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.0836291313171387D), Telerik.Reporting.Drawing.Unit.Cm(1.6966298818588257D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8941673040390015D), Telerik.Reporting.Drawing.Unit.Cm(0.3941670358181D));
            this.textBox5.Style.Color = System.Drawing.Color.Gray;
            this.textBox5.Style.Font.Italic = true;
            this.textBox5.Style.Font.Name = "Calibri";
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Style.Visible = true;
            this.textBox5.StyleName = "Title";
            this.textBox5.Value = "Visar:";
            // 
            // textBox6
            // 
            this.textBox6.Format = "";
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.0309162139892578D), Telerik.Reporting.Drawing.Unit.Cm(1.6966298818588257D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.2225303649902344D), Telerik.Reporting.Drawing.Unit.Cm(0.3941670358181D));
            this.textBox6.Style.Color = System.Drawing.Color.Black;
            this.textBox6.Style.Font.Name = "Calibri";
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Style.Visible = true;
            this.textBox6.StyleName = "Title";
            this.textBox6.Value = "=Fields.ShowType";
            // 
            // panel3
            // 
            this.panel3.Name = "panel3";
            this.panel3.Style.Font.Bold = true;
            this.panel3.Style.Font.Italic = false;
            this.panel3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.panel3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.panel3.Style.Visible = false;
            // 
            // textBox68
            // 
            this.textBox68.CanGrow = false;
            this.textBox68.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.23812499642372131D));
            this.textBox68.Name = "textBox68";
            this.textBox68.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.1999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.44999998807907104D));
            this.textBox68.Style.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.textBox68.Style.Color = System.Drawing.Color.White;
            this.textBox68.Style.Font.Bold = false;
            this.textBox68.Style.Font.Italic = false;
            this.textBox68.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox68.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox68.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox68.Style.Visible = true;
            this.textBox68.TextWrap = false;
            this.textBox68.Value = "Unit 2";
            // 
            // table2
            // 
            this.table2.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(0D)));
            this.table2.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(0D)));
            this.table2.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(0D)));
            this.table2.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(0D)));
            this.table2.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(0D)));
            this.table2.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(0D)));
            this.table2.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(0D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0D)));
            this.table2.Body.SetCellContent(0, 0, this.textBox69);
            this.table2.Body.SetCellContent(0, 3, this.textBox70);
            this.table2.Body.SetCellContent(0, 4, this.textBox71);
            this.table2.Body.SetCellContent(1, 0, this.textBox72);
            this.table2.Body.SetCellContent(1, 3, this.textBox73);
            this.table2.Body.SetCellContent(1, 4, this.textBox74);
            this.table2.Body.SetCellContent(0, 5, this.textBox75);
            this.table2.Body.SetCellContent(1, 5, this.textBox78);
            this.table2.Body.SetCellContent(0, 6, this.textBox79);
            this.table2.Body.SetCellContent(1, 6, this.textBox80);
            this.table2.Body.SetCellContent(0, 2, this.textBox81);
            this.table2.Body.SetCellContent(1, 2, this.textBox82);
            this.table2.Body.SetCellContent(0, 1, this.textBox83);
            this.table2.Body.SetCellContent(1, 1, this.textBox84);
            tableGroup2.Name = "Group4";
            tableGroup3.Name = "Group3";
            tableGroup6.Name = "Group1";
            tableGroup7.Name = "Group2";
            this.table2.ColumnGroups.Add(tableGroup1);
            this.table2.ColumnGroups.Add(tableGroup2);
            this.table2.ColumnGroups.Add(tableGroup3);
            this.table2.ColumnGroups.Add(tableGroup4);
            this.table2.ColumnGroups.Add(tableGroup5);
            this.table2.ColumnGroups.Add(tableGroup6);
            this.table2.ColumnGroups.Add(tableGroup7);
            this.table2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox69,
            this.textBox70,
            this.textBox71,
            this.textBox72,
            this.textBox73,
            this.textBox74,
            this.textBox75,
            this.textBox78,
            this.textBox79,
            this.textBox80,
            this.textBox81,
            this.textBox82,
            this.textBox83,
            this.textBox84});
            this.table2.KeepTogether = false;
            this.table2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.68832522630691528D));
            this.table2.Name = "table2Stops";
            this.table2.RowGroups.Add(tableGroup8);
            this.table2.Style.BackgroundColor = System.Drawing.SystemColors.Control;
            this.table2.Style.Visible = true;
            // 
            // textBox69
            // 
            this.textBox69.Name = "textBox69";
            this.textBox69.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            // 
            // textBox70
            // 
            this.textBox70.Name = "textBox70";
            this.textBox70.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox70.Style.Font.Bold = true;
            this.textBox70.Style.Font.Italic = false;
            this.textBox70.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox70.Value = "Tidsåtgång totalt";
            // 
            // textBox71
            // 
            this.textBox71.Name = "textBox71";
            this.textBox71.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox71.Style.Font.Bold = true;
            this.textBox71.Style.Font.Italic = false;
            this.textBox71.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox71.Value = "Antal";
            // 
            // textBox72
            // 
            this.textBox72.Name = "textBox72";
            this.textBox72.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox72.Style.Font.Bold = true;
            this.textBox72.Style.Font.Italic = false;
            this.textBox72.Style.Font.Name = "Arial";
            this.textBox72.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox72.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox72.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox72.Value = "=Fields.ReasonAbbrForList";
            // 
            // textBox73
            // 
            this.textBox73.Format = "{0:N1} tim";
            this.textBox73.Name = "textBox73";
            this.textBox73.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox73.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox73.Value = "=Fields.ElapsedTimeInHours";
            // 
            // textBox74
            // 
            this.textBox74.Format = "{0:N0}";
            this.textBox74.Name = "textBox74";
            this.textBox74.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox74.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox74.Value = "=Fields.NumberOfStops";
            // 
            // textBox75
            // 
            this.textBox75.Name = "textBox75";
            this.textBox75.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox75.Style.Font.Bold = true;
            this.textBox75.Style.Font.Italic = false;
            this.textBox75.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox75.Value = "Tidsåtgång snittvärde";
            // 
            // textBox78
            // 
            this.textBox78.Format = "{0:N1} min";
            this.textBox78.Name = "textBox78";
            this.textBox78.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox78.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox78.StyleName = "";
            this.textBox78.Value = "=Fields.AverageTimeInMinutes";
            // 
            // textBox79
            // 
            this.textBox79.Name = "textBox79";
            this.textBox79.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox79.Style.Font.Bold = true;
            this.textBox79.Style.Font.Italic = false;
            this.textBox79.Style.Font.Name = "Arial";
            this.textBox79.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox79.Value = "Andel av total reg. stopptid";
            // 
            // textBox80
            // 
            this.textBox80.Format = "{0:P1}";
            this.textBox80.Name = "textBox80";
            this.textBox80.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox80.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox80.Value = "=Fields.TimePart";
            // 
            // textBox81
            // 
            this.textBox81.Name = "textBox81";
            this.textBox81.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox81.Style.Font.Bold = true;
            this.textBox81.Style.Font.Italic = false;
            this.textBox81.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox81.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox81.StyleName = "";
            this.textBox81.Value = "Kategori";
            // 
            // textBox82
            // 
            this.textBox82.Name = "textBox82";
            this.textBox82.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox82.Style.Font.Bold = false;
            this.textBox82.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox82.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox82.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox82.StyleName = "";
            this.textBox82.Value = "=Fields.Category";
            // 
            // textBox83
            // 
            this.textBox83.Name = "textBox83";
            this.textBox83.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox83.Style.Font.Bold = true;
            this.textBox83.Style.Font.Italic = false;
            this.textBox83.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox83.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox83.StyleName = "";
            // 
            // textBox84
            // 
            this.textBox84.Name = "textBox84";
            this.textBox84.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox84.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox84.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox84.StyleName = "";
            this.textBox84.Value = "=Fields.Machine";
            // 
            // graphAxis1
            // 
            this.graphAxis1.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis1.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis1.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis1.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis1.MinorGridLineStyle.Visible = false;
            this.graphAxis1.Name = "GraphAxis1";
            this.graphAxis1.Scale = categoryScale2;
            // 
            // graphAxis3
            // 
            this.graphAxis3.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis3.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis3.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis3.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis3.MinorGridLineStyle.Visible = false;
            this.graphAxis3.Name = "GraphAxis1";
            this.graphAxis3.Scale = categoryScale3;
            // 
            // graphAxis4
            // 
            this.graphAxis4.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis4.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis4.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis4.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis4.MinorGridLineStyle.Visible = false;
            this.graphAxis4.Name = "GraphAxis3";
            this.graphAxis4.Scale = numericalScale3;
            // 
            // StoppageAnalyzeWeekly
            // 
            this.DocumentName = "= M2M.DataCenter.Reports.StoppageAnalyzeWeekly.GetDocumentName(Parameters.Divisio" +
    "nId.Value, Parameters.Category.Value, Parameters.StopReason.Value ,Parameters.Ye" +
    "ar.Value,Parameters.Week.Value)";
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageHeaderSection1,
            pageFooterSection1});
            this.Name = "StoppageAnalyzeWeekly";
            this.PageSettings.ColumnCount = 1;
            this.PageSettings.ColumnSpacing = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Cm(1.6000000238418579D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "DivisionId";
            reportParameter1.Text = "Avdelning/linje";
            reportParameter2.Name = "ShiftType";
            reportParameter2.Text = "Skift";
            reportParameter2.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter3.Name = "Year";
            reportParameter3.Text = "År";
            reportParameter3.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter4.Name = "Category";
            reportParameter4.Text = "Kategori";
            reportParameter4.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter5.Name = "Week";
            reportParameter5.Text = "T o m vecka";
            reportParameter5.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter6.AllowNull = true;
            reportParameter6.Name = "StopReason";
            reportParameter6.Text = "Stopporsak";
            reportParameter7.Name = "ShowType";
            reportParameter7.Text = "Visa";
            reportParameter7.Type = Telerik.Reporting.ReportParameterType.Integer;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
            this.ReportParameters.Add(reportParameter5);
            this.ReportParameters.Add(reportParameter6);
            this.ReportParameters.Add(reportParameter7);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.Font.Name = "Calibri";
            this.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Cm;
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(18.626560211181641D);
            this.NeedDataSource += new System.EventHandler(this.Report_NeedDataSource);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DetailSection detail;
        private Telerik.Reporting.TextBox textBox44;
        private Telerik.Reporting.TextBox tbHeader;
        private Telerik.Reporting.TextBox tbDivisionPrompt;
        private Telerik.Reporting.TextBox tbDivisionName;
        private PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox45;
        private Telerik.Reporting.TextBox textBox46;
        private Telerik.Reporting.TextBox textBox47;
        private Telerik.Reporting.Panel panelLogo;
        private Telerik.Reporting.Panel panel4;
        private Telerik.Reporting.TextBox textBox50;
        private Telerik.Reporting.Panel panel3;
        private Telerik.Reporting.TextBox textBox68;
        private Table table2;
        private Telerik.Reporting.TextBox textBox69;
        private Telerik.Reporting.TextBox textBox70;
        private Telerik.Reporting.TextBox textBox71;
        private Telerik.Reporting.TextBox textBox72;
        private Telerik.Reporting.TextBox textBox73;
        private Telerik.Reporting.TextBox textBox74;
        private Telerik.Reporting.TextBox textBox75;
        private Telerik.Reporting.TextBox textBox78;
        private Telerik.Reporting.TextBox textBox79;
        private Telerik.Reporting.TextBox textBox80;
        private Telerik.Reporting.TextBox textBox81;
        private Telerik.Reporting.TextBox textBox82;
        private Telerik.Reporting.TextBox textBox83;
        private Telerik.Reporting.TextBox textBox84;
        private Telerik.Reporting.PictureBox pictureBoxLogo;
        private Telerik.Reporting.TextBox tbSubHeader;
        private Telerik.Reporting.TextBox textBox32;
        private Telerik.Reporting.TextBox tbCategory;
        private Telerik.Reporting.TextBox textBox100;
        private Telerik.Reporting.TextBox tbStopReason;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox tbShapeRow2;
        private Shape shape1;
        private Telerik.Reporting.Panel panel5;
        private Telerik.Reporting.Panel panel6;
        private Telerik.Reporting.TextBox textBox4;
        private Graph graph1;
        private GraphAxis graphAxis2;
        private GraphAxis graphAxis1;
        private GraphAxis graphAxis3;
        private GraphAxis graphAxis4;
        private CartesianCoordinateSystem cartesianCoordinateSystem1;
        private GraphAxis graphAxis5;
        private GraphAxis graphAxis6;
        private LineSeries lineSeries1;
        private Telerik.Reporting.TextBox tbComment;
        private LineSeries lineSeries2;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
    }
}