<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OEEControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Production.OEEControl" %>
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
											<div class="oeeView">
                                                <div class="oeeLeft" style="top:8px;left: 0px;">
												    <div class="leftItem" style="top:10px;left:2px;">
                                                        <div class="leftPrefix">
                                                            <asp:Literal ID="Literal13" runat="server" Text="<%$ DataCenter:AvailabilityLossBasedOnActualStops.Abbr#= %>" />
                                                        </div>
                                                        <div class="leftInput">
														    <asp:Label ID="lbAvailabilityLoss" runat="server" Text="100,00%"></asp:Label>
													    </div>
												    </div>
                                                </div>
                                                <div class="oeeItem" style="top:7px;left:140px;">
                                                    <div class="oeePrefix">
                                                        <asp:Literal ID="Literal10" runat="server" Text="<%$ DataCenter:Availability.Abbr#= %>" />
                                                    </div>
												    <div class="oeeInput">
														<asp:Label ID="lbAvailability" runat="server" Text="100,00%"></asp:Label>
													</div>
                                                	<div class="oeeLabel">
														<asp:Literal ID="Literal1" runat="server" Text="<%$ DataCenter:#()Availability %>" />
													</div>
												</div>
                                               <div class="oeeItem" style="top:7px;left:270px;">
													<div class="oeePrefix">
                                                        <asp:Literal ID="Literal9" runat="server" Text="<%$ DataCenter:Performance.Abbr#= %>" />
                                                    </div>
                                                    <div class="oeeInput">
														<asp:Label ID="lbPerformance" runat="server" Text="100,00%"></asp:Label>
													</div>
                                                    <div class="oeeLabel">
														<asp:Literal ID="Literal2" runat="server" Text="<%$ DataCenter:#()Performance %>" />
													</div>
												</div>
												<div class="oeeItem" style="top:7px;left:390px;">
                                                    <div class="oeePrefix">
                                                        <asp:Literal ID="Literal7" runat="server" Text="<%$ DataCenter:Quality.Abbr#= %>" />
                                                    </div>
													<div class="oeeInput">
														<asp:Label ID="lbQuality" runat="server" Text="100,00%"></asp:Label>
													</div>
                                                     <div class="oeeLabel">
														<asp:Literal ID="Literal3" runat="server" Text="<%$ DataCenter:#()Quality %>" />
														 
													</div>
												</div>
                                                <div class="oeeRight" style="top:0px;left: 548px;">
                                                    <div class="rightFirst" style="top:10px;left:0px;">
                                                        <asp:Literal ID="Literal4" runat="server" Text="<%$ DataCenter:#()#+Oee.Special %>" />
                                                    </div>
                                                    <div class="rightItem" style="top:6px;left:80px;">
                                                        <div class="rightPrefix">
                                                            <asp:Literal ID="Literal8" runat="server" Text="<%$ DataCenter:Oee.Abbr#= %>" />
                                                        </div>
                                                        <div class="rightInput">
														    <asp:Label ID="lbOEE" runat="server" Text="100,00%"></asp:Label>
													    </div>
                                                    </div>
                                                    <div class="rightLast" style="top:7px;left:270px;">
													    <div class="lastInput">
														    <asp:Label ID="lbPace" runat="server" Text="180"></asp:Label>
													    </div>
                                                        <div class="lastLabel">
														    <asp:Label ID="lbPaceUnit" runat="server" Text="<%$ DataCenter:#()PaceInHour %>" />
													    </div>
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