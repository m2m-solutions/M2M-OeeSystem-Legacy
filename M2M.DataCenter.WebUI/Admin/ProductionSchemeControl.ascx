<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ProductionSchemeControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Admin.ProductionSchemeControl" %>
<%@ Register Src="Templates/AdvancedFormCS.ascx" TagName="AdvancedForm" TagPrefix="scheduler" %>
<%@ Register Assembly="Csla" Namespace="Csla.Web" TagPrefix="cc1" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
<Scripts>
 <asp:ScriptReference Path="~\Admin\Templates\AdvancedForm.js" />
</Scripts>
</asp:ScriptManagerProxy>
<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
		<script type="text/javascript">	
		//<![CDATA[
			function OnClientRecurrenceActionDialogShowing(sender, eventArgs)
			{  
				var scheduler = $get('<%=RadScheduler1.ClientID %>');
				
				var viewPortHeight = 0;
				if( typeof( window.innerWidth ) == 'number' ) 
				{
					//Non-IE
					viewPortHeight = window.innerHeight;
				}
				else if( document.documentElement && ( document.documentElement.clientWidth || document.documentElement.clientHeight ) ) 
				{
					//IE 6+ in 'standards compliant mode'
					viewPortHeight = document.documentElement.clientHeight;
				} 
				else if( document.body && ( document.body.clientWidth || document.body.clientHeight ) ) 
				{
					//IE 4 compatible
					viewPortHeight = document.body.clientHeight;
				}

				var schedulerHeight = scheduler.scrollHeight;
				var schedulerOffsetTop = scheduler.offsetTop;
				window.scrollTo(0,  schedulerOffsetTop + schedulerHeight/2 - viewPortHeight/2);
			}
			
			function schedulerFormCreated(scheduler, eventArgs) {
                var $ = $telerik.$;
                var schedulerElement = scheduler.get_element();
                var formElement = $("div.rsAdvancedEdit", schedulerElement);

                if (formElement.length == 1) {
                    // Initialize the client-side object for the advanced form   
                    var advancedTemplate = new window.SchedulerAdvancedTemplate(schedulerElement, formElement);
                    advancedTemplate.initialize();
                }
            }
            function pageLoad() {
                var scheduler = $find('<%= RadScheduler1.ClientID %>');
                var firstAppointment = $telerik.getElementByClassName(scheduler.get_element(), "FirstAppointment", "td");
                if (firstAppointment)
                {
                    var scrollYposition = firstAppointment.offsetTop;
                    $telerik.$(".rsContentScrollArea", scheduler.get_element()).get(0).scrollTop = scrollYposition;
                }
            }

           
		//]]>
		</script>
