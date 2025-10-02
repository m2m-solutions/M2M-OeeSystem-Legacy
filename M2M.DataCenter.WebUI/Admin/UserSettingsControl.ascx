<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserSettingsControl.ascx.cs" Inherits="M2M.DataCenter.WebUI.Admin.UserSettingsControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register src="../Common/ResponseControl.ascx" tagname="ResponseControl" tagprefix="uc1" %>
<telerik:RadCodeBlock runat="server">
<script type="text/javascript"> 

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
    
    function onCheckBoxClick(sender) {
        var combo = $find(sender);
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
        else if (selected == 0) {
            //no checkboxes are checked
            combo.set_text(""); 
        }
        else {
            //all checkboxes are checked
            combo.set_text('<%= GetResourceString("All") %>');
        }

    }


    //this method removes the ending comma from a string
    function removeLastComma(str) {
        return str.replace(/,$/, "");
    }

</script>
</telerik:RadCodeBlock>
<div class="content">
	 <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="420px" Width="100%">
		<div style="text-align: center; width:100%;">
            <uc1:ResponseControl ID="ucResponse" runat="server" />
        </div>
	    <telerik:RadGrid ID="gridUsers" runat="server" AllowPaging="False" Height="400" 
                AutoGenerateColumns="False" GridLines="None" AllowMultiRowEdit="false"
                onneeddatasource="gridUsers_NeedDataSource" 
                ondatabound="gridUsers_DataBound" 
                onitemdatabound="gridUsers_ItemDataBound" 
                onupdatecommand="gridUsers_UpdateCommand" 
                ondeletecommand="gridUsers_DeleteCommand" 
                oninsertcommand="gridUsers_InsertCommand">
   		    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
            <MasterTableView CommandItemDisplay="Top" 
                DataKeyNames="UserId" EditMode="EditForms" NoMasterRecordsText="">
                <CommandItemSettings AddNewRecordText="<%$ DataCenter:AddNewUser %>" RefreshImageUrl="" 
                    RefreshText="" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridEditCommandColumn ButtonType="ImageButton" CancelText="<%$ DataCenter:Cancel %>" 
                        EditText="<%$ DataCenter:Edit %>" InsertText="<%$ DataCenter:Save %>" UniqueName="EditCommandColumn" 
                        UpdateText="Spara">
                        <HeaderStyle Width="50px" />
                        <ItemStyle Width="50px" />
                    </telerik:GridEditCommandColumn>
                    <telerik:GridBoundColumn DataField="UserId" 
                        ForceExtractValue="InEditMode" 
                        HeaderText="<%$ DataCenter:UserName %>" 
                        UniqueName="UserId">
                        <HeaderStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Password" Display="False"
                        HeaderText="<%$ DataCenter:Password %>" 
                        UniqueName="Password">
                        <HeaderStyle Width="90px" />
                        <ItemStyle Width="90px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DisplayName" 
                        HeaderText="<%$ DataCenter:DisplayName %>" 
                        UniqueName="DisplayName">
                        <HeaderStyle Width="110px" />
                        <ItemStyle Width="110px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn DataField="RoleWithHighestAccess" HeaderText="<%$ DataCenter:Role %>" 
                        UniqueName="RoleWithHighestAccess">
                        <HeaderStyle Width="120px" />
                        <ItemStyle Width="120px" Wrap="false" />
                        
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="DivisionsAsString" 
                        HeaderText="<%$ DataCenter:Divisions %>" UniqueName="DivisionsAsString">
                        <HeaderStyle Width="200px" />
                        <ItemStyle Width="200px" Wrap="false" />
                        <ItemTemplate>
                            <asp:Label ID="lbDivisions" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DivisionsAsString")%>' />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="ModulesAsString" HeaderText="<%$ DataCenter:AdditionalModules %>" 
                        UniqueName="ModulesAsString">
                        <ItemStyle Wrap="false" />
                        <ItemTemplate>
                            <asp:Label ID="lbModules" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ModulesAsString")%>' />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="Culture" HeaderText="<%$ DataCenter:Culture %>" 
                        UniqueName="Culture">
                        <ItemStyle Wrap="false" />
                        <ItemTemplate>
                            <asp:Label ID="lbCulture" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Settings.Culture")%> ' />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" 
                        ConfirmDialogType="RadWindow" ConfirmText="<%$ DataCenter:ConfirmUserDeletion %>" 
                        ConfirmTitle="<%$ DataCenter:Delete %>" Text="<%$ DataCenter:Delete %>" UniqueName="DeleteColumn">
                        <HeaderStyle Width="30px" />
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </telerik:GridButtonColumn>
                </Columns>
                <EditFormSettings EditFormType="Template">
                    <EditColumn FilterControlAltText="Filter EditCommandColumn1 column" 
                        UniqueName="EditCommandColumn1">
                    </EditColumn>
                    <FormTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="Label1" runat="server" ForeColor="Red" 
                                        Text="<%$ DataCenter:RequiredFieldsNote %>"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    <asp:Literal ID="Literal1" runat="server" Text="<%$ DataCenter:UserName#: %>" /></td>
                                <td style="width: 350px">
                                    <asp:TextBox ID="tbUserName" runat="server" 
                                        Enabled="<%# (Container is GridEditFormInsertItem) ? true : false %>" 
                                        TabIndex="1" Text='<%# Bind("UserId") %>'></asp:TextBox>
                                    <span style="color: Red">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" 
                                        ControlToValidate="tbUserName" ErrorMessage=""></asp:RequiredFieldValidator>
                                </td>
                                <td style="width: 100px">
                                    <asp:Literal ID="Literal2" runat="server" Text="<%$ DataCenter:Role#: %>" /></td>
                                <td>
                                    <asp:DropDownList ID="dlRoles" runat="server" TabIndex="3">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    <asp:Literal ID="Literal3" runat="server" Text="<%$ DataCenter:Password#: %>" /></td>
                                <td style="width: 350px">
                                    <asp:TextBox ID="tbPassword" runat="server" TabIndex="2" TextMode="Password"  
                                       value='<%# Eval("password") %>' Text='<%# Bind("Password") %>'></asp:TextBox>
                                    <span style="color: Red">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" 
                                        ControlToValidate="tbPassword" ErrorMessage=""></asp:RequiredFieldValidator>
                                </td>
                                <td style="width: 100px">
                                    <asp:Literal ID="Literal6" runat="server" Text="<%$ DataCenter:Divisions#: %>" /></td>
                                <td>
                                    <telerik:RadComboBox ID="cbDivisions" runat="server" AllowCustomText="true" 
                                        ChangeTextOnKeyBoardNavigation="false" DataTextField="DisplayName" 
                                        DataValueField="DivisionId" EmptyMessage="<%$ DataCenter:SelectDivisions %>" 
                                        EnableTextSelection="False" LoadingMessage="<%$ DataCenter:Loading %>" 
                                         Width="240px" OnClientLoad="onLoad" TabIndex="4" >
                                        <ItemTemplate>
                                            <div onclick="StopPropagation(event)" >
                                            <asp:CheckBox ID="chk1" runat="server" />
                                            <asp:Label ID="lb1" runat="server" AssociatedControlID="chk1" Text='<%# Eval("DisplayName") %>' />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                    <span style="color: Red">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="cbDivisions" ErrorMessage=""></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    <asp:Literal ID="Literal4" runat="server" Text="<%$ DataCenter:DisplayName#: %>" /></td>
                                <td style="width: 350px">
                                    <asp:TextBox ID="tbDisplayName" runat="server" TabIndex="7" 
                                        Text='<%# Bind("DisplayName") %>'></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                    <asp:Literal ID="Literal7" runat="server" Text="<%$ DataCenter:AdditionalModules#: %>" /></td>
                                <td>
                                    <telerik:RadComboBox ID="cbModules" runat="server" AllowCustomText="true" 
                                        ChangeTextOnKeyBoardNavigation="false" DataTextField="DisplayName" 
                                        DataValueField="Module" EmptyMessage="<%$ DataCenter:AddModules %>" 
                                        EnableTextSelection="False" LoadingMessage="<%$ DataCenter:Loading %>" 
                                         Width="240px" OnClientLoad="onLoad" TabIndex="4" >
                                        <ItemTemplate>
                                            <div onclick="StopPropagation(event)" >
                                            <asp:CheckBox ID="chk1" runat="server" />
                                            <asp:Label ID="lb1" runat="server" AssociatedControlID="chk1" Text='<%# Eval("DisplayName") %>' />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    <asp:Literal ID="Literal5" runat="server" Text="<%$ DataCenter:Culture#: %>" /></td>
                                <td style="width: 350px">
                                    <asp:DropDownList ID="dlCultures" runat="server" TabIndex="6">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px" >
                                    <asp:Button ID="btnUpdate" runat="server" 
                                        CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>' 
                                        TabIndex="10" 
                                        Text='<%$ DataCenter:Save %>'
                                         />
                                </td>
                                <td>
                                <asp:Button ID="btnCancel" runat="server" CausesValidation="False" TabIndex="6"
                                        CommandName="Cancel" Text="<%$ DataCenter:Cancel %>" />
                                </td>
                            </tr>
                        </table>
                    </FormTemplate>
                </EditFormSettings>
            </MasterTableView>
	        <ClientSettings EnableRowHoverStyle="true">
	            <Scrolling AllowScroll="true" UseStaticHeaders="true" />
            </ClientSettings>
	        <FilterMenu EnableImageSprites="False">
            </FilterMenu>
	    </telerik:RadGrid>
	</telerik:RadAjaxPanel>
</div>
