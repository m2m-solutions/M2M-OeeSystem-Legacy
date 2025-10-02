<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="CategoryListControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Admin.CategoryListControl" %>
<div class="content">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="310px" Width="100%">
    <telerik:RadGrid ID="gridCategories" runat="server" DataSourceID="SqlDataSource4" Height="310px"
        GridLines="None" AllowAutomaticUpdates="True"  >
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="TagId" 
            DataSourceID="SqlDataSource4" CommandItemDisplay="Top" EditMode="InPlace" 
            NoMasterRecordsText="<%$ DataCenter:Warning.EmptyRecord.Alerts %>">
        <CommandItemSettings  AddNewRecordText=""
                ShowAddNewRecordButton="False" ShowRefreshButton="False"></CommandItemSettings>
        <RowIndicatorColumn>
        <HeaderStyle Width="20px"></HeaderStyle>
        </RowIndicatorColumn>
        <ExpandCollapseColumn>
        <HeaderStyle Width="20px"></HeaderStyle>
        </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="TagId" 
                    ReadOnly="True" SortExpression="TagId" 
                    UniqueName="TagId" DataType="System.Guid" Display="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Larm" HeaderText="<%$ DataCenter:Alert %>" 
                    SortExpression="Larm" UniqueName="Larm" ReadOnly="True">
                    <HeaderStyle Width="450px" />
                </telerik:GridBoundColumn>
                <telerik:GridDropDownColumn DataField="CategoryId" SortExpression="Kategori" DataSourceID="SqlDataSource1" 
                    DataType="System.Int32" HeaderText="<%$ DataCenter:Category %>" ListTextField="DisplayName" EmptyListItemText="<%$ DataCenter:NoCategory %>" EmptyListItemValue="0" EnableEmptyListItem="true"
                    ListValueField="CategoryId" UniqueName="Kategori">
                </telerik:GridDropDownColumn>
                <telerik:GridEditCommandColumn ButtonType="ImageButton" CancelText="<%$ DataCenter:Cancel %>"
                    EditText="<%$ DataCenter:Edit %>" UpdateText="<%$ DataCenter:Update %>" UniqueName="EditCommandColumn">
                </telerik:GridEditCommandColumn>
            </Columns>
        <EditFormSettings>
        <EditColumn UniqueName="EditCommandColumn1"></EditColumn>
        </EditFormSettings>
        </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true" >
	            <Scrolling AllowScroll="true" UseStaticHeaders="true" />
            </ClientSettings>
    </telerik:RadGrid>
    </telerik:RadAjaxPanel>
</div> <!--content -->
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    SelectCommand="SELECT [CategoryId], [DisplayName] FROM [EventCategories]" >
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource4" runat="server" 
    SelectCommand="SELECT TagInfo.TagId, TagInfo.DisplayName AS Larm, TagInfo.CategoryId AS CategoryId, EventCategories.DisplayName AS Kategori FROM TagInfo LEFT OUTER JOIN EventCategories ON TagInfo.CategoryId = EventCategories.CategoryId WHERE (TagInfo.MachineId = @MachineId) AND (TagInfo.TagType = 3 OR TagInfo.TagType = 4 OR TagInfo.TagType = 80 ) ORDER BY Larm" 
    
    UpdateCommand="UPDATE TagInfo SET CategoryId = @CategoryId WHERE (TagId = @TagId)" 
    onupdated="SqlDataSource4_Updated" >
        <SelectParameters>
            <asp:SessionParameter Name="MachineId" 
                SessionField="CurrentMachineId" />
        </SelectParameters>
        <UpdateParameters>
            <asp:ControlParameter ControlID="gridCategories" Name="CategoryId" /> 
            <asp:ControlParameter ControlID="gridCategories" Name="TagId" /> 
        </UpdateParameters>
</asp:SqlDataSource>