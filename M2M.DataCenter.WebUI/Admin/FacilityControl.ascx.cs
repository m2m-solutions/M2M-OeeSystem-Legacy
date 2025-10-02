using System;

namespace M2M.DataCenter.WebUI.Admin
{
	public partial class FacilityControl : System.Web.UI.UserControl
	{
		#region Members


		#endregion

		#region Event Handlers

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{

			}

		}

		#endregion

		#region Methods

		public void BindData()
		{
			BindInfo();
			BindList();
		}

		private void BindInfo()
		{
            
		}

		private void BindList()
		{
			ucDivisionListControl.BindData();
		}

	
		#endregion

		
	}
}