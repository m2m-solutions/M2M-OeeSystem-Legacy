<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MachineListControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Admin.MachineListControl" %>
<script language="javascript" type="text/javascript">
	<!--
		function RowClick(sender, eventArgs)   
		{   
		   window.location.href = "AdministrationPage.aspx?MachineId=" + eventArgs.getDataKeyValue("MachineId");
		}

	-->
</script>
<div class="content">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="310px" Width="100%">
	<telerik:RadGrid ID="gridMachines" runat="server" Height="310px" PageSize="20" AllowPaging="True" AutoGenerateColumns="False" GridLines="None" OnNeedDataSource="gridMachines_NeedDataSource">
		<MasterTableView ClientDataKeyNames="MachineId" NoMasterRecordsText="<%$ DataCenter:Warning.EmptyRecord.Machines %>" AllowAutomaticInserts="False" AllowAutomaticUpdates="False" CommandItemDisplay="None" DataKeyNames="MachineId">
		   <Columns>
				<telerik:GridBoundColumn DataField="MachineId" HeaderText="<%$ DataCenter:Id %>" ReadOnly="True" UniqueName="MachineId" >
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="DisplayName" HeaderText="<%$ DataCenter:Machine %>" ReadOnly="True" UniqueName="DisplayName">
					<ItemStyle Font-Bold="True" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="Notes" HeaderText="<%$ DataCenter:Description %>" ReadOnly="True" UniqueName="Notes" >
				</telerik:GridBoundColumn>
			</Columns>
			<PagerStyle Mode="NextPrevAndNumeric" PagerTextFormat="<%$ DataCenter:Grid.PagerTextFormat %>" PageSizeLabelText="<%$ DataCenter:Grid.PageSizeLabelText %>"  />
		</MasterTableView>
		<ClientSettings EnableRowHoverStyle="True">
			<ClientEvents OnRowClick="RowClick"	 />
			<Selecting AllowRowSelect="True" />
			<Resizing AllowColumnResize="True" />
			<Scrolling AllowScroll="true" UseStaticHeaders="true" />
		</ClientSettings>
	</telerik:RadGrid>
	</telerik:RadAjaxPanel>
</div>