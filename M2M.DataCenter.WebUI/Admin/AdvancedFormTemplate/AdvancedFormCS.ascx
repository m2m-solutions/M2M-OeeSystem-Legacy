<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="M2M.DataCenter.WebUI.Admin.AdvancedTemplates.AdvancedForm" Codebehind="AdvancedFormCS.ascx.cs" %>
<%@ Register TagPrefix="scheduler" TagName="ResourceControl" Src="ResourceControlCS.ascx" %>
<div class="rsAdvancedEdit rsAdvancedModal" style="position: relative">
    <div class="rsModalBgTopLeft">
    </div>
    <div class="rsModalBgTopRight">
    </div>
    <div class="rsModalBgBottomLeft">
    </div>
    <div class="rsModalBgBottomRight">
    </div>
    <%-- Title bar. --%>
    <div class="rsAdvTitle">
        <%-- The rsAdvInnerTitle element is used as a drag handle when the form is modal. --%>
        <h1 class="rsAdvInnerTitle">
            <%= (this.Mode.ToString() == "Edit") ? Owner.Localization.AdvancedEditAppointment : Owner.Localization.AdvancedNewAppointment %></h1>
        <asp:LinkButton runat="server" ID="AdvancedEditCloseButton" CssClass="rsAdvEditClose"
            CommandName="Cancel" CausesValidation="false" ToolTip='<%# Owner.Localization.AdvancedClose %>'>
			<%= Owner.Localization.AdvancedClose %>
        </asp:LinkButton>
    </div>
    <div class="rsAdvContentWrapper">
        <%-- Scroll container - when the form height exceeds MaximumHeight scrollbars will appear on this element--%>
        <div class="rsAdvOptionsScroll">
            <asp:Panel runat="server" ID="AdvancedEditOptionsPanel" CssClass="rsAdvOptions">
                <asp:Panel runat="server" ID="AdvancedControlsPanel" CssClass="rsAdvMoreControls">
                    
                    <asp:Panel runat="server" ID="ResourceControls">
                        <%-- RESOURCE CONTROLS --%>
                        <ul class="rsResourceControls">
                            <li>
                                <asp:Label runat="server" ID="SubTitle" style="font-weight:bold;"></asp:Label>
                            </li>
                            <li>
                                <!-- Resource controls should follow the convention Res[Resource Name] for ID -->
                                <scheduler:ResourceControl runat="server" ID="ResShift" Type="Shift" Label="Shift:"
                                    Skin='<%# Owner.Skin %>' />
                            </li>
                            <li style="display:none;">
                                <scheduler:ResourceControl runat="server" ID="ResDeviceUnit" Type="DeviceUnit" Label="DeviceUnit:"
                                    Skin='<%# Owner.Skin %>' />
                            </li>
                            <!-- Optionally add more ResourceControl instances here -->
                        </ul>
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel runat="server" ID="BasicControlsPanel" CssClass="rsAdvBasicControls" OnDataBinding="BasicControlsPanel_DataBinding">
                    <telerik:RadTextBox runat="server" ID="SubjectText" Width="100%" style="display:none;" Label='' />
                    
                    <ul class="rsTimePickers">
                        <li class="rsTimePick">
                            <label for='<%= StartDate.ClientID %>_dateInput_text'>
                                <%= Owner.Localization.AdvancedFrom %></label><%--
							    Leaving a newline here will affect the layout, so we use a comment instead.
                                --%><telerik:RadDatePicker runat="server" ID="StartDate" CssClass="rsAdvDatePicker"
                                    Width="83px" SharedCalendarID="SharedCalendar" Skin='<%# Owner.Skin %>' Culture='<%# Owner.Culture %>'
                                    MinDate="1900-01-01">
                                    <DatePopupButton Visible="False" />
                                    <DateInput ID="DateInput2" runat="server" DateFormat='<%# Owner.AdvancedForm.DateFormat %>'
                                        EmptyMessageStyle-CssClass="riError" EmptyMessage=" " EnableSingleInputRendering="false"/>
                                </telerik:RadDatePicker>
                            <%--
							
                            --%><telerik:RadTimePicker runat="server" ID="StartTime" CssClass="rsAdvTimePicker"
                                Width="65px" Skin='<%# Owner.Skin %>' Culture='<%# Owner.Culture %>'>
                                <DateInput ID="DateInput3" runat="server" EmptyMessageStyle-CssClass="riError" EmptyMessage=" " EnableSingleInputRendering="false" />
                                <TimePopupButton Visible="false" />
                                <TimeView ID="TimeView1" runat="server" Columns="2" ShowHeader="false" StartTime="08:00"
                                    EndTime="18:00" Interval="00:30" />
                            </telerik:RadTimePicker>
                        </li>
                        <li class="rsTimePick">
                            <label for='<%= EndDate.ClientID %>_dateInput_text'>
                                <%= Owner.Localization.AdvancedTo%></label><%--
							
                                --%><telerik:RadDatePicker runat="server" ID="EndDate" CssClass="rsAdvDatePicker"
                                    Width="83px" SharedCalendarID="SharedCalendar" Skin='<%# Owner.Skin %>' Culture='<%# Owner.Culture %>'
                                    MinDate="1900-01-01">
                                    <DatePopupButton Visible="False" />
                                    <DateInput ID="DateInput4" runat="server" DateFormat='<%# Owner.AdvancedForm.DateFormat %>'
                                        EmptyMessageStyle-CssClass="riError" EmptyMessage=" " EnableSingleInputRendering="false"/>
                                </telerik:RadDatePicker>
                            <%--
							
                            --%><telerik:RadTimePicker runat="server" ID="EndTime" CssClass="rsAdvTimePicker"
                                Width="65px" Skin='<%# Owner.Skin %>' Culture='<%# Owner.Culture %>'>
                                <DateInput ID="DateInput5" runat="server" EmptyMessageStyle-CssClass="riError" EmptyMessage=" " EnableSingleInputRendering="false"/>
                                <TimePopupButton Visible="false" />
                                <TimeView ID="TimeView2" runat="server" Columns="2" ShowHeader="false" StartTime="08:00"
                                    EndTime="18:00" Interval="00:30" />
                            </telerik:RadTimePicker>
                        </li>
                        <li class="rsAllDayWrapper">
                            <asp:CheckBox runat="server" ID="AllDayEvent" CssClass="rsAdvChkWrap" Checked="false" />
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
                </asp:Panel>
                <span class="rsAdvResetExceptions">
                    <asp:LinkButton runat="server" ID="ResetExceptions" OnClick="ResetExceptions_OnClick" />
                </span>
                <telerik:RadSchedulerRecurrenceEditor runat="server" ID="AppointmentRecurrenceEditor" />
                <asp:HiddenField runat="server" ID="OriginalRecurrenceRule" />
                <telerik:RadCalendar runat="server" ID="SharedCalendar" Skin='<%# Owner.Skin %>'
                    CultureInfo='<%# Owner.Culture %>' ShowRowHeaders="false" RangeMinDate="1900-01-01" />
            </asp:Panel>
        </div>
        <asp:Panel runat="server" ID="ButtonsPanel" CssClass="rsAdvancedSubmitArea">
            <div class="rsAdvButtonWrapper">
                <asp:LinkButton runat="server" ID="UpdateButton" CssClass="rsAdvEditSave">
					<span><%= Owner.Localization.Save %></span>
                </asp:LinkButton>
                <asp:LinkButton runat="server" ID="CancelButton" CssClass="rsAdvEditCancel" CommandName="Cancel"
                    CausesValidation="false">
					<span><%= Owner.Localization.Cancel %></span>
                </asp:LinkButton>
            </div>
        </asp:Panel>
    </div>
</div>
