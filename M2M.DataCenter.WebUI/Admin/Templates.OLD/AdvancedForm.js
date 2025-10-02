Sys.Application.add_init(function() {
    (function() {

        var $ = $telerik.$;
        var $T = Telerik.Web.UI;
        var $DateTime;
        if ($T.Scheduler != null) {
            $DateTime = $T.Scheduler.DateTime;
        }
        var timePerMinute = 60000;
        var timePerHour = timePerMinute * 60;
        var timePerDay = timePerHour * 24;


        window.SchedulerAdvancedTemplate = function(schedulerElement, formElement) {
            this._scheduler = $find(schedulerElement.id);
            this._schedulerElement = schedulerElement;
            this._formElement = formElement;
            this._schedulerElementId = this._schedulerElement.id;

            // We need to obtain the ID of the naming container that
            // contains the advanced template. We can find it from
            // the ID of a known element hosted in the form,
            // such as BasicControlsPanel.
            var basicControlsPanel = $("div.rsAdvBasicControls", formElement);
            if (basicControlsPanel.length == 0)
                return;

            var basicControlsPanelId = basicControlsPanel[0].id;
            this._templateId = basicControlsPanelId.substring(0, basicControlsPanelId.lastIndexOf("_"));
        };

        window.SchedulerAdvancedTemplate._adjustHeight = function(schedulerElement) {
            // Stretches the rsAdvOptions div to the available height.
            var advancedEditDiv = $("div.rsAdvancedEdit:visible", schedulerElement);
            var advancedEditDivBorder = advancedEditDiv.outerHeight() - advancedEditDiv.height();

            var buttonsDiv = $("div.rsAdvancedSubmitArea", advancedEditDiv);
            var buttonsHeight = buttonsDiv.outerHeight({ margin: true });

            var targetHeight = $(schedulerElement).height() - buttonsHeight - advancedEditDivBorder;

            $(".rsAdvOptionsScroll", advancedEditDiv).height(targetHeight + "px");

            // IE fix
            if (buttonsDiv[0])
                buttonsDiv[0].style.cssText = buttonsDiv[0].style.cssText;
        };

        window.SchedulerAdvancedTemplate.prototype =
{
    initialize: function() {
        var scheduler = this._scheduler;
        scheduler.add_disposing(Function.createDelegate(this, this.dispose));

        // Enable the buttons in the advanced form
        $("div.rsAdvancedSubmitArea a", this._formElement).attr("onclick", "");

        if (scheduler.get_overflowBehavior() == 1)
            window.SchedulerAdvancedTemplate._adjustHeight(this._schedulerElement);

        this._initializePickers();
        this._initializeAdvancedFormValidators();
        this._initializeAllDayCheckbox();

        var recurrenceSupport = $("#" + this._templateId + "_RecurrencePanel").length > 0;
        if (recurrenceSupport) {
            this._initializeRecurrenceCheckbox();
            this._initializeResetExceptions();
            this._initializeRecurrenceRadioButtons();
            this._initializeLinkedRecurrenceControls();
        }

        //    if ($telerik.isIE) {
        //        var textarea = $("div.textareaWrapper textarea", this._formElement)[0];

        //        textarea.style.cssText = textarea.style.cssText;
        //    }
    },

    dispose: function() {
        if (!this._formElement)
            return;

        $("*", this._formElement).unbind();

        this._pickers = null;
        this._scheduler = null;
        this._schedulerElement = null;
        this._formElement = null;
    },

    // The populate function is needed only when using Web Service data binding.
    populate: function(apt, isInsert, editSeries) {
        if (!this._clientMode)
            this._initializeClientMode();

        this._appointment = apt;
        this._isInsert = isInsert;
        this._editSeries = editSeries;

        var isAllDay =
            $DateTime.getTimeOfDay(apt.get_start()) == 0 &&
            $DateTime.getTimeOfDay(apt.get_end()) == 0;

        var aptEndDate = $DateTime.getDate(apt.get_end());
        if (isAllDay)
            aptEndDate = $DateTime.add(aptEndDate, -timePerDay);

        this._getSubjectTextBox().value = apt.get_subject();
        this._pickers.startDate.set_selectedDate($DateTime.getDate(apt.get_start()));
        this._pickers.startTime.set_selectedDate(apt.get_start());
        this._pickers.endDate.set_selectedDate(aptEndDate);
        this._pickers.endTime.set_selectedDate(apt.get_end());

        this._populateResources();
        this._populateAttributes();

        this._initalizeResetExceptionsClientMode();

        var allDayCheckBox = $("#" + this._templateId + "_AllDayEvent");
        if (isAllDay != allDayCheckBox[0].checked) {
            allDayCheckBox[0].checked = isAllDay;
            this._onAllDayCheckBoxClick(isAllDay, false);
        }

        this._populateRecurrence();
    },

    _initializeClientMode: function() {
        this._clientMode = true;
        var template = this;

        $("a.rsAdvEditSave", this._formElement)
            .click(function(e) {
                template._saveClicked();
                $telerik.cancelRawEvent(e);
            })
            .attr("href", "#");

        $("a.rsAdvEditCancel", this._formElement)
            .click(function(e) {
                template._cancelClicked();
                $telerik.cancelRawEvent(e);
            })
            .attr("href", "#");
    },

    _initalizeResetExceptionsClientMode: function() {
        var resetExceptions = $("span.rsAdvResetExceptions > a", this._formElement);
        var hasExceptions = this._appointment.get_recurrenceRule().indexOf("EXDATE") != -1;

        resetExceptions.unbind();

        if (hasExceptions) {
            var template = this;
            var localization = this._scheduler.get_localization();
            resetExceptions
                .attr("href", "#")
                .text(localization.AdvancedReset)
                .click(function() {
                    // Display confirmation dialog
                    template._getRemoveExceptionsDialog()
                        .set_onActionConfirm(function() {
                            // The user has confirmed - proceed
                            template._scheduler.removeRecurrenceExceptions(template._appointment);
                            resetExceptions.text(localization.AdvancedDone);
                        })
                        .show();

                    return false;
                });
        }
        else {
            resetExceptions.text("");
        }
    },

    _saveClicked: function() {
        var validationGroup = this._scheduler._validationGroup + (this._isInsert ? "Insert" : "Edit");
        if (!Page_ClientValidate(validationGroup))
            return;

        var apt = this._appointment;
        if (!this._isInsert)
            apt = this._scheduler.prepareToEdit(apt, this._editSeries);

        apt.set_subject(this._getSubjectTextBox().value);

        var isAllDay = $get(this._templateId + "_AllDayEvent").checked;

        var startDate = this._pickers.startDate.get_selectedDate();
        var startTime = $DateTime.getTimeOfDay(this._pickers.startTime.get_selectedDate());
        apt.set_start($DateTime.add(startDate, isAllDay ? 0 : startTime));

        var endDate = this._pickers.endDate.get_selectedDate();
        var endTime = $DateTime.getTimeOfDay(this._pickers.endTime.get_selectedDate());
        apt.set_end($DateTime.add(endDate, isAllDay ? timePerDay : endTime));

        this._saveResources(apt);
        this._saveAttributes(apt);

        this._saveRecurrenceRule(apt);

        if (this._isInsert)
            this._scheduler.insertAppointment(apt);
        else
            this._scheduler.updateAppointment(apt);

        this._scheduler.hideAdvancedForm();
    },

    _cancelClicked: function() {
        this._scheduler.hideAdvancedForm();
    },

    _saveResources: function(apt) {
        var template = this;
        var schedulerResources = this._scheduler.get_resources();

        $.each(schedulerResources._getResourceTypes(), function() {
            var resourceType = this;
            var dropDown = $get(template._templateId + "_Res" + resourceType);

            if (!dropDown)
                return;

            apt.get_resources().getResourcesByType(resourceType)
                    .forEach(function(oldRes) {
                        apt.get_resources().remove(oldRes);
                    });

            var newResource;

            if (dropDown.selectedIndex >= 0) {
                var selectedValue = dropDown.options[dropDown.selectedIndex].value;
                newResource = schedulerResources.findAll(function(res) {
                    return res.get_type() == resourceType &&
                           res._getInternalKey() == selectedValue;
                }).getResource(0) || null;
            }

            if (newResource)
                apt.get_resources().add(newResource);
        });
    },

    _saveAttributes: function(apt) {
        var template = this;
        var aptAttributes = apt.get_attributes();
        $.each(this._scheduler.get_customAttributeNames(), function() {
            var attrName = this.toString();
            var textBox = $get(template._templateId + "_Attr" + attrName);
            if (!textBox)
                return;

            aptAttributes.removeAttribute(attrName);
            aptAttributes.setAttribute(attrName, textBox.value);
        });
    },

    _populateResources: function() {
        var template = this;

        this._scheduler.get_resources().forEach(function(res) {
            var dropDown = $get(template._templateId + "_Res" + res.get_type());
            if (!dropDown)
                return;

            dropDown.selectedIndex = 0;
        });

        this._appointment.get_resources().forEach(function(res) {
            var dropDown = $get(template._templateId + "_Res" + res.get_type());
            if (!dropDown)
                return;

            template._selectDropDownValue(dropDown, res._getInternalKey());
        });
    },

    _saveRecurrenceRule: function(apt) {
        var rrule = $T.RecurrenceRule.fromPatternAndRange(this._getPattern(), this._getRange(apt));
        if (!rrule) {
            apt.set_recurrenceRule("");
            return;
        }

        // Restore the original recurrence exceptions if the
        // appointment was already recurring.
        var originalRRule = $T.RecurrenceRule.parse(apt.get_recurrenceRule());
        if (originalRRule)
            Array.addRange(rrule.get_exceptions(), originalRRule.get_exceptions());

        apt.set_recurrenceRule(rrule.toString());
    },

    _populateAttributes: function() {
        var template = this;
        this._appointment.get_attributes().forEach(function(attr, attrValue) {
            var textBox = $get(template._templateId + "_Attr" + attr);
            if (!textBox)
                return;

            textBox.value = attrValue;
        });
    },

    _populateRecurrence: function() {
        var isRecurring = this._appointment.get_recurrenceRule() != "";
        this._getRecurrentCheckBox().checked = isRecurring;

        var recurrencePanel = $("#" + this._templateId + "_RecurrencePanel");
        if (!isRecurring) {
            recurrencePanel.hide();
            return;
        }

        var rrule = $T.RecurrenceRule.parse(this._appointment.get_recurrenceRule());
        if (!rrule) {
            recurrencePanel.hide();
            this._getRecurrentCheckBox().checked = false;
            return;
        }

        var pattern = rrule.get_pattern();
        var interval = pattern.get_interval().toString();
        var mask = pattern.get_daysOfWeekMask();

        switch (pattern.get_frequency()) {
            case $T.RecurrenceFrequency.Hourly:
                this._getElement("RepeatFrequencyHourly").checked = true;
                this._getElement("HourlyRepeatInterval").value = interval;
                break;

            case $T.RecurrenceFrequency.Daily:
                this._getElement("RepeatFrequencyDaily").checked = true;

                if (pattern.get_daysOfWeekMask() == $T.RecurrenceDay.WeekDays) {
                    this._getElement("RepeatEveryWeekday").checked = true;
                    this._getElement("RepeatEveryNthDay").checked = false;
                }
                else {
                    this._getElement("RepeatEveryWeekday").checked = false;
                    this._getElement("RepeatEveryNthDay").checked = true;
                    this._getElement("DailyRepeatInterval").value = interval;
                }
                break;

            case $T.RecurrenceFrequency.Weekly:
                this._getElement("RepeatFrequencyWeekly").checked = true;
                this._getElement("WeeklyRepeatInterval").value = interval;

                this._getElement("WeeklyWeekDayMonday").checked = ($T.RecurrenceDay.Monday & mask) == $T.RecurrenceDay.Monday;
                this._getElement("WeeklyWeekDayTuesday").checked = ($T.RecurrenceDay.Tuesday & mask) == $T.RecurrenceDay.Tuesday;
                this._getElement("WeeklyWeekDayWednesday").checked = ($T.RecurrenceDay.Wednesday & mask) == $T.RecurrenceDay.Wednesday;
                this._getElement("WeeklyWeekDayThursday").checked = ($T.RecurrenceDay.Thursday & mask) == $T.RecurrenceDay.Thursday;
                this._getElement("WeeklyWeekDayFriday").checked = ($T.RecurrenceDay.Friday & mask) == $T.RecurrenceDay.Friday;
                this._getElement("WeeklyWeekDaySaturday").checked = ($T.RecurrenceDay.Saturday & mask) == $T.RecurrenceDay.Saturday;
                this._getElement("WeeklyWeekDaySunday").checked = ($T.RecurrenceDay.Sunday & mask) == $T.RecurrenceDay.Sunday;
                break;

            case $T.RecurrenceFrequency.Monthly:
                this._getElement("RepeatFrequencyMonthly").checked = true;

                if (0 < pattern.get_dayOfMonth()) {
                    this._getElement("RepeatEveryNthMonthOnDate").checked = true;
                    this._getElement("RepeatEveryNthMonthOnGivenDay").checked = false;
                    this._getElement("MonthlyRepeatDate").value = pattern.get_dayOfMonth();
                    this._getElement("MonthlyRepeatIntervalForDate").value = interval;
                }
                else {
                    this._getElement("RepeatEveryNthMonthOnDate").checked = false;
                    this._getElement("RepeatEveryNthMonthOnGivenDay").checked = true;
                    this._selectDropDownValue(this._getElement("MonthlyDayOrdinalDropDown"), pattern.get_dayOrdinal());
                    this._selectDropDownValue(this._getElement("MonthlyDayMaskDropDown"), mask.toString());
                    this._getElement("MonthlyRepeatIntervalForGivenDay").value = interval;
                }
                break;

            case $T.RecurrenceFrequency.Yearly:
                this._getElement("RepeatFrequencyYearly").checked = true;

                if (0 < pattern.get_dayOfMonth()) {
                    this._getElement("RepeatEveryYearOnDate").checked = true;
                    this._getElement("RepeatEveryYearOnGivenDay").checked = false;
                    this._getElement("YearlyRepeatDate").value = pattern.get_dayOfMonth();
                    this._selectDropDownValue(this._getElement("YearlyRepeatMonthForDate"),
                            $T.RecurrenceMonth.toString(pattern.get_month()));
                }
                else {
                    this._getElement("RepeatEveryYearOnDate").checked = false;
                    this._getElement("RepeatEveryYearOnGivenDay").checked = true;
                    this._selectDropDownValue(this._getElement("YearlyDayOrdinalDropDown"), pattern.get_dayOrdinal());
                    this._selectDropDownValue(this._getElement("YearlyDayMaskDropDown"), mask.toString());
                    this._selectDropDownValue(this._getElement("YearlyRepeatMonthForGivenDay"),
                            $T.RecurrenceMonth.toString(pattern.get_month()));
                }
                break;
        }

        this._populateRecurrenceRange(rrule.get_range());

        recurrencePanel.show();
    },

    _populateRecurrenceRange: function(range) {
        var occurrencesLimit = range.get_maxOccurrences() != maxInt;
        var timeLimit = range.get_recursUntil().getTime() != maxDate.getTime();

        if (!occurrencesLimit && !timeLimit) {
            this._getElement("RepeatIndefinitely").checked = true;
            this._getElement("RepeatGivenOccurrences").checked = false;
            this._getElement("RepeatUntilGivenDate").checked = false;
        }
        else {
            if (occurrencesLimit) {
                this._getElement("RepeatIndefinitely").checked = false;
                this._getElement("RepeatGivenOccurrences").checked = true;
                this._getElement("RepeatUntilGivenDate").checked = false;

                this._getElement("RangeOccurrences").value = range.get_maxOccurrences();
            }
            else {
                this._getElement("RepeatIndefinitely").checked = false;
                this._getElement("RepeatGivenOccurrences").checked = false;
                this._getElement("RepeatUntilGivenDate").checked = true;

                var recursUntil = this._scheduler.utcToDisplay(range.get_recursUntil());
                if (this._getElement("AllDayEvent").checked)
                    recursUntil = $DateTime.add(recursUntil, -timePerDay);

                this._pickers.rangeEndDate.set_selectedDate(recursUntil);
            }
        }
    },

    _selectDropDownValue: function(dropDown, value) {
        $.each(dropDown.options, function() {
            if (this.value == value) {
                this.selected = true;
                return false;
            }
        });
    },

    _getFrequency: function() {
        if (!this._getRecurrentCheckBox().checked)
            return $T.RecurrenceFrequency.None;

        if (this._getElement("RepeatFrequencyHourly").checked)
            return $T.RecurrenceFrequency.Hourly;

        if (this._getElement("RepeatFrequencyDaily").checked)
            return $T.RecurrenceFrequency.Daily;

        if (this._getElement("RepeatFrequencyWeekly").checked)
            return $T.RecurrenceFrequency.Weekly;

        if (this._getElement("RepeatFrequencyMonthly").checked)
            return $T.RecurrenceFrequency.Monthly;

        if (this._getElement("RepeatFrequencyYearly").checked)
            return $T.RecurrenceFrequency.Yearly;

        return $T.RecurrenceFrequency.None;
    },

    _getInterval: function() {
        switch (this._getFrequency()) {
            case $T.RecurrenceFrequency.Hourly:
                return parseInt(this._getElement("HourlyRepeatInterval").value);

            case $T.RecurrenceFrequency.Daily:
                if (this._getElement("RepeatEveryNthDay").checked)
                    return parseInt(this._getElement("DailyRepeatInterval").value);
                break;

            case $T.RecurrenceFrequency.Weekly:
                return parseInt(this._getElement("WeeklyRepeatInterval").value);

            case $T.RecurrenceFrequency.Monthly:
                if (this._getElement("RepeatEveryNthMonthOnDate").checked)
                    return parseInt(this._getElement("MonthlyRepeatIntervalForDate").value);
                else
                    return parseInt(this._getElement("MonthlyRepeatIntervalForGivenDay").value);
        }

        return 0;
    },

    _getDaysOfWeekMask: function() {
        switch (this._getFrequency()) {
            case $T.RecurrenceFrequency.Daily:
                return this._getElement("RepeatEveryWeekday").checked ?
                       $T.RecurrenceDay.WeekDays : $T.RecurrenceDay.EveryDay;

            case $T.RecurrenceFrequency.Weekly:
                var finalMask = $T.RecurrenceDay.None;
                finalMask |= this._getElement("WeeklyWeekDayMonday").checked ? $T.RecurrenceDay.Monday : finalMask;
                finalMask |= this._getElement("WeeklyWeekDayTuesday").checked ? $T.RecurrenceDay.Tuesday : finalMask;
                finalMask |= this._getElement("WeeklyWeekDayWednesday").checked ? $T.RecurrenceDay.Wednesday : finalMask;
                finalMask |= this._getElement("WeeklyWeekDayThursday").checked ? $T.RecurrenceDay.Thursday : finalMask;
                finalMask |= this._getElement("WeeklyWeekDayFriday").checked ? $T.RecurrenceDay.Friday : finalMask;
                finalMask |= this._getElement("WeeklyWeekDaySaturday").checked ? $T.RecurrenceDay.Saturday : finalMask;
                finalMask |= this._getElement("WeeklyWeekDaySunday").checked ? $T.RecurrenceDay.Sunday : finalMask;
                return finalMask;
                break;

            case $T.RecurrenceFrequency.Monthly:
                if (this._getElement("RepeatEveryNthMonthOnGivenDay").checked)
                    return parseInt(this._getElement("MonthlyDayMaskDropDown").value);
                break;

            case $T.RecurrenceFrequency.Yearly:
                if (this._getElement("RepeatEveryYearOnGivenDay").checked)
                    return parseInt(this._getElement("YearlyDayMaskDropDown").value);
                break;
        }

        return $T.RecurrenceDay.None;
    },

    _getDayOfMonth: function() {
        switch (this._getFrequency()) {
            case $T.RecurrenceFrequency.Monthly:
                return this._getElement("RepeatEveryNthMonthOnDate").checked ?
                       parseInt(this._getElement("MonthlyRepeatDate").value) : 0;

            case $T.RecurrenceFrequency.Yearly:
                return this._getElement("RepeatEveryYearOnDate").checked ?
                       parseInt(this._getElement("YearlyRepeatDate").value) : 0;
        }

        return 0;
    },

    _getDayOrdinal: function() {
        switch (this._getFrequency()) {
            case $T.RecurrenceFrequency.Monthly:
                if (this._getElement("RepeatEveryNthMonthOnGivenDay").checked)
                    return parseInt(this._getElement("MonthlyDayOrdinalDropDown").value);
                break;

            case $T.RecurrenceFrequency.Yearly:
                if (this._getElement("RepeatEveryYearOnGivenDay").checked)
                    return parseInt(this._getElement("YearlyDayOrdinalDropDown").value);
                break;
        }

        return 0;
    },

    _getMonth: function() {
        if (this._getFrequency() != $T.RecurrenceFrequency.Yearly)
            return $T.RecurrenceMonth.None;

        var selectedMonth;

        if (this._getElement("RepeatEveryYearOnDate").checked)
            selectedMonth = this._getElement("YearlyRepeatMonthForDate").value;
        else
            selectedMonth = this._getElement("YearlyRepeatMonthForGivenDay").value;

        return $T.RecurrenceMonth.parse(selectedMonth, true);
    },

    _getPattern: function() {
        if (!this._getRecurrentCheckBox() || !this._getRecurrentCheckBox().checked)
            return null;

        var pattern = new $T.RecurrencePattern();
        pattern.set_frequency(this._getFrequency());
        pattern.set_interval(this._getInterval());
        pattern.set_daysOfWeekMask(this._getDaysOfWeekMask());
        pattern.set_dayOfMonth(this._getDayOfMonth());
        pattern.set_dayOrdinal(this._getDayOrdinal());
        pattern.set_month(this._getMonth());

        if (pattern.get_frequency() == $T.RecurrenceFrequency.Weekly)
            pattern.set_firstDayOfWeek(this._scheduler.get_firstDayOfWeek());

        return pattern;
    },

    _getRange: function(apt) {
        if (!this._getRecurrentCheckBox() || !this._getRecurrentCheckBox().checked)
            return null;

        var startDate = this._scheduler.displayToUtc(apt.get_start());
        var endDate = this._scheduler.displayToUtc(apt.get_end());

        var range = new $T.RecurrenceRange();
        range.set_start(startDate);
        range.set_eventDuration($DateTime.subtract(endDate, startDate));
        range.set_maxOccurrences(0);
        range.set_recursUntil(maxDate);

        if (this._getElement("RepeatGivenOccurrences").checked) {
            var maxOccurrences = parseInt(this._getElement("RangeOccurrences").value);
            if (!isNaN(maxOccurrences))
                range.set_maxOccurrences(maxOccurrences);
        }

        if (this._getElement("RepeatUntilGivenDate").checked && !this._pickers.rangeEndDate.isEmpty()) {
            range.set_recursUntil(this._scheduler.displayToUtc(this._pickers.rangeEndDate.get_selectedDate()));

            if (!this._getElement("AllDayEvent").checked)
                range.set_recursUntil($DateTime.add(range.get_recursUntil(), timePerDay));
        }

        return range;
    },

    _getSubjectTextBox: function() {
        return $("div.textareaWrapper textarea", this._formElement)[0];
    },

    _getElement: function(id) {
        return $get(this._templateId + "_" + id);
    },

    _getRecurrentCheckBox: function() {
        return this._getElement("RecurrentAppointment");
    },

    _initializePickers: function() {
        // Show picker pop-ups when the inputs are focused

        var showPopupDelegate = Function.createDelegate(this, this._showPopup);

        var templateId = this._templateId;
        this._pickers =
		{
		    "startDate": $find(templateId + "_StartDate"),
		    "endDate": $find(templateId + "_EndDate"),
		    "rangeEndDate": $find(templateId + "_RangeEndDate"),
		    "startTime": $find(templateId + "_StartTime"),
		    "endTime": $find(templateId + "_EndTime")
		};

        $.each(
			this._pickers,
			function() {
			    if (this && this.get_dateInput)
			        this.get_dateInput().add_focus(showPopupDelegate);
			});


        var pickerControls = [
					$get(this._pickers.startDate.get_element().id + "_wrapper"),
					$get(this._pickers.startTime.get_element().id + "_wrapper"),
					$get(this._pickers.startTime.get_element().id + "_timeView_wrapper"),
					$get(this._pickers.endDate.get_element().id + "_wrapper"),
					$get(this._pickers.endTime.get_element().id + "_wrapper"),
					$get(this._pickers.endTime.get_element().id + "_timeView_wrapper"),
					$get(this._templateId + "_SharedCalendar")
				];

        // Might be null if recurrences are disabled
        if (this._pickers.rangeEndDate)
            Array.add(pickerControls, $get(this._pickers.rangeEndDate.get_element().id + "_wrapper"));


        // Hide the pickers when the focus moves to another element in the template
        var advancedTemplate = this;
        var eventName = "focusin";

        $(this._formElement).bind(eventName,
			function(e) {
			    var inPickerControls = false;
			    for (var i = 0, len = pickerControls.length; i < len; i++) {
			        var control = pickerControls[i];
			        if ($telerik.isDescendantOrSelf(control, e.target)) {
			            inPickerControls = true;
			            break;
			        }
			    }

			    if (!inPickerControls)
			        advancedTemplate._hidePickerPopups();
			});
    },

    _initializeAdvancedFormValidators: function() {
        var toolTip = this._createValidatorToolTip();

        if (!Page_Validators)
            return;

        for (var validatorIndex in Page_Validators) {
            var validator = Page_Validators[validatorIndex];
            if (this._validatorIsInTemplate(validator)) {
                var control = $("#" + validator.controltovalidate);
                if (control.length == 0)
                    break;

                if (control.parent().is(".rsAdvDatePicker") ||
					control.parent().is(".rsAdvTimePicker")) {
                    $("#" + validator.controltovalidate + "_dateInput_text")
						.bind("focus", { "toolTip": toolTip }, this._showToolTip)
						.bind("blur", { "toolTip": toolTip }, this._hideToolTip)
						[0].errorMessage = validator.errormessage;
                }
                else {
                    control.addClass("rsValidatedInput");
                }

                control[0].errorMessage = validator.errormessage;
                this._updateValidator(validator, control);
            }
        }

        var advancedTemplate = this;
        var originalValidatorUpdateDisplay = ValidatorUpdateDisplay;

        ValidatorUpdateDisplay = function(validator) {
            if (advancedTemplate._validatorIsInTemplate(validator) && validator.controltovalidate) {
                advancedTemplate._updateValidator(validator);
            }
            else {
                originalValidatorUpdateDisplay(validator);
            }
        };

        $(".rsValidatedInput", this._formElement)
			.bind("focus", { "toolTip": toolTip }, this._showToolTip)
			.bind("blur", { "toolTip": toolTip }, this._hideToolTip);
    },

    _initializeAllDayCheckbox: function() {
        var allDayCheckbox = $("#" + this._templateId + "_AllDayEvent");
        var controlList = $(allDayCheckbox[0].parentNode.parentNode.parentNode);
        var timePickers = controlList.find('.rsAdvTimePicker');

        if ($telerik.isSafari || $telerik.isOpera) {
            var datePickers = controlList.find('.rsAdvDatePicker');
            timePickers.add(datePickers).css("display", "inline-block");
        }

        var initialPickersWidth = $(".rsTimePick", this._formElement).eq(0).outerWidth();
        var allDayPickersWidth = initialPickersWidth - $("#" + this._templateId + "_StartTime_wrapper").outerWidth();

        var startTimeValidator = $get(this._templateId + "_StartTimeValidator");
        var endTimeValidator = $get(this._templateId + "_StartTimeValidator");

        var advancedTemplate = this;

        // IE fix - the hidden input pushes down the other TimePicker elements during animation
        controlList.find('.rsAdvTimePicker > input').css("display", "none");

        var clickHandler = function(allDay, animate) {
            var showTimePickers = function() {
                if ($telerik.isSafari || $telerik.isOpera)
                    timePickers.css("display", "inline-block");
                else
                    timePickers.show();
            };

            if (!allDay)
                showTimePickers();

            controlList.find('.rsTimePick').each(function() {
                if (animate) {
                    $(this).stop();

                    if (allDay)
                        $(this).animate({ width: allDayPickersWidth }, "slow",
							"linear", function() { timePickers.hide(); });
                    else
                        $(this).animate({ width: initialPickersWidth }, "slow");
                }
                else {
                    if (allDay) {
                        timePickers.hide();
                        $(this).width(allDayPickersWidth);
                    }
                    else {
                        $(this).width(initialPickersWidth);
                    }
                }
            });

            ValidatorEnable(startTimeValidator, !allDay);
            ValidatorEnable(endTimeValidator, !allDay);

            var startTimePicker = advancedTemplate._pickers.startTime;
            startTimePicker.set_enabled(!allDay);

            var endTimePicker = advancedTemplate._pickers.endTime;
            endTimePicker.set_enabled(!allDay);
        };

        this._onAllDayCheckBoxClick = clickHandler;

        clickHandler(allDayCheckbox[0].checked, false);
        allDayCheckbox.click(function() { clickHandler(this.checked, true); });
    },

    _initializeRecurrenceCheckbox: function() {
        var recurrencePanel = $("#" + this._templateId + "_RecurrencePanel");
        var recurrentAppointment = $("#" + this._templateId + "_RecurrentAppointment");
        if (recurrentAppointment[0].checked) {
            recurrencePanel.show();
        }

        recurrentAppointment
			.click(function() {
			    recurrencePanel.stop(false, true).animate({ height: "toggle" }, "slow");
			});
    },

    _initializeResetExceptions: function() {
        var resetExceptions = $("#" + this._templateId + "_ResetExceptions");
        if (resetExceptions.length == 0)
            return;

        var scheduler = this._scheduler;
        var template = this;
        var localization = scheduler.get_localization();
        var doneMessage = localization.AdvancedDone;
        if (resetExceptions[0].innerHTML.indexOf(doneMessage) > -1) {
            // Hide "Done" after 2 seconds
            resetExceptions.click(function() { return false; });
            window.setTimeout(function() { resetExceptions.fadeOut("slow"); }, 2000);
        }
        else {
            resetExceptions.click(
                function() {
                    // Display confirmation dialog
                    var dialog = template._getRemoveExceptionsDialog();
                    dialog.set_onActionConfirm(function() {
                        // The user has confirmed - proceed with postback
                        resetExceptions[0].innerHTML = localization.AdvancedWorking;
                        window.location.href = resetExceptions[0].href;

                        dialog.dispose();
                    })
                        .show();

                    return false;
                });
        }
    },

    _getRemoveExceptionsDialog: function() {
        var localization = this._scheduler.get_localization();
        return $telerik.$.modal(this._formElement)
            .initialize()
            .set_content({
                title: localization.ConfirmResetExceptionsTitle,
                content: localization.ConfirmResetExceptionsText,
                ok: localization.ConfirmOK,
                cancel: localization.ConfirmCancel
            });
    },

    _initializeRecurrenceRadioButtons: function() {
        var radioButtons = [
			$get(this._templateId + "_RepeatFrequencyHourly"),
			$get(this._templateId + "_RepeatFrequencyDaily"),
			$get(this._templateId + "_RepeatFrequencyWeekly"),
			$get(this._templateId + "_RepeatFrequencyMonthly"),
			$get(this._templateId + "_RepeatFrequencyYearly")];

        var recurrencePatternPanels = $("#" + this._templateId + "_RecurrencePatternPanel .rsAdvPatternPanel");

        var getCorrespondingPanel = function(button) {
            var targetId = button.value.replace("RepeatFrequency", "RecurrencePattern") + "Panel";
            return recurrencePatternPanels.filter("[id$='" + targetId + "']");
        };

        for (var i = 0, len = radioButtons.length; i < len; i++) {
            var button = radioButtons[i];

            if (button.checked) {
                // Show initially selected options panel without animation
                getCorrespondingPanel(button).show();
            }

            $(button)
				.click(function() {
				    var panel = $(getCorrespondingPanel(this));

				    if (panel.css("display") == "none") {
				        // Show the corresponding panel with animation
				        recurrencePatternPanels.hide();
				        panel.fadeIn("slow");
				    }
				});
        }
    },

    _initializeLinkedRecurrenceControls: function() {
        // Each radio button is listed with all of it's linked controls
        var controls = {};

        var id = this._templateId;
        var hid = "#" + id;

        controls[id + "_RepeatEveryNthDay"] = [
				$(hid + "_DailyRepeatInterval")];

        controls[id + "_RepeatEveryNthMonthOnDate"] = [
				$(hid + "_MonthlyRepeatDate"),
				$(hid + "_MonthlyRepeatIntervalForDate")];

        controls[id + "_RepeatEveryNthMonthOnGivenDay"] = [
				$(hid + "_MonthlyDayOrdinalDropDown"),
				$(hid + "_MonthlyDayMaskDropDown"),
				$(hid + "_MonthlyRepeatIntervalForGivenDay")];

        controls[id + "_RepeatEveryYearOnDate"] = [
				$(hid + "_YearlyRepeatMonthForDate"),
				$(hid + "_YearlyRepeatDate")];

        controls[id + "_RepeatEveryYearOnGivenDay"] = [
				$(hid + "_YearlyDayOrdinalDropDown"),
				$(hid + "_YearlyDayMaskDropDown"),
				$(hid + "_YearlyRepeatMonthForGivenDay")];

        controls[id + "_RepeatGivenOccurrences"] = [
				$(hid + "_RangeOccurrences")];

        controls[id + "_RepeatUntilGivenDate"] = [
				$(hid + "_RangeEndDate_dateInput_text")];


        // Attach event handlers, so:
        // 1. When a radio-button is clicked, the first of the linked controls will be focused.
        // 2. When a linked control is clicked, the radio-button will be checked.
        $.each(controls, function(radioId) {
            var radio = $("#" + radioId);
            var firstControl = controls[radioId][0];

            radio.click(function() {
                if (firstControl.css("visibility") == "hidden") {
                    var inputControl = $("#" + firstControl[0].id + "_text");
                    if (inputControl)
                        inputControl.focus();
                }
                else {
                    firstControl.focus();
                }
            });

            $.each(controls[radioId], function() {
                $(this).focus(function() {
                    radio[0].checked = true;
                });
            });
        });
    },

    _updateValidator: function(validator) {
        var control = $("#" + validator.controltovalidate);

        if (control.is("textarea"))
            control = control.parent();

        if (!validator.isvalid)
            control.addClass("rsInvalid");
        else
            control.removeClass("rsInvalid");
    },

    _validatorIsInTemplate: function(validator) {
        return $(validator).parents().is("#" + this._schedulerElementId);
    },

    _createValidatorToolTip: function() {
        return $('<div></div>').hide().appendTo("#" + this._schedulerElementId);
    },

    _showToolTip: function(e) {
        var toolTip = e.data.toolTip;
        var _control = $(this);
        var isTextArea = false;

        if (_control.is("textarea")) {
            isTextArea = true;
            _control = _control.parent();
        }

        var isInvalid = _control.is(".rsInvalid");
        // Date and time pickers are validated against a hidden input located one level up in the DOM
        isInvalid = isInvalid || _control.parent().parent().children().is(".rsInvalid");

        if (isInvalid) {
            toolTip
				.css("visibility", "hidden")
				.text(this.errorMessage)
				.addClass("rsValidatorTooltip");

            var schedulerOffset = $(_control).parents(".RadScheduler").offset();
            var pos = _control.offset();
            pos.left -= schedulerOffset.left;
            pos.top -= schedulerOffset.top;

            var toolTipLeft = pos.left + "px";

            if (isTextArea) {
                toolTipLeft = (pos.left + _control.outerWidth() - toolTip.outerWidth()) + "px";
            }

            var toolTipTop = (pos.top - toolTip.outerHeight()) + "px";
            toolTip
				.css({
				    top: toolTipTop,
				    left: toolTipLeft,
				    visibility: "visible"
				})
				.fadeIn("fast");
        }
    },

    _hideToolTip: function(e) {
        var toolTip = e.data.toolTip;
        toolTip.hide();
    },

    _hidePickerPopups: function() {
        if (!this._pickers)
            return;

        for (var pickerId in this._pickers) {
            var picker = this._pickers[pickerId];

            if (!picker)
                continue;

            if (picker.hideTimePopup)
                picker.hideTimePopup();
            else
                picker.hidePopup();
        }
    },

    _showPopup: function(sender) {
        this._hidePickerPopups();

        if (sender.Owner.showTimePopup)
            sender.Owner.showTimePopup();
        else
            sender.Owner.showPopup();
    }
};
    })()
});
