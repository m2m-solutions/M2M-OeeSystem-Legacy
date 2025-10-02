<%@ Page Title="" Language="C#" MasterPageFile="~/M2MDataCenter.Master" AutoEventWireup="true" CodeBehind="DeviceUnitPage.aspx.cs" Inherits="M2M.DataCenter.WebUI.Production.DeviceUnitPage" %>
<%@ Register Src="DeviceUnitListControl.ascx" TagName="DeviceUnitListControl" TagPrefix="uc1" %>
<%@ Register Src="OEEControl.ascx" TagName="OEEControl" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManagerProxy runat="server" ID="RadAjaxManagerProxy1">
</telerik:RadAjaxManagerProxy>
	<div class="divContent">	
		<div class="grey_frame">
			<div class="top">
				<div class="bottom">
					<div class="left">
						<div class="right">
							<div class="bottomleft">
								<div class="bottomright">
									<div class="topleft">
										<div class="topright">
											<div class="content">
											<div class="divInfo">
		<div class="divInfoLine">
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
			<div class="title">
	            <asp:Label ID="lbInfo" runat="server" Text=""></asp:Label>		
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
		</div>
	</div>
<div class="subContent">
	<div class="divFilter">
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
												   	<div class="filterView">
														<div class="item">
															<div class="label">
																<asp:Label ID="lbDateStart" runat="server" Text="<%$ DataCenter:DateFrom %>"></asp:Label>
															</div>
															<div class="input">
																<telerik:RadDatePicker ID="dtStart" Width="100px" runat="server" Skin="Default" AutoPostBack="False">
																</telerik:RadDatePicker>
															</div>
														</div>
														<div class="item">
															<div class="label">
																<asp:Label ID="lbDateEnd" runat="server" Text="<%$ DataCenter:DateTo %>"></asp:Label>
															</div>
															 <div class="input">
																<telerik:RadDatePicker ID="dtEnd" Width="100px" Skin="Default" AutoPostBack="False" runat="server">
																</telerik:RadDatePicker>
															</div>
														</div>
														<div class="item">
															<div class="label">
																<asp:Label ID="lbShift" runat="server" Text="<%$ DataCenter:Shift %>"></asp:Label>
															</div>
															 <div class="input">
																<telerik:RadComboBox ID="ProductionShifts" Width="190px" Skin="Default" AutoPostBack="False" runat="server">
																	 <CollapseAnimation Duration="200" Type="OutQuint" />
																 </telerik:RadComboBox>
															</div>
														</div>
														<div class="item">
															<div class="label">
																<asp:Label ID="lbArticle" runat="server" Text="<%$ DataCenter:Article %>"></asp:Label>
															</div>
															 <div class="input">
																 <telerik:RadComboBox ID="rcbArticles" OnClientDropDownOpening="HandleOpen" OnClientItemsRequesting="HandleRequest" LoadingMessage="<%$ DataCenter:Loading %>" Width="130px" EnableLoadOnDemand="True" ShowMoreResultsBox="False" ItemRequestTimeout="500" MarkFirstMatch="True" AllowCustomText="True" runat="server" Skin="Default">
																	  <WebServiceSettings Path="../Common/Articles.asmx" Method="GetFacilityArticles" />
																	  <CollapseAnimation Duration="200" Type="OutQuint" />
																 </telerik:RadComboBox>
															</div>
														</div>
														<div class="last">
															<div class="button">
																<asp:Button ID="btnRefresh" runat="server" CssClass="buttonSmallWhiteOnWhite" 
																	Text="<%$ DataCenter:Update %>" OnClick="btnRefresh_Click" />
															</div>
														</div>
														<div class="divider" style="height:10px">
														</div>
														<div class="item">
															<div class="label">
																<asp:CheckBox ID="checkSystemErrors" runat="server"  Checked="True" Text="<%$ DataCenter:ShowSystemErrors%>" />
															</div>
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
				</div>
				<div class="clear">&nbsp;</div>
			</div>
		</div>
	</div>	
	<div class="divider">
	</div>
	<div class="divOEE">
		<uc2:OEEControl ID="ucOEEControl" runat="server" />
	</div>
	<div class="divider">
	</div>
	<div class="divFullGraph">
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
                                                    
														<telerik:RadChart ID="chartOee" runat="server" DefaultType="Line"
														Width="900px" Skin="Web20">
														<Series>
															<telerikC:ChartSeries Name="<%$ DataCenter:Oee %>" Type="Line" DataYColumn="Oee"
																DefaultLabelValue="#Y{#0.0%}">
																<Appearance ShowLabels="False">
																	<FillStyle FillType="ComplexGradient" MainColor="86, 153, 78">
																		<FillSettings>
																			<ComplexGradient>
																				<telerikC:GradientElement Color="86, 153, 78" />
																				<telerikC:GradientElement Color="43, 126, 33" Position="0.5" />
																				<telerikC:GradientElement Color="18, 96, 3" Position="1" />
																			</ComplexGradient>
																		</FillSettings>
																	</FillStyle>
																	<TextAppearance TextProperties-Color="103, 136, 190">
																	</TextAppearance>
																	<Border Color="111, 174, 12" />
																</Appearance>
															</telerikC:ChartSeries>
															<telerikC:ChartSeries DataYColumn="Availability" DefaultLabelValue="#Y{#0.0%}" 
																Name="<%$ DataCenter:Availability %>" Type="Line">
																<Appearance ShowLabels="False">
																	<FillStyle MainColor="136, 221, 246" FillType="ComplexGradient">
																		<FillSettings>
																			<ComplexGradient>
																				<telerikC:GradientElement Color="136, 221, 246" />
																				<telerikC:GradientElement Color="97, 203, 234" Position="0.5" />
																				<telerikC:GradientElement Color="59, 161, 197" Position="1" />
																			</ComplexGradient>
																		</FillSettings>
																	</FillStyle>
																	<TextAppearance TextProperties-Color="103, 136, 190">
																	</TextAppearance>
																	<Border Color="67, 181, 229" />
																</Appearance>
															</telerikC:ChartSeries>
															<telerikC:ChartSeries DataYColumn="Performance" DefaultLabelValue="#Y{#0.0%}" 
																Name="<%$ DataCenter:Performance %>" Type="Line">
																<Appearance ShowLabels="False">
																	<FillStyle MainColor="163, 222, 78" FillType="ComplexGradient">
																		<FillSettings>
																			<ComplexGradient>
																				<telerikC:GradientElement Color="163, 222, 78" />
																				<telerikC:GradientElement Color="132, 207, 27" Position="0.5" />
																				<telerikC:GradientElement Color="102, 181, 3" Position="1" />
																			</ComplexGradient>
																		</FillSettings>
																	</FillStyle>
																	<TextAppearance TextProperties-Color="103, 136, 190">
																	</TextAppearance>
																	<Border Color="94, 160, 0" />
																</Appearance>
															</telerikC:ChartSeries>
															<telerikC:ChartSeries DataYColumn="Quality" DefaultLabelValue="#Y{#0.0%}" 
																Name="<%$ DataCenter:Quality %>" Type="Line">
																<Appearance ShowLabels="False">
																	<FillStyle FillType="ComplexGradient" MainColor="79, 152, 198">
																		<FillSettings>
																			<ComplexGradient>
																				<telerikC:GradientElement Color="79, 152, 198" />
																				<telerikC:GradientElement Color="34, 123, 182" Position="0.5" />
																				<telerikC:GradientElement Color="4, 85, 156" Position="1" />
																			</ComplexGradient>
																		</FillSettings>
																	</FillStyle>
																	<TextAppearance TextProperties-Color="103, 136, 190">
																	</TextAppearance>
																	<Border Color="94, 160, 0" />
																</Appearance>
															</telerikC:ChartSeries>
														</Series>
														<PlotArea >
                                                            <EmptySeriesMessage>
                                                                <TextBlock Text="<%$ DataCenter:Warning.EmptyRecord %>">
                                                                <Appearance AutoTextWrap="True"></Appearance>
                                                                </TextBlock>
                                                            </EmptySeriesMessage>
															<XAxis DataLabelsColumn="XValue" LabelStep="2" LayoutMode="Inside">
																<Appearance Color="149, 184, 206" MajorTick-Color="149, 184, 206" 
																	CustomFormat="ddd dd MMM" ValueFormat="ShortDate">
																	<MajorGridLines Color="209, 221, 238" Width="0" />
																</Appearance>
																<Items>
																	<telerikC:ChartAxisItem>
																	</telerikC:ChartAxisItem>
																	<telerikC:ChartAxisItem Value="1" Visible="False">
																		<Appearance Visible="False">
																		</Appearance>
																	</telerikC:ChartAxisItem>
																	<telerikC:ChartAxisItem Value="2">
																	</telerikC:ChartAxisItem>
																	<telerikC:ChartAxisItem Value="3" Visible="False">
																		<Appearance Visible="False">
																		</Appearance>
																	</telerikC:ChartAxisItem>
																	<telerikC:ChartAxisItem Value="4">
																	</telerikC:ChartAxisItem>
																	<telerikC:ChartAxisItem Value="5" Visible="False">
																		<Appearance Visible="False">
																		</Appearance>
																	</telerikC:ChartAxisItem>
																	<telerikC:ChartAxisItem Value="6">
																	</telerikC:ChartAxisItem>
																	<telerikC:ChartAxisItem Value="7" Visible="False">
																		<Appearance Visible="False">
																		</Appearance>
																	</telerikC:ChartAxisItem>
																</Items>
															</XAxis>
															<YAxis LabelStep="2">
																<Appearance Color="149, 184, 206" MajorTick-Color="149, 184, 206" 
																	MinorTick-Color="149, 184, 206" CustomFormat="N0" ValueFormat="Percent">
																	<MajorGridLines Color="209, 221, 238" />
																	<MinorGridLines Color="209, 221, 238" Visible="False" />
																</Appearance>
																<AxisLabel>
																	<Appearance Position-Auto="False" Position-X="14.9331894" 
																		Position-Y="148.628174">
																	</Appearance>
																	<TextBlock Text="%">
																	</TextBlock>
																</AxisLabel>
															</YAxis>
															<Appearance Dimensions-Margins="16%, 10%, 12%, 10%">
																<FillStyle FillType="Solid" MainColor="White" SecondColor="White">
																</FillStyle>
																<Border Visible="False" Color="149, 184, 206" />
															</Appearance>
														</PlotArea>
														<Appearance>
															<Border Color="103, 136, 190" Visible="False" />
														</Appearance>
														<ChartTitle Visible="False">
															<Appearance Visible="False">
																<FillStyle MainColor="">
																</FillStyle>
															</Appearance>
															<TextBlock Text="TAK/OEE">
																<Appearance TextProperties-Color="0, 0, 79" 
																	TextProperties-Font="Verdana, 12pt, style=Bold">
																</Appearance>
															</TextBlock>
														</ChartTitle>
														<Legend>
															<Appearance Dimensions-Margins="0%, 3%, 1px, 1px" 
																Dimensions-Paddings="2px, 8px, 6px, 3px" Position-AlignedPosition="Top" Overflow="Row">
																<ItemAppearance>
																	<Border Visible="False" />
																</ItemAppearance>
																<Border Color="165, 190, 223" Visible="False" />
															</Appearance>
														</Legend>
													</telerik:RadChart>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="clear">&nbsp;
					</div>
			</div>
		</div>
	</div>
	<div class="divider"></div>
    <div class="divGraph">
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
													<telerik:RadChart ID="chartStopTimes" runat="server" DefaultType="Pie" 
														Height="220px" Skin="Web20" Width="430px">
														<Series>
