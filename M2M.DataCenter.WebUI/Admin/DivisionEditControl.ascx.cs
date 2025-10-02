using System;

namespace M2M.DataCenter.WebUI.Admin
{
	public partial class DivisionEditControl : System.Web.UI.UserControl
	{
		public event EventHandler SaveClick;

		public string DivisionId
		{
			get
			{
				return tbDivisionId.Text;
			}
			set
			{
				tbDivisionId.Text = value;
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