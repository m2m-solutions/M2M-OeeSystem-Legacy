using System;
using System.Drawing;
using Telerik.Web.UI;


namespace M2M.DataCenter.WebUI.Production
{
	public partial class DivisionListControl : System.Web.UI.UserControl
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

        private DivisionStatusList StatusList
        {
            get
            {
                return (DivisionStatusList)ViewState["StatusList"];
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
			if (m_Divisions != null)
            {
                StatusList = new DivisionStatusList();
                StatusList.LoadStatusList(m_Divisions);
                gridDivisions.DataSource = m_Divisions;
            }
		}

		protected void gridDivisions_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if ((e.Item.ItemType == GridItemType.Item) || (e.Item.ItemType == GridItemType.AlternatingItem))
            {
                GridDataItem dataItem = e.Item as GridDataItem;

                DivisionStatusList.StatusItem statusItem = StatusList.GetStatusItem(dataItem["DivisionId"].Text);

                dataItem["Running"].Text = statusItem.Status;
                
                if(statusItem.TotalCount == 0)
                    dataItem["Running"].ForeColor = Color.Black; 
                else
                    dataItem["Running"].ForeColor = (statusItem.RunningCount < statusItem.TotalCount) ? Color.DarkRed : Color.Green;
                                   
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