<%@ Control Language="C#" AutoEventWireup="True" Inherits="SchedulerTemplatesCS.ResourceControl" Codebehind="ResourceControl.ascx.cs" %>

<%--
	This is a custom control used for editing resources that support single values.
	
	It contains a label and DropDownList.
--%>

<asp:Label runat="server" ID="ResourceLabel" AssociatedControlID="ResourceValue" Text='<%# Label %>' CssClass="rsAdvResourceLabel" />
<asp:DropDownList	runat="server" ID="ResourceValue" CssClass="rsAdvResourceValue" />
