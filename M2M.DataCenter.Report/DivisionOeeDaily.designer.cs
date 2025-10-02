namespace M2M.DataCenter.Reports
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class DivisionOeeDaily
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Panel panelOverview;
            Telerik.Reporting.PageFooterSection pageFooterSection1;
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
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins3 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartPaddings chartPaddings1 = new Telerik.Reporting.Charting.Styles.ChartPaddings();
            Telerik.Reporting.Charting.Palette palette2 = new Telerik.Reporting.Charting.Palette();
            Telerik.Reporting.Charting.PaletteItem paletteItem5 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem6 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem7 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem8 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem9 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem10 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins4 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartSeries chartSeries5 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins5 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartPaddings chartPaddings2 = new Telerik.Reporting.Charting.Styles.ChartPaddings();
            Telerik.Reporting.Charting.Palette palette3 = new Telerik.Reporting.Charting.Palette();
            Telerik.Reporting.Charting.PaletteItem paletteItem11 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem12 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem13 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem14 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem15 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem16 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins6 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartSeries chartSeries6 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.TableGroup tableGroup14 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup15 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup16 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup17 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup18 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup19 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup20 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup21 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup22 = new Telerik.Reporting.TableGroup();
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
            this.textBox51 = new Telerik.Reporting.TextBox();
            this.textBox52 = new Telerik.Reporting.TextBox();
            this.textBox53 = new Telerik.Reporting.TextBox();
            this.textBox54 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox49 = new Telerik.Reporting.TextBox();
            this.textBox55 = new Telerik.Reporting.TextBox();
            this.textBox44 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox45 = new Telerik.Reporting.TextBox();
            this.textBox46 = new Telerik.Reporting.TextBox();
            this.textBox47 = new Telerik.Reporting.TextBox();
            this.textBox50 = new Telerik.Reporting.TextBox();
            this.pictureBoxLogo = new Telerik.Reporting.PictureBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.chartTotalOee = new Telerik.Reporting.Chart();
            this.tableMachines = new Telerik.Reporting.Table();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.textBox22 = new Telerik.Reporting.TextBox();
            this.textBox59 = new Telerik.Reporting.TextBox();
            this.textBox60 = new Telerik.Reporting.TextBox();
            this.textBox61 = new Telerik.Reporting.TextBox();
            this.textBox62 = new Telerik.Reporting.TextBox();
            this.textBox63 = new Telerik.Reporting.TextBox();
            this.textBox64 = new Telerik.Reporting.TextBox();
            this.textBox67 = new Telerik.Reporting.TextBox();
            this.textBox68 = new Telerik.Reporting.TextBox();
            this.list1 = new Telerik.Reporting.List();
            this.panel1 = new Telerik.Reporting.Panel();
            this.panel3 = new Telerik.Reporting.Panel();
            this.chartStopCount = new Telerik.Reporting.Chart();
            this.chartStopTime = new Telerik.Reporting.Chart();
            this.panel9 = new Telerik.Reporting.Panel();
            this.panel10 = new Telerik.Reporting.Panel();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.panel11 = new Telerik.Reporting.Panel();
            this.panel12 = new Telerik.Reporting.Panel();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.tableStops = new Telerik.Reporting.Table();
            this.textBox27 = new Telerik.Reporting.TextBox();
            this.textBox28 = new Telerik.Reporting.TextBox();
            this.textBox31 = new Telerik.Reporting.TextBox();
            this.textBox35 = new Telerik.Reporting.TextBox();
            this.textBox38 = new Telerik.Reporting.TextBox();
            this.textBox39 = new Telerik.Reporting.TextBox();
            this.textBox40 = new Telerik.Reporting.TextBox();
            this.textBox41 = new Telerik.Reporting.TextBox();
            this.textBox42 = new Telerik.Reporting.TextBox();
            this.textBox43 = new Telerik.Reporting.TextBox();
            this.textBox57 = new Telerik.Reporting.TextBox();
            this.textBox58 = new Telerik.Reporting.TextBox();
            this.textBox65 = new Telerik.Reporting.TextBox();
            this.textBox66 = new Telerik.Reporting.TextBox();
            this.panel5 = new Telerik.Reporting.Panel();
            this.panel6 = new Telerik.Reporting.Panel();
            this.textBox25 = new Telerik.Reporting.TextBox();
            this.panel7 = new Telerik.Reporting.Panel();
            this.panel8 = new Telerik.Reporting.Panel();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.tbHeaderLeft = new Telerik.Reporting.TextBox();
            this.tbHeader = new Telerik.Reporting.TextBox();
            this.tbDivisionPrompt = new Telerik.Reporting.TextBox();
            this.tbDivisionName = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.panel2 = new Telerik.Reporting.Panel();
            this.panel4 = new Telerik.Reporting.Panel();
            this.shape1 = new Telerik.Reporting.Shape();
            this.tbShapeRow2 = new Telerik.Reporting.TextBox();
            this.tbShiftPrompt = new Telerik.Reporting.TextBox();
            this.textBox48 = new Telerik.Reporting.TextBox();
            this.textBox56 = new Telerik.Reporting.TextBox();
            this.tbCategoriesPrompt = new Telerik.Reporting.TextBox();
            panelOverview = new Telerik.Reporting.Panel();
            pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
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
            this.textBox51,
            this.textBox52,
            this.textBox53,
            this.textBox54,
            this.textBox1,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox49,
            this.textBox55});
            panelOverview.Name = "panelOverview";
            panelOverview.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(4.4000000953674316D));
            panelOverview.Style.BackgroundColor = System.Drawing.Color.White;
            panelOverview.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            // 
            // tbProductionTime
            // 
            this.tbProductionTime.Format = "{0:N1} tim";
            this.tbProductionTime.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0802001953125D), Telerik.Reporting.Drawing.Unit.Cm(1.7356666326522827D));
            this.tbProductionTime.Name = "tbProductionTime";
            this.tbProductionTime.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.tbProductionTime.Value = "=Fields.ActualProductionTimeInHours";
            // 
            // tbAvailability
            // 
            this.tbAvailability.Format = "{0:P1}";
            this.tbAvailability.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.208324432373047D), Telerik.Reporting.Drawing.Unit.Cm(0.66675001382827759D));
            this.tbAvailability.Name = "tbAvailability";
            this.tbAvailability.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.tbAvailability.Value = "=Fields.Availability";
            // 
            // tbPerformance
            // 
            this.tbPerformance.Format = "{0:P1}";
            this.tbPerformance.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.208324432373047D), Telerik.Reporting.Drawing.Unit.Cm(1.2012083530426025D));
            this.tbPerformance.Name = "tbPerformance";
            this.tbPerformance.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.tbPerformance.Value = "=Fields.Performance";
            // 
            // tbQuality
            // 
            this.tbQuality.Format = "{0:P1}";
            this.tbQuality.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.208324432373047D), Telerik.Reporting.Drawing.Unit.Cm(1.7356666326522827D));
            this.tbQuality.Name = "tbQuality";
            this.tbQuality.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.tbQuality.Style.Visible = true;
            this.tbQuality.Value = "=Fields.Quality";
            // 
            // tbTotalTime
            // 
            this.tbTotalTime.Format = "{0:N1} tim";
            this.tbTotalTime.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0802001953125D), Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D));
            this.tbTotalTime.Name = "tbTotalTime";
            this.tbTotalTime.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.tbTotalTime.Value = "=Fields.ScheduledTimeInHours";
            // 
            // tbStopTime
            // 
            this.tbStopTime.Format = "{0:N1} tim";
            this.tbStopTime.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0802001953125D), Telerik.Reporting.Drawing.Unit.Cm(0.66675001382827759D));
            this.tbStopTime.Name = "tbStopTime";
            this.tbStopTime.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.42333352565765381D));
            this.tbStopTime.Value = "=Fields.NoProductionTimeInHours";
            // 
            // tbOee
            // 
            this.tbOee.Format = "{0:P1}";
            this.tbOee.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.199999809265137D), Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D));
            this.tbOee.Name = "tbOee";
            this.tbOee.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.tbOee.Value = "=Fields.Oee";
            // 
            // textBox29
            // 
            this.textBox29.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.82020831108093262D), Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D));
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox29.Value = "Schemalagd tid:";
            // 
            // textBox30
            // 
            this.textBox30.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.82020831108093262D), Telerik.Reporting.Drawing.Unit.Cm(1.7356666326522827D));
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox30.Value = "Tillgänglig tid:";
            // 
            // textBox32
            // 
            this.textBox32.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.44979164004325867D), Telerik.Reporting.Drawing.Unit.Cm(0.66675001382827759D));
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.6302080154418945D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox32.Value = "Maskin ej i produktion:";
            // 
            // textBox33
            // 
            this.textBox33.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9400081634521484D), Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144D));
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox33.Value = "TAK/OEE:";
            // 
            // textBox34
            // 
            this.textBox34.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9483327865600586D), Telerik.Reporting.Drawing.Unit.Cm(0.66675001382827759D));
            this.textBox34.Name = "textBox34";
            this.textBox34.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox34.Value = "Tillgänglighet (T):";
            // 
            // textBox36
            // 
            this.textBox36.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9483327865600586D), Telerik.Reporting.Drawing.Unit.Cm(1.2012083530426025D));
            this.textBox36.Name = "textBox36";
            this.textBox36.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox36.Value = "Anläggningsutbyte (A):";
            // 
            // textBox37
            // 
            this.textBox37.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9483327865600586D), Telerik.Reporting.Drawing.Unit.Cm(1.7356666326522827D));
            this.textBox37.Name = "textBox37";
            this.textBox37.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox37.Value = "Kvalitet (K):";
            // 
            // textBox51
            // 
            this.textBox51.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.44979164004325867D), Telerik.Reporting.Drawing.Unit.Cm(2.2701249122619629D));
            this.textBox51.Name = "textBox51";
            this.textBox51.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.6302080154418945D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox51.Value = "Effektiv produktionstid:";
            // 
            // textBox52
            // 
            this.textBox52.Format = "{0:N1} tim";
            this.textBox52.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0802001953125D), Telerik.Reporting.Drawing.Unit.Cm(2.2701249122619629D));
            this.textBox52.Name = "textBox52";
            this.textBox52.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.42333352565765381D));
            this.textBox52.Value = "=Fields.AutoTimeInHours";
            // 
            // textBox53
            // 
            this.textBox53.Format = "{0:N1} tim";
            this.textBox53.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0802001953125D), Telerik.Reporting.Drawing.Unit.Cm(2.8045833110809326D));
            this.textBox53.Name = "textBox53";
            this.textBox53.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.42333352565765381D));
            this.textBox53.Value = "=Fields.StopTimeInHours";
            // 
            // textBox54
            // 
            this.textBox54.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.44979164004325867D), Telerik.Reporting.Drawing.Unit.Cm(2.8045833110809326D));
            this.textBox54.Name = "textBox54";
            this.textBox54.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.6302080154418945D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox54.Value = "Stopptid:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.44979164004325867D), Telerik.Reporting.Drawing.Unit.Cm(1.2012083530426025D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.6302080154418945D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox1.Value = "Ingen kontakt med maskin:";
            // 
            // textBox3
            // 
            this.textBox3.Format = "{0:N1} tim";
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0802001953125D), Telerik.Reporting.Drawing.Unit.Cm(1.2012083530426025D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.42333352565765381D));
            this.textBox3.Value = "=Fields.NotConnectedTimeInHours";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.44979164004325867D), Telerik.Reporting.Drawing.Unit.Cm(3.3337500095367432D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.6302080154418945D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox4.Value = "Stopptid faktiska stopp:";
            // 
            // textBox5
            // 
            this.textBox5.Format = "{0:N1} tim";
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0799999237060547D), Telerik.Reporting.Drawing.Unit.Cm(3.3337500095367432D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.42333352565765381D));
            this.textBox5.Value = "=Fields.ActualStopTimeInHours";
            // 
            // textBox6
            // 
            this.textBox6.Format = "{0:N1} tim";
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0799999237060547D), Telerik.Reporting.Drawing.Unit.Cm(3.8629164695739746D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.42333352565765381D));
            this.textBox6.Value = "=Fields.FlowErrorTimeInHours";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.44979164004325867D), Telerik.Reporting.Drawing.Unit.Cm(3.8629164695739746D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.6302080154418945D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox7.Value = "Stopptid flödesfel:";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.9400081634521484D), Telerik.Reporting.Drawing.Unit.Cm(2.8045833110809326D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox8.Value = "Tillgänglighetsförlust (F):";
            // 
            // textBox9
            // 
            this.textBox9.Format = "{0:P1}";
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.199999809265137D), Telerik.Reporting.Drawing.Unit.Cm(2.8045833110809326D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox9.Style.Visible = true;
            this.textBox9.Value = "=Fields.AvailabilityLoss";
            // 
            // textBox10
            // 
            this.textBox10.Format = "{0:P1}";
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.199999809265137D), Telerik.Reporting.Drawing.Unit.Cm(3.3337500095367432D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox10.Style.Visible = true;
            this.textBox10.Value = "=Fields.AvailabilityLossBasedOnActualStops";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(3.3337500095367432D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.9000000953674316D), Telerik.Reporting.Drawing.Unit.Cm(0.41999998688697815D));
            this.textBox11.Value = "...baserat på faktiska stopp (Fs):";
            // 
            // textBox49
            // 
            this.textBox49.Format = "{0:P1}";
            this.textBox49.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.199999809265137D), Telerik.Reporting.Drawing.Unit.Cm(3.8629164695739746D));
            this.textBox49.Name = "textBox49";
            this.textBox49.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox49.Style.Visible = true;
            this.textBox49.Value = "=Fields.AvailabilityLossBasedOnFlowErrors";
            // 
            // textBox55
            // 
            this.textBox55.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(3.8629164695739746D));
            this.textBox55.Name = "textBox55";
            this.textBox55.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.8997993469238281D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox55.Value = "...baserat på flödesfel (Ff):";
            // 
            // pageFooterSection1
            // 
            pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.0099999904632568D);
            pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox44,
            this.textBox2,
            this.textBox45,
            this.textBox46,
            this.textBox47,
            this.textBox50,
            this.pictureBoxLogo});
            pageFooterSection1.Name = "pageFooterSection1";
            pageFooterSection1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            pageFooterSection1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            pageFooterSection1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            pageFooterSection1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
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
            // textBox2
            // 
            this.textBox2.CanShrink = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D), Telerik.Reporting.Drawing.Unit.Cm(0.62999999523162842D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.37000000476837158D), Telerik.Reporting.Drawing.Unit.Cm(0.37000000476837158D));
            this.textBox2.Style.Color = System.Drawing.Color.Gray;
            this.textBox2.Style.Font.Italic = true;
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox2.TextWrap = false;
            this.textBox2.Value = "= PageNumber";
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
            // tbShapeRow1
            // 
            tbShapeRow1.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            tbShapeRow1.Format = "{0:dd MMM}";
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
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(16.079999923706055D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.chartTotalOee,
            this.tableMachines,
            this.list1,
            this.panel3,
            this.tableStops,
            this.panel5,
            this.panel7});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.Font.Italic = true;
            this.detail.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.detail.Style.Visible = true;
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
            // tableMachines
            // 
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(4.5610384941101074D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.9999996423721314D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.9999996423721314D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.9999996423721314D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.0000009536743164D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.0000009536743164D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.9999996423721314D)));
            this.tableMachines.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.9999996423721314D)));
            this.tableMachines.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D)));
            this.tableMachines.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D)));
            this.tableMachines.Body.SetCellContent(0, 0, this.textBox12);
            this.tableMachines.Body.SetCellContent(0, 1, this.textBox13);
            this.tableMachines.Body.SetCellContent(1, 0, this.textBox15);
            this.tableMachines.Body.SetCellContent(1, 1, this.textBox16);
            this.tableMachines.Body.SetCellContent(0, 6, this.textBox19);
            this.tableMachines.Body.SetCellContent(1, 6, this.textBox20);
            this.tableMachines.Body.SetCellContent(0, 7, this.textBox21);
            this.tableMachines.Body.SetCellContent(1, 7, this.textBox22);
            this.tableMachines.Body.SetCellContent(0, 5, this.textBox59);
            this.tableMachines.Body.SetCellContent(1, 5, this.textBox60);
            this.tableMachines.Body.SetCellContent(0, 4, this.textBox61);
            this.tableMachines.Body.SetCellContent(1, 4, this.textBox62);
            this.tableMachines.Body.SetCellContent(0, 3, this.textBox63);
            this.tableMachines.Body.SetCellContent(1, 3, this.textBox64);
            this.tableMachines.Body.SetCellContent(0, 2, this.textBox67);
            this.tableMachines.Body.SetCellContent(1, 2, this.textBox68);
            tableGroup3.Name = "Group8";
            tableGroup4.Name = "Group6";
            tableGroup5.Name = "Group5";
            tableGroup6.Name = "Group4";
            tableGroup7.Name = "Group2";
            tableGroup8.Name = "Group3";
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
            this.textBox19,
            this.textBox20,
            this.textBox21,
            this.textBox22,
            this.textBox59,
            this.textBox60,
            this.textBox61,
            this.textBox62,
            this.textBox63,
            this.textBox64,
            this.textBox67,
            this.textBox68});
            this.tableMachines.KeepTogether = false;
            this.tableMachines.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D));
            this.tableMachines.Name = "tableMachines";
            tableGroup11.Name = "Group7";
            tableGroup10.ChildGroups.Add(tableGroup11);
            tableGroup10.Groupings.Add(new Telerik.Reporting.Grouping(""));
            tableGroup10.Name = "detailGroup";
            this.tableMachines.RowGroups.Add(tableGroup9);
            this.tableMachines.RowGroups.Add(tableGroup10);
            this.tableMachines.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.561038970947266D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D));
            this.tableMachines.Style.BackgroundColor = System.Drawing.Color.White;
            this.tableMachines.Style.Font.Name = "Verdana";
            this.tableMachines.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.tableMachines.Style.Visible = true;
            this.tableMachines.NeedDataSource += new System.EventHandler(this.tableMachines_NeedDataSource);
            // 
            // textBox12
            // 
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.5610380172729492D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox12.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox12.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox12.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox12.Style.Font.Bold = false;
            this.textBox12.Style.Font.Name = "Calibri";
            // 
            // textBox13
            // 
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9999996423721314D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox13.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox13.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox13.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox13.Style.Font.Bold = false;
            this.textBox13.Style.Font.Italic = false;
            this.textBox13.Style.Font.Name = "Calibri";
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox13.Value = "TAK/OEE";
            // 
            // textBox15
            // 
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.5610380172729492D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox15.Style.Font.Bold = false;
            this.textBox15.Style.Font.Italic = false;
            this.textBox15.Style.Font.Name = "Calibri";
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox15.Value = "=Fields.Machine";
            // 
            // textBox16
            // 
            this.textBox16.Format = "{0:P1}";
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9999996423721314D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox16.Style.Font.Name = "Calibri";
            this.textBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox16.Value = "=Fields.Oee";
            // 
            // textBox19
            // 
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9999996423721314D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox19.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox19.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox19.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox19.Style.Font.Bold = false;
            this.textBox19.Style.Font.Italic = false;
            this.textBox19.Style.Font.Name = "Calibri";
            this.textBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox19.Value = "A";
            // 
            // textBox20
            // 
            this.textBox20.Format = "{0:P1}";
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9999996423721314D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox20.Style.Font.Name = "Calibri";
            this.textBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox20.Value = "=Fields.Performance";
            // 
            // textBox21
            // 
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9999996423721314D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox21.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox21.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox21.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox21.Style.Font.Bold = false;
            this.textBox21.Style.Font.Italic = false;
            this.textBox21.Style.Font.Name = "Calibri";
            this.textBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox21.Value = "K";
            // 
            // textBox22
            // 
            this.textBox22.Format = "{0:P1}";
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9999996423721314D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox22.Style.Font.Name = "Calibri";
            this.textBox22.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox22.Value = "=Fields.Quality";
            // 
            // textBox59
            // 
            this.textBox59.Name = "textBox59";
            this.textBox59.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0000007152557373D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox59.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox59.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox59.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox59.Style.Font.Bold = false;
            this.textBox59.Style.Font.Italic = false;
            this.textBox59.Style.Font.Name = "Calibri";
            this.textBox59.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox59.StyleName = "";
            this.textBox59.Value = "Ff";
            // 
            // textBox60
            // 
            this.textBox60.Format = "{0:P1}";
            this.textBox60.Name = "textBox60";
            this.textBox60.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0000007152557373D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox60.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox60.Style.Font.Name = "Calibri";
            this.textBox60.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox60.StyleName = "";
            this.textBox60.Value = "=Fields.AvailabilityLossBasedOnFlowErrors";
            // 
            // textBox61
            // 
            this.textBox61.Name = "textBox61";
            this.textBox61.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0000007152557373D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox61.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox61.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox61.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox61.Style.Font.Bold = false;
            this.textBox61.Style.Font.Italic = false;
            this.textBox61.Style.Font.Name = "Calibri";
            this.textBox61.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox61.StyleName = "";
            this.textBox61.Value = "Fs";
            // 
            // textBox62
            // 
            this.textBox62.Format = "{0:P1}";
            this.textBox62.Name = "textBox62";
            this.textBox62.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0000007152557373D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox62.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox62.Style.Font.Name = "Calibri";
            this.textBox62.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox62.StyleName = "";
            this.textBox62.Value = "=Fields.AvailabilityLossBasedOnActualStops";
            // 
            // textBox63
            // 
            this.textBox63.Name = "textBox63";
            this.textBox63.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9999996423721314D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox63.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox63.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox63.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox63.Style.Font.Bold = false;
            this.textBox63.Style.Font.Italic = false;
            this.textBox63.Style.Font.Name = "Calibri";
            this.textBox63.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox63.StyleName = "";
            this.textBox63.Value = "F";
            // 
            // textBox64
            // 
            this.textBox64.Format = "{0:P1}";
            this.textBox64.Name = "textBox64";
            this.textBox64.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9999996423721314D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox64.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox64.Style.Font.Name = "Calibri";
            this.textBox64.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox64.StyleName = "";
            this.textBox64.Value = "=Fields.AvailabilityLoss";
            // 
            // textBox67
            // 
            this.textBox67.Name = "textBox67";
            this.textBox67.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox67.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox67.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox67.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox67.Style.Font.Bold = false;
            this.textBox67.Style.Font.Italic = false;
            this.textBox67.Style.Font.Name = "Calibri";
            this.textBox67.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox67.StyleName = "";
            this.textBox67.Value = "T";
            // 
            // textBox68
            // 
            this.textBox68.Format = "{0:P1}";
            this.textBox68.Name = "textBox68";
            this.textBox68.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox68.Style.Font.Name = "Calibri";
            this.textBox68.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox68.StyleName = "";
            this.textBox68.Value = "=Fields.Availability";
            // 
            // list1
            // 
            this.list1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D)));
            this.list1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(4.4000000953674316D)));
            this.list1.Body.SetCellContent(0, 0, this.panel1);
            tableGroup12.Name = "ColumnGroup1";
            this.list1.ColumnGroups.Add(tableGroup12);
            this.list1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1});
            this.list1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.list1.Name = "list1";
            tableGroup13.Name = "RowGroup1";
            this.list1.RowGroups.Add(tableGroup13);
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
            // panel3
            // 
            this.panel3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.chartStopCount,
            this.chartStopTime,
            this.panel9,
            this.panel11});
            this.panel3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(10.5D));
            this.panel3.Name = "panel3";
            this.panel3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(4.0999999046325684D));
            // 
            // chartStopCount
            // 
            this.chartStopCount.Appearance.Border.Visible = false;
            this.chartStopCount.Appearance.Dimensions.AutoSize = false;
            this.chartStopCount.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(139D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins3.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins3.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins3.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins3.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.Appearance.Dimensions.Margins = chartMargins3;
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
            paletteItem5.MainColor = System.Drawing.Color.Red;
            paletteItem5.Name = "PaletteItem 6";
            paletteItem5.SecondColor = System.Drawing.Color.DarkOrange;
            paletteItem6.MainColor = System.Drawing.Color.Blue;
            paletteItem6.Name = "PaletteItem 1";
            paletteItem6.SecondColor = System.Drawing.Color.LightSkyBlue;
            paletteItem7.MainColor = System.Drawing.Color.Green;
            paletteItem7.Name = "PaletteItem 2";
            paletteItem7.SecondColor = System.Drawing.Color.GreenYellow;
            paletteItem8.MainColor = System.Drawing.Color.DarkGoldenrod;
            paletteItem8.Name = "PaletteItem 3";
            paletteItem8.SecondColor = System.Drawing.Color.Gold;
            paletteItem9.MainColor = System.Drawing.Color.DarkGray;
            paletteItem9.Name = "PaletteItem 4";
            paletteItem9.SecondColor = System.Drawing.Color.White;
            paletteItem10.MainColor = System.Drawing.Color.Pink;
            paletteItem10.Name = "PaletteItem 5";
            paletteItem10.SecondColor = System.Drawing.Color.PeachPuff;
            palette2.Items.AddRange(new Telerik.Reporting.Charting.PaletteItem[] {
            paletteItem5,
            paletteItem6,
            paletteItem7,
            paletteItem8,
            paletteItem9,
            paletteItem10});
            palette2.Name = "Palette1";
            this.chartStopCount.CustomPalettes.AddRange(new Telerik.Reporting.Charting.Palette[] {
            palette2});
            this.chartStopCount.DefaultType = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chartStopCount.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chartStopCount.IntelligentLabelsEnabled = true;
            this.chartStopCount.Legend.Appearance.Border.Visible = false;
            this.chartStopCount.Legend.Appearance.ItemTextAppearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartStopCount.Legend.TextBlock.Appearance.Dimensions.AutoSize = false;
            this.chartStopCount.Legend.TextBlock.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.Legend.TextBlock.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.Legend.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartStopCount.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.chartStopCount.Name = "chartStopCount";
            this.chartStopCount.PlotArea.Appearance.Border.Visible = false;
            chartMargins4.Right = new Telerik.Reporting.Charting.Styles.Unit(160D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.PlotArea.Appearance.Dimensions.Margins = chartMargins4;
            this.chartStopCount.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartStopCount.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chartStopCount.PlotArea.Appearance.SeriesPalette = "Palette1";
            this.chartStopCount.PlotArea.EmptySeriesMessage.TextBlock.Visible = false;
            this.chartStopCount.PlotArea.XAxis.MinValue = 1D;
            chartSeries5.Appearance.CenterXOffset = -30;
            chartSeries5.Appearance.DiameterScale = 0.85D;
            chartSeries5.Appearance.LegendDisplayMode = Telerik.Reporting.Charting.ChartSeriesLegendDisplayMode.ItemLabels;
            chartSeries5.Appearance.ShowLabels = false;
            chartSeries5.DataLabelsColumn = "ReasonWithMachinePrefix";
            chartSeries5.DataYColumn = "NumberOfStops";
            chartSeries5.DefaultLabelValue = "";
            chartSeries5.Name = "Series 1";
            chartSeries5.Type = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chartStopCount.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries5});
            this.chartStopCount.SeriesPalette = "Palette1";
            this.chartStopCount.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(3.7000000476837158D));
            this.chartStopCount.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.chartStopCount.Style.Visible = true;
            this.chartStopCount.NeedDataSource += new System.EventHandler(this.chartStopCount_NeedDataSource);
            // 
            // chartStopTime
            // 
            this.chartStopTime.Appearance.Border.Visible = false;
            this.chartStopTime.Appearance.Dimensions.AutoSize = false;
            this.chartStopTime.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(139D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins5.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins5.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins5.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins5.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopTime.Appearance.Dimensions.Margins = chartMargins5;
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
            paletteItem11.MainColor = System.Drawing.Color.Red;
            paletteItem11.Name = "PaletteItem 6";
            paletteItem11.SecondColor = System.Drawing.Color.DarkOrange;
            paletteItem12.MainColor = System.Drawing.Color.Blue;
            paletteItem12.Name = "PaletteItem 1";
            paletteItem12.SecondColor = System.Drawing.Color.LightSkyBlue;
            paletteItem13.MainColor = System.Drawing.Color.Green;
            paletteItem13.Name = "PaletteItem 2";
            paletteItem13.SecondColor = System.Drawing.Color.GreenYellow;
            paletteItem14.MainColor = System.Drawing.Color.DarkGoldenrod;
            paletteItem14.Name = "PaletteItem 3";
            paletteItem14.SecondColor = System.Drawing.Color.Gold;
            paletteItem15.MainColor = System.Drawing.Color.DarkGray;
            paletteItem15.Name = "PaletteItem 4";
            paletteItem15.SecondColor = System.Drawing.Color.White;
            paletteItem16.MainColor = System.Drawing.Color.Pink;
            paletteItem16.Name = "PaletteItem 5";
            paletteItem16.SecondColor = System.Drawing.Color.PeachPuff;
            palette3.Items.AddRange(new Telerik.Reporting.Charting.PaletteItem[] {
            paletteItem11,
            paletteItem12,
            paletteItem13,
            paletteItem14,
            paletteItem15,
            paletteItem16});
            palette3.Name = "Palette1";
            this.chartStopTime.CustomPalettes.AddRange(new Telerik.Reporting.Charting.Palette[] {
            palette3});
            this.chartStopTime.DefaultType = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chartStopTime.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;
            this.chartStopTime.IntelligentLabelsEnabled = true;
            this.chartStopTime.Legend.Appearance.Border.Visible = false;
            this.chartStopTime.Legend.Appearance.ItemTextAppearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartStopTime.Legend.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartStopTime.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.chartStopTime.Name = "chartStopTime";
            this.chartStopTime.PlotArea.Appearance.Border.Visible = false;
            chartMargins6.Right = new Telerik.Reporting.Charting.Styles.Unit(160D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopTime.PlotArea.Appearance.Dimensions.Margins = chartMargins6;
            this.chartStopTime.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartStopTime.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chartStopTime.PlotArea.Appearance.SeriesPalette = "Palette1";
            this.chartStopTime.PlotArea.EmptySeriesMessage.TextBlock.Visible = false;
            this.chartStopTime.PlotArea.XAxis.MinValue = 1D;
            chartSeries6.Appearance.CenterXOffset = -30;
            chartSeries6.Appearance.DiameterScale = 0.85D;
            chartSeries6.Appearance.LegendDisplayMode = Telerik.Reporting.Charting.ChartSeriesLegendDisplayMode.ItemLabels;
            chartSeries6.Appearance.ShowLabels = false;
            chartSeries6.DataLabelsColumn = "ReasonWithMachinePrefix";
            chartSeries6.DataYColumn = "ElapsedTimeInSeconds";
            chartSeries6.Name = "Series 1";
            chartSeries6.Type = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chartStopTime.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries6});
            this.chartStopTime.SeriesPalette = "Palette1";
            this.chartStopTime.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(3.7000000476837158D));
            this.chartStopTime.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.chartStopTime.NeedDataSource += new System.EventHandler(this.chartStopTime_NeedDataSource);
            // 
            // panel9
            // 
            this.panel9.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel10,
            this.textBox23});
            this.panel9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel9.Name = "panel9";
            this.panel9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.90000057220459D), Telerik.Reporting.Drawing.Unit.Cm(0.35718747973442078D));
            // 
            // panel10
            // 
            this.panel10.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.panel10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.22489582002162933D));
            this.panel10.Name = "panel10";
            this.panel10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.90000057220459D), Telerik.Reporting.Drawing.Unit.Cm(0.13229167461395264D));
            this.panel10.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.panel10.Style.BackgroundImage.MimeType = "";
            this.panel10.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.RepeatX;
            this.panel10.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel10.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.panel10.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            // 
            // textBox23
            // 
            this.textBox23.CanShrink = false;
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.627291202545166D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.textBox23.Multiline = false;
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6799999475479126D), Telerik.Reporting.Drawing.Unit.Cm(0.34000000357627869D));
            this.textBox23.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox23.Style.Font.Italic = false;
            this.textBox23.Style.Font.Name = "Calibri";
            this.textBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox23.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox23.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox23.TextWrap = false;
            this.textBox23.Value = "Fördelning av tid";
            // 
            // panel11
            // 
            this.panel11.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel12,
            this.textBox14});
            this.panel11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.3999996185302734D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel11.Name = "panel11";
            this.panel11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.90000057220459D), Telerik.Reporting.Drawing.Unit.Cm(0.35718747973442078D));
            // 
            // panel12
            // 
            this.panel12.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.panel12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.22489582002162933D));
            this.panel12.Name = "panel12";
            this.panel12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.90000057220459D), Telerik.Reporting.Drawing.Unit.Cm(0.13229167461395264D));
            this.panel12.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.panel12.Style.BackgroundImage.MimeType = "";
            this.panel12.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.RepeatX;
            this.panel12.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel12.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.panel12.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            // 
            // textBox14
            // 
            this.textBox14.CanShrink = false;
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.627291202545166D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.textBox14.Multiline = false;
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6799999475479126D), Telerik.Reporting.Drawing.Unit.Cm(0.34000000357627869D));
            this.textBox14.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox14.Style.Font.Italic = false;
            this.textBox14.Style.Font.Name = "Calibri";
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox14.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox14.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.TextWrap = false;
            this.textBox14.Value = "Fördelning av tid";
            // 
            // tableStops
            // 
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(6.1914591789245605D)));
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.132291316986084D)));
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.5972909927368164D)));
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.8560407161712647D)));
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.7883332967758179D)));
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.9883323907852173D)));
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.0354173183441162D)));
            this.tableStops.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.7300000786781311D)));
            this.tableStops.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.40000003576278687D)));
            this.tableStops.Body.SetCellContent(0, 0, this.textBox27);
            this.tableStops.Body.SetCellContent(0, 3, this.textBox28);
            this.tableStops.Body.SetCellContent(0, 4, this.textBox31);
            this.tableStops.Body.SetCellContent(1, 0, this.textBox35);
            this.tableStops.Body.SetCellContent(1, 3, this.textBox38);
            this.tableStops.Body.SetCellContent(1, 4, this.textBox39);
            this.tableStops.Body.SetCellContent(0, 5, this.textBox40);
            this.tableStops.Body.SetCellContent(1, 5, this.textBox41);
            this.tableStops.Body.SetCellContent(0, 6, this.textBox42);
            this.tableStops.Body.SetCellContent(1, 6, this.textBox43);
            this.tableStops.Body.SetCellContent(0, 2, this.textBox57);
            this.tableStops.Body.SetCellContent(1, 2, this.textBox58);
            this.tableStops.Body.SetCellContent(0, 1, this.textBox65);
            this.tableStops.Body.SetCellContent(1, 1, this.textBox66);
            tableGroup15.Name = "Group4";
            tableGroup16.Name = "Group3";
            tableGroup19.Name = "Group1";
            tableGroup20.Name = "Group2";
            this.tableStops.ColumnGroups.Add(tableGroup14);
            this.tableStops.ColumnGroups.Add(tableGroup15);
            this.tableStops.ColumnGroups.Add(tableGroup16);
            this.tableStops.ColumnGroups.Add(tableGroup17);
            this.tableStops.ColumnGroups.Add(tableGroup18);
            this.tableStops.ColumnGroups.Add(tableGroup19);
            this.tableStops.ColumnGroups.Add(tableGroup20);
            this.tableStops.ColumnHeadersPrintOnEveryPage = true;
            this.tableStops.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox27,
            this.textBox28,
            this.textBox31,
            this.textBox35,
            this.textBox38,
            this.textBox39,
            this.textBox40,
            this.textBox41,
            this.textBox42,
            this.textBox43,
            this.textBox57,
            this.textBox58,
            this.textBox65,
            this.textBox66});
            this.tableStops.KeepTogether = false;
            this.tableStops.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(14.949999809265137D));
            this.tableStops.Name = "tableStops";
            tableGroup22.Groupings.Add(new Telerik.Reporting.Grouping(""));
            tableGroup22.Name = "detailGroup";
            this.tableStops.RowGroups.Add(tableGroup21);
            this.tableStops.RowGroups.Add(tableGroup22);
            this.tableStops.RowHeadersPrintOnEveryPage = true;
            this.tableStops.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.589164733886719D), Telerik.Reporting.Drawing.Unit.Cm(1.1299999952316284D));
            this.tableStops.Style.BackgroundColor = System.Drawing.Color.White;
            this.tableStops.Style.Visible = true;
            this.tableStops.NeedDataSource += new System.EventHandler(this.tableStops_NeedDataSource);
            // 
            // textBox27
            // 
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.1914582252502441D), Telerik.Reporting.Drawing.Unit.Cm(0.7300000786781311D));
            this.textBox27.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox27.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox27.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox27.Style.Font.Bold = false;
            // 
            // textBox28
            // 
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8560407161712647D), Telerik.Reporting.Drawing.Unit.Cm(0.7300000786781311D));
            this.textBox28.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox28.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox28.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox28.Style.Font.Bold = false;
            this.textBox28.Style.Font.Italic = false;
            this.textBox28.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox28.Value = "Tidsåtgång totalt";
            this.textBox28.ItemDataBound += new System.EventHandler(this.ColumnDowntimeDatabound);
            // 
            // textBox31
            // 
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7883331775665283D), Telerik.Reporting.Drawing.Unit.Cm(0.7300000786781311D));
            this.textBox31.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox31.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox31.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox31.Style.Font.Bold = false;
            this.textBox31.Style.Font.Italic = false;
            this.textBox31.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox31.Value = "Antal";
            this.textBox31.ItemDataBound += new System.EventHandler(this.ColumnNumberOfDatabound);
            // 
            // textBox35
            // 
            this.textBox35.Name = "textBox35";
            this.textBox35.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.1914582252502441D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox35.Style.Font.Bold = false;
            this.textBox35.Style.Font.Italic = false;
            this.textBox35.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox35.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox35.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox35.Value = "=Fields.Reason";
            // 
            // textBox38
            // 
            this.textBox38.Format = "{0:N1} min";
            this.textBox38.Name = "textBox38";
            this.textBox38.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8560407161712647D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox38.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox38.Value = "=Fields.ElapsedTimeInMinutes";
            this.textBox38.ItemDataBound += new System.EventHandler(this.ColumnDowntimeDatabound);
            // 
            // textBox39
            // 
            this.textBox39.Format = "{0:N0}";
            this.textBox39.Name = "textBox39";
            this.textBox39.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7883331775665283D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox39.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox39.Value = "=Fields.NumberOfStops";
            this.textBox39.ItemDataBound += new System.EventHandler(this.ColumnNumberOfDatabound);
            // 
            // textBox40
            // 
            this.textBox40.Name = "textBox40";
            this.textBox40.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9883323907852173D), Telerik.Reporting.Drawing.Unit.Cm(0.7300000786781311D));
            this.textBox40.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox40.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox40.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox40.Style.Font.Bold = false;
            this.textBox40.Style.Font.Italic = false;
            this.textBox40.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox40.Value = "Tidsåtgång snittvärde";
            // 
            // textBox41
            // 
            this.textBox41.Format = "{0:N1} min";
            this.textBox41.Name = "textBox41";
            this.textBox41.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9883323907852173D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox41.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox41.StyleName = "";
            this.textBox41.Value = "=Fields.AverageTimeInMinutes";
            // 
            // textBox42
            // 
            this.textBox42.Name = "textBox42";
            this.textBox42.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0354166030883789D), Telerik.Reporting.Drawing.Unit.Cm(0.7300000786781311D));
            this.textBox42.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox42.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox42.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox42.Style.Font.Bold = false;
            this.textBox42.Style.Font.Italic = false;
            this.textBox42.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox42.Value = "Andel av total reg. stopptid";
            // 
            // textBox43
            // 
            this.textBox43.Format = "{0:P1}";
            this.textBox43.Name = "textBox43";
            this.textBox43.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0354166030883789D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox43.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox43.Value = "=Fields.TimePart";
            // 
            // textBox57
            // 
            this.textBox57.Name = "textBox57";
            this.textBox57.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5972909927368164D), Telerik.Reporting.Drawing.Unit.Cm(0.7300000786781311D));
            this.textBox57.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox57.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox57.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox57.Style.Font.Bold = false;
            this.textBox57.Style.Font.Italic = false;
            this.textBox57.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox57.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox57.StyleName = "";
            this.textBox57.Value = "Maskin";
            // 
            // textBox58
            // 
            this.textBox58.Name = "textBox58";
            this.textBox58.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5972909927368164D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox58.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox58.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox58.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox58.StyleName = "";
            this.textBox58.Value = "=Fields.Machine";
            // 
            // textBox65
            // 
            this.textBox65.Name = "textBox65";
            this.textBox65.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.1322915554046631D), Telerik.Reporting.Drawing.Unit.Cm(0.7300000786781311D));
            this.textBox65.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox65.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox65.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox65.Style.Font.Bold = false;
            this.textBox65.Style.Font.Italic = false;
            this.textBox65.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox65.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox65.StyleName = "";
            this.textBox65.Value = "Kategori";
            // 
            // textBox66
            // 
            this.textBox66.Name = "textBox66";
            this.textBox66.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.1322915554046631D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox66.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox66.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox66.StyleName = "";
            this.textBox66.Value = "=Fields.Category";
            // 
            // panel5
            // 
            this.panel5.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel6,
            this.textBox25});
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
            // textBox25
            // 
            this.textBox25.CanShrink = false;
            this.textBox25.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.627291202545166D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.textBox25.Multiline = false;
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6799999475479126D), Telerik.Reporting.Drawing.Unit.Cm(0.34000000357627869D));
            this.textBox25.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox25.Style.Font.Italic = false;
            this.textBox25.Style.Font.Name = "Calibri";
            this.textBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox25.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox25.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox25.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox25.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox25.TextWrap = false;
            this.textBox25.Value = "Fördelning av tid";
            // 
            // panel7
            // 
            this.panel7.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel8,
            this.textBox24});
            this.panel7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(8.6000003814697266D));
            this.panel7.Name = "panel7";
            this.panel7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(0.35718747973442078D));
            // 
            // panel8
            // 
            this.panel8.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.panel8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.22489582002162933D));
            this.panel8.Name = "panel8";
            this.panel8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(0.13229167461395264D));
            this.panel8.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.panel8.Style.BackgroundImage.MimeType = "";
            this.panel8.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.RepeatX;
            this.panel8.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel8.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.panel8.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            // 
            // textBox24
            // 
            this.textBox24.CanShrink = false;
            this.textBox24.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.627291202545166D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.textBox24.Multiline = false;
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6799999475479126D), Telerik.Reporting.Drawing.Unit.Cm(0.34000000357627869D));
            this.textBox24.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox24.Style.Font.Italic = false;
            this.textBox24.Style.Font.Name = "Calibri";
            this.textBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox24.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox24.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox24.TextWrap = false;
            this.textBox24.Value = "Fördelning av tid";
            // 
            // tbHeaderLeft
            // 
            this.tbHeaderLeft.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.44999998807907104D), Telerik.Reporting.Drawing.Unit.Cm(1.2300000190734863D));
            this.tbHeaderLeft.Name = "tbHeaderLeft";
            this.tbHeaderLeft.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.9800000190734863D), Telerik.Reporting.Drawing.Unit.Cm(0.41999998688697815D));
            this.tbHeaderLeft.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.tbHeaderLeft.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat;
            this.tbHeaderLeft.Style.Color = System.Drawing.Color.Gray;
            this.tbHeaderLeft.Style.Font.Bold = false;
            this.tbHeaderLeft.Style.Font.Italic = true;
            this.tbHeaderLeft.Style.Font.Name = "Calibri";
            this.tbHeaderLeft.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.tbHeaderLeft.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbHeaderLeft.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbHeaderLeft.StyleName = "Title";
            this.tbHeaderLeft.Value = "Dagsrapport";
            // 
            // tbHeader
            // 
            this.tbHeader.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.44999998807907104D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.tbHeader.Name = "tbHeader";
            this.tbHeader.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.9800000190734863D), Telerik.Reporting.Drawing.Unit.Cm(0.62999999523162842D));
            this.tbHeader.Style.Color = System.Drawing.Color.Black;
            this.tbHeader.Style.Font.Name = "Calibri";
            this.tbHeader.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.tbHeader.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbHeader.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbHeader.Style.Visible = true;
            this.tbHeader.StyleName = "Title";
            this.tbHeader.Value = "Översikt";
            // 
            // tbDivisionPrompt
            // 
            this.tbDivisionPrompt.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.050000190734863D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.tbDivisionPrompt.Name = "tbDivisionPrompt";
            this.tbDivisionPrompt.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8899999856948853D), Telerik.Reporting.Drawing.Unit.Cm(0.38999998569488525D));
            this.tbDivisionPrompt.Style.Color = System.Drawing.Color.Gray;
            this.tbDivisionPrompt.Style.Font.Italic = true;
            this.tbDivisionPrompt.Style.Font.Name = "Calibri";
            this.tbDivisionPrompt.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbDivisionPrompt.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbDivisionPrompt.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbDivisionPrompt.Style.Visible = true;
            this.tbDivisionPrompt.StyleName = "Title";
            this.tbDivisionPrompt.Value = "Avdelning:";
            // 
            // tbDivisionName
            // 
            this.tbDivisionName.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13D), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791D));
            this.tbDivisionName.Name = "tbDivisionName";
            this.tbDivisionName.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6600000858306885D), Telerik.Reporting.Drawing.Unit.Cm(0.38999998569488525D));
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
            this.panel2,
            this.panel4,
            this.tbDivisionPrompt,
            this.tbDivisionName,
            this.tbShiftPrompt,
            this.textBox48,
            this.textBox56,
            this.tbCategoriesPrompt});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            this.pageHeaderSection1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pageHeaderSection1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.pageHeaderSection1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.pageHeaderSection1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            // 
            // panel2
            // 
            this.panel2.Docking = Telerik.Reporting.DockingStyle.Left;
            this.panel2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.tbHeaderLeft,
            this.tbHeader});
            this.panel2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel2.Name = "panel2";
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.80020809173584D), Telerik.Reporting.Drawing.Unit.Cm(2.6800000667572021D));
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
            // tbShiftPrompt
            // 
            this.tbShiftPrompt.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.050000190734863D), Telerik.Reporting.Drawing.Unit.Cm(0.99000000953674316D));
            this.tbShiftPrompt.Name = "tbShiftPrompt";
            this.tbShiftPrompt.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8899999856948853D), Telerik.Reporting.Drawing.Unit.Cm(0.38999998569488525D));
            this.tbShiftPrompt.Style.Color = System.Drawing.Color.Gray;
            this.tbShiftPrompt.Style.Font.Italic = true;
            this.tbShiftPrompt.Style.Font.Name = "Calibri";
            this.tbShiftPrompt.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbShiftPrompt.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbShiftPrompt.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbShiftPrompt.Style.Visible = true;
            this.tbShiftPrompt.StyleName = "Title";
            this.tbShiftPrompt.Value = "Skift:";
            // 
            // textBox48
            // 
            this.textBox48.Format = "{0:d}";
            this.textBox48.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13D), Telerik.Reporting.Drawing.Unit.Cm(0.99000000953674316D));
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
            // textBox56
            // 
            this.textBox56.Format = "{0:d}";
            this.textBox56.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13D), Telerik.Reporting.Drawing.Unit.Cm(1.3867708444595337D));
            this.textBox56.Name = "textBox48";
            this.textBox56.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6600000858306885D), Telerik.Reporting.Drawing.Unit.Cm(0.38999998569488525D));
            this.textBox56.Style.Color = System.Drawing.Color.Black;
            this.textBox56.Style.Font.Name = "Calibri";
            this.textBox56.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox56.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox56.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox56.Style.Visible = true;
            this.textBox56.StyleName = "Title";
            this.textBox56.Value = "= Fields.Categories";
            // 
            // tbCategoriesPrompt
            // 
            this.tbCategoriesPrompt.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.050000190734863D), Telerik.Reporting.Drawing.Unit.Cm(1.3867708444595337D));
            this.tbCategoriesPrompt.Name = "tbCategoriesPrompt";
            this.tbCategoriesPrompt.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8899999856948853D), Telerik.Reporting.Drawing.Unit.Cm(0.38999998569488525D));
            this.tbCategoriesPrompt.Style.Color = System.Drawing.Color.Gray;
            this.tbCategoriesPrompt.Style.Font.Italic = true;
            this.tbCategoriesPrompt.Style.Font.Name = "Calibri";
            this.tbCategoriesPrompt.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbCategoriesPrompt.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbCategoriesPrompt.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbCategoriesPrompt.Style.Visible = true;
            this.tbCategoriesPrompt.StyleName = "Title";
            this.tbCategoriesPrompt.Value = "Kategorier:";
            // 
            // DivisionOeeDaily
            // 
            this.DocumentName = "= M2M.DataCenter.Reports.DivisionOeeDaily.GetDocumentName(Parameters.DivisionId.V" +
    "alue, Parameters.Date.Value)";
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageHeaderSection1,
            pageFooterSection1});
            this.Name = "DivisionOeeDaily";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Cm(1.6000000238418579D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "DivisionId";
            reportParameter1.Text = "Avdelning";
            reportParameter2.MultiValue = true;
            reportParameter2.Name = "Category";
            reportParameter2.Text = "Kategori";
            reportParameter3.Name = "Date";
            reportParameter3.Text = "Dag";
            reportParameter3.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter4.Name = "OrderBy";
            reportParameter4.Text = "Sortera efter";
            reportParameter4.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter5.Name = "ShiftType";
            reportParameter5.Text = "Skift";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
            this.ReportParameters.Add(reportParameter5);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.Font.Name = "Calibri";
            this.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
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
        private Chart chartTotalOee;
        private Table tableMachines;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox21;
        private Telerik.Reporting.TextBox textBox22;
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
        private Telerik.Reporting.Panel panel3;
        private Chart chartStopCount;
        private Chart chartStopTime;
        private Table tableStops;
        private Telerik.Reporting.TextBox textBox27;
        private Telerik.Reporting.TextBox textBox28;
        private Telerik.Reporting.TextBox textBox31;
        private Telerik.Reporting.TextBox textBox35;
        private Telerik.Reporting.TextBox textBox38;
        private Telerik.Reporting.TextBox textBox39;
        private Telerik.Reporting.TextBox textBox40;
        private Telerik.Reporting.TextBox textBox41;
        private Telerik.Reporting.TextBox textBox42;
        private Telerik.Reporting.TextBox textBox43;
        private Telerik.Reporting.TextBox textBox44;
        private Telerik.Reporting.TextBox tbHeaderLeft;
        private Telerik.Reporting.TextBox tbHeader;
        private Telerik.Reporting.TextBox tbDivisionPrompt;
        private Telerik.Reporting.TextBox tbDivisionName;
        private PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox45;
        private Telerik.Reporting.TextBox textBox46;
        private Telerik.Reporting.TextBox textBox47;
        private Telerik.Reporting.Panel panel2;
        private Telerik.Reporting.Panel panel4;
        private Telerik.Reporting.TextBox textBox48;
        private Telerik.Reporting.TextBox tbShiftPrompt;
        private Telerik.Reporting.TextBox textBox50;
        private Telerik.Reporting.TextBox textBox51;
        private Telerik.Reporting.TextBox textBox52;
        private Telerik.Reporting.TextBox textBox53;
        private Telerik.Reporting.TextBox textBox54;
        private Telerik.Reporting.TextBox tbCategoriesPrompt;
        private Telerik.Reporting.TextBox textBox56;
        private Telerik.Reporting.TextBox textBox57;
        private Telerik.Reporting.TextBox textBox58;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox49;
        private Telerik.Reporting.TextBox textBox55;
        private Telerik.Reporting.TextBox textBox59;
        private Telerik.Reporting.TextBox textBox60;
        private Telerik.Reporting.TextBox textBox61;
        private Telerik.Reporting.TextBox textBox62;
        private Telerik.Reporting.TextBox textBox63;
        private Telerik.Reporting.TextBox textBox64;
        private Telerik.Reporting.TextBox textBox65;
        private Telerik.Reporting.TextBox textBox66;
        private Telerik.Reporting.TextBox textBox67;
        private Telerik.Reporting.TextBox textBox68;
        private Shape shape1;
        private Telerik.Reporting.TextBox tbShapeRow2;
        private Telerik.Reporting.PictureBox pictureBoxLogo;
        private Telerik.Reporting.Panel panel5;
        private Telerik.Reporting.Panel panel6;
        private Telerik.Reporting.TextBox textBox25;
        private Telerik.Reporting.Panel panel7;
        private Telerik.Reporting.Panel panel8;
        private Telerik.Reporting.TextBox textBox24;
        private Telerik.Reporting.Panel panel9;
        private Telerik.Reporting.Panel panel10;
        private Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.Panel panel11;
        private Telerik.Reporting.Panel panel12;
        private Telerik.Reporting.TextBox textBox14;
    }
}