using System;
using System.Linq;

namespace M2M.DataCenter.WebUI
{
    public partial class Defibrillator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) - 10));
        }
    }
}
