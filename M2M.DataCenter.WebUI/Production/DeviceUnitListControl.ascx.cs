using System;
using System.Drawing;
using Telerik.Web.UI;

namespace M2M.DataCenter.WebUI.Production
{
	public partial class DeviceUnitListControl : System.Web.UI.UserControl
	{
		#region Members

		private DivisionList m_Divisions = null;

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

		protected void gridDivisions_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
		{
			if (!e.IsFromDetailTable)
			{
				if(m_Divisions != null)
					gridDivisions.DataSource = m_Divisions;
			}
		}

		protected void gridDivisions_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
		{
			//GridDataItem parentItem = e.DetailTableView.ParentItem as GridDataItem;

			//if (e.DetailTableView.Name == "Machines")
			//{
			//    Criteria.DivisionId = parentItem["DivisionId"].Text;
			//    MachineList machines = MachineList.GetMachineList(Criteria.GetMachineListCriteria());

			//    StatusList = new MachineStatusList();
			//    StatusList.LoadStatusList(machines);
			//    e.DetailTableView.DataSource = machines;
			//}

		}

        protected void gridDivisions_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if ((e.Item.ItemType == GridItemType.Item) || (e.Item.ItemType == GridItemType.AlternatingItem))
            {
                GridDataItem dataItem = e.Item as GridDataItem;

                if (e.Item.OwnerTableView.Name == "Machines")
                {
                    MachineStatusList.StatusItem statusItem = StatusList.GetStatusItem(dataItem["MachineId"].Text);

                    dataItem["Status"].Text = statusItem.Status;
                    dataItem["ArticleNumber"].Text = statusItem.ArticleNumber;

                    if (statusItem.InProduction)
                        dataItem["Status"].ForeColor = statusItem.Running ? Color.Green : Color.Red;
                    else
                        dataItem["Status"].ForeColor = Color.Black;
                }
            }
        }
			
				

		#endregion

		#region Methods

		public void BindData(DivisionList divisions)
		{
			m_Divisions = divisions;
			gridDivisions.DataSource = null; 
			gridDivisions.Rebind();
		}

		#endregion

	}
}