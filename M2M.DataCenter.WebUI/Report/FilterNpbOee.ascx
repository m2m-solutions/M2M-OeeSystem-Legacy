<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilterNpbOee.ascx.cs" Inherits="M2M.DataCenter.WebUI.Report.FilterNpbOee" %>
<div class="filterView" style="height: 40px;" >
	<div class="item" style="top: 0px; left: 0px">
		<div class="label">
			<asp:Label ID="lbDivision" runat="server" Text="<%$ DataCenter:Division#: %>"></asp:Label>
		</div>
		<div class="input">
			<telerik:RadComboBox ID="Divisions" Width="160px" DropDownAutoWidth="Enabled" Skin="Default" AutoPostBack="False" runat="server">
					<CollapseAnimation Duration="200" Type="OutQuint" />
				</telerik:RadComboBox>
		</div>
	</div>
    <div class="item" style="top: 0px; left: 175px">
		<div class="label">
			<asp:Label ID="lbYear" runat="server" Text="<%$ DataCenter:RangeStart#: %>"></asp:Label>
		</div>
			<div class="input">
                <telerik:RadDateTimePicker ID="dtFrom" Width="200px" runat="server" Skin="Default" AutoPostBack="False">
														</telerik:RadDateTimePicker>
		</div>
	</div>
    <div class="item" style="top: 0px; left: 400px">
		<div class="label">
			<asp:Label ID="lbWeek" runat="server" Text="<%$ DataCenter:RangeEnd#: %>"></asp:Label>
		</div>
			<div class="input">
                <telerik:RadDateTimePicker ID="dtTo" Width="200px" runat="server" Skin="Default" AutoPostBack="False">
														</telerik:RadDateTimePicker>
		</div>
	</div>
	<div class="last" style="top: 15px; left: 665px">
		<div class="button">
			<asp:Button ID="btnRefresh" runat="server" CssClass="buttonSmallWhiteOnWhite" Text="<%$ DataCenter:Update %>" OnClick="btnRefresh_Click" />
		</div>
	</div>
	<div class="divider"></div>
</div>
<div class="divider"></div>