<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatusControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Production.StatusControl" %>
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
											<div class="statusView">
												<div class="item">
													<div class="label">
														<asp:Literal ID="Literal1" runat="server" Text="<%$ DataCenter:Status#: %>" />
													</div>
													<div class="input">
														<asp:Label ID="lbStatus" runat="server" Text=""></asp:Label>
													</div>
												</div>
												<div class="item">
													<div class="label">
														<asp:Literal ID="Literal2" runat="server" Text="<%$ DataCenter:Article#: %>" />
													</div>
													 <div class="input">
														<asp:Label ID="lbArticle" runat="server" Text=""></asp:Label>
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