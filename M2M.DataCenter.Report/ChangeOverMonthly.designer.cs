namespace M2M.DataCenter.Reports
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class ChangeOverMonthly
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
            Telerik.Reporting.NumericalScale numericalScale1 = new Telerik.Reporting.NumericalScale();
            Telerik.Reporting.TableGroup tableGroup11 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup12 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup13 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup14 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup15 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup16 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup17 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup18 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.CategoryScale categoryScale1 = new Telerik.Reporting.CategoryScale();
            Telerik.Reporting.CategoryScale categoryScale2 = new Telerik.Reporting.CategoryScale();
            Telerik.Reporting.NumericalScale numericalScale2 = new Telerik.Reporting.NumericalScale();
            Telerik.Reporting.TableGroup tableGroup19 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup20 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup21 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup22 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup23 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter5 = new Telerik.Reporting.ReportParameter();
            this.textBox44 = new Telerik.Reporting.TextBox();
            this.textBox50 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox46 = new Telerik.Reporting.TextBox();
            this.textBox47 = new Telerik.Reporting.TextBox();
            this.textBox45 = new Telerik.Reporting.TextBox();
            this.pictureBoxLogo = new Telerik.Reporting.PictureBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.textBox26 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox28 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox27 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.panel5 = new Telerik.Reporting.Panel();
            this.panel6 = new Telerik.Reporting.Panel();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.crosstab1 = new Telerik.Reporting.Crosstab();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.textBox30 = new Telerik.Reporting.TextBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox29 = new Telerik.Reporting.TextBox();
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
            this.tbMachinePrompt = new Telerik.Reporting.TextBox();
            this.tbArticle = new Telerik.Reporting.TextBox();
            this.tbMachineName = new Telerik.Reporting.TextBox();
            this.textBox32 = new Telerik.Reporting.TextBox();
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
            this.table1 = new Telerik.Reporting.Table();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox22 = new Telerik.Reporting.TextBox();
            this.textBox25 = new Telerik.Reporting.TextBox();
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
            tbShapeRow1.Value = "=Fields.PeriodEnd";
            // 
            // textBox13
            // 
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.002631664276123D), Telerik.Reporting.Drawing.Unit.Cm(0.4999992847442627D));
            this.textBox13.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox13.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox13.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox13.Style.Font.Bold = false;
            this.textBox13.Style.Font.Italic = false;
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox13.Value = "Time consumed (min)";
            // 
            // textBox21
            // 
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.3283333778381348D), Telerik.Reporting.Drawing.Unit.Cm(0.4999992847442627D));
            this.textBox21.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox21.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox21.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox21.Style.Font.Italic = false;
            this.textBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox21.StyleName = "";
            this.textBox21.Value = "Average time consumed";
            // 
            // textBox26
            // 
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.4214565753936768D), Telerik.Reporting.Drawing.Unit.Cm(0.40000015497207642D));
            this.textBox26.Style.Font.Bold = true;
            this.textBox26.Style.Font.Italic = false;
            this.textBox26.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox26.StyleName = "";
            // 
            // textBox20
            // 
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.3218364715576172D), Telerik.Reporting.Drawing.Unit.Cm(0.40000015497207642D));
            this.textBox20.Style.Font.Bold = true;
            this.textBox20.Style.Font.Italic = false;
            this.textBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox20.StyleName = "";
            // 
            // textBox28
            // 
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.4214565753936768D), Telerik.Reporting.Drawing.Unit.Cm(0.40000015497207642D));
            this.textBox28.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox28.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox28.StyleName = "";
            this.textBox28.Value = "=Fields.EndTime";
            // 
            // textBox15
            // 
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.3218364715576172D), Telerik.Reporting.Drawing.Unit.Cm(0.40000015497207642D));
            this.textBox15.Style.Font.Italic = true;
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox15.StyleName = "";
            this.textBox15.Value = "=Fields.StartTime";
            // 
            // textBox27
            // 
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.4214565753936768D), Telerik.Reporting.Drawing.Unit.Cm(0.40000021457672119D));
            this.textBox27.Style.Font.Bold = true;
            this.textBox27.Style.Font.Italic = false;
            this.textBox27.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox27.StyleName = "";
            // 
            // textBox14
            // 
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.46199107170105D), Telerik.Reporting.Drawing.Unit.Cm(0.80000036954879761D));
            this.textBox14.Style.Font.Bold = true;
            this.textBox14.Style.Font.Italic = false;
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox14.Value = "=Fields.PreviousArticle";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(2.4425959587097168D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel5,
            this.crosstab1});
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
            this.panel5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224D));
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
            this.textBox4.Value = "= M2M.DataCenter.Reports.ChangeOverMonthly.GetArticle(ReportItem.DataObject)";
            this.textBox4.ItemDataBound += new System.EventHandler(this.textBox4_ItemDataBound);
            // 
            // crosstab1
            // 
            this.crosstab1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(4.002631664276123D)));
            this.crosstab1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(4.3283333778381348D)));
            this.crosstab1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.40000015497207642D)));
            this.crosstab1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.40000021457672119D)));
            this.crosstab1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.40000015497207642D)));
            this.crosstab1.Body.SetCellContent(1, 0, this.textBox18);
            this.crosstab1.Body.SetCellContent(0, 1, this.textBox30);
            this.crosstab1.Body.SetCellContent(1, 1, this.textBox23);
            this.crosstab1.Body.SetCellContent(0, 0, this.textBox19);
            this.crosstab1.Body.SetCellContent(2, 1, this.textBox22);
            this.crosstab1.Body.SetCellContent(2, 0, this.textBox25);
            tableGroup1.Name = "columnGroup";
            tableGroup1.ReportItem = this.textBox13;
            tableGroup2.Name = "group3";
            tableGroup2.ReportItem = this.textBox21;
            this.crosstab1.ColumnGroups.Add(tableGroup1);
            this.crosstab1.ColumnGroups.Add(tableGroup2);
            this.crosstab1.Corner.SetCellContent(0, 0, this.textBox1);
            this.crosstab1.Corner.SetCellContent(0, 1, this.textBox16);
            this.crosstab1.Corner.SetCellContent(0, 2, this.textBox29);
            this.crosstab1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox18,
            this.textBox30,
            this.textBox23,
            this.textBox13,
            this.textBox21,
            this.textBox1,
            this.textBox16,
            this.textBox29,
            this.textBox20,
            this.textBox14,
            this.textBox15,
            this.textBox26,
            this.textBox27,
            this.textBox28,
            this.textBox24,
            this.textBox17,
            this.textBox19,
            this.textBox22,
            this.textBox25});
            this.crosstab1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.7424958348274231D));
            this.crosstab1.Name = "crosstab1";
            tableGroup5.Name = "group6";
            tableGroup5.ReportItem = this.textBox28;
            tableGroup4.ChildGroups.Add(tableGroup5);
            tableGroup4.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup4.Name = "rowGroup1";
            tableGroup4.ReportItem = this.textBox15;
            tableGroup7.Name = "group5";
            tableGroup7.ReportItem = this.textBox27;
            tableGroup6.ChildGroups.Add(tableGroup7);
            tableGroup6.Name = "group";
            tableGroup6.ReportItem = this.textBox24;
            tableGroup3.ChildGroups.Add(tableGroup4);
            tableGroup3.ChildGroups.Add(tableGroup6);
            tableGroup3.Groupings.Add(new Telerik.Reporting.Grouping("=Fields.PreviousArticle"));
            tableGroup3.Name = "rowGroup";
            tableGroup3.ReportItem = this.textBox14;
            tableGroup3.Sortings.Add(new Telerik.Reporting.Sorting("=Fields.PreviousArticle", Telerik.Reporting.SortDirection.Asc));
            tableGroup10.Name = "group4";
            tableGroup10.ReportItem = this.textBox26;
            tableGroup9.ChildGroups.Add(tableGroup10);
            tableGroup9.Name = "group2";
            tableGroup9.ReportItem = this.textBox20;
            tableGroup8.ChildGroups.Add(tableGroup9);
            tableGroup8.Name = "group1";
            tableGroup8.ReportItem = this.textBox17;
            this.crosstab1.RowGroups.Add(tableGroup3);
            this.crosstab1.RowGroups.Add(tableGroup8);
            this.crosstab1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.5362491607666D), Telerik.Reporting.Drawing.Unit.Cm(1.6999998092651367D));
            this.crosstab1.NeedDataSource += new System.EventHandler(this.crosstab1_NeedDataSource);
            // 
            // textBox18
            // 
            this.textBox18.Format = "{0:N0}";
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.002631664276123D), Telerik.Reporting.Drawing.Unit.Cm(0.4000001847743988D));
            this.textBox18.Style.Font.Bold = true;
            this.textBox18.Style.Font.Italic = false;
            this.textBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox18.StyleName = "";
            this.textBox18.Value = "=SUM(Fields.ElapsedTimeInMinutes)";
            // 
            // textBox30
            // 
            this.textBox30.Format = "{0:N1}";
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.3283333778381348D), Telerik.Reporting.Drawing.Unit.Cm(0.40000015497207642D));
            this.textBox30.Style.Font.Bold = true;
            this.textBox30.Style.Font.Italic = false;
            this.textBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            // 
            // textBox23
            // 
            this.textBox23.Format = "{0:N1}";
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.3283333778381348D), Telerik.Reporting.Drawing.Unit.Cm(0.40000021457672119D));
            this.textBox23.Style.Font.Bold = true;
            this.textBox23.Style.Font.Italic = false;
            this.textBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox23.Value = "=Avg(Fields.ElapsedTimeInMinutes)";
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.46199107170105D), Telerik.Reporting.Drawing.Unit.Cm(0.4999992847442627D));
            this.textBox1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox1.Style.Font.Bold = false;
            this.textBox1.Style.Font.Italic = false;
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox1.Value = "Föregående artikel";
            // 
            // textBox16
            // 
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.3218364715576172D), Telerik.Reporting.Drawing.Unit.Cm(0.49999931454658508D));
            this.textBox16.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox16.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox16.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox16.Style.Font.Bold = false;
            this.textBox16.Style.Font.Italic = false;
            this.textBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox16.StyleName = "";
            this.textBox16.Value = "Started";
            // 
            // textBox29
            // 
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.4214565753936768D), Telerik.Reporting.Drawing.Unit.Cm(0.49999931454658508D));
            this.textBox29.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox29.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox29.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox29.Style.Font.Italic = false;
            this.textBox29.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox29.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox29.StyleName = "";
            this.textBox29.Value = "Ended";
            // 
            // graphAxis2
            // 
            this.graphAxis2.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis2.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis2.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis2.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis2.MinorGridLineStyle.Visible = false;
            this.graphAxis2.Name = "GraphAxis2";
            this.graphAxis2.Scale = numericalScale1;
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
            this.tbHeader.Value = "Ställ";
            // 
            // tbDivisionPrompt
            // 
            this.tbDivisionPrompt.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.0836324691772461D), Telerik.Reporting.Drawing.Unit.Cm(0.52926677465438843D));
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
            this.tbDivisionName.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.0309133529663086D), Telerik.Reporting.Drawing.Unit.Cm(0.52926677465438843D));
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
            this.tbMachinePrompt,
            this.tbArticle,
            this.tbDivisionName,
            this.tbMachineName,
            this.textBox32});
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
            this.tbSubHeader.Value = "MÅNADSRAPPORT";
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
            // tbMachinePrompt
            // 
            this.tbMachinePrompt.Anchoring = Telerik.Reporting.AnchoringStyles.Top;
            this.tbMachinePrompt.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.0836324691772461D), Telerik.Reporting.Drawing.Unit.Cm(0.92363321781158447D));
            this.tbMachinePrompt.Name = "tbMachinePrompt";
            this.tbMachinePrompt.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8941673040390015D), Telerik.Reporting.Drawing.Unit.Cm(0.39416682720184326D));
            this.tbMachinePrompt.Style.Color = System.Drawing.Color.Gray;
            this.tbMachinePrompt.Style.Font.Italic = true;
            this.tbMachinePrompt.Style.Font.Name = "Calibri";
            this.tbMachinePrompt.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbMachinePrompt.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbMachinePrompt.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbMachinePrompt.Style.Visible = true;
            this.tbMachinePrompt.StyleName = "Title";
            this.tbMachinePrompt.Value = "Maskin:";
            // 
            // tbArticle
            // 
            this.tbArticle.Anchoring = Telerik.Reporting.AnchoringStyles.Top;
            this.tbArticle.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.0836291313171387D), Telerik.Reporting.Drawing.Unit.Cm(1.3286218643188477D));
            this.tbArticle.Name = "tbArticle";
            this.tbArticle.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8941673040390015D), Telerik.Reporting.Drawing.Unit.Cm(0.39416682720184326D));
            this.tbArticle.Style.Color = System.Drawing.Color.Gray;
            this.tbArticle.Style.Font.Italic = true;
            this.tbArticle.Style.Font.Name = "Calibri";
            this.tbArticle.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbArticle.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbArticle.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbArticle.Style.Visible = true;
            this.tbArticle.StyleName = "Title";
            this.tbArticle.Value = "Artikel:";
            // 
            // tbMachineName
            // 
            this.tbMachineName.Format = "";
            this.tbMachineName.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.0309133529663086D), Telerik.Reporting.Drawing.Unit.Cm(0.92614173889160156D));
            this.tbMachineName.Name = "tbMachineName";
            this.tbMachineName.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6642873287200928D), Telerik.Reporting.Drawing.Unit.Cm(0.3941670358181D));
            this.tbMachineName.Style.Color = System.Drawing.Color.Black;
            this.tbMachineName.Style.Font.Name = "Calibri";
            this.tbMachineName.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.tbMachineName.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.tbMachineName.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.tbMachineName.Style.Visible = true;
            this.tbMachineName.StyleName = "Title";
            this.tbMachineName.Value = "= Fields.Machine";
            // 
            // textBox32
            // 
            this.textBox32.Angle = 0D;
            this.textBox32.Format = "";
            this.textBox32.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.0309133529663086D), Telerik.Reporting.Drawing.Unit.Cm(1.33122980594635D));
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.351804256439209D), Telerik.Reporting.Drawing.Unit.Cm(0.3941670358181D));
            this.textBox32.Style.Color = System.Drawing.Color.Black;
            this.textBox32.Style.Font.Name = "Calibri";
            this.textBox32.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox32.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox32.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox32.Style.Visible = true;
            this.textBox32.StyleName = "";
            this.textBox32.Value = "= Fields.FilterArticle";
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
            tableGroup12.Name = "Group4";
            tableGroup13.Name = "Group3";
            tableGroup16.Name = "Group1";
            tableGroup17.Name = "Group2";
            this.table2.ColumnGroups.Add(tableGroup11);
            this.table2.ColumnGroups.Add(tableGroup12);
            this.table2.ColumnGroups.Add(tableGroup13);
            this.table2.ColumnGroups.Add(tableGroup14);
            this.table2.ColumnGroups.Add(tableGroup15);
            this.table2.ColumnGroups.Add(tableGroup16);
            this.table2.ColumnGroups.Add(tableGroup17);
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
            this.table2.RowGroups.Add(tableGroup18);
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
            this.graphAxis1.Scale = categoryScale1;
            // 
            // graphAxis3
            // 
            this.graphAxis3.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis3.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis3.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis3.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis3.MinorGridLineStyle.Visible = false;
            this.graphAxis3.Name = "GraphAxis1";
            this.graphAxis3.Scale = categoryScale2;
            // 
            // graphAxis4
            // 
            this.graphAxis4.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis4.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis4.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray;
            this.graphAxis4.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.graphAxis4.MinorGridLineStyle.Visible = false;
            this.graphAxis4.Name = "GraphAxis3";
            this.graphAxis4.Scale = numericalScale2;
            // 
            // table1
            // 
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(5.5601687431335449D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(4.0757908821105957D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.9075706005096436D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(6.0563678741455078D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.7300000786781311D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.40000009536743164D)));
            this.table1.Body.SetCellContent(0, 2, this.textBox3);
            this.table1.Body.SetCellContent(0, 3, this.textBox5);
            this.table1.Body.SetCellContent(1, 0, this.textBox6);
            this.table1.Body.SetCellContent(1, 2, this.textBox7);
            this.table1.Body.SetCellContent(1, 3, this.textBox8);
            this.table1.Body.SetCellContent(0, 1, this.textBox9);
            this.table1.Body.SetCellContent(1, 1, this.textBox10);
            this.table1.Body.SetCellContent(0, 0, this.textBox11);
            tableGroup20.Name = "Group3";
            this.table1.ColumnGroups.Add(tableGroup19);
            this.table1.ColumnGroups.Add(tableGroup20);
            this.table1.ColumnGroups.Add(tableGroup21);
            this.table1.ColumnGroups.Add(tableGroup22);
            this.table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox3,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11});
            this.table1.KeepTogether = false;
            this.table1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.55582523345947266D));
            this.table1.Name = "tableStops";
            this.table1.RowGroups.Add(tableGroup23);
            // 
            // textBox3
            // 
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.907569408416748D), Telerik.Reporting.Drawing.Unit.Cm(0.73000013828277588D));
            this.textBox3.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox3.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox3.Style.Font.Bold = false;
            this.textBox3.Style.Font.Italic = false;
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox3.Value = "Tidsåtgång (min)";
            // 
            // textBox5
            // 
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.0563678741455078D), Telerik.Reporting.Drawing.Unit.Cm(0.7300000786781311D));
            this.textBox5.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox5.Style.Font.Bold = false;
            this.textBox5.Style.Font.Italic = false;
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox5.Value = "Angiven orsak";
            // 
            // textBox6
            // 
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.5601696968078613D), Telerik.Reporting.Drawing.Unit.Cm(0.40000003576278687D));
            this.textBox6.Style.Font.Bold = false;
            this.textBox6.Style.Font.Italic = false;
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox6.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox6.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.5D);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox6.Value = "=Fields.PreviousArticle";
            // 
            // textBox7
            // 
            this.textBox7.Format = "{0:N1} tim";
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.907569408416748D), Telerik.Reporting.Drawing.Unit.Cm(0.40000003576278687D));
            this.textBox7.Style.Font.Bold = false;
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox7.Value = "=Fields.ElapsedTimeInMinutes";
            // 
            // textBox8
            // 
            this.textBox8.Format = "{0:N0}";
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.0563678741455078D), Telerik.Reporting.Drawing.Unit.Cm(0.40000006556510925D));
            this.textBox8.Style.Font.Bold = false;
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox8.Value = "=Fields.ChangeOverText";
            // 
            // textBox9
            // 
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0757913589477539D), Telerik.Reporting.Drawing.Unit.Cm(0.73000001907348633D));
            this.textBox9.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox9.Style.Font.Bold = false;
            this.textBox9.Style.Font.Italic = false;
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox9.StyleName = "";
            this.textBox9.Value = "Tidpunkt";
            // 
            // textBox10
            // 
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0757913589477539D), Telerik.Reporting.Drawing.Unit.Cm(0.40000003576278687D));
            this.textBox10.Style.Font.Bold = false;
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox10.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox10.StyleName = "";
            this.textBox10.Value = "=Fields.Timestamp";
            // 
            // textBox11
            // 
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.5601696968078613D), Telerik.Reporting.Drawing.Unit.Cm(0.73000013828277588D));
            this.textBox11.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox11.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox11.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox11.Style.Font.Bold = false;
            this.textBox11.Style.Font.Italic = false;
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox11.StyleName = "";
            this.textBox11.Value = "Föregående artikel";
            // 
            // textBox24
            // 
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.3218364715576172D), Telerik.Reporting.Drawing.Unit.Cm(0.40000021457672119D));
            this.textBox24.Style.Font.Bold = true;
            this.textBox24.Style.Font.Italic = false;
            this.textBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox24.StyleName = "";
            this.textBox24.Value = "Deltotal";
            // 
            // textBox17
            // 
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.46199107170105D), Telerik.Reporting.Drawing.Unit.Cm(0.40000015497207642D));
            this.textBox17.Style.Font.Bold = true;
            this.textBox17.Style.Font.Italic = false;
            this.textBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox17.StyleName = "";
            this.textBox17.Value = "Total";
            // 
            // textBox19
            // 
            this.textBox19.Format = "{0:N0}";
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.002631664276123D), Telerik.Reporting.Drawing.Unit.Cm(0.40000015497207642D));
            this.textBox19.Style.Font.Italic = true;
            this.textBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox19.Value = "=Fields.ElapsedTimeInMinutes";
            // 
            // textBox22
            // 
            this.textBox22.Format = "{0:N1}";
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.3283333778381348D), Telerik.Reporting.Drawing.Unit.Cm(0.40000015497207642D));
            this.textBox22.Style.Font.Bold = true;
            this.textBox22.Style.Font.Italic = false;
            this.textBox22.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox22.Value = "=Avg(Fields.ElapsedTimeInMinutes)";
            // 
            // textBox25
            // 
            this.textBox25.Format = "{0:N0}";
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.002631664276123D), Telerik.Reporting.Drawing.Unit.Cm(0.4000001847743988D));
            this.textBox25.Style.Font.Bold = true;
            this.textBox25.Style.Font.Italic = false;
            this.textBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox25.StyleName = "";
            this.textBox25.Value = "=SUM(Fields.ElapsedTimeInMinutes)";
            // 
            // ChangeOverMonthly
            // 
            this.DocumentName = "= M2M.DataCenter.Reports.ChangeOverMonthly.GetDocumentName(Parameters.MachineId.V" +
    "alue,Parameters.Year.Value,Parameters.Month.Value)";
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageHeaderSection1,
            pageFooterSection1});
            this.Name = "ChangeOverMonthly";
            this.PageSettings.ColumnCount = 1;
            this.PageSettings.ColumnSpacing = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Cm(1.6000000238418579D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D), Telerik.Reporting.Drawing.Unit.Cm(0.800000011920929D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "DivisionId";
            reportParameter1.Text = "Avdelning/linje";
            reportParameter2.Name = "MachineId";
            reportParameter2.Text = "Maskin";
            reportParameter3.Name = "Article";
            reportParameter3.Text = "Artikel";
            reportParameter4.Name = "Year";
            reportParameter4.Text = "År";
            reportParameter4.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter5.Name = "Month";
            reportParameter5.Text = "T o m månad";
            reportParameter5.Type = Telerik.Reporting.ReportParameterType.Integer;
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
            this.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Cm;
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(18.600000381469727D);
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
        private Telerik.Reporting.TextBox tbArticle;
        private Telerik.Reporting.TextBox tbMachineName;
        private Telerik.Reporting.TextBox tbMachinePrompt;
        private Telerik.Reporting.TextBox tbShapeRow2;
        private Shape shape1;
        private Telerik.Reporting.Panel panel5;
        private Telerik.Reporting.Panel panel6;
        private Telerik.Reporting.TextBox textBox4;
        private GraphAxis graphAxis2;
        private GraphAxis graphAxis1;
        private GraphAxis graphAxis3;
        private GraphAxis graphAxis4;
        private Table table1;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Crosstab crosstab1;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox29;
        private Telerik.Reporting.TextBox textBox26;
        private Telerik.Reporting.TextBox textBox27;
        private Telerik.Reporting.TextBox textBox28;
        private Telerik.Reporting.TextBox textBox21;
        private Telerik.Reporting.TextBox textBox30;
        private Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.TextBox textBox24;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.TextBox textBox22;
        private Telerik.Reporting.TextBox textBox25;
    }
}