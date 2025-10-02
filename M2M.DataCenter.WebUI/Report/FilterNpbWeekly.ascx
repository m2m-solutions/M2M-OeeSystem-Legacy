<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilterNpbWeekly.ascx.cs" Inherits="M2M.DataCenter.WebUI.Report.FilterNpbWeekly" %>
<div class="filterView" style="height: 40px;" >
	<div class="item" style="top: 0px; left: 0px">
		<div class="label">
			<asp:Label ID="lbDivision" runat="server" Text="<%$ DataCenter:Npb.Module#: %>"></asp:Label>
		</div>
		<div class="input">
			<telerik:RadComboBox ID="Modules" Width="160px" DropDownAutoWidth="Enabled" Skin="Default" AutoPostBack="False" runat="server">
					<CollapseAnimation Duration="200" Type="OutQuint" />
				</telerik:RadComboBox>
		</div>
	</div>
    <div class="item" style="top: 0px; left: 175px">
		<div class="label">
			<asp:Label ID="lbYear" runat="server" Text="<%$ DataCenter:Year#: %>"></asp:Label>
		</div>
			<div class="input">
                <telerik:RadComboBox ID="Years" DropDownAutoWidth="Enabled" Width="60px" Skin="Default" AutoPostBack="False" runat="server">
					<CollapseAnimation Duration="200" Type="OutQuint" />
				</telerik:RadComboBox>
		</div>
	</div>
    <div class="item" style="top: 0px; left: 250px">
		<div class="label">
			<asp:Label ID="lbWeek" runat="server" Text="<%$ DataCenter:Week#: %>"></asp:Label>
		</div>
			<div class="input">
                <telerik:RadComboBox ID="Weeks" DropDownAutoWidth="Enabled" Width="60px" Skin="Default" AutoPostBack="False" runat="server">
					<CollapseAnimation Duration="200" Type="OutQuint" />
				</telerik:RadComboBox>
		</div>
	</div>
	<div class="last" style="top: 15px; left: 325px">
		<div class="button">
			<asp:Button ID="btnRefresh" runat="server" CssClass="buttonSmallWhiteOnWhite" Text="<%$ DataCenter:Update %>" OnClick="btnRefresh_Click" />
		</div>
	</div>
	<div class="divider"></div>
</div>
<div class="divider"></div>