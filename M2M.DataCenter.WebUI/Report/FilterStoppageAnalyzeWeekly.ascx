<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilterStoppageAnalyzeWeekly.ascx.cs" Inherits="M2M.DataCenter.WebUI.Report.FilterStoppageAnalyzeWeekly" %>

<div class="filterView" style="height: 40px;" >
	<div class="item" style="top: 0px; left: 0px">
		<div class="label">
			<asp:Label ID="lbDivision" runat="server" Text="<%$ DataCenter:Division#: %>"></asp:Label>
		</div>
		<div class="input">
			<telerik:RadComboBox ID="Divisions" Width="160px" DropDownAutoWidth="Enabled" 
                Skin="Default" AutoPostBack="True" runat="server" 
                onselectedindexchanged="Divisions_SelectedIndexChanged">
					<CollapseAnimation Duration="200" Type="OutQuint" />
				</telerik:RadComboBox>
		</div>
	</div>
    <div class="item" style="top: 0px; left: 175px">
		<div class="label">
			<asp:Label ID="lbShift" runat="server" Text="<%$ DataCenter:Shift#: %>"></asp:Label>
		</div>
			<div class="input">
			<telerik:RadComboBox ID="ProductionShifts" DropDownAutoWidth="Enabled" Width="120px" Skin="Default" AutoPostBack="False" runat="server">
					<CollapseAnimation Duration="200" Type="OutQuint" />
				</telerik:RadComboBox>
		</div>
	</div>
	<div class="item" style="top: 0px; left: 310px">
		<div class="label">
			<asp:Label ID="lbYear" runat="server" Text="<%$ DataCenter:Year#: %>"></asp:Label>
		</div>
			<div class="input">
                <telerik:RadComboBox ID="Years" DropDownAutoWidth="Enabled" Width="60px" Skin="Default" AutoPostBack="False" runat="server">
					<CollapseAnimation Duration="200" Type="OutQuint" />
				</telerik:RadComboBox>
		</div>
	</div>
    <div class="item" style="top: 0px; left: 375px">
		<div class="label">
			<asp:Label ID="Label1" runat="server" Text="<%$ DataCenter:Week#: %>"></asp:Label>
		</div>
			<div class="input">
                <telerik:RadComboBox ID="Weeks" DropDownAutoWidth="Enabled" Width="60px" Skin="Default" AutoPostBack="False" runat="server">
					<CollapseAnimation Duration="200" Type="OutQuint" />
				</telerik:RadComboBox>
		</div>
	</div>
    <div class="item" style="top: 0px; left: 450px">
		<div class="label">
			<asp:Label ID="lbWeek" runat="server" Text="<%$ DataCenter:Category#: %>"></asp:Label>
		</div>
			<div class="input">
                <telerik:RadComboBox ID="Categories" Width="140px" DropDownAutoWidth="Enabled" 
                Skin="Default" AutoPostBack="True" runat="server" 
                    onselectedindexchanged="Categories_SelectedIndexChanged" >
					<CollapseAnimation Duration="200" Type="OutQuint" />
				</telerik:RadComboBox>
		</div>
	</div>
    <div class="item" style="top: 0px; left: 605px">
		<div class="label">
			<asp:Label ID="Label2" runat="server" Text="<%$ DataCenter:DowntimeCause#: %>"></asp:Label>
		</div>
			<div class="input">
                <telerik:RadComboBox ID="StopReasons" Width="200px" DropDownAutoWidth="Enabled" 
                Skin="Default" runat="server"  >
					<CollapseAnimation Duration="200" Type="OutQuint" />
				</telerik:RadComboBox>
		</div>
	</div>
    <div class="item" style="top: 0px; left: 820px">
		<div class="label">
			<asp:Label ID="Label3" runat="server" Text="<%$ DataCenter:Show#: %>"></asp:Label>
		</div>
        <div class="input">
                <telerik:RadComboBox ID="ShowTypes" DropDownAutoWidth="Enabled" Width="200px" Skin="Default" AutoPostBack="False" runat="server">
					<CollapseAnimation Duration="200" Type="OutQuint" />
				</telerik:RadComboBox>
		</div>
	</div>
    <div class="last" style="top: 15px; left: 1040px">
		<div class="button">
			<asp:Button ID="btnRefresh" runat="server" CssClass="buttonSmallWhiteOnWhite" Text="<%$ DataCenter:Update %>" OnClick="btnRefresh_Click" />
		</div>
	</div>
	<div class="divider"></div>
</div>
<div class="divider"></div>
<telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server" >
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Divisions">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="StopReasons" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Categories">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="StopReasons" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>