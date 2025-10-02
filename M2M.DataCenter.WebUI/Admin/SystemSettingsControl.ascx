<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SystemSettingsControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Admin.SystemSettingsControl" %>
<%@ Register src="../Common/ResponseControl.ascx" tagname="ResponseControl" tagprefix="uc1" %>
<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
<script type="text/javascript">
    var itemIndexCategories;
    var stateCategories = 0;
    function onGridCategoriesCommand(sender, eventArgs) {
        if (eventArgs.get_commandName() == "Delete" && stateCategories == 0) {
            var grid = sender;
            var MasterTable = grid.get_masterTableView();
            itemIndexCategories = eventArgs.get_commandArgument();
            var row = MasterTable.get_dataItems()[itemIndexCategories];
            var cellValue = row.get_cell("DisplayName").innerHTML;
            radconfirm('<%= GetResourceString("Category.DeleteText.Part1") %> ' + cellValue +  ' <%= GetResourceString("Category.DeleteText.Part2") %>' + "<br/><br/>", confirmCallBackCategoriesFn, 300, 120, null, '<%= GetResourceString("DeleteTitle") %>');
            eventArgs.set_cancel(true);
        }

    }

    var itemIndexShifts;
    var stateShifts = 0;
    function onGridShiftsCommand(sender, eventArgs) {
        if (eventArgs.get_commandName() == "Delete" && stateShifts == 0) {
            var grid = sender;
            var MasterTable = grid.get_masterTableView();
            itemIndexShifts = eventArgs.get_commandArgument();
            var row = MasterTable.get_dataItems()[itemIndexShifts];
            var cellValue = row.get_cell("DisplayName").innerHTML;
            radconfirm('<%= GetResourceString("Shift.DeleteText.Part1") %> ' + cellValue + "<br/><br/>", confirmCallBackShiftsFn, 300, 120, null, '<%= GetResourceString("DeleteTitle") %>');
            eventArgs.set_cancel(true);
        }

    }

    function confirmCallBackCategoriesFn(arg) {
        if (arg) {
            if (!stateCategories) {
                stateCategories = 1;
                var masterTable = $find("<%= gridCategories.ClientID %>").get_masterTableView();
                masterTable.fireCommand("Delete", itemIndexCategories);
            }
        }
    }

    function confirmCallBackShiftsFn(arg) {
        if (arg) {
            if (!stateShifts) {
                stateShifts = 1;
                var masterTable = $find("<%= gridShifts.ClientID %>").get_masterTableView();
                masterTable.fireCommand("Delete", itemIndexShifts);
            }
        }
    }
 </script>  
 
