using System;

namespace M2M.DataCenter.WebUI.Production
{
	public partial class OEEControl : System.Web.UI.UserControl
	{
        public string Availability
		{
			get
			{
				return lbAvailability.Text;
			}
			set
			{
				lbAvailability.Text = value;
			}
		}

        public string AvailabilityLoss
        {
            get
            {
                return lbAvailabilityLoss.Text;
            }
            set
            {
                lbAvailabilityLoss.Text = value;
            }
        }

        public string Performance
		{
			get
			{
				return lbPerformance.Text;
			}
			set
			{
				lbPerformance.Text = value;
			}
		}


		public string Quality
		{
			get
			{
				return lbQuality.Text;
			}
			set
			{
				lbQuality.Text = value;
			}
		}

		public string OEE
		{
			get
			{
				return lbOEE.Text;
			}
			set
			{
				lbOEE.Text = value;
			}
		}

        public string Pace
        {
            get
            {
                return lbPace.Text;
            }
            set
            {
                lbPace.Text = value;
            }
        }

        public string PaceUnit
        {
            get
            {
                return lbPaceUnit.Text;
            }
            set
            {
                lbPaceUnit.Text = value;
            }
        }

        public bool ShowPace
        {
            set
            {
                lbPace.Style["display"] = value ? "block" : "none";
                lbPaceUnit.Style["display"] = value ? "block" : "none";
            }
        }
		
		protected void Page_Load(object sender, EventArgs e)
		{
            
		}
	}
}