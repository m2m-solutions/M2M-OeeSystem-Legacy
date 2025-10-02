<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilterDivisionStoppageWeekly.ascx.cs" Inherits="M2M.DataCenter.WebUI.Report.FilterDivisionStoppageWeekly" %>

<div class="filterView" style="height: 40px;" >
	<div class="item" style="top: 0px; left: 00px">
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
    <div class="item" style="top: 0px; left: 385px">
		<div class="label">
			<asp:Label ID="Label2" runat="server" Text="<%$ DataCenter:Week#: %>"></asp:Label>
		</div>
			<div class="input">
                <telerik:RadComboBox ID="Weeks" DropDownAutoWidth="Enabled" Width="60px" Skin="Default" AutoPostBack="False" runat="server">
					<CollapseAnimation Duration="200" Type="OutQuint" />
				</telerik:RadComboBox>
		</div>
	</div>
    <div class="item" style="top: 0px; left: 460px">
		<div class="label">
			<asp:Label ID="lbWeek" runat="server" Text="<%$ DataCenter:Categories#: %>"></asp:Label>
		</div>
			<div class="input">
                <telerik:RadComboBox ID="SelectCategories" runat="server" Width="140px" 
                    DropDownAutoWidth="Enabled" CheckBoxes="true" 
                    EnableCheckAllItemsCheckBox="True" 
                    EmptyMessage="<%$ DataCenter:NoCategoriesSelected %>" 
                    onitemdatabound="SelectCategories_ItemDataBound" >
    <Localization AllItemsCheckedString="<%$ DataCenter:AllCategoriesSelected %>" CheckAllString="<%$ DataCenter:SelectAll %>" ItemsCheckedString="<%$ DataCenter:CategoriesCheckedString %>"  />
                                                             
                                                        </telerik:RadComboBox>
		</div>
	</div>
    <div class="item" style="top: 0px; left: 615px">
		<div class="label">
			<asp:Label ID="Label1" runat="server" Text="<%$ DataCenter:OrderBy#: %>"></asp:Label>
		</div>
        <div class="input">
                <telerik:RadComboBox ID="OrderBys" DropDownAutoWidth="Enabled" Width="100px" Skin="Default" AutoPostBack="False" runat="server">
					<CollapseAnimation Duration="200" Type="OutQuint" />
				</telerik:RadComboBox>
		</div>
	</div>
	<div class="last" style="top: 15px; left: 730px">
		<div class="button">
			<asp:Button ID="btnRefresh" runat="server" CssClass="buttonSmallWhiteOnWhite" Text="<%$ DataCenter:Update %>" OnClick="btnRefresh_Click" />
		</div>
	</div>
	<div class="divider"></div>
</div>
<div class="divider"></div>