</telerik:RadScriptBlock>
<div class="content">
    <telerik:RadAjaxPanel runat="server" height="500px" width="100%">
        <asp:Label runat="server" id="ProductionModeWarning" Visible="false" ForeColor="Red" Text="<%$ DataCenter:ProductionModeSchedulerWarning %>"></asp:Label>
    <telerik:RadScheduler ID="RadScheduler1" StartInsertingInAdvancedForm="True"
        OnClientRecurrenceActionDialogShowing="OnClientRecurrenceActionDialogShowing" 
        runat="server" EnableResourceEditing="false"  DataEndField="EndTime" 
        DataKeyField="Id" DataRecurrenceField="RecurrenceRule" 
        DataRecurrenceParentKeyField="RecurrenceParentId" DataStartField="StartTime" 
        DataSubjectField="Shift"  
        OnAppointmentUpdate="RadScheduler1_AppointmentUpdate" 
        OnAppointmentInsert="RadScheduler1_AppointmentInsert"
        OnNavigationCommand="RadScheduler1_NavigationCommand"
        OnTimeSlotCreated="RadScheduler1_TimeSlotCreated"
        WorkDayEndTime="00:00:00" WorkDayStartTime="00:00:00" DayEndTime="1.00:00:00" 
        DayStartTime="00:00:00" SelectedView="WeekView" FirstDayOfWeek="Monday" 
        ShowAllDayRow="False" ShowFullTime="True" MinutesPerRow="15"
        OnAppointmentDelete="RadScheduler1_AppointmentDelete" LastDayOfWeek="Sunday" 
        OnAppointmentDataBound="RadScheduler1_AppointmentDataBound"
        OnClientFormCreated="schedulerFormCreated" ShowFooter="false"
        HoursPanelTimeFormat="HH:mm tt" EnableExactTimeRendering="True" 
        Height="500px" RowHeight="10px" Culture="(Default)" style="margin-right: 0">
	    <advancedform enableresourceediting="False" modal="True" />
	    <MonthView VisibleAppointmentsPerDay="6" />
        <TimelineView NumberOfSlots="7" UserSelectable="False" />
	    <WeekView DayEndTime="1.00:00:00" DayStartTime="00:00:00"   
            WorkDayEndTime="1.00:00:00" WorkDayStartTime="00:00:00" />
            <AppointmentTemplate>
                <div class="rsAptSubject"> 
                    <%# Eval("Description") %> 
                </div> 
            </AppointmentTemplate>
        <AdvancedEditTemplate>
		    <scheduler:AdvancedForm ID="AdvancedEditForm1" runat="server" Mode="Edit"
			    Subject='<%# Bind("Subject") %>'
			    Start='<%# Bind("Start") %>'
			    End='<%# Bind("End") %>'
			    RecurrenceRuleText='<%# Bind("RecurrenceRule") %>' />
	    </AdvancedEditTemplate>
	    <AdvancedInsertTemplate>
		    <scheduler:AdvancedForm ID="AdvancedInsertForm1" runat="server" Mode="Insert"
			    Subject='<%# Bind("Subject") %>'
			    Start='<%# Bind("Start") %>'
			    End='<%# Bind("End") %>'
			    RecurrenceRuleText='<%# Bind("RecurrenceRule") %>' />
	    </AdvancedInsertTemplate>
	    <Localization AdvancedAllDayEvent="<%$ DataCenter:Scheduler.AdvancedAllDayEvent %>" AdvancedCalendarCancel="<%$ DataCenter:Scheduler.AdvancedCalendarCancel %>"
		    AdvancedCalendarToday="<%$ DataCenter:Scheduler.AdvancedCalendarToday %>" AdvancedDaily="<%$ DataCenter:Scheduler.AdvancedDaily %>" AdvancedDay="<%$ DataCenter:Scheduler.AdvancedDay %>" AdvancedDays="<%$ DataCenter:Scheduler.AdvancedDays %>"
		    AdvancedDescription="<%$ DataCenter:Scheduler.AdvancedDescription %>" AdvancedEndAfter="<%$ DataCenter:Scheduler.AdvancedEndAfter %>" AdvancedEndByThisDate="<%$ DataCenter:Scheduler.AdvancedEndByThisDate %>"
		    AdvancedEvery="<%$ DataCenter:Scheduler.AdvancedEvery %>" AdvancedEveryWeekday="<%$ DataCenter:Scheduler.AdvancedEveryWeekday %>" AdvancedHours="<%$ DataCenter:Scheduler.AdvancedHours %>"
		    AdvancedMaskWeekday="<%$ DataCenter:Scheduler.AdvancedMaskWeekday %>" AdvancedMaskWeekendDay="<%$ DataCenter:Scheduler.AdvancedMaskWeekendDay %>" AdvancedMonthly="<%$ DataCenter:Scheduler.AdvancedMonthly %>"
		    AdvancedMonths="<%$ DataCenter:Scheduler.AdvancedMonths %>" AdvancedNoEndDate="<%$ DataCenter:Scheduler.AdvancedNoEndDate %>"
		    AdvancedOccurrences="<%$ DataCenter:Scheduler.AdvancedOccurrences %>" AdvancedOf="<%$ DataCenter:Scheduler.AdvancedOf %>" AdvancedOfEvery="<%$ DataCenter:Scheduler.AdvancedOfEvery %>"
		    AdvancedRecurEvery="<%$ DataCenter:Scheduler.AdvancedRecurEvery %>" AdvancedRecurrence="<%$ DataCenter:Scheduler.AdvancedRecurrence %>"
		    AdvancedReset="<%$ DataCenter:Scheduler.AdvancedReset %>" 
		    AdvancedSecond="<%$ DataCenter:Scheduler.AdvancedSecond %>" AdvancedThird="<%$ DataCenter:Scheduler.AdvancedThird %>" AdvancedTo="<%$ DataCenter:Scheduler.AdvancedTo %>" AdvancedWeekly="<%$ DataCenter:Scheduler.AdvancedWeekly %>"
		    AdvancedWeeks="<%$ DataCenter:Scheduler.AdvancedWeeks %>" AdvancedYearly="<%$ DataCenter:Scheduler.AdvancedYearly %>" AllDay="<%$ DataCenter:Scheduler.AllDay %>" Cancel="<%$ DataCenter:Scheduler.Cancel %>"
		    ConfirmCancel="<%$ DataCenter:Scheduler.ConfirmCancel %>" ConfirmDeleteText="<%$ DataCenter:Scheduler.ConfirmDeleteText %>"
		    ConfirmDeleteTitle="<%$ DataCenter:Scheduler.ConfirmDeleteTitle %>" ConfirmRecurrenceDeleteOccurrence="<%$ DataCenter:Scheduler.ConfirmRecurrenceDeleteOccurrence %>"
		    ConfirmRecurrenceDeleteSeries="<%$ DataCenter:Scheduler.ConfirmRecurrenceDeleteSeries %>" ConfirmRecurrenceDeleteTitle="<%$ DataCenter:Scheduler.ConfirmRecurrenceDeleteTitle %>"
		    ConfirmRecurrenceEditOccurrence="<%$ DataCenter:Scheduler.ConfirmRecurrenceEditOccurrence %>" ConfirmRecurrenceEditSeries="<%$ DataCenter:Scheduler.ConfirmRecurrenceEditSeries %>"
		    ConfirmRecurrenceEditTitle="<%$ DataCenter:Scheduler.ConfirmRecurrenceEditTitle %>" ConfirmRecurrenceMoveOccurrence="<%$ DataCenter:Scheduler.ConfirmRecurrenceMoveOccurrence %>"
		    ConfirmRecurrenceMoveSeries="<%$ DataCenter:Scheduler.ConfirmRecurrenceMoveSeries %>" ConfirmRecurrenceMoveTitle="<%$ DataCenter:Scheduler.ConfirmRecurrenceMoveTitle %>"
		    ConfirmRecurrenceResizeOccurrence="<%$ DataCenter:Scheduler.ConfirmRecurrenceResizeOccurrence %>"
		    ConfirmRecurrenceResizeSeries="<%$ DataCenter:Scheduler.ConfirmRecurrenceResizeSeries %>"
		    ConfirmRecurrenceResizeTitle="<%$ DataCenter:Scheduler.ConfirmRecurrenceResizeTitle %>"
		    HeaderDay="<%$ DataCenter:Scheduler.HeaderDay %>" HeaderMonth="<%$ DataCenter:Scheduler.HeaderMonth %>" HeaderNextDay="<%$ DataCenter:Scheduler.HeaderNextDay %>" HeaderPrevDay="<%$ DataCenter:Scheduler.HeaderPrevDay %>"
		    HeaderToday="<%$ DataCenter:Scheduler.HeaderToday %>" HeaderWeek="<%$ DataCenter:Scheduler.HeaderWeek %>" Show24Hours="<%$ DataCenter:Scheduler.Show24Hours %>"
		    ShowAdvancedForm="<%$ DataCenter:Scheduler.ShowAdvancedForm %>" ShowBusinessHours="<%$ DataCenter:Scheduler.ShowBusinessHours %>" ShowMore="<%$ DataCenter:Scheduler.ShowMore %>"
		    AdvancedFirst="<%$ DataCenter:Scheduler.AdvancedFirst %>" AdvancedFourth="<%$ DataCenter:Scheduler.AdvancedFourth %>" AdvancedFrom="<%$ DataCenter:Scheduler.AdvancedFrom %>" 
            AdvancedHourly="<%$ DataCenter:Scheduler.AdvancedHourly %>" AdvancedLast="<%$ DataCenter:Scheduler.AdvancedLast %>" AdvancedMaskDay="<%$ DataCenter:Scheduler.AdvancedMaskDay %>" 
            AdvancedThe="<%$ DataCenter:Scheduler.AdvancedThe %>" HeaderTimeline="<%$ DataCenter:Scheduler.HeaderTimeline %>" 
            AdvancedEndDateRequired="<%$ DataCenter:Scheduler.AdvancedEndDateRequired %>" 
            AdvancedEndTimeRequired="<%$ DataCenter:Scheduler.AdvancedEndTimeRequired %>" 
            AdvancedStartDateRequired="<%$ DataCenter:Scheduler.AdvancedStartDateRequired %>" 
            AdvancedStartTimeBeforeEndTime="<%$ DataCenter:Scheduler.AdvancedStartTimeBeforeEndTime %>" 
            AdvancedStartTimeRequired="<%$ DataCenter:Scheduler.AdvancedStartTimeRequired %>" Save="<%$ DataCenter:Scheduler.Save %>" 
            AdvancedClose="<%$ DataCenter:Scheduler.AdvancedClose %>" AdvancedDone="<%$ DataCenter:Scheduler.AdvancedDone %>" 
            AdvancedEditAppointment="<%$ DataCenter:Scheduler.AdvancedEditAppointment %>" 
            AdvancedInvalidNumber="<%$ DataCenter:Scheduler.AdvancedInvalidNumber %>" AdvancedNewAppointment="<%$ DataCenter:Scheduler.AdvancedNewAppointment %>" 
            AdvancedSubjectRequired="<%$ DataCenter:Scheduler.AdvancedSubjectRequired %>" AdvancedWorking="<%$ DataCenter:Scheduler.AdvancedWorking %>" 
            ConfirmResetExceptionsText="<%$ DataCenter:Scheduler.ConfirmResetExceptionsText %>" 
            AdvancedSubject="<%$ DataCenter:Scheduler.AdvancedSubject %>"
            ContextMenuAddAppointment="<%$ DataCenter:Scheduler.ContextMenuAddAppointment %>"
            ContextMenuAddRecurringAppointment="<%$ DataCenter:Scheduler.ContextMenuAddRecurringAppointment %>"
            ContextMenuDelete="<%$ DataCenter:Scheduler.ContextMenuDelete %>"
            ContextMenuEdit="<%$ DataCenter:Scheduler.ContextMenuEdit %>"
            ContextMenuGoToToday="<%$ DataCenter:Scheduler.ContextMenuGoToToday %>" />
	    <DayView DayEndTime="1.00:00:00" DayStartTime="00:00:00" />
	    <TimeSlotContextMenuSettings EnableDefault="true" />
        <AppointmentContextMenuSettings EnableDefault="true" />
    </telerik:RadScheduler>
    </telerik:RadAjaxPanel>
</div>

<cc1:CslaDataSource ID="CslaDataSource1" runat="server" TypeAssemblyName="" TypeName="M2M.DataCenter.ProductionSchemeItemCollection, M2M.DataCenter.Library"
				TypeSupportsPaging="False" TypeSupportsSorting="False">
			</cc1:CslaDataSource>
