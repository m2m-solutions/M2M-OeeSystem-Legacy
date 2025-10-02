<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeviceUnitListControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Production.DeviceUnitListControl" %>
<style type="text/css"> 

    .rgAltRow, .rgRow 

    { 

        cursor: pointer !important; 

    } 

</style>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
	<script language="javascript" type="text/javascript">
	    
			function RowClick(sender, eventArgs)   
			{ 
			  
			   window.location.href = "/DivisionPage.aspx?DivisionId=" + eventArgs.getDataKeyValue("DivisionId");
			}
		
	</script>
</telerik:RadCodeBlock>
<div class="content">
	<telerik:RadGrid ID="gridDivisions" runat="server" PageSize="20" AllowPaging="True" Skin="Default" AutoGenerateColumns="False" GridLines="None" OnItemDataBound="gridDivisions_ItemDataBound" OnNeedDataSource="gridDivisions_NeedDataSource"  OnDetailTableDataBind="gridDivisions_DetailTableDataBind">
		<MasterTableView  NoMasterRecordsText="<%$ DataCenter:Warning.EmptyRecord.Divisions %>" Name="Divisions" ClientDataKeyNames="DivisionId" DataKeyNames="DivisionId">
			<Columns>
				<telerik:GridBoundColumn DataField="DivisionId" ReadOnly="True" UniqueName="DivisionId" Display="False" >
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="DisplayName" HeaderText="<%$ DataCenter:Division %>" ReadOnly="True" UniqueName="DisplayName">
					<ItemStyle Font-Bold="True" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="AvailabilityAsString" HeaderText="<%$ DataCenter:AvailabilityWithAbbr %>" ReadOnly="True" UniqueName="AvailabilityAsString">
					<ItemStyle HorizontalAlign="Right" />
					<HeaderStyle HorizontalAlign="Right" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="PerformanceAsString" HeaderText="<%$ DataCenter:PerformanceWithAbbr %>" ReadOnly="True" UniqueName="PerformanceAsString">
					<ItemStyle HorizontalAlign="Right" />
					<HeaderStyle HorizontalAlign="Right" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="QualityAsString" HeaderText="<%$ DataCenter:QualityWithAbbr %>" ReadOnly="True" UniqueName="QualityAsString">
					<ItemStyle HorizontalAlign="Right" />
					<HeaderStyle HorizontalAlign="Right" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="OEEAsString" HeaderText="<%$ DataCenter:Oee %>" ReadOnly="True" UniqueName="OEEAsString">
					<ItemStyle HorizontalAlign="Right" />
					<HeaderStyle HorizontalAlign="Right" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="Trend" DataType="System.Decimal" Display="False" ReadOnly="True" UniqueName="Trend">
				</telerik:GridBoundColumn>
			</Columns>
			<PagerStyle Mode="NextPrevAndNumeric" PagerTextFormat="<%$ DataCenter:Grid.PagerTextFormat %>" PageSizeLabelText="<%$ DataCenter:Grid.PageSizeLabelText %>"  />
		</MasterTableView>
		<ClientSettings EnableRowHoverStyle="True">
			<ClientEvents OnRowClick="RowClick"	 />
			<Selecting AllowRowSelect="True" />
			<Resizing AllowColumnResize="True" />
		</ClientSettings>
	</telerik:RadGrid>
</div>