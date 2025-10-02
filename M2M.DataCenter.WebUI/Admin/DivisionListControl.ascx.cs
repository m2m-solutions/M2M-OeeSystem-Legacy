using System;
using Telerik.Web.UI;
using System.Collections.Generic;

namespace M2M.DataCenter.WebUI.Admin
{
	public partial class DivisionListControl : System.Web.UI.UserControl
	{
		#region Members

		#endregion

		#region Event Handlers

		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void gridDivisions_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
		{
            List<PlainDivisionListItem> divisions = M2MDataCenter.GetDivisionsAccessibleForUser();

			gridDivisions.DataSource = divisions;
		}

        #endregion


        #region Methods

        public void BindData()
		{
			gridDivisions.Rebind();
		}

		#endregion

		protected void gridDivisions_ItemCreated(object sender, GridItemEventArgs e)
		{
			

		}

		

	}
}