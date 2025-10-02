<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilterMachineOeeDaily.ascx.cs" Inherits="M2M.DataCenter.WebUI.Report.FilterMachineOeeDaily" %>

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
			<asp:Label ID="Label2" runat="server" Text="<%$ DataCenter:Machine#: %>"></asp:Label>
		</div>
		<div class="input">
			<telerik:RadComboBox ID="Machines" Width="160px" DropDownAutoWidth="Enabled" Skin="Default" AutoPostBack="False" runat="server">
					<CollapseAnimation Duration="200" Type="OutQuint" />
				</telerik:RadComboBox>
		</div>
	</div>
    <div class="item" style="top: 0px; left: 350px">
		<div class="label">
			<asp:Label ID="lbShift" runat="server" Text="<%$ DataCenter:Shift#: %>"></asp:Label>
		</div>
			<div class="input">
			<telerik:RadComboBox ID="ProductionShifts" DropDownAutoWidth="Enabled" Width="120px" Skin="Default" AutoPostBack="False" runat="server">
					<CollapseAnimation Duration="200" Type="OutQuint" />
				</telerik:RadComboBox>
		</div>
	</div>
	<div class="item" style="top: 0px; left: 485px">
		<div class="label">
			<asp:Label ID="lbDate" runat="server" Text="<%$ DataCenter:Day#: %>"></asp:Label>
		</div>
			<div class="input">
                <telerik:RadDatePicker ID="dtDate" Width="100px" runat="server" Skin="Default" AutoPostBack="False">
														</telerik:RadDatePicker>
		</div>
	</div>
    <div class="item" style="top: 0px; left: 600px">
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
    <div class="item" style="top: 0px; left: 755px">
		<div class="label">
			<asp:Label ID="Label1" runat="server" Text="<%$ DataCenter:OrderBy#: %>"></asp:Label>
		</div>
        <div class="input">
                <telerik:RadComboBox ID="OrderBys" DropDownAutoWidth="Enabled" Width="100px" Skin="Default" AutoPostBack="False" runat="server">
					<CollapseAnimation Duration="200" Type="OutQuint" />
				</telerik:RadComboBox>
		</div>
	</div>
	<div class="last" style="top: 15px; left: 870px">
		<div class="button">
			<asp:Button ID="btnRefresh" runat="server" CssClass="buttonSmallWhiteOnWhite" Text="<%$ DataCenter:Update %>" OnClick="btnRefresh_Click" />
		</div>
	</div>
	<div class="divider"></div>
</div>
<div class="divider"></div>
<telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Divisions">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Machines" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>