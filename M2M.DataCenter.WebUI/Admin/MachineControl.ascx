<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MachineControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Admin.MachineControl" %>
<%@ Register Src="ArticleListControl.ascx" TagName="ArticleListControl" TagPrefix="uc3" %>
<%@ Register Src="MachineEditControl.ascx" TagName="MachineEditControl" TagPrefix="uc1" %>
<%@ Register src="CategoryListControl.ascx" tagname="CategoryListControl" tagprefix="uc4" %>
<div class="subContent">
	<div class="divInfo">
		<div class="divInfoLine">
			<div class="label">
			<asp:Literal ID="Literal1" runat="server" Text="<%$ DataCenter:Machine#: %>" />
			</div>
			<telerik:RadComboBox ID="rcbMachine" AutoPostBack="true" runat="server" Skin="Default" OnSelectedIndexChanged="rcbMachine_SelectedIndexChanged">
			</telerik:RadComboBox>
		</div>
	</div>
	<div class="divider"></div>
	<div class="divFilter">
		<uc1:MachineEditControl id="ucMachineEditControl" runat="server"></uc1:MachineEditControl>
		
	</div>
	<div class="divider"></div>
	<div class="divEvents">
		<uc4:CategoryListControl ID="ucCategoryListControl" runat="server" />
    </div>
	<div class="divider"></div>
	<div class="divEvents">
		<uc3:ArticleListControl ID="ucArticleListControl" runat="server" />
	</div>
	<div class="divider"></div>
</div>