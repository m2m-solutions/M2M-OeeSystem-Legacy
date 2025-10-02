using System;
using System.Drawing;
using System.Windows.Forms;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.Panel.FormsUI
{
    public partial class CustomMessageBox : Telerik.WinControls.UI.RadForm
    {
        public CustomMessageBox()
        {
            InitializeComponent();

            Localize();
        }

        private void Localize()
        {
            this.radButton1.Text = ResourceStrings.GetString("OK");
        }

        public void Show(IWin32Window parent, string caption, string message)
        {
            this.FormElement.TitleBar.Font = new Font("Segoe UI", 14f);
            this.Text = caption;

            this.radLabel1.Text = message;
            this.ShowDialog(parent);
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
