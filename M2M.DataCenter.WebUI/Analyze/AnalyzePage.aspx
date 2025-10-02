<%@ Page Title="" Language="C#" MasterPageFile="~/M2MDataCenter.Master" AutoEventWireup="true" CodeBehind="AnalyzePage.aspx.cs" Inherits="M2M.DataCenter.WebUI.Analyze.AnalyzePage" %>
<%@ Register src="../Production/FilterControl.ascx" tagname="FilterControl" tagprefix="uc1" %>
<%@ Register src="../Production/EventListControl.ascx" tagname="EventListControl" tagprefix="uc2" %>
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
												                                                    <div class="content"  style="position:relative;height:25px;" >
			                                                                                            <div class="title" style="position: absolute; top: 2px; left: 0px;">
	                                                                                                        <asp:Label ID="lbInfo" runat="server" Text=""></asp:Label>		
			                                                                                            </div>
			                                                                                            <div class="button" style="position: absolute; top: 0px; left: 330px;">
                                                                                                            <asp:Button ID="buttonShowDefault" runat="server" CssClass="buttonSmallWhiteOnWhite" PostBackUrl=""  
																	                                                                                            Text="<%$ DataCenter:ProductionView.Default %>" />
	   		                                                                                            </div>
                                                                                                        <div class="button" style="position: absolute; top: 0px; left: 200px;">
                                                                                                            <asp:Button ID="buttonShowGraphical" runat="server" CssClass="buttonSmallWhiteOnWhite" PostBackUrl=""  
																	                                                                                            Text="<%$ DataCenter:ProductionView.Graphical %>" />
	   		                                                                                            </div>
                                                                                                        <div class="button" style="position: absolute; top: 0px; left: 460px;">
                                                                                                                                <asp:Button ID="buttonUp" runat="server" CssClass="buttonSmallWhiteOnWhite" PostBackUrl=""  
									                                                                                            Text="<%$ DataCenter:ShowDivision %>" />
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
                                                    <div class="divFilter">
		                                                <uc1:FilterControl ID="ucFilterControl" ArticleMethodName="GetMachineArticles" ShiftVisible="False"  runat="server" />
                                                    </div>
                                                    <div class="divider"></div>
	                                                <div class="divEvents">
		                                                <uc2:EventListControl ID="ucEventListControl" runat="server" />
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

