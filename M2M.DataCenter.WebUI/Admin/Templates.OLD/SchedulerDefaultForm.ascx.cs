using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

using M2M.DataCenter;

namespace SchedulerTemplatesCS
{
    public partial class SchedulerDefaultForm : UserControl
    {
        #region Private members

        private static readonly string[] DayOrdinalValues = { "1", "2", "3", "4", "-1" };

        private static readonly string[] DayMaskValues = { 
            ((int) RecurrenceDay.EveryDay).ToString(),
            ((int) RecurrenceDay.WeekDays).ToString(),
            ((int) RecurrenceDay.WeekendDays).ToString(),
            ((int) RecurrenceDay.Sunday).ToString(),
            ((int) RecurrenceDay.Monday).ToString(),
            ((int) RecurrenceDay.Tuesday).ToString(),
            ((int) RecurrenceDay.Wednesday).ToString(),
            ((int) RecurrenceDay.Thursday).ToString(),
            ((int) RecurrenceDay.Friday).ToString(),
            ((int) RecurrenceDay.Saturday).ToString() };

        private string[] DayOrdinalDescriptions;

        private string[] DayMaskDescriptions;

        private readonly string[] InvariantMonthNames;

        private bool FormInitialized
        {
            get
            {
                return (bool)(ViewState["FormInitialized"] ?? false);
            }

            set
            {
                ViewState["FormInitialized"] = value;
            }
        }

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
                SchedulerFormContainer container = (SchedulerFormContainer)BindingContainer;
                return container.Appointment;
            }
        }

        protected RecurrenceFrequency Frequency
        {
            get
            {
                if (RecurrentAppointment != null && RecurrentAppointment.Checked)
                {
                    if (RepeatFrequencyHourly != null && RepeatFrequencyHourly.Checked)
                    {
                        return RecurrenceFrequency.Hourly;
                    }

                    if (RepeatFrequencyDaily != null && RepeatFrequencyDaily.Checked)
                    {
                        return RecurrenceFrequency.Daily;
                    }

                    if (RepeatFrequencyWeekly != null && RepeatFrequencyWeekly.Checked)
                    {
                        return RecurrenceFrequency.Weekly;
                    }

                    if (RepeatFrequencyMonthly != null && RepeatFrequencyMonthly.Checked)
                    {
                        return RecurrenceFrequency.Monthly;
                    }

                    if (RepeatFrequencyYearly != null && RepeatFrequencyYearly.Checked)
                    {
                        return RecurrenceFrequency.Yearly;
                    }
                }

                return RecurrenceFrequency.None;
            }
        }

        protected int Interval
        {
            get
            {
                switch (Frequency)
                {
                    case RecurrenceFrequency.Hourly:
                        return int.Parse(HourlyRepeatInterval.Text);

                    case RecurrenceFrequency.Daily:
                        if (RepeatEveryNthDay.Checked)
                        {
                            return int.Parse(DailyRepeatInterval.Text);
                        }
                        break;

                    case RecurrenceFrequency.Weekly:
                        return int.Parse(WeeklyRepeatInterval.Text);

                    case RecurrenceFrequency.Monthly:
                        if (RepeatEveryNthMonthOnDate.Checked)
                        {
                            return int.Parse(MonthlyRepeatIntervalForDate.Text);
                        }

                        return int.Parse(MonthlyRepeatIntervalForGivenDay.Text);
                }

                return 0;
            }
        }

        protected RecurrenceDay DaysOfWeekMask
        {
            get
            {
                switch (Frequency)
                {
                    case RecurrenceFrequency.Daily:
                        return (RepeatEveryWeekday.Checked) ? RecurrenceDay.WeekDays : RecurrenceDay.EveryDay;

                    case RecurrenceFrequency.Weekly:
                        RecurrenceDay finalMask = RecurrenceDay.None;
                        finalMask |= WeeklyWeekDayMonday.Checked ? RecurrenceDay.Monday : finalMask;
                        finalMask |= WeeklyWeekDayTuesday.Checked ? RecurrenceDay.Tuesday : finalMask;
                        finalMask |= WeeklyWeekDayWednesday.Checked ? RecurrenceDay.Wednesday : finalMask;
                        finalMask |= WeeklyWeekDayThursday.Checked ? RecurrenceDay.Thursday : finalMask;
                        finalMask |= WeeklyWeekDayFriday.Checked ? RecurrenceDay.Friday : finalMask;
                        finalMask |= WeeklyWeekDaySaturday.Checked ? RecurrenceDay.Saturday : finalMask;
                        finalMask |= WeeklyWeekDaySunday.Checked ? RecurrenceDay.Sunday : finalMask;

                        return finalMask;

                    case RecurrenceFrequency.Monthly:
                        if (RepeatEveryNthMonthOnGivenDay.Checked)
                        {
                            return (RecurrenceDay)Enum.Parse(typeof(RecurrenceDay), MonthlyDayMaskDropDown.SelectedValue);
                        }
                        break;

                    case RecurrenceFrequency.Yearly:
                        if (RepeatEveryYearOnGivenDay.Checked)
                        {
                            return (RecurrenceDay)Enum.Parse(typeof(RecurrenceDay), YearlyDayMaskDropDown.SelectedValue);
                        }
                        break;
                }

                return RecurrenceDay.None;
            }
        }

        protected int DayOfMonth
        {
            get
            {
                switch (Frequency)
                {
                    case RecurrenceFrequency.Monthly:
                        return (RepeatEveryNthMonthOnDate.Checked ? int.Parse(MonthlyRepeatDate.Text) : 0);

                    case RecurrenceFrequency.Yearly:
                        return (RepeatEveryYearOnDate.Checked ? int.Parse(YearlyRepeatDate.Text) : 0);
                }

                return 0;
            }
        }

        protected int DayOrdinal
        {
            get
            {
                switch (Frequency)
                {
                    case RecurrenceFrequency.Monthly:
                        if (RepeatEveryNthMonthOnGivenDay.Checked)
                        {
                            return int.Parse(MonthlyDayOrdinalDropDown.SelectedValue);
                        }
                        break;

                    case RecurrenceFrequency.Yearly:
                        if (RepeatEveryYearOnGivenDay.Checked)
                        {
                            return int.Parse(YearlyDayOrdinalDropDown.SelectedValue);
                        }
                        break;
                }

                return 0;
            }
        }

        protected RecurrenceMonth Month
        {
            get
            {
                if (Frequency == RecurrenceFrequency.Yearly)
                {
                    string selectedMonth;

                    if (RepeatEveryYearOnDate.Checked)
                    {
                        selectedMonth = YearlyRepeatMonthForDate.SelectedValue;
                    }
                    else
                    {
                        selectedMonth = YearlyRepeatMonthForGivenDay.SelectedValue;
                    }

                    return (RecurrenceMonth)Enum.Parse(typeof(RecurrenceMonth), selectedMonth);
                }

                return RecurrenceMonth.None;
            }
        }

        private RecurrencePattern Pattern
        {
            get
            {
                if (!RecurrentAppointment.Checked)
                {
                    return null;
                }

                RecurrencePattern submittedPattern = new RecurrencePattern();
                submittedPattern.Frequency = Frequency;
                submittedPattern.Interval = Interval;
                submittedPattern.DaysOfWeekMask = DaysOfWeekMask;
                submittedPattern.DayOfMonth = DayOfMonth;
                submittedPattern.DayOrdinal = DayOrdinal;
                submittedPattern.Month = Month;

                if (submittedPattern.Frequency == RecurrenceFrequency.Weekly)
                {
                    submittedPattern.FirstDayOfWeek = Owner.FirstDayOfWeek;
                }

                return submittedPattern;
            }
        }

        private RecurrenceRange Range
        {
            get
            {
                bool dateSpecified = StartDate.SelectedDate.HasValue && EndDate.SelectedDate.HasValue;
                bool timeSpecified = StartTime.SelectedDate.HasValue && EndTime.SelectedDate.HasValue;

                if ((AllDayEvent.Checked && !dateSpecified) ||
                    (!AllDayEvent.Checked && !(dateSpecified && timeSpecified)))
                {
                    return new RecurrenceRange();
                }

                DateTime startDate = StartDate.SelectedDate.Value.Date;
                DateTime endDate = EndDate.SelectedDate.Value.Date;

                if (AllDayEvent.Checked)
                {
                    startDate = startDate.Date;
                    endDate = endDate.Date.AddDays(1);
                }
                else
                {
                    TimeSpan startTime = StartTime.SelectedDate.Value.TimeOfDay;
                    startDate = startDate.Add(startTime);

                    TimeSpan endTime = EndTime.SelectedDate.Value.TimeOfDay;
                    endDate = endDate.Add(endTime);
                }

                startDate = Owner.DisplayToUtc(startDate);
                endDate = Owner.DisplayToUtc(endDate);

                RecurrenceRange range = new RecurrenceRange();
                range.Start = startDate;
                range.EventDuration = endDate - startDate;
                range.MaxOccurrences = 0;
                range.RecursUntil = DateTime.MaxValue;

                if (Owner.RecurrenceSupport)
                {
                    if (RepeatGivenOccurrences.Checked)
                    {
                        int maxOccurrences;
                        int.TryParse(RangeOccurrences.Text, out maxOccurrences);
                        range.MaxOccurrences = maxOccurrences;
                    }

                    if (RepeatUntilGivenDate.Checked && RangeEndDate.SelectedDate.HasValue)
                    {
                        range.RecursUntil = Owner.DisplayToUtc(RangeEndDate.SelectedDate.Value);

                        if (!AllDayEvent.Checked)
                        {
                            range.RecursUntil = range.RecursUntil.AddDays(1);
                        }
                    }
                }

                return range;
            }
        }

        #endregion


        #region Public properties

        [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
        public string Subject
        {
            get
            {
                return SelectedShift.Value;
            }

            set
            {
                SelectedShift.Value = value;
            }
        }

        [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
        public DateTime Start
        {
            get
            {
                return Range.Start;
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
                return Range.Start.Add(Range.EventDuration);
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
                    RecurrenceRule rrule = RecurrenceRule.FromPatternAndRange(Pattern, Range);

                    if (rrule == null)
                    {
                        return string.Empty;
                    }

                    RecurrenceRule originalRule;
                    if (RecurrenceRule.TryParse(OriginalRecurrenceRule.Value, out originalRule))
                    {
                        rrule.Exceptions = originalRule.Exceptions;
                    }

                    return rrule.ToString();
                }

                return string.Empty;
            }

            set
            {
                OriginalRecurrenceRule.Value = value;
            }
        }

        #endregion

        public SchedulerDefaultForm()
        {
            InvariantMonthNames = new string[12];
            Array.Copy(Enum.GetNames(typeof(RecurrenceMonth)), 1, InvariantMonthNames, 0, 12);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeStrings();

            if (!FormInitialized)
            {
                PopulateDescriptions();
                InitializeMonthlyRecurrenceControls();
                InitializeYearlyRecurrenceControls();
                InitializeShiftControl();
                PrefillRecurrenceControls();
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

            RepeatFrequencyHourly.Text = Owner.Localization.AdvancedHourly;
            RepeatFrequencyDaily.Text = Owner.Localization.AdvancedDaily;
            RepeatFrequencyWeekly.Text = Owner.Localization.AdvancedWeekly;
            RepeatFrequencyMonthly.Text = Owner.Localization.AdvancedMonthly;
            RepeatFrequencyYearly.Text = Owner.Localization.AdvancedYearly;

            HourlyRepeatIntervalValidator.ErrorMessage = Owner.Localization.AdvancedInvalidNumber;
            HourlyRepeatIntervalValidator.ValidationGroup = Owner.ValidationGroup;

            RepeatEveryNthDay.Text = Owner.Localization.AdvancedEvery;

            DailyRepeatIntervalValidator.ErrorMessage = Owner.Localization.AdvancedInvalidNumber;
            DailyRepeatIntervalValidator.ValidationGroup = Owner.ValidationGroup;

            RepeatEveryWeekday.Text = Owner.Localization.AdvancedEveryWeekday;

            WeeklyRepeatIntervalValidator.ErrorMessage = Owner.Localization.AdvancedInvalidNumber;
            WeeklyRepeatIntervalValidator.ValidationGroup = Owner.ValidationGroup;

            RepeatEveryNthMonthOnDate.Text = Owner.Localization.AdvancedDay;

            MonthlyRepeatDateValidator.ErrorMessage = Owner.Localization.AdvancedInvalidNumber;
            MonthlyRepeatDateValidator.ValidationGroup = Owner.ValidationGroup;

            MonthlyRepeatIntervalForDateValidator.ErrorMessage = Owner.Localization.AdvancedInvalidNumber;
            MonthlyRepeatIntervalForDateValidator.ValidationGroup = Owner.ValidationGroup;

            RepeatEveryNthMonthOnGivenDay.Text = Owner.Localization.AdvancedThe;

            MonthlyRepeatIntervalForGivenDayValidator.ErrorMessage = Owner.Localization.AdvancedInvalidNumber;
            MonthlyRepeatIntervalForGivenDayValidator.ValidationGroup = Owner.ValidationGroup;

            RepeatEveryYearOnDate.Text = Owner.Localization.AdvancedEvery;

            YearlyRepeatDateValidator.ErrorMessage = Owner.Localization.AdvancedInvalidNumber;
            YearlyRepeatDateValidator.ValidationGroup = Owner.ValidationGroup;

            RepeatEveryYearOnGivenDay.Text = Owner.Localization.AdvancedThe;

            RepeatIndefinitely.Text = Owner.Localization.AdvancedNoEndDate;

            RepeatGivenOccurrences.Text = Owner.Localization.AdvancedEndAfter;

            RangeOccurrencesValidator.ErrorMessage = Owner.Localization.AdvancedInvalidNumber;
            RangeOccurrencesValidator.ValidationGroup = Owner.ValidationGroup;

            RepeatUntilGivenDate.Text = Owner.Localization.AdvancedEndByThisDate;

            SharedCalendar.FastNavigationSettings.OkButtonCaption = Owner.Localization.AdvancedCalendarOK;
            SharedCalendar.FastNavigationSettings.CancelButtonCaption = Owner.Localization.AdvancedCalendarCancel;
            SharedCalendar.FastNavigationSettings.TodayButtonCaption = Owner.Localization.AdvancedCalendarToday;

            WeeklyWeekDayMonday.Text = Owner.Culture.DateTimeFormat.DayNames[1];
            WeeklyWeekDayTuesday.Text = Owner.Culture.DateTimeFormat.DayNames[2];
            WeeklyWeekDayWednesday.Text = Owner.Culture.DateTimeFormat.DayNames[3];
            WeeklyWeekDayThursday.Text = Owner.Culture.DateTimeFormat.DayNames[4];
            WeeklyWeekDayFriday.Text = Owner.Culture.DateTimeFormat.DayNames[5];
            WeeklyWeekDaySaturday.Text = Owner.Culture.DateTimeFormat.DayNames[6];
            WeeklyWeekDaySunday.Text = Owner.Culture.DateTimeFormat.DayNames[0];
        }

        private void UpdateResetExceptionsVisibility()
        {
            ResetExceptions.Visible = false;
            RecurrenceRule rrule;
            if (RecurrenceRule.TryParse(Appointment.RecurrenceRule, out rrule))
            {
                ResetExceptions.Visible = rrule.Exceptions.Count > 0;
            }
        }

        protected void ResetExceptions_OnClick(object sender, EventArgs e)
        {
            Owner.RemoveRecurrenceExceptions(Appointment);
            OriginalRecurrenceRule.Value = Appointment.RecurrenceRule;
            ResetExceptions.Text = Owner.Localization.AdvancedDone;
        }

        protected void BasicControlsPanel_DataBinding(object sender, EventArgs e)
        {
            AllDayEvent.Checked = IsAllDayAppointment(Appointment);
        }

        protected void RecurrencePatternPanel_DataBinding(object sender, EventArgs e)
        {
            RecurrenceRule rrule;
            if (!RecurrenceRule.TryParse(OriginalRecurrenceRule.Value, out rrule))
            {
                RecurrentAppointment.Checked = false;
                return;
            }

            RecurrentAppointment.Checked = true;

            string interval = rrule.Pattern.Interval.ToString();
            int mask = (int)rrule.Pattern.DaysOfWeekMask;

            switch (rrule.Pattern.Frequency)
            {
                case RecurrenceFrequency.Hourly:
                    RepeatFrequencyHourly.Checked = true;
                    HourlyRepeatInterval.Text = interval;
                    break;

                case RecurrenceFrequency.Daily:
                    RepeatFrequencyDaily.Checked = true;

                    if (rrule.Pattern.DaysOfWeekMask == RecurrenceDay.WeekDays)
                    {
                        RepeatEveryWeekday.Checked = true;
                        RepeatEveryNthDay.Checked = false;
                    }
                    else
                    {
                        RepeatEveryWeekday.Checked = false;
                        RepeatEveryNthDay.Checked = true;
                        DailyRepeatInterval.Text = interval;
                    }
                    break;

                case RecurrenceFrequency.Weekly:
                    RepeatFrequencyWeekly.Checked = true;

                    WeeklyRepeatInterval.Text = interval;

                    WeeklyWeekDayMonday.Checked = (RecurrenceDay.Monday & rrule.Pattern.DaysOfWeekMask) == RecurrenceDay.Monday;
                    WeeklyWeekDayTuesday.Checked = (RecurrenceDay.Tuesday & rrule.Pattern.DaysOfWeekMask) == RecurrenceDay.Tuesday;
                    WeeklyWeekDayWednesday.Checked = (RecurrenceDay.Wednesday & rrule.Pattern.DaysOfWeekMask) == RecurrenceDay.Wednesday;
                    WeeklyWeekDayThursday.Checked = (RecurrenceDay.Thursday & rrule.Pattern.DaysOfWeekMask) == RecurrenceDay.Thursday;
                    WeeklyWeekDayFriday.Checked = (RecurrenceDay.Friday & rrule.Pattern.DaysOfWeekMask) == RecurrenceDay.Friday;
                    WeeklyWeekDaySaturday.Checked = (RecurrenceDay.Saturday & rrule.Pattern.DaysOfWeekMask) == RecurrenceDay.Saturday;
                    WeeklyWeekDaySunday.Checked = (RecurrenceDay.Sunday & rrule.Pattern.DaysOfWeekMask) == RecurrenceDay.Sunday;
                    break;

                case RecurrenceFrequency.Monthly:
                    RepeatFrequencyMonthly.Checked = true;

                    if (0 < rrule.Pattern.DayOfMonth)
                    {
                        RepeatEveryNthMonthOnDate.Checked = true;
                        RepeatEveryNthMonthOnGivenDay.Checked = false;
                        MonthlyRepeatDate.Text = rrule.Pattern.DayOfMonth.ToString();
                        MonthlyRepeatIntervalForDate.Text = interval;
                    }
                    else
                    {
                        RepeatEveryNthMonthOnDate.Checked = false;
                        RepeatEveryNthMonthOnGivenDay.Checked = true;
                        MonthlyDayOrdinalDropDown.SelectedValue = rrule.Pattern.DayOrdinal.ToString();
                        MonthlyDayMaskDropDown.SelectedIndex = Array.IndexOf(DayMaskValues, (mask).ToString());
                        MonthlyRepeatIntervalForGivenDay.Text = interval;
                    }
                    break;

                case RecurrenceFrequency.Yearly:
                    RepeatFrequencyYearly.Checked = true;

                    if (0 < rrule.Pattern.DayOfMonth)
                    {
                        RepeatEveryYearOnDate.Checked = true;
                        RepeatEveryYearOnGivenDay.Checked = false;
                        YearlyRepeatDate.Text = rrule.Pattern.DayOfMonth.ToString();
                        YearlyRepeatMonthForDate.SelectedIndex = ((int)rrule.Pattern.Month) - 1;
                    }
                    else
                    {
                        RepeatEveryYearOnDate.Checked = false;
                        RepeatEveryYearOnGivenDay.Checked = true;
                        YearlyDayOrdinalDropDown.SelectedValue = rrule.Pattern.DayOrdinal.ToString();
                        YearlyDayMaskDropDown.SelectedIndex = Array.IndexOf(DayMaskValues, (mask).ToString());
                        YearlyRepeatMonthForGivenDay.SelectedIndex = ((int)rrule.Pattern.Month) - 1;
                    }
                    break;
            }
        }

        protected void RecurrenceRangePanel_DataBinding(object sender, EventArgs e)
        {
            RecurrenceRule rrule;
            if (!RecurrenceRule.TryParse(OriginalRecurrenceRule.Value, out rrule))
            {
                return;
            }

            bool occurrencesLimit = (rrule.Range.MaxOccurrences != int.MaxValue);
            bool timeLimit = (rrule.Range.RecursUntil != DateTime.MaxValue);

            if (!occurrencesLimit && !timeLimit)
            {
                RepeatIndefinitely.Checked = true;
                RepeatGivenOccurrences.Checked = false;
                RepeatUntilGivenDate.Checked = false;
            }
            else
                if (occurrencesLimit)
                {
                    RepeatIndefinitely.Checked = false;
                    RepeatGivenOccurrences.Checked = true;
                    RepeatUntilGivenDate.Checked = false;

                    RangeOccurrences.Text = rrule.Range.MaxOccurrences.ToString();
                }
                else
                {
                    RepeatIndefinitely.Checked = false;
                    RepeatGivenOccurrences.Checked = false;
                    RepeatUntilGivenDate.Checked = true;

                    RangeEndDate.SelectedDate = Owner.UtcToDisplay(rrule.Range.RecursUntil).AddDays(-1);
                }
        }

        protected void DurationValidator_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Range.EventDuration > TimeSpan.Zero;
        }


        private void PopulateDescriptions()
        {
            DayOrdinalDescriptions = new string[5];
            DayOrdinalDescriptions[0] = Owner.Localization.AdvancedFirst;
            DayOrdinalDescriptions[1] = Owner.Localization.AdvancedSecond;
            DayOrdinalDescriptions[2] = Owner.Localization.AdvancedThird;
            DayOrdinalDescriptions[3] = Owner.Localization.AdvancedFourth;
            DayOrdinalDescriptions[4] = Owner.Localization.AdvancedLast;

            DayMaskDescriptions = new string[10];
            DayMaskDescriptions[0] = Owner.Localization.AdvancedMaskDay;
            DayMaskDescriptions[1] = Owner.Localization.AdvancedMaskWeekday;
            DayMaskDescriptions[2] = Owner.Localization.AdvancedMaskWeekendDay;
            Array.Copy(Owner.Culture.DateTimeFormat.DayNames, 0, DayMaskDescriptions, 3, 7);
        }

        private void InitializeMonthlyRecurrenceControls()
        {
            MonthlyDayOrdinalDropDown.Items.AddRange(CreateListItemArray(DayOrdinalDescriptions, DayOrdinalValues));
            MonthlyDayMaskDropDown.Items.AddRange(CreateListItemArray(DayMaskDescriptions, DayMaskValues));
        }

        private void InitializeYearlyRecurrenceControls()
        {
            string[] monthNames = new string[12];
            Array.Copy(Owner.Culture.DateTimeFormat.MonthNames, monthNames, 12);

            YearlyRepeatMonthForDate.Items.AddRange(CreateListItemArray(monthNames, InvariantMonthNames));

            YearlyDayOrdinalDropDown.Items.AddRange(CreateListItemArray(DayOrdinalDescriptions, DayOrdinalValues));
            YearlyDayMaskDropDown.Items.AddRange(CreateListItemArray(DayMaskDescriptions, DayMaskValues));

            YearlyRepeatMonthForGivenDay.Items.AddRange(CreateListItemArray(monthNames, InvariantMonthNames));
        }

        private void InitializeShiftControl()
        {
            //ddl.AutoPostBack = true;
            //ddl.SelectedIndexChanged += new EventHandler(ddl_SelectedIndexChanged);
            // ddl.Attributes.Add("onchange", "LocationChange();");   

            //ProductionShifts.AutoPostBack = true;
            ProductionShifts.Attributes["onChange"] = Owner.ClientID + "_onShiftChanged(this.options(this.selectedIndex));";
            ProductionShifts.DataTextField = "Value";
            ProductionShifts.DataValueField = "Key";
            ProductionShifts.DataSource = EnumHelper.ToList(typeof(ShiftType));
            ProductionShifts.DataBind();
        }

        private static ListItem[] CreateListItemArray(string[] descriptions)
        {
            ListItem[] listItems = new ListItem[descriptions.Length];

            for (int i = 0; i < descriptions.Length; i++)
            {
                listItems[i] = new ListItem(descriptions[i]);
            }

            return listItems;
        }

        private static ListItem[] CreateListItemArray(string[] descriptions, string[] values)
        {
            if (descriptions.Length != values.Length)
            {
                throw new InvalidOperationException("There must be equal number of values and descriptions.");
            }

            ListItem[] listItems = CreateListItemArray(descriptions);

            for (int i = 0; i < values.Length; i++)
            {
                listItems[i].Value = values[i];
            }

            return listItems;
        }

        private bool IsAllDayAppointment(Appointment appointment)
        {
            DateTime displayStart = Owner.UtcToDisplay(appointment.Start);
            DateTime displayEnd = Owner.UtcToDisplay(appointment.End);
            return displayStart.CompareTo(displayStart.Date) == 0 && displayEnd.CompareTo(displayEnd.Date) == 0;
        }

        private void PrefillRecurrenceControls()
        {
            DateTime start = Appointment.Start;

            switch (start.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    WeeklyWeekDaySunday.Checked = true;
                    break;

                case DayOfWeek.Monday:
                    WeeklyWeekDayMonday.Checked = true;
                    break;

                case DayOfWeek.Tuesday:
                    WeeklyWeekDayTuesday.Checked = true;
                    break;

                case DayOfWeek.Wednesday:
                    WeeklyWeekDayWednesday.Checked = true;
                    break;

                case DayOfWeek.Thursday:
                    WeeklyWeekDayThursday.Checked = true;
                    break;

                case DayOfWeek.Friday:
                    WeeklyWeekDayFriday.Checked = true;
                    break;

                case DayOfWeek.Saturday:
                    WeeklyWeekDaySaturday.Checked = true;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            MonthlyRepeatDate.Text = start.Day.ToString();

            YearlyRepeatMonthForDate.SelectedValue = InvariantMonthNames[start.Month - 1];
            YearlyRepeatMonthForGivenDay.SelectedValue = YearlyRepeatMonthForDate.SelectedValue;
            YearlyRepeatDate.Text = start.Day.ToString();
        }

        protected void ProductionShifts_PreRender(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(SelectedShift.Value))
                SelectedShift.Value = EnumHelper.GetDescription(ShiftType.NotDefined);

            ProductionShifts.ClearSelection();
            ProductionShifts.Items.FindByText(SelectedShift.Value).Selected = true;

            //CommitButton.Style["display"] = (SelectedShift.Value == EnumHelper.GetDescription(ShiftType.NotDefined)) ? "none" : "inline";
        }
    }
}