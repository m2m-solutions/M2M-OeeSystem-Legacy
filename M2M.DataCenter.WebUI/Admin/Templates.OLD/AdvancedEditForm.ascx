<%@ Control Language="C#" AutoEventWireup="True" Inherits="SchedulerTemplatesCS.AdvancedEditForm" Codebehind="AdvancedEditForm.ascx.cs" %>
<%@ Register TagPrefix="scheduler" TagName="AdvancedForm" Src="AdvancedForm.ascx" %>

<%--
	This is the advanced edit template. It defines the basic structure of the template and
	hosts the AdvancedForm, which contains the actual input controls for description,
	start time, end time, recurrence parameters, attributes and resources.
	
	In order to be used as an edit template, this control contains the update and cancel buttons.
--%>

<div class="rsAdvancedEdit">
	<scheduler:AdvancedForm	runat="server" ID="AdvancedForm1"
							Subject='<%# Bind("Subject") %>'
							Start='<%# Bind("Start") %>'
							End='<%# Bind("End") %>'
							RecurrenceRuleText='<%# Bind("RecurrenceRule") %>'
							 />
	<asp:Panel runat="server" ID="ButtonsPanel" CssClass="rsAdvancedSubmitArea">
		<div class="rsAdvButtonWrapper">
			<asp:LinkButton
				runat="server" ID="UpdateButton"
				CssClass="rsAdvEditSave"
				CommandName="Update">
				<span><%= Owner.Localization.Save %></span>
			</asp:LinkButton>

			<asp:LinkButton
				runat="server" ID="CancelButton"
				CssClass="rsAdvEditCancel"
				CommandName="Cancel"
				CausesValidation="false">
				<span><%= Owner.Localization.Cancel %></span>
			</asp:LinkButton>
		</div>
	</asp:Panel>
</div>
