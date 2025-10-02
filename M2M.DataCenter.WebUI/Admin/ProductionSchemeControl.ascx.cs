using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Threading;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.WebUI.Admin
{
	public partial class ProductionSchemeControl : System.Web.UI.UserControl
	{
        private SystemSettingCollection SystemSettings
        {
            get
            {
                return (SystemSettingCollection)(ViewState["SystemSettings"] ?? (ViewState["SystemSettings"] = SystemSettingCollection.GetSettingCollection()));
            }
            set
            {
                ViewState["SystemSettings"] = value;
            }
        }

        private bool FirstAppointmentFound
        {
            get
            {
                object o = ViewState["FirstAppointmentFound"];
                if (o != null)
                    return (bool)o;
                return false;
            }
            set
            {
                ViewState["FirstAppointmentFound"] = value;
            }
        }

		public string CurrentDivisionId
		{
			get
			{
				return ((Division)Session["CurrentDivision"]).DivisionId;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
            if (RadScheduler1.SelectedView == SchedulerViewType.MonthView)
            {
                RadScheduler1.RowHeight = Unit.Pixel(20);
            }
            else
            {
                RadScheduler1.RowHeight = Unit.Pixel(15);
            }
            
            if (!Page.IsPostBack)
            {
                RadScheduler1.Culture = Thread.CurrentThread.CurrentCulture;
            }
		}

		public void BindData()
		{
			ProductionSchemeItemCollection productionScheme = ProductionSchemeItemCollection.GetProductionSchemeItemCollection(CurrentDivisionId);
			RadScheduler1.DataSource = productionScheme;
			RadScheduler1.DataBind();
   
		}

		protected void RadScheduler1_AppointmentUpdate(object sender, Telerik.Web.UI.AppointmentUpdateEventArgs e)
		{
			if (Convert.ToInt32(e.ModifiedAppointment.Subject) < 0)
			{
                string script = "<script type=\"text//javascript\"> window.setTimeout(function() { alert('" + ResourceStrings.GetString("Warning.NoShiftSelected") + "{0}'); }, 100);<//script>";

				if (!Page.ClientScript.IsClientScriptBlockRegistered("ValidateProperty"))
				{
					ScriptManager.RegisterClientScriptBlock(Page, GetType(), UniqueID, script, false);
				}

				e.Cancel = true;
			}
			else
			{
				ProductionSchemeItem item = ProductionSchemeItem.GetProductionSchemeItem((Guid)e.Appointment.ID);
				item.Shift = Convert.ToInt32(e.ModifiedAppointment.Subject);
				item.StartTime = e.ModifiedAppointment.Start;
				item.EndTime = e.ModifiedAppointment.End;
				item.DivisionId = CurrentDivisionId;

                RecurrenceRule rrule;
                if (RecurrenceRule.TryParse(e.ModifiedAppointment.RecurrenceRule, out rrule))
                {
                    rrule.Range.Start = e.ModifiedAppointment.Start;
                    rrule.Range.EventDuration = e.ModifiedAppointment.End - e.ModifiedAppointment.Start;
                    TimeSpan startTimeChange = e.ModifiedAppointment.Start - e.Appointment.Start;
                    for (int i = 0; i < rrule.Exceptions.Count; i++)
                    {
                        rrule.Exceptions[i] = rrule.Exceptions[i].Add(startTimeChange);
                    }

                    e.ModifiedAppointment.RecurrenceRule = rrule.ToString();
                }

				item.RecurrenceRule = e.ModifiedAppointment.RecurrenceRule;
				item.RecurrenceParentId = (Guid?)e.ModifiedAppointment.RecurrenceParentID;

				item.Save();

				BindData();
			}
		}

		protected void RadScheduler1_NavigationCommand(object sender, Telerik.Web.UI.SchedulerNavigationCommandEventArgs e)
		{
            if (e.Command == SchedulerNavigationCommand.SwitchToMonthView)
            {
                RadScheduler1.RowHeight = Unit.Pixel(20);
            }
            else
            {
                RadScheduler1.RowHeight = Unit.Pixel(15);
            }

            FirstAppointmentFound = false;
			BindData();
		}

		protected void RadScheduler1_AppointmentInsert(object sender, Telerik.Web.UI.SchedulerCancelEventArgs e)
		{
			if (Convert.ToInt32(e.Appointment.Subject) < 0)
			{
                string script = "<script type=\"text//javascript\"> window.setTimeout(function() { alert('" + ResourceStrings.GetString("Warning.NoShiftSelected") + "{0}'); }, 100);<//script>";

				if (!Page.ClientScript.IsClientScriptBlockRegistered("ValidateProperty"))
				{
					ScriptManager.RegisterClientScriptBlock(Page, GetType(), UniqueID, script, false);
				}  

				e.Cancel = true;
			}
			else
			{
				ProductionSchemeItem item = ProductionSchemeItem.NewProductionSchemeItem();
				item.Shift = Convert.ToInt32(e.Appointment.Subject);
				item.StartTime = e.Appointment.Start;
				item.EndTime = e.Appointment.End;
				item.DivisionId = CurrentDivisionId;
				item.RecurrenceRule = e.Appointment.RecurrenceRule;
				item.RecurrenceParentId = (Guid?)e.Appointment.RecurrenceParentID;

				item.Save();

				BindData();
			}
		}

		protected void RadScheduler1_FormCreating(object sender, SchedulerFormCreatingEventArgs e)
		{
			RadScheduler scheduler1 = (RadScheduler)sender;

			if (e.Mode == SchedulerFormMode.AdvancedInsert)
			{
				e.Appointment.Subject = "-1";
			}

			
			if ((scheduler1.SelectedView == SchedulerViewType.MonthView) && (e.Mode == SchedulerFormMode.AdvancedInsert))
			{
				e.Appointment.Start = e.Appointment.Start.Add(new TimeSpan(8, 0, 0));
				e.Appointment.End = e.Appointment.Start.Add(new TimeSpan(1, 0, 0));
			}      

		}

		protected void RadScheduler1_AppointmentDelete(object sender, SchedulerCancelEventArgs e)
		{
			ProductionSchemeItem item = ProductionSchemeItem.GetProductionSchemeItem((Guid)e.Appointment.ID);
			item.Delete();
			
			item.Save();

			BindData();

		}

		protected void RadScheduler1_AppointmentDataBound(object sender, Telerik.Web.UI.SchedulerEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Appointment.Subject))
			{
				switch (Convert.ToInt32(e.Appointment.Subject))
				{
					case 0:
						e.Appointment.CssClass = "rsCategoryYellow";
						break;
					case 1:
						e.Appointment.CssClass = "rsCategoryBlue";
						break;
                    case 2:
						e.Appointment.CssClass = "rsCategoryRed";
						break;
                    case 3:
						e.Appointment.CssClass = "rsCategoryGreen";
						break;
                    case 4:
						e.Appointment.CssClass = "rsCategoryOrange";
						break;
                    case 5:
						e.Appointment.CssClass = "rsCategoryDarkBlue";
						break;      
                    case 6:
						e.Appointment.CssClass = "rsCategoryDarkRed";
						break;
                    case 7:
						e.Appointment.CssClass = "rsCategoryDarkGreen";
						break;
                    case 8:
						e.Appointment.CssClass = "rsCategoryViolet";
						break;
                    default:
						e.Appointment.CssClass = "rsCategoryPink";
						break; 
				}
			}

            e.Appointment.ToolTip = string.Format("{0} - {1}", e.Appointment.Start.ToString("t"), e.Appointment.End.ToString("t"));
            e.Appointment.Description = string.Format("<b>{0}</b><br>{1} - {2}", M2MDataCenter.GetShiftName(Convert.ToInt32(e.Appointment.Subject)), e.Appointment.Start.ToString("t"), e.Appointment.End.ToString("t"));
        }

        protected void RadScheduler1_TimeSlotCreated(object sender, Telerik.Web.UI.TimeSlotCreatedEventArgs e)
        {
            if(SystemSettings.PurplepointMode)
            {
                RadScheduler1.Visible = false;
                ProductionModeWarning.Visible = true;
            }
            else if (!FirstAppointmentFound && e.TimeSlot.Appointments.Count > 0)
            {
                e.TimeSlot.CssClass = "FirstAppointment";
                FirstAppointmentFound = true;
            }
        }
	}
}