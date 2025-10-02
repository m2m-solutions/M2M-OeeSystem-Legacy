using System;
using System.Windows.Forms;
using Telerik.WinControls;

namespace M2M.DataCenter.AdminTool
{
    public partial class LogonDlg : Telerik.WinControls.UI.RadForm
    {
        private int retries = 3;

        public LogonDlg()
        {
            InitializeComponent();

            this.AcceptButton = btnLogon;
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            if(tbUser.Text == "m2m" && tbPassword.Text == "m2m07")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            if (retries-- > 0)
            {
                RadMessageBox.Show(this, String.Format("Fel användare och/eller lösenord.\n\n{0} försök återstår.", retries), "Felmeddelande", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            else
            {
                RadMessageBox.Show(this, "Fel användare och/eller lösenord.\n\nProgrammet avslutas.", "Felmeddelande", MessageBoxButtons.OK, RadMessageIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
