<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="M2M.DataCenter.WebUI.Logon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title><asp:Literal ID="Literal1" runat="server" Text="<%$ DataCenter:Logon.Title %>" /></title>
   <meta http-equiv="X-UA-Compatible" content="IE=edge" />
		<link href="M2M.Classic.css" rel="stylesheet" type="text/css" />
        <link href="CustomerSpecifics/customer.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <script type="text/javascript">
            function setlanguage(value) {
                document.getElementById('<%=selectedLanguage.ClientID%>').value = value;
            } 

        </script>   
		<div id="loginpage">
			<div class="body_header">
				<asp:Image ID="image1" runat="server" ImageAlign="Left" ImageUrl="~/CustomerSpecifics/headerLogo.gif" />
				<div class="divLanguage" style="display:none;">
				    <asp:LinkButton ID="btnEnglish" runat="server" OnClientClick="setlanguage('en')">English</asp:LinkButton>&nbsp;<asp:LinkButton 
                        ID="btnSwedish" runat="server" OnClientClick="setlanguage('sv')">Svenska</asp:LinkButton>
                    <asp:HiddenField
                            ID="selectedLanguage" Value="" runat="server" 
                        onvaluechanged="selectedLanguage_ValueChanged"  />
		        </div>
			</div>
			<div class="divider"></div>
			<div id="login_content">
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
														<div class="divLogin">
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
																										<div class="loginView">
                                                                                                            <div id="divCheck" runat="server" style="width:100%; text-align:center;">
																											<asp:CheckBox ID="showCheck" runat="server" Text="Visa äldre data" Checked="false" />
                                                                                                            </div>
																											<asp:Login ID="Login1" runat="server" CssClass="loginControl" DisplayRememberMe="False"
																												OnAuthenticate="Login1_Authenticate" TextBoxStyle-Width="200px"
																												TitleText="" UserNameLabelText="<%$ DataCenter:Logon.UserName %>" PasswordLabelText="<%$ DataCenter:Logon.Password %>" FailureText="<%$ DataCenter:Logon.Failure %>" 
                                                                                                                PasswordRequiredErrorMessage="<%$ DataCenter:Logon.PasswordRequired %>" 
                                                                                                                UserNameRequiredErrorMessage="<%$ DataCenter:Logon.UserNameRequired %>" LoginButtonText="<%$ DataCenter:Logon.Button.Text %>" 
                                                                                                                onloggedin="Login1_LoggedIn">
																												<TextBoxStyle CssClass="loginTextBox" Width="200px" />
																												<LoginButtonStyle CssClass="buttonSmallWhiteOnWhite" />
																												<LabelStyle CssClass="loginLabel" />
																											</asp:Login>
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
			<div id="login_footer">
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
														<a href="http://www.m2msolutions.se">M2M Solutions AB</a>
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
    </form>
</body>
</html>
