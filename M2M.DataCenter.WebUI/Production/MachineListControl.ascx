<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MachineListControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Production.MachineListControl" %>
<script language="javascript" type="text/javascript">
	<!--
		function RowClick(sender, eventArgs)   
		{   
		   window.location.href = "MachinePage.aspx?DivisionId=" + eventArgs.getDataKeyValue("DivisionId") + "&MachineId=" + eventArgs.getDataKeyValue("MachineId");
		}  
	-->
</script>
<style type="text/css"> 

    .rgAltRow, .rgRow 

    { 

        cursor: pointer !important; 

    } 

</style>
<div class="content">
	<telerik:RadGrid ID="gridMachines" HeaderStyle-Font-Size="X-Small" ItemStyle-Font-Size="X-Small" AlternatingItemStyle-Font-Size="X-Small" runat="server" PageSize="50" AllowPaging="True" AutoGenerateColumns="False" GridLines="None" OnItemDataBound="gridMachines_ItemDataBound" OnNeedDataSource="gridMachines_NeedDataSource">
		<MasterTableView AllowCustomPaging="false" ClientDataKeyNames="MachineId,DivisionId" NoMasterRecordsText="<%$ DataCenter:Warning.EmptyRecord.Machines %>" DataKeyNames="MachineId">
            <ColumnGroups>
                <telerik:GridColumnGroup HeaderText="<%$ DataCenter:AvailabilityLossExtended %>" Name="AvailabilityLossExtended" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="160px">
                </telerik:GridColumnGroup>
            </ColumnGroups>
			<Columns>
				<telerik:GridBoundColumn DataField="MachineId" ReadOnly="True" UniqueName="MachineId" Display="False" >
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="DisplayName" HeaderText="<%$ DataCenter:Machine %>" ReadOnly="True" UniqueName="DisplayName">
					<ItemStyle Font-Bold="true" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="AvailabilityAsString" HeaderText="<%$ DataCenter:Availability %>" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center" ReadOnly="True" UniqueName="AvailabilityAsString">
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="AvailabilityLossAsString" HeaderText="<%$ DataCenter:AvailabilityLoss.Abbr %>" ColumnGroupName="AvailabilityLossExtended" ReadOnly="True" UniqueName="AvailabilityLoss">
					<ItemStyle HorizontalAlign="Center" BackColor="LightGray" />
                    <HeaderStyle HorizontalAlign="Center" />
               </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="AvailabilityLossBasedOnActualStopsAsString" HeaderText="<%$ DataCenter:AvailabilityLossBasedOnActualStops.Abbr %>" ColumnGroupName="AvailabilityLossExtended" ReadOnly="True" UniqueName="AvailabilityLossBasedOnActualStops">
					<ItemStyle HorizontalAlign="Center" BackColor="LightGray" />
                    <HeaderStyle HorizontalAlign="Center" />
				</telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="AvailabilityLossBasedOnFlowErrorsAsString" HeaderText="<%$ DataCenter:AvailabilityLossBasedOnFlowErrors.Abbr %>" ColumnGroupName="AvailabilityLossExtended" ReadOnly="True" UniqueName="AvailabilityLossBasedOnFlowErrors">
					<ItemStyle HorizontalAlign="Center" BackColor="LightGray" />
                    <HeaderStyle HorizontalAlign="Center" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="PerformanceAsString" HeaderText="<%$ DataCenter:Performance %>" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" ReadOnly="True" UniqueName="PerformanceAsString">
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="QualityAsString" HeaderText="<%$ DataCenter:Quality %>" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px" ReadOnly="True" UniqueName="QualityAsString">
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="OEEAsString" HeaderText="<%$ DataCenter:Oee %>" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center" ReadOnly="True" UniqueName="OEEAsString">
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn HeaderText="<%$ DataCenter:Status %>" ReadOnly="True" HeaderStyle-Width="90px" UniqueName="Status">
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn HeaderText="<%$ DataCenter:ArticleOrActiveStop %>" HeaderStyle-Width="120px" ReadOnly="True" UniqueName="ArticleNumberOrActiveStop">
				</telerik:GridBoundColumn>
           </Columns>
			<PagerStyle Mode="NextPrevAndNumeric" PagerTextFormat="<%$ DataCenter:Grid.PagerTextFormat %>" PageSizeLabelText="<%$ DataCenter:Grid.PageSizeLabelText %>"  />
		</MasterTableView>
		<ClientSettings EnableRowHoverStyle="True">
			<ClientEvents OnRowClick="RowClick"	 />
			<Selecting AllowRowSelect="True" />
		</ClientSettings>
	</telerik:RadGrid>
</div>
