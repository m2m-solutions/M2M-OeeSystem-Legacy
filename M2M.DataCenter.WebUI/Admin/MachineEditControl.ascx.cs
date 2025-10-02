using System;
using Telerik.Web.UI;

namespace M2M.DataCenter.WebUI.Admin
{
	public partial class MachineEditControl : System.Web.UI.UserControl
	{
		public event EventHandler SaveClick;

		public string MachineId
		{
			get
			{
				return tbMachineId.Text;
			}
			set
			{
				tbMachineId.Text = value;
			}
		}

		public string DisplayName
		{
			get
			{
				return tbDisplayName.Text;
			}
			set
			{
				tbDisplayName.Text = value;
			}
		}

		public string Notes
		{
			get
			{
				return tbNotes.Text;
			}
			set
			{
				tbNotes.Text = value;
			}
		}

		public int? IdealRunRate
		{
			get
			{
				return (int?)tbIdealRunRate.Value;
			}
			set
			{
				tbIdealRunRate.Value = value;
			}
		}

		public string LastModified
		{
			get
			{
				return lbLastModified.Text;
			}
			set
			{
				lbLastModified.Text = value;
			}
		}

		public RunRateUnit RunRateUnit
		{
			get
			{
				return (RunRateUnit)Enum.Parse(typeof(RunRateUnit), rcbRunRateUnit.SelectedValue);
			}
			set
			{
				RadComboBoxItem item = rcbRunRateUnit.FindItemByValue(value.ToString());

				item.Selected = true;
			}
		}

        public MomentUnit MomentUnit
        {
            get
            {
                return (MomentUnit)Enum.Parse(typeof(MomentUnit), rcbMomentUnit.SelectedValue);
            }
            set
            {
                RadComboBoxItem item = rcbMomentUnit.FindItemByValue(value.ToString());

                item.Selected = true;
            }
        }

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				
			}
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			if (SaveClick != null)
			{
				SaveClick(this, e);
			}
		}
	}
}