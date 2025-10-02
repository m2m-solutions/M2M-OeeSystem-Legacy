namespace M2M.DataCenter.Reports
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class MachineStoppageMonthly
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
            Telerik.Reporting.Charting.ChartSeries chartSeries1 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins3 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.Styles.ChartPaddings chartPaddings2 = new Telerik.Reporting.Charting.Styles.ChartPaddings();
            Telerik.Reporting.Charting.Palette palette2 = new Telerik.Reporting.Charting.Palette();
            Telerik.Reporting.Charting.PaletteItem paletteItem7 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem8 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem9 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem10 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem11 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.PaletteItem paletteItem12 = new Telerik.Reporting.Charting.PaletteItem();
            Telerik.Reporting.Charting.Styles.ChartMargins chartMargins4 = new Telerik.Reporting.Charting.Styles.ChartMargins();
            Telerik.Reporting.Charting.ChartSeries chartSeries2 = new Telerik.Reporting.Charting.ChartSeries();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter5 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter6 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter7 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.tbProductionTime = new Telerik.Reporting.TextBox();
            this.tbTotalTime = new Telerik.Reporting.TextBox();
            this.tbStopTime = new Telerik.Reporting.TextBox();
            this.tbOee = new Telerik.Reporting.TextBox();
            this.textBox29 = new Telerik.Reporting.TextBox();
            this.textBox30 = new Telerik.Reporting.TextBox();
            this.textBox32 = new Telerik.Reporting.TextBox();
            this.textBox33 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox31 = new Telerik.Reporting.TextBox();
            this.textBox36 = new Telerik.Reporting.TextBox();
            this.textBox37 = new Telerik.Reporting.TextBox();
            this.textBox57 = new Telerik.Reporting.TextBox();
            this.textBox38 = new Telerik.Reporting.TextBox();
            this.textBox54 = new Telerik.Reporting.TextBox();
            this.textBox53 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.list1 = new Telerik.Reporting.List();
            this.panel1 = new Telerik.Reporting.Panel();
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
            this.panel3 = new Telerik.Reporting.Panel();
            this.chartStopCount = new Telerik.Reporting.Chart();
            this.chartStopTime = new Telerik.Reporting.Chart();
            this.panel5 = new Telerik.Reporting.Panel();
            this.panel6 = new Telerik.Reporting.Panel();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.panel7 = new Telerik.Reporting.Panel();
            this.panel8 = new Telerik.Reporting.Panel();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.panel4 = new Telerik.Reporting.Panel();
            this.shape1 = new Telerik.Reporting.Shape();
            this.tbShapeRow2 = new Telerik.Reporting.TextBox();
            this.panel2 = new Telerik.Reporting.Panel();
            this.textBox25 = new Telerik.Reporting.TextBox();
            this.textBox26 = new Telerik.Reporting.TextBox();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.textBox48 = new Telerik.Reporting.TextBox();
            this.textBox49 = new Telerik.Reporting.TextBox();
            this.textBox55 = new Telerik.Reporting.TextBox();
            this.textBox56 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.textBox47 = new Telerik.Reporting.TextBox();
            this.textBox46 = new Telerik.Reporting.TextBox();
            this.textBox45 = new Telerik.Reporting.TextBox();
            this.textBox28 = new Telerik.Reporting.TextBox();
            this.textBox44 = new Telerik.Reporting.TextBox();
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
            this.tbTotalTime,
            this.tbStopTime,
            this.tbOee,
            this.textBox29,
            this.textBox30,
            this.textBox32,
            this.textBox33,
            this.textBox10,
            this.textBox11,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox31,
            this.textBox36,
            this.textBox37,
            this.textBox57,
            this.textBox38,
            this.textBox54,
            this.textBox53});
            panelOverview.Name = "panelOverview";
            panelOverview.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(3.3500001430511475D));
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
            this.tbProductionTime.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0802001953125D), Telerik.Reporting.Drawing.Unit.Cm(1.7400000095367432D));
            this.tbProductionTime.Name = "tbProductionTime";
            this.tbProductionTime.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.41999977827072144D));
            this.tbProductionTime.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbProductionTime.Value = "=Fields.ActualProductionTimeInHours";
            // 
            // tbTotalTime
            // 
            this.tbTotalTime.CanGrow = false;
            this.tbTotalTime.Format = "{0:N1} tim";
            this.tbTotalTime.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0802001953125D), Telerik.Reporting.Drawing.Unit.Cm(0.12999999523162842D));
            this.tbTotalTime.Name = "tbTotalTime";
            this.tbTotalTime.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.41999977827072144D));
            this.tbTotalTime.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbTotalTime.Value = "=Fields.ScheduledTimeInHours";
            // 
            // tbStopTime
            // 
            this.tbStopTime.CanGrow = false;
            this.tbStopTime.Format = "{0:N1} tim";
            this.tbStopTime.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.210569381713867D), Telerik.Reporting.Drawing.Unit.Cm(0.67000001668930054D));
            this.tbStopTime.Name = "tbStopTime";
            this.tbStopTime.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.41999977827072144D));
            this.tbStopTime.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbStopTime.Value = "=Fields.RegisteredStopTimeInHours";
            // 
            // tbOee
            // 
            this.tbOee.CanGrow = false;
            this.tbOee.Format = "{0:N0}";
            this.tbOee.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.200395584106445D), Telerik.Reporting.Drawing.Unit.Cm(0.12999999523162842D));
            this.tbOee.Name = "tbOee";
            this.tbOee.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.41999977827072144D));
            this.tbOee.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbOee.Value = "=Fields.NumberOfStops";
            // 
            // textBox29
            // 
            this.textBox29.CanGrow = false;
            this.textBox29.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.81999999284744263D), Telerik.Reporting.Drawing.Unit.Cm(0.12999999523162842D));
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.41999977827072144D));
            this.textBox29.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox29.Value = "Schemalagd tid:";
            // 
            // textBox30
            // 
            this.textBox30.CanGrow = false;
            this.textBox30.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.81999999284744263D), Telerik.Reporting.Drawing.Unit.Cm(1.7400000095367432D));
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.41999977827072144D));
            this.textBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox30.Value = "Tillgänglig tid:";
            // 
            // textBox32
            // 
            this.textBox32.CanGrow = false;
            this.textBox32.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.945591926574707D), Telerik.Reporting.Drawing.Unit.Cm(0.67000001668930054D));
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.41999977827072144D));
            this.textBox32.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox32.Value = "Registrerad stopptid:";
            // 
            // textBox33
            // 
            this.textBox33.CanGrow = false;
            this.textBox33.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.940403938293457D), Telerik.Reporting.Drawing.Unit.Cm(0.12999999523162842D));
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.41999977827072144D));
            this.textBox33.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox33.Value = "Total antal stopp:";
            // 
            // textBox10
            // 
            this.textBox10.CanGrow = false;
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.31999951601028442D), Telerik.Reporting.Drawing.Unit.Cm(0.67000001668930054D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.7597918510437012D), Telerik.Reporting.Drawing.Unit.Cm(0.41999977827072144D));
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox10.Value = "Maskin ej i produktion:";
            // 
            // textBox11
            // 
            this.textBox11.CanGrow = false;
            this.textBox11.Format = "{0:N1} tim";
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0802001953125D), Telerik.Reporting.Drawing.Unit.Cm(0.67000001668930054D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.41999977827072144D));
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox11.Value = "=Fields.NoProductionTimeInHours";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = false;
            this.textBox1.Format = "{0:N1} tim";
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.205382347106934D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.41999977827072144D));
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox1.Value = "=Fields.UnregisteredStopTimeInHours";
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = false;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.94559097290039D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.41999977827072144D));
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox2.Value = "Övrig stopptid:";
            // 
            // textBox3
            // 
            this.textBox3.CanGrow = false;
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.81999999284744263D), Telerik.Reporting.Drawing.Unit.Cm(2.7999999523162842D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.41999977827072144D));
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox3.Value = "Stopptid:";
            // 
            // textBox4
            // 
            this.textBox4.CanGrow = false;
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.81999999284744263D), Telerik.Reporting.Drawing.Unit.Cm(2.2699999809265137D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.259791374206543D), Telerik.Reporting.Drawing.Unit.Cm(0.41999977827072144D));
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox4.Value = "Effektiv produktionstid:";
            // 
            // textBox5
            // 
            this.textBox5.CanGrow = false;
            this.textBox5.Format = "{0:N1} tim";
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0799999237060547D), Telerik.Reporting.Drawing.Unit.Cm(2.2699999809265137D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.41999977827072144D));
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox5.Value = "=Fields.AutoTimeInHours";
            // 
            // textBox31
            // 
            this.textBox31.CanGrow = false;
            this.textBox31.Format = "{0:N1} tim";
            this.textBox31.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0799999237060547D), Telerik.Reporting.Drawing.Unit.Cm(2.7999999523162842D));
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.41999977827072144D));
            this.textBox31.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox31.Value = "=Fields.StopTimeInHours";
            // 
            // textBox36
            // 
            this.textBox36.CanGrow = false;
            this.textBox36.Format = "{0:N1} tim";
            this.textBox36.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0802001953125D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.textBox36.Name = "textBox36";
            this.textBox36.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2949845790863037D), Telerik.Reporting.Drawing.Unit.Cm(0.41999977827072144D));
            this.textBox36.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox36.Value = "=Fields.NotConnectedTimeInHours";
            // 
            // textBox37
            // 
            this.textBox37.CanGrow = false;
            this.textBox37.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.31999951601028442D), Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158D));
            this.textBox37.Name = "textBox37";
            this.textBox37.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.7597918510437012D), Telerik.Reporting.Drawing.Unit.Cm(0.41999977827072144D));
            this.textBox37.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox37.Value = "Ingen kontakt med maskin:";
            // 
            // textBox57
            // 
            this.textBox57.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.5751743316650391D), Telerik.Reporting.Drawing.Unit.Cm(2.2666666507720947D));
            this.textBox57.Name = "textBox57";
            this.textBox57.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.6302080154418945D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox57.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox57.Value = "Stopptid faktiska stopp:";
            // 
            // textBox38
            // 
            this.textBox38.Format = "{0:N1} tim";
            this.textBox38.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.205382347106934D), Telerik.Reporting.Drawing.Unit.Cm(2.2666666507720947D));
            this.textBox38.Name = "textBox38";
            this.textBox38.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.42333352565765381D));
            this.textBox38.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox38.Value = "=Fields.ActualStopTimeInHours";
            // 
            // textBox54
            // 
            this.textBox54.Format = "{0:N1} tim";
            this.textBox54.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.205382347106934D), Telerik.Reporting.Drawing.Unit.Cm(2.7999999523162842D));
            this.textBox54.Name = "textBox54";
            this.textBox54.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2899999618530273D), Telerik.Reporting.Drawing.Unit.Cm(0.42333352565765381D));
            this.textBox54.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox54.Value = "=Fields.FlowErrorTimeInHours";
            // 
            // textBox53
            // 
            this.textBox53.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.5751743316650391D), Telerik.Reporting.Drawing.Unit.Cm(2.7999999523162842D));
            this.textBox53.Name = "textBox53";
            this.textBox53.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.6302080154418945D), Telerik.Reporting.Drawing.Unit.Cm(0.42333331704139709D));
            this.textBox53.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox53.Value = "Stopptid flödesfel:";
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
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(9.4799995422363281D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.list1,
            this.tableStops,
            this.panel3});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            this.detail.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.detail.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.Font.Italic = true;
            this.detail.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.detail.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            // 
            // list1
            // 
            this.list1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D)));
            this.list1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(3.3499999046325684D)));
            this.list1.Body.SetCellContent(0, 0, this.panel1);
            tableGroup1.Name = "ColumnGroup1";
            this.list1.ColumnGroups.Add(tableGroup1);
            this.list1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1});
            this.list1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896D));
            this.list1.Name = "list1";
            tableGroup2.Name = "RowGroup1";
            this.list1.RowGroups.Add(tableGroup2);
            this.list1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(3.3499999046325684D));
            this.list1.NeedDataSource += new System.EventHandler(this.list1_NeedDataSource);
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            panelOverview});
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D), Telerik.Reporting.Drawing.Unit.Cm(3.3499999046325684D));
            // 
            // tableStops
            // 
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(6.7999963760375977D)));
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(3.0999996662139893D)));
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.200000524520874D)));
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.9999997615814209D)));
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.200000524520874D)));
            this.tableStops.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.3000004291534424D)));
            this.tableStops.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.7300000786781311D)));
            this.tableStops.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D)));
            this.tableStops.Body.SetCellContent(0, 0, this.textBox18);
            this.tableStops.Body.SetCellContent(0, 2, this.textBox19);
            this.tableStops.Body.SetCellContent(0, 3, this.textBox20);
            this.tableStops.Body.SetCellContent(1, 0, this.textBox21);
            this.tableStops.Body.SetCellContent(1, 2, this.textBox22);
            this.tableStops.Body.SetCellContent(1, 3, this.textBox27);
            this.tableStops.Body.SetCellContent(0, 4, this.textBox6);
            this.tableStops.Body.SetCellContent(1, 4, this.textBox7);
            this.tableStops.Body.SetCellContent(0, 5, this.textBox8);
            this.tableStops.Body.SetCellContent(1, 5, this.textBox9);
            this.tableStops.Body.SetCellContent(0, 1, this.textBox34);
            this.tableStops.Body.SetCellContent(1, 1, this.textBox35);
            tableGroup4.Name = "Group3";
            tableGroup7.Name = "Group1";
            tableGroup8.Name = "Group2";
            this.tableStops.ColumnGroups.Add(tableGroup3);
            this.tableStops.ColumnGroups.Add(tableGroup4);
            this.tableStops.ColumnGroups.Add(tableGroup5);
            this.tableStops.ColumnGroups.Add(tableGroup6);
            this.tableStops.ColumnGroups.Add(tableGroup7);
            this.tableStops.ColumnGroups.Add(tableGroup8);
            this.tableStops.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox18,
            this.textBox19,
            this.textBox20,
            this.textBox21,
            this.textBox22,
            this.textBox27,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox34,
            this.textBox35});
            this.tableStops.KeepTogether = false;
            this.tableStops.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(8.3500003814697266D));
            this.tableStops.Name = "tableStops";
            tableGroup10.Groupings.Add(new Telerik.Reporting.Grouping(""));
            tableGroup10.Name = "detailGroup";
            this.tableStops.RowGroups.Add(tableGroup9);
            this.tableStops.RowGroups.Add(tableGroup10);
            this.tableStops.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.599998474121094D), Telerik.Reporting.Drawing.Unit.Cm(1.1299999952316284D));
            this.tableStops.Style.BackgroundColor = System.Drawing.Color.White;
            this.tableStops.Style.Visible = true;
            this.tableStops.NeedDataSource += new System.EventHandler(this.tableStops_NeedDataSource);
            // 
            // textBox18
            // 
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.7999973297119141D), Telerik.Reporting.Drawing.Unit.Cm(0.7300000786781311D));
            this.textBox18.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox18.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox18.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox18.Style.Font.Bold = false;
            this.textBox18.Style.Font.Italic = false;
            this.textBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            // 
            // textBox19
            // 
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2000002861022949D), Telerik.Reporting.Drawing.Unit.Cm(0.7300000786781311D));
            this.textBox19.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox19.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox19.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox19.Style.Font.Bold = false;
            this.textBox19.Style.Font.Italic = false;
            this.textBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox19.Value = "Tidsåtgång totalt";
            this.textBox19.ItemDataBound += new System.EventHandler(this.ColumnDowntimeDatabound);
            // 
            // textBox20
            // 
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2D), Telerik.Reporting.Drawing.Unit.Cm(0.7300000786781311D));
            this.textBox20.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox20.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox20.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox20.Style.Font.Bold = false;
            this.textBox20.Style.Font.Italic = false;
            this.textBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox20.Value = "Antal";
            this.textBox20.ItemDataBound += new System.EventHandler(this.ColumnNumberOfDatabound);
            // 
            // textBox21
            // 
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.7999973297119141D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox21.Style.Font.Bold = false;
            this.textBox21.Style.Font.Italic = false;
            this.textBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox21.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox21.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.5D);
            this.textBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox21.Value = "=Fields.Reason";
            // 
            // textBox22
            // 
            this.textBox22.Format = "{0:N1} tim";
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2000002861022949D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox22.Style.Font.Bold = false;
            this.textBox22.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox22.Value = "=Fields.ElapsedTimeInHours";
            this.textBox22.ItemDataBound += new System.EventHandler(this.ColumnDowntimeDatabound);
            // 
            // textBox27
            // 
            this.textBox27.Format = "{0:N0}";
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox27.Style.Font.Bold = false;
            this.textBox27.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox27.Value = "=Fields.NumberOfStops";
            this.textBox27.ItemDataBound += new System.EventHandler(this.ColumnNumberOfDatabound);
            // 
            // textBox6
            // 
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2000002861022949D), Telerik.Reporting.Drawing.Unit.Cm(0.7300000786781311D));
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
            this.textBox7.Format = "{0:N1} min";
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2000002861022949D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox7.Style.Font.Bold = false;
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox7.StyleName = "";
            this.textBox7.Value = "=Fields.AverageTimeInMinutes";
            // 
            // textBox8
            // 
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2999999523162842D), Telerik.Reporting.Drawing.Unit.Cm(0.7300000786781311D));
            this.textBox8.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox8.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox8.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox8.Style.Font.Bold = false;
            this.textBox8.Style.Font.Italic = false;
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox8.Value = "Andel av total reg. stopptid";
            // 
            // textBox9
            // 
            this.textBox9.Format = "{0:P1}";
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2999999523162842D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox9.Style.Font.Bold = false;
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox9.Value = "=Fields.TimePart";
            // 
            // textBox34
            // 
            this.textBox34.Name = "textBox34";
            this.textBox34.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.0999996662139893D), Telerik.Reporting.Drawing.Unit.Cm(0.7300000786781311D));
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
            this.textBox35.Name = "textBox35";
            this.textBox35.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.0999996662139893D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.textBox35.Style.Font.Bold = false;
            this.textBox35.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox35.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox35.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox35.StyleName = "";
            this.textBox35.Value = "=Fields.Category";
            // 
            // panel3
            // 
            this.panel3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.chartStopCount,
            this.chartStopTime,
            this.panel5,
            this.panel7});
            this.panel3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(3.9500000476837158D));
            this.panel3.Name = "panel3";
            this.panel3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.599897384643555D), Telerik.Reporting.Drawing.Unit.Cm(4.1001019477844238D));
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
            this.chartStopCount.Legend.Appearance.Border.Visible = false;
            this.chartStopCount.Legend.Appearance.ItemTextAppearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartStopCount.Legend.TextBlock.Appearance.Dimensions.AutoSize = false;
            this.chartStopCount.Legend.TextBlock.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.Legend.TextBlock.Appearance.Dimensions.Width = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.Legend.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Verdana", 5F);
            this.chartStopCount.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.chartStopCount.Name = "chartStopCount";
            this.chartStopCount.PlotArea.Appearance.Border.Visible = false;
            chartMargins2.Right = new Telerik.Reporting.Charting.Styles.Unit(160D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopCount.PlotArea.Appearance.Dimensions.Margins = chartMargins2;
            this.chartStopCount.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.Transparent;
            this.chartStopCount.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.Transparent;
            this.chartStopCount.PlotArea.Appearance.SeriesPalette = "Palette1";
            this.chartStopCount.PlotArea.EmptySeriesMessage.TextBlock.Visible = false;
            this.chartStopCount.PlotArea.XAxis.MinValue = 1D;
            chartSeries1.Appearance.CenterXOffset = -30;
            chartSeries1.Appearance.DiameterScale = 0.85D;
            chartSeries1.Appearance.LegendDisplayMode = Telerik.Reporting.Charting.ChartSeriesLegendDisplayMode.ItemLabels;
            chartSeries1.Appearance.ShowLabels = false;
            chartSeries1.DataLabelsColumn = "ReasonAbbr";
            chartSeries1.DataYColumn = "NumberOfStops";
            chartSeries1.DefaultLabelValue = "";
            chartSeries1.Name = "Series 1";
            chartSeries1.Type = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chartStopCount.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries1});
            this.chartStopCount.SeriesPalette = "Palette1";
            this.chartStopCount.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.299799919128418D), Telerik.Reporting.Drawing.Unit.Cm(3.7001018524169922D));
            this.chartStopCount.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.chartStopCount.Style.Visible = true;
            this.chartStopCount.NeedDataSource += new System.EventHandler(this.chartStopCount_NeedDataSource);
            // 
            // chartStopTime
            // 
            this.chartStopTime.Appearance.Border.Visible = false;
            this.chartStopTime.Appearance.Dimensions.AutoSize = false;
            this.chartStopTime.Appearance.Dimensions.Height = new Telerik.Reporting.Charting.Styles.Unit(139D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins3.Bottom = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins3.Left = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins3.Right = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            chartMargins3.Top = new Telerik.Reporting.Charting.Styles.Unit(0D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopTime.Appearance.Dimensions.Margins = chartMargins3;
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
            this.chartStopTime.Legend.Appearance.Border.Visible = false;
            this.chartStopTime.Legend.Appearance.ItemTextAppearance.TextProperties.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartStopTime.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.3000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(0.40000000596046448D));
            this.chartStopTime.Name = "chartStopTime";
            this.chartStopTime.PlotArea.Appearance.Border.Visible = false;
            chartMargins4.Right = new Telerik.Reporting.Charting.Styles.Unit(160D, Telerik.Reporting.Charting.Styles.UnitType.Pixel);
            this.chartStopTime.PlotArea.Appearance.Dimensions.Margins = chartMargins4;
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
            chartSeries2.DataLabelsColumn = "ReasonAbbr";
            chartSeries2.DataYColumn = "ElapsedTimeInSeconds";
            chartSeries2.Name = "Series 1";
            chartSeries2.Type = Telerik.Reporting.Charting.ChartSeriesType.Pie;
            this.chartStopTime.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] {
            chartSeries2});
            this.chartStopTime.SeriesPalette = "Palette1";
            this.chartStopTime.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.29990291595459D), Telerik.Reporting.Drawing.Unit.Cm(3.7001001834869385D));
            this.chartStopTime.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.chartStopTime.NeedDataSource += new System.EventHandler(this.chartStopTime_NeedDataSource);
            // 
            // panel5
            // 
            this.panel5.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel6,
            this.textBox12});
            this.panel5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Cm(0D));
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
            this.panel8,
            this.textBox13});
            this.panel7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.3999996185302734D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.panel7.Name = "panel7";
            this.panel7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.90000057220459D), Telerik.Reporting.Drawing.Unit.Cm(0.35718747973442078D));
            // 
            // panel8
            // 
            this.panel8.Anchoring = ((Telerik.Reporting.AnchoringStyles)((Telerik.Reporting.AnchoringStyles.Left | Telerik.Reporting.AnchoringStyles.Right)));
            this.panel8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.22489582002162933D));
            this.panel8.Name = "panel8";
            this.panel8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.90000057220459D), Telerik.Reporting.Drawing.Unit.Cm(0.13229167461395264D));
            this.panel8.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.panel8.Style.BackgroundImage.MimeType = "";
            this.panel8.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.RepeatX;
            this.panel8.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel8.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.panel8.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
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
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(2.6800000667572021D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel4,
            this.panel2,
            this.textBox24,
            this.textBox16,
            this.textBox23,
            this.textBox17,
            this.textBox48,
            this.textBox49,
            this.textBox55,
            this.textBox56});
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
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.429999828338623D), Telerik.Reporting.Drawing.Unit.Cm(2.6800000667572021D));
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
            this.textBox26.Value = "Stopptidsuppföljning";
            // 
            // textBox24
            // 
            this.textBox24.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.050000190734863D), Telerik.Reporting.Drawing.Unit.Cm(0.52062499523162842D));
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
            this.textBox24.Value = "Avdelning:";
            // 
            // textBox16
            // 
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13D), Telerik.Reporting.Drawing.Unit.Cm(0.52062499523162842D));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6600000858306885D), Telerik.Reporting.Drawing.Unit.Cm(0.38999998569488525D));
            this.textBox16.Style.Color = System.Drawing.Color.Black;
            this.textBox16.Style.Font.Name = "Calibri";
            this.textBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox16.Style.Visible = true;
            this.textBox16.StyleName = "Title";
            this.textBox16.Value = "= Fields.Division";
            // 
            // textBox23
            // 
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13D), Telerik.Reporting.Drawing.Unit.Cm(0.91062498092651367D));
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6600000858306885D), Telerik.Reporting.Drawing.Unit.Cm(0.38999998569488525D));
            this.textBox23.Style.Color = System.Drawing.Color.Black;
            this.textBox23.Style.Font.Name = "Calibri";
            this.textBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox23.Style.Visible = true;
            this.textBox23.StyleName = "Title";
            this.textBox23.Value = "= Fields.Machine";
            // 
            // textBox17
            // 
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.050000190734863D), Telerik.Reporting.Drawing.Unit.Cm(0.91062498092651367D));
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
            // textBox48
            // 
            this.textBox48.Format = "{0:d}";
            this.textBox48.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13D), Telerik.Reporting.Drawing.Unit.Cm(1.3073956966400147D));
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
            this.textBox49.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.050000190734863D), Telerik.Reporting.Drawing.Unit.Cm(1.3073958158493042D));
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
            // textBox55
            // 
            this.textBox55.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.050000190734863D), Telerik.Reporting.Drawing.Unit.Cm(1.7099999189376831D));
            this.textBox55.Name = "textBox49";
            this.textBox55.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8899999856948853D), Telerik.Reporting.Drawing.Unit.Cm(0.38999998569488525D));
            this.textBox55.Style.Color = System.Drawing.Color.Gray;
            this.textBox55.Style.Font.Italic = true;
            this.textBox55.Style.Font.Name = "Calibri";
            this.textBox55.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox55.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox55.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox55.Style.Visible = true;
            this.textBox55.StyleName = "Title";
            this.textBox55.Value = "Kategorier:";
            // 
            // textBox56
            // 
            this.textBox56.Format = "{0:d}";
            this.textBox56.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13D), Telerik.Reporting.Drawing.Unit.Cm(1.7099999189376831D));
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
            // MachineStoppageMonthly
            // 
            this.DocumentName = "= M2M.DataCenter.Reports.MachineStoppageMonthly.GetDocumentName(Parameters.Machin" +
    "eId.Value, Parameters.Year.Value, Parameters.Month.Value)";
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageHeaderSection1,
            this.pageFooterSection1});
            this.Name = "MachineStoppageMonthly";
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
            reportParameter6.MultiValue = true;
            reportParameter6.Name = "Category";
            reportParameter6.Text = "Kategori";
            reportParameter7.Name = "OrderBy";
            reportParameter7.Text = "Sortera efter";
            reportParameter7.Type = Telerik.Reporting.ReportParameterType.Integer;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
            this.ReportParameters.Add(reportParameter5);
            this.ReportParameters.Add(reportParameter6);
            this.ReportParameters.Add(reportParameter7);
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
        private List list1;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.TextBox tbProductionTime;
        private Telerik.Reporting.TextBox tbTotalTime;
        private Telerik.Reporting.TextBox tbStopTime;
        private Telerik.Reporting.TextBox tbOee;
        private Telerik.Reporting.TextBox textBox29;
        private Telerik.Reporting.TextBox textBox30;
        private Telerik.Reporting.TextBox textBox32;
        private Telerik.Reporting.TextBox textBox33;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.Panel panel3;
        private PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.Panel panel4;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.TextBox textBox24;
        private Telerik.Reporting.Panel panel2;
        private Telerik.Reporting.TextBox textBox25;
        private Telerik.Reporting.TextBox textBox26;
        private PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox textBox47;
        private Telerik.Reporting.TextBox textBox46;
        private Telerik.Reporting.TextBox textBox45;
        private Telerik.Reporting.TextBox textBox28;
        private Telerik.Reporting.TextBox textBox44;
        private Telerik.Reporting.TextBox textBox49;
        private Telerik.Reporting.TextBox textBox48;
        private Telerik.Reporting.TextBox textBox50;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox31;
        private Telerik.Reporting.TextBox textBox56;
        private Telerik.Reporting.TextBox textBox55;
        private Telerik.Reporting.TextBox textBox34;
        private Telerik.Reporting.TextBox textBox35;
        private Telerik.Reporting.TextBox textBox36;
        private Telerik.Reporting.TextBox textBox37;
        private Telerik.Reporting.TextBox textBox57;
        private Telerik.Reporting.TextBox textBox38;
        private Telerik.Reporting.TextBox textBox54;
        private Telerik.Reporting.TextBox textBox53;
        private Shape shape1;
        private Telerik.Reporting.TextBox tbShapeRow2;
        private Telerik.Reporting.PictureBox pictureBoxLogo;
        private Telerik.Reporting.Panel panel5;
        private Telerik.Reporting.Panel panel6;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.Panel panel7;
        private Telerik.Reporting.Panel panel8;
        private Telerik.Reporting.TextBox textBox13;
    }
}