using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using M2M.DataCenter;

namespace SchedulerTemplatesCS
{
	/// <summary>
	/// Specifies the advanced form mode.
	/// </summary>
	public enum AdvancedFormMode
	{
		Insert, Edit
	}

	public partial class AdvancedForm : UserControl
	{
		#region Private members

		private bool FormInitialized
		{
			get
			{
				return (bool) (ViewState["FormInitialized"] ?? false);
			}

			set
			{
				ViewState["FormInitialized"] = value;
			}
		}

		private AdvancedFormMode mode = AdvancedFormMode.Insert;

		#endregion

		#region Protected properties

		protected RadScheduler Owner
		{
			get
			{
				return Appointment.Owner;
			}
		}

		protected Appointment Appointment
		{
			get
			{
				SchedulerFormContainer container = (SchedulerFormContainer) BindingContainer;
				return container.Appointment;
			}
		}

		#endregion

		
		#region Public properties

		public AdvancedFormMode Mode
		{
			get
			{
				return mode;
			}
			set
			{
				mode = value;
			}
		}

        [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
        public string Subject
        {
            get
            {
                return SubjectText.SelectedItem.Value;
            }
            set
            {
                SubjectText.SelectedValue = value;
            }
        } 

		[Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
		public DateTime Start
		{
			get
			{
                DateTime result = StartDate.SelectedDate.Value.Date;

                if (AllDayEvent.Checked)
                {
                    result = result.Date;
                }
                else
                {
                    TimeSpan time = StartTime.SelectedDate.Value.TimeOfDay;
                    result = result.Add(time);
                }

                return Owner.DisplayToUtc(result);
            }

			set
			{
				StartDate.SelectedDate = Owner.UtcToDisplay(value);
				StartTime.SelectedDate = Owner.UtcToDisplay(value);
			}
		}

		[Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
		public DateTime End
		{
			get
			{
                DateTime result = EndDate.SelectedDate.Value.Date;

                if (AllDayEvent.Checked)
                {
                    result = result.Date.AddDays(1);
                }
                else
                {
                    TimeSpan time = EndTime.SelectedDate.Value.TimeOfDay;
                    result = result.Add(time);
                }

                return Owner.DisplayToUtc(result);
            }

			set
			{
				EndDate.SelectedDate = Owner.UtcToDisplay(value);
				EndTime.SelectedDate = Owner.UtcToDisplay(value);
			}
		}


		[Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
		public string RecurrenceRuleText
		{
			get
			{
				if (Owner.RecurrenceSupport)
				{
                    bool dateSpecified = StartDate.SelectedDate.HasValue && EndDate.SelectedDate.HasValue;
                    bool timeSpecified = StartTime.SelectedDate.HasValue && EndTime.SelectedDate.HasValue;

                    if ((AllDayEvent.Checked && !dateSpecified) ||
                        (!AllDayEvent.Checked && !(dateSpecified && timeSpecified)))
                    {
                        return string.Empty;
                    }

                    AppointmentRecurrenceEditor.StartDate = Start;
                    AppointmentRecurrenceEditor.EndDate = End;

                    RecurrenceRule rrule = AppointmentRecurrenceEditor.RecurrenceRule;

					if (rrule == null)
					{
						return string.Empty;
					}

					RecurrenceRule originalRule;
					if (RecurrenceRule.TryParse(OriginalRecurrenceRule.Value, out originalRule))
					{
						rrule.Exceptions = originalRule.Exceptions;
					}

                    if (rrule.Range.RecursUntil != DateTime.MaxValue)
                    {
                        rrule.Range.RecursUntil = Owner.DisplayToUtc(rrule.Range.RecursUntil);

                        if (!AllDayEvent.Checked)
                        {
                            rrule.Range.RecursUntil = rrule.Range.RecursUntil.AddDays(1);
                        }
                    }

					return rrule.ToString();
				}

				return string.Empty;
			}

			set
			{
                RecurrenceRule rrule;
                RecurrenceRule.TryParse(value, out rrule);

                if (rrule != null)
                {
                    if (rrule.Range.RecursUntil != DateTime.MaxValue)
                    {
                        DateTime recursUntil = Owner.UtcToDisplay(rrule.Range.RecursUntil);

                        if (!IsAllDayAppointment(Appointment))
                        {
                            recursUntil = recursUntil.AddDays(-1);
                        }

                        rrule.Range.RecursUntil = recursUntil;
                    }

                    AppointmentRecurrenceEditor.RecurrenceRule = rrule;

                    OriginalRecurrenceRule.Value = value;
                }
			}
		}

        #endregion

		protected void Page_Load(object sender, EventArgs e)
		{
			UpdateButton.ValidationGroup = Owner.ValidationGroup;
			UpdateButton.CommandName = Mode == AdvancedFormMode.Edit ? "Update" : "Insert";

			InitializeStrings();
            InitializeRecurrenceEditor();

			if (!FormInitialized)
			{
                InitializeSubjectControl();
                UpdateResetExceptionsVisibility();
			}
        }

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (!FormInitialized)
			{
				if (IsAllDayAppointment(Appointment))
				{
					EndDate.SelectedDate = EndDate.SelectedDate.Value.AddDays(-1);
				}

				FormInitialized = true;
			}
		}

		protected void BasicControlsPanel_DataBinding(object sender, EventArgs e)
		{
			AllDayEvent.Checked = IsAllDayAppointment(Appointment);
		}

		protected void DurationValidator_OnServerValidate(object source, ServerValidateEventArgs args)
		{
			args.IsValid = (End - Start) > TimeSpan.Zero;
		}

		protected void ResetExceptions_OnClick(object sender, EventArgs e)
		{
			Owner.RemoveRecurrenceExceptions(Appointment);
			OriginalRecurrenceRule.Value = Appointment.RecurrenceRule;
			ResetExceptions.Text = Owner.Localization.AdvancedDone;
		}

		#region Private methods

		private void InitializeStrings()
		{
			SubjectValidator.ErrorMessage = Owner.Localization.AdvancedSubjectRequired;
			SubjectValidator.ValidationGroup = Owner.ValidationGroup;

			AllDayEvent.Text = Owner.Localization.AdvancedAllDayEvent;

			StartDateValidator.ErrorMessage = Owner.Localization.AdvancedStartDateRequired;
			StartDateValidator.ValidationGroup = Owner.ValidationGroup;

			StartTimeValidator.ErrorMessage = Owner.Localization.AdvancedStartTimeRequired;
			StartTimeValidator.ValidationGroup = Owner.ValidationGroup;

			EndDateValidator.ErrorMessage = Owner.Localization.AdvancedEndDateRequired;
			EndDateValidator.ValidationGroup = Owner.ValidationGroup;

			EndTimeValidator.ErrorMessage = Owner.Localization.AdvancedEndTimeRequired;
			EndTimeValidator.ValidationGroup = Owner.ValidationGroup;

			DurationValidator.ErrorMessage = Owner.Localization.AdvancedStartTimeBeforeEndTime;
			DurationValidator.ValidationGroup = Owner.ValidationGroup;

			ResetExceptions.Text = Owner.Localization.AdvancedReset;

            AppointmentRecurrenceEditor.Localization.CalendarCancel = Owner.Localization.AdvancedCalendarCancel;
            AppointmentRecurrenceEditor.Localization.CalendarOK = Owner.Localization.AdvancedCalendarOK;
            AppointmentRecurrenceEditor.Localization.CalendarToday = Owner.Localization.AdvancedCalendarToday;
            AppointmentRecurrenceEditor.Localization.Daily = Owner.Localization.AdvancedDaily;
            AppointmentRecurrenceEditor.Localization.Day = Owner.Localization.AdvancedDay;
            AppointmentRecurrenceEditor.Localization.Days = Owner.Localization.AdvancedDays;
            AppointmentRecurrenceEditor.Localization.EndAfter = Owner.Localization.AdvancedEndAfter;
            AppointmentRecurrenceEditor.Localization.EndByThisDate = Owner.Localization.AdvancedEndByThisDate;
            AppointmentRecurrenceEditor.Localization.Every = Owner.Localization.AdvancedEvery;
            AppointmentRecurrenceEditor.Localization.EveryWeekday = Owner.Localization.AdvancedEveryWeekday;
            AppointmentRecurrenceEditor.Localization.First = Owner.Localization.AdvancedFirst;
            AppointmentRecurrenceEditor.Localization.Fourth = Owner.Localization.AdvancedFourth;
            AppointmentRecurrenceEditor.Localization.Hourly = Owner.Localization.AdvancedHourly;
            AppointmentRecurrenceEditor.Localization.Hours = Owner.Localization.AdvancedHours;
            AppointmentRecurrenceEditor.Localization.Last = Owner.Localization.AdvancedLast;
            AppointmentRecurrenceEditor.Localization.MaskDay = Owner.Localization.AdvancedMaskDay;
            AppointmentRecurrenceEditor.Localization.MaskWeekday = Owner.Localization.AdvancedMaskWeekday;
            AppointmentRecurrenceEditor.Localization.MaskWeekendDay = Owner.Localization.AdvancedMaskWeekendDay;
            AppointmentRecurrenceEditor.Localization.Monthly = Owner.Localization.AdvancedMonthly;
            AppointmentRecurrenceEditor.Localization.Months = Owner.Localization.AdvancedMonths;
            AppointmentRecurrenceEditor.Localization.NoEndDate = Owner.Localization.AdvancedNoEndDate;
            AppointmentRecurrenceEditor.Localization.Occurrences = Owner.Localization.AdvancedOccurrences;
            AppointmentRecurrenceEditor.Localization.Of = Owner.Localization.AdvancedOf;
            AppointmentRecurrenceEditor.Localization.OfEvery = Owner.Localization.AdvancedOfEvery;
            AppointmentRecurrenceEditor.Localization.RecurEvery = Owner.Localization.AdvancedRecurEvery;
            AppointmentRecurrenceEditor.Localization.Recurrence = Owner.Localization.AdvancedRecurrence;
            AppointmentRecurrenceEditor.Localization.Second = Owner.Localization.AdvancedSecond;
            AppointmentRecurrenceEditor.Localization.The = Owner.Localization.AdvancedThe;
            AppointmentRecurrenceEditor.Localization.Third = Owner.Localization.AdvancedThird;
            AppointmentRecurrenceEditor.Localization.Weekly = Owner.Localization.AdvancedWeekly;
            AppointmentRecurrenceEditor.Localization.Weeks = Owner.Localization.AdvancedWeeks;
            AppointmentRecurrenceEditor.Localization.Yearly = Owner.Localization.AdvancedYearly;
    
           	SharedCalendar.FastNavigationSettings.OkButtonCaption = Owner.Localization.AdvancedCalendarOK;
			SharedCalendar.FastNavigationSettings.CancelButtonCaption = Owner.Localization.AdvancedCalendarCancel;
			SharedCalendar.FastNavigationSettings.TodayButtonCaption = Owner.Localization.AdvancedCalendarToday;
		}

        private void InitializeSubjectControl()
        {
            SubjectText.DataTextField = "Value";
            SubjectText.DataValueField = "Key";
            SubjectText.DataSource = M2MDataCenter.GetShiftSelectList(false);
            SubjectText.DataBind();
        }

        private void InitializeRecurrenceEditor()
        {
            AppointmentRecurrenceEditor.SharedCalendar = SharedCalendar;
            AppointmentRecurrenceEditor.Culture = Owner.Culture;
            AppointmentRecurrenceEditor.StartDate = Appointment.Start;
            AppointmentRecurrenceEditor.EndDate = Appointment.End;
        }

		private void UpdateResetExceptionsVisibility()
		{
            // Render the reset exceptions checkbox when using web service binding
            if (string.IsNullOrEmpty(Owner.WebServiceSettings.Path))
            {
                ResetExceptions.Visible = false;
                RecurrenceRule rrule;
                if (RecurrenceRule.TryParse(Appointment.RecurrenceRule, out rrule))
                {
                    ResetExceptions.Visible = rrule.Exceptions.Count > 0;
                }
            }
		}

		private bool IsAllDayAppointment(Appointment appointment)
		{
			DateTime displayStart = Owner.UtcToDisplay(appointment.Start);
			DateTime displayEnd = Owner.UtcToDisplay(appointment.End);
			return displayStart.CompareTo(displayStart.Date) == 0 && displayEnd.CompareTo(displayEnd.Date) == 0;
		}

       	#endregion
	}
}