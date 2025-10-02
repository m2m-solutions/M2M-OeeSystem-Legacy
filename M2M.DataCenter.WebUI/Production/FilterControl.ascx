<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilterControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Production.FilterControl" %>
<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
<script type="text/javascript">
    function FixClearSelection(sender) {

        if (!sender.get_text())
            sender.clearSelection();

    } 

    function HandleRequest(sender, eventArgs)
	{
		sender.clearItems();
		var context = eventArgs.get_context();
		
		var articlesFilter = eventArgs.get_text();
		
		if(articlesFilter != null)
		{
			context["ArticlesFilter"] = articlesFilter;
		}
		
		var startDatePicker = $find("<%= dtStart.ClientID %>");
		var startDate = startDatePicker.get_selectedDate();
		
		if (startDate != null)
		{
			context["StartDate"] = startDate;
		}
		
		var endDatePicker = $find("<%= dtEnd.ClientID %>");
		var endDate = endDatePicker.get_selectedDate();
		
		if (endDate != null)
		{
			context["EndDate"] = endDate;
		}
		
		var shiftCombo = $find("<%= ProductionShifts.ClientID %>");
		var shift = shiftCombo.get_value();
		
		if (shift != null)
		{
			context["Shift"] = shift;
		}
	}
	
	function HandleOpen(sender, eventArgs)
    {
		sender.requestItems(sender.get_text(), false);
}

    function onLoad(sender) {
        sender.get_inputDomElement().readOnly = "readonly";
    }

    function StopPropagation(e) {
        //cancel bubbling
        e.cancelBubble = true;
        if (e.stopPropagation) {
            e.stopPropagation();
        }
    }

    function onCheckBoxClick() {
        var combo = $find("<%= cbCategories.ClientID %>");
        //holds the text of all checked items
        var text = "";
        //get the collection of all items
        var items = combo.get_items();
        // holds the total number of items
        var count = items.get_count();
        // holds the number of selected items
        var selected = 0;
        //enumerate all items
        for (var i = 0; i < count; i++) {
            var item = items.getItem(i);
            //get the checkbox element of the current item
            var chk1 = $get(combo.get_id() + "_i" + i + "_chk1");
            if (chk1.checked) {
                text += item.get_text() + ",";
                selected++;
            }
        }


        if (selected > 0 && selected < count) {
            //remove the last comma from the string
            text = removeLastComma(text);
            //set the text of the combobox
            combo.set_text(text);
        }
        else if (selected == count) {
            // all checkboxes are checked
            combo.set_text('<%= GetResourceString("ShowAllAlerts") %>');
        }
        else if (selected == 0) {
            //no checkboxes are checked
            combo.set_text('<%= GetResourceString("ShowNoAlerts") %>');
        }
    }


    //this method removes the ending comma from a string
    function removeLastComma(str) {
        return str.replace(/,$/, "");
    }

    function onRefreshClick() {
        return true;
    }
