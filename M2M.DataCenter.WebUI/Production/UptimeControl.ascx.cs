using System;

namespace M2M.DataCenter.WebUI.Production
{
	public partial class UptimeControl : System.Web.UI.UserControl
	{
		public string Uptime
		{
			get
			{
				return lbUptime.Text;
			}
			set
			{
				lbUptime.Text = value;
			}
		}

		public string UptimeTransferred
		{
			get
			{
				return lbUptimeTransferred.Text;
			}
			set
			{
                lbUptimeTransferred.Text = value;
			}
		}

		public string Moments
		{
			get
			{
				return lbMoments.Text;
			}
			set
			{
				lbMoments.Text = value;
			}
		}

		public string MomentsTransferred
		{
			get
			{
                return lbMomentsTransferred.Text;
			}
			set
			{
                lbMomentsTransferred.Text = value;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}