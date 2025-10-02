using System;
using System.Drawing;
using Telerik.Web.UI;
using System.Data.SqlClient;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter.WebUI.Production
{
	public partial class MachineListControl : System.Web.UI.UserControl
	{
		#region Members

		public GenericFilter Criteria
		{
			get
			{
				return (GenericFilter)Session["CurrentCriteria"];
			}
		}

		private MachineStatusList StatusList
		{
			get
			{
				return (MachineStatusList)ViewState["StatusList"];
			}
			set
			{
				ViewState["StatusList"] = value;
			}
		}

		#endregion

		#region Event Handlers

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void gridMachines_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
		{
			MachineList machines = null;
			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionStringWithMultipleActiveResultSets))
			{
				connection.Open();
				MachineList.Criteria criteria = Criteria.GetMachineListCriteria();
				criteria.Connection = connection;
				machines = MachineList.GetMachineList(criteria);
			}
            
			StatusList = new MachineStatusList();
			StatusList.LoadStatusList(machines);

			gridMachines.DataSource = machines;
		}

		protected void gridMachines_ItemDataBound(object sender, GridItemEventArgs e)
		{
			if ((e.Item.ItemType == GridItemType.Item) || (e.Item.ItemType == GridItemType.AlternatingItem))
			{
				GridDataItem dataItem = e.Item as GridDataItem;

				MachineStatusList.StatusItem statusItem = StatusList.GetStatusItem(dataItem["MachineId"].Text);

				dataItem["Status"].Text = statusItem.Status;
                dataItem["ArticleNumberOrActiveStop"].Text = statusItem.ActiveStop != "" ? statusItem.ActiveStop.SafeSubstring(20, true) : statusItem.ArticleNumber;
                if (statusItem.ActiveStop.Length > 20)
                    dataItem["ArticleNumberOrActiveStop"].ToolTip = statusItem.ActiveStop;

                if (statusItem.InProduction && statusItem.IsConnected)
                {
                    dataItem["Status"].ForeColor = statusItem.Running ? Color.Green : Color.Red;
                    dataItem["ArticleNumberOrActiveStop"].ForeColor = statusItem.Running ? Color.Black : Color.Red;
                }
                else
                    dataItem["Status"].ForeColor = Color.Black;
			}
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