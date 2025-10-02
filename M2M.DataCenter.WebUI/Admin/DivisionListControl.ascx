<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DivisionListControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Admin.DivisionListControl" %>

<script language="javascript" type="text/javascript">
	<!--
		function RowClick(sender, eventArgs)   
		{   
		   window.location.href = "AdministrationPage.aspx?DivisionId=" + eventArgs.getDataKeyValue("DivisionId");
		}
		  
	-->
</script>
<div class="content">
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="220px" Width="100%">
	<telerik:RadGrid ID="gridDivisions" runat="server" Height="220px" PageSize="20" AllowPaging="True" AutoGenerateColumns="False" GridLines="None" OnNeedDataSource="gridDivisions_NeedDataSource">
		<MasterTableView ClientDataKeyNames="DivisionId" NoMasterRecordsText="<%$ DataCenter:Warning.EmptyRecord.Divisions %>" AllowAutomaticInserts="False" AllowAutomaticUpdates="False" CommandItemDisplay="None" DataKeyNames="DivisionId">
		    <Columns>
				<telerik:GridBoundColumn DataField="DivisionId" HeaderText="<%$ DataCenter:Id %>" ReadOnly="True" UniqueName="DivisionId" >
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="DisplayName" HeaderText="<%$ DataCenter:Division %>" ReadOnly="True" UniqueName="DisplayName">
					<ItemStyle Font-Bold="True"/>
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="Notes" HeaderText="<%$ DataCenter:Description %>" ReadOnly="True" UniqueName="Notes">
				</telerik:GridBoundColumn>
			</Columns>
			<PagerStyle Mode="NextPrevAndNumeric" PagerTextFormat="<%$ DataCenter:Grid.PagerTextFormat %>" PageSizeLabelText="<%$ DataCenter:Grid.PageSizeLabelText %>" />
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
