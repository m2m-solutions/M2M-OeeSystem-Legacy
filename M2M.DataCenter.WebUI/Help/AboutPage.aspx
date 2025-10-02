<%@ Page Title="" Language="C#" MasterPageFile="~/M2MDataCenter.Master" AutoEventWireup="true" CodeBehind="AboutPage.aspx.cs" Inherits="M2M.DataCenter.WebUI.Help.AboutPage" %>
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
									            <div class="subContent">
									                <div class="divAbout">
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
												                                                <div class="content" >
			                                                                                        <img src="../images/OeeSystemLogo.png" width="100" height="91" alt="M2M Oee System" />
                                                                                                    <p>&nbsp;</p>
                                                                                                    <p><asp:literal ID="Literal1" runat="server" Text="<%$ DataCenter:Version#: %>"></asp:literal>&nbsp;<asp:literal ID="Literal2" runat="server" Text="<%$ DataCenter:CurrentVersion %>"></asp:literal></p>
                                                                                                    <p><asp:literal ID="Literal3" runat="server" Text="<%$ DataCenter:Copyright %>"></asp:literal><br />
                                                                                                    <asp:literal ID="Literal4" runat="server" Text="<%$ DataCenter:AllRightsReserved  %>"></asp:literal></p>
                                                                                                    <p><asp:literal ID="Literal5" runat="server" Text="<%$ DataCenter:LicensedTo#: %>"></asp:literal> <asp:literal ID="lbCustomer" runat="server" Text=""></asp:literal></p>
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
</asp:Content>

