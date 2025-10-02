<%@ Control Language="C#" AutoEventWireup="True" Inherits="SchedulerTemplatesCS.CustomAttributeControl" Codebehind="CustomAttributeControl.ascx.cs" %>

<%--
	This is a simple custom control used for editing custom attributes.
	It contains only a label and a text-box.
	
	Additional validation logic or styling may be applied in accordance to the type
	of the edited attribute.
--%>

<asp:Label runat="server" ID="AttributeLabel" AssociatedControlID="AttributeValue" Text='<%# Label %>' />
<asp:TextBox runat="server" ID="AttributeValue" Text='<%# Value %>' CssClass="rsAdvInput" />
