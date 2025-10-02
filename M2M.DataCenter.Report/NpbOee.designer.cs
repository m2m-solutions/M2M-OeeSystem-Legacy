namespace M2M.DataCenter.Reports
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class NpbOee
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Panel panelOverview;
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup3 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup4 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup5 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup6 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup7 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup8 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup9 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins1 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartPaddings chartPaddings1 = new Telerik.Reporting.Charting.Styles.ChartPaddings();
            Telerik.Reporting.Charting.Palette palette1 = new Telerik.Reporting.Charting.Palette();
            Telerik.Reporting.Charting.PaletteItem paletteItem1 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem2 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem3 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem4 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem5 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem6 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins2 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins3 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartSeries chartSeries1 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins4 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartPaddings chartPaddings2 = new Telerik.Reporting.Charting.Styles.ChartPaddings();
            Telerik.Reporting.Charting.Palette palette2 = new Telerik.Reporting.Charting.Palette();
            Telerik.Reporting.Charting.PaletteItem paletteItem7 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem8 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem9 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem10 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem11 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem12 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins5 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins6 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartSeries chartSeries2 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.TableGroup tableGroup10 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup11 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins7 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Palette palette3 = new Telerik.Reporting.Charting.Palette();
            Telerik.Reporting.Charting.PaletteItem paletteItem13 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem14 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem15 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem16 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins8 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins9 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem1 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins10 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem2 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins11 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem3 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins12 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem4 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins13 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem5 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins14 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem6 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins15 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem7 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins16 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem8 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem9 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem10 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem11 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem12 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem13 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.ChartSeries chartSeries3 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Charting.ChartSeries chartSeries4 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Charting.ChartSeries chartSeries5 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Charting.ChartSeries chartSeries6 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.TableGroup tableGroup12 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup13 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup14 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup15 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup16 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup17 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup18 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup19 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup20 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup21 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup22 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup23 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup24 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup25 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup26 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.tbProductionTime = new Telerik.Reporting.TextBox();
            this.textBox29 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.tbAvailabilityBasedOnActualStops = new Telerik.Reporting.TextBox();
            this.textBox37 = new Telerik.Reporting.TextBox();
            this.textBox36 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.tbOee = new Telerik.Reporting.TextBox();
            this.tbQuality = new Telerik.Reporting.TextBox();
            this.tbPerformance = new Telerik.Reporting.TextBox();
            this.tbAvailability = new Telerik.Reporting.TextBox();
            this.textBox32 = new Telerik.Reporting.TextBox();
            this.tbProducedItems = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.tableStops = new Telerik.Reporting.Table();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.textBox22 = new Telerik.Reporting.TextBox();
            this.textBox27 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox34 = new Telerik.Reporting.TextBox();
            this.textBox35 = new Telerik.Reporting.TextBox();
            this.textBox76 = new Telerik.Reporting.TextBox();
            this.textBox77 = new Telerik.Reporting.TextBox();
            this.chartStopCount = new Telerik.Reporting.Chart();
            this.chartStopTime = new Telerik.Reporting.Chart();
            this.list1 = new Telerik.Reporting.List();
            this.panel1 = new Telerik.Reporting.Panel();
            this.chartPeriodicOee = new Telerik.Reporting.Chart();
            this.tableMachines = new Telerik.Reporting.Table();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox39 = new Telerik.Reporting.TextBox();
            this.textBox40 = new Telerik.Reporting.TextBox();
            this.textBox41 = new Telerik.Reporting.TextBox();
            this.textBox48 = new Telerik.Reporting.TextBox();
            this.textBox49 = new Telerik.Reporting.TextBox();
            this.textBox51 = new Telerik.Reporting.TextBox();
            this.textBox52 = new Telerik.Reporting.TextBox();
            this.textBox55 = new Telerik.Reporting.TextBox();
            this.textBox56 = new Telerik.Reporting.TextBox();
            this.textBox57 = new Telerik.Reporting.TextBox();
            this.textBox58 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox25 = new Telerik.Reporting.TextBox();
            this.textBox30 = new Telerik.Reporting.TextBox();
            this.textBox31 = new Telerik.Reporting.TextBox();
            this.textBox85 = new Telerik.Reporting.TextBox();
            this.textBox115 = new Telerik.Reporting.TextBox();
            this.textBox38 = new Telerik.Reporting.TextBox();
            this.textBox42 = new Telerik.Reporting.TextBox();
            this.textBox117 = new Telerik.Reporting.TextBox();
            this.textBox116 = new Telerik.Reporting.TextBox();
            this.panel8 = new Telerik.Reporting.Panel();
            this.panel9 = new Telerik.Reporting.Panel();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.panel7 = new Telerik.Reporting.Panel();
            this.panel3 = new Telerik.Reporting.Panel();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.panel5 = new Telerik.Reporting.Panel();
            this.panel6 = new Telerik.Reporting.Panel();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.panel2 = new Telerik.Reporting.Panel();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.panel4 = new Telerik.Reporting.Panel();
            this.shape1 = new Telerik.Reporting.Shape();
            this.tbShapeRow2 = new Telerik.Reporting.TextBox();
            this.textBox26 = new Telerik.Reporting.TextBox();
            this.textBox43 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.textBox47 = new Telerik.Reporting.TextBox();
            this.textBox46 = new Telerik.Reporting.TextBox();
            this.textBox45 = new Telerik.Reporting.TextBox();
            this.textBox28 = new Telerik.Reporting.TextBox();
            this.textBox44 = new Telerik.Reporting.TextBox();
            this.textBox50 = new Telerik.Reporting.TextBox();
            this.pictureBoxLogo = new Telerik.Reporting.PictureBox();
            panelOverview = new Telerik.Reporting.Panel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // panelOverview
            // 
            panelOverview.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.tbProductionTime,
            this.textBox29,
            this.textBox3,
            this.tbAvailabilityBasedOnActualStops,
            this.textBox37,
            this.textBox36,
            this.textBox1,
            this.textBox2,
            this.tbOee,
            this.tbQuality,
            this.tbPerformance,
            this.tbAvailability,
            this.textBox32,
            this.tbProducedItems});
            panelOverview.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            panelOverview.Name = "panelOverview";
            panelOverview.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(2.320000171661377D));
            panelOverview.Style.BackgroundColor = System.Drawing.Color.White;
            panelOverview.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(97)))), ((int)(((byte)(74)))));
            panelOverview.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            panelOverview.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            panelOverview.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // tbProductionTime
            // 
            this.tbProductionTime.CanGrow = false;
            this.tbProductionTime.Format = "{0:N1} tim";
            this.tbProductionTime.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0802001953125D), Telerik.Reporting.Drawing.Unit.Cm(0.12999999523162842D));
            this.tbProductionTime.Name = "tbProductionTime";
            this.tbProductionTime.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.41999998688697815D));
            this.tbProductionTime.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbProductionTime.Value = "=Fields.ScheduledTimeAverageInHours";
            // 
            // textBox29
            // 
            this.textBox29.CanGrow = false;
            this.textBox29.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.81999999284744263D), Telerik.Reporting.Drawing.Unit.Cm(0.12999999523162842D));
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.2600002288818359D), Telerik.Reporting.Drawing.Unit.Cm(0.41999998688697815D));
            this.textBox29.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox29.Value = "Schemalagd produktionstid:";
            // 
            // textBox3
            // 
            this.textBox3.CanGrow = false;
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.81999999284744263D), Telerik.Reporting.Drawing.Unit.Cm(0.67000001668930054D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.41999998688697815D));
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox3.Value = "Tillgänglighet utan flödesfel:";
            // 
            // tbAvailabilityBasedOnActualStops
            // 
            this.tbAvailabilityBasedOnActualStops.CanGrow = false;
            this.tbAvailabilityBasedOnActualStops.Format = "{0:P1}";
            this.tbAvailabilityBasedOnActualStops.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0799999237060547D), Telerik.Reporting.Drawing.Unit.Cm(0.67000001668930054D));
            this.tbAvailabilityBasedOnActualStops.Name = "tbAvailabilityBasedOnActualStops";
            this.tbAvailabilityBasedOnActualStops.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.41999998688697815D));
            this.tbAvailabilityBasedOnActualStops.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbAvailabilityBasedOnActualStops.Value = "=Fields.AvailabilityBasedOnActualStops";
            // 
            // textBox37
            // 
            this.textBox37.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.399998664855957D), Telerik.Reporting.Drawing.Unit.Cm(1.7400000095367432D));
            this.textBox37.Name = "textBox37";
            this.textBox37.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.41999998688697815D));
            this.textBox37.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox37.Value = "Kvalitet (K):";
            // 
            // textBox36
            // 
            this.textBox36.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.399998664855957D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.textBox36.Name = "textBox36";
            this.textBox36.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.41999998688697815D));
            this.textBox36.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox36.Value = "Anläggningsutbyte (A):";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.399998664855957D), Telerik.Reporting.Drawing.Unit.Cm(0.67000001668930054D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.41999998688697815D));
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox1.Value = "Tillgänglighet (T):";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.399999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.12999999523162842D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.41999998688697815D));
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox2.Value = "TAK/OEEr:";
            // 
            // tbOee
            // 
            this.tbOee.Format = "{0:P1}";
            this.tbOee.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.659791946411133D), Telerik.Reporting.Drawing.Unit.Cm(0.12999999523162842D));
            this.tbOee.Name = "tbOee";
            this.tbOee.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.41999998688697815D));
            this.tbOee.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbOee.Value = "=Fields.OeeNpb";
            // 
            // tbQuality
            // 
            this.tbQuality.Format = "{0:P2}";
            this.tbQuality.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.686250686645508D), Telerik.Reporting.Drawing.Unit.Cm(1.7400000095367432D));
            this.tbQuality.Name = "tbQuality";
            this.tbQuality.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.41999998688697815D));
            this.tbQuality.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbQuality.Style.Visible = true;
            this.tbQuality.Value = "=Fields.Quality";
            // 
            // tbPerformance
            // 
            this.tbPerformance.Format = "{0:P1}";
            this.tbPerformance.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.686250686645508D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.tbPerformance.Name = "tbPerformance";
            this.tbPerformance.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.41999998688697815D));
            this.tbPerformance.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbPerformance.Value = "=Fields.PerformanceNpb";
            // 
            // tbAvailability
            // 
            this.tbAvailability.Format = "{0:P1}";
            this.tbAvailability.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.686250686645508D), Telerik.Reporting.Drawing.Unit.Cm(0.67000001668930054D));
            this.tbAvailability.Name = "tbAvailability";
            this.tbAvailability.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.41999998688697815D));
            this.tbAvailability.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbAvailability.Value = "=Fields.Availability";
            // 
            // textBox32
            // 
            this.textBox32.CanGrow = false;
            this.textBox32.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.880000114440918D), Telerik.Reporting.Drawing.Unit.Cm(0.41999998688697815D));
            this.textBox32.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox32.Value = "Hanterat antal:";
            // 
            // tbProducedItems
            // 
            this.tbProducedItems.CanGrow = false;
            this.tbProducedItems.Culture = new System.Globalization.CultureInfo("");
            this.tbProducedItems.Format = "{0:N0}";
            this.tbProducedItems.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0799999237060547D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.tbProducedItems.Name = "tbProducedItems";
            this.tbProducedItems.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.41999998688697815D));
            this.tbProducedItems.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbProducedItems.Value = "=Fields.ProducedItems";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(16.5497989654541D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.tableStops,
            this.chartStopCount,
            this.chartStopTime,
            this.list1,
            this.chartPeriodicOee,
            this.tableMachines,
            this.panel8,
            this.panel7,
            this.panel5});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            this.detail.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.detail.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.Font.Italic = true;
            this.detail.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.detail.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            // 
            // tableStops
            // 
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(7.5408267974853516D)));
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.9206254482269287D)));
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.0152068138122559D)));
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.6179167032241821D)));
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.5766650438308716D)));
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.750208854675293D)));
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.0354180335998535D)));
            this.tableStops.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.51770830154418945D)));
            this.tableStops.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.38000008463859558D)));
            this.tableStops.Body.SetCellContent(0, 0, this.textBox18);
            this.tableStops.Body.SetCellContent(0, 3, this.textBox19);
            this.tableStops.Body.SetCellContent(0, 4, this.textBox20);
            this.tableStops.Body.SetCellContent(1, 0, this.textBox21);
            this.tableStops.Body.SetCellContent(1, 3, this.textBox22);
            this.tableStops.Body.SetCellContent(1, 4, this.textBox27);
            this.tableStops.Body.SetCellContent(0, 5, this.textBox6);
            this.tableStops.Body.SetCellContent(1, 5, this.textBox7);
            this.tableStops.Body.SetCellContent(0, 6, this.textBox8);
            this.tableStops.Body.SetCellContent(1, 6, this.textBox9);
            this.tableStops.Body.SetCellContent(0, 2, this.textBox34);
            this.tableStops.Body.SetCellContent(1, 2, this.textBox35);
            this.tableStops.Body.SetCellContent(0, 1, this.textBox76);
            this.tableStops.Body.SetCellContent(1, 1, this.textBox77);
            tableGroup2.Name = "Group4";
            tableGroup3.Name = "Group3";
            tableGroup6.Name = "Group1";
            tableGroup7.Name = "Group2";
            this.tableStops.ColumnGroups.Add(tableGroup1);
            this.tableStops.ColumnGroups.Add(tableGroup2);
            this.tableStops.ColumnGroups.Add(tableGroup3);
            this.tableStops.ColumnGroups.Add(tableGroup4);
            this.tableStops.ColumnGroups.Add(tableGroup5);
            this.tableStops.ColumnGroups.Add(tableGroup6);
            this.tableStops.ColumnGroups.Add(tableGroup7);
            this.tableStops.ColumnHeadersPrintOnEveryPage = true;
            this.tableStops.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox18,
            this.textBox76,
            this.textBox34,
            this.textBox19,
            this.textBox20,
            this.textBox6,
            this.textBox8,
            this.textBox21,
            this.textBox77,
            this.textBox35,
            this.textBox22,
            this.textBox27,
            this.textBox7,
            this.textBox9});
            this.tableStops.KeepTogether = false;
            this.tableStops.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.010842361487448216D), Telerik.Reporting.Drawing.Unit.Cm(15.419998168945313D));
            this.tableStops.Name = "tableStops";
            tableGroup9.Groupings.Add(new Telerik.Reporting.Grouping(""));
            tableGroup9.Name = "detailGroup";
            this.tableStops.RowGroups.Add(tableGroup8);
            this.tableStops.RowGroups.Add(tableGroup9);
            this.tableStops.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.456867218017578D), Telerik.Reporting.Drawing.Unit.Cm(0.89770835638046265D));
            this.tableStops.Style.BackgroundColor = System.Drawing.Color.White;
            this.tableStops.Style.Visible = true;
            this.tableStops.NeedDataSource += new System.EventHandler(this.tableStops_NeedDataSource);
            // 
            // textBox18
            // 
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.5408267974853516D), Telerik.Reporting.Drawing.Unit.Cm(0.51770824193954468D));
            this.textBox18.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox18.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox18.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            // 
            // textBox19
            // 
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6179170608520508D), Telerik.Reporting.Drawing.Unit.Cm(0.51770824193954468D));
            this.textBox19.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox19.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox19.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox19.Style.Font.Bold = false;
            this.textBox19.Style.Font.Italic = false;
            this.textBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox19.Value = "Tidsåtgång totalt";
            // 
            // textBox20
            // 
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.5766645669937134D), Telerik.Reporting.Drawing.Unit.Cm(0.51770824193954468D));
            this.textBox20.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox20.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox20.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox20.Style.Font.Bold = false;
            this.textBox20.Style.Font.Italic = false;
            this.textBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox20.Value = "Antal";
            // 
            // textBox21
            // 
            this.textBox21.Bindings.Add(new Telerik.Reporting.Binding("Style.BorderStyle.Top", "=M2M.DataCenter.Reports.NpbOee.GetBorderTop(ReportItem.DataObject)"));
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.5408267974853516D), Telerik.Reporting.Drawing.Unit.Cm(0.38000005483627319D));
            this.textBox21.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox21.Style.Font.Bold = false;
            this.textBox21.Style.Font.Italic = false;
            this.textBox21.Style.Font.Name = "Calibri";
            this.textBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox21.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox21.Value = "=Fields.ReasonAbbrForList";
            // 
            // textBox22
            // 
            this.textBox22.Bindings.Add(new Telerik.Reporting.Binding("Style.BorderStyle.Top", "=M2M.DataCenter.Reports.NpbOee.GetBorderTop(ReportItem.DataObject)"));
            this.textBox22.Format = "{0:N1} tim";
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6179171800613403D), Telerik.Reporting.Drawing.Unit.Cm(0.38000002503395081D));
            this.textBox22.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox22.Style.Font.Italic = false;
            this.textBox22.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox22.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox22.Value = "=Fields.ElapsedTimeInHours";
            // 
            // textBox27
            // 
            this.textBox27.Bindings.Add(new Telerik.Reporting.Binding("Style.BorderStyle.Top", "=M2M.DataCenter.Reports.NpbOee.GetBorderTop(ReportItem.DataObject)"));
            this.textBox27.Format = "{0:N0}";
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.5766651630401611D), Telerik.Reporting.Drawing.Unit.Cm(0.38000002503395081D));
            this.textBox27.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox27.Style.Font.Italic = false;
            this.textBox27.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox27.Value = "=Fields.NumberOfStops";
            // 
            // textBox6
            // 
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7502083778381348D), Telerik.Reporting.Drawing.Unit.Cm(0.51770824193954468D));
            this.textBox6.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox6.Style.Font.Bold = false;
            this.textBox6.Style.Font.Italic = false;
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox6.Value = "Tidsåtgång snittvärde";
            // 
            // textBox7
            // 
            this.textBox7.Bindings.Add(new Telerik.Reporting.Binding("Style.BorderStyle.Top", "=M2M.DataCenter.Reports.NpbOee.GetBorderTop(ReportItem.DataObject)"));
            this.textBox7.Format = "{0:N1} min";
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7502084970474243D), Telerik.Reporting.Drawing.Unit.Cm(0.38000002503395081D));
            this.textBox7.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox7.Style.Font.Italic = false;
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox7.StyleName = "";
            this.textBox7.Value = "=Fields.AverageTimeInMinutes";
            // 
            // textBox8
            // 
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0354175567626953D), Telerik.Reporting.Drawing.Unit.Cm(0.51770824193954468D));
            this.textBox8.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox8.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox8.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox8.Style.Font.Bold = false;
            this.textBox8.Style.Font.Italic = false;
            this.textBox8.Style.Font.Name = "Calibri";
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox8.Value = "Tid mellan stopp";
            // 
            // textBox9
            // 
            this.textBox9.Bindings.Add(new Telerik.Reporting.Binding("Style.BorderStyle.Top", "=M2M.DataCenter.Reports.NpbOee.GetBorderTop(ReportItem.DataObject)"));
            this.textBox9.Format = "";
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0354175567626953D), Telerik.Reporting.Drawing.Unit.Cm(0.38000002503395081D));
            this.textBox9.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox9.Style.Font.Italic = false;
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox9.Value = "=Fields.AverageTimeBetweenStopsString";
            // 
            // textBox34
            // 
            this.textBox34.Name = "textBox34";
            this.textBox34.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0152058601379395D), Telerik.Reporting.Drawing.Unit.Cm(0.51770824193954468D));
            this.textBox34.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox34.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox34.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox34.Style.Font.Bold = false;
            this.textBox34.Style.Font.Italic = false;
            this.textBox34.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox34.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox34.StyleName = "";
            this.textBox34.Value = "Kategori";
            // 
            // textBox35
            // 
            this.textBox35.Bindings.Add(new Telerik.Reporting.Binding("Style.BorderStyle.Top", "=M2M.DataCenter.Reports.NpbOee.GetBorderTop(ReportItem.DataObject)"));
            this.textBox35.Name = "textBox35";
            this.textBox35.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0152058601379395D), Telerik.Reporting.Drawing.Unit.Cm(0.38000002503395081D));
            this.textBox35.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox35.Style.Font.Bold = false;
            this.textBox35.Style.Font.Italic = false;
            this.textBox35.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox35.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox35.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox35.StyleName = "";
            this.textBox35.Value = "=Fields.Category";
            // 
            // textBox76
            // 
            this.textBox76.Name = "textBox76";
            this.textBox76.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9206254482269287D), Telerik.Reporting.Drawing.Unit.Cm(0.51770824193954468D));
            this.textBox76.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox76.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox76.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox76.Style.Font.Bold = false;
            this.textBox76.Style.Font.Italic = false;
            this.textBox76.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox76.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox76.StyleName = "";
            // 
            // textBox77
            // 
            this.textBox77.Bindings.Add(new Telerik.Reporting.Binding("Style.BorderStyle.Top", "=M2M.DataCenter.Reports.NpbOee.GetBorderTop(ReportItem.DataObject)"));
            this.textBox77.Name = "textBox77";
            this.textBox77.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9206254482269287D), Telerik.Reporting.Drawing.Unit.Cm(0.38000005483627319D));
            this.textBox77.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox77.Style.Font.Italic = false;
            this.textBox77.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox77.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox77.StyleName = "";
            this.textBox77.Value = "=Fields.Machine";
            // 
            // chartStopCount
            // 
            this.chartStopCount.Appearance.Border.Visible = false;
            this.chartStopCount.Appearance.Dimensions.AutoSize = false;
            this.chartStopCount.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(139D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins1.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins1.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins1.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins1.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.Appearance.Dimensions.Margins = chartMargins1;
            chartPaddings1.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings1.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings1.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings1.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.Appearance.Dimensions.Paddings = chartPaddings1;
            this.chartStopCount.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(351D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.BitmapResolution = 192F;
            this.chartStopCount.ChartTitle.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartStopCount.ChartTitle.Appearance.Visible = false;
            this.chartStopCount.ChartTitle.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 12F);
            this.chartStopCount.ChartTitle.TextBlock.Text = "";
            this.chartStopCount.ChartTitle.Visible = false;
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
            this.chartStopCount.CustomPalettes.AddRange(new Telerik.Reporting.Charting.Palette[] {
            palette1});
            this.chartStopCount.DefaultType = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chartStopCount.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chartStopCount.IntelligentLabelsEnabled = true;
            chartMargins2.Right = new Telerik.Reporting.Charting.Styles.Unit(2D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.Legend.Appearance.Dimensions.Margins = chartMargins2;
            this.chartStopCount.Legend.Appearance.ItemTextAppearance.TextProperties.Font = new System.Drawing.Font("Verdana", 6.4F);
            this.chartStopCount.Legend.TextBlock.Appearance.Dimensions.AutoSize = false;
            this.chartStopCount.Legend.TextBlock.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.Legend.TextBlock.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.Legend.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6F);
            this.chartStopCount.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9921220680698752E-05D), Telerik.Reporting.Drawing.Unit.Cm(11.477388381958008D));
            this.chartStopCount.Name = "chartStopCount";
            this.chartStopCount.PlotArea.Appearance.Border.Visible = false;
            chartMargins3.Right = new Telerik.Reporting.Charting.Styles.Unit(160D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.PlotArea.Appearance.Dimensions.Margins = chartMargins3;
            this.chartStopCount.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartStopCount.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chartStopCount.PlotArea.Appearance.SeriesPalette = "Palette1";
            this.chartStopCount.PlotArea.EmptySeriesMessage.TextBlock.Visible = false;
            this.chartStopCount.PlotArea.XAxis.MinValue = 1D;
            chartSeries1.Appearance.CenterXOffset = -30;
            chartSeries1.Appearance.DiameterScale = 0.85D;
            chartSeries1.Appearance.LegendDisplayMode = Telerik.Reporting.Charting.ChartSeriesLegendDisplayMode.ItemLabels;
            chartSeries1.Appearance.ShowLabels = false;
            chartSeries1.DataLabelsColumn = "ReasonWithMachinePrefix";
            chartSeries1.DataYColumn = "NumberOfStops";
            chartSeries1.DefaultLabelValue = "";
            chartSeries1.Name = "Series 1";
            chartSeries1.Type = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chartStopCount.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries1});
            this.chartStopCount.SeriesPalette = "Palette1";
            this.chartStopCount.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.299799919128418D), Telerik.Reporting.Drawing.Unit.Cm(3.6999993324279785D));
            this.chartStopCount.Style.BackgroundColor = System.Drawing.SystemColors.Control;
            this.chartStopCount.Style.Visible = true;
            this.chartStopCount.NeedDataSource += new System.EventHandler(this.chartStopCount_NeedDataSource);
            // 
            // chartStopTime
            // 
            this.chartStopTime.Appearance.Border.Visible = false;
            this.chartStopTime.Appearance.Dimensions.AutoSize = false;
            this.chartStopTime.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(139D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins4.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins4.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins4.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins4.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopTime.Appearance.Dimensions.Margins = chartMargins4;
            chartPaddings2.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings2.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings2.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartPaddings2.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopTime.Appearance.Dimensions.Paddings = chartPaddings2;
            this.chartStopTime.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(351D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopTime.BitmapResolution = 192F;
            this.chartStopTime.ChartTitle.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartStopTime.ChartTitle.Appearance.Visible = false;
            this.chartStopTime.ChartTitle.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 12F);
            this.chartStopTime.ChartTitle.TextBlock.Text = "Fördelning av stopptid";
            this.chartStopTime.ChartTitle.Visible = false;
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
            this.chartStopTime.CustomPalettes.AddRange(new Telerik.Reporting.Charting.Palette[] {
            palette2});
            this.chartStopTime.DefaultType = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chartStopTime.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chartStopTime.IntelligentLabelsEnabled = true;
            chartMargins5.Right = new Telerik.Reporting.Charting.Styles.Unit(2D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopTime.Legend.Appearance.Dimensions.Margins = chartMargins5;
            this.chartStopTime.Legend.Appearance.ItemTextAppearance.TextProperties.Font = new System.Drawing.Font("Verdana", 6.4F);
            this.chartStopTime.Legend.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6F);
            this.chartStopTime.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(11.477388381958008D));
            this.chartStopTime.Name = "chartStopTime";
            this.chartStopTime.PlotArea.Appearance.Border.Visible = false;
            chartMargins6.Right = new Telerik.Reporting.Charting.Styles.Unit(160D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopTime.PlotArea.Appearance.Dimensions.Margins = chartMargins6;
            this.chartStopTime.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartStopTime.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chartStopTime.PlotArea.Appearance.SeriesPalette = "Palette1";
            this.chartStopTime.PlotArea.EmptySeriesMessage.TextBlock.Text = "";
            this.chartStopTime.PlotArea.EmptySeriesMessage.TextBlock.Visible = false;
            this.chartStopTime.PlotArea.XAxis.MinValue = 1D;
            chartSeries2.Appearance.CenterXOffset = -30;
            chartSeries2.Appearance.DiameterScale = 0.85D;
            chartSeries2.Appearance.LegendDisplayMode = Telerik.Reporting.Charting.ChartSeriesLegendDisplayMode.ItemLabels;
            chartSeries2.Appearance.ShowLabels = false;
            chartSeries2.DataLabelsColumn = "ReasonWithMachinePrefix";
            chartSeries2.DataYColumn = "ElapsedTimeInSeconds";
            chartSeries2.Name = "Series 1";
            chartSeries2.Type = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chartStopTime.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries2});
            this.chartStopTime.SeriesPalette = "Palette1";
            this.chartStopTime.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.29990291595459D), Telerik.Reporting.Drawing.Unit.Cm(3.6999969482421875D));
            this.chartStopTime.Style.BackgroundColor = System.Drawing.SystemColors.Control;
            this.chartStopTime.NeedDataSource += new System.EventHandler(this.chartStopTime_NeedDataSource);
            // 
            // list1
            // 
            this.list1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D)));
            this.list1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(2.320000171661377D)));
            this.list1.Body.SetCellContent(0, 0, this.panel1);
            tableGroup10.Name = "ColumnGroup1";
            this.list1.ColumnGroups.Add(tableGroup10);
            this.list1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1});
            this.list1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.list1.Name = "list1";
            tableGroup11.Name = "RowGroup1";
            this.list1.RowGroups.Add(tableGroup11);
            this.list1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(2.320000171661377D));
            this.list1.NeedDataSource += new System.EventHandler(this.list1_NeedDataSource);
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            panelOverview});
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(2.320000171661377D));
            // 
            // chartPeriodicOee
            // 
            this.chartPeriodicOee.Appearance.BarWidthPercent = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.chartPeriodicOee.Appearance.Border.Visible = false;
            this.chartPeriodicOee.BitmapResolution = 96F;
            this.chartPeriodicOee.ChartTitle.Appearance.Border.Visible = false;
            this.chartPeriodicOee.ChartTitle.Appearance.Dimensions.AutoSize = false;
            this.chartPeriodicOee.ChartTitle.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(24D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins7.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins7.Left = new Telerik.Reporting.Charting.Styles.Unit(7D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins7.Right = new Telerik.Reporting.Charting.Styles.Unit(10D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins7.Top = new Telerik.Reporting.Charting.Styles.Unit(3D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            this.chartPeriodicOee.ChartTitle.Appearance.Dimensions.Margins = chartMargins7;
            this.chartPeriodicOee.ChartTitle.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(253.40625D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartPeriodicOee.ChartTitle.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartPeriodicOee.ChartTitle.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chartPeriodicOee.ChartTitle.Appearance.Position.AlignedPosition = Telerik.Reporting.Charting.Styles.AlignedPositions.Top;
            this.chartPeriodicOee.ChartTitle.Appearance.Visible = false;
            this.chartPeriodicOee.ChartTitle.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartPeriodicOee.ChartTitle.TextBlock.Text = "TAK/OEE per produktionsdag";
            this.chartPeriodicOee.ChartTitle.Visible = false;
            paletteItem13.MainColor = System.Drawing.Color.DarkBlue;
            paletteItem13.Name = "PalletteOee";
            paletteItem13.SecondColor = System.Drawing.Color.Blue;
            paletteItem14.MainColor = System.Drawing.Color.RoyalBlue;
            paletteItem14.Name = "PaletteAvailabilityLoss";
            paletteItem14.SecondColor = System.Drawing.Color.LightBlue;
            paletteItem15.MainColor = System.Drawing.Color.DarkGray;
            paletteItem15.Name = "PaletteRunRateLoss";
            paletteItem15.SecondColor = System.Drawing.Color.LightGray;
            paletteItem16.MainColor = System.Drawing.Color.Gainsboro;
            paletteItem16.Name = "PaletteQualityLoss";
            paletteItem16.SecondColor = System.Drawing.Color.WhiteSmoke;
            palette3.Items.AddRange(new Telerik.Reporting.Charting.PaletteItem[] {
            paletteItem13,
            paletteItem14,
            paletteItem15,
            paletteItem16});
            palette3.Name = "Palette1";
            this.chartPeriodicOee.CustomPalettes.AddRange(new Telerik.Reporting.Charting.Palette[] {
            palette3});
            this.chartPeriodicOee.DefaultType = Telerik.Reporting.Charting.ChartSeriesType.StackedBar100;
            this.chartPeriodicOee.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chartPeriodicOee.IntelligentLabelsEnabled = true;
            this.chartPeriodicOee.Legend.Appearance.Border.Color = System.Drawing.Color.White;
            this.chartPeriodicOee.Legend.Appearance.Border.Visible = false;
            this.chartPeriodicOee.Legend.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartPeriodicOee.Legend.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chartPeriodicOee.Legend.Appearance.ItemTextAppearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartPeriodicOee.Legend.Appearance.Overflow = Telerik.Reporting.Charting.Styles.Overflow.Row;
            this.chartPeriodicOee.Legend.Appearance.Position.AlignedPosition = Telerik.Reporting.Charting.Styles.AlignedPositions.Bottom;
            this.chartPeriodicOee.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(2.8199996948242188D));
            this.chartPeriodicOee.Name = "chartPeriodicOee";
            this.chartPeriodicOee.PlotArea.Appearance.Border.Visible = false;
            chartMargins8.Bottom = new Telerik.Reporting.Charting.Styles.Unit(80D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins8.Left = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins8.Right = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins8.Top = new Telerik.Reporting.Charting.Styles.Unit(20D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartPeriodicOee.PlotArea.Appearance.Dimensions.Margins = chartMargins8;
            this.chartPeriodicOee.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartPeriodicOee.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chartPeriodicOee.PlotArea.Appearance.SeriesPalette = "Palette1";
            this.chartPeriodicOee.PlotArea.EmptySeriesMessage.TextBlock.Text = "Det saknas värden för intervallet";
            this.chartPeriodicOee.PlotArea.EmptySeriesMessage.TextBlock.Visible = false;
            chartMargins9.Top = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartPeriodicOee.PlotArea.XAxis.Appearance.LabelAppearance.Dimensions.Margins = chartMargins9;
            this.chartPeriodicOee.PlotArea.XAxis.Appearance.LabelAppearance.RotationAngle = 270F;
            this.chartPeriodicOee.PlotArea.XAxis.Appearance.TextAppearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartPeriodicOee.PlotArea.XAxis.AutoScale = false;
            this.chartPeriodicOee.PlotArea.XAxis.DataLabelsColumn = "XLabel";
            this.chartPeriodicOee.PlotArea.XAxis.IsZeroBased = false;
            chartMargins10.Top = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartAxisItem1.Appearance.Dimensions.Margins = chartMargins10;
            chartAxisItem1.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            chartMargins11.Top = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartAxisItem2.Appearance.Dimensions.Margins = chartMargins11;
            chartAxisItem2.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            chartMargins12.Top = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartAxisItem3.Appearance.Dimensions.Margins = chartMargins12;
            chartAxisItem3.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem3.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            chartMargins13.Top = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartAxisItem4.Appearance.Dimensions.Margins = chartMargins13;
            chartAxisItem4.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem4.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            chartMargins14.Top = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartAxisItem5.Appearance.Dimensions.Margins = chartMargins14;
            chartAxisItem5.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem5.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            chartMargins15.Top = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartAxisItem6.Appearance.Dimensions.Margins = chartMargins15;
            chartAxisItem6.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem6.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            chartMargins16.Top = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartAxisItem7.Appearance.Dimensions.Margins = chartMargins16;
            chartAxisItem7.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem7.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.chartPeriodicOee.PlotArea.XAxis.Items.AddRange(new Telerik.Reporting.Charting.ChartAxisItem[] {
            chartAxisItem1,
            chartAxisItem2,
            chartAxisItem3,
            chartAxisItem4,
            chartAxisItem5,
            chartAxisItem6,
            chartAxisItem7});
            this.chartPeriodicOee.PlotArea.XAxis.MaxItemsCount = 100;
            this.chartPeriodicOee.PlotArea.XAxis.MinValue = 1D;
            this.chartPeriodicOee.PlotArea.YAxis.Appearance.TextAppearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartPeriodicOee.PlotArea.YAxis.AutoScale = false;
            this.chartPeriodicOee.PlotArea.YAxis.IsZeroBased = false;
            chartAxisItem8.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem9.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem9.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            chartAxisItem10.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem10.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            chartAxisItem11.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem11.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            chartAxisItem12.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem12.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            chartAxisItem13.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem13.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.chartPeriodicOee.PlotArea.YAxis.Items.AddRange(new Telerik.Reporting.Charting.ChartAxisItem[] {
            chartAxisItem8,
            chartAxisItem9,
            chartAxisItem10,
            chartAxisItem11,
            chartAxisItem12,
            chartAxisItem13});
            this.chartPeriodicOee.PlotArea.YAxis.MaxValue = 100D;
            this.chartPeriodicOee.PlotArea.YAxis.Step = 20D;
            chartSeries3.Appearance.Border.Color = System.Drawing.Color.Black;
            chartSeries3.Appearance.LabelAppearance.LabelLocation = Telerik.Reporting.Charting.Styles.StyleSeriesItemLabel.ItemLabelLocation.Outside;
            chartSeries3.Appearance.ShowLabels = false;
            chartSeries3.DataYColumn = "OeeNpb";
            chartSeries3.DefaultLabelValue = "";
            chartSeries3.Name = "TAK";
            chartSeries3.Type = Telerik.Reporting.Charting.ChartSeriesType.StackedBar100;
            chartSeries4.Appearance.Border.Color = System.Drawing.Color.Black;
            chartSeries4.Appearance.FillStyle.FillSettings.ImageAlign = Telerik.Reporting.Charting.Styles.ImageAlignModes.Top;
            chartSeries4.Appearance.LabelAppearance.LabelLocation = Telerik.Reporting.Charting.Styles.StyleSeriesItemLabel.ItemLabelLocation.Outside;
            chartSeries4.Appearance.LabelAppearance.Position.Auto = false;
            chartSeries4.Appearance.LabelAppearance.Position.X = 0F;
            chartSeries4.Appearance.LabelAppearance.Position.Y = 0F;
            chartSeries4.Appearance.LabelAppearance.Visible = false;
            chartSeries4.Appearance.ShowLabels = false;
            chartSeries4.DataYColumn = "NonAvailabilityNpb";
            chartSeries4.DefaultLabelValue = "";
            chartSeries4.Name = "Tillgänglighetsförlust";
            chartSeries4.Type = Telerik.Reporting.Charting.ChartSeriesType.StackedBar100;
            chartSeries5.Appearance.Border.Color = System.Drawing.Color.Black;
            chartSeries5.Appearance.LabelAppearance.LabelLocation = Telerik.Reporting.Charting.Styles.StyleSeriesItemLabel.ItemLabelLocation.Outside;
            chartSeries5.Appearance.LabelAppearance.Position.Auto = false;
            chartSeries5.Appearance.LabelAppearance.Position.X = 0F;
            chartSeries5.Appearance.LabelAppearance.Position.Y = 0F;
            chartSeries5.Appearance.LabelAppearance.Visible = false;
            chartSeries5.Appearance.ShowLabels = false;
            chartSeries5.DataYColumn = "RunRateLossNpb";
            chartSeries5.DefaultLabelValue = "";
            chartSeries5.Name = "Hastighetsförlust";
            chartSeries5.Type = Telerik.Reporting.Charting.ChartSeriesType.StackedBar100;
            chartSeries6.Appearance.Border.Color = System.Drawing.Color.Black;
            chartSeries6.Appearance.LabelAppearance.LabelLocation = Telerik.Reporting.Charting.Styles.StyleSeriesItemLabel.ItemLabelLocation.Outside;
            chartSeries6.Appearance.LabelAppearance.Position.Auto = false;
            chartSeries6.Appearance.LabelAppearance.Position.X = 0F;
            chartSeries6.Appearance.LabelAppearance.Position.Y = 0F;
            chartSeries6.Appearance.LabelAppearance.Visible = false;
            chartSeries6.Appearance.ShowLabels = false;
            chartSeries6.DataYColumn = "QualityLoss";
            chartSeries6.DefaultLabelValue = "";
            chartSeries6.Name = "Kvalitetsförlust";
            chartSeries6.Type = Telerik.Reporting.Charting.ChartSeriesType.StackedBar100;
            this.chartPeriodicOee.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries3,
            chartSeries4,
            chartSeries5,
            chartSeries6});
            this.chartPeriodicOee.SeriesPalette = "Palette1";
            this.chartPeriodicOee.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(6.3000001907348633D));
            this.chartPeriodicOee.NeedDataSource += new System.EventHandler(this.chartPeriodicOee_NeedDataSource);
            // 
            // tableMachines
            // 
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.29217267036438D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.2517257928848267D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.2016565799713135D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.2016565799713135D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.2016565799713135D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.2016565799713135D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.2016565799713135D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.2016565799713135D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.3728463649749756D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.4048736095428467D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.0027616024017334D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.0027616024017334D)));
            this.tableMachines.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.4889962375164032D)));
            this.tableMachines.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.38100358843803406D)));
            this.tableMachines.Body.SetCellContent(0, 0, this.textBox14);
            this.tableMachines.Body.SetCellContent(0, 1, this.textBox39);
            this.tableMachines.Body.SetCellContent(1, 0, this.textBox40);
            this.tableMachines.Body.SetCellContent(1, 1, this.textBox41);
            this.tableMachines.Body.SetCellContent(0, 6, this.textBox48);
            this.tableMachines.Body.SetCellContent(1, 6, this.textBox49);
            this.tableMachines.Body.SetCellContent(0, 7, this.textBox51);
            this.tableMachines.Body.SetCellContent(1, 7, this.textBox52);
            this.tableMachines.Body.SetCellContent(0, 11, this.textBox55);
            this.tableMachines.Body.SetCellContent(1, 11, this.textBox56);
            this.tableMachines.Body.SetCellContent(0, 10, this.textBox57);
            this.tableMachines.Body.SetCellContent(1, 10, this.textBox58);
            this.tableMachines.Body.SetCellContent(0, 8, this.textBox5);
            this.tableMachines.Body.SetCellContent(1, 8, this.textBox10);
            this.tableMachines.Body.SetCellContent(0, 9, this.textBox11);
            this.tableMachines.Body.SetCellContent(1, 9, this.textBox25);
            this.tableMachines.Body.SetCellContent(0, 2, this.textBox30);
            this.tableMachines.Body.SetCellContent(1, 2, this.textBox31);
            this.tableMachines.Body.SetCellContent(0, 3, this.textBox85);
            this.tableMachines.Body.SetCellContent(0, 4, this.textBox115);
            this.tableMachines.Body.SetCellContent(0, 5, this.textBox38);
            this.tableMachines.Body.SetCellContent(1, 3, this.textBox42);
            this.tableMachines.Body.SetCellContent(1, 4, this.textBox117);
            this.tableMachines.Body.SetCellContent(1, 5, this.textBox116);
            tableGroup14.Name = "Group4";
            tableGroup15.Name = "group";
            tableGroup16.Name = "group1";
            tableGroup17.Name = "Group1";
            tableGroup18.Name = "Group2";
            tableGroup19.Name = "Group3";
            tableGroup20.Name = "Group8";
            tableGroup21.Name = "Group9";
            tableGroup22.Name = "Group6";
            tableGroup23.Name = "Group5";
            this.tableMachines.ColumnGroups.Add(tableGroup12);
            this.tableMachines.ColumnGroups.Add(tableGroup13);
            this.tableMachines.ColumnGroups.Add(tableGroup14);
            this.tableMachines.ColumnGroups.Add(tableGroup15);
            this.tableMachines.ColumnGroups.Add(tableGroup16);
            this.tableMachines.ColumnGroups.Add(tableGroup17);
            this.tableMachines.ColumnGroups.Add(tableGroup18);
            this.tableMachines.ColumnGroups.Add(tableGroup19);
            this.tableMachines.ColumnGroups.Add(tableGroup20);
            this.tableMachines.ColumnGroups.Add(tableGroup21);
            this.tableMachines.ColumnGroups.Add(tableGroup22);
            this.tableMachines.ColumnGroups.Add(tableGroup23);
            this.tableMachines.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox14,
            this.textBox39,
            this.textBox30,
            this.textBox85,
            this.textBox115,
            this.textBox38,
            this.textBox48,
            this.textBox51,
            this.textBox5,
            this.textBox11,
            this.textBox57,
            this.textBox55,
            this.textBox40,
            this.textBox41,
            this.textBox31,
            this.textBox42,
            this.textBox117,
            this.textBox116,
            this.textBox49,
            this.textBox52,
            this.textBox10,
            this.textBox25,
            this.textBox58,
            this.textBox56});
            this.tableMachines.KeepTogether = false;
            this.tableMachines.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(9.9199991226196289D));
            this.tableMachines.Name = "tableMachines";
            tableGroup26.Name = "Group7";
            tableGroup25.ChildGroups.Add(tableGroup26);
            tableGroup25.Groupings.Add(new Telerik.Reporting.Grouping(""));
            tableGroup25.Name = "detailGroup";
            this.tableMachines.RowGroups.Add(tableGroup24);
            this.tableMachines.RowGroups.Add(tableGroup25);
            this.tableMachines.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.537080764770508D), Telerik.Reporting.Drawing.Unit.Cm(0.86999982595443726D));
            this.tableMachines.Style.BackgroundColor = System.Drawing.Color.White;
            this.tableMachines.Style.Visible = true;
            this.tableMachines.NeedDataSource += new System.EventHandler(this.tableMachines_NeedDataSource);
            // 
            // textBox14
            // 
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2921724319458008D), Telerik.Reporting.Drawing.Unit.Cm(0.48899626731872559D));
            this.textBox14.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox14.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox14.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox14.Style.Font.Bold = true;
            this.textBox14.Style.Font.Italic = false;
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            // 
            // textBox39
            // 
            this.textBox39.Name = "textBox39";
            this.textBox39.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2517257928848267D), Telerik.Reporting.Drawing.Unit.Cm(0.48899641633033752D));
            this.textBox39.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox39.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox39.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox39.Style.Font.Bold = false;
            this.textBox39.Style.Font.Italic = false;
            this.textBox39.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox39.Value = "TAK/OEEr";
            // 
            // textBox40
            // 
            this.textBox40.Name = "textBox40";
            this.textBox40.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2921724319458008D), Telerik.Reporting.Drawing.Unit.Cm(0.38100358843803406D));
            this.textBox40.Style.Font.Bold = false;
            this.textBox40.Style.Font.Italic = false;
            this.textBox40.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox40.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox40.Value = "=Fields.Machine";
            // 
            // textBox41
            // 
            this.textBox41.Format = "{0:P1}";
            this.textBox41.Name = "textBox41";
            this.textBox41.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2517257928848267D), Telerik.Reporting.Drawing.Unit.Cm(0.38100358843803406D));
            this.textBox41.Style.Font.Italic = false;
            this.textBox41.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox41.Value = "=Fields.Oee";
            // 
            // textBox48
            // 
            this.textBox48.Name = "textBox48";
            this.textBox48.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2016569375991821D), Telerik.Reporting.Drawing.Unit.Cm(0.48899641633033752D));
            this.textBox48.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox48.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox48.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox48.Style.Font.Bold = false;
            this.textBox48.Style.Font.Italic = false;
            this.textBox48.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox48.Value = "Ar";
            // 
            // textBox49
            // 
            this.textBox49.Format = "{0:P1}";
            this.textBox49.Name = "textBox49";
            this.textBox49.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2016569375991821D), Telerik.Reporting.Drawing.Unit.Cm(0.38100358843803406D));
            this.textBox49.Style.Font.Italic = false;
            this.textBox49.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox49.Value = "=Fields.PerformanceNpb";
            // 
            // textBox51
            // 
            this.textBox51.Name = "textBox51";
            this.textBox51.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2016569375991821D), Telerik.Reporting.Drawing.Unit.Cm(0.48899641633033752D));
            this.textBox51.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox51.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox51.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox51.Style.Font.Bold = false;
            this.textBox51.Style.Font.Italic = false;
            this.textBox51.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox51.Value = "K";
            // 
            // textBox52
            // 
            this.textBox52.Format = "{0:P2}";
            this.textBox52.Name = "textBox52";
            this.textBox52.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2016569375991821D), Telerik.Reporting.Drawing.Unit.Cm(0.38100358843803406D));
            this.textBox52.Style.Font.Italic = false;
            this.textBox52.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox52.Value = "=Fields.Quality";
            // 
            // textBox55
            // 
            this.textBox55.Name = "textBox55";
            this.textBox55.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0027611255645752D), Telerik.Reporting.Drawing.Unit.Cm(0.48899641633033752D));
            this.textBox55.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox55.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox55.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox55.Style.Font.Bold = false;
            this.textBox55.Style.Font.Italic = false;
            this.textBox55.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox55.StyleName = "";
            this.textBox55.Value = "Stopptid";
            // 
            // textBox56
            // 
            this.textBox56.Format = "{0:N1} tim";
            this.textBox56.Name = "textBox56";
            this.textBox56.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0027611255645752D), Telerik.Reporting.Drawing.Unit.Cm(0.38100358843803406D));
            this.textBox56.Style.Font.Italic = false;
            this.textBox56.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox56.StyleName = "";
            this.textBox56.Value = "=Fields.StopTimeInHours";
            // 
            // textBox57
            // 
            this.textBox57.Name = "textBox57";
            this.textBox57.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0027611255645752D), Telerik.Reporting.Drawing.Unit.Cm(0.48899641633033752D));
            this.textBox57.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox57.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox57.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox57.Style.Font.Bold = false;
            this.textBox57.Style.Font.Italic = false;
            this.textBox57.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox57.StyleName = "";
            this.textBox57.Value = "Prod. tid";
            // 
            // textBox58
            // 
            this.textBox58.Format = "{0:N1} tim";
            this.textBox58.Name = "textBox58";
            this.textBox58.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0027611255645752D), Telerik.Reporting.Drawing.Unit.Cm(0.38100358843803406D));
            this.textBox58.Style.Font.Italic = false;
            this.textBox58.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox58.StyleName = "";
            this.textBox58.Value = "=Fields.ProductionTimeNpb";
            // 
            // textBox5
            // 
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.3728461265563965D), Telerik.Reporting.Drawing.Unit.Cm(0.48899626731872559D));
            this.textBox5.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox5.Style.Font.Bold = false;
            this.textBox5.Style.Font.Italic = false;
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox5.StyleName = "";
            this.textBox5.Value = "Producerat antal";
            // 
            // textBox10
            // 
            this.textBox10.Format = "{0:N0}";
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.3728461265563965D), Telerik.Reporting.Drawing.Unit.Cm(0.38100358843803406D));
            this.textBox10.Style.Font.Italic = false;
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox10.StyleName = "";
            this.textBox10.Value = "=Fields.ProducedItems";
            // 
            // textBox11
            // 
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.4048739671707153D), Telerik.Reporting.Drawing.Unit.Cm(0.48899626731872559D));
            this.textBox11.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox11.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox11.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox11.Style.Font.Bold = false;
            this.textBox11.Style.Font.Italic = false;
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox11.StyleName = "";
            this.textBox11.Value = "Antal stopp";
            // 
            // textBox25
            // 
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.4048739671707153D), Telerik.Reporting.Drawing.Unit.Cm(0.38100358843803406D));
            this.textBox25.Style.Font.Italic = false;
            this.textBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox25.StyleName = "";
            this.textBox25.Value = "=Fields.NumberOfStops";
            // 
            // textBox30
            // 
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2016569375991821D), Telerik.Reporting.Drawing.Unit.Cm(0.48899641633033752D));
            this.textBox30.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox30.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox30.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox30.Style.Font.Bold = false;
            this.textBox30.Style.Font.Italic = false;
            this.textBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox30.Value = "T";
            // 
            // textBox31
            // 
            this.textBox31.Format = "{0:P1}";
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2016569375991821D), Telerik.Reporting.Drawing.Unit.Cm(0.38100358843803406D));
            this.textBox31.Style.Font.Italic = false;
            this.textBox31.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox31.Value = "=Fields.Availability";
            // 
            // textBox85
            // 
            this.textBox85.Name = "textBox85";
            this.textBox85.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2016569375991821D), Telerik.Reporting.Drawing.Unit.Cm(0.48899641633033752D));
            this.textBox85.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox85.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox85.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox85.Style.Font.Bold = false;
            this.textBox85.Style.Font.Italic = false;
            this.textBox85.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox85.StyleName = "";
            this.textBox85.Value = "Ts";
            // 
            // textBox115
            // 
            this.textBox115.Name = "textBox115";
            this.textBox115.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2016569375991821D), Telerik.Reporting.Drawing.Unit.Cm(0.48899641633033752D));
            this.textBox115.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox115.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox115.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox115.Style.Font.Bold = false;
            this.textBox115.Style.Font.Italic = false;
            this.textBox115.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox115.StyleName = "";
            this.textBox115.Value = "Fs";
            // 
            // textBox38
            // 
            this.textBox38.Name = "textBox38";
            this.textBox38.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2016569375991821D), Telerik.Reporting.Drawing.Unit.Cm(0.48899641633033752D));
            this.textBox38.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox38.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox38.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox38.Style.Font.Bold = false;
            this.textBox38.Style.Font.Italic = false;
            this.textBox38.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox38.StyleName = "";
            this.textBox38.Value = "Ff";
            // 
            // textBox42
            // 
            this.textBox42.Format = "{0:P1}";
            this.textBox42.Name = "textBox42";
            this.textBox42.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2016569375991821D), Telerik.Reporting.Drawing.Unit.Cm(0.38100358843803406D));
            this.textBox42.Style.Font.Bold = false;
            this.textBox42.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox42.StyleName = "";
            this.textBox42.Value = "=Fields.AvailabilityBasedOnActualStops";
            // 
            // textBox117
            // 
            this.textBox117.Format = "{0:P1}";
            this.textBox117.Name = "textBox117";
            this.textBox117.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2016569375991821D), Telerik.Reporting.Drawing.Unit.Cm(0.38100358843803406D));
            this.textBox117.Style.Font.Bold = false;
            this.textBox117.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox117.StyleName = "";
            this.textBox117.Value = "=Fields.AvailabilityLossBasedOnActualStops";
            // 
            // textBox116
            // 
            this.textBox116.Format = "{0:P1}";
            this.textBox116.Name = "textBox116";
            this.textBox116.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.2016569375991821D), Telerik.Reporting.Drawing.Unit.Cm(0.38100358843803406D));
            this.textBox116.Style.Font.Bold = false;
            this.textBox116.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox116.StyleName = "";
            this.textBox116.Value = "=Fields.AvailabilityLossBasedOnFlowErrors";
            // 
            // panel8
            // 
            this.panel8.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel9,
            this.textBox12});
            this.panel8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(9.3199996948242188D));
            this.panel8.Name = "panel8";
            this.panel8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(0.35718747973442078D));
            // 
            // panel9
            // 
            this.panel9.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.panel9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.22489582002162933D));
            this.panel9.Name = "panel9";
            this.panel9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(0.13229167461395264D));
            this.panel9.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.panel9.Style.BackgroundImage.MimeType = "";
            this.panel9.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.RepeatX;
            this.panel9.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel9.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.panel9.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            // 
            // textBox12
            // 
            this.textBox12.CanShrink = false;
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.627291202545166D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.textBox12.Multiline = false;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6799999475479126D), Telerik.Reporting.Drawing.Unit.Cm(0.34000000357627869D));
            this.textBox12.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox12.Style.Font.Italic = false;
            this.textBox12.Style.Font.Name = "Calibri";
            this.textBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox12.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox12.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.TextWrap = false;
            this.textBox12.Value = "Fördelning av tid";
            // 
            // panel7
            // 
            this.panel7.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel3,
            this.textBox13});
            this.panel7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(11.119998931884766D));
            this.panel7.Name = "panel7";
            this.panel7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.90000057220459D), Telerik.Reporting.Drawing.Unit.Cm(0.35718747973442078D));
            // 
            // panel3
            // 
            this.panel3.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.panel3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.22489582002162933D));
            this.panel3.Name = "panel3";
            this.panel3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.90000057220459D), Telerik.Reporting.Drawing.Unit.Cm(0.13229167461395264D));
            this.panel3.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.panel3.Style.BackgroundImage.MimeType = "";
            this.panel3.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.RepeatX;
            this.panel3.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.panel3.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            // 
            // textBox13
            // 
            this.textBox13.CanShrink = false;
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.627291202545166D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.textBox13.Multiline = false;
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6799999475479126D), Telerik.Reporting.Drawing.Unit.Cm(0.34000000357627869D));
            this.textBox13.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox13.Style.Font.Italic = false;
            this.textBox13.Style.Font.Name = "Calibri";
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox13.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox13.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.TextWrap = false;
            this.textBox13.Value = "Fördelning av tid";
            // 
            // panel5
            // 
            this.panel5.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel6,
            this.textBox15});
            this.panel5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(11.119998931884766D));
            this.panel5.Name = "panel5";
            this.panel5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.90000057220459D), Telerik.Reporting.Drawing.Unit.Cm(0.35718747973442078D));
            // 
            // panel6
            // 
            this.panel6.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.panel6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.22489582002162933D));
            this.panel6.Name = "panel6";
            this.panel6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.90000057220459D), Telerik.Reporting.Drawing.Unit.Cm(0.13229167461395264D));
            this.panel6.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.panel6.Style.BackgroundImage.MimeType = "";
            this.panel6.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.RepeatX;
            this.panel6.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel6.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.panel6.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            // 
            // textBox15
            // 
            this.textBox15.CanShrink = false;
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.627291202545166D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.textBox15.Multiline = false;
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6799999475479126D), Telerik.Reporting.Drawing.Unit.Cm(0.34000000357627869D));
            this.textBox15.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox15.Style.Font.Italic = false;
            this.textBox15.Style.Font.Name = "Calibri";
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox15.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox15.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox15.TextWrap = false;
            this.textBox15.Value = "Fördelning av tid";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(2.6800000667572021D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel2,
            this.textBox17,
            this.textBox16,
            this.textBox23,
            this.textBox24,
            this.panel4,
            this.textBox26,
            this.textBox43});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            this.pageHeaderSection1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pageHeaderSection1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.pageHeaderSection1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            // 
            // panel2
            // 
            this.panel2.Docking = Telerik.Reporting.DockingStyle.Left;
            this.panel2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pictureBox1});
            this.panel2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel2.Name = "panel2";
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.5D), Telerik.Reporting.Drawing.Unit.Cm(2.6800000667572021D));
            this.panel2.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D), Telerik.Reporting.Drawing.Unit.Cm(0.70000004768371582D));
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.90000057220459D), Telerik.Reporting.Drawing.Unit.Cm(1.4000000953674316D));
            this.pictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            // 
            // textBox17
            // 
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.050000190734863D), Telerik.Reporting.Drawing.Unit.Cm(0.99000000953674316D));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8899999856948853D), Telerik.Reporting.Drawing.Unit.Cm(0.38999998569488525D));
            this.textBox17.Style.Color = System.Drawing.Color.Gray;
            this.textBox17.Style.Font.Italic = true;
            this.textBox17.Style.Font.Name = "Calibri";
            this.textBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox17.Style.Visible = true;
            this.textBox17.StyleName = "Title";
            this.textBox17.Value = "Maskin:";
            // 
            // textBox16
            // 
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6600000858306885D), Telerik.Reporting.Drawing.Unit.Cm(0.38999998569488525D));
            this.textBox16.Style.Color = System.Drawing.Color.Black;
            this.textBox16.Style.Font.Name = "Calibri";
            this.textBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox16.Style.Visible = true;
            this.textBox16.StyleName = "Title";
            this.textBox16.Value = "=Fields.Grouping";
            // 
            // textBox23
            // 
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13D), Telerik.Reporting.Drawing.Unit.Cm(0.99000000953674316D));
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6600000858306885D), Telerik.Reporting.Drawing.Unit.Cm(0.38999998569488525D));
            this.textBox23.Style.Color = System.Drawing.Color.Black;
            this.textBox23.Style.Font.Name = "Calibri";
            this.textBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox23.Style.Visible = true;
            this.textBox23.StyleName = "Title";
            this.textBox23.Value = "=Fields.Division";
            // 
            // textBox24
            // 
            this.textBox24.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.050000190734863D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8899999856948853D), Telerik.Reporting.Drawing.Unit.Cm(0.38999998569488525D));
            this.textBox24.Style.Color = System.Drawing.Color.Gray;
            this.textBox24.Style.Font.Italic = true;
            this.textBox24.Style.Font.Name = "Calibri";
            this.textBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox24.Style.Visible = true;
            this.textBox24.StyleName = "Title";
            this.textBox24.Value = "Module:";
            // 
            // panel4
            // 
            this.panel4.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.shape1,
            this.tbShapeRow2});
            this.panel4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.9399995803833D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel4.Name = "panel4";
            this.panel4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.3599998950958252D), Telerik.Reporting.Drawing.Unit.Cm(2.6800000667572021D));
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
            this.tbShapeRow2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D));
            this.tbShapeRow2.Name = "tbShapeRow2";
            this.tbShapeRow2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.357297420501709D), Telerik.Reporting.Drawing.Unit.Cm(0.61635404825210571D));
            this.tbShapeRow2.Style.Color = System.Drawing.Color.White;
            this.tbShapeRow2.Style.Font.Bold = true;
            this.tbShapeRow2.Style.Font.Name = "Calibri";
            this.tbShapeRow2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16D);
            this.tbShapeRow2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tbShapeRow2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbShapeRow2.Value = "=Fields.PeriodStart";
            // 
            // textBox26
            // 
            this.textBox26.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6D), Telerik.Reporting.Drawing.Unit.Cm(0.60000008344650269D));
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.62999999523162842D));
            this.textBox26.Style.Color = System.Drawing.Color.Black;
            this.textBox26.Style.Font.Name = "Calibri";
            this.textBox26.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.textBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox26.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox26.Style.Visible = true;
            this.textBox26.StyleName = "Title";
            this.textBox26.Value = "Report";
            // 
            // textBox43
            // 
            this.textBox43.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6D), Telerik.Reporting.Drawing.Unit.Cm(1.674972414970398D));
            this.textBox43.Name = "textBox43";
            this.textBox43.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.62999999523162842D));
            this.textBox43.Style.Color = System.Drawing.Color.Black;
            this.textBox43.Style.Font.Name = "Calibri";
            this.textBox43.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox43.Style.Font.Strikeout = false;
            this.textBox43.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox43.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox43.Style.Visible = true;
            this.textBox43.StyleName = "Title";
            this.textBox43.Value = "=Fields.Range";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.0099999904632568D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox47,
            this.textBox46,
            this.textBox45,
            this.textBox28,
            this.textBox44,
            this.textBox50,
            this.pictureBoxLogo});
            this.pageFooterSection1.Name = "pageFooterSection1";
            this.pageFooterSection1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.pageFooterSection1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pageFooterSection1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            // 
            // textBox47
            // 
            this.textBox47.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.3999999761581421D), Telerik.Reporting.Drawing.Unit.Cm(0.62999999523162842D));
            this.textBox47.Name = "textBox47";
            this.textBox47.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.37000000476837158D), Telerik.Reporting.Drawing.Unit.Cm(0.37000000476837158D));
            this.textBox47.Style.Color = System.Drawing.Color.Gray;
            this.textBox47.Style.Font.Italic = true;
            this.textBox47.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox47.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox47.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox47.TextWrap = false;
            this.textBox47.Value = "= PageCount";
            // 
            // textBox46
            // 
            this.textBox46.CanShrink = true;
            this.textBox46.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.97000002861022949D), Telerik.Reporting.Drawing.Unit.Cm(0.62999999523162842D));
            this.textBox46.Name = "textBox46";
            this.textBox46.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.43000000715255737D), Telerik.Reporting.Drawing.Unit.Cm(0.37000000476837158D));
            this.textBox46.Style.Color = System.Drawing.Color.Gray;
            this.textBox46.Style.Font.Italic = true;
            this.textBox46.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox46.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox46.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox46.TextWrap = false;
            this.textBox46.Value = "av";
            // 
            // textBox45
            // 
            this.textBox45.CanShrink = true;
            this.textBox45.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.62999999523162842D));
            this.textBox45.Name = "textBox45";
            this.textBox45.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D), Telerik.Reporting.Drawing.Unit.Cm(0.37000000476837158D));
            this.textBox45.Style.Color = System.Drawing.Color.Gray;
            this.textBox45.Style.Font.Italic = true;
            this.textBox45.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox45.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox45.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox45.TextWrap = false;
            this.textBox45.Value = "Sida";
            // 
            // textBox28
            // 
            this.textBox28.CanShrink = true;
            this.textBox28.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D), Telerik.Reporting.Drawing.Unit.Cm(0.62999999523162842D));
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.37000000476837158D), Telerik.Reporting.Drawing.Unit.Cm(0.37000000476837158D));
            this.textBox28.Style.Color = System.Drawing.Color.Gray;
            this.textBox28.Style.Font.Italic = true;
            this.textBox28.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox28.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox28.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox28.TextWrap = false;
            this.textBox28.Value = "= PageNumber";
            // 
            // textBox44
            // 
            this.textBox44.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.12999999523162842D));
            this.textBox44.Name = "textBox44";
            this.textBox44.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.190000057220459D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox44.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox44.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat;
            this.textBox44.Style.Color = System.Drawing.Color.Black;
            this.textBox44.Style.Font.Bold = false;
            this.textBox44.Style.Font.Name = "Calibri";
            this.textBox44.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox44.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox44.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox44.StyleName = "Title";
            this.textBox44.Value = "Genererad av M2M DataCenter";
            // 
            // textBox50
            // 
            this.textBox50.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.7699999809265137D), Telerik.Reporting.Drawing.Unit.Cm(0.62999999523162842D));
            this.textBox50.Name = "textBox50";
            this.textBox50.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.2899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.37000000476837158D));
            this.textBox50.Style.Color = System.Drawing.Color.Gray;
            this.textBox50.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox50.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox50.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox50.Value = "Copyright© 2009, M2M Solutions AB";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(16.889999389648438D), Telerik.Reporting.Drawing.Unit.Cm(0.37000000476837158D));
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.559999942779541D), Telerik.Reporting.Drawing.Unit.Cm(0.63999998569488525D));
            this.pictureBoxLogo.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBoxLogo.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            // 
            // NpbOee
            // 
            this.DocumentName = "= M2M.DataCenter.Reports.NpbOee.GetDocumentName(Parameters.DivisionId.Value, Para" +
    "meters.RangeStart.Value, Parameters.RangeEnd.Value)";
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageHeaderSection1,
            this.pageFooterSection1});
            this.Name = "NpbOee";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Cm(1.6000000238418579D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "DivisionId";
            reportParameter1.Text = "Maskin";
            reportParameter2.Name = "RangeStart";
            reportParameter2.Text = "From";
            reportParameter2.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter3.Name = "RangeEnd";
            reportParameter3.Text = "To";
            reportParameter3.Type = Telerik.Reporting.ReportParameterType.DateTime;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Style.BorderColor.Default = System.Drawing.SystemColors.Control;
            this.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.Font.Name = "Calibri";
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
        private Chart chartStopTime;
        private Chart chartStopCount;
        private Table tableStops;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox21;
        private Telerik.Reporting.TextBox textBox22;
        private Telerik.Reporting.TextBox textBox27;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
        private PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.TextBox textBox24;
        private Telerik.Reporting.Panel panel2;
        private PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox textBox47;
        private Telerik.Reporting.TextBox textBox46;
        private Telerik.Reporting.TextBox textBox45;
        private Telerik.Reporting.TextBox textBox28;
        private Telerik.Reporting.TextBox textBox44;
        private Telerik.Reporting.TextBox textBox50;
        private Telerik.Reporting.TextBox textBox34;
        private Telerik.Reporting.TextBox textBox35;
        private Telerik.Reporting.TextBox tbProductionTime;
        private Telerik.Reporting.TextBox textBox29;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox tbAvailabilityBasedOnActualStops;
        private Telerik.Reporting.TextBox textBox37;
        private Telerik.Reporting.TextBox textBox36;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox tbOee;
        private Telerik.Reporting.TextBox tbQuality;
        private Telerik.Reporting.TextBox tbPerformance;
        private Telerik.Reporting.TextBox tbAvailability;
        private Telerik.Reporting.TextBox textBox32;
        private Telerik.Reporting.TextBox tbProducedItems;
        private List list1;
        private Telerik.Reporting.Panel panel1;
        private Chart chartPeriodicOee;
        private Table tableMachines;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox39;
        private Telerik.Reporting.TextBox textBox40;
        private Telerik.Reporting.TextBox textBox41;
        private Telerik.Reporting.TextBox textBox48;
        private Telerik.Reporting.TextBox textBox49;
        private Telerik.Reporting.TextBox textBox51;
        private Telerik.Reporting.TextBox textBox52;
        private Telerik.Reporting.TextBox textBox55;
        private Telerik.Reporting.TextBox textBox57;
        private Telerik.Reporting.TextBox textBox58;
        private Telerik.Reporting.TextBox textBox76;
        private Telerik.Reporting.TextBox textBox77;
        private Telerik.Reporting.TextBox textBox56;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox25;
        private Telerik.Reporting.PictureBox pictureBoxLogo;
        private Telerik.Reporting.TextBox textBox26;
        private Telerik.Reporting.Panel panel4;
        private Shape shape1;
        private Telerik.Reporting.TextBox tbShapeRow2;
        private Telerik.Reporting.Panel panel8;
        private Telerik.Reporting.Panel panel9;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.Panel panel7;
        private Telerik.Reporting.Panel panel3;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.Panel panel5;
        private Telerik.Reporting.Panel panel6;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.TextBox textBox30;
        private Telerik.Reporting.TextBox textBox31;
        private Telerik.Reporting.TextBox textBox85;
        private Telerik.Reporting.TextBox textBox115;
        private Telerik.Reporting.TextBox textBox38;
        private Telerik.Reporting.TextBox textBox42;
        private Telerik.Reporting.TextBox textBox117;
        private Telerik.Reporting.TextBox textBox116;
        private Telerik.Reporting.TextBox textBox43;
    }
}