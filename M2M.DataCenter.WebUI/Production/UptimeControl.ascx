<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UptimeControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Production.UptimeControl" %>
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
											<div class="uptimeView">
												<div class="item">
													<div class="label">
														<asp:Literal ID="Literal1" runat="server" Text="<%$ DataCenter:Uptime %>" />
													</div>
													<div class="input">
														<asp:Label ID="lbUptime" runat="server"></asp:Label>
													</div>
												</div>
												<div class="item">
													<div class="label">
														<asp:Literal ID="Literal2" runat="server" Text="<%$ DataCenter:Uptime.Transferred %>" />
													</div>
													 <div class="input">
														<asp:Label ID="lbUptimeTransferred" runat="server"></asp:Label>
													</div>
												</div>
												<div class="item">
													 <div class="label">
														 <asp:Literal ID="Literal3" runat="server" Text="<%$ DataCenter:Moments %>" />
													</div>
													<div class="input">
														<asp:Label ID="lbMoments" runat="server"></asp:Label>
													</div>
												</div>
												<div class="item">
													<div class="label">
														<asp:Literal ID="Literal4" runat="server" Text="<%$ DataCenter:Moments.Transferred %>" />
													</div>
													 <div class="input">
														<asp:Label ID="lbMomentsTransferred" runat="server"></asp:Label>
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