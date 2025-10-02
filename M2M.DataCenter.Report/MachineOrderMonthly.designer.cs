namespace M2M.DataCenter.Reports
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class MachineOrderMonthly
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
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
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.detail = new Telerik.Reporting.DetailSection();
            this.tableArticles = new Telerik.Reporting.Table();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.textBox26 = new Telerik.Reporting.TextBox();
            this.panel4 = new Telerik.Reporting.Panel();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.textBox27 = new Telerik.Reporting.TextBox();
            this.textBox28 = new Telerik.Reporting.TextBox();
            this.tbDate = new Telerik.Reporting.TextBox();
            this.panel2 = new Telerik.Reporting.Panel();
            this.textBox25 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.textBox44 = new Telerik.Reporting.TextBox();
            this.textBox31 = new Telerik.Reporting.TextBox();
            this.textBox45 = new Telerik.Reporting.TextBox();
            this.textBox46 = new Telerik.Reporting.TextBox();
            this.textBox47 = new Telerik.Reporting.TextBox();
            this.textBox50 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(1.5401995182037354);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.tableArticles,
            this.textBox2});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.Font.Italic = true;
            this.detail.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            // 
            // tableArticles
            // 
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.1842734813690186)));
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(3.0303165912628174)));
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.0000007152557373)));
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.1047232151031494)));
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.032888650894165)));
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.9652471542358398)));
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.2634851932525635)));
            this.tableArticles.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.8378348350524902)));
            this.tableArticles.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367)));
            this.tableArticles.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367)));
            this.tableArticles.Body.SetCellContent(0, 0, this.textBox12);
            this.tableArticles.Body.SetCellContent(0, 1, this.textBox13);
            this.tableArticles.Body.SetCellContent(1, 0, this.textBox15);
            this.tableArticles.Body.SetCellContent(1, 1, this.textBox16);
            this.tableArticles.Body.SetCellContent(0, 4, this.textBox17);
            this.tableArticles.Body.SetCellContent(1, 4, this.textBox18);
            this.tableArticles.Body.SetCellContent(0, 5, this.textBox19);
            this.tableArticles.Body.SetCellContent(1, 5, this.textBox20);
            this.tableArticles.Body.SetCellContent(0, 7, this.textBox10);
            this.tableArticles.Body.SetCellContent(1, 7, this.textBox11);
            this.tableArticles.Body.SetCellContent(0, 3, this.textBox4);
            this.tableArticles.Body.SetCellContent(1, 3, this.textBox5);
            this.tableArticles.Body.SetCellContent(0, 6, this.textBox1);
            this.tableArticles.Body.SetCellContent(1, 6, this.textBox3);
            this.tableArticles.Body.SetCellContent(0, 2, this.textBox8);
            this.tableArticles.Body.SetCellContent(1, 2, this.textBox9);
            tableGroup3.Name = "Group8";
            tableGroup4.Name = "Group5";
            tableGroup5.Name = "Group1";
            tableGroup6.Name = "Group2";
            tableGroup7.Name = "Group4";
            tableGroup8.Name = "Group6";
            this.tableArticles.ColumnGroups.Add(tableGroup1);
            this.tableArticles.ColumnGroups.Add(tableGroup2);
            this.tableArticles.ColumnGroups.Add(tableGroup3);
            this.tableArticles.ColumnGroups.Add(tableGroup4);
            this.tableArticles.ColumnGroups.Add(tableGroup5);
            this.tableArticles.ColumnGroups.Add(tableGroup6);
            this.tableArticles.ColumnGroups.Add(tableGroup7);
            this.tableArticles.ColumnGroups.Add(tableGroup8);
            this.tableArticles.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox12,
            this.textBox13,
            this.textBox15,
            this.textBox16,
            this.textBox17,
            this.textBox18,
            this.textBox19,
            this.textBox20,
            this.textBox10,
            this.textBox11,
            this.textBox4,
            this.textBox5,
            this.textBox1,
            this.textBox3,
            this.textBox8,
            this.textBox9});
            this.tableArticles.KeepTogether = false;
            this.tableArticles.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0), Telerik.Reporting.Drawing.Unit.Cm(0.50019961595535278));
            this.tableArticles.Name = "tableArticles";
            tableGroup11.Name = "Group7";
            tableGroup10.ChildGroups.Add(tableGroup11);
            tableGroup10.Groupings.AddRange(new Telerik.Reporting.Data.Grouping[] {
            new Telerik.Reporting.Data.Grouping("")});
            tableGroup10.Name = "detailGroup";
            this.tableArticles.RowGroups.Add(tableGroup9);
            this.tableArticles.RowGroups.Add(tableGroup10);
            this.tableArticles.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.418769836425781), Telerik.Reporting.Drawing.Unit.Cm(1.0399999618530273));
            this.tableArticles.Style.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tableArticles.NeedDataSource += new System.EventHandler(this.tableArticles_NeedDataSource);
            // 
            // textBox12
            // 
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.1842734813690186), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367));
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            // 
            // textBox13
            // 
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.0303165912628174), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367));
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Font.Italic = false;
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox13.Value = "Orderstart";
            // 
            // textBox15
            // 
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.1842734813690186), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367));
            this.textBox15.Style.Font.Bold = true;
            this.textBox15.Style.Font.Italic = false;
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox15.Value = "=Fields.Article";
            // 
            // textBox16
            // 
            this.textBox16.Format = "{0:g}";
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.0303165912628174), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367));
            this.textBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox16.Value = "=Fields.OrderStart";
            // 
            // textBox17
            // 
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0328881740570068), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367));
            this.textBox17.Style.Font.Bold = true;
            this.textBox17.Style.Font.Italic = false;
            this.textBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox17.Value = "Antal";
            // 
            // textBox18
            // 
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0328881740570068), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367));
            this.textBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox18.Value = "=Fields.ProducedItems";
            // 
            // textBox19
            // 
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.965246319770813), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367));
            this.textBox19.Style.Font.Bold = true;
            this.textBox19.Style.Font.Italic = false;
            this.textBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox19.Value = "Hastighet";
            // 
            // textBox20
            // 
            this.textBox20.Format = "{0:N1} / h";
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.965246319770813), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367));
            this.textBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox20.Value = "=Fields.RunRate";
            // 
            // textBox10
            // 
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8378345966339111), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367));
            this.textBox10.Style.Font.Bold = true;
            this.textBox10.Style.Font.Italic = false;
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox10.Value = "Orderslut";
            // 
            // textBox11
            // 
            this.textBox11.Format = "{0:g}";
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8378345966339111), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367));
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox11.Value = "=Fields.OrderStop";
            // 
            // textBox4
            // 
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.1047224998474121), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367));
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Style.Font.Italic = false;
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox4.Value = "Prod. tid";
            // 
            // textBox5
            // 
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.1047224998474121), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367));
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox5.Value = "=Fields.ProducingTime";
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.263484001159668), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Italic = false;
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox1.Value = "Tid per enhet";
            // 
            // textBox3
            // 
            this.textBox3.Format = "{0:N0} ms";
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.263484001159668), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367));
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox3.Value = "=Fields.CycleTime";
            // 
            // textBox8
            // 
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367));
            this.textBox8.Style.Font.Bold = true;
            this.textBox8.Style.Font.Italic = false;
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox8.Value = "Ställtid";
            // 
            // textBox9
            // 
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367));
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox9.Value = "=Fields.AssembleTime";
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.201458215713501), Telerik.Reporting.Drawing.Unit.Cm(0.49999934434890747));
            this.textBox2.Style.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.textBox2.Style.Color = System.Drawing.Color.White;
            this.textBox2.Style.Font.Bold = false;
            this.textBox2.Style.Font.Italic = false;
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Style.Visible = true;
            this.textBox2.TextWrap = false;
            this.textBox2.Value = "Artiklar";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(2.0799999237060547);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox26,
            this.panel4,
            this.panel2});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            this.pageHeaderSection1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pageHeaderSection1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(2);
            // 
            // textBox26
            // 
            this.textBox26.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.4001998901367188), Telerik.Reporting.Drawing.Unit.Cm(0));
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.5746860504150391), Telerik.Reporting.Drawing.Unit.Cm(2));
            this.textBox26.Style.Font.Name = "Arial";
            this.textBox26.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16);
            this.textBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox26.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox26.Style.Visible = true;
            this.textBox26.StyleName = "Title";
            this.textBox26.Value = "Körordrar";
            // 
            // panel4
            // 
            this.panel4.Docking = Telerik.Reporting.DockingStyle.Right;
            this.panel4.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox14,
            this.textBox23,
            this.textBox24,
            this.textBox27,
            this.textBox28,
            this.tbDate});
            this.panel4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.975088119506836), Telerik.Reporting.Drawing.Unit.Cm(0));
            this.panel4.Name = "panel4";
            this.panel4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.6223115921020508), Telerik.Reporting.Drawing.Unit.Cm(2.0799999237060547));
            // 
            // textBox14
            // 
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.68791663646698), Telerik.Reporting.Drawing.Unit.Cm(1.0533168315887451));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0000007152557373), Telerik.Reporting.Drawing.Unit.Cm(0.50000017881393433));
            this.textBox14.Style.Color = System.Drawing.Color.Black;
            this.textBox14.Style.Font.Name = "Arial";
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.25);
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.Style.Visible = true;
            this.textBox14.StyleName = "Title";
            this.textBox14.Value = "Period:";
            // 
            // textBox23
            // 
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.6960361003875732), Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637));
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.889183521270752), Telerik.Reporting.Drawing.Unit.Cm(0.49989992380142212));
            this.textBox23.Style.Color = System.Drawing.Color.Black;
            this.textBox23.Style.Font.Name = "Arial";
            this.textBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.25);
            this.textBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox23.Style.Visible = true;
            this.textBox23.StyleName = "Title";
            this.textBox23.Value = "= Fields.Division";
            // 
            // textBox24
            // 
            this.textBox24.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.68791663646698), Telerik.Reporting.Drawing.Unit.Cm(0.55311667919158936));
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0000007152557373), Telerik.Reporting.Drawing.Unit.Cm(0.50000017881393433));
            this.textBox24.Style.Color = System.Drawing.Color.Black;
            this.textBox24.Style.Font.Name = "Arial";
            this.textBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.25);
            this.textBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox24.Style.Visible = true;
            this.textBox24.StyleName = "Title";
            this.textBox24.Value = "Maskin:";
            // 
            // textBox27
            // 
            this.textBox27.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.6964366436004639), Telerik.Reporting.Drawing.Unit.Cm(0.55301696062088013));
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8887839317321777), Telerik.Reporting.Drawing.Unit.Cm(0.50000035762786865));
            this.textBox27.Style.Color = System.Drawing.Color.Black;
            this.textBox27.Style.Font.Name = "Arial";
            this.textBox27.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.25);
            this.textBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox27.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox27.Style.Visible = true;
            this.textBox27.StyleName = "Title";
            this.textBox27.Value = "= Fields.Machine";
            // 
            // textBox28
            // 
            this.textBox28.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.68791663646698), Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637));
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.9999973773956299), Telerik.Reporting.Drawing.Unit.Cm(0.49999994039535522));
            this.textBox28.Style.Color = System.Drawing.Color.Black;
            this.textBox28.Style.Font.Name = "Arial";
            this.textBox28.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.25);
            this.textBox28.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox28.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox28.Style.Visible = true;
            this.textBox28.StyleName = "Title";
            this.textBox28.Value = "Avdelning:";
            // 
            // tbDate
            // 
            this.tbDate.Format = "{0:MMMM yyyy}";
            this.tbDate.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.6964366436004639), Telerik.Reporting.Drawing.Unit.Cm(1.0532172918319702));
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8887834548950195), Telerik.Reporting.Drawing.Unit.Cm(0.50000035762786865));
            this.tbDate.Style.Color = System.Drawing.Color.Black;
            this.tbDate.Style.Font.Name = "Arial";
            this.tbDate.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.25);
            this.tbDate.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbDate.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbDate.Style.Visible = true;
            this.tbDate.StyleName = "Title";
            this.tbDate.Value = "= Fields.PeriodStart";
            // 
            // panel2
            // 
            this.panel2.Docking = Telerik.Reporting.DockingStyle.Left;
            this.panel2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox25});
            this.panel2.Name = "panel2";
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.4000000953674316), Telerik.Reporting.Drawing.Unit.Cm(2.0799999237060547));
            // 
            // textBox25
            // 
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.399899959564209), Telerik.Reporting.Drawing.Unit.Cm(0.73802495002746582));
            this.textBox25.Style.BackgroundColor = System.Drawing.Color.Black;
            this.textBox25.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat;
            this.textBox25.Style.Color = System.Drawing.Color.White;
            this.textBox25.Style.Font.Bold = false;
            this.textBox25.Style.Font.Name = "Arial";
            this.textBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12);
            this.textBox25.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox25.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox25.StyleName = "Title";
            this.textBox25.Value = "Månadsrapport";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.0027068853378296);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox44,
            this.textBox31,
            this.textBox45,
            this.textBox46,
            this.textBox47,
            this.textBox50});
            this.pageFooterSection1.Name = "pageFooterSection1";
            this.pageFooterSection1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pageFooterSection1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(2);
            // 
            // textBox44
            // 
            this.textBox44.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.399999618530273), Telerik.Reporting.Drawing.Unit.Cm(0.5));
            this.textBox44.Name = "textBox44";
            this.textBox44.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.1973986625671387), Telerik.Reporting.Drawing.Unit.Cm(0.5));
            this.textBox44.Style.BackgroundColor = System.Drawing.Color.Black;
            this.textBox44.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat;
            this.textBox44.Style.Color = System.Drawing.Color.White;
            this.textBox44.Style.Font.Bold = false;
            this.textBox44.Style.Font.Name = "Arial";
            this.textBox44.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10);
            this.textBox44.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox44.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox44.StyleName = "Title";
            this.textBox44.Value = "Genererad av M2M DataCenter";
            // 
            // textBox31
            // 
            this.textBox31.CanShrink = true;
            this.textBox31.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.7197916507720947), Telerik.Reporting.Drawing.Unit.Cm(0.5027083158493042));
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.37041667103767395), Telerik.Reporting.Drawing.Unit.Cm(0.42052504420280457));
            this.textBox31.Style.Font.Italic = true;
            this.textBox31.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8);
            this.textBox31.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBox31.TextWrap = false;
            this.textBox31.Value = "= PageNumber";
            // 
            // textBox45
            // 
            this.textBox45.CanShrink = true;
            this.textBox45.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.82020831108093262), Telerik.Reporting.Drawing.Unit.Cm(0.5027083158493042));
            this.textBox45.Name = "textBox45";
            this.textBox45.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.88249337673187256), Telerik.Reporting.Drawing.Unit.Cm(0.42052504420280457));
            this.textBox45.Style.Font.Italic = true;
            this.textBox45.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8);
            this.textBox45.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBox45.TextWrap = false;
            this.textBox45.Value = "Sida";
            // 
            // textBox46
            // 
            this.textBox46.CanShrink = true;
            this.textBox46.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.1166665554046631), Telerik.Reporting.Drawing.Unit.Cm(0.5027083158493042));
            this.textBox46.Name = "textBox46";
            this.textBox46.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.47624999284744263), Telerik.Reporting.Drawing.Unit.Cm(0.42052504420280457));
            this.textBox46.Style.Font.Italic = true;
            this.textBox46.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8);
            this.textBox46.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox46.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBox46.TextWrap = false;
            this.textBox46.Value = "av";
            // 
            // textBox47
            // 
            this.textBox47.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.6193749904632568), Telerik.Reporting.Drawing.Unit.Cm(0.5027083158493042));
            this.textBox47.Name = "textBox47";
            this.textBox47.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.58208334445953369), Telerik.Reporting.Drawing.Unit.Cm(0.42052504420280457));
            this.textBox47.Style.Font.Italic = true;
            this.textBox47.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8);
            this.textBox47.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox47.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBox47.TextWrap = false;
            this.textBox47.Value = "= PageCount";
            // 
            // textBox50
            // 
            this.textBox50.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.1858329772949219), Telerik.Reporting.Drawing.Unit.Cm(0.31749999523162842));
            this.textBox50.Name = "textBox50";
            this.textBox50.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.6410412788391113), Telerik.Reporting.Drawing.Unit.Cm(0.60854166746139526));
            this.textBox50.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox50.Value = "Copyright© 2009, M2M Solutions AB";
            // 
            // textBox7
            // 
            this.textBox7.Format = "{0:N2}";
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4797348976135254), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367));
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox7.Value = "=Fields.NoProductionTime";
            // 
            // textBox6
            // 
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4797348976135254), Telerik.Reporting.Drawing.Unit.Cm(0.51999998092651367));
            this.textBox6.Style.Font.Bold = true;
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9);
            this.textBox6.Value = "Hastighet (cykler/h) ";
            // 
            // MachineOrderMonthly
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageHeaderSection1,
            this.pageFooterSection1});
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Cm(1.2000000476837158);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "DivisionId";
            reportParameter1.Text = "Avdelning";
            reportParameter1.Visible = true;
            reportParameter2.Name = "MachineId";
            reportParameter2.Text = "Maskin";
            reportParameter2.Visible = true;
            reportParameter3.Name = "Year";
            reportParameter3.Text = "År";
            reportParameter3.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter3.Visible = true;
            reportParameter4.Name = "Month";
            reportParameter4.Text = "Månad";
            reportParameter4.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter4.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(97)))), ((int)(((byte)(74)))));
            styleRule1.Style.Font.Name = "Georgia";
            styleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(174)))), ((int)(((byte)(173)))));
            styleRule2.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(168)))), ((int)(((byte)(212)))));
            styleRule2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Dotted;
            styleRule2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1);
            styleRule2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            styleRule2.Style.Font.Name = "Georgia";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Font.Name = "Georgia";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Font.Name = "Georgia";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(18.59739875793457);
            this.Name = "MachineOrderMonthly";
            this.NeedDataSource += new System.EventHandler(this.Machine_NeedDataSource);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DetailSection detail;
        private Table tableArticles;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.TextBox textBox26;
        private Telerik.Reporting.Panel panel4;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.TextBox textBox24;
        private Telerik.Reporting.TextBox textBox27;
        private Telerik.Reporting.TextBox textBox28;
        private Telerik.Reporting.TextBox tbDate;
        private Telerik.Reporting.Panel panel2;
        private Telerik.Reporting.TextBox textBox25;
        private PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox textBox44;
        private Telerik.Reporting.TextBox textBox31;
        private Telerik.Reporting.TextBox textBox45;
        private Telerik.Reporting.TextBox textBox46;
        private Telerik.Reporting.TextBox textBox47;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox50;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
    }
}