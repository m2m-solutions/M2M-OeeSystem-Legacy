namespace M2M.DataCenter.Reports
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class MachineOeeMonthly
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Panel panelOverview;
            Telerik.Reporting.TextBox tbShapeRow1;
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins1 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Palette palette1 = new Telerik.Reporting.Charting.Palette();
            Telerik.Reporting.Charting.PaletteItem paletteItem1 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem2 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem3 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem4 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins2 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartSeries chartSeries1 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Charting.ChartSeries chartSeries2 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Charting.ChartSeries chartSeries3 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Charting.ChartSeries chartSeries4 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins3 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Palette palette2 = new Telerik.Reporting.Charting.Palette();
            Telerik.Reporting.Charting.PaletteItem paletteItem5 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem6 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem7 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem8 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins4 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins5 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem1 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins6 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem2 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins7 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem3 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins8 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem4 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins9 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem5 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins10 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem6 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins11 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartAxisItem chartAxisItem7 = new Telerik.Reporting.Charting.ChartAxisItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins12 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartSeries chartSeries5 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Charting.ChartSeries chartSeries6 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Charting.ChartSeries chartSeries7 = new Telerik.Reporting.Charting.ChartSeries();
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
            Telerik.Reporting.TableGroup tableGroup12 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup13 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup14 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup15 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup16 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter5 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.tbProductionTime = new Telerik.Reporting.TextBox();
            this.tbAvailability = new Telerik.Reporting.TextBox();
            this.tbPerformance = new Telerik.Reporting.TextBox();
            this.tbQuality = new Telerik.Reporting.TextBox();
            this.tbTotalTime = new Telerik.Reporting.TextBox();
            this.tbStopTime = new Telerik.Reporting.TextBox();
            this.tbOee = new Telerik.Reporting.TextBox();
            this.textBox29 = new Telerik.Reporting.TextBox();
            this.textBox30 = new Telerik.Reporting.TextBox();
            this.textBox32 = new Telerik.Reporting.TextBox();
            this.textBox33 = new Telerik.Reporting.TextBox();
            this.textBox34 = new Telerik.Reporting.TextBox();
            this.textBox36 = new Telerik.Reporting.TextBox();
            this.textBox37 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox35 = new Telerik.Reporting.TextBox();
            this.textBox38 = new Telerik.Reporting.TextBox();
            this.textBox39 = new Telerik.Reporting.TextBox();
            this.textBox40 = new Telerik.Reporting.TextBox();
            this.textBox55 = new Telerik.Reporting.TextBox();
            this.textBox41 = new Telerik.Reporting.TextBox();
            this.textBox42 = new Telerik.Reporting.TextBox();
            this.textBox43 = new Telerik.Reporting.TextBox();
            this.textBox51 = new Telerik.Reporting.TextBox();
            this.textBox52 = new Telerik.Reporting.TextBox();
            this.textBox53 = new Telerik.Reporting.TextBox();
            this.textBox54 = new Telerik.Reporting.TextBox();
            this.textBox56 = new Telerik.Reporting.TextBox();
            this.textBox57 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.chartTotalOee = new Telerik.Reporting.Chart();
            this.chartPeriodicOee = new Telerik.Reporting.Chart();
            this.tableArticles = new Telerik.Reporting.Table();
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
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox58 = new Telerik.Reporting.TextBox();
            this.textBox59 = new Telerik.Reporting.TextBox();
            this.textBox60 = new Telerik.Reporting.TextBox();
            this.textBox61 = new Telerik.Reporting.TextBox();
            this.textBox62 = new Telerik.Reporting.TextBox();
            this.textBox63 = new Telerik.Reporting.TextBox();
            this.list1 = new Telerik.Reporting.List();
            this.panel1 = new Telerik.Reporting.Panel();
            this.panel5 = new Telerik.Reporting.Panel();
            this.panel6 = new Telerik.Reporting.Panel();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.panel3 = new Telerik.Reporting.Panel();
            this.panel7 = new Telerik.Reporting.Panel();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.panel8 = new Telerik.Reporting.Panel();
            this.panel9 = new Telerik.Reporting.Panel();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.panel4 = new Telerik.Reporting.Panel();
            this.shape1 = new Telerik.Reporting.Shape();
            this.tbShapeRow2 = new Telerik.Reporting.TextBox();
            this.panel2 = new Telerik.Reporting.Panel();
            this.textBox25 = new Telerik.Reporting.TextBox();
            this.textBox26 = new Telerik.Reporting.TextBox();
            this.textBox28 = new Telerik.Reporting.TextBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.textBox27 = new Telerik.Reporting.TextBox();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.textBox48 = new Telerik.Reporting.TextBox();
            this.textBox49 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.textBox44 = new Telerik.Reporting.TextBox();
            this.textBox31 = new Telerik.Reporting.TextBox();
            this.textBox45 = new Telerik.Reporting.TextBox();
            this.textBox46 = new Telerik.Reporting.TextBox();
            this.textBox47 = new Telerik.Reporting.TextBox();
            this.textBox50 = new Telerik.Reporting.TextBox();
            this.pictureBoxLogo = new Telerik.Reporting.PictureBox();
            panelOverview = new Telerik.Reporting.Panel();
            tbShapeRow1 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // panelOverview
            // 
            panelOverview.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.tbProductionTime,
            this.tbAvailability,
            this.tbPerformance,
            this.tbQuality,
            this.tbTotalTime,
            this.tbStopTime,
            this.tbOee,
            this.textBox29,
            this.textBox30,
            this.textBox32,
            this.textBox33,
            this.textBox34,
            this.textBox36,
            this.textBox37,
            this.textBox4,
            this.textBox5,
            this.textBox35,
            this.textBox38,
            this.textBox39,
            this.textBox40,
            this.textBox55,
            this.textBox41,
            this.textBox42,
            this.textBox43,
            this.textBox51,
            this.textBox52,
            this.textBox53,
            this.textBox54,
            this.textBox56,
            this.textBox57});
            panelOverview.Name = "panelOverview";
            panelOverview.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(4.4000000953674316D));
            panelOverview.Style.BackgroundColor = System.Drawing.Color.White;
            // 
            // tbProductionTime
            // 
            this.tbProductionTime.Format = "{0:N1} tim";
            this.tbProductionTime.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0802001953125D), Telerik.Reporting.Drawing.Unit.Cm(1.7400000095367432D));
            this.tbProductionTime.Name = "tbProductionTime";
            this.tbProductionTime.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.tbProductionTime.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbProductionTime.Value = "=Fields.ActualProductionTimeInHours";
            // 
            // tbAvailability
            // 
            this.tbAvailability.Format = "{0:P1}";
            this.tbAvailability.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.208324432373047D), Telerik.Reporting.Drawing.Unit.Cm(0.67000001668930054D));
            this.tbAvailability.Name = "tbAvailability";
            this.tbAvailability.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.tbAvailability.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbAvailability.Value = "=Fields.Availability";
            // 
            // tbPerformance
            // 
            this.tbPerformance.Format = "{0:P1}";
            this.tbPerformance.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.208324432373047D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.tbPerformance.Name = "tbPerformance";
            this.tbPerformance.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.tbPerformance.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbPerformance.Value = "=Fields.Performance";
            // 
            // tbQuality
            // 
            this.tbQuality.Format = "{0:P1}";
            this.tbQuality.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.208324432373047D), Telerik.Reporting.Drawing.Unit.Cm(1.7400000095367432D));
            this.tbQuality.Name = "tbQuality";
            this.tbQuality.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.tbQuality.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbQuality.Style.Visible = true;
            this.tbQuality.Value = "=Fields.Quality";
            // 
            // tbTotalTime
            // 
            this.tbTotalTime.Format = "{0:N1} tim";
            this.tbTotalTime.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0802001953125D), Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D));
            this.tbTotalTime.Name = "tbTotalTime";
            this.tbTotalTime.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.tbTotalTime.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbTotalTime.Value = "=Fields.ScheduledTimeInHours";
            // 
            // tbStopTime
            // 
            this.tbStopTime.Format = "{0:N1} tim";
            this.tbStopTime.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0851850509643555D), Telerik.Reporting.Drawing.Unit.Cm(0.67000001668930054D));
            this.tbStopTime.Name = "tbStopTime";
            this.tbStopTime.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.tbStopTime.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbStopTime.Value = "=Fields.NoProductionTimeInHours";
            // 
            // tbOee
            // 
            this.tbOee.Format = "{0:P1}";
            this.tbOee.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.199999809265137D), Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D));
            this.tbOee.Name = "tbOee";
            this.tbOee.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.tbOee.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbOee.Value = "=Fields.Oee";
            // 
            // textBox29
            // 
            this.textBox29.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.82020831108093262D), Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D));
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox29.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox29.Value = "Schemalagd tid:";
            // 
            // textBox30
            // 
            this.textBox30.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.81999999284744263D), Telerik.Reporting.Drawing.Unit.Cm(1.7400000095367432D));
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox30.Value = "Tillgänglig tid:";
            // 
            // textBox32
            // 
            this.textBox32.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.81999999284744263D), Telerik.Reporting.Drawing.Unit.Cm(2.2699999809265137D));
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox32.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox32.Value = "Effektiv produktionstid:";
            // 
            // textBox33
            // 
            this.textBox33.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9400081634521484D), Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D));
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox33.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox33.Value = "TAK/OEE:";
            // 
            // textBox34
            // 
            this.textBox34.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9483327865600586D), Telerik.Reporting.Drawing.Unit.Cm(0.67000001668930054D));
            this.textBox34.Name = "textBox34";
            this.textBox34.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox34.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox34.Value = "Tillgänglighet (T):";
            // 
            // textBox36
            // 
            this.textBox36.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9483327865600586D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.textBox36.Name = "textBox36";
            this.textBox36.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox36.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox36.Value = "Anläggningsutbyte (A):";
            // 
            // textBox37
            // 
            this.textBox37.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9483327865600586D), Telerik.Reporting.Drawing.Unit.Cm(1.7400000095367432D));
            this.textBox37.Name = "textBox37";
            this.textBox37.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox37.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox37.Value = "Kvalitet (K):";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.34000000357627869D), Telerik.Reporting.Drawing.Unit.Cm(0.67000001668930054D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.73604154586792D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox4.Value = "Maskin ej i produktion:";
            // 
            // textBox5
            // 
            this.textBox5.Format = "{0:N1} tim";
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0802001953125D), Telerik.Reporting.Drawing.Unit.Cm(2.2699999809265137D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox5.Value = "=Fields.AutoTimeInHours";
            // 
            // textBox35
            // 
            this.textBox35.Format = "{0:N1} tim";
            this.textBox35.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0802001953125D), Telerik.Reporting.Drawing.Unit.Cm(2.7999999523162842D));
            this.textBox35.Name = "textBox35";
            this.textBox35.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox35.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox35.Value = "=Fields.StopTimeInHours";
            // 
            // textBox38
            // 
            this.textBox38.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.81999999284744263D), Telerik.Reporting.Drawing.Unit.Cm(2.7999999523162842D));
            this.textBox38.Name = "textBox38";
            this.textBox38.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox38.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox38.Value = "Stopptid:";
            // 
            // textBox39
            // 
            this.textBox39.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.31749987602233887D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.textBox39.Name = "textBox39";
            this.textBox39.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.7624998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox39.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox39.Value = "Ingen kontakt med maskin:";
            // 
            // textBox40
            // 
            this.textBox40.Format = "{0:N1} tim";
            this.textBox40.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0851850509643555D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.textBox40.Name = "textBox40";
            this.textBox40.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox40.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox40.Value = "=Fields.NotConnectedTimeInHours";
            // 
            // textBox55
            // 
            this.textBox55.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.30832576751709D), Telerik.Reporting.Drawing.Unit.Cm(3.8599998950958252D));
            this.textBox55.Name = "textBox55";
            this.textBox55.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.8997993469238281D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox55.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox55.Value = "...baserat på flödesfel (Ff):";
            // 
            // textBox41
            // 
            this.textBox41.Format = "{0:P1}";
            this.textBox41.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.208324432373047D), Telerik.Reporting.Drawing.Unit.Cm(3.8599998950958252D));
            this.textBox41.Name = "textBox41";
            this.textBox41.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox41.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox41.Style.Visible = true;
            this.textBox41.Value = "=Fields.AvailabilityLossBasedOnFlowErrors";
            // 
            // textBox42
            // 
            this.textBox42.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(3.3299999237060547D));
            this.textBox42.Name = "textBox42";
            this.textBox42.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.9081239700317383D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox42.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox42.Value = "...baserat på faktiska stopp (Fs):";
            // 
            // textBox43
            // 
            this.textBox43.Format = "{0:P1}";
            this.textBox43.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.208324432373047D), Telerik.Reporting.Drawing.Unit.Cm(3.3299999237060547D));
            this.textBox43.Name = "textBox43";
            this.textBox43.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox43.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox43.Style.Visible = true;
            this.textBox43.Value = "=Fields.AvailabilityLossBasedOnActualStops";
            // 
            // textBox51
            // 
            this.textBox51.Format = "{0:P1}";
            this.textBox51.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.208324432373047D), Telerik.Reporting.Drawing.Unit.Cm(2.7999999523162842D));
            this.textBox51.Name = "textBox51";
            this.textBox51.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox51.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox51.Style.Visible = true;
            this.textBox51.Value = "=Fields.AvailabilityLoss";
            // 
            // textBox52
            // 
            this.textBox52.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9483327865600586D), Telerik.Reporting.Drawing.Unit.Cm(2.7999999523162842D));
            this.textBox52.Name = "textBox52";
            this.textBox52.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox52.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox52.Value = "Tillgänglighetsförlust (F):";
            // 
            // textBox53
            // 
            this.textBox53.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.44999998807907104D), Telerik.Reporting.Drawing.Unit.Cm(3.8599998950958252D));
            this.textBox53.Name = "textBox53";
            this.textBox53.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.6302080154418945D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox53.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox53.Value = "Stopptid flödesfel:";
            // 
            // textBox54
            // 
            this.textBox54.Format = "{0:N1} tim";
            this.textBox54.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0802001953125D), Telerik.Reporting.Drawing.Unit.Cm(3.8599998950958252D));
            this.textBox54.Name = "textBox54";
            this.textBox54.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.42333352565765381D));
            this.textBox54.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox54.Value = "=Fields.FlowErrorTimeInHours";
            // 
            // textBox56
            // 
            this.textBox56.Format = "{0:N1} tim";
            this.textBox56.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0802001953125D), Telerik.Reporting.Drawing.Unit.Cm(3.3299999237060547D));
            this.textBox56.Name = "textBox56";
            this.textBox56.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.42333352565765381D));
            this.textBox56.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox56.Value = "=Fields.ActualStopTimeInHours";
            // 
            // textBox57
            // 
            this.textBox57.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.44999998807907104D), Telerik.Reporting.Drawing.Unit.Cm(3.3299999237060547D));
            this.textBox57.Name = "textBox57";
            this.textBox57.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.6302080154418945D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox57.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox57.Value = "Stopptid faktiska stopp:";
            // 
            // tbShapeRow1
            // 
            tbShapeRow1.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            tbShapeRow1.Format = "{0:MMM}";
            tbShapeRow1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.49000000953674316D));
            tbShapeRow1.Name = "tbShapeRow1";
            tbShapeRow1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.3572964668273926D), Telerik.Reporting.Drawing.Unit.Cm(0.61635404825210571D));
            tbShapeRow1.Style.Color = System.Drawing.Color.White;
            tbShapeRow1.Style.Font.Bold = true;
            tbShapeRow1.Style.Font.Name = "Calibri";
            tbShapeRow1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16D);
            tbShapeRow1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            tbShapeRow1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            tbShapeRow1.Value = "=Fields.PeriodStart";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(17.430000305175781D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.chartTotalOee,
            this.chartPeriodicOee,
            this.tableArticles,
            this.list1,
            this.panel5,
            this.panel3,
            this.panel8});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.Font.Italic = true;
            this.detail.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            // 
            // chartTotalOee
            // 
            this.chartTotalOee.Appearance.BarWidthPercent = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.chartTotalOee.Appearance.Border.Visible = false;
            this.chartTotalOee.BitmapResolution = 96F;
            this.chartTotalOee.ChartTitle.Appearance.Border.Visible = false;
            this.chartTotalOee.ChartTitle.Appearance.Dimensions.AutoSize = false;
            this.chartTotalOee.ChartTitle.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(24D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins1.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins1.Left = new Telerik.Reporting.Charting.Styles.Unit(7D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins1.Right = new Telerik.Reporting.Charting.Styles.Unit(10D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins1.Top = new Telerik.Reporting.Charting.Styles.Unit(3D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            this.chartTotalOee.ChartTitle.Appearance.Dimensions.Margins = chartMargins1;
            this.chartTotalOee.ChartTitle.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(253.40625D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartTotalOee.ChartTitle.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartTotalOee.ChartTitle.Appearance.Position.AlignedPosition = Telerik.Reporting.Charting.Styles.AlignedPositions.Top;
            this.chartTotalOee.ChartTitle.Appearance.Visible = false;
            this.chartTotalOee.ChartTitle.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartTotalOee.ChartTitle.TextBlock.Text = "TAK/OEE översikt";
            this.chartTotalOee.ChartTitle.Visible = false;
            paletteItem1.MainColor = System.Drawing.Color.DarkBlue;
            paletteItem1.Name = "PalletteOee";
            paletteItem1.SecondColor = System.Drawing.Color.Blue;
            paletteItem2.MainColor = System.Drawing.Color.RoyalBlue;
            paletteItem2.Name = "PaletteAvailabilityLoss";
            paletteItem2.SecondColor = System.Drawing.Color.LightBlue;
            paletteItem3.MainColor = System.Drawing.Color.DarkGray;
            paletteItem3.Name = "PaletteRunRateLoss";
            paletteItem3.SecondColor = System.Drawing.Color.LightGray;
            paletteItem4.MainColor = System.Drawing.Color.Gainsboro;
            paletteItem4.Name = "PaletteQualityLoss";
            paletteItem4.SecondColor = System.Drawing.Color.WhiteSmoke;
            palette1.Items.AddRange(new Telerik.Reporting.Charting.PaletteItem[] {
            paletteItem1,
            paletteItem2,
            paletteItem3,
            paletteItem4});
            palette1.Name = "Palette1";
            this.chartTotalOee.CustomPalettes.AddRange(new Telerik.Reporting.Charting.Palette[] {
            palette1});
            this.chartTotalOee.DefaultType = Telerik.Reporting.Charting.ChartSeriesType.StackedBar100;
            this.chartTotalOee.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chartTotalOee.IntelligentLabelsEnabled = true;
            this.chartTotalOee.Legend.Appearance.Border.Color = System.Drawing.Color.White;
            this.chartTotalOee.Legend.Appearance.Border.Visible = false;
            this.chartTotalOee.Legend.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartTotalOee.Legend.Appearance.ItemTextAppearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartTotalOee.Legend.Appearance.Overflow = Telerik.Reporting.Charting.Styles.Overflow.Row;
            this.chartTotalOee.Legend.Appearance.Position.AlignedPosition = Telerik.Reporting.Charting.Styles.AlignedPositions.Bottom;
            this.chartTotalOee.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(5.4000000953674316D));
            this.chartTotalOee.Name = "chartTotalOee";
            this.chartTotalOee.PlotArea.Appearance.Border.Visible = false;
            this.chartTotalOee.PlotArea.Appearance.Dimensions.AutoSize = false;
            this.chartTotalOee.PlotArea.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(36D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins2.Bottom = new Telerik.Reporting.Charting.Styles.Unit(30D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins2.Left = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins2.Right = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins2.Top = new Telerik.Reporting.Charting.Styles.Unit(30D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartTotalOee.PlotArea.Appearance.Dimensions.Margins = chartMargins2;
            this.chartTotalOee.PlotArea.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(631.79998779296875D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartTotalOee.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartTotalOee.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chartTotalOee.PlotArea.Appearance.SeriesPalette = "Palette1";
            this.chartTotalOee.PlotArea.EmptySeriesMessage.TextBlock.Text = "Det saknas värden för intervallet";
            this.chartTotalOee.PlotArea.EmptySeriesMessage.TextBlock.Visible = false;
            this.chartTotalOee.PlotArea.XAxis.Appearance.Visible = Telerik.Reporting.Charting.Styles.ChartAxisVisibility.False;
            this.chartTotalOee.PlotArea.XAxis.AxisLabel.Appearance.RotationAngle = 270F;
            this.chartTotalOee.PlotArea.XAxis.MinValue = 1D;
            this.chartTotalOee.PlotArea.XAxis.Visible = Telerik.Reporting.Charting.Styles.ChartAxisVisibility.False;
            this.chartTotalOee.PlotArea.YAxis.Appearance.TextAppearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartTotalOee.PlotArea.YAxis.AxisLabel.Appearance.RotationAngle = 0F;
            this.chartTotalOee.PlotArea.YAxis.MaxValue = 100D;
            this.chartTotalOee.PlotArea.YAxis.Step = 10D;
            this.chartTotalOee.PlotArea.YAxis.VisibleValues = Telerik.Reporting.Charting.Styles.ChartAxisVisibleValues.Positive;
            this.chartTotalOee.PlotArea.YAxis2.AxisLabel.Appearance.RotationAngle = 0F;
            chartSeries1.Appearance.BarWidthPercent = new decimal(new int[] {
            30,
            0,
            0,
            0});
            chartSeries1.Appearance.Border.Color = System.Drawing.Color.Black;
            chartSeries1.Appearance.FillStyle.FillSettings.GradientMode = Telerik.Reporting.Charting.Styles.GradientFillStyle.Vertical;
            chartSeries1.Appearance.LabelAppearance.LabelLocation = Telerik.Reporting.Charting.Styles.StyleSeriesItemLabel.ItemLabelLocation.Outside;
            chartSeries1.Appearance.LabelAppearance.Position.Auto = false;
            chartSeries1.Appearance.LabelAppearance.Position.X = 0F;
            chartSeries1.Appearance.LabelAppearance.Position.Y = 0F;
            chartSeries1.DataYColumn = "Oee";
            chartSeries1.DefaultLabelValue = "#Y{#0.0%}";
            chartSeries1.Name = "TAK";
            chartSeries1.Type = Telerik.Reporting.Charting.ChartSeriesType.StackedBar100;
            chartSeries2.Appearance.BarWidthPercent = new decimal(new int[] {
            30,
            0,
            0,
            0});
            chartSeries2.Appearance.Border.Color = System.Drawing.Color.Black;
            chartSeries2.Appearance.FillStyle.FillSettings.GradientMode = Telerik.Reporting.Charting.Styles.GradientFillStyle.Vertical;
            chartSeries2.Appearance.FillStyle.FillSettings.ImageAlign = Telerik.Reporting.Charting.Styles.ImageAlignModes.Top;
            chartSeries2.Appearance.LabelAppearance.LabelLocation = Telerik.Reporting.Charting.Styles.StyleSeriesItemLabel.ItemLabelLocation.Outside;
            chartSeries2.Appearance.LabelAppearance.Position.Auto = false;
            chartSeries2.Appearance.LabelAppearance.Position.X = 0F;
            chartSeries2.Appearance.LabelAppearance.Position.Y = 0F;
            chartSeries2.DataYColumn = "NonAvailability";
            chartSeries2.DefaultLabelValue = "#Y{#0.0%}";
            chartSeries2.Name = "Tillgänglighetsförlust";
            chartSeries2.Type = Telerik.Reporting.Charting.ChartSeriesType.StackedBar100;
            chartSeries3.Appearance.BarWidthPercent = new decimal(new int[] {
            30,
            0,
            0,
            0});
            chartSeries3.Appearance.Border.Color = System.Drawing.Color.Black;
            chartSeries3.Appearance.FillStyle.FillSettings.GradientMode = Telerik.Reporting.Charting.Styles.GradientFillStyle.Vertical;
            chartSeries3.Appearance.LabelAppearance.LabelLocation = Telerik.Reporting.Charting.Styles.StyleSeriesItemLabel.ItemLabelLocation.Outside;
            chartSeries3.Appearance.LabelAppearance.Position.Auto = false;
            chartSeries3.Appearance.LabelAppearance.Position.X = 0F;
            chartSeries3.Appearance.LabelAppearance.Position.Y = 0F;
            chartSeries3.DataYColumn = "RunRateLoss";
            chartSeries3.DefaultLabelValue = "#Y{#0.0%}";
            chartSeries3.Name = "Hastighetsförlust";
            chartSeries3.Type = Telerik.Reporting.Charting.ChartSeriesType.StackedBar100;
            chartSeries4.Appearance.BarWidthPercent = new decimal(new int[] {
            30,
            0,
            0,
            0});
            chartSeries4.Appearance.Border.Color = System.Drawing.Color.Black;
            chartSeries4.Appearance.FillStyle.FillSettings.GradientMode = Telerik.Reporting.Charting.Styles.GradientFillStyle.Vertical;
            chartSeries4.Appearance.LabelAppearance.LabelLocation = Telerik.Reporting.Charting.Styles.StyleSeriesItemLabel.ItemLabelLocation.Outside;
            chartSeries4.Appearance.LabelAppearance.Position.Auto = false;
            chartSeries4.Appearance.LabelAppearance.Position.X = 0F;
            chartSeries4.Appearance.LabelAppearance.Position.Y = 0F;
            chartSeries4.DataYColumn = "QualityLoss";
            chartSeries4.DefaultLabelValue = "#Y{#0.0%}";
            chartSeries4.Name = "Kvalitetsförlust";
            chartSeries4.Type = Telerik.Reporting.Charting.ChartSeriesType.StackedBar100;
            this.chartTotalOee.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries1,
            chartSeries2,
            chartSeries3,
            chartSeries4});
            this.chartTotalOee.SeriesOrientation = Telerik.Reporting.Charting.ChartSeriesOrientation.Horizontal;
            this.chartTotalOee.SeriesPalette = "Palette1";
            this.chartTotalOee.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(2.9000000953674316D));
            this.chartTotalOee.NeedDataSource += new System.EventHandler(this.chartTotalOee_NeedDataSource);
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
            chartMargins3.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins3.Left = new Telerik.Reporting.Charting.Styles.Unit(7D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins3.Right = new Telerik.Reporting.Charting.Styles.Unit(10D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins3.Top = new Telerik.Reporting.Charting.Styles.Unit(3D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            this.chartPeriodicOee.ChartTitle.Appearance.Dimensions.Margins = chartMargins3;
            this.chartPeriodicOee.ChartTitle.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(253.40625D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartPeriodicOee.ChartTitle.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartPeriodicOee.ChartTitle.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chartPeriodicOee.ChartTitle.Appearance.Position.AlignedPosition = Telerik.Reporting.Charting.Styles.AlignedPositions.Top;
            this.chartPeriodicOee.ChartTitle.Appearance.Visible = false;
            this.chartPeriodicOee.ChartTitle.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartPeriodicOee.ChartTitle.TextBlock.Text = "TAK/OEE per produktionsdag";
            this.chartPeriodicOee.ChartTitle.Visible = false;
            paletteItem5.MainColor = System.Drawing.Color.DarkBlue;
            paletteItem5.Name = "PalletteOee";
            paletteItem5.SecondColor = System.Drawing.Color.Blue;
            paletteItem6.MainColor = System.Drawing.Color.RoyalBlue;
            paletteItem6.Name = "PaletteAvailabilityLoss";
            paletteItem6.SecondColor = System.Drawing.Color.LightBlue;
            paletteItem7.MainColor = System.Drawing.Color.LightGray;
            paletteItem7.Name = "PaletteRunRateLoss";
            paletteItem7.SecondColor = System.Drawing.Color.WhiteSmoke;
            paletteItem8.MainColor = System.Drawing.Color.WhiteSmoke;
            paletteItem8.Name = "PaletteQualityLoss";
            paletteItem8.SecondColor = System.Drawing.Color.White;
            palette2.Items.AddRange(new Telerik.Reporting.Charting.PaletteItem[] {
            paletteItem5,
            paletteItem6,
            paletteItem7,
            paletteItem8});
            palette2.Name = "Palette1";
            this.chartPeriodicOee.CustomPalettes.AddRange(new Telerik.Reporting.Charting.Palette[] {
            palette2});
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
            this.chartPeriodicOee.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(9D));
            this.chartPeriodicOee.Name = "chartPeriodicOee";
            this.chartPeriodicOee.PlotArea.Appearance.Border.Visible = false;
            this.chartPeriodicOee.PlotArea.Appearance.Dimensions.AutoSize = false;
            this.chartPeriodicOee.PlotArea.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(138D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins4.Bottom = new Telerik.Reporting.Charting.Styles.Unit(80D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins4.Left = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins4.Right = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Percentage);
            chartMargins4.Top = new Telerik.Reporting.Charting.Styles.Unit(20D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartPeriodicOee.PlotArea.Appearance.Dimensions.Margins = chartMargins4;
            this.chartPeriodicOee.PlotArea.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(631.79998779296875D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartPeriodicOee.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartPeriodicOee.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chartPeriodicOee.PlotArea.Appearance.SeriesPalette = "Palette1";
            this.chartPeriodicOee.PlotArea.EmptySeriesMessage.TextBlock.Text = "Det saknas värden för intervallet";
            this.chartPeriodicOee.PlotArea.EmptySeriesMessage.TextBlock.Visible = false;
            chartMargins5.Top = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartPeriodicOee.PlotArea.XAxis.Appearance.LabelAppearance.Dimensions.Margins = chartMargins5;
            this.chartPeriodicOee.PlotArea.XAxis.Appearance.LabelAppearance.RotationAngle = 270F;
            this.chartPeriodicOee.PlotArea.XAxis.Appearance.TextAppearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartPeriodicOee.PlotArea.XAxis.AutoScale = false;
            this.chartPeriodicOee.PlotArea.XAxis.DataLabelsColumn = "XLabel";
            this.chartPeriodicOee.PlotArea.XAxis.IsZeroBased = false;
            chartMargins6.Top = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartAxisItem1.Appearance.Dimensions.Margins = chartMargins6;
            chartAxisItem1.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            chartMargins7.Top = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartAxisItem2.Appearance.Dimensions.Margins = chartMargins7;
            chartAxisItem2.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            chartMargins8.Top = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartAxisItem3.Appearance.Dimensions.Margins = chartMargins8;
            chartAxisItem3.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem3.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            chartMargins9.Top = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartAxisItem4.Appearance.Dimensions.Margins = chartMargins9;
            chartAxisItem4.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem4.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            chartMargins10.Top = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartAxisItem5.Appearance.Dimensions.Margins = chartMargins10;
            chartAxisItem5.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem5.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            chartMargins11.Top = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartAxisItem6.Appearance.Dimensions.Margins = chartMargins11;
            chartAxisItem6.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartAxisItem6.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            chartMargins12.Top = new Telerik.Reporting.Charting.Styles.Unit(5D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartAxisItem7.Appearance.Dimensions.Margins = chartMargins12;
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
            this.chartPeriodicOee.PlotArea.YAxis.MaxItemsCount = 4;
            this.chartPeriodicOee.PlotArea.YAxis.MaxValue = 100D;
            this.chartPeriodicOee.PlotArea.YAxis.Step = 20D;
            this.chartPeriodicOee.PlotArea.YAxis.VisibleValues = Telerik.Reporting.Charting.Styles.ChartAxisVisibleValues.Positive;
            chartSeries5.Appearance.Border.Color = System.Drawing.Color.Black;
            chartSeries5.Appearance.LabelAppearance.LabelLocation = Telerik.Reporting.Charting.Styles.StyleSeriesItemLabel.ItemLabelLocation.Outside;
            chartSeries5.Appearance.ShowLabels = false;
            chartSeries5.DataYColumn = "Oee";
            chartSeries5.DefaultLabelValue = "";
            chartSeries5.Name = "TAK";
            chartSeries5.Type = Telerik.Reporting.Charting.ChartSeriesType.StackedBar100;
            chartSeries6.Appearance.Border.Color = System.Drawing.Color.Black;
            chartSeries6.Appearance.FillStyle.FillSettings.ImageAlign = Telerik.Reporting.Charting.Styles.ImageAlignModes.Top;
            chartSeries6.Appearance.LabelAppearance.LabelLocation = Telerik.Reporting.Charting.Styles.StyleSeriesItemLabel.ItemLabelLocation.Outside;
            chartSeries6.Appearance.LabelAppearance.Position.Auto = false;
            chartSeries6.Appearance.LabelAppearance.Position.X = 0F;
            chartSeries6.Appearance.LabelAppearance.Position.Y = 0F;
            chartSeries6.Appearance.LabelAppearance.Visible = false;
            chartSeries6.Appearance.ShowLabels = false;
            chartSeries6.DataYColumn = "NonAvailability";
            chartSeries6.DefaultLabelValue = "";
            chartSeries6.Name = "Tillgänglighetsförlust";
            chartSeries6.Type = Telerik.Reporting.Charting.ChartSeriesType.StackedBar100;
            chartSeries7.Appearance.Border.Color = System.Drawing.Color.Black;
            chartSeries7.Appearance.LabelAppearance.LabelLocation = Telerik.Reporting.Charting.Styles.StyleSeriesItemLabel.ItemLabelLocation.Outside;
            chartSeries7.Appearance.LabelAppearance.Position.Auto = false;
            chartSeries7.Appearance.LabelAppearance.Position.X = 0F;
            chartSeries7.Appearance.LabelAppearance.Position.Y = 0F;
            chartSeries7.Appearance.LabelAppearance.Visible = false;
            chartSeries7.Appearance.ShowLabels = false;
            chartSeries7.DataYColumn = "RunRateLoss";
            chartSeries7.DefaultLabelValue = "";
            chartSeries7.Name = "Hastighetsförlust";
            chartSeries7.Type = Telerik.Reporting.Charting.ChartSeriesType.StackedBar100;
            chartSeries8.Appearance.Border.Color = System.Drawing.Color.Black;
            chartSeries8.Appearance.LabelAppearance.LabelLocation = Telerik.Reporting.Charting.Styles.StyleSeriesItemLabel.ItemLabelLocation.Outside;
            chartSeries8.Appearance.LabelAppearance.Position.Auto = false;
            chartSeries8.Appearance.LabelAppearance.Position.X = 0F;
            chartSeries8.Appearance.LabelAppearance.Position.Y = 0F;
            chartSeries8.Appearance.LabelAppearance.Visible = false;
            chartSeries8.Appearance.ShowLabels = false;
            chartSeries8.DataYColumn = "QualityLoss";
            chartSeries8.DefaultLabelValue = "";
            chartSeries8.Name = "Kvalitetsförlust";
            chartSeries8.Type = Telerik.Reporting.Charting.ChartSeriesType.StackedBar100;
            this.chartPeriodicOee.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries5,
            chartSeries6,
            chartSeries7,
            chartSeries8});
            this.chartPeriodicOee.SeriesPalette = "Palette1";
            this.chartPeriodicOee.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(6.3000006675720215D));
            this.chartPeriodicOee.NeedDataSource += new System.EventHandler(this.chartPeriodicOee_NeedDataSource);
            // 
            // tableArticles
            // 
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.7316665649414063D)));
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.9170531034469605D)));
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.4300003051757813D)));
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.4300003051757813D)));
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.4300003051757813D)));
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.4300003051757813D)));
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.4300003051757813D)));
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.4300003051757813D)));
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.1000001430511475D)));
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.2000002861022949D)));
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.0399999618530273D)));
            this.tableArticles.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.729999840259552D)));
            this.tableArticles.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D)));
            this.tableArticles.Body.SetCellContent(0, 0, this.textBox12);
            this.tableArticles.Body.SetCellContent(0, 1, this.textBox13);
            this.tableArticles.Body.SetCellContent(1, 0, this.textBox15);
            this.tableArticles.Body.SetCellContent(1, 1, this.textBox16);
            this.tableArticles.Body.SetCellContent(0, 2, this.textBox17);
            this.tableArticles.Body.SetCellContent(1, 2, this.textBox18);
            this.tableArticles.Body.SetCellContent(0, 6, this.textBox19);
            this.tableArticles.Body.SetCellContent(1, 6, this.textBox20);
            this.tableArticles.Body.SetCellContent(0, 7, this.textBox21);
            this.tableArticles.Body.SetCellContent(1, 7, this.textBox22);
            this.tableArticles.Body.SetCellContent(0, 8, this.textBox6);
            this.tableArticles.Body.SetCellContent(1, 8, this.textBox7);
            this.tableArticles.Body.SetCellContent(0, 9, this.textBox8);
            this.tableArticles.Body.SetCellContent(1, 9, this.textBox9);
            this.tableArticles.Body.SetCellContent(0, 10, this.textBox10);
            this.tableArticles.Body.SetCellContent(1, 10, this.textBox11);
            this.tableArticles.Body.SetCellContent(0, 5, this.textBox58);
            this.tableArticles.Body.SetCellContent(1, 5, this.textBox59);
            this.tableArticles.Body.SetCellContent(0, 4, this.textBox60);
            this.tableArticles.Body.SetCellContent(1, 4, this.textBox61);
            this.tableArticles.Body.SetCellContent(0, 3, this.textBox62);
            this.tableArticles.Body.SetCellContent(1, 3, this.textBox63);
            tableGroup3.Name = "Group1";
            tableGroup4.Name = "Group10";
            tableGroup5.Name = "Group9";
            tableGroup6.Name = "Group8";
            tableGroup7.Name = "Group2";
            tableGroup8.Name = "Group3";
            tableGroup9.Name = "Group4";
            tableGroup10.Name = "Group5";
            tableGroup11.Name = "Group6";
            this.tableArticles.ColumnGroups.Add(tableGroup1);
            this.tableArticles.ColumnGroups.Add(tableGroup2);
            this.tableArticles.ColumnGroups.Add(tableGroup3);
            this.tableArticles.ColumnGroups.Add(tableGroup4);
            this.tableArticles.ColumnGroups.Add(tableGroup5);
            this.tableArticles.ColumnGroups.Add(tableGroup6);
            this.tableArticles.ColumnGroups.Add(tableGroup7);
            this.tableArticles.ColumnGroups.Add(tableGroup8);
            this.tableArticles.ColumnGroups.Add(tableGroup9);
            this.tableArticles.ColumnGroups.Add(tableGroup10);
            this.tableArticles.ColumnGroups.Add(tableGroup11);
            this.tableArticles.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
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
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox58,
            this.textBox59,
            this.textBox60,
            this.textBox61,
            this.textBox62,
            this.textBox63});
            this.tableArticles.KeepTogether = false;
            this.tableArticles.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(16.299999237060547D));
            this.tableArticles.Name = "tableArticles";
            tableGroup14.Name = "Group7";
            tableGroup13.ChildGroups.Add(tableGroup14);
            tableGroup13.Groupings.Add(new Telerik.Reporting.Grouping(""));
            tableGroup13.Name = "detailGroup";
            this.tableArticles.RowGroups.Add(tableGroup12);
            this.tableArticles.RowGroups.Add(tableGroup13);
            this.tableArticles.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.568717956542969D), Telerik.Reporting.Drawing.Unit.Cm(1.1299998760223389D));
            this.tableArticles.Style.BackgroundColor = System.Drawing.Color.White;
            this.tableArticles.NeedDataSource += new System.EventHandler(this.tableArticles_NeedDataSource);
            // 
            // textBox12
            // 
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.731665849685669D), Telerik.Reporting.Drawing.Unit.Cm(0.72999995946884155D));
            this.textBox12.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox12.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox12.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox12.Style.Font.Bold = false;
            // 
            // textBox13
            // 
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9170533418655396D), Telerik.Reporting.Drawing.Unit.Cm(0.72999995946884155D));
            this.textBox13.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox13.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox13.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox13.Style.Font.Bold = false;
            this.textBox13.Style.Font.Italic = false;
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox13.Value = "TAK/OEE";
            // 
            // textBox15
            // 
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7316670417785645D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox15.Style.Font.Bold = false;
            this.textBox15.Style.Font.Italic = false;
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox15.Value = "=Fields.ArticleNumber";
            // 
            // textBox16
            // 
            this.textBox16.Format = "{0:P1}";
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9170540571212769D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox16.Style.Font.Bold = false;
            this.textBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox16.Value = "=Fields.Oee";
            // 
            // textBox17
            // 
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.4300000667572022D), Telerik.Reporting.Drawing.Unit.Cm(0.729999840259552D));
            this.textBox17.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox17.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox17.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox17.Style.Font.Bold = false;
            this.textBox17.Style.Font.Italic = false;
            this.textBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox17.Value = "T";
            // 
            // textBox18
            // 
            this.textBox18.Format = "{0:P1}";
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.4300000667572022D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox18.Style.Font.Bold = false;
            this.textBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox18.Value = "=Fields.Availability";
            // 
            // textBox19
            // 
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.4300000667572022D), Telerik.Reporting.Drawing.Unit.Cm(0.72999989986419678D));
            this.textBox19.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox19.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox19.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox19.Style.Font.Bold = false;
            this.textBox19.Style.Font.Italic = false;
            this.textBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox19.Value = "A";
            // 
            // textBox20
            // 
            this.textBox20.Format = "{0:P1}";
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.4300000667572022D), Telerik.Reporting.Drawing.Unit.Cm(0.40000003576278687D));
            this.textBox20.Style.Font.Bold = false;
            this.textBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox20.Value = "=Fields.Performance";
            // 
            // textBox21
            // 
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.4300000667572022D), Telerik.Reporting.Drawing.Unit.Cm(0.729999840259552D));
            this.textBox21.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox21.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox21.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox21.Style.Font.Bold = false;
            this.textBox21.Style.Font.Italic = false;
            this.textBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox21.Value = "K";
            // 
            // textBox22
            // 
            this.textBox22.Format = "{0:P1}";
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.4300000667572022D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox22.Style.Font.Bold = false;
            this.textBox22.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox22.Value = "=Fields.Quality";
            // 
            // textBox6
            // 
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.729999840259552D));
            this.textBox6.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox6.Style.Font.Bold = false;
            this.textBox6.Style.Font.Italic = false;
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox6.Value = "Hastighet (cykler/h) ";
            // 
            // textBox7
            // 
            this.textBox7.Format = "{0:N0}";
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox7.Style.Font.Bold = false;
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox7.Value = "=Fields.RunRate";
            // 
            // textBox8
            // 
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2000002861022949D), Telerik.Reporting.Drawing.Unit.Cm(0.729999840259552D));
            this.textBox8.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox8.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox8.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox8.Style.Font.Bold = false;
            this.textBox8.Style.Font.Italic = false;
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox8.Value = "Idealhastighet (cykler/h)";
            // 
            // textBox9
            // 
            this.textBox9.Format = "{0:N0}";
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2000002861022949D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox9.Style.Font.Bold = false;
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox9.Value = "=Fields.IdealRunRate";
            // 
            // textBox10
            // 
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0399999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.72999989986419678D));
            this.textBox10.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox10.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox10.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox10.Style.Font.Bold = false;
            this.textBox10.Style.Font.Italic = false;
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox10.Value = "Producerat antal";
            // 
            // textBox11
            // 
            this.textBox11.Format = "{0:N0}";
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0399999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.40000003576278687D));
            this.textBox11.Style.Font.Bold = false;
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox11.Value = "=Fields.Produced";
            // 
            // textBox58
            // 
            this.textBox58.Name = "textBox58";
            this.textBox58.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.4299999475479126D), Telerik.Reporting.Drawing.Unit.Cm(0.729999840259552D));
            this.textBox58.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox58.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox58.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox58.Style.Font.Bold = false;
            this.textBox58.Style.Font.Italic = false;
            this.textBox58.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox58.StyleName = "";
            this.textBox58.Value = "Ff";
            // 
            // textBox59
            // 
            this.textBox59.Format = "{0:P1}";
            this.textBox59.Name = "textBox59";
            this.textBox59.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.4299999475479126D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox59.Style.Font.Bold = false;
            this.textBox59.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox59.StyleName = "";
            this.textBox59.Value = "=Fields.AvailabilityLossBasedOnFlowErrors";
            // 
            // textBox60
            // 
            this.textBox60.Name = "textBox60";
            this.textBox60.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.4300000667572022D), Telerik.Reporting.Drawing.Unit.Cm(0.729999840259552D));
            this.textBox60.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox60.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox60.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox60.Style.Font.Bold = false;
            this.textBox60.Style.Font.Italic = false;
            this.textBox60.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox60.StyleName = "";
            this.textBox60.Value = "Fs";
            // 
            // textBox61
            // 
            this.textBox61.Format = "{0:P1}";
            this.textBox61.Name = "textBox61";
            this.textBox61.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.4300000667572022D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox61.Style.Font.Bold = false;
            this.textBox61.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox61.StyleName = "";
            this.textBox61.Value = "=Fields.AvailabilityLossBasedOnActualStops";
            // 
            // textBox62
            // 
            this.textBox62.Name = "textBox62";
            this.textBox62.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.4300000667572022D), Telerik.Reporting.Drawing.Unit.Cm(0.72999989986419678D));
            this.textBox62.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox62.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox62.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox62.Style.Font.Bold = false;
            this.textBox62.Style.Font.Italic = false;
            this.textBox62.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox62.StyleName = "";
            this.textBox62.Value = "F";
            // 
            // textBox63
            // 
            this.textBox63.Format = "{0:P1}";
            this.textBox63.Name = "textBox63";
            this.textBox63.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.4300000667572022D), Telerik.Reporting.Drawing.Unit.Cm(0.40000003576278687D));
            this.textBox63.Style.Font.Bold = false;
            this.textBox63.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox63.StyleName = "";
            this.textBox63.Value = "=Fields.AvailabilityLoss";
            // 
            // list1
            // 
            this.list1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D)));
            this.list1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(4.4000000953674316D)));
            this.list1.Body.SetCellContent(0, 0, this.panel1);
            tableGroup15.Name = "ColumnGroup1";
            this.list1.ColumnGroups.Add(tableGroup15);
            this.list1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1});
            this.list1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.list1.Name = "list1";
            tableGroup16.Name = "RowGroup1";
            this.list1.RowGroups.Add(tableGroup16);
            this.list1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(4.4000000953674316D));
            this.list1.NeedDataSource += new System.EventHandler(this.list1_NeedDataSource);
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            panelOverview});
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(4.4000000953674316D));
            // 
            // panel5
            // 
            this.panel5.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel6,
            this.textBox1});
            this.panel5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(5D));
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
            // textBox1
            // 
            this.textBox1.CanShrink = false;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.627291202545166D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.textBox1.Multiline = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6799999475479126D), Telerik.Reporting.Drawing.Unit.Cm(0.34000000357627869D));
            this.textBox1.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox1.Style.Font.Italic = false;
            this.textBox1.Style.Font.Name = "Calibri";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.TextWrap = false;
            this.textBox1.Value = "Fördelning av tid";
            // 
            // panel3
            // 
            this.panel3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel7,
            this.textBox3});
            this.panel3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(8.6000003814697266D));
            this.panel3.Name = "panel3";
            this.panel3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(0.35718747973442078D));
            // 
            // panel7
            // 
            this.panel7.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.panel7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.22489582002162933D));
            this.panel7.Name = "panel7";
            this.panel7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(0.13229167461395264D));
            this.panel7.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.panel7.Style.BackgroundImage.MimeType = "";
            this.panel7.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.RepeatX;
            this.panel7.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel7.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.panel7.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            // 
            // textBox3
            // 
            this.textBox3.CanShrink = false;
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.627291202545166D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.textBox3.Multiline = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6799999475479126D), Telerik.Reporting.Drawing.Unit.Cm(0.34000000357627869D));
            this.textBox3.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox3.Style.Font.Italic = false;
            this.textBox3.Style.Font.Name = "Calibri";
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox3.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox3.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.TextWrap = false;
            this.textBox3.Value = "Fördelning av tid";
            // 
            // panel8
            // 
            this.panel8.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel9,
            this.textBox2});
            this.panel8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(15.600000381469727D));
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
            // textBox2
            // 
            this.textBox2.CanShrink = false;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.627291202545166D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.textBox2.Multiline = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6799999475479126D), Telerik.Reporting.Drawing.Unit.Cm(0.34000000357627869D));
            this.textBox2.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox2.Style.Font.Italic = false;
            this.textBox2.Style.Font.Name = "Calibri";
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox2.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.TextWrap = false;
            this.textBox2.Value = "Fördelning av tid";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(2.6800000667572021D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel4,
            this.panel2,
            this.textBox28,
            this.textBox23,
            this.textBox27,
            this.textBox24,
            this.textBox48,
            this.textBox49});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            this.pageHeaderSection1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pageHeaderSection1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.pageHeaderSection1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            // 
            // panel4
            // 
            this.panel4.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.shape1,
            this.tbShapeRow2,
            tbShapeRow1});
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
            this.tbShapeRow2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(1.1399999856948853D));
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
            // panel2
            // 
            this.panel2.Docking = Telerik.Reporting.DockingStyle.Left;
            this.panel2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox25,
            this.textBox26});
            this.panel2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel2.Name = "panel2";
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.5087203979492188D), Telerik.Reporting.Drawing.Unit.Cm(2.6800000667572021D));
            // 
            // textBox25
            // 
            this.textBox25.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.44999998807907104D), Telerik.Reporting.Drawing.Unit.Cm(1.2300000190734863D));
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.9800000190734863D), Telerik.Reporting.Drawing.Unit.Cm(0.41999998688697815D));
            this.textBox25.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox25.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat;
            this.textBox25.Style.Color = System.Drawing.Color.Gray;
            this.textBox25.Style.Font.Bold = false;
            this.textBox25.Style.Font.Italic = true;
            this.textBox25.Style.Font.Name = "Calibri";
            this.textBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox25.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox25.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox25.StyleName = "Title";
            this.textBox25.Value = "Månadsrapport";
            // 
            // textBox26
            // 
            this.textBox26.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.44999998807907104D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.9800000190734863D), Telerik.Reporting.Drawing.Unit.Cm(0.62999999523162842D));
            this.textBox26.Style.Color = System.Drawing.Color.Black;
            this.textBox26.Style.Font.Name = "Calibri";
            this.textBox26.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.textBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox26.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox26.Style.Visible = true;
            this.textBox26.StyleName = "Title";
            this.textBox26.Value = "TAK/OEE";
            // 
            // textBox28
            // 
            this.textBox28.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.050000190734863D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8899999856948853D), Telerik.Reporting.Drawing.Unit.Cm(0.38999998569488525D));
            this.textBox28.Style.Color = System.Drawing.Color.Gray;
            this.textBox28.Style.Font.Italic = true;
            this.textBox28.Style.Font.Name = "Calibri";
            this.textBox28.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox28.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox28.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox28.Style.Visible = true;
            this.textBox28.StyleName = "Title";
            this.textBox28.Value = "Avdelning:";
            // 
            // textBox23
            // 
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6600000858306885D), Telerik.Reporting.Drawing.Unit.Cm(0.38999998569488525D));
            this.textBox23.Style.Color = System.Drawing.Color.Black;
            this.textBox23.Style.Font.Name = "Calibri";
            this.textBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox23.Style.Visible = true;
            this.textBox23.StyleName = "Title";
            this.textBox23.Value = "= Fields.Division";
            // 
            // textBox27
            // 
            this.textBox27.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13D), Telerik.Reporting.Drawing.Unit.Cm(0.99000000953674316D));
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6600000858306885D), Telerik.Reporting.Drawing.Unit.Cm(0.38999998569488525D));
            this.textBox27.Style.Color = System.Drawing.Color.Black;
            this.textBox27.Style.Font.Name = "Calibri";
            this.textBox27.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox27.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox27.Style.Visible = true;
            this.textBox27.StyleName = "Title";
            this.textBox27.Value = "= Fields.Machine";
            // 
            // textBox24
            // 
            this.textBox24.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.050000190734863D), Telerik.Reporting.Drawing.Unit.Cm(0.99000000953674316D));
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
            this.textBox24.Value = "Maskin:";
            // 
            // textBox48
            // 
            this.textBox48.Format = "{0:d}";
            this.textBox48.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13D), Telerik.Reporting.Drawing.Unit.Cm(1.3867708444595337D));
            this.textBox48.Name = "textBox48";
            this.textBox48.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6600000858306885D), Telerik.Reporting.Drawing.Unit.Cm(0.38999998569488525D));
            this.textBox48.Style.Color = System.Drawing.Color.Black;
            this.textBox48.Style.Font.Name = "Calibri";
            this.textBox48.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox48.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox48.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox48.Style.Visible = true;
            this.textBox48.StyleName = "Title";
            this.textBox48.Value = "= Fields.Shift";
            // 
            // textBox49
            // 
            this.textBox49.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.050000190734863D), Telerik.Reporting.Drawing.Unit.Cm(1.3867708444595337D));
            this.textBox49.Name = "textBox49";
            this.textBox49.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8899999856948853D), Telerik.Reporting.Drawing.Unit.Cm(0.38999998569488525D));
            this.textBox49.Style.Color = System.Drawing.Color.Gray;
            this.textBox49.Style.Font.Italic = true;
            this.textBox49.Style.Font.Name = "Calibri";
            this.textBox49.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox49.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox49.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox49.Style.Visible = true;
            this.textBox49.StyleName = "Title";
            this.textBox49.Value = "Skift:";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.0099999904632568D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox44,
            this.textBox31,
            this.textBox45,
            this.textBox46,
            this.textBox47,
            this.textBox50,
            this.pictureBoxLogo});
            this.pageFooterSection1.Name = "pageFooterSection1";
            this.pageFooterSection1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.pageFooterSection1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pageFooterSection1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            // 
            // textBox44
            // 
            this.textBox44.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.12999999523162842D));
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
            this.textBox44.StyleName = "Title";
            this.textBox44.Value = "Genererad av M2M DataCenter";
            // 
            // textBox31
            // 
            this.textBox31.CanShrink = true;
            this.textBox31.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D), Telerik.Reporting.Drawing.Unit.Cm(0.62999999523162842D));
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.37000000476837158D), Telerik.Reporting.Drawing.Unit.Cm(0.37000000476837158D));
            this.textBox31.Style.Color = System.Drawing.Color.Gray;
            this.textBox31.Style.Font.Italic = true;
            this.textBox31.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox31.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox31.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox31.TextWrap = false;
            this.textBox31.Value = "= PageNumber";
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
            // textBox47
            // 
            this.textBox47.CanShrink = true;
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
            // MachineOeeMonthly
            // 
            this.DocumentName = "= M2M.DataCenter.Reports.MachineOeeMonthly.GetDocumentName(Parameters.MachineId.V" +
    "alue, Parameters.Year.Value, Parameters.Month.Value)";
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageHeaderSection1,
            this.pageFooterSection1});
            this.Name = "MachineOeeMonthly";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Cm(1.6000000238418579D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "DivisionId";
            reportParameter1.Text = "Avdelning";
            reportParameter2.Name = "MachineId";
            reportParameter2.Text = "Maskin";
            reportParameter3.Name = "Year";
            reportParameter3.Text = "År";
            reportParameter3.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter4.Name = "ShiftType";
            reportParameter4.Text = "Skift";
            reportParameter5.Name = "Month";
            reportParameter5.Text = "Månad";
            reportParameter5.Type = Telerik.Reporting.ReportParameterType.Integer;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
            this.ReportParameters.Add(reportParameter5);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(18.599899291992188D);
            this.NeedDataSource += new System.EventHandler(this.Machine_NeedDataSource);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DetailSection detail;
        private Chart chartTotalOee;
        private Chart chartPeriodicOee;
        private Table tableArticles;
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
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private List list1;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.TextBox tbProductionTime;
        private Telerik.Reporting.TextBox tbAvailability;
        private Telerik.Reporting.TextBox tbPerformance;
        private Telerik.Reporting.TextBox tbQuality;
        private Telerik.Reporting.TextBox tbTotalTime;
        private Telerik.Reporting.TextBox tbStopTime;
        private Telerik.Reporting.TextBox tbOee;
        private Telerik.Reporting.TextBox textBox29;
        private Telerik.Reporting.TextBox textBox30;
        private Telerik.Reporting.TextBox textBox32;
        private Telerik.Reporting.TextBox textBox33;
        private Telerik.Reporting.TextBox textBox34;
        private Telerik.Reporting.TextBox textBox36;
        private Telerik.Reporting.TextBox textBox37;
        private PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.TextBox textBox26;
        private Telerik.Reporting.Panel panel4;
        private Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.TextBox textBox24;
        private Telerik.Reporting.TextBox textBox27;
        private Telerik.Reporting.TextBox textBox28;
        private Telerik.Reporting.Panel panel2;
        private Telerik.Reporting.TextBox textBox25;
        private PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox textBox44;
        private Telerik.Reporting.TextBox textBox31;
        private Telerik.Reporting.TextBox textBox45;
        private Telerik.Reporting.TextBox textBox46;
        private Telerik.Reporting.TextBox textBox47;
        private Telerik.Reporting.TextBox textBox49;
        private Telerik.Reporting.TextBox textBox48;
        private Telerik.Reporting.TextBox textBox50;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox35;
        private Telerik.Reporting.TextBox textBox38;
        private Telerik.Reporting.TextBox textBox39;
        private Telerik.Reporting.TextBox textBox40;
        private Telerik.Reporting.TextBox textBox55;
        private Telerik.Reporting.TextBox textBox41;
        private Telerik.Reporting.TextBox textBox42;
        private Telerik.Reporting.TextBox textBox43;
        private Telerik.Reporting.TextBox textBox51;
        private Telerik.Reporting.TextBox textBox52;
        private Telerik.Reporting.TextBox textBox53;
        private Telerik.Reporting.TextBox textBox54;
        private Telerik.Reporting.TextBox textBox56;
        private Telerik.Reporting.TextBox textBox57;
        private Telerik.Reporting.TextBox textBox58;
        private Telerik.Reporting.TextBox textBox59;
        private Telerik.Reporting.TextBox textBox60;
        private Telerik.Reporting.TextBox textBox61;
        private Telerik.Reporting.TextBox textBox62;
        private Telerik.Reporting.TextBox textBox63;
        private Shape shape1;
        private Telerik.Reporting.TextBox tbShapeRow2;
        private Telerik.Reporting.PictureBox pictureBoxLogo;
        private Telerik.Reporting.Panel panel5;
        private Telerik.Reporting.Panel panel6;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.Panel panel3;
        private Telerik.Reporting.Panel panel7;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.Panel panel8;
        private Telerik.Reporting.Panel panel9;
        private Telerik.Reporting.TextBox textBox2;
    }
}