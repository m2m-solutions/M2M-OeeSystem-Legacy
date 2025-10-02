<%@ Page Title="" Language="C#" MasterPageFile="~/M2MDataCenter.Master" AutoEventWireup="true" CodeBehind="SchedulerPage.aspx.cs" Inherits="M2M.DataCenter.WebUI.Admin.SchedulerPage" %>
<%@ Register TagPrefix="scheduler" TagName="AdvancedForm" Src="AdvancedFormTemplate/AdvancedFormCS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
<Scripts>
 <asp:ScriptReference Path="~\Admin\AdvancedFormTemplate\AdvancedForm.js" />
</Scripts>
</asp:ScriptManagerProxy>
<script type="text/javascript">
    //<![CDATA[

    // Dictionary containing the advanced template client object
    // for a given RadScheduler instance (the control ID is used as key).
    var schedulerTemplates = {};

    function schedulerFormCreated(scheduler, eventArgs) {
        // Create a client-side object only for the advanced templates
        var mode = eventArgs.get_mode();
        if (mode == Telerik.Web.UI.SchedulerFormMode.AdvancedInsert ||
					mode == Telerik.Web.UI.SchedulerFormMode.AdvancedEdit) {
            // Initialize the client-side object for the advanced form
            var formElement = eventArgs.get_formElement();
            var templateKey = scheduler.get_id() + "_" + mode;
            var advancedTemplate = schedulerTemplates[templateKey];
            if (!advancedTemplate) {
                // Initialize the template for this RadScheduler instance
                // and cache it in the schedulerTemplates dictionary
                var schedulerElement = scheduler.get_element();
                var isModal = scheduler.get_advancedFormSettings().modal;
                advancedTemplate = new window.SchedulerAdvancedTemplate(schedulerElement, formElement, isModal);
                advancedTemplate.initialize();

                schedulerTemplates[templateKey] = advancedTemplate;

                // Remove the template object from the dictionary on dispose.
                scheduler.add_disposing(function() {
                    schedulerTemplates[templateKey] = null;
                });
            }

            // Are we using Web Service data binding?
            if (!scheduler.get_webServiceSettings().get_isEmpty()) {
                // Populate the form with the appointment data
                var apt = eventArgs.get_appointment();
                var isInsert = mode == Telerik.Web.UI.SchedulerFormMode.AdvancedInsert;
                advancedTemplate.populate(apt, isInsert);
            }
        }
    }

    //]]>
		</script>
		<div class="divContentTop">
    </div>
    <div class="divContent">	
		<div class="grey_frame">
			<div class="topspecial">
				<div class="bottom">
					<div class="left">
						<div class="right">
							<div class="bottomleft">
								<div class="bottomright">
									<div class="topleft">
										<div class="topright">
											<div class="content">
	                                            <div class="filterView">
	                                            <div class="white_frame">
	<div class="header">
		<div class="top">
			<div class="bottom">
				<div class="left">
					<div class="right">
						<div class="bottomleft">
							<div class="bottomright">
								<div class="topleft">
									<div class="topright">
										<div class="content">
											<div class="filterView">
												<div class="item">
													<div class="input">
														<telerik:RadComboBox ID="DeviceUnits" Width="190px" Skin="Default" AutoPostBack="False"  runat="server">
															 <CollapseAnimation Duration="200" Type="OutQuint" />
														 </telerik:RadComboBox>
													</div>
												</div>
												<div class="last">
													<div class="button">
														<asp:Button ID="btnAddDeviceUnit" runat="server" CssClass="buttonSmallWhiteOnWhite" Text="<%$ DataCenter:AddScheme %>" OnClick="btnAddDeviceUnit_Click" />
													</div>
												</div>
												<div class="divider"></div>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="clear">&nbsp;</div>
	</div>
</div>
                                                    <telerik:RadScheduler runat="server" ID="RadScheduler1" Width="100%" 
			    OnDataBound="RadScheduler1_DataBound" AppointmentStyleMode="Default" 
        SelectedView="TimelineView" FirstDayOfWeek="Monday"
                OnAppointmentCreated="RadScheduler1_AppointmentCreated" 
        StartEditingInAdvancedForm="true" StartInsertingInAdvancedForm="true"
			    OnAppointmentDataBound="RadScheduler1_AppointmentDataBound" 
			    OnClientFormCreated="schedulerFormCreated" 
        ProviderName="ProductionSchemeProvider" 
        OnNavigationComplete="RadScheduler1_NavigationComplete" 
        onappointmentinsert="RadScheduler1_AppointmentInsert" 
        onappointmentupdate="RadScheduler1_AppointmentUpdate" onformcreated="RadScheduler1_FormCreated"
			    >
			    <AdvancedForm Modal="true" EnableCustomAttributeEditing="true" EnableResourceEditing="true"  />
                <Reminders Enabled="false" />
                <TimelineView UserSelectable="True" SlotDuration="01:00:00" NumberOfSlots="24" ColumnHeaderDateFormat="HH:mm" GroupBy="DeviceUnit" GroupingDirection="Vertical"  />
                <MonthView  UserSelectable="False" />
                <WeekView  UserSelectable="False" />
                <DayView  UserSelectable="false" />
                <MultiDayView NumberOfDays="7" UserSelectable="true"  />
			    <AppointmentTemplate>
                <div class="rsAptSubject"> 
                    <%# Eval("Subject") %> 
                </div> 
            </AppointmentTemplate>
			    <AdvancedEditTemplate>
				    <scheduler:AdvancedForm runat="server" ID="AdvancedEditForm1" Mode="Edit"
					    Subject='<%# Bind("DeviceUnit.Text") %>'
					    Start='<%# Bind("Start") %>'
					    End='<%# Bind("End") %>'
					    RecurrenceRuleText='<%# Bind("RecurrenceRule") %>'
                        ShiftId='<%# Bind("Shift") %>'
                        DeviceUnitId='<%# Bind("DeviceUnit") %>' />
			    </AdvancedEditTemplate>
			    <AdvancedInsertTemplate>
				    <scheduler:AdvancedForm runat="server" ID="AdvancedInsertForm1" Mode="Insert"
					    Subject='<%# Bind("DeviceUnit.Text") %>'
					    Start='<%# Bind("Start") %>'
					    End='<%# Bind("End") %>'
					    RecurrenceRuleText='<%# Bind("RecurrenceRule") %>'
                        ShiftId='<%# Bind("Shift") %>' 
                        DeviceUnitId='<%# Bind("DeviceUnit") %>' />
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
            AdvancedSubject="<%$ DataCenter:Scheduler.AdvancedSubject %>" />
			    <TimeSlotContextMenuSettings EnableDefault="true" />
		        <AppointmentContextMenuSettings EnableDefault="true" />        			
		    </telerik:RadScheduler>
                                                </div>
                                                <div class="divider"></div>
                                            </div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="clear">&nbsp;</div>
		</div>
	</div>

</asp:Content>
