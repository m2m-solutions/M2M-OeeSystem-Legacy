<%@ Control Language="C#" AutoEventWireup="True" Inherits="SchedulerTemplatesCS.SchedulerDefaultForm" Codebehind="SchedulerDefaultForm.ascx.cs" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register src="ScriptBlock.ascx" tagname="ScriptBlock" tagprefix="scheduler" %>

<scheduler:ScriptBlock ID="ScriptBlock1" runat="server" >
<Content>
<script type="text/javascript">	
    //<![CDATA[
			
			function validateRange()
			{
				var startDatePicker = $find('<%= StartDate.ClientID %>');
				var startTimeInput = $find('<%= StartTime.ClientID %>');
				
				var startDate = startDatePicker.get_selectedDate();
				var startTime = startTimeInput.get_selectedDate();
				
				var startDateTime = new Date();
				startDateTime.setFullYear(startDate.getFullYear());
				startDateTime.setMonth(startDate.getMonth());
				startDateTime.setDate(startDate.getDate());
				startDateTime.setHours(startTime.getHours());
				startDateTime.setMinutes(startTime.getMinutes());
				
				var endDatePicker = $find('<%= EndDate.ClientID %>');
				var endTimeInput = $find('<%= EndTime.ClientID %>');
				
				var endDate = endDatePicker.get_selectedDate();
				var endTime = endTimeInput.get_selectedDate();
				
				var endDateTime = new Date();
				endDateTime.setFullYear(endDate.getFullYear());
				endDateTime.setMonth(endDate.getMonth());
				endDateTime.setDate(endDate.getDate());
				endDateTime.setHours(endTime.getHours());
				endDateTime.setMinutes(endTime.getMinutes());
				
				if(startDateTime > endDateTime)
				{
					return false
				}
				else
				{
					return true;
				}
			}
			
			function validateShift()
			{
				var productionShifts = $get('<%= ProductionShifts.ClientID %>');
				var selectedShift = productionShifts.options[productionShifts.selectedIndex].value;
				
				if(selectedShift == 'NotDefined')
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			
			function <%= Owner.ClientID %>_onShiftChanged(selectedItem)
			{
				var selectedShift = $get('<%= SelectedShift.ClientID %>');
				selectedShift.value = selectedItem.text;
				
				
			}
			
			
			
			function <%= Owner.ClientID %>_onRecurrentAppointmentClicked(sender)
			{
				var recurrencePatternPanel = $get('<%= RecurrencePatternPanel.ClientID %>');
				var recurrenceRangePanel = $get('<%= RecurrenceRangePanel.ClientID %>');
				
				if (sender.checked)
				{
					recurrencePatternPanel.style.display = 'block';
					recurrenceRangePanel.style.display = 'block';
					
					var schedulerElement = $find('<%= Owner.ClientID %>').get_element();  
					schedulerElement.style.height = "800px";  
					Telerik.Web.UI.RadScheduler._adjustHeight('<%= Owner.ClientID %>');  
  
				}
				else
				{
					recurrencePatternPanel.style.display = 'none';
					recurrenceRangePanel.style.display = 'none';
				}
			}
			
			function <%= Owner.ClientID %>_onAllDayEventClicked(sender)
			{
				var startTime = $find('<%= StartTime.ClientID %>');
				var endTime = $find('<%= EndTime.ClientID %>');

				if (sender.checked)
				{
					if (startTime)
					{
						startTime.disable();
					}
		            
					if (endTime)
					{
						endTime.disable();
					}
				}
				else
				{
					if (startTime)
					{
						startTime.enable();
					}
		            
					if (endTime)
					{
						endTime.enable();
					}
				}
			}

			function <%= Owner.ClientID %>_onRecurrenceFrequencyClicked(sender)
			{
				var recurrencePatternHourlyPanel = $get('<%= RecurrencePatternHourlyPanel.ClientID %>');
				var recurrencePatternDailyPanel = $get('<%= RecurrencePatternDailyPanel.ClientID %>');
				var recurrencePatternWeeklyPanel = $get('<%= RecurrencePatternWeeklyPanel.ClientID %>');
				var recurrencePatternMonthlyPanel = $get('<%= RecurrencePatternMonthlyPanel.ClientID %>');
				var recurrencePatternYearlyPanel = $get('<%= RecurrencePatternYearlyPanel.ClientID %>');

				recurrencePatternHourlyPanel.style.display = 'none';
				recurrencePatternDailyPanel.style.display = 'none';
				recurrencePatternWeeklyPanel.style.display = 'none';
				recurrencePatternMonthlyPanel.style.display = 'none';
				recurrencePatternYearlyPanel.style.display = 'none';

				switch (sender.value)
				{
					case "RepeatFrequencyHourly":
						recurrencePatternHourlyPanel.style.display = 'block';
						break;

					case "RepeatFrequencyDaily":
						recurrencePatternDailyPanel.style.display = 'block';
						break;

					case "RepeatFrequencyWeekly":
						recurrencePatternWeeklyPanel.style.display = 'block';
						break;

					case "RepeatFrequencyMonthly":
						recurrencePatternMonthlyPanel.style.display = 'block';
						break;

					case "RepeatFrequencyYearly":
						recurrencePatternYearlyPanel.style.display = 'block';
						break;
				}
			}
				
			function <%= Owner.ClientID %>_onGluedControlClick(controlId, radioId)
			{
				var radio = $get(radioId);
				radio.checked = true;
			}
				
			function <%= Owner.ClientID %>_onGluedRadioClick(controlId, radioId)
			{
				var control = $get(controlId);
				
				if (control.style.visibility == "hidden")
				{
					var inputControl = $get(controlId + "_text");
					if (inputControl)
					{
						inputControl.focus();
					}
				}
				else
				{
					control.focus();
				}
			}

			function <%= Owner.ClientID %>_onRangeEndDateOpening()
			{
				var repeatUntilGivenDateRadio = $get('<%= RepeatUntilGivenDate.ClientID %>');
				repeatUntilGivenDateRadio.checked = true;
				
				var rangeEndDateInput = $get('<%= RangeEndDate.DateInput.ClientID + "_text" %>');
				rangeEndDateInput.focus();
			}

		//]]>
		</script>
</Content>
</scheduler:ScriptBlock>
<asp:Panel runat="server" ID="BasicControlsPanel" CssClass="rsAdvBasicControls" OnDataBinding="BasicControlsPanel_DataBinding">
	<div class="rsAdvOptionsPanel">
		<label for='<%= ProductionShifts.ClientID %>'><%= Owner.Localization.AdvancedDescription%></label>
		<asp:RequiredFieldValidator runat="server" ID="SubjectValidator" ControlToValidate="ProductionShifts"
			EnableClientScript="true" Display="None" CssClass="rsValidatorMsg" />
		<div class="textareaWrapper">
		
			<asp:DropDownList runat="server" ID="ProductionShifts" OnPreRender="ProductionShifts_PreRender">
			</asp:DropDownList>
			
		</div>
						
		<ul>
			<li class="rsTimePick">
				<label for='<%= StartDate.ClientID %>_dateInput_text'><%= Owner.Localization.AdvancedFrom %></label>
				<telerik:RadDatePicker	runat="server" ID="StartDate" CssClass="rsAdvDatePicker"
										Width="83px" SharedCalendarID="SharedCalendar"
										Skin='<%# Owner.Skin %>'
										Culture='<%# Owner.Culture %>'>
					<DatePopupButton Visible="False" />
					<DateInput ID="DateInput1"
						runat="server"
						DateFormat='<%# Owner.EditFormDateFormat %>'
						EmptyMessageStyle-CssClass="radInvalidCss_Default" EmptyMessage=" " />
				</telerik:RadDatePicker>
				<telerik:RadTimePicker
						runat="server" ID="StartTime" CssClass="rsAdvTimePicker"
						Width="65px" Skin='<%# Owner.Skin %>' Culture='<%# Owner.Culture %>'>
					<DateInput ID="DateInput2" runat="server"
						 EmptyMessageStyle-CssClass="radInvalidCss_Default" EmptyMessage=" " />
					<TimePopupButton Visible="false" />
					<TimeView ID="TimeView1"
						runat="server"
						Columns="2" ShowHeader="false"
						StartTime="08:00" EndTime="18:00" Interval="00:30" />
				</telerik:RadTimePicker>
			</li>
			<li class="rsTimePick">
				<label for='<%= EndDate.ClientID %>_dateInput_text'><%= Owner.Localization.AdvancedTo%></label>
				<telerik:RadDatePicker	runat="server" ID="EndDate" CssClass="rsAdvDatePicker"
										Width="83px" SharedCalendarID="SharedCalendar"
										Skin='<%# Owner.Skin %>'
										Culture='<%# Owner.Culture %>'>
					<DatePopupButton Visible="False" />
					<DateInput ID="DateInput3"
						runat="server"
						DateFormat='<%# Owner.EditFormDateFormat %>'
						EmptyMessageStyle-CssClass="radInvalidCss_Default" EmptyMessage=" " />
				</telerik:RadDatePicker><telerik:RadTimePicker
						runat="server" ID="EndTime" CssClass="rsAdvTimePicker"
						Width="65px" Skin='<%# Owner.Skin %>' Culture='<%# Owner.Culture %>'>
					<DateInput ID="DateInput4" runat="server"
						 EmptyMessageStyle-CssClass="radInvalidCss_Default" EmptyMessage=" " />
					<TimePopupButton Visible="false" />
					<TimeView ID="TimeView2"
						runat="server"
						Columns="2" ShowHeader="false"
						StartTime="08:00" EndTime="18:00" Interval="00:30" />
				</telerik:RadTimePicker>
			</li>
			<li style="float: right">
				<asp:CheckBox	runat="server" ID="AllDayEvent" CssClass="rsAdvChkWrap"
								Checked="false" />
								
				<asp:CheckBox	runat="server" ID="RecurrentAppointment" CssClass="rsAdvChkWrap"
								Checked="false" />
			</li>
		</ul>
								
		<asp:RequiredFieldValidator runat="server" ID="StartDateValidator" ControlToValidate="StartDate"
			EnableClientScript="true" Display="None" CssClass="rsValidatorMsg" />
		
		<asp:RequiredFieldValidator runat="server" ID="StartTimeValidator" ControlToValidate="StartTime"
			EnableClientScript="true" Display="None" CssClass="rsValidatorMsg" />
		
		<asp:RequiredFieldValidator runat="server" ID="EndDateValidator" ControlToValidate="EndDate"
			EnableClientScript="true" Display="None" CssClass="rsValidatorMsg" />
		
		<asp:RequiredFieldValidator runat="server" ID="EndTimeValidator" ControlToValidate="EndTime"
			EnableClientScript="true" Display="None" CssClass="rsValidatorMsg" />
		
		<asp:CustomValidator runat="server" ID="DurationValidator" ControlToValidate="StartDate"
			EnableClientScript="false" Display="Dynamic" CssClass="rsValidatorMsg rsInvalid"
			OnServerValidate="DurationValidator_OnServerValidate" />
	</div>
</asp:Panel>

<asp:Panel runat="server" ID="RecurrencePanel" Style="display: none;">

<asp:Panel runat="server" ID="RecurrencePatternPanel" CssClass="rsAdvRecurrencePatterns"  OnDataBinding="RecurrencePatternPanel_DataBinding">
	<h2 class="rsAdvRecurrence">
		<span><%= Owner.Localization.AdvancedRecurrence %></span>
		<span class="rsAdvResetExceptions">
			<asp:LinkButton runat="server" ID="ResetExceptions" OnClick="ResetExceptions_OnClick" />
		</span>
	</h2>
	
	<div class="rsAdvOptionsPanel">
		<asp:Panel runat="server" ID="RecurrenceFrequencyPanel" CssClass="rsAdvRecurrenceFreq">
			<ul class="rsRecurrenceOptionList">
				<li>
					<asp:RadioButton runat="server" ID="RepeatFrequencyHourly" GroupName="RepeatFrequency" />
				</li>
				<li>
					<asp:RadioButton runat="server" ID="RepeatFrequencyDaily" GroupName="RepeatFrequency" />
				</li>	
				<li>
					<asp:RadioButton runat="server" ID="RepeatFrequencyWeekly" GroupName="RepeatFrequency" />
				</li>
				<li>
					<asp:RadioButton runat="server" ID="RepeatFrequencyMonthly" GroupName="RepeatFrequency" />
				</li>
				<li>
					<asp:RadioButton runat="server" ID="RepeatFrequencyYearly" GroupName="RepeatFrequency" />
				</li>
			</ul>
		</asp:Panel>
		<asp:Panel runat="server" ID="RecurrencePatternHourlyPanel" CssClass="rsAdvPatternPanel rsAdvHourly" Style="display:none;">
			<p>
					<%= Owner.Localization.AdvancedEvery %>
					<asp:TextBox runat="server" ID="HourlyRepeatInterval" Text="1" CssClass="rsAdvInput" />
					<%= Owner.Localization.AdvancedHours %>
				
				<asp:RegularExpressionValidator runat="server" ID="HourlyRepeatIntervalValidator"
					ControlToValidate="HourlyRepeatInterval" EnableClientScript="true"
					Display="None" CssClass="rsValidatorMsg" ValidationExpression="\d+" />
			</p>
		</asp:Panel>
		<asp:Panel runat="server" ID="RecurrencePatternDailyPanel" CssClass="rsAdvPatternPanel rsAdvDaily" Style="display:none;">
			<ul>
				<li>
					<asp:RadioButton	runat="server" ID="RepeatEveryNthDay" Checked="true"									
										GroupName="DailyRecurrenceDetailRadioGroup" CssClass="rsAdvRadio" />
					<asp:TextBox runat="server" ID="DailyRepeatInterval" Text="1" CssClass="rsAdvInput" />
					<%= Owner.Localization.AdvancedDays %>
				
					<asp:RegularExpressionValidator runat="server" ID="DailyRepeatIntervalValidator"
						ControlToValidate="DailyRepeatInterval" EnableClientScript="true"					
						Display="None" CssClass="rsValidatorMsg" ValidationExpression="\d+" />
				</li>
				<li>
					<asp:RadioButton runat="server" ID="RepeatEveryWeekday" GroupName="DailyRecurrenceDetailRadioGroup" CssClass="rsAdvRadio" />
				</li>
			</ul>
		</asp:Panel>
		<asp:Panel runat="server" ID="RecurrencePatternWeeklyPanel" CssClass="rsAdvPatternPanel rsAdvWeekly" Style="display:none;">

			<p>
				<%= Owner.Localization.AdvancedRecurEvery %>
				<asp:TextBox runat="server" ID="WeeklyRepeatInterval" Text="1" CssClass="rsAdvInput" />
				<%= Owner.Localization.AdvancedWeeks %>
			
				<asp:RegularExpressionValidator runat="server" ID="WeeklyRepeatIntervalValidator"
					ControlToValidate="WeeklyRepeatInterval" EnableClientScript="true"
					
					Display="None" CssClass="rsValidatorMsg" 
					ValidationExpression="\d+" />
			</p>
			<ul class="rsAdvWeekly_WeekDays">
				<li>
					<asp:CheckBox	runat="server" ID="WeeklyWeekDaySunday" CssClass="rsAdvCheckboxWrapper" />
				</li>
				<li>
					<asp:CheckBox	runat="server" ID="WeeklyWeekDayMonday" CssClass="rsAdvCheckboxWrapper" />
				</li>
				<li>
					<asp:CheckBox	runat="server" ID="WeeklyWeekDayTuesday" CssClass="rsAdvCheckboxWrapper" />
				</li>
				<li>
					<asp:CheckBox	runat="server" ID="WeeklyWeekDayWednesday" CssClass="rsAdvCheckboxWrapper" />
				</li>
				<li style="clear: left;">
					<asp:CheckBox	runat="server" ID="WeeklyWeekDayThursday" CssClass="rsAdvCheckboxWrapper" />
				</li>
				<li>
					<asp:CheckBox	runat="server" ID="WeeklyWeekDayFriday" CssClass="rsAdvCheckboxWrapper" />
				</li>
				<li>
					<asp:CheckBox	runat="server" ID="WeeklyWeekDaySaturday" CssClass="rsAdvCheckboxWrapper" />
				</li>
			</ul>
		</asp:Panel>
		<asp:Panel runat="server" ID="RecurrencePatternMonthlyPanel" CssClass="rsAdvPatternPanel rsAdvMonthly" Style="display:none;">
			<ul>
				<li>
					<asp:RadioButton	runat="server" ID="RepeatEveryNthMonthOnDate" Checked="true"									
										GroupName="MonthlyRecurrenceRadioGroup" CssClass="rsAdvRadio" />
					<asp:TextBox runat="server" ID="MonthlyRepeatDate" Text="1" CssClass="rsAdvInput" />
					<%= Owner.Localization.AdvancedOfEvery %>
				
					<asp:RegularExpressionValidator runat="server" ID="MonthlyRepeatDateValidator"
						ControlToValidate="MonthlyRepeatDate" EnableClientScript="true"					
						Display="None" CssClass="rsValidatorMsg" ValidationExpression="\d+" />

					<asp:TextBox runat="server" ID="MonthlyRepeatIntervalForDate" Text="1" CssClass="rsAdvInput" />
					<%= Owner.Localization.AdvancedMonths %>

				
					<asp:RegularExpressionValidator runat="server" ID="MonthlyRepeatIntervalForDateValidator"
						ControlToValidate="MonthlyRepeatIntervalForDate" EnableClientScript="true"					
						Display="None" CssClass="rsValidatorMsg" ValidationExpression="\d+" />
				</li>
				<li>
					<asp:RadioButton	runat="server" ID="RepeatEveryNthMonthOnGivenDay"									
										GroupName="MonthlyRecurrenceRadioGroup" CssClass="rsAdvRadio" />
					<asp:DropDownList	runat="server" ID="MonthlyDayOrdinalDropDown">
						<%--Populated from code-behind--%>
					</asp:DropDownList>
					<asp:DropDownList	runat="server" ID="MonthlyDayMaskDropDown">
						<%--Populated from code-behind--%>
					</asp:DropDownList>
					<%= Owner.Localization.AdvancedOfEvery %>
					<asp:TextBox runat="server" ID="MonthlyRepeatIntervalForGivenDay" Text="1" CssClass="rsAdvInput" />
					<%= Owner.Localization.AdvancedMonths %>
				
					<asp:RegularExpressionValidator runat="server" ID="MonthlyRepeatIntervalForGivenDayValidator"
						ControlToValidate="MonthlyRepeatIntervalForGivenDay" EnableClientScript="true"					
						Display="None" CssClass="rsValidatorMsg" ValidationExpression="\d+" />
				</li>
			</ul>
		</asp:Panel>
		<asp:Panel runat="server" ID="RecurrencePatternYearlyPanel" CssClass="rsAdvPatternPanel rsAdvYearly" Style="display:none;">
			<ul>
				<li>
					<asp:RadioButton	runat="server" ID="RepeatEveryYearOnDate" Checked="true"									
										GroupName="YearlyRecurrenceRadioGroup" CssClass="rsAdvRadio" />
					<asp:DropDownList	runat="server" ID="YearlyRepeatMonthForDate">
						<%--Populated from code-behind--%>
					</asp:DropDownList>
					<asp:TextBox runat="server" ID="YearlyRepeatDate" Text="1" CssClass="rsAdvInput">
					</asp:TextBox>
				
					<asp:RegularExpressionValidator runat="server" ID="YearlyRepeatDateValidator"
						ControlToValidate="YearlyRepeatDate" EnableClientScript="true"					
						Display="None" CssClass="rsValidatorMsg" ValidationExpression="\d+" />
				</li>
				<li>
					<asp:RadioButton	runat="server" ID="RepeatEveryYearOnGivenDay"									
										GroupName="YearlyRecurrenceRadioGroup" CssClass="rsAdvRadio" />
					<asp:DropDownList	runat="server" ID="YearlyDayOrdinalDropDown">
						<%--Populated from code-behind--%>
					</asp:DropDownList>
					<asp:DropDownList	runat="server" ID="YearlyDayMaskDropDown">
						<%--Populated from code-behind--%>
					</asp:DropDownList>
					<%= Owner.Localization.AdvancedOf %>
					<asp:DropDownList	runat="server" ID="YearlyRepeatMonthForGivenDay">
						<%--Populated from code-behind--%>
					</asp:DropDownList>
				</li>
			</ul>
		</asp:Panel>
	</div>
</asp:Panel>
<asp:Panel runat="server" ID="RecurrenceRangePanel" CssClass="rsAdvRecurrenceRangePanel" OnDataBinding="RecurrenceRangePanel_DataBinding">
	<h3 class="rsAdvRecurrenceRange"><%= Owner.Localization.AdvancedRange %></h3>
	<div class="rsAdvOptionsPanel">
		<ul>
		<li>
			<asp:RadioButton	runat="server" ID="RepeatIndefinitely" Checked="true"								
								GroupName="RecurrenceRangeRadioGroup" CssClass="rsAdvRadio" />
		</li>
		<li>
			<asp:RadioButton	runat="server" ID="RepeatGivenOccurrences"								
								GroupName="RecurrenceRangeRadioGroup" CssClass="rsAdvRadio" />
			<asp:TextBox		runat="server" ID="RangeOccurrences" CssClass="rsAdvInput" />
			<%= Owner.Localization.AdvancedOccurrences %>
			
			<asp:RegularExpressionValidator runat="server" ID="RangeOccurrencesValidator"
				ControlToValidate="RangeOccurrences" EnableClientScript="true"				
				Display="None" CssClass="rsValidatorMsg" ValidationExpression="\d+" />
		</li>
		<li class="rsTimePick">
			<asp:RadioButton	runat="server" ID="RepeatUntilGivenDate"								
								GroupName="RecurrenceRangeRadioGroup" CssClass="rsAdvRadio" />
			<telerik:RadDatePicker	runat="server" ID="RangeEndDate" CssClass="rsAdvDatePicker"
									Width="83px" Skin='<%# Owner.Skin %>'
									SharedCalendarID="SharedCalendar"
									Culture='<%# Owner.Culture %>'>
					<DatePopupButton Visible="False" />
					<DateInput ID="DateInput5"
						runat="server"
						DateFormat='<%# Owner.EditFormDateFormat %>'/>
				</telerik:RadDatePicker>
		</li>
	</ul>
	</div>
</asp:Panel>

</asp:Panel>

<asp:HiddenField runat="server" ID="OriginalRecurrenceRule" />
<asp:HiddenField runat="server" ID="SelectedShift" />

<telerik:RadCalendar
	runat="server" ID="SharedCalendar"
	Skin='<%# Owner.Skin %>'
	CultureInfo='<%# Owner.Culture %>'
	ShowRowHeaders="false" />
