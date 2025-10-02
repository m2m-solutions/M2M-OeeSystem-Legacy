<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleListControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Admin.ArticleListControl" %>
<%@ Register src="../Common/ResponseControl.ascx" tagname="ResponseControl" tagprefix="uc1" %>
<div class="content">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="310px" Width="100%">
        <uc1:ResponseControl ID="ucResponse" runat="server" />
        <telerik:RadGrid ID="gridArticles" runat="server" AllowMultiRowEdit="True" Height="310" AutoGenerateColumns="False" GridLines="None" OnNeedDataSource="gridArticles_NeedDataSource" OnItemCreated="gridArticles_ItemCreated" OnItemDataBound="gridArticles_ItemDataBound" OnInsertCommand="gridArticles_InsertCommand" OnDeleteCommand="gridArticles_DeleteCommand" OnUpdateCommand="gridArticles_UpdateCommand">
		    <MasterTableView NoMasterRecordsText="<%$ DataCenter:Warning.EmptyRecord.Articles %>" CommandItemDisplay="Top" DataKeyNames="ArticleNumber" EditMode="InPlace">
		        <Columns>
				    <telerik:GridBoundColumn DataField="ArticleNumber" HeaderText="<%$ DataCenter:Article %>" MaxLength="20" UniqueName="ArticleNumber" ItemStyle-CssClass="maximize" >
				        <HeaderStyle Width="150px" />
				    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ToolNumber" HeaderText="<%$ DataCenter:ToolNumber %>" MaxLength="20" UniqueName="ToolNumber" >
				        <HeaderStyle Width="150px" />
				    </telerik:GridBoundColumn>
				    <telerik:GridBoundColumn DataField="IdealRunRate" DataType="System.Int32" MaxLength="8" HeaderText="<%$ DataCenter:IdealCycleTimeOrPace %>" UniqueName="IdealRunRate" >
				    </telerik:GridBoundColumn>
				    <telerik:GridTemplateColumn DataField="RunRateUnit"  HeaderText="<%$ DataCenter:Unit %>" UniqueName="RunRateUnit" >
				        <HeaderStyle Width="150px" />
					    <ItemTemplate>
					       <asp:Label id="lbRunRateUnit" runat="server">
						      <%# DataBinder.Eval(Container.DataItem, "RunRateUnit") %>
					       </asp:Label>
					    </ItemTemplate>
					    <EditItemTemplate>
					       <asp:DropDownList id="rcbRunRateUnit" runat="server">
					       <asp:ListItem Selected="true" Text="<%$ DataCenter:RunRateUnit.CycleTimeInMilliSeconds %>" Value="CycleTimeInMilliSeconds"></asp:ListItem>
					       <asp:ListItem Text="<%$ DataCenter:RunRateUnit.CyclesPerHour %>" Value="CyclesPerHour"></asp:ListItem>
					       <asp:ListItem Text="<%$ DataCenter:RunRateUnit.CyclesPerMinute %>" Value="CyclesPerMinute"></asp:ListItem>
					       </asp:DropDownList>
					    </EditItemTemplate>
				    </telerik:GridTemplateColumn>
				    <telerik:GridBoundColumn ReadOnly="true" HeaderText="<%$ DataCenter:LastModified %>" DataField="LastModifiedIdealRunRate" UniqueName="LastModified" DataType="System.DateTime">
				        <HeaderStyle Width="150px" />
				    </telerik:GridBoundColumn>
				    <telerik:GridEditCommandColumn ButtonType="ImageButton" CancelText="<%$ DataCenter:Cancel %>" InsertText="<%$ DataCenter:Save %>" EditText="<%$ DataCenter:Edit %>" UpdateText="<%$ DataCenter:Save %>">
				        <HeaderStyle Width="50px" />
				    </telerik:GridEditCommandColumn>
				    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" Text="<%$ DataCenter:Delete %>" UniqueName= "Delete" >
				        <HeaderStyle Width="100px" />
				    </telerik:GridButtonColumn>
			    </Columns>
			    <CommandItemSettings AddNewRecordText="<%$ DataCenter:AddNewArticle %>"
                    ShowAddNewRecordButton="True" ShowRefreshButton="False" />
		    </MasterTableView>
		    <ClientSettings EnableRowHoverStyle="true">
	                <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                </ClientSettings>
	    </telerik:RadGrid>
	</telerik:RadAjaxPanel>
</div>
