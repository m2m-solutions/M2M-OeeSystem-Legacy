<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventListControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Production.EventListControl" %>
<div class="content">
	<telerik:RadGrid ID="gridEvents" runat="server" HeaderStyle-Font-Size="X-Small" 
        ItemStyle-Font-Size="X-Small" AlternatingItemStyle-Font-Size="X-Small" 
        PageSize="20" AllowCustomPaging="True" Skin="Default" AutoGenerateColumns="False" 
        GridLines="None" OnNeedDataSource="gridEvents_NeedDataSource" 
        OnItemDataBound="gridEvents_ItemDataBound" 
        onprerender="gridEvents_PreRender" AllowPaging="True" 
        onpageindexchanged="gridEvents_PageIndexChanged" 
        onpagesizechanged="gridEvents_PageSizeChanged">
		<MasterTableView NoMasterRecordsText="<%$ DataCenter:Warning.EmptyRecord.Events %>">
			<Columns>
				<telerik:GridBoundColumn DataField="EventId" DataType="System.Guid" ReadOnly="True" UniqueName="Id" Display="False" >
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="EventRaisedAsDateTime" DataType="System.DateTime" HeaderText="<%$ DataCenter:TimeStamp %>" ReadOnly="True" UniqueName="EventRaisedAsDateTime">
<HeaderStyle Width="130px" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="ElapsedTime" DataType="System.TimeSpan" HeaderText="<%$ DataCenter:ElapsedTime %>" ReadOnly="True" UniqueName="ElapsedTime">
<HeaderStyle Width="80px" />
				</telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="MachineId" HeaderText="<%$ DataCenter:Machine%>" ReadOnly="True" UniqueName="MachineId">
                <HeaderStyle Width="80px" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="DisplayName" HeaderText="<%$ DataCenter:Event %>" ReadOnly="True" UniqueName="DisplayName">
					<ItemStyle Font-Bold="True"/>
                    <HeaderStyle Width="220px" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="TagType" HeaderText="<%$ DataCenter:Type %>" ReadOnly="True" UniqueName="TagType">
<HeaderStyle Width="100px" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="Category" HeaderText="<%$ DataCenter:Category %>" ReadOnly="True" UniqueName="Category">
                    <HeaderStyle Width="150px" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="ArticleNumber" HeaderText="<%$ DataCenter:Article %>" ReadOnly="True" UniqueName="ArticleNumber">
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="PaceAsString" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" HeaderText="<%$ DataCenter:Pace %>" ReadOnly="True" UniqueName="PaceAsString">
<HeaderStyle Width="100px" />
				</telerik:GridBoundColumn>
				<telerik:GridBoundColumn DataField="Complete" HeaderText="Comp" ReadOnly="True" UniqueName="Complete" Display="False">
				</telerik:GridBoundColumn>
			</Columns>
			<PagerStyle Mode="NextPrevAndNumeric" PagerTextFormat="<%$ DataCenter:Grid.PagerTextFormat %>" PageSizeLabelText="<%$ DataCenter:Grid.PageSizeLabelText %>" />
		</MasterTableView>
		
	</telerik:RadGrid>
</div>