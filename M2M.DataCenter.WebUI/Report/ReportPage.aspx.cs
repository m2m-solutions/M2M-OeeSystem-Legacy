using System;
using System.Data;
using M2M.DataCenter.Localization;
using M2M.DataCenter.Reports;
using Telerik.Web.UI;
using System.Drawing;

namespace M2M.DataCenter.WebUI.Report
{
	public partial class ReportPage : System.Web.UI.Page
	{
		#region Members

        
		
		#endregion

		#region Event Handlers

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
			{
                Page.Title = ResourceStrings.GetString("Page.Title.Report");
       	    }
		}

		#endregion

		#region Methods

		protected void HideAndShowControls()
		{
		
		}

        protected void gridReports_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable gridData = new DataTable();
            gridData.Columns.Add("GroupName");
            gridData.Columns.Add("DisplayName");
            gridData.Columns.Add("Description");
            gridData.Columns.Add("NavigateUrl");

            foreach (Type t in ReportExplorer.GetReports())
            {
                string groupName = ResourceStrings.GetString(String.Format("Report.{0}.GroupName", t.Name));
                string displayName = ResourceStrings.GetString(String.Format("Report.{0}.DisplayName", t.Name));
                string description = ResourceStrings.GetString(String.Format("Report.{0}.Description", t.Name));

                //TODO: Add Grouping support. The DescriptionAttribute DescriptionAttribute i.e. TypeDescriptor.GetAttributes(type)[typeof(DescriptionAttribute)]
                // has the value Default for all Default reports or the name of a customer dependant module for example "Npb"

                object[] values = new object[]
                    {
                        groupName
                        , displayName
                        , description
                        ,  "ReportViewer.aspx?ReportName=" + Server.UrlEncode(t.AssemblyQualifiedName) + "&Title=" + Server.UrlEncode(displayName) + "&Filter=" + Server.UrlEncode(t.Name)
				    };
                
                gridData.Rows.Add(values);
            }


            this.gridReports.DataSource = gridData;
        }

        

		#endregion

        protected void gridReports_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridGroupHeaderItem)
            {
                GridGroupHeaderItem item = (GridGroupHeaderItem)e.Item;
                DataRowView groupDataRow = (DataRowView)e.Item.DataItem;
                item.DataCell.Text = groupDataRow["GroupName"].ToString();
            }
        }

        protected void gridReports_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
            if (e.Column is GridGroupSplitterColumn)
            {
                (e.Column as GridGroupSplitterColumn).HeaderButtonType = GridHeaderButtonType.LinkButton;
                (e.Column as GridGroupSplitterColumn).ItemStyle.BackColor = Color.White;
                (e.Column as GridGroupSplitterColumn).ItemStyle.BorderColor = Color.White;
                (e.Column as GridGroupSplitterColumn).ExpandImageUrl = "~/images/SinglePlus.gif";
                (e.Column as GridGroupSplitterColumn).CollapseImageUrl = "~/images/SingleMinus.gif";
            }
        }
	}
}
