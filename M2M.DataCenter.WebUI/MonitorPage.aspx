<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonitorPage.aspx.cs" Inherits="M2M.DataCenter.WebUI.MonitorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin: 0; padding:0;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager" runat="server" >
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="TimerRefresh">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="Panel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
</telerik:RadAjaxManager>
        <asp:Timer ID="TimerRefresh" runat="server" Interval="3000" OnTick="OnRefreshTimer">
    </asp:Timer>
    <div>
        <asp:Panel ID="Panel1" Height="1080px" With="1920px" runat="server" Font-Names="'MS Sans Serif', Geneva, sans-serif" style="position:relative; background-repeat:no-repeat;" Font-Bold="False">
        </asp:Panel>
    </div>
    </form>
</body>
   
</html>
