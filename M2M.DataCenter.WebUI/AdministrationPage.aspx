<%@ Page Language="C#" MasterPageFile="~/M2MDataCenter.Master" AutoEventWireup="true" CodeBehind="AdministrationPage.aspx.cs" Inherits="M2M.DataCenter.WebUI.AdministrationPage" Title="" %>
<%@ Register src="Admin/FacilityControl.ascx" tagname="FacilityControl" tagprefix="uc1" %>
<%@ Register Src="Admin/DivisionControl.ascx" TagName="DivisionControl" TagPrefix="uc2" %>
<%@ Register Src="Admin/MachineControl.ascx" TagName="MachineControl" TagPrefix="uc3" %>
<%@ Register src="Admin/SystemSettingsControl.ascx" tagname="SystemSettingsControl" tagprefix="uc4" %>
<%@ Register src="Admin/UserSettingsControl.ascx" tagname="UserSettingsControl" tagprefix="uc5" %>
<asp:Content ID="AdministrationContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="divContentTop">
		<div class="subMenu">
			<div class="first">
			    <ul id="subMenuItemSystemSettings" runat="server" class="subMenuItem">
					<li class="left"></li>
					<li class="middle">
						<asp:LinkButton ID="btnSystemSettings" runat="server" CausesValidation="False" OnClick="btnSystemSettings_Click" Text="<%$ DataCenter:System %>"></asp:LinkButton>
					</li>
					<li class="right"></li>
				</ul>
			</div>
			<div class="all">
			    <ul id="subMenuItemUserSettings" runat="server" class="subMenuItem">
					<li class="left"></li>
					<li class="middle">
						<asp:LinkButton ID="btnUserSettings" runat="server" CausesValidation="False" OnClick="btnUserSettings_Click" Text="<%$ DataCenter:Users %>"></asp:LinkButton>
					</li>
					<li class="right"></li>
				</ul>
			    <ul id="subMenuItemFacility" runat="server" class="subMenuItem">
					<li class="left"></li>
					<li class="middle">
						<asp:LinkButton ID="btnFacility" runat="server" CausesValidation="False" OnClick="btnFacility_Click" Text="<%$ DataCenter:Facility %>"></asp:LinkButton>
					</li>
					<li class="right"></li>
				</ul>
				<ul id="subMenuItemDivision" runat="server" class="subMenuItem">
					<li class="left"></li>
					<li class="middle">
						<asp:LinkButton ID="btnDivision" runat="server" CausesValidation="False" OnClick="btnDivision_Click" Text="<%$ DataCenter:Division %>"></asp:LinkButton>
					</li>
					<li class="right"></li>
				</ul>
				<ul id="subMenuItemMachine" runat="server" class="subMenuItem">
					<li class="left"></li>
					<li class="middle">
						<asp:LinkButton ID="btnMachine" runat="server" CausesValidation="False" OnClick="btnMachine_Click" Text="<%$ DataCenter:Machine %>"></asp:LinkButton>
					</li>
					<li class="right"></li>
				</ul>
			</div>
		</div>
	</div>
	<div class="divContent">	
		<div class="grey_frame">
			<div class="topspecial">
				<div class="bottom">
					<div class="left">
						<div class="right">
							<div class="bottomleft">
								<div class="bottomright">
									<div class="topleft">
										<div class="topright">
											<div class="content">
											    <uc4:SystemSettingsControl ID="ucSystemSettingsControl" runat="server" />
											    <uc5:UserSettingsControl ID="ucUserSettingsControl" runat="server" />
                                                <uc1:FacilityControl ID="ucFacilityControl" runat="server" />
                                                <uc2:DivisionControl id="ucDivisionControl" runat="server">
												</uc2:DivisionControl>
												<uc3:MachineControl id="ucMachineControl" runat="server">
												</uc3:MachineControl>
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
