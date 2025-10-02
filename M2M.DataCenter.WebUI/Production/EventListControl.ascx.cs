using System;
using System.Drawing;
using Telerik.Web.UI;
using M2M.DataCenter.Localization;
using System.Web.UI.WebControls;

namespace M2M.DataCenter.WebUI.Production
{
    [Serializable]
	public partial class EventListControl : System.Web.UI.UserControl
	{
        #region Properties
		
		public GenericFilter Criteria
		{
			get
			{
				return (GenericFilter)Session["CurrentCriteria"];
			}
		}

        public int PageIndex
        {
            get
            {
                if (ViewState["PageIndex"] == null)
                    return 0;
                return (int)ViewState["PageIndex"];
            }
            set
            {
                ViewState["PageIndex"] = value;
                gridEvents.CurrentPageIndex = 0;
            }
        }

        public int PageSize
        {
            get
            {
                if (ViewState["PageSize"] == null)
                    return 20;
                return (int)ViewState["PageSize"];
            }
            set
            {
                ViewState["PageSize"] = value;
            }
        }

		#endregion

		#region Event Handlers

		protected void Page_Load(object sender, EventArgs e)
		{
            
		}

		protected void gridEvents_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
		{
            EventList.Criteria criteria = Criteria.GetEventListCriteria();
            criteria.PageIndex = this.PageIndex;
            criteria.PageSize = this.PageSize;
            criteria.FetchPagedData = true;
			EventList events = EventList.GetEventList(criteria);

            gridEvents.VirtualItemCount = events.TotalRowCount;
			gridEvents.DataSource = events;
            
		}

		protected void gridEvents_ItemDataBound(object sender, GridItemEventArgs e)
		{
			if ((e.Item.ItemType == GridItemType.Item) || (e.Item.ItemType == GridItemType.AlternatingItem))
			{
				GridDataItem dataItem = e.Item as GridDataItem;
                EventListItem eventItem = dataItem.DataItem as EventListItem;

                string displayName = eventItem.DisplayName;
                if (eventItem.ReasonDisplayName != "")
                    displayName = string.Format("{0} ({1})", eventItem.ReasonDisplayName, eventItem.TagInfoDisplayName);

                dataItem["DisplayName"].Text = displayName;

                if (Criteria.MachineId == null)
                    dataItem["MachineId"].Text = M2MDataCenter.GetMachine(eventItem.MachineId).DisplayName; // M2MDataCenter.GetMachine(eventItem.MachineId).DisplayName;
                
				switch (eventItem.TagType)
                {
                    case TagType.Stop:
                    case TagType.UnidentifiedStop:
                        dataItem["TagType"].Text = ResourceStrings.GetString(TagType.Stop);
                        dataItem["TagType"].ForeColor = Color.Red;
                        break;
                    case TagType.MainAlarm:
                        dataItem["TagType"].Text = ResourceStrings.GetString(TagType.MainAlarm);
                        dataItem["TagType"].ForeColor = Color.Red;
                        break;
                    case TagType.CommunicationError:
                    case TagType.CommunicationBadQuality:
                    case TagType.InitiatingCommunication:
                    case TagType.ExpectedRestart:
                    case TagType.UnexpectedRestart:
                        dataItem["TagType"].Text = ResourceStrings.GetString("System");
                        dataItem["TagType"].ForeColor = Color.Red;
                        break;
                    case TagType.Informational:
                        dataItem["TagType"].Text = ResourceStrings.GetString(TagType.Informational);
                        dataItem["TagType"].ForeColor = Color.Green;
                        break;
                    case TagType.Auto:
                        dataItem["TagType"].Text = ResourceStrings.GetString("Auto");
                        dataItem["TagType"].ForeColor = Color.Blue;
                        break;
                    case TagType.ProductionSwitch:
                        dataItem["TagType"].Text = ResourceStrings.GetString("ProductionSwitch");
                        dataItem["TagType"].ForeColor = Color.Black;
                        break;
                }

                if (eventItem.TagType != TagType.Auto)
				{
					dataItem["PaceAsString"].Text = "";
				}

				TimeSpan elapsedTime = TimeSpan.Parse(dataItem["ElapsedTime"].Text);
                
                bool active = !eventItem.Complete;
                
                if(active)
                    dataItem["ElapsedTime"].ForeColor = Color.Red;
                
                if (elapsedTime.Ticks == 0)
				{
					dataItem["ElapsedTime"].Text = "";
				}
                else if (elapsedTime.TotalSeconds < 1)
				{
					dataItem["ElapsedTime"].Text = active ? ResourceStrings.GetString("Active") :  "< 1 " + ResourceStrings.GetString("#-Seconds.Abbr");
                    dataItem["ElapsedTime"].ToolTip = String.Format("{0:n0} {1}", elapsedTime.Milliseconds, ResourceStrings.GetString("#-MilliSeconds.Abbr"));
				}
                else if (elapsedTime.TotalDays >= 1)
				{
					dataItem["ElapsedTime"].Text = active ? ResourceStrings.GetString("Active") :  "> 1 " + ResourceStrings.GetString("#-Days.Abbr");
                    dataItem["ElapsedTime"].ToolTip = String.Format("{0:n1} {1}", elapsedTime.TotalHours, ResourceStrings.GetString("#-Hours.Abbr"));
				}
                else if (elapsedTime.TotalHours >= 1)
                {
                    dataItem["ElapsedTime"].Text = active ? ResourceStrings.GetString("Active") :  String.Format("{0:n1} {1}", elapsedTime.TotalHours, ResourceStrings.GetString("#-Hours.Abbr"));
                }
                else if (elapsedTime.TotalMinutes < 3)
                {
                    dataItem["ElapsedTime"].Text = active ? ResourceStrings.GetString("Active") : String.Format("{0:n0} {1}", elapsedTime.TotalSeconds, ResourceStrings.GetString("#-Seconds.Abbr"));
                }
				else
				{
                    dataItem["ElapsedTime"].Text = active ? ResourceStrings.GetString("Active") : String.Format("{0:n2} {1}", elapsedTime.TotalMinutes, ResourceStrings.GetString("#-Minutes.Abbr"));
				}
			}
		}

		#endregion

		#region Methods

		public void BindData()
		{

			gridEvents.Rebind();
		}

		#endregion

        protected void gridEvents_PreRender(object sender, EventArgs e)
        {
            gridEvents.MasterTableView.GetColumn("MachineId").Visible = Criteria.MachineId == null;
            gridEvents.MasterTableView.GetColumn("DisplayName").HeaderStyle.Width = M2MDataCenter.GetAvailableModules().Contains("Npb") ? Unit.Empty : Unit.Pixel(220);
            gridEvents.MasterTableView.GetColumn("ArticleNumber").HeaderStyle.Width = M2MDataCenter.GetAvailableModules().Contains("Npb") ? Unit.Pixel(60) : Unit.Empty;
            gridEvents.Rebind();  

        }

        protected void gridEvents_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.PageIndex = e.NewPageIndex;
            gridEvents.Rebind();  
        }

        protected void gridEvents_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.PageSize = e.NewPageSize;
            this.PageIndex = 0;
            gridEvents.Rebind();  
        }

		
	}
}