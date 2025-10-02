<%@ Control Language="C#" AutoEventWireup="True" Inherits="SchedulerTemplatesCS.AdvancedForm" Codebehind="AdvancedForm.ascx.cs" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="scheduler" TagName="SchedulerDefaultForm" Src="SchedulerDefaultForm.ascx" %>
<%@ Register TagPrefix="scheduler" TagName="CustomAttributeControl" Src="CustomAttributeControl.ascx" %>
<%@ Register TagPrefix="scheduler" TagName="ResourceControl" Src="ResourceControl.ascx" %>
<%@ Register TagPrefix="scheduler" TagName="MultipleValuesResourceControl" Src="MultipleValuesResourceControl.ascx" %>

<%--
	This is the shared edit template. It defines the basic structure of the template and
	hosts the SchedulerDefaultForm, which contains the input controls for Description,
	Start and End time and recurrence parameters.
	
	Additionally, this control contains the custom controls for editing custom attributes
	and resources (with one or many values).
--%>

<div class="rsAdvOptionsScroll">
	<asp:Panel	runat="server" ID="AdvancedEditOptionsPanel"
				CssClass="rsAdvOptions">
		<scheduler:SchedulerDefaultForm	runat="server" ID="SchedulerDefaultForm1"
									Subject='<%# Bind("Subject") %>'
									Start='<%# Bind("Start") %>'
									End='<%# Bind("End") %>'
									RecurrenceRuleText='<%# Bind("RecurrenceRule") %>' />
									
		
	</asp:Panel>
</div>