</telerik:RadScriptBlock>
<div class="white_frame">
	<div class="header">
		<div class="top">
			<div class="bottom">
				<div class="left">
					<div class="right">
						<div class="bottomleft">
							<div class="bottomright">
								<div class="topleft">
									<div class="topright">
										<div class="content">
										    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="350px" 
                                                width="100%">
                                           
										    <telerik:RadFormDecorator ID="RadFormDecorator1" Runat="server" 
                                                Skin="Windows7" DecoratedControls="CheckBoxes,FieldSet" />
										    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
										    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
                                            </asp:ScriptManagerProxy>
										    <div class="divider" style="height: 10px;"></div>
                                            <asp:Panel ID="pnlUI" GroupingText="<%$ DataCenter:Display %>" runat="server" CssClass="groupBox">
                                                <table style="width: 895px;color:Black;font-weight:normal;">
													<tr>
													<td style="width:200px;">
															<asp:Literal ID="Literal2" runat="server" Text="<%$ DataCenter:FilterStartDate#: %>" /> 
														</td>
														<td >
															<telerik:RadNumericTextBox ID="tbStartDateOffset" Runat="server" 
																DataType="System.Int32" MaxValue="30" MinValue="1" ShowSpinButtons="True" 
																Value="3" Width="86px" CausesValidation="false" >
																<NumberFormat DecimalDigits="0" />
															</telerik:RadNumericTextBox >
															 <asp:Literal ID="Literal8" runat="server" Text="<%$ DataCenter:#-DaysBack %>" /></td>
													</tr>
													<tr>
														
														<td style="width:200px;">
															<asp:Literal ID="Literal3" runat="server" Text="<%$ DataCenter:StoppageGraphGroupCount#: %>" /> 
														</td>
														<td >
															<telerik:RadNumericTextBox ID="tbStoppageGraphGroupCount" Runat="server" 
																DataType="System.Int32" MaxValue="20" MinValue="3" ShowSpinButtons="True" 
																Value="3" Width="86px" CausesValidation="false" >
																<NumberFormat DecimalDigits="0" />
															</telerik:RadNumericTextBox >
															</td>
													</tr>
                                          	    </table>
                                                <div class="divider" style="height: 5px;"></div>
                                            </asp:Panel>
                                            <div class="divider" style="height: 5px;"></div>
                                            <asp:Panel ID="pnlDataCalculation" GroupingText="<%$ DataCenter:PreCalculation %>" runat="server" CssClass="groupBox">
                                                <table style="width: 895px;color:Black;font-weight:normal;float:left;">
													<tr>
														<td style="width:200px;">
															<asp:Literal ID="Literal6" runat="server" Text="<%$ DataCenter:PreCalculationInterval#: %>" />
														</td>
														<td >
															Var
															<telerik:RadNumericTextBox ID="tbCalculatorInterval" Runat="server" 
																DataType="System.Int32" MaxValue="86400" MinValue="1" ShowSpinButtons="True" 
																Value="10" Width="86px" CausesValidation="false" >
																<NumberFormat DecimalDigits="0" />
															</telerik:RadNumericTextBox >
															<asp:Literal ID="Literal7" runat="server" Text="<%$ DataCenter:#-EveryMinute %>" /></td>
													</tr>
												</table>
												<div class="divider" style="height: 5px;"></div>
											</asp:Panel>
                                            
                                           <table style="width: 100%;color:Black;">
												<tr>
													<td style="text-align: right; vertical-align:bottom; ">
														<uc1:ResponseControl ID="ucResponse" runat="server" />
														<asp:Button ID="btnSave"
															runat="server" Text="<%$ DataCenter:Save %>" onclick="btnSave_Click" />
													</td>
												</tr>
											</table>
										</telerik:RadAjaxPanel>	
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="clear">&nbsp;</div></div></div>
        <div class="divider" style="height:10px;"></div>
        <asp:Label runat="server" id="ProductionModeWarning" Visible="false" ForeColor="Red" Text="<%$ DataCenter:ProductionModeShiftWarning %>"></asp:Label>
		<telerik:RadGrid ID="gridShifts" runat="server" DataSourceID="SqlDataSource2" 
                                                    GridLines="None" OnPreRender="gridShifts_PreRender"   
                                                    AllowAutomaticDeletes="True" AllowAutomaticInserts="True" 
                                                    AllowAutomaticUpdates="True" GroupingEnabled="False">
                                                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="ShiftId" 
                                                        DataSourceID="SqlDataSource2" CommandItemDisplay="Top" EditMode="InPlace" 
                                                        NoMasterRecordsText="<%$ DataCenter:Warning.EmptyRecord.Shift %>" >
                                                    <CommandItemSettings 
                                                            AddNewRecordText="<%$ DataCenter:AddNewShift %>" ShowRefreshButton="False"></CommandItemSettings>

                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="ShiftId" DataType="System.Int32" 
                                                                HeaderText="Kategori" ReadOnly="True" SortExpression="ShiftId" 
                                                                UniqueName="Id" Display="False">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="DisplayName" HeaderText="<%$ DataCenter:Shift %>" 
                                                                SortExpression="DisplayName" UniqueName="DisplayName">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridEditCommandColumn ButtonType="ImageButton" CancelText="<%$ DataCenter:Cancel %>" 
                                                                EditText="<%$ DataCenter:Edit %>" InsertText="<%$ DataCenter:Add %>" UpdateText="<%$ DataCenter:Update %>" UniqueName="EditCommandColumn">
                                                            </telerik:GridEditCommandColumn>
                                                            <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" 
                                                                ConfirmDialogType="RadWindow" Text="<%$ DataCenter:Delete %>" UniqueName="DeleteCommandColumn">
                                                            </telerik:GridButtonColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                    <HeaderStyle Font-Bold="True" />
                                                   <ClientSettings>
                                                    <ClientEvents OnCommand="onGridShiftsCommand" />
                                                   </ClientSettings> 
                                                </telerik:RadGrid>
                                                <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                                                    DeleteCommand="DELETE FROM [Shifts] WHERE [ShiftId] = @ShiftId" 
                                                    InsertCommand="INSERT INTO [Shifts] ([DisplayName]) VALUES (@DisplayName)" 
                                                    SelectCommand="SELECT [ShiftId], [DisplayName] FROM [Shifts]" 
                                                    
    UpdateCommand="UPDATE [Shifts] SET [DisplayName] = @DisplayName WHERE [ShiftId] = @ShiftId" 
    OnDeleted="SqlDataSource2_Changed" OnInserted="SqlDataSource2_Changed" 
    OnUpdated="SqlDataSource2_Changed">
                                                    <DeleteParameters>
                                                        <asp:Parameter Name="ShiftId" Type="Int32" />
                                                    </DeleteParameters>
                                                    <UpdateParameters>
                                                        <asp:Parameter Name="DisplayName" Type="String" />
                                                        <asp:Parameter Name="ShiftId" Type="Int32" />
                                                    </UpdateParameters>
                                                    <InsertParameters>
                                                        <asp:Parameter Name="DisplayName" Type="String" />
                                                    </InsertParameters>
                                                </asp:SqlDataSource>
		<div class="divider" style="height:10px;"></div>
		<telerik:RadGrid ID="gridCategories" runat="server" DataSourceID="SqlDataSource1" 
                                                    GridLines="None"  
                                                    AllowAutomaticDeletes="True" AllowAutomaticInserts="True" 
                                                    AllowAutomaticUpdates="True" GroupingEnabled="False">
                                                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="CategoryId" 
                                                        DataSourceID="SqlDataSource1" CommandItemDisplay="Top" EditMode="InPlace" 
                                                        NoMasterRecordsText="<%$ DataCenter:Warning.EmptyRecord.Categories %>" >
                                                    <CommandItemSettings 
                                                            AddNewRecordText="<%$ DataCenter:AddNewCategory %>" ShowRefreshButton="False"></CommandItemSettings>

                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="CategoryId" DataType="System.Int32" 
                                                                HeaderText="Kategori" ReadOnly="True" SortExpression="CategoryId" 
                                                                UniqueName="Id" Display="False">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="DisplayName" HeaderText="<%$ DataCenter:Category %>" 
                                                                SortExpression="DisplayName" UniqueName="DisplayName">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridCheckBoxColumn DataField="FlowError" DataType="System.Boolean" HeaderText="<%$ DataCenter:FlowError %>" 
                                                                SortExpression="FlowError" UniqueName="FlowError">
                                                            </telerik:GridCheckBoxColumn>
                                                            <telerik:GridCheckBoxColumn DataField="ChangeOver" DataType="System.Boolean" HeaderText="<%$ DataCenter:ChangeOver %>" 
                                                                SortExpression="ChangeOver" UniqueName="ChangeOver">
                                                            </telerik:GridCheckBoxColumn>
                                                            <telerik:GridCheckBoxColumn DataField="NoProduction" DataType="System.Boolean" Display="false" HeaderText="<%$ DataCenter:NoProduction %>" 
                                                                SortExpression="NoProduction" UniqueName="NoProduction">
                                                            </telerik:GridCheckBoxColumn>
                                                            <telerik:GridEditCommandColumn ButtonType="ImageButton" CancelText="<%$ DataCenter:Cancel %>" 
                                                                EditText="<%$ DataCenter:Edit %>" InsertText="<%$ DataCenter:Add %>" UpdateText="<%$ DataCenter:Update %>" UniqueName="EditCommandColumn">
                                                            </telerik:GridEditCommandColumn>
                                                            <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" 
                                                                ConfirmDialogType="RadWindow" Text="<%$ DataCenter:Delete %>" UniqueName="DeleteCommandColumn">
                                                            </telerik:GridButtonColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                    <HeaderStyle Font-Bold="True" />
                                                   <ClientSettings>
                                                    <ClientEvents OnCommand="onGridCategoriesCommand" />
                                                   </ClientSettings> 
                                                </telerik:RadGrid>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                                                    DeleteCommand="DELETE FROM [EventCategories] WHERE [CategoryId] = @CategoryId" 
                                                    InsertCommand="INSERT INTO [EventCategories] ([DisplayName], [FlowError], [ChangeOver], [NoProduction]) VALUES (@DisplayName,@FlowError,@ChangeOver,@NoProduction)" 
                                                    SelectCommand="SELECT [CategoryId], [DisplayName], [FlowError], [ChangeOver], [NoProduction] FROM [EventCategories]" 
                                                    
    UpdateCommand="UPDATE [EventCategories] SET [DisplayName] = @DisplayName, [FlowError]=@FlowError, [ChangeOver]=@ChangeOver, [NoProduction]=@NoProduction  WHERE [CategoryId] = @CategoryId" 
    OnDeleted="SqlDataSource1_Changed" OnInserted="SqlDataSource1_Changed" 
    OnUpdated="SqlDataSource1_Changed">
                                                    <DeleteParameters>
                                                        <asp:Parameter Name="CategoryId" Type="Int32" />
                                                    </DeleteParameters>
                                                    <UpdateParameters>
                                                        <asp:Parameter Name="DisplayName" Type="String" />
                                                        <asp:Parameter Name="FlowError" Type="Boolean" />
                                                        <asp:Parameter Name="ChangeOver" Type="Boolean" />
                                                        <asp:Parameter Name="NoProduction" Type="Boolean" />
                                                        <asp:Parameter Name="CategoryId" Type="Int32" />
                                                    </UpdateParameters>
                                                    <InsertParameters>
                                                        <asp:Parameter Name="DisplayName" Type="String" />
                                                        <asp:Parameter Name="FlowError" Type="Boolean" />
                                                        <asp:Parameter Name="ChangeOver" Type="Boolean" />
                                                        <asp:Parameter Name="NoProduction" Type="Boolean" />
                                                    </InsertParameters>
                                                </asp:SqlDataSource>
                                                
		<telerik:RadWindowManager ID="RadWindowManager1" runat="server" 
    Skin="Default" Localization-Cancel="<%$ DataCenter:No %>" Localization-OK="<%$ DataCenter:Yes %>" Title="<%$ DataCenter:ConfirmDeletion %>" >
</telerik:RadWindowManager>
		