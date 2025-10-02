<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DivisionListControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Production.DivisionListControl" %>
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

			    window.location.href = "<%= HttpContext.Current.Request.ApplicationPath %>/Production/DivisionPage.aspx?DivisionId=" + eventArgs.getDataKeyValue("DivisionId");
			}
		
	</script>
</telerik:RadCodeBlock>
<div class="content">
	<telerik:RadGrid ID="gridDivisions" runat="server" PageSize="20" AllowPaging="True" Skin="Default" HeaderStyle-Font-Size="X-Small" ItemStyle-Font-Size="X-Small" AlternatingItemStyle-Font-Size="X-Small" AutoGenerateColumns="False" GridLines="None" OnItemDataBound="gridDivisions_ItemDataBound" OnNeedDataSource="gridDivisions_NeedDataSource"  >
		<MasterTableView AllowCustomPaging="false" NoMasterRecordsText="<%$ DataCenter:Warning.EmptyRecord.Divisions %>" Name="Divisions" ClientDataKeyNames="DivisionId" DataKeyNames="DivisionId">
			<ColumnGroups>
                <telerik:GridColumnGroup HeaderText="<%$ DataCenter:AvailabilityLossExtended %>" Name="AvailabilityLoss" HeaderStyle-HorizontalAlign="Center">
                </telerik:GridColumnGroup>
            </ColumnGroups>
			<Columns>
				<telerik:GridBoundColumn DataField="DivisionId" ReadOnly="True" UniqueName="DivisionId" Display="False" >
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="DisplayName" HeaderText="<%$ DataCenter:Division %>" ReadOnly="True" UniqueName="DisplayName">
					<ItemStyle Font-Bold="True" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="AvailabilityAsString" HeaderText="<%$ DataCenter:AvailabilityWithAbbr %>" ReadOnly="True" UniqueName="AvailabilityAsString">
					<ItemStyle HorizontalAlign="Center" />
					<HeaderStyle HorizontalAlign="Center" />
				</telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="AvailabilityLossAsString" HeaderText="<%$ DataCenter:AvailabilityLoss.Abbr %>" ColumnGroupName="AvailabilityLoss" ReadOnly="True" UniqueName="AvailabilityLossAsString">
					<ItemStyle HorizontalAlign="Center"  BackColor="LightGray" />
                    <HeaderStyle HorizontalAlign="Center"  />
               </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="AvailabilityLossBasedOnActualStopsAsString" HeaderText="<%$ DataCenter:AvailabilityLossBasedOnActualStops.Abbr %>" ColumnGroupName="AvailabilityLoss" ReadOnly="True" UniqueName="AvailabilityLossBasedOnActualStopsAsString">
					<ItemStyle HorizontalAlign="Center"  BackColor="LightGray" />
                    <HeaderStyle HorizontalAlign="Center" />
				</telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="AvailabilityLossBasedOnFlowErrorsAsString" HeaderText="<%$ DataCenter:AvailabilityLossBasedOnFlowErrors.Abbr %>" ColumnGroupName="AvailabilityLoss" ReadOnly="True" UniqueName="AvailabilityLossBasedOnFlowErrorsAsString">
					<ItemStyle HorizontalAlign="Center"  BackColor="LightGray" />
                    <HeaderStyle HorizontalAlign="Center" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="PerformanceAsString" HeaderText="<%$ DataCenter:PerformanceWithAbbr %>" ReadOnly="True" UniqueName="PerformanceAsString">
					<ItemStyle HorizontalAlign="Center" />
					<HeaderStyle HorizontalAlign="Center" Width="150px" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="QualityAsString" HeaderText="<%$ DataCenter:QualityWithAbbr %>" ReadOnly="True" UniqueName="QualityAsString">
					<ItemStyle HorizontalAlign="Center" />
					<HeaderStyle HorizontalAlign="Center" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="OEEAsString" HeaderText="<%$ DataCenter:Oee %>" ReadOnly="True" UniqueName="OEEAsString">
					<ItemStyle HorizontalAlign="Center" />
					<HeaderStyle HorizontalAlign="Center" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn HeaderText="<%$ DataCenter:Running %>" ReadOnly="True" UniqueName="Running">
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