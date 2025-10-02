using System;
using System.Linq;
using System.Drawing;

namespace M2M.DataCenter.WebUI.Common
{
    public partial class ResponseControl : System.Web.UI.UserControl
    {
        public void SetInformation(string text)
        {
            lbText.Text = text;
            lbText.ForeColor = Color.Green;
            imageState.ImageUrl = "~/images/information.png";
            imageState.Visible = true;
        }

        public void SetWarning(string text)
        {
            SetWarning(text, null);
        }

        public void SetWarning(string text, Exception ex)
        {
            lbText.Text = text;
            lbText.ForeColor = Color.Orange;
            imageState.ImageUrl = "~/images/warning.png";
            imageState.Visible = true;
            if (ex != null)
                imageState.ToolTip = ex.Message;
        }

        public void SetError(string text)
        {
            SetError(text, null);
        }

        public void SetError(string text, Exception ex)
        {
            lbText.Text = text;
            lbText.ForeColor = Color.Red;
            imageState.ImageUrl = "~/images/error.png";
            imageState.Visible = true;
            if (ex != null)
                imageState.ToolTip = ex.Message;
        }

        public void Reset()
        {
            lbText.Text = "";
            imageState.Visible = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}