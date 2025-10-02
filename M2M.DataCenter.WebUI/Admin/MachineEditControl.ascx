<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MachineEditControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Admin.MachineEditControl" %>
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
														<asp:Label ID="lbMachineId" runat="server" Text="<%$ DataCenter:Id %>"></asp:Label>
													</div>
													<div class="input">
														<asp:TextBox ID="tbMachineId" runat="server" Columns="10" Enabled="False"></asp:TextBox>
													</div>
												</div>
												<div class="item">
													<div class="label">
														<asp:Label ID="lbDisplayName" runat="server" Text="<%$ DataCenter:DisplayName %>"></asp:Label>
													</div>
													<div class="input">
														<asp:TextBox ID="tbDisplayName" runat="server" Columns="35"></asp:TextBox>
													</div>
												</div>
												<div class="item">
													<div class="label">
														<asp:Label ID="lbMomentUnit" runat="server" Text="<%$ DataCenter:MomentUnit %>"></asp:Label>
													</div>
													 <div class="input">
														 <telerik:RadComboBox ID="rcbMomentUnit" AutoPostBack="false" Width="100px" runat="server" Skin="Default">
															<Items>
															    <telerik:RadComboBoxItem runat="server" Selected="True" Text="<%$ DataCenter:MomentUnit.Cycles %>" Value="Cycles" />
																<telerik:RadComboBoxItem runat="server" Text="<%$ DataCenter:MomentUnit.Strokes %>" Value="Strokes" />
																<telerik:RadComboBoxItem runat="server" Text="<%$ DataCenter:MomentUnit.Welds %>" Value="Welds" />
															</Items>
														</telerik:RadComboBox>
													</div>
												</div>
												<div class="divider"></div>
												<div class="item">
													<div class="label">
														<asp:Label ID="lbNotes" runat="server" Text="<%$ DataCenter:Description %>"></asp:Label>
													</div>
													 <div class="input">
														<asp:TextBox ID="tbNotes" runat="server" Columns="50" ></asp:TextBox>
													</div>
												</div>
												<div class="item">
													<div class="label">
														<asp:Label ID="lbIdealRunRate" runat="server" Text="<%$ DataCenter:IdealCycleTimeOrPace %>"></asp:Label><asp:Label ID="lbLastModified" runat="server" Text=""></asp:Label>
													</div>
													 <div class="input">
														 <telerik:RadNumericTextBox ID="tbIdealRunRate" Width="80px" runat="server" MinValue="0">
															<NumberFormat DecimalDigits="0" />
														 </telerik:RadNumericTextBox>
														 <telerik:RadComboBox ID="rcbRunRateUnit" AutoPostBack="false" Width="100px" runat="server" Skin="Default">
															<Items>
																<telerik:RadComboBoxItem runat="server" Selected="True" Text="<%$ DataCenter:RunRateUnit.CycleTimeInMilliSeconds %>" Value="CycleTimeInMilliSeconds" />
																<telerik:RadComboBoxItem runat="server" Text="<%$ DataCenter:RunRateUnit.CyclesPerHour %>" Value="CyclesPerHour" />
																<telerik:RadComboBoxItem runat="server" Text="<%$ DataCenter:RunRateUnit.CyclesPerMinute %>" Value="CyclesPerMinute" />
															</Items>
														</telerik:RadComboBox>
													</div>
												</div>
												<div class="last">
													<div class="button">
														<asp:Button ID="btnSave" runat="server" CssClass="buttonSmallWhiteOnWhite" Text="<%$ DataCenter:Save %>" OnClick="btnSave_Click" />
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
