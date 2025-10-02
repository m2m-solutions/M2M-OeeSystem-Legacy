using System;
using System.Drawing;

namespace M2M.DataCenter.WebUI.Production
{
	public partial class StatusControl : System.Web.UI.UserControl
	{
		public string Status
		{
			get
			{
				return lbStatus.Text;
			}
			set
			{
				lbStatus.Text = value;
			}
		}

        public Color StatusColor
        {
            get
            {
                return lbStatus.ForeColor;
            }
            set
            {
                lbStatus.ForeColor = value;
            }
        }

		public string Article
		{
			get
			{
				return lbArticle.Text;
			}
			set
			{
				lbArticle.Text = value;
			}
		}
	
		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}