</script>
</telerik:RadScriptBlock>
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
														<asp:Label ID="lbDateStart" runat="server" Text="<%$ DataCenter:DateFrom %>"></asp:Label>
													</div>
													<div class="input">
														<telerik:RadDatePicker ID="dtStart" Width="100px" runat="server" Skin="Default" AutoPostBack="False">
														</telerik:RadDatePicker>
													</div>
												</div>
												<div class="item">
													<div class="label">
														<asp:Label ID="lbDateEnd" runat="server" Text="<%$ DataCenter:DateTo %>"></asp:Label>
													</div>
													 <div class="input">
														<telerik:RadDatePicker ID="dtEnd" Width="100px" Skin="Default" AutoPostBack="False" runat="server">
														</telerik:RadDatePicker>
													</div>
												</div>
												<div class="item">
													<div class="label">
														<asp:Label ID="lbShift" runat="server" Text="<%$ DataCenter:Shift %>"></asp:Label>
													</div>
													 <div class="input">
														<telerik:RadComboBox ID="ProductionShifts" Width="190px" Skin="Default" AutoPostBack="False" runat="server">
															 <CollapseAnimation Duration="200" Type="OutQuint" />
														 </telerik:RadComboBox>
													</div>
												</div>
												<div class="item">
													<div class="label">
														<asp:Label ID="lbArticle" runat="server" Text="<%$ DataCenter:Article %>"></asp:Label>
													</div>
													 <div class="input">
														 <telerik:RadComboBox ID="rcbArticles"  OnClientDropDownOpening="HandleOpen" OnClientBlur="FixClearSelection" OnClientItemsRequesting="HandleRequest" LoadingMessage="<%$ DataCenter:Loading %>" Width="130px" EnableLoadOnDemand="True" ShowMoreResultsBox="False" ItemRequestTimeout="500" MarkFirstMatch="True" AllowCustomText="True" runat="server" Skin="Default">
															  <WebServiceSettings Path="~/Common/Articles.asmx" Method="" />
															  <CollapseAnimation Duration="200" Type="OutQuint" />
														 </telerik:RadComboBox>
													</div>
												</div>
												<div class="last">
													<div class="button">
														<asp:Button ID="btnRefresh" runat="server" CssClass="buttonSmallWhiteOnWhite" OnClientClick="onRefreshClick()" Text="<%$ DataCenter:Update %>" OnClick="btnRefresh_Click" />
													</div>
												</div>
												<div class="divider" style="height:10px"></div>
												<div class="item">
													<div class="label">
														<asp:CheckBox ID="checkSystemErrors" runat="server" Checked="False" Text="<%$ DataCenter:ShowSystemErrors %>" />
													</div>
												</div>
                                                <div class="item">
													 <div class="label">
														 <asp:CheckBox ID="checkAuto" runat="server" Checked="True" Style="display:block;" Text="<%$ DataCenter:Auto %>" />
													</div>
													
												</div>
                                                <div class="item">
													 <div class="label">
														 <asp:CheckBox ID="checkProductionSwitch" runat="server" Checked="True" Style="display:block;" Text="<%$ DataCenter:ProductionSwitch %>" />
													</div>
													
												</div>
												<div class="item">
													 <div class="label">
														 <asp:CheckBox ID="checkInfo" runat="server" Checked="True" Style="display:block;" Text="<%$ DataCenter:Information %>" />
													</div>
													
												</div>
                                                <div class="item">
													 <div class="label">
														 <asp:CheckBox ID="checkSecondary" runat="server" Visible="False" Checked="True" Text="<%$ DataCenter:SecondaryFailures %>" />
													</div>
													
												</div>
												<div class="item">
													<div class="input">
														<telerik:RadComboBox ID="cbCategories" runat="server" DataSourceID="SqlDataSource1"
                                                            DataValueField="CategoryId" DataTextField="DisplayName" AllowCustomText="true" 
                                                             EmptyMessage="<%$ DataCenter:ShowNoAlerts %>" Width="240px" EnableViewState="true" 
                                                             EnableTextSelection="False"  ChangeTextOnKeyBoardNavigation="false" 
                                                            LoadingMessage="<%$ DataCenter:Loading %>" OnClientLoad="onLoad"
                                                            onprerender="cbCategories_PreRender">
                                                            <ItemTemplate>
                                                                <div onclick="StopPropagation(event)" >
                                                                    <asp:CheckBox runat="server" ID="chk1" Checked="true" onclick="onCheckBoxClick()"/>
                                                                    <asp:Label runat="server" ID="Label1" AssociatedControlID="chk1">
                                                                        <%# Eval("DisplayName") %>
                                                                    </asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:RadComboBox>
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
<telerik:RadWindowManager ID="RadWindowManager1" runat="server" 
    Skin="Default" Localization-Cancel="<%$ DataCenter:Cancel %>" Localization-OK="<%$ DataCenter:OK %>" Title="<%$ DataCenter:ConfirmDeletion %>" >
</telerik:RadWindowManager>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    SelectCommand="SELECT [CategoryId], [DisplayName] FROM [EventCategories]">
</asp:SqlDataSource>