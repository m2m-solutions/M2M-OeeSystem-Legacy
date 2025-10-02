using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.Panel.FormsUI
{
    public partial class LogonDialog : Telerik.WinControls.UI.RadForm
    {
        public LogonDialog()
        {
            InitializeComponent();

            Localize();

            this.FormElement.TitleBar.Font = new Font("Segoe UI", 14f);
            this.FormElement.TitleBar.CloseButton.AutoSize = true;
            this.radMaskedEditBox1.Focus();
        }

        private void Localize()
        {
            this.Text = ResourceStrings.GetString("Logon.ShortTitle");
            this.radLabel1.Text = ResourceStrings.GetString("Logon.Password");
            this.radMaskedEditBox1.NullText = ResourceStrings.GetString("Logon.PasswordRequired");
            this.radLabelValidation.Text = ResourceStrings.GetString("Logon.ShortFailure");
            this.radButton1.Text = ResourceStrings.GetString("Logon.Button.Text");
            this.radButton2.Text = ResourceStrings.GetString("Cancel");
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if(this.radMaskedEditBox1.Text == "m2m")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            this.radLabelValidation.Visible = true;
            this.radMaskedEditBox1.Focus();
        }

        private void radMaskedEditBox1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void radMaskedEditBox1_ValueChanging(object sender, CancelEventArgs e)
        {
            
        }

        private void radMaskedEditBox1_TextChanged(object sender, EventArgs e)
        {
            this.radButton1.Enabled = radMaskedEditBox1.Text != "";
            this.radLabelValidation.Visible = false;
        }
    }
}
