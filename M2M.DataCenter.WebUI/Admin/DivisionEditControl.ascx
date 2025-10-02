<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DivisionEditControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Admin.DivisionEditControl" %>
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
														<asp:Label ID="lbDivisionId" runat="server" Text="<%$ DataCenter:Id %>"></asp:Label>
													</div>
													<div class="input">
														<asp:TextBox ID="tbDivisionId" runat="server" Columns="20"  Enabled="False"></asp:TextBox>
													</div>
												</div>
												<div class="item">
													<div class="label">
														<asp:Label ID="lbDisplayName" runat="server" Text="<%$ DataCenter:DisplayName %>"></asp:Label>
													</div>
													<div class="input">
														<asp:TextBox ID="tbDisplayName" runat="server" Columns="25"></asp:TextBox>
													</div>
												</div>
												<div class="item">
													<div class="label">
														<asp:Label ID="lbNotes" runat="server" Text="<%$ DataCenter:Description %>"></asp:Label>
													</div>
													 <div class="input">
														<asp:TextBox ID="tbNotes" runat="server" Columns="40" ></asp:TextBox>
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
