using System;
using Telerik.Web.UI;

namespace M2M.DataCenter.WebUI.Admin
{
	public partial class MachineListControl : System.Web.UI.UserControl
	{
		#region Members

		public Division CurrentDivision
		{
			get
			{
				return (Division)Session["CurrentDivision"];
			}
		}
		
		#endregion

		#region Event Handlers

		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void gridMachines_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
		{
			PlainMachineList machines = M2MDataCenter.GetMachineList(CurrentDivision.DivisionId);
			gridMachines.DataSource = machines;
		}

	
		#endregion

		#region Methods

		public void BindData()
		{
			gridMachines.Rebind();
		}

		#endregion

		
	}
}