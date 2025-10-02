<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacilityControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Admin.FacilityControl" %>
<%@ Register Src="DivisionListControl.ascx" TagName="DivisionListControl" TagPrefix="uc1" %>
<div class="subContent">
	<div class="divEvents">
		<uc1:DivisionListControl id="ucDivisionListControl" runat="server">
		</uc1:DivisionListControl>
	</div>
	<div class="divider"></div>
</div>