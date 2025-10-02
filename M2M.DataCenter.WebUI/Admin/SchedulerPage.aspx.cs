using System;

using System.Linq;

using System.Web.UI;

using Telerik.Web.UI;
using System.Threading;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.WebUI.Admin
{
    public partial class SchedulerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RadScheduler1.Culture = Thread.CurrentThread.CurrentCulture;
                LoadDeviceUnits();
            }
        }

        protected void RadScheduler1_DataBound(object sender, EventArgs e)
        {
            RadScheduler1.ResourceTypes.FindByName("DeviceUnit").AllowMultipleValues = false;
            RadScheduler1.ResourceTypes.FindByName("Shift").AllowMultipleValues = false;
        }

        protected void RadScheduler1_AppointmentCreated(object sender, AppointmentCreatedEventArgs e)
        {
            //if (e.Appointment.RecurrenceState == RecurrenceState.Master || e.Appointment.RecurrenceState == RecurrenceState.Occurrence)
            //{
            //    Panel recurrenceStateDiv = new Panel();
            //    recurrenceStateDiv.CssClass = "rsAptRecurrence";
            //    e.Container.Controls.AddAt(0, recurrenceStateDiv);
            //}
            //if (e.Appointment.RecurrenceState == RecurrenceState.Exception)
            //{
            //    Panel recurrenceStateDiv = new Panel();
            //    recurrenceStateDiv.CssClass = "rsAptRecurrenceException";
            //    e.Container.Controls.AddAt(0, recurrenceStateDiv);
            //}
        }

        protected void RadScheduler1_AppointmentDataBound(object sender, SchedulerEventArgs e)
        {
            switch (Convert.ToInt32(e.Appointment.Resources.GetResourceByType("Shift").Key))
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
                    e.Appointment.CssClass = "rsCategoryBlack";
                    break;
            }

            e.Appointment.ToolTip = String.Format("{0}\n{1}\n{2} - {3}", e.Appointment.Resources.GetResourceByType("DeviceUnit").Text, e.Appointment.Resources.GetResourceByType("Shift").Text, e.Appointment.Start.ToString("t"), e.Appointment.End.ToString("t"));
        }

        protected void RadScheduler1_NavigationComplete(object sender, SchedulerNavigationCompleteEventArgs e)
        {
            if (RadScheduler1.SelectedView == SchedulerViewType.MultiDayView)
            {
                //SelectedDate adjustment to make a Work Week view from Multi-day view
                int workWeekAdjustmentTimeShift = (int)RadScheduler1.FirstDayOfWeek - (int)RadScheduler1.SelectedDate.DayOfWeek;
                if (e.Command == SchedulerNavigationCommand.NavigateToNextPeriod)
                {
                    if (workWeekAdjustmentTimeShift < 0)
                        workWeekAdjustmentTimeShift += 7;

                }
                else if (e.Command == SchedulerNavigationCommand.NavigateToPreviousPeriod)
                {
                    if (workWeekAdjustmentTimeShift > 0)
                        workWeekAdjustmentTimeShift -= 7;
                }
                RadScheduler1.SelectedDate = RadScheduler1.SelectedDate.AddDays(workWeekAdjustmentTimeShift);
            }
        }

        protected void RadScheduler1_AppointmentUpdate(object sender, Telerik.Web.UI.AppointmentUpdateEventArgs e)
        {
            if (e.ModifiedAppointment.Resources.GetResourceByType("Shift") == null)
            {
                string script = "<script type=\"text//javascript\"> window.setTimeout(function() { alert('" + ResourceStrings.GetString("Warning.NoShiftSelected") + "{0}'); }, 100);<//script>";

                if (!Page.ClientScript.IsClientScriptBlockRegistered("ValidateShift"))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "ValidateShift", script, false);
                }
                e.Cancel = true;
            }
        }

        

        protected void RadScheduler1_AppointmentInsert(object sender, AppointmentInsertEventArgs e)
        {
            if (e.Appointment.Resources.GetResourceByType("Shift") == null)
            {
                string script = "<script type=\"text//javascript\"> window.setTimeout(function() { alert('" + ResourceStrings.GetString("Warning.NoShiftSelected") + "{0}'); }, 100);<//script>";

                if (!Page.ClientScript.IsClientScriptBlockRegistered("ValidateShift"))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "ValidateShift", script, false);
                }
                e.Cancel = true;
        }
        }

        protected void RadScheduler1_FormCreated(object sender, SchedulerFormCreatedEventArgs e)
        {
            if ((e.Container.Mode == SchedulerFormMode.AdvancedEdit) || (e.Container.Mode == SchedulerFormMode.AdvancedInsert))
            {
                

            }

        }

        protected void btnAddDeviceUnit_Click(object sender, EventArgs e)
        {
            if (DeviceUnits.SelectedIndex < 0)
                return;

            string script = "<script type=\"text//javascript\"> window.setTimeout(function() { alert('" + ResourceStrings.GetString("Warning.NoShiftSelected") + "{0}'); }, 100);<//script>";

            if (!Page.ClientScript.IsClientScriptBlockRegistered("ValidateShift"))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "ValidateShift", script, false);
            }
        }

        protected void LoadDeviceUnits()
        {
            DeviceUnits.EmptyMessage = ResourceStrings.GetString("SelectDeviceUnit");
            DeviceUnits.DataTextField = "DisplayName";
            DeviceUnits.DataValueField = "DeviceUnitId";
            DeviceUnits.DataSource = M2MDataCenter.GetDeviceUnitSortedList();
            DeviceUnits.DataBind();
        }

    }
}

