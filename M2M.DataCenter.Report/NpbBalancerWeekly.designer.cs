namespace M2M.DataCenter.Reports
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class NpbBalancerWeekly
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.PageFooterSection pageFooterSection1;
            Telerik.Reporting.Panel panelRow2;
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins1 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartPaddings chartPaddings1 = new Telerik.Reporting.Charting.Styles.ChartPaddings();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins2 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Palette palette1 = new Telerik.Reporting.Charting.Palette();
            Telerik.Reporting.Charting.PaletteItem paletteItem1 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem2 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem3 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem4 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem5 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem6 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins3 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins4 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartSeries chartSeries1 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins5 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartPaddings chartPaddings2 = new Telerik.Reporting.Charting.Styles.ChartPaddings();
            Telerik.Reporting.Charting.Palette palette2 = new Telerik.Reporting.Charting.Palette();
            Telerik.Reporting.Charting.PaletteItem paletteItem7 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem8 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem9 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem10 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem11 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem12 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins6 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins7 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartSeries chartSeries2 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Panel panelRow4;
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins8 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartPaddings chartPaddings3 = new Telerik.Reporting.Charting.Styles.ChartPaddings();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins9 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Palette palette3 = new Telerik.Reporting.Charting.Palette();
            Telerik.Reporting.Charting.PaletteItem paletteItem13 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem14 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem15 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem16 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem17 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem18 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins10 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins11 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartSeries chartSeries3 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins12 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartPaddings chartPaddings4 = new Telerik.Reporting.Charting.Styles.ChartPaddings();
            Telerik.Reporting.Charting.Palette palette4 = new Telerik.Reporting.Charting.Palette();
            Telerik.Reporting.Charting.PaletteItem paletteItem19 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem20 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem21 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem22 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem23 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem24 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins13 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins14 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartSeries chartSeries4 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Panel panelRow3;
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins15 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartPaddings chartPaddings5 = new Telerik.Reporting.Charting.Styles.ChartPaddings();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins16 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Palette palette5 = new Telerik.Reporting.Charting.Palette();
            Telerik.Reporting.Charting.PaletteItem paletteItem25 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem26 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem27 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem28 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem29 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem30 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins17 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins18 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartSeries chartSeries5 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins19 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartPaddings chartPaddings6 = new Telerik.Reporting.Charting.Styles.ChartPaddings();
            Telerik.Reporting.Charting.Palette palette6 = new Telerik.Reporting.Charting.Palette();
            Telerik.Reporting.Charting.PaletteItem paletteItem31 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem32 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem33 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem34 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem35 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem36 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins20 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins21 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartSeries chartSeries6 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Panel panelRow5;
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins22 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartPaddings chartPaddings7 = new Telerik.Reporting.Charting.Styles.ChartPaddings();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins23 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Palette palette7 = new Telerik.Reporting.Charting.Palette();
            Telerik.Reporting.Charting.PaletteItem paletteItem37 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem38 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem39 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem40 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem41 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem42 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins24 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins25 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartSeries chartSeries7 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins26 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartPaddings chartPaddings8 = new Telerik.Reporting.Charting.Styles.ChartPaddings();
            Telerik.Reporting.Charting.Palette palette8 = new Telerik.Reporting.Charting.Palette();
            Telerik.Reporting.Charting.PaletteItem paletteItem43 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem44 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem45 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem46 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem47 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem48 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins27 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins28 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartSeries chartSeries8 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup3 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup4 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup5 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup6 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup7 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup8 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup9 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup10 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup11 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins29 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartPaddings chartPaddings9 = new Telerik.Reporting.Charting.Styles.ChartPaddings();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins30 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Palette palette9 = new Telerik.Reporting.Charting.Palette();
            Telerik.Reporting.Charting.PaletteItem paletteItem49 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem50 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem51 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem52 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem53 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem54 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins31 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins32 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartSeries chartSeries9 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins33 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartPaddings chartPaddings10 = new Telerik.Reporting.Charting.Styles.ChartPaddings();
            Telerik.Reporting.Charting.Palette palette10 = new Telerik.Reporting.Charting.Palette();
            Telerik.Reporting.Charting.PaletteItem paletteItem55 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem56 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem57 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem58 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem59 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem60 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins34 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins35 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartSeries chartSeries10 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.textBox44 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox45 = new Telerik.Reporting.TextBox();
            this.textBox46 = new Telerik.Reporting.TextBox();
            this.textBox47 = new Telerik.Reporting.TextBox();
            this.textBox50 = new Telerik.Reporting.TextBox();
            this.chart1 = new Telerik.Reporting.Chart();
            this.chart2 = new Telerik.Reporting.Chart();
            this.chart5 = new Telerik.Reporting.Chart();
            this.chart6 = new Telerik.Reporting.Chart();
            this.chart3 = new Telerik.Reporting.Chart();
            this.chart4 = new Telerik.Reporting.Chart();
            this.chart7 = new Telerik.Reporting.Chart();
            this.chart8 = new Telerik.Reporting.Chart();
            this.detail = new Telerik.Reporting.DetailSection();
            this.tableMachines = new Telerik.Reporting.Table();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.textBox22 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.panelRow1 = new Telerik.Reporting.Panel();
            this.chartStopCount = new Telerik.Reporting.Chart();
            this.chartStopTime = new Telerik.Reporting.Chart();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.tbHeader = new Telerik.Reporting.TextBox();
            this.tbDivisionPrompt = new Telerik.Reporting.TextBox();
            this.tbDatePrompt = new Telerik.Reporting.TextBox();
            this.tbDivisionName = new Telerik.Reporting.TextBox();
            this.tbDate = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.panel2 = new Telerik.Reporting.Panel();
            this.panel4 = new Telerik.Reporting.Panel();
            pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            panelRow2 = new Telerik.Reporting.Panel();
            panelRow4 = new Telerik.Reporting.Panel();
            panelRow3 = new Telerik.Reporting.Panel();
            panelRow5 = new Telerik.Reporting.Panel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageFooterSection1
            // 
            pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.8147919774055481D);
            pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox44,
            this.textBox2,
            this.textBox45,
            this.textBox46,
            this.textBox47,
            this.textBox50});
            pageFooterSection1.Name = "pageFooterSection1";
            pageFooterSection1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            pageFooterSection1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            pageFooterSection1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(2D);
            // 
            // textBox44
            // 
            this.textBox44.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.399999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.31479167938232422D));
            this.textBox44.Name = "textBox44";
            this.textBox44.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.1973986625671387D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox44.Style.BackgroundColor = System.Drawing.Color.Black;
            this.textBox44.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat;
            this.textBox44.Style.Color = System.Drawing.Color.White;
            this.textBox44.Style.Font.Bold = false;
            this.textBox44.Style.Font.Name = "Arial";
            this.textBox44.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox44.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox44.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox44.StyleName = "Title";
            this.textBox44.Value = "Genererad av M2M DataCenter";
            // 
            // textBox2
            // 
            this.textBox2.CanShrink = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.7264583110809326D), Telerik.Reporting.Drawing.Unit.Cm(0.31479167938232422D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.37041667103767395D), Telerik.Reporting.Drawing.Unit.Cm(0.42052504420280457D));
            this.textBox2.Style.Font.Italic = true;
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBox2.TextWrap = false;
            this.textBox2.Value = "= PageNumber";
            // 
            // textBox45
            // 
            this.textBox45.CanShrink = true;
            this.textBox45.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.81999999284744263D), Telerik.Reporting.Drawing.Unit.Cm(0.31479167938232422D));
            this.textBox45.Name = "textBox45";
            this.textBox45.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.88249337673187256D), Telerik.Reporting.Drawing.Unit.Cm(0.42052504420280457D));
            this.textBox45.Style.Font.Italic = true;
            this.textBox45.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox45.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBox45.TextWrap = false;
            this.textBox45.Value = "Sida";
            // 
            // textBox46
            // 
            this.textBox46.CanShrink = true;
            this.textBox46.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.1229166984558105D), Telerik.Reporting.Drawing.Unit.Cm(0.31479167938232422D));
            this.textBox46.Name = "textBox46";
            this.textBox46.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.47624999284744263D), Telerik.Reporting.Drawing.Unit.Cm(0.42052504420280457D));
            this.textBox46.Style.Font.Italic = true;
            this.textBox46.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox46.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox46.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBox46.TextWrap = false;
            this.textBox46.Value = "av";
            // 
            // textBox47
            // 
            this.textBox47.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.6029164791107178D), Telerik.Reporting.Drawing.Unit.Cm(0.31479167938232422D));
            this.textBox47.Name = "textBox47";
            this.textBox47.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.58208334445953369D), Telerik.Reporting.Drawing.Unit.Cm(0.42052504420280457D));
            this.textBox47.Style.Font.Italic = true;
            this.textBox47.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox47.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox47.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBox47.TextWrap = false;
            this.textBox47.Value = "= PageCount";
            // 
            // textBox50
            // 
            this.textBox50.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.2387499809265137D), Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D));
            this.textBox50.Name = "textBox50";
            this.textBox50.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.6410412788391113D), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526D));
            this.textBox50.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox50.Value = "Copyright© 2009, M2M Solutions AB";
            // 
            // panelRow2
            // 
            panelRow2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.chart1,
            this.chart2});
            panelRow2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(5.6204094886779785D));
            panelRow2.Name = "panelRow2";
            panelRow2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(3.8502085208892822D));
            panelRow2.Style.BackgroundColor = System.Drawing.Color.White;
            panelRow2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            panelRow2.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            panelRow2.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            panelRow2.Style.Visible = false;
            // 
            // chart1
            // 
            this.chart1.Appearance.Border.Visible = false;
            this.chart1.Appearance.Border.Width = 5F;
            this.chart1.Appearance.Dimensions.AutoSize = false;
            this.chart1.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(145D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins1.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins1.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins1.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins1.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart1.Appearance.Dimensions.Margins = chartMargins1;
            chartPaddings1.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings1.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings1.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings1.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart1.Appearance.Dimensions.Paddings = chartPaddings1;
            this.chart1.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(351D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart1.Appearance.FillStyle.MainColor = System.Drawing.SystemColors.ControlLightLight;
            this.chart1.BitmapResolution = 192F;
            chartMargins2.Bottom = new Telerik.Reporting.Charting.Styles.Unit(14D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins2.Left = new Telerik.Reporting.Charting.Styles.Unit(2D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins2.Right = new Telerik.Reporting.Charting.Styles.Unit(10D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins2.Top = new Telerik.Reporting.Charting.Styles.Unit(4D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            this.chart1.ChartTitle.Appearance.Dimensions.Margins = chartMargins2;
            this.chart1.ChartTitle.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chart1.ChartTitle.TextBlock.Appearance.Position.Auto = false;
            this.chart1.ChartTitle.TextBlock.Appearance.Position.X = 0F;
            this.chart1.ChartTitle.TextBlock.Appearance.Position.Y = 0F;
            this.chart1.ChartTitle.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart1.ChartTitle.TextBlock.Text = "Packstation 2";
            paletteItem1.MainColor = System.Drawing.Color.Red;
            paletteItem1.Name = "PaletteItem 6";
            paletteItem1.SecondColor = System.Drawing.Color.DarkOrange;
            paletteItem2.MainColor = System.Drawing.Color.Blue;
            paletteItem2.Name = "PaletteItem 1";
            paletteItem2.SecondColor = System.Drawing.Color.LightSkyBlue;
            paletteItem3.MainColor = System.Drawing.Color.Green;
            paletteItem3.Name = "PaletteItem 2";
            paletteItem3.SecondColor = System.Drawing.Color.GreenYellow;
            paletteItem4.MainColor = System.Drawing.Color.DarkGoldenrod;
            paletteItem4.Name = "PaletteItem 3";
            paletteItem4.SecondColor = System.Drawing.Color.Gold;
            paletteItem5.MainColor = System.Drawing.Color.DarkGray;
            paletteItem5.Name = "PaletteItem 4";
            paletteItem5.SecondColor = System.Drawing.Color.White;
            paletteItem6.MainColor = System.Drawing.Color.Pink;
            paletteItem6.Name = "PaletteItem 5";
            paletteItem6.SecondColor = System.Drawing.Color.PeachPuff;
            palette1.Items.AddRange(new Telerik.Reporting.Charting.PaletteItem[] {
            paletteItem1,
            paletteItem2,
            paletteItem3,
            paletteItem4,
            paletteItem5,
            paletteItem6});
            palette1.Name = "Palette1";
            this.chart1.CustomPalettes.AddRange(new Telerik.Reporting.Charting.Palette[] {
            palette1});
            this.chart1.DefaultType = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chart1.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chart1.IntelligentLabelsEnabled = true;
            chartMargins3.Right = new Telerik.Reporting.Charting.Styles.Unit(2D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart1.Legend.Appearance.Dimensions.Margins = chartMargins3;
            this.chart1.Legend.Appearance.ItemTextAppearance.TextProperties.Font = new System.Drawing.Font("Verdana", 6.4F);
            this.chart1.Legend.TextBlock.Appearance.Dimensions.AutoSize = false;
            this.chart1.Legend.TextBlock.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart1.Legend.TextBlock.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart1.Legend.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6F);
            this.chart1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.chart1.Name = "chart1";
            this.chart1.PlotArea.Appearance.Border.Visible = false;
            chartMargins4.Right = new Telerik.Reporting.Charting.Styles.Unit(160D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart1.PlotArea.Appearance.Dimensions.Margins = chartMargins4;
            this.chart1.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chart1.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chart1.PlotArea.Appearance.SeriesPalette = "Palette1";
            this.chart1.PlotArea.EmptySeriesMessage.TextBlock.Visible = false;
            this.chart1.PlotArea.XAxis.MinValue = 1D;
            chartSeries1.Appearance.CenterXOffset = -30;
            chartSeries1.Appearance.CenterYOffset = 10;
            chartSeries1.Appearance.DiameterScale = 0.8D;
            chartSeries1.Appearance.LegendDisplayMode = Telerik.Reporting.Charting.ChartSeriesLegendDisplayMode.ItemLabels;
            chartSeries1.Appearance.ShowLabels = false;
            chartSeries1.DataLabelsColumn = "ReasonWithMachinePrefix";
            chartSeries1.DataYColumn = "NumberOfStops";
            chartSeries1.DefaultLabelValue = "";
            chartSeries1.Name = "Series 1";
            chartSeries1.Type = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chart1.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries1});
            this.chart1.SeriesPalette = "Palette1";
            this.chart1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(3.8502085208892822D));
            this.chart1.Style.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.chart1.Style.Visible = true;
            this.chart1.NeedDataSource += new System.EventHandler(this.chart2StopCount_NeedDataSource);
            // 
            // chart2
            // 
            this.chart2.Appearance.Border.Visible = false;
            this.chart2.Appearance.Border.Width = 5F;
            this.chart2.Appearance.Dimensions.AutoSize = false;
            this.chart2.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(145D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins5.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins5.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins5.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins5.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart2.Appearance.Dimensions.Margins = chartMargins5;
            chartPaddings2.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings2.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings2.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings2.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart2.Appearance.Dimensions.Paddings = chartPaddings2;
            this.chart2.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(351D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart2.Appearance.FillStyle.MainColor = System.Drawing.SystemColors.ControlLightLight;
            this.chart2.BitmapResolution = 192F;
            this.chart2.ChartTitle.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chart2.ChartTitle.Appearance.Visible = false;
            this.chart2.ChartTitle.TextBlock.Appearance.Position.Auto = false;
            this.chart2.ChartTitle.TextBlock.Appearance.Position.X = 0F;
            this.chart2.ChartTitle.TextBlock.Appearance.Position.Y = 0F;
            this.chart2.ChartTitle.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart2.ChartTitle.TextBlock.Text = "Maskin 2";
            this.chart2.ChartTitle.Visible = false;
            paletteItem7.MainColor = System.Drawing.Color.Red;
            paletteItem7.Name = "PaletteItem 6";
            paletteItem7.SecondColor = System.Drawing.Color.DarkOrange;
            paletteItem8.MainColor = System.Drawing.Color.Blue;
            paletteItem8.Name = "PaletteItem 1";
            paletteItem8.SecondColor = System.Drawing.Color.LightSkyBlue;
            paletteItem9.MainColor = System.Drawing.Color.Green;
            paletteItem9.Name = "PaletteItem 2";
            paletteItem9.SecondColor = System.Drawing.Color.GreenYellow;
            paletteItem10.MainColor = System.Drawing.Color.DarkGoldenrod;
            paletteItem10.Name = "PaletteItem 3";
            paletteItem10.SecondColor = System.Drawing.Color.Gold;
            paletteItem11.MainColor = System.Drawing.Color.DarkGray;
            paletteItem11.Name = "PaletteItem 4";
            paletteItem11.SecondColor = System.Drawing.Color.White;
            paletteItem12.MainColor = System.Drawing.Color.Pink;
            paletteItem12.Name = "PaletteItem 5";
            paletteItem12.SecondColor = System.Drawing.Color.PeachPuff;
            palette2.Items.AddRange(new Telerik.Reporting.Charting.PaletteItem[] {
            paletteItem7,
            paletteItem8,
            paletteItem9,
            paletteItem10,
            paletteItem11,
            paletteItem12});
            palette2.Name = "Palette1";
            this.chart2.CustomPalettes.AddRange(new Telerik.Reporting.Charting.Palette[] {
            palette2});
            this.chart2.DefaultType = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chart2.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chart2.IntelligentLabelsEnabled = true;
            chartMargins6.Right = new Telerik.Reporting.Charting.Styles.Unit(2D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart2.Legend.Appearance.Dimensions.Margins = chartMargins6;
            this.chart2.Legend.Appearance.ItemTextAppearance.TextProperties.Font = new System.Drawing.Font("Verdana", 6.4F);
            this.chart2.Legend.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6F);
            this.chart2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.chart2.Name = "chart2";
            this.chart2.PlotArea.Appearance.Border.Visible = false;
            chartMargins7.Right = new Telerik.Reporting.Charting.Styles.Unit(160D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart2.PlotArea.Appearance.Dimensions.Margins = chartMargins7;
            this.chart2.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chart2.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chart2.PlotArea.Appearance.SeriesPalette = "Palette1";
            this.chart2.PlotArea.EmptySeriesMessage.TextBlock.Visible = false;
            this.chart2.PlotArea.XAxis.MinValue = 1D;
            chartSeries2.Appearance.CenterXOffset = -30;
            chartSeries2.Appearance.CenterYOffset = 10;
            chartSeries2.Appearance.DiameterScale = 0.8D;
            chartSeries2.Appearance.LegendDisplayMode = Telerik.Reporting.Charting.ChartSeriesLegendDisplayMode.ItemLabels;
            chartSeries2.Appearance.ShowLabels = false;
            chartSeries2.DataLabelsColumn = "ReasonWithMachinePrefix";
            chartSeries2.DataYColumn = "ElapsedTimeInSeconds";
            chartSeries2.Name = "Series 1";
            chartSeries2.Type = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chart2.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries2});
            this.chart2.SeriesPalette = "Palette1";
            this.chart2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(3.8502085208892822D));
            this.chart2.Style.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.chart2.NeedDataSource += new System.EventHandler(this.chart2StopTime_NeedDataSource);
            // 
            // panelRow4
            // 
            panelRow4.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.chart5,
            this.chart6});
            panelRow4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(13.321227073669434D));
            panelRow4.Name = "panelRow4";
            panelRow4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(3.8502085208892822D));
            panelRow4.Style.BackgroundColor = System.Drawing.Color.White;
            panelRow4.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            panelRow4.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            panelRow4.Style.Visible = false;
            // 
            // chart5
            // 
            this.chart5.Appearance.Border.Visible = false;
            this.chart5.Appearance.Border.Width = 5F;
            this.chart5.Appearance.Dimensions.AutoSize = false;
            this.chart5.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(145D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins8.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins8.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins8.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins8.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart5.Appearance.Dimensions.Margins = chartMargins8;
            chartPaddings3.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings3.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings3.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings3.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart5.Appearance.Dimensions.Paddings = chartPaddings3;
            this.chart5.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(351D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart5.Appearance.FillStyle.MainColor = System.Drawing.SystemColors.ControlLightLight;
            this.chart5.BitmapResolution = 192F;
            chartMargins9.Bottom = new Telerik.Reporting.Charting.Styles.Unit(14D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins9.Left = new Telerik.Reporting.Charting.Styles.Unit(2D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins9.Right = new Telerik.Reporting.Charting.Styles.Unit(10D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins9.Top = new Telerik.Reporting.Charting.Styles.Unit(4D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            this.chart5.ChartTitle.Appearance.Dimensions.Margins = chartMargins9;
            this.chart5.ChartTitle.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chart5.ChartTitle.TextBlock.Appearance.Position.Auto = false;
            this.chart5.ChartTitle.TextBlock.Appearance.Position.X = 0F;
            this.chart5.ChartTitle.TextBlock.Appearance.Position.Y = 0F;
            this.chart5.ChartTitle.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart5.ChartTitle.TextBlock.Text = "Packstation 4";
            paletteItem13.MainColor = System.Drawing.Color.Red;
            paletteItem13.Name = "PaletteItem 6";
            paletteItem13.SecondColor = System.Drawing.Color.DarkOrange;
            paletteItem14.MainColor = System.Drawing.Color.Blue;
            paletteItem14.Name = "PaletteItem 1";
            paletteItem14.SecondColor = System.Drawing.Color.LightSkyBlue;
            paletteItem15.MainColor = System.Drawing.Color.Green;
            paletteItem15.Name = "PaletteItem 2";
            paletteItem15.SecondColor = System.Drawing.Color.GreenYellow;
            paletteItem16.MainColor = System.Drawing.Color.DarkGoldenrod;
            paletteItem16.Name = "PaletteItem 3";
            paletteItem16.SecondColor = System.Drawing.Color.Gold;
            paletteItem17.MainColor = System.Drawing.Color.DarkGray;
            paletteItem17.Name = "PaletteItem 4";
            paletteItem17.SecondColor = System.Drawing.Color.White;
            paletteItem18.MainColor = System.Drawing.Color.Pink;
            paletteItem18.Name = "PaletteItem 5";
            paletteItem18.SecondColor = System.Drawing.Color.PeachPuff;
            palette3.Items.AddRange(new Telerik.Reporting.Charting.PaletteItem[] {
            paletteItem13,
            paletteItem14,
            paletteItem15,
            paletteItem16,
            paletteItem17,
            paletteItem18});
            palette3.Name = "Palette1";
            this.chart5.CustomPalettes.AddRange(new Telerik.Reporting.Charting.Palette[] {
            palette3});
            this.chart5.DefaultType = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chart5.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chart5.IntelligentLabelsEnabled = true;
            chartMargins10.Right = new Telerik.Reporting.Charting.Styles.Unit(2D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart5.Legend.Appearance.Dimensions.Margins = chartMargins10;
            this.chart5.Legend.Appearance.ItemTextAppearance.TextProperties.Font = new System.Drawing.Font("Verdana", 6.4F);
            this.chart5.Legend.TextBlock.Appearance.Dimensions.AutoSize = false;
            this.chart5.Legend.TextBlock.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart5.Legend.TextBlock.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart5.Legend.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6F);
            this.chart5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.chart5.Name = "chart5";
            this.chart5.PlotArea.Appearance.Border.Visible = false;
            chartMargins11.Right = new Telerik.Reporting.Charting.Styles.Unit(160D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart5.PlotArea.Appearance.Dimensions.Margins = chartMargins11;
            this.chart5.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chart5.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chart5.PlotArea.Appearance.SeriesPalette = "Palette1";
            this.chart5.PlotArea.EmptySeriesMessage.TextBlock.Visible = false;
            this.chart5.PlotArea.XAxis.MinValue = 1D;
            chartSeries3.Appearance.CenterXOffset = -30;
            chartSeries3.Appearance.CenterYOffset = 10;
            chartSeries3.Appearance.DiameterScale = 0.8D;
            chartSeries3.Appearance.LegendDisplayMode = Telerik.Reporting.Charting.ChartSeriesLegendDisplayMode.ItemLabels;
            chartSeries3.Appearance.ShowLabels = false;
            chartSeries3.DataLabelsColumn = "ReasonWithMachinePrefix";
            chartSeries3.DataYColumn = "NumberOfStops";
            chartSeries3.DefaultLabelValue = "";
            chartSeries3.Name = "Series 1";
            chartSeries3.Type = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chart5.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries3});
            this.chart5.SeriesPalette = "Palette1";
            this.chart5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(3.8502085208892822D));
            this.chart5.Style.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.chart5.Style.Visible = true;
            this.chart5.NeedDataSource += new System.EventHandler(this.chart4StopCount_NeedDataSource);
            // 
            // chart6
            // 
            this.chart6.Appearance.Border.Visible = false;
            this.chart6.Appearance.Border.Width = 5F;
            this.chart6.Appearance.Dimensions.AutoSize = false;
            this.chart6.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(145D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins12.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins12.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins12.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins12.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart6.Appearance.Dimensions.Margins = chartMargins12;
            chartPaddings4.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings4.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings4.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings4.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart6.Appearance.Dimensions.Paddings = chartPaddings4;
            this.chart6.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(351D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart6.Appearance.FillStyle.MainColor = System.Drawing.SystemColors.ControlLightLight;
            this.chart6.BitmapResolution = 192F;
            this.chart6.ChartTitle.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chart6.ChartTitle.Appearance.Visible = false;
            this.chart6.ChartTitle.TextBlock.Appearance.Position.Auto = false;
            this.chart6.ChartTitle.TextBlock.Appearance.Position.X = 0F;
            this.chart6.ChartTitle.TextBlock.Appearance.Position.Y = 0F;
            this.chart6.ChartTitle.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart6.ChartTitle.TextBlock.Text = "Maskin 2";
            this.chart6.ChartTitle.Visible = false;
            paletteItem19.MainColor = System.Drawing.Color.Red;
            paletteItem19.Name = "PaletteItem 6";
            paletteItem19.SecondColor = System.Drawing.Color.DarkOrange;
            paletteItem20.MainColor = System.Drawing.Color.Blue;
            paletteItem20.Name = "PaletteItem 1";
            paletteItem20.SecondColor = System.Drawing.Color.LightSkyBlue;
            paletteItem21.MainColor = System.Drawing.Color.Green;
            paletteItem21.Name = "PaletteItem 2";
            paletteItem21.SecondColor = System.Drawing.Color.GreenYellow;
            paletteItem22.MainColor = System.Drawing.Color.DarkGoldenrod;
            paletteItem22.Name = "PaletteItem 3";
            paletteItem22.SecondColor = System.Drawing.Color.Gold;
            paletteItem23.MainColor = System.Drawing.Color.DarkGray;
            paletteItem23.Name = "PaletteItem 4";
            paletteItem23.SecondColor = System.Drawing.Color.White;
            paletteItem24.MainColor = System.Drawing.Color.Pink;
            paletteItem24.Name = "PaletteItem 5";
            paletteItem24.SecondColor = System.Drawing.Color.PeachPuff;
            palette4.Items.AddRange(new Telerik.Reporting.Charting.PaletteItem[] {
            paletteItem19,
            paletteItem20,
            paletteItem21,
            paletteItem22,
            paletteItem23,
            paletteItem24});
            palette4.Name = "Palette1";
            this.chart6.CustomPalettes.AddRange(new Telerik.Reporting.Charting.Palette[] {
            palette4});
            this.chart6.DefaultType = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chart6.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chart6.IntelligentLabelsEnabled = true;
            chartMargins13.Right = new Telerik.Reporting.Charting.Styles.Unit(2D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart6.Legend.Appearance.Dimensions.Margins = chartMargins13;
            this.chart6.Legend.Appearance.ItemTextAppearance.TextProperties.Font = new System.Drawing.Font("Verdana", 6.4F);
            this.chart6.Legend.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6F);
            this.chart6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.chart6.Name = "chart6";
            this.chart6.PlotArea.Appearance.Border.Visible = false;
            chartMargins14.Right = new Telerik.Reporting.Charting.Styles.Unit(160D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart6.PlotArea.Appearance.Dimensions.Margins = chartMargins14;
            this.chart6.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chart6.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chart6.PlotArea.Appearance.SeriesPalette = "Palette1";
            this.chart6.PlotArea.EmptySeriesMessage.TextBlock.Visible = false;
            this.chart6.PlotArea.XAxis.MinValue = 1D;
            chartSeries4.Appearance.CenterXOffset = -25;
            chartSeries4.Appearance.LegendDisplayMode = Telerik.Reporting.Charting.ChartSeriesLegendDisplayMode.ItemLabels;
            chartSeries4.Appearance.ShowLabels = false;
            chartSeries4.DataLabelsColumn = "ReasonWithMachinePrefix";
            chartSeries4.DataYColumn = "ElapsedTimeInSeconds";
            chartSeries4.Name = "Series 1";
            chartSeries4.Type = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chart6.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries4});
            this.chart6.SeriesPalette = "Palette1";
            this.chart6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(3.8502085208892822D));
            this.chart6.Style.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.chart6.NeedDataSource += new System.EventHandler(this.chart4StopTime_NeedDataSource);
            // 
            // panelRow3
            // 
            panelRow3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.chart3,
            this.chart4});
            panelRow3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(9.4708175659179688D));
            panelRow3.Name = "panelRow3";
            panelRow3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(3.8502085208892822D));
            panelRow3.Style.BackgroundColor = System.Drawing.Color.White;
            panelRow3.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            panelRow3.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            panelRow3.Style.Visible = false;
            // 
            // chart3
            // 
            this.chart3.Appearance.Border.Visible = false;
            this.chart3.Appearance.Border.Width = 5F;
            this.chart3.Appearance.Dimensions.AutoSize = false;
            this.chart3.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(145D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins15.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins15.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins15.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins15.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart3.Appearance.Dimensions.Margins = chartMargins15;
            chartPaddings5.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings5.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings5.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings5.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart3.Appearance.Dimensions.Paddings = chartPaddings5;
            this.chart3.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(351D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart3.Appearance.FillStyle.MainColor = System.Drawing.SystemColors.Control;
            this.chart3.BitmapResolution = 192F;
            chartMargins16.Bottom = new Telerik.Reporting.Charting.Styles.Unit(14D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins16.Left = new Telerik.Reporting.Charting.Styles.Unit(2D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins16.Right = new Telerik.Reporting.Charting.Styles.Unit(10D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins16.Top = new Telerik.Reporting.Charting.Styles.Unit(4D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            this.chart3.ChartTitle.Appearance.Dimensions.Margins = chartMargins16;
            this.chart3.ChartTitle.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chart3.ChartTitle.TextBlock.Appearance.Position.Auto = false;
            this.chart3.ChartTitle.TextBlock.Appearance.Position.X = 0F;
            this.chart3.ChartTitle.TextBlock.Appearance.Position.Y = 0F;
            this.chart3.ChartTitle.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart3.ChartTitle.TextBlock.Text = "Packstation 3";
            paletteItem25.MainColor = System.Drawing.Color.Red;
            paletteItem25.Name = "PaletteItem 6";
            paletteItem25.SecondColor = System.Drawing.Color.DarkOrange;
            paletteItem26.MainColor = System.Drawing.Color.Blue;
            paletteItem26.Name = "PaletteItem 1";
            paletteItem26.SecondColor = System.Drawing.Color.LightSkyBlue;
            paletteItem27.MainColor = System.Drawing.Color.Green;
            paletteItem27.Name = "PaletteItem 2";
            paletteItem27.SecondColor = System.Drawing.Color.GreenYellow;
            paletteItem28.MainColor = System.Drawing.Color.DarkGoldenrod;
            paletteItem28.Name = "PaletteItem 3";
            paletteItem28.SecondColor = System.Drawing.Color.Gold;
            paletteItem29.MainColor = System.Drawing.Color.DarkGray;
            paletteItem29.Name = "PaletteItem 4";
            paletteItem29.SecondColor = System.Drawing.Color.White;
            paletteItem30.MainColor = System.Drawing.Color.Pink;
            paletteItem30.Name = "PaletteItem 5";
            paletteItem30.SecondColor = System.Drawing.Color.PeachPuff;
            palette5.Items.AddRange(new Telerik.Reporting.Charting.PaletteItem[] {
            paletteItem25,
            paletteItem26,
            paletteItem27,
            paletteItem28,
            paletteItem29,
            paletteItem30});
            palette5.Name = "Palette1";
            this.chart3.CustomPalettes.AddRange(new Telerik.Reporting.Charting.Palette[] {
            palette5});
            this.chart3.DefaultType = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chart3.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chart3.IntelligentLabelsEnabled = true;
            chartMargins17.Right = new Telerik.Reporting.Charting.Styles.Unit(2D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart3.Legend.Appearance.Dimensions.Margins = chartMargins17;
            this.chart3.Legend.Appearance.ItemTextAppearance.TextProperties.Font = new System.Drawing.Font("Verdana", 6.4F);
            this.chart3.Legend.TextBlock.Appearance.Dimensions.AutoSize = false;
            this.chart3.Legend.TextBlock.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart3.Legend.TextBlock.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart3.Legend.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6F);
            this.chart3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.chart3.Name = "chart3";
            this.chart3.PlotArea.Appearance.Border.Visible = false;
            chartMargins18.Right = new Telerik.Reporting.Charting.Styles.Unit(160D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart3.PlotArea.Appearance.Dimensions.Margins = chartMargins18;
            this.chart3.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chart3.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chart3.PlotArea.Appearance.SeriesPalette = "Palette1";
            this.chart3.PlotArea.EmptySeriesMessage.TextBlock.Visible = false;
            this.chart3.PlotArea.XAxis.MinValue = 1D;
            chartSeries5.Appearance.CenterXOffset = -30;
            chartSeries5.Appearance.CenterYOffset = 10;
            chartSeries5.Appearance.DiameterScale = 0.8D;
            chartSeries5.Appearance.LegendDisplayMode = Telerik.Reporting.Charting.ChartSeriesLegendDisplayMode.ItemLabels;
            chartSeries5.Appearance.ShowLabels = false;
            chartSeries5.DataLabelsColumn = "ReasonWithMachinePrefix";
            chartSeries5.DataYColumn = "NumberOfStops";
            chartSeries5.DefaultLabelValue = "";
            chartSeries5.Name = "Series 1";
            chartSeries5.Type = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chart3.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries5});
            this.chart3.SeriesPalette = "Palette1";
            this.chart3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(3.8502085208892822D));
            this.chart3.Style.BackgroundColor = System.Drawing.SystemColors.Control;
            this.chart3.Style.Visible = true;
            this.chart3.NeedDataSource += new System.EventHandler(this.chart3StopCount_NeedDataSource);
            // 
            // chart4
            // 
            this.chart4.Appearance.Border.Visible = false;
            this.chart4.Appearance.Border.Width = 5F;
            this.chart4.Appearance.Dimensions.AutoSize = false;
            this.chart4.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(145D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins19.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins19.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins19.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins19.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart4.Appearance.Dimensions.Margins = chartMargins19;
            chartPaddings6.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings6.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings6.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings6.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart4.Appearance.Dimensions.Paddings = chartPaddings6;
            this.chart4.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(351D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart4.Appearance.FillStyle.MainColor = System.Drawing.SystemColors.Control;
            this.chart4.BitmapResolution = 192F;
            this.chart4.ChartTitle.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chart4.ChartTitle.Appearance.Visible = false;
            this.chart4.ChartTitle.TextBlock.Appearance.Position.Auto = false;
            this.chart4.ChartTitle.TextBlock.Appearance.Position.X = 0F;
            this.chart4.ChartTitle.TextBlock.Appearance.Position.Y = 0F;
            this.chart4.ChartTitle.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart4.ChartTitle.TextBlock.Text = "Maskin 2";
            this.chart4.ChartTitle.Visible = false;
            paletteItem31.MainColor = System.Drawing.Color.Red;
            paletteItem31.Name = "PaletteItem 6";
            paletteItem31.SecondColor = System.Drawing.Color.DarkOrange;
            paletteItem32.MainColor = System.Drawing.Color.Blue;
            paletteItem32.Name = "PaletteItem 1";
            paletteItem32.SecondColor = System.Drawing.Color.LightSkyBlue;
            paletteItem33.MainColor = System.Drawing.Color.Green;
            paletteItem33.Name = "PaletteItem 2";
            paletteItem33.SecondColor = System.Drawing.Color.GreenYellow;
            paletteItem34.MainColor = System.Drawing.Color.DarkGoldenrod;
            paletteItem34.Name = "PaletteItem 3";
            paletteItem34.SecondColor = System.Drawing.Color.Gold;
            paletteItem35.MainColor = System.Drawing.Color.DarkGray;
            paletteItem35.Name = "PaletteItem 4";
            paletteItem35.SecondColor = System.Drawing.Color.White;
            paletteItem36.MainColor = System.Drawing.Color.Pink;
            paletteItem36.Name = "PaletteItem 5";
            paletteItem36.SecondColor = System.Drawing.Color.PeachPuff;
            palette6.Items.AddRange(new Telerik.Reporting.Charting.PaletteItem[] {
            paletteItem31,
            paletteItem32,
            paletteItem33,
            paletteItem34,
            paletteItem35,
            paletteItem36});
            palette6.Name = "Palette1";
            this.chart4.CustomPalettes.AddRange(new Telerik.Reporting.Charting.Palette[] {
            palette6});
            this.chart4.DefaultType = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chart4.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chart4.IntelligentLabelsEnabled = true;
            chartMargins20.Right = new Telerik.Reporting.Charting.Styles.Unit(2D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart4.Legend.Appearance.Dimensions.Margins = chartMargins20;
            this.chart4.Legend.Appearance.ItemTextAppearance.TextProperties.Font = new System.Drawing.Font("Verdana", 6.4F);
            this.chart4.Legend.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6F);
            this.chart4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.chart4.Name = "chart4";
            this.chart4.PlotArea.Appearance.Border.Visible = false;
            chartMargins21.Right = new Telerik.Reporting.Charting.Styles.Unit(160D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart4.PlotArea.Appearance.Dimensions.Margins = chartMargins21;
            this.chart4.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chart4.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chart4.PlotArea.Appearance.SeriesPalette = "Palette1";
            this.chart4.PlotArea.EmptySeriesMessage.TextBlock.Visible = false;
            this.chart4.PlotArea.XAxis.MinValue = 1D;
            chartSeries6.Appearance.CenterXOffset = -30;
            chartSeries6.Appearance.CenterYOffset = 10;
            chartSeries6.Appearance.DiameterScale = 0.8D;
            chartSeries6.Appearance.LegendDisplayMode = Telerik.Reporting.Charting.ChartSeriesLegendDisplayMode.ItemLabels;
            chartSeries6.Appearance.ShowLabels = false;
            chartSeries6.DataLabelsColumn = "ReasonWithMachinePrefix";
            chartSeries6.DataYColumn = "ElapsedTimeInSeconds";
            chartSeries6.Name = "Series 1";
            chartSeries6.Type = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chart4.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries6});
            this.chart4.SeriesPalette = "Palette1";
            this.chart4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(3.8502085208892822D));
            this.chart4.Style.BackgroundColor = System.Drawing.SystemColors.Control;
            this.chart4.NeedDataSource += new System.EventHandler(this.chart3StopTime_NeedDataSource);
            // 
            // panelRow5
            // 
            panelRow5.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.chart7,
            this.chart8});
            panelRow5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(17.171634674072266D));
            panelRow5.Name = "panelRow5";
            panelRow5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(3.8452088832855225D));
            panelRow5.Style.BackgroundColor = System.Drawing.Color.White;
            panelRow5.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            panelRow5.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            panelRow5.Style.Visible = false;
            // 
            // chart7
            // 
            this.chart7.Appearance.Border.Visible = false;
            this.chart7.Appearance.Border.Width = 5F;
            this.chart7.Appearance.Dimensions.AutoSize = false;
            this.chart7.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(145D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins22.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins22.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins22.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins22.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart7.Appearance.Dimensions.Margins = chartMargins22;
            chartPaddings7.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings7.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings7.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings7.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart7.Appearance.Dimensions.Paddings = chartPaddings7;
            this.chart7.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(351D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart7.Appearance.FillStyle.MainColor = System.Drawing.SystemColors.Control;
            this.chart7.BitmapResolution = 192F;
            chartMargins23.Bottom = new Telerik.Reporting.Charting.Styles.Unit(14D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins23.Left = new Telerik.Reporting.Charting.Styles.Unit(2D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins23.Right = new Telerik.Reporting.Charting.Styles.Unit(10D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins23.Top = new Telerik.Reporting.Charting.Styles.Unit(4D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            this.chart7.ChartTitle.Appearance.Dimensions.Margins = chartMargins23;
            this.chart7.ChartTitle.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chart7.ChartTitle.TextBlock.Appearance.Position.Auto = false;
            this.chart7.ChartTitle.TextBlock.Appearance.Position.X = 0F;
            this.chart7.ChartTitle.TextBlock.Appearance.Position.Y = 0F;
            this.chart7.ChartTitle.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart7.ChartTitle.TextBlock.Text = "Packstation 5";
            paletteItem37.MainColor = System.Drawing.Color.Red;
            paletteItem37.Name = "PaletteItem 6";
            paletteItem37.SecondColor = System.Drawing.Color.DarkOrange;
            paletteItem38.MainColor = System.Drawing.Color.Blue;
            paletteItem38.Name = "PaletteItem 1";
            paletteItem38.SecondColor = System.Drawing.Color.LightSkyBlue;
            paletteItem39.MainColor = System.Drawing.Color.Green;
            paletteItem39.Name = "PaletteItem 2";
            paletteItem39.SecondColor = System.Drawing.Color.GreenYellow;
            paletteItem40.MainColor = System.Drawing.Color.DarkGoldenrod;
            paletteItem40.Name = "PaletteItem 3";
            paletteItem40.SecondColor = System.Drawing.Color.Gold;
            paletteItem41.MainColor = System.Drawing.Color.DarkGray;
            paletteItem41.Name = "PaletteItem 4";
            paletteItem41.SecondColor = System.Drawing.Color.White;
            paletteItem42.MainColor = System.Drawing.Color.Pink;
            paletteItem42.Name = "PaletteItem 5";
            paletteItem42.SecondColor = System.Drawing.Color.PeachPuff;
            palette7.Items.AddRange(new Telerik.Reporting.Charting.PaletteItem[] {
            paletteItem37,
            paletteItem38,
            paletteItem39,
            paletteItem40,
            paletteItem41,
            paletteItem42});
            palette7.Name = "Palette1";
            this.chart7.CustomPalettes.AddRange(new Telerik.Reporting.Charting.Palette[] {
            palette7});
            this.chart7.DefaultType = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chart7.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chart7.IntelligentLabelsEnabled = true;
            chartMargins24.Right = new Telerik.Reporting.Charting.Styles.Unit(2D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart7.Legend.Appearance.Dimensions.Margins = chartMargins24;
            this.chart7.Legend.Appearance.ItemTextAppearance.TextProperties.Font = new System.Drawing.Font("Verdana", 6.4F);
            this.chart7.Legend.TextBlock.Appearance.Dimensions.AutoSize = false;
            this.chart7.Legend.TextBlock.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart7.Legend.TextBlock.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart7.Legend.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6F);
            this.chart7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.chart7.Name = "chart7";
            this.chart7.PlotArea.Appearance.Border.Visible = false;
            chartMargins25.Right = new Telerik.Reporting.Charting.Styles.Unit(160D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart7.PlotArea.Appearance.Dimensions.Margins = chartMargins25;
            this.chart7.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chart7.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chart7.PlotArea.Appearance.SeriesPalette = "Palette1";
            this.chart7.PlotArea.EmptySeriesMessage.TextBlock.Visible = false;
            this.chart7.PlotArea.XAxis.MinValue = 1D;
            chartSeries7.Appearance.CenterXOffset = -30;
            chartSeries7.Appearance.CenterYOffset = 10;
            chartSeries7.Appearance.DiameterScale = 0.8D;
            chartSeries7.Appearance.LegendDisplayMode = Telerik.Reporting.Charting.ChartSeriesLegendDisplayMode.ItemLabels;
            chartSeries7.Appearance.ShowLabels = false;
            chartSeries7.DataLabelsColumn = "ReasonWithMachinePrefix";
            chartSeries7.DataYColumn = "NumberOfStops";
            chartSeries7.DefaultLabelValue = "";
            chartSeries7.Name = "Series 1";
            chartSeries7.Type = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chart7.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries7});
            this.chart7.SeriesPalette = "Palette1";
            this.chart7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(3.8451082706451416D));
            this.chart7.Style.BackgroundColor = System.Drawing.SystemColors.Control;
            this.chart7.Style.Visible = true;
            this.chart7.NeedDataSource += new System.EventHandler(this.chart5StopCount_NeedDataSource);
            // 
            // chart8
            // 
            this.chart8.Appearance.Border.Visible = false;
            this.chart8.Appearance.Border.Width = 5F;
            this.chart8.Appearance.Dimensions.AutoSize = false;
            this.chart8.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(145D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins26.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins26.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins26.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins26.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart8.Appearance.Dimensions.Margins = chartMargins26;
            chartPaddings8.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings8.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings8.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings8.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart8.Appearance.Dimensions.Paddings = chartPaddings8;
            this.chart8.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(351D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart8.Appearance.FillStyle.MainColor = System.Drawing.SystemColors.Control;
            this.chart8.BitmapResolution = 192F;
            this.chart8.ChartTitle.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chart8.ChartTitle.Appearance.Visible = false;
            this.chart8.ChartTitle.TextBlock.Appearance.Position.Auto = false;
            this.chart8.ChartTitle.TextBlock.Appearance.Position.X = 0F;
            this.chart8.ChartTitle.TextBlock.Appearance.Position.Y = 0F;
            this.chart8.ChartTitle.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart8.ChartTitle.TextBlock.Text = "Maskin 2";
            this.chart8.ChartTitle.Visible = false;
            paletteItem43.MainColor = System.Drawing.Color.Red;
            paletteItem43.Name = "PaletteItem 6";
            paletteItem43.SecondColor = System.Drawing.Color.DarkOrange;
            paletteItem44.MainColor = System.Drawing.Color.Blue;
            paletteItem44.Name = "PaletteItem 1";
            paletteItem44.SecondColor = System.Drawing.Color.LightSkyBlue;
            paletteItem45.MainColor = System.Drawing.Color.Green;
            paletteItem45.Name = "PaletteItem 2";
            paletteItem45.SecondColor = System.Drawing.Color.GreenYellow;
            paletteItem46.MainColor = System.Drawing.Color.DarkGoldenrod;
            paletteItem46.Name = "PaletteItem 3";
            paletteItem46.SecondColor = System.Drawing.Color.Gold;
            paletteItem47.MainColor = System.Drawing.Color.DarkGray;
            paletteItem47.Name = "PaletteItem 4";
            paletteItem47.SecondColor = System.Drawing.Color.White;
            paletteItem48.MainColor = System.Drawing.Color.Pink;
            paletteItem48.Name = "PaletteItem 5";
            paletteItem48.SecondColor = System.Drawing.Color.PeachPuff;
            palette8.Items.AddRange(new Telerik.Reporting.Charting.PaletteItem[] {
            paletteItem43,
            paletteItem44,
            paletteItem45,
            paletteItem46,
            paletteItem47,
            paletteItem48});
            palette8.Name = "Palette1";
            this.chart8.CustomPalettes.AddRange(new Telerik.Reporting.Charting.Palette[] {
            palette8});
            this.chart8.DefaultType = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chart8.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chart8.IntelligentLabelsEnabled = true;
            chartMargins27.Right = new Telerik.Reporting.Charting.Styles.Unit(2D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart8.Legend.Appearance.Dimensions.Margins = chartMargins27;
            this.chart8.Legend.Appearance.ItemTextAppearance.TextProperties.Font = new System.Drawing.Font("Verdana", 6.4F);
            this.chart8.Legend.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6F);
            this.chart8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.chart8.Name = "chart8";
            this.chart8.PlotArea.Appearance.Border.Visible = false;
            chartMargins28.Right = new Telerik.Reporting.Charting.Styles.Unit(160D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chart8.PlotArea.Appearance.Dimensions.Margins = chartMargins28;
            this.chart8.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chart8.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chart8.PlotArea.Appearance.SeriesPalette = "Palette1";
            this.chart8.PlotArea.EmptySeriesMessage.TextBlock.Visible = false;
            this.chart8.PlotArea.XAxis.MinValue = 1D;
            chartSeries8.Appearance.CenterXOffset = -30;
            chartSeries8.Appearance.CenterYOffset = 10;
            chartSeries8.Appearance.DiameterScale = 0.8D;
            chartSeries8.Appearance.LegendDisplayMode = Telerik.Reporting.Charting.ChartSeriesLegendDisplayMode.ItemLabels;
            chartSeries8.Appearance.ShowLabels = false;
            chartSeries8.DataLabelsColumn = "ReasonWithMachinePrefix";
            chartSeries8.DataYColumn = "ElapsedTimeInSeconds";
            chartSeries8.Name = "Series 1";
            chartSeries8.Type = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chart8.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries8});
            this.chart8.SeriesPalette = "Palette1";
            this.chart8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(3.8452088832855225D));
            this.chart8.Style.BackgroundColor = System.Drawing.SystemColors.Control;
            this.chart8.NeedDataSource += new System.EventHandler(this.chart5StopTime_NeedDataSource);
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(21.016845703125D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.tableMachines,
            this.panelRow1,
            panelRow2,
            panelRow4,
            panelRow3,
            panelRow5,
            this.textBox14,
            this.textBox23});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.Font.Italic = true;
            this.detail.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.detail.Style.Visible = true;
            // 
            // tableMachines
            // 
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(4.2464566230773926D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.076366662979126D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.238123893737793D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.7372286319732666D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.8168972730636597D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.8438819646835327D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.3704166412353516D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.2645833492279053D)));
            this.tableMachines.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367D)));
            this.tableMachines.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367D)));
            this.tableMachines.Body.SetCellContent(0, 0, this.textBox12);
            this.tableMachines.Body.SetCellContent(0, 1, this.textBox13);
            this.tableMachines.Body.SetCellContent(1, 0, this.textBox15);
            this.tableMachines.Body.SetCellContent(1, 1, this.textBox16);
            this.tableMachines.Body.SetCellContent(0, 3, this.textBox17);
            this.tableMachines.Body.SetCellContent(1, 3, this.textBox18);
            this.tableMachines.Body.SetCellContent(0, 4, this.textBox19);
            this.tableMachines.Body.SetCellContent(1, 4, this.textBox20);
            this.tableMachines.Body.SetCellContent(0, 5, this.textBox21);
            this.tableMachines.Body.SetCellContent(1, 5, this.textBox22);
            this.tableMachines.Body.SetCellContent(0, 2, this.textBox1);
            this.tableMachines.Body.SetCellContent(1, 2, this.textBox3);
            this.tableMachines.Body.SetCellContent(0, 7, this.textBox4);
            this.tableMachines.Body.SetCellContent(1, 7, this.textBox5);
            this.tableMachines.Body.SetCellContent(0, 6, this.textBox6);
            this.tableMachines.Body.SetCellContent(1, 6, this.textBox7);
            tableGroup3.Name = "Group4";
            tableGroup4.Name = "Group1";
            tableGroup5.Name = "Group2";
            tableGroup6.Name = "Group3";
            tableGroup7.Name = "Group6";
            tableGroup8.Name = "Group5";
            this.tableMachines.ColumnGroups.Add(tableGroup1);
            this.tableMachines.ColumnGroups.Add(tableGroup2);
            this.tableMachines.ColumnGroups.Add(tableGroup3);
            this.tableMachines.ColumnGroups.Add(tableGroup4);
            this.tableMachines.ColumnGroups.Add(tableGroup5);
            this.tableMachines.ColumnGroups.Add(tableGroup6);
            this.tableMachines.ColumnGroups.Add(tableGroup7);
            this.tableMachines.ColumnGroups.Add(tableGroup8);
            this.tableMachines.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox12,
            this.textBox13,
            this.textBox15,
            this.textBox16,
            this.textBox17,
            this.textBox18,
            this.textBox19,
            this.textBox20,
            this.textBox21,
            this.textBox22,
            this.textBox1,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7});
            this.tableMachines.KeepTogether = false;
            this.tableMachines.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.tableMachines.Name = "tableMachines";
            tableGroup11.Name = "Group7";
            tableGroup10.ChildGroups.Add(tableGroup11);
            tableGroup10.Groupings.AddRange(new Telerik.Reporting.Data.Grouping[] {
            new Telerik.Reporting.Data.Grouping("")});
            tableGroup10.Name = "detailGroup";
            this.tableMachines.RowGroups.Add(tableGroup9);
            this.tableMachines.RowGroups.Add(tableGroup10);
            this.tableMachines.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.593952178955078D), Telerik.Reporting.Drawing.Unit.Cm(1.0399999618530273D));
            this.tableMachines.Style.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tableMachines.Style.Visible = true;
            this.tableMachines.NeedDataSource += new System.EventHandler(this.tableMachines_NeedDataSource);
            // 
            // textBox12
            // 
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.2464566230773926D), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367D));
            this.textBox12.Style.Font.Bold = true;
            this.textBox12.Style.Font.Italic = false;
            this.textBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            // 
            // textBox13
            // 
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0763659477233887D), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367D));
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Font.Italic = false;
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox13.Value = "TAK/OEE";
            // 
            // textBox15
            // 
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.2464566230773926D), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367D));
            this.textBox15.Style.Font.Bold = true;
            this.textBox15.Style.Font.Italic = false;
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox15.Value = "=Fields.Division";
            // 
            // textBox16
            // 
            this.textBox16.Format = "{0:P1}";
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0763659477233887D), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367D));
            this.textBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox16.Value = "=Fields.Oee";
            // 
            // textBox17
            // 
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7372299432754517D), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367D));
            this.textBox17.Style.Font.Bold = true;
            this.textBox17.Style.Font.Italic = false;
            this.textBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox17.Value = "T";
            // 
            // textBox18
            // 
            this.textBox18.Format = "{0:P1}";
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7372299432754517D), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367D));
            this.textBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox18.Value = "=Fields.Availability";
            // 
            // textBox19
            // 
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.816897988319397D), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367D));
            this.textBox19.Style.Font.Bold = true;
            this.textBox19.Style.Font.Italic = false;
            this.textBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox19.Value = "A";
            // 
            // textBox20
            // 
            this.textBox20.Format = "{0:P1}";
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.816897988319397D), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367D));
            this.textBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox20.Value = "=Fields.Performance";
            // 
            // textBox21
            // 
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8438820838928223D), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367D));
            this.textBox21.Style.Font.Bold = true;
            this.textBox21.Style.Font.Italic = false;
            this.textBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox21.Value = "K";
            // 
            // textBox22
            // 
            this.textBox22.Format = "{0:P1}";
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8438820838928223D), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367D));
            this.textBox22.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox22.Value = "=Fields.Quality";
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.238123893737793D), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Italic = false;
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox1.StyleName = "";
            this.textBox1.Value = "Ackumulerat";
            // 
            // textBox3
            // 
            this.textBox3.Format = "{0:P1}";
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.238123893737793D), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367D));
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox3.StyleName = "";
            this.textBox3.Value = "=Fields.PreviousOee";
            // 
            // textBox4
            // 
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2645833492279053D), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367D));
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Style.Font.Italic = false;
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox4.StyleName = "";
            this.textBox4.Value = "Stopptid";
            // 
            // textBox5
            // 
            this.textBox5.Format = "{0:N1} tim";
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2645833492279053D), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367D));
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox5.StyleName = "";
            this.textBox5.Value = "=Fields.StopTimeInHours";
            // 
            // textBox6
            // 
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.3704164028167725D), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367D));
            this.textBox6.Style.Font.Bold = true;
            this.textBox6.Style.Font.Italic = false;
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox6.StyleName = "";
            this.textBox6.Value = "Prod. tid";
            // 
            // textBox7
            // 
            this.textBox7.Format = "{0:N1} tim";
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.3704164028167725D), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367D));
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox7.StyleName = "";
            this.textBox7.Value = "=Fields.TotalTimeInHours";
            // 
            // panelRow1
            // 
            this.panelRow1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.chartStopCount,
            this.chartStopTime});
            this.panelRow1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(1.770000696182251D));
            this.panelRow1.Name = "panelRow1";
            this.panelRow1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(3.8502082824707031D));
            this.panelRow1.Style.Visible = false;
            // 
            // chartStopCount
            // 
            this.chartStopCount.Appearance.Border.Visible = false;
            this.chartStopCount.Appearance.Dimensions.AutoSize = false;
            this.chartStopCount.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(145D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins29.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins29.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins29.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins29.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.Appearance.Dimensions.Margins = chartMargins29;
            chartPaddings9.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings9.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings9.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings9.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.Appearance.Dimensions.Paddings = chartPaddings9;
            this.chartStopCount.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(351D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.Appearance.FillStyle.MainColor = System.Drawing.SystemColors.Control;
            this.chartStopCount.BitmapResolution = 192F;
            chartMargins30.Bottom = new Telerik.Reporting.Charting.Styles.Unit(14D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins30.Left = new Telerik.Reporting.Charting.Styles.Unit(2D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins30.Right = new Telerik.Reporting.Charting.Styles.Unit(10D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins30.Top = new Telerik.Reporting.Charting.Styles.Unit(4D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            this.chartStopCount.ChartTitle.Appearance.Dimensions.Margins = chartMargins30;
            this.chartStopCount.ChartTitle.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartStopCount.ChartTitle.TextBlock.Appearance.Position.Auto = false;
            this.chartStopCount.ChartTitle.TextBlock.Appearance.Position.X = 0F;
            this.chartStopCount.ChartTitle.TextBlock.Appearance.Position.Y = 0F;
            this.chartStopCount.ChartTitle.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartStopCount.ChartTitle.TextBlock.Text = "Packstation 1";
            paletteItem49.MainColor = System.Drawing.Color.Red;
            paletteItem49.Name = "PaletteItem 6";
            paletteItem49.SecondColor = System.Drawing.Color.DarkOrange;
            paletteItem50.MainColor = System.Drawing.Color.Blue;
            paletteItem50.Name = "PaletteItem 1";
            paletteItem50.SecondColor = System.Drawing.Color.LightSkyBlue;
            paletteItem51.MainColor = System.Drawing.Color.Green;
            paletteItem51.Name = "PaletteItem 2";
            paletteItem51.SecondColor = System.Drawing.Color.GreenYellow;
            paletteItem52.MainColor = System.Drawing.Color.DarkGoldenrod;
            paletteItem52.Name = "PaletteItem 3";
            paletteItem52.SecondColor = System.Drawing.Color.Gold;
            paletteItem53.MainColor = System.Drawing.Color.DarkGray;
            paletteItem53.Name = "PaletteItem 4";
            paletteItem53.SecondColor = System.Drawing.Color.White;
            paletteItem54.MainColor = System.Drawing.Color.Pink;
            paletteItem54.Name = "PaletteItem 5";
            paletteItem54.SecondColor = System.Drawing.Color.PeachPuff;
            palette9.Items.AddRange(new Telerik.Reporting.Charting.PaletteItem[] {
            paletteItem49,
            paletteItem50,
            paletteItem51,
            paletteItem52,
            paletteItem53,
            paletteItem54});
            palette9.Name = "Palette1";
            this.chartStopCount.CustomPalettes.AddRange(new Telerik.Reporting.Charting.Palette[] {
            palette9});
            this.chartStopCount.DefaultType = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chartStopCount.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chartStopCount.IntelligentLabelsEnabled = true;
            chartMargins31.Right = new Telerik.Reporting.Charting.Styles.Unit(2D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.Legend.Appearance.Dimensions.Margins = chartMargins31;
            this.chartStopCount.Legend.Appearance.ItemTextAppearance.TextProperties.Font = new System.Drawing.Font("Verdana", 6.4F);
            this.chartStopCount.Legend.TextBlock.Appearance.Dimensions.AutoSize = false;
            this.chartStopCount.Legend.TextBlock.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.Legend.TextBlock.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.Legend.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6F);
            this.chartStopCount.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.chartStopCount.Name = "chartStopCount";
            this.chartStopCount.PlotArea.Appearance.Border.Visible = false;
            chartMargins32.Right = new Telerik.Reporting.Charting.Styles.Unit(160D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.PlotArea.Appearance.Dimensions.Margins = chartMargins32;
            this.chartStopCount.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartStopCount.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chartStopCount.PlotArea.Appearance.SeriesPalette = "Palette1";
            this.chartStopCount.PlotArea.EmptySeriesMessage.TextBlock.Visible = false;
            this.chartStopCount.PlotArea.XAxis.MinValue = 1D;
            chartSeries9.Appearance.CenterXOffset = -30;
            chartSeries9.Appearance.CenterYOffset = 10;
            chartSeries9.Appearance.DiameterScale = 0.8D;
            chartSeries9.Appearance.LegendDisplayMode = Telerik.Reporting.Charting.ChartSeriesLegendDisplayMode.ItemLabels;
            chartSeries9.Appearance.ShowLabels = false;
            chartSeries9.DataLabelsColumn = "ReasonWithMachinePrefix";
            chartSeries9.DataYColumn = "NumberOfStops";
            chartSeries9.DefaultLabelValue = "";
            chartSeries9.Name = "Series 1";
            chartSeries9.Type = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chartStopCount.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries9});
            this.chartStopCount.SeriesPalette = "Palette1";
            this.chartStopCount.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.299799919128418D), Telerik.Reporting.Drawing.Unit.Cm(3.8502082824707031D));
            this.chartStopCount.Style.BackgroundColor = System.Drawing.SystemColors.Control;
            this.chartStopCount.Style.Visible = true;
            this.chartStopCount.NeedDataSource += new System.EventHandler(this.chart1StopCount_NeedDataSource);
            // 
            // chartStopTime
            // 
            this.chartStopTime.Appearance.Border.Visible = false;
            this.chartStopTime.Appearance.Dimensions.AutoSize = false;
            this.chartStopTime.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(145D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins33.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins33.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins33.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins33.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopTime.Appearance.Dimensions.Margins = chartMargins33;
            chartPaddings10.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings10.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings10.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings10.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopTime.Appearance.Dimensions.Paddings = chartPaddings10;
            this.chartStopTime.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(351D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopTime.Appearance.FillStyle.MainColor = System.Drawing.SystemColors.Control;
            this.chartStopTime.BitmapResolution = 192F;
            this.chartStopTime.ChartTitle.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartStopTime.ChartTitle.Appearance.Visible = false;
            this.chartStopTime.ChartTitle.TextBlock.Appearance.Position.Auto = false;
            this.chartStopTime.ChartTitle.TextBlock.Appearance.Position.X = 0F;
            this.chartStopTime.ChartTitle.TextBlock.Appearance.Position.Y = 0F;
            this.chartStopTime.ChartTitle.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartStopTime.ChartTitle.TextBlock.Text = "Maskin 1";
            this.chartStopTime.ChartTitle.Visible = false;
            paletteItem55.MainColor = System.Drawing.Color.Red;
            paletteItem55.Name = "PaletteItem 6";
            paletteItem55.SecondColor = System.Drawing.Color.DarkOrange;
            paletteItem56.MainColor = System.Drawing.Color.Blue;
            paletteItem56.Name = "PaletteItem 1";
            paletteItem56.SecondColor = System.Drawing.Color.LightSkyBlue;
            paletteItem57.MainColor = System.Drawing.Color.Green;
            paletteItem57.Name = "PaletteItem 2";
            paletteItem57.SecondColor = System.Drawing.Color.GreenYellow;
            paletteItem58.MainColor = System.Drawing.Color.DarkGoldenrod;
            paletteItem58.Name = "PaletteItem 3";
            paletteItem58.SecondColor = System.Drawing.Color.Gold;
            paletteItem59.MainColor = System.Drawing.Color.DarkGray;
            paletteItem59.Name = "PaletteItem 4";
            paletteItem59.SecondColor = System.Drawing.Color.White;
            paletteItem60.MainColor = System.Drawing.Color.Pink;
            paletteItem60.Name = "PaletteItem 5";
            paletteItem60.SecondColor = System.Drawing.Color.PeachPuff;
            palette10.Items.AddRange(new Telerik.Reporting.Charting.PaletteItem[] {
            paletteItem55,
            paletteItem56,
            paletteItem57,
            paletteItem58,
            paletteItem59,
            paletteItem60});
            palette10.Name = "Palette1";
            this.chartStopTime.CustomPalettes.AddRange(new Telerik.Reporting.Charting.Palette[] {
            palette10});
            this.chartStopTime.DefaultType = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chartStopTime.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chartStopTime.IntelligentLabelsEnabled = true;
            chartMargins34.Right = new Telerik.Reporting.Charting.Styles.Unit(2D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopTime.Legend.Appearance.Dimensions.Margins = chartMargins34;
            this.chartStopTime.Legend.Appearance.ItemTextAppearance.TextProperties.Font = new System.Drawing.Font("Verdana", 6.4F);
            this.chartStopTime.Legend.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6F);
            this.chartStopTime.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.chartStopTime.Name = "chartStopTime";
            this.chartStopTime.PlotArea.Appearance.Border.Visible = false;
            chartMargins35.Right = new Telerik.Reporting.Charting.Styles.Unit(160D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopTime.PlotArea.Appearance.Dimensions.Margins = chartMargins35;
            this.chartStopTime.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartStopTime.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chartStopTime.PlotArea.Appearance.SeriesPalette = "Palette1";
            this.chartStopTime.PlotArea.EmptySeriesMessage.TextBlock.Visible = false;
            this.chartStopTime.PlotArea.XAxis.MinValue = 1D;
            chartSeries10.Appearance.CenterXOffset = -30;
            chartSeries10.Appearance.CenterYOffset = 10;
            chartSeries10.Appearance.DiameterScale = 0.8D;
            chartSeries10.Appearance.LegendDisplayMode = Telerik.Reporting.Charting.ChartSeriesLegendDisplayMode.ItemLabels;
            chartSeries10.Appearance.ShowLabels = false;
            chartSeries10.DataLabelsColumn = "ReasonWithMachinePrefix";
            chartSeries10.DataYColumn = "ElapsedTimeInSeconds";
            chartSeries10.Name = "Series 1";
            chartSeries10.Type = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chartStopTime.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries10});
            this.chartStopTime.SeriesPalette = "Palette1";
            this.chartStopTime.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.29990291595459D), Telerik.Reporting.Drawing.Unit.Cm(3.8502082824707031D));
            this.chartStopTime.Style.BackgroundColor = System.Drawing.SystemColors.Control;
            this.chartStopTime.NeedDataSource += new System.EventHandler(this.chart1StopTime_NeedDataSource);
            // 
            // textBox14
            // 
            this.textBox14.CanGrow = false;
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(1.2698003053665161D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.1999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox14.Style.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.textBox14.Style.Color = System.Drawing.Color.White;
            this.textBox14.Style.Font.Bold = false;
            this.textBox14.Style.Font.Italic = false;
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.Style.Visible = true;
            this.textBox14.TextWrap = false;
            this.textBox14.Value = "Fördelning av stopptid";
            // 
            // textBox23
            // 
            this.textBox23.CanGrow = false;
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(1.2698003053665161D));
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.1999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.49999934434890747D));
            this.textBox23.Style.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.textBox23.Style.Color = System.Drawing.Color.White;
            this.textBox23.Style.Font.Bold = false;
            this.textBox23.Style.Font.Italic = false;
            this.textBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox23.Style.Visible = true;
            this.textBox23.TextWrap = false;
            this.textBox23.Value = "Fördelning av antal stopp";
            // 
            // tbHeader
            // 
            this.tbHeader.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.4266581535339355D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.tbHeader.Name = "tbHeader";
            this.tbHeader.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.5856122970581055D), Telerik.Reporting.Drawing.Unit.Cm(1.0769668817520142D));
            this.tbHeader.Style.Font.Name = "Arial";
            this.tbHeader.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16D);
            this.tbHeader.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tbHeader.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbHeader.Style.Visible = true;
            this.tbHeader.StyleName = "Title";
            this.tbHeader.Value = "Översikt";
            // 
            // tbDivisionPrompt
            // 
            this.tbDivisionPrompt.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.66145831346511841D), Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637D));
            this.tbDivisionPrompt.Name = "tbDivisionPrompt";
            this.tbDivisionPrompt.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9999973773956299D), Telerik.Reporting.Drawing.Unit.Cm(0.49999994039535522D));
            this.tbDivisionPrompt.Style.Color = System.Drawing.Color.Black;
            this.tbDivisionPrompt.Style.Font.Name = "Arial";
            this.tbDivisionPrompt.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.25D);
            this.tbDivisionPrompt.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbDivisionPrompt.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbDivisionPrompt.Style.Visible = true;
            this.tbDivisionPrompt.StyleName = "Title";
            this.tbDivisionPrompt.Value = "Modul:";
            // 
            // tbDatePrompt
            // 
            this.tbDatePrompt.Anchoring = Telerik.Reporting.AnchoringStyles.Top;
            this.tbDatePrompt.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.66145831346511841D), Telerik.Reporting.Drawing.Unit.Cm(0.57706683874130249D));
            this.tbDatePrompt.Name = "tbDatePrompt";
            this.tbDatePrompt.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0000007152557373D), Telerik.Reporting.Drawing.Unit.Cm(0.50000017881393433D));
            this.tbDatePrompt.Style.Color = System.Drawing.Color.Black;
            this.tbDatePrompt.Style.Font.Name = "Arial";
            this.tbDatePrompt.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.25D);
            this.tbDatePrompt.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbDatePrompt.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbDatePrompt.Style.Visible = true;
            this.tbDatePrompt.StyleName = "Title";
            this.tbDatePrompt.Value = "Datum:";
            // 
            // tbDivisionName
            // 
            this.tbDivisionName.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.6695778369903564D), Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637D));
            this.tbDivisionName.Name = "tbDivisionName";
            this.tbDivisionName.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.889183521270752D), Telerik.Reporting.Drawing.Unit.Cm(0.49989992380142212D));
            this.tbDivisionName.Style.Color = System.Drawing.Color.Black;
            this.tbDivisionName.Style.Font.Name = "Arial";
            this.tbDivisionName.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.25D);
            this.tbDivisionName.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbDivisionName.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbDivisionName.Style.Visible = true;
            this.tbDivisionName.StyleName = "Title";
            this.tbDivisionName.Value = "= Fields.Grouping";
            // 
            // tbDate
            // 
            this.tbDate.Format = "{0:MMMM yyyy}";
            this.tbDate.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.6699783802032471D), Telerik.Reporting.Drawing.Unit.Cm(0.57696735858917236D));
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8887834548950195D), Telerik.Reporting.Drawing.Unit.Cm(0.50000035762786865D));
            this.tbDate.Style.Color = System.Drawing.Color.Black;
            this.tbDate.Style.Font.Name = "Arial";
            this.tbDate.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.25D);
            this.tbDate.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbDate.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbDate.Style.Visible = true;
            this.tbDate.StyleName = "Title";
            this.tbDate.Value = "= Fields.Week";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.2622753381729126D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.tbHeader,
            this.panel2,
            this.panel4});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            this.pageHeaderSection1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.pageHeaderSection1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.pageHeaderSection1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(2D);
            // 
            // panel2
            // 
            this.panel2.Docking = Telerik.Reporting.DockingStyle.Left;
            this.panel2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel2.Name = "panel2";
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.1849997043609619D), Telerik.Reporting.Drawing.Unit.Cm(1.2622753381729126D));
            this.panel2.Style.BackgroundImage.ImageData = global::M2M.DataCenter.Report.Properties.Resources.reportLogo2;
            this.panel2.Style.BackgroundImage.MimeType = "image/gif";
            this.panel2.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat;
            // 
            // panel4
            // 
            this.panel4.Docking = Telerik.Reporting.DockingStyle.Right;
            this.panel4.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.tbDatePrompt,
            this.tbDivisionName,
            this.tbDivisionPrompt,
            this.tbDate});
            this.panel4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.012469291687012D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel4.Name = "panel4";
            this.panel4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.5875301361083984D), Telerik.Reporting.Drawing.Unit.Cm(1.2622753381729126D));
            // 
            // NpbWeekly
            // 
            this.DocumentName = "= M2M.DataCenter.Reports.NpbWeekly.GetDocumentName(Parameters.ModuleId.Value, Par" +
    "ameters.Year.Value, Parameters.Week.Value)";
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageHeaderSection1,
            pageFooterSection1});
            this.Name = "NpbWeekly";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "ModuleId";
            reportParameter1.Text = "Modul";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Visible = true;
            reportParameter2.Name = "Year";
            reportParameter2.Text = "Year";
            reportParameter2.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter2.Visible = true;
            reportParameter3.Name = "Week";
            reportParameter3.Text = "Week";
            reportParameter3.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter3.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(97)))), ((int)(((byte)(74)))));
            styleRule1.Style.Font.Name = "Georgia";
            styleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(174)))), ((int)(((byte)(173)))));
            styleRule2.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(168)))), ((int)(((byte)(212)))));
            styleRule2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Dotted;
            styleRule2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            styleRule2.Style.Font.Name = "Georgia";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Font.Name = "Georgia";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Font.Name = "Georgia";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D);
            this.NeedDataSource += new System.EventHandler(this.Machine_NeedDataSource);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DetailSection detail;
        private Table tableMachines;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox21;
        private Telerik.Reporting.TextBox textBox22;
        private Telerik.Reporting.Panel panelRow1;
        private Chart chartStopCount;
        private Chart chartStopTime;
        private Telerik.Reporting.TextBox textBox44;
        private Telerik.Reporting.TextBox tbHeader;
        private Telerik.Reporting.TextBox tbDivisionPrompt;
        private Telerik.Reporting.TextBox tbDatePrompt;
        private Telerik.Reporting.TextBox tbDivisionName;
        private Telerik.Reporting.TextBox tbDate;
        private PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox45;
        private Telerik.Reporting.TextBox textBox46;
        private Telerik.Reporting.TextBox textBox47;
        private Telerik.Reporting.Panel panel2;
        private Telerik.Reporting.Panel panel4;
        private Telerik.Reporting.TextBox textBox50;
        private Chart chart1;
        private Chart chart2;
        private Chart chart5;
        private Chart chart6;
        private Chart chart3;
        private Chart chart4;
        private Chart chart7;
        private Chart chart8;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox23;
    }
}