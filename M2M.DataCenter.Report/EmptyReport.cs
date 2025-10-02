using System;
using System.ComponentModel;
using System.Web;

namespace M2M.DataCenter.Reports
{
    /// <summary>
    /// Summary description for Machine.
    /// </summary>
    [Description("Template")]
    [DisplayName("16")]
    public partial class EmptyReport : Telerik.Reporting.Report
    {
        #region Properties

        
        #endregion

        public EmptyReport()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            SetLocalizedStrings();

            this.pictureBoxLogo.Value = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("~/CustomerSpecifics/ReportLogo.png"));


  
        }

        private void SetLocalizedStrings()
        {
            textBox4.Value = "Fördelning av stopptid";
            textBox4.GrowAndCenterControl();

            textBox5.Value = "Fördelning av antal stopp";
            textBox5.GrowAndCenterControl();

            textBox6.Value = "Va faan!";
            textBox6.GrowAndCenterControl();

            textBox7.Value = "Hä bli bra de";
            textBox7.GrowAndCenterControl();
        }

        private void Report_NeedDataSource(object sender, EventArgs e)
        {
            
        }
        
    }

    
}