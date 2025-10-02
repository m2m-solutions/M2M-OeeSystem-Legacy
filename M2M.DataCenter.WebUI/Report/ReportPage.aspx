<%@ Page Language="C#" MasterPageFile="~/M2MDataCenter.Master" AutoEventWireup="true" CodeBehind="ReportPage.aspx.cs" Inherits="M2M.DataCenter.WebUI.Report.ReportPage" Title="M2M DataCenter - Rapporter" %>

<asp:Content ID="ReportContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContentTop">
    </div>
    <div class="divContent">	
		<div class="grey_frame">
			<div class="topspecial">
				<div class="bottom">
					<div class="left">
						<div class="right">
							<div class="bottomleft">
								<div class="bottomright">
									<div class="topleft">
										<div class="topright">
											<div class="content">
	                                            <div class="filterView">
                                                    <telerik:RadGrid ID="gridReports"  
                                                        runat="server" PageSize="50" AllowPaging="True" 
                                                        AutoGenerateColumns="False" GridLines="None"
                                                        OnNeedDataSource="gridReports_NeedDataSource" 
                                                        oncolumncreated="gridReports_ColumnCreated" 
                                                        onitemdatabound="gridReports_ItemDataBound">
                                                        <MasterTableView NoMasterRecordsText="<%$ DataCenter:Warning.EmptyRecord.Reports %>" Name="Reports" >
                                                            <GroupByExpressions>
                                                                <telerik:GridGroupByExpression>
                                                                    <SelectFields>
                                                                        <telerik:GridGroupByField FieldAlias="" FieldName="GroupName" />
                                                                    </SelectFields>
                                                                    <GroupByFields>
                                                                        <telerik:GridGroupByField FieldName="GroupName" />
                                                                    </GroupByFields>
                                                                </telerik:GridGroupByExpression>                                                              
                                                            </GroupByExpressions>
                                                            <GroupHeaderItemStyle BackColor="White" />
                                                            <Columns>
                                                                <telerik:GridBoundColumn DataField="GroupName" Visible="false" HeaderText="<%$ DataCenter:Group %>" ReadOnly="True" UniqueName="GroupName" >
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridHyperLinkColumn HeaderText="<%$ DataCenter:Report %>" Target="_blank" UniqueName="Report" DataNavigateUrlFields="NavigateUrl" DataTextField="DisplayName" ></telerik:GridHyperLinkColumn>
                                                                <telerik:GridBoundColumn DataField="Description" HeaderText="<%$ DataCenter:Description %>" ReadOnly="True" UniqueName="Description" >
                                                                </telerik:GridBoundColumn>
                                                            </Columns>
                                                            <PagerStyle Mode="NextPrevAndNumeric" PagerTextFormat="<%$ DataCenter:Grid.PagerTextFormat %>" PageSizeLabelText="<%$ DataCenter:Grid.PageSizeLabelText %>"  />
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                </div>
                                                <div class="divider"></div>
                                            </div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="clear">&nbsp;</div>
		</div>
	</div>

</asp:Content>