<telerikC:ChartSeries Name="Series 1" Type="Pie">
	<Appearance LegendDisplayMode="Nothing">
		<FillStyle FillType="ComplexGradient">
			<FillSettings>
				<ComplexGradient>
					<telerikC:GradientElement Color="213, 247, 255" />
					<telerikC:GradientElement Color="193, 239, 252" Position="0.5" />
					<telerikC:GradientElement Color="157, 217, 238" Position="1" />
				</ComplexGradient>
			</FillSettings>
		</FillStyle>
		<TextAppearance TextProperties-Color="103, 136, 190">
		</TextAppearance>
	</Appearance>
															</telerikC:ChartSeries>
</Series>
														<PlotArea>
                                                            <EmptySeriesMessage>
                                                                <TextBlock Text="<%$ DataCenter:Warning.EmptyRecord %>">
                                                                <Appearance AutoTextWrap="True"></Appearance>
                                                                </TextBlock>
                                                            </EmptySeriesMessage>
															<XAxis>
																<Appearance Color="149, 184, 206" MajorTick-Color="149, 184, 206">
																	<MajorGridLines Color="209, 221, 238" Width="0" />
																</Appearance>
															</XAxis>
															<YAxis>
																<Appearance Color="149, 184, 206" MajorTick-Color="149, 184, 206" 
																	MinorTick-Color="149, 184, 206">
																	<MajorGridLines Color="209, 221, 238" />
																	<MinorGridLines Color="209, 221, 238" />
																</Appearance>
															</YAxis>
															<Appearance Dimensions-Margins="1%, 5%, 5%, 30%" 
                                                                Position-AlignedPosition="TopRight">
																<FillStyle FillType="Solid" MainColor="White" SecondColor="White">
																</FillStyle>
																<Border Color="149, 184, 206" Visible="False" />
															</Appearance>
														</PlotArea>
														<Appearance>
															<Border Color="103, 136, 190" Visible="False" />
														</Appearance>
														<ChartTitle>
															<Appearance>
																<FillStyle MainColor="">
																</FillStyle>
															</Appearance>
															<TextBlock>
																<Appearance TextProperties-Color="0, 0, 79" 
																	TextProperties-Font="Verdana, 8pt, style=Bold">
																</Appearance>
															</TextBlock>
														</ChartTitle>
														<Legend>
															<Appearance Dimensions-Margins="0%, 3%, 1px, 1px" 
																Dimensions-Paddings="2px, 8px, 6px, 3px" Position-AlignedPosition="BottomRight">
																<ItemTextAppearance MaxLength="27">
																</ItemTextAppearance>
																<Border Color="165, 190, 223" />
															</Appearance>
															<TextBlock>
																<Appearance MaxLength="27">
																</Appearance>
															</TextBlock>
														</Legend>
													</telerik:RadChart>
                                                    <telerik:RadGrid ID="gridStopTimes" runat="server" PageSize="6" 
                                                        AutoGenerateColumns="False" GridLines="None"
                                                        OnItemDataBound="gridStops_ItemDataBound" BorderStyle="None" 
                                                        CellSpacing="0">
		                                                <MasterTableView NoMasterRecordsText="" ShowHeader="false" BorderStyle="None">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                                                            <Columns>
				                                                <telerik:GridBoundColumn DataField="StoppageDataId" DataType="System.Guid" ReadOnly="True" UniqueName="Id" Visible="False" >
				                                                </telerik:GridBoundColumn>
				                                                <telerik:GridTemplateColumn DataField="Marker" UniqueName="Marker">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="imageMarker" runat="server" />
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
				                                                <telerik:GridBoundColumn DataField="Machine" HeaderText="<%$ DataCenter:Machine %>" ReadOnly="True" UniqueName="Machine">
				                                                </telerik:GridBoundColumn>
				                                                <telerik:GridBoundColumn DataField="Reason" HeaderText="<%$ DataCenter:StopReason %>" ReadOnly="True" UniqueName="Reason">
				                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="NumberOfStops" HeaderText="<%$ DataCenter:NumberOfStops %>" ReadOnly="True" UniqueName="NumberOfStops">
				                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="ElapsedTime" HeaderText="<%$ DataCenter:ElapsedTime %>" ItemStyle-Font-Bold="true" ReadOnly="True" UniqueName="ElapsedTime">
				                                                </telerik:GridBoundColumn>
				                                            </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
			                                            </MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
		                                            </telerik:RadGrid>
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
	</div>
	<div class="divGraph">
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
													<telerik:RadChart ID="chartStops" runat="server" DefaultType="Pie" 
														Height="220px" Skin="Web20" Width="430px">
														<Series>
															<telerikC:ChartSeries Name="Series 1" Type="Pie">
																<Appearance LegendDisplayMode="Nothing">
																	<FillStyle FillType="ComplexGradient">
																		<FillSettings>
																			<ComplexGradient>
																				<telerikC:GradientElement Color="213, 247, 255" />
																				<telerikC:GradientElement Color="193, 239, 252" Position="0.5" />
																				<telerikC:GradientElement Color="157, 217, 238" Position="1" />
																			</ComplexGradient>
																		</FillSettings>
																	</FillStyle>
																	<TextAppearance TextProperties-Color="103, 136, 190">
																	</TextAppearance>
																</Appearance>
																														</telerikC:ChartSeries>
															</Series>
														<PlotArea>
                                                            <EmptySeriesMessage>
                                                                <TextBlock Text="<%$ DataCenter:Warning.EmptyRecord %>">
                                                                <Appearance AutoTextWrap="True"></Appearance>
                                                                </TextBlock>
                                                            </EmptySeriesMessage>
															<XAxis>
																<Appearance Color="149, 184, 206" MajorTick-Color="149, 184, 206">
																	<MajorGridLines Color="209, 221, 238" Width="0" />
																</Appearance>
															</XAxis>
															<YAxis>
																<Appearance Color="149, 184, 206" MajorTick-Color="149, 184, 206" 
																	MinorTick-Color="149, 184, 206">
																	<MajorGridLines Color="209, 221, 238" />
																	<MinorGridLines Color="209, 221, 238" />
																</Appearance>
															</YAxis>
															<Appearance Dimensions-Margins="1%, 5%, 5%, 30%" 
                                                                Position-AlignedPosition="TopRight">
																<FillStyle FillType="Solid" MainColor="White" SecondColor="White">
																</FillStyle>
																<Border Color="149, 184, 206" Visible="False" />
															</Appearance>
														</PlotArea>
														<Appearance>
															<Border Color="103, 136, 190" Visible="False" />
														</Appearance>
														<ChartTitle>
															<Appearance>
																<FillStyle MainColor="">
																</FillStyle>
															</Appearance>
															<TextBlock>
																<Appearance TextProperties-Color="0, 0, 79" 
																	TextProperties-Font="Verdana, 8pt, style=Bold">
																</Appearance>
															</TextBlock>
														</ChartTitle>
														<Legend>
															<Appearance Dimensions-Margins="0%, 3%, 1px, 1px" 
																Dimensions-Paddings="2px, 8px, 6px, 3px" Position-AlignedPosition="BottomRight">
																<ItemTextAppearance MaxLength="27">
																</ItemTextAppearance>
																<Border Color="165, 190, 223" />
															</Appearance>
															<TextBlock>
																<Appearance MaxLength="27">
																</Appearance>
															</TextBlock>
														</Legend>
													</telerik:RadChart>
                                                    <telerik:RadGrid ID="gridStops" runat="server" PageSize="6" 
                                                        AutoGenerateColumns="False" GridLines="None" 
                                                        OnItemDataBound="gridStops_ItemDataBound" BorderStyle="None" 
                                                        CellSpacing="0">
		                                                <MasterTableView NoMasterRecordsText="" ShowHeader="false" BorderStyle="None">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                                                            <Columns>
				                                                <telerik:GridBoundColumn DataField="StoppageDataId" DataType="System.Guid" ReadOnly="True" UniqueName="Id" Visible="False" >
				                                                </telerik:GridBoundColumn>
				                                                <telerik:GridTemplateColumn DataField="Marker" UniqueName="Marker">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="imageMarker" runat="server" />
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
				                                                <telerik:GridBoundColumn DataField="Machine" HeaderText="<%$ DataCenter:Machine %>" ReadOnly="True" UniqueName="Machine">
				                                                </telerik:GridBoundColumn>
				                                                <telerik:GridBoundColumn DataField="Reason" HeaderText="<%$ DataCenter:StopReason %>" ReadOnly="True" UniqueName="Reason">
				                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="NumberOfStops" HeaderText="<%$ DataCenter:NumberOfStops %>" ItemStyle-Font-Bold="true"  ReadOnly="True" UniqueName="NumberOfStops">
				                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="ElapsedTime" HeaderText="<%$ DataCenter:ElapsedTime %>" ReadOnly="True" UniqueName="ElapsedTime">
				                                                </telerik:GridBoundColumn>
				                                            </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
			                                            </MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
		                                            </telerik:RadGrid>
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
	</div>
	<div class="divider"></div>
	<div class="divEvents">
		<uc1:DeviceUnitListControl ID="ucDivisionListControl" runat="server" />
	</div>
	<div class="divider">
		
	</div>
</div>
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
<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
<script type="text/javascript">

	function HandleRequest(sender, eventArgs)
	{
	
		sender.clearItems();
		var context = eventArgs.get_context();
		
		var articlesFilter = eventArgs.get_text();
	
		if(articlesFilter != null)
		{
			context["ArticlesFilter"] = articlesFilter;
		}
		
		var startDatePicker = $find("<%= dtStart.ClientID %>");
		var startDate = startDatePicker.get_selectedDate();
		
		if (startDate != null) {
		    context["StartDate"] = startDate;
		}
		
		var endDatePicker = $find("<%= dtEnd.ClientID %>");
		var endDate = endDatePicker.get_selectedDate();
		
		if (endDate != null)
		{
			context["EndDate"] = endDate;
		}
		
		var shiftCombo = $find("<%= ProductionShifts.ClientID %>");
		var shift = shiftCombo.get_value();
		
		if (shift != null)
		{
			context["Shift"] = shift;
		}
	}
	
	function HandleOpen(sender, eventArgs)
    {
		sender.requestItems(sender.get_text(), false); 
    }
    
</script>
</telerik:RadScriptBlock>

</asp:Content>
