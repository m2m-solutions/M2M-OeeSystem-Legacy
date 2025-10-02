<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DivisionControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Admin.DivisionControl" %>
<%@ Register Src="ProductionSchemeControl.ascx" TagName="ProductionSchemeControl"
	TagPrefix="uc5" %>
<%@ Register Src="DivisionEditControl.ascx" TagName="DivisionEditControl" TagPrefix="uc1" %>
<%@ Register Src="MachineListControl.ascx" TagName="MachineListControl" TagPrefix="uc2" %>
<div class="subContent">
	<div class="divInfo">
		<div class="divInfoLine">
			<div class="label">
			<asp:Literal ID="Literal1" runat="server" Text="<%$ DataCenter:Division#: %>" />
			</div>
			 <telerik:RadComboBox ID="rcbDivision" AutoPostBack="true" runat="server" Skin="Default" OnSelectedIndexChanged="rcbDivision_SelectedIndexChanged">
			</telerik:RadComboBox>
		</div>
	</div>
	<div class="divider"></div>
	<div class="divFilter">
		<uc1:DivisionEditControl id="ucDivisionEditControl" runat="server">
		</uc1:DivisionEditControl>
	</div>
	<div class="divider"></div>
	<div class="divEvents">
		<uc2:MachineListControl id="ucMachineListControl" runat="server">
		</uc2:MachineListControl>
	</div>
	<div class="divider"></div>
	<div class="divEvents">
		<uc5:ProductionSchemeControl id="ProductionSchemeControl1" runat="server">
		</uc5:ProductionSchemeControl>
	</div>
	<div class="divider"></div>
	<div class="divEvents">
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
														<asp:Label ID="lbStart" runat="server" Text="<%$ DataCenter:DateFrom %>"></asp:Label>
													</div>
													<div class="input">
														<telerik:RadDatePicker ID="dtStart" Width="100px" runat="server" Skin="Default" AutoPostBack="False">
														</telerik:RadDatePicker>
													</div>
												</div>
												<div class="item">
													<div class="label">
														<asp:Label ID="lbEnd" runat="server" Text="<%$ DataCenter:DateUntil %>"></asp:Label>
													</div>
													<div class="input">
														<telerik:RadDatePicker ID="dtEnd" Width="100px" runat="server" Skin="Default" AutoPostBack="False">
														</telerik:RadDatePicker>
													</div>
												</div>
												<div class="last">
													<div class="button">
														<asp:Button ID="btnCaluclate" runat="server" CssClass="buttonSmallWhiteOnWhite" Text="<%$ DataCenter:OeeCalculate %>" OnClick="btnCaluclate_Click"  />
													    <asp:Label ID="lbOeeCalcInfo" runat="server" Text=""></asp:Label>
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
	<div class="divider"></div>
</div>

