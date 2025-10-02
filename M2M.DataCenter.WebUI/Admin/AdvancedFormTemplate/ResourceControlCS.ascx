<%@ Control Language="C#" AutoEventWireup="true" Inherits="M2M.DataCenter.WebUI.Admin.AdvancedTemplates.ResourceControl" Codebehind="ResourceControlCS.ascx.cs" %>

<%--
	This is a custom control used for editing resources that support single values.
	
	It contains a label and DropDownList.
--%>

<asp:Label runat="server" ID="ResourceLabel" AssociatedControlID="ResourceValue" Text='<%# Label %>' CssClass="rsAdvResourceLabel" /><!--
--><telerik:RadComboBox runat="server" ID="ResourceValue" CssClass="rsAdvResourceValue" Skin='<%# Skin %>' />
