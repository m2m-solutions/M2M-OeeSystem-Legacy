<%@ Page Language="C#" AutoEventWireup="true" Inherits="M2M.DataCenter.WebUI.Report.ReportViewer" Codebehind="ReportViewer.aspx.cs" %>

<%@ Register TagPrefix="telerik" Assembly="Telerik.ReportViewer.WebForms" Namespace="Telerik.ReportViewer.WebForms" %>

<%@ Assembly Name="Telerik.ReportViewer.WebForms" %>

<html xmlns="http://www.w3.org/1999/xhtml" id="html">
<head runat="server">
    <title>telerik Report Viewer</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <style type="text/css">	
    	html#html, body#body, form#form1, div#content, center#center
		{	
			border: 0px solid black;
			padding: 0px;
			margin: 0px;
			height: 100%;
		}
		.divFilter 
        {
            float:left;
            width: 920px;
            clear: both;
	        padding: 10px 20px;
	        font-family: Calibri;
	        font-size: 12px;
	        
        }
        .filterView
        {
	        width: 100%;
	        font-size: 12px;
	        text-align:left;
	        position: relative;
	        padding: 0px;
        }
        .filterView .item
        {
            position: absolute;	       
	    }

        .filterView .label
        {
	        padding-left: 3px;
        }

        .filterView .last
        {
	        position: absolute;
	    }

        
        .divider
        {
	        width: 100%;
	        height: 1px;
	        font-size: 1px;
	        clear: both;
	
        }
        input.buttonSmallWhiteOnWhite
{
	background-color: transparent;
	background-image: url(../images/buttonSmallWhiteOnWhite.gif);
	background-repeat: no-repeat;
	width: 118px;
	height: 21px;
	padding: 0 0 3px 0;
	margin-top: 0;
	font-family: Calibri;
	font-size: 12px;
	text-align: center;
	text-decoration: none;
	color: #969696;
	border-top-style: none;
	border-right-style: none;
	border-left-style: none;
	border-bottom-style: none;
}

input.buttonSmallWhiteOnWhite:hover, input.buttonSmallWhiteOnWhite:active, input.buttonSmallWhiteOnWhite:focus
 {
	background-color: transparent;
	background-image: url(../images/buttonSmallWhiteOnWhite.gif);
	background-repeat: no-repeat;
	width: 118px;
	height: 21px;
	padding: 0 0 3px 0;
	margin-top: 0;
	font-size: 12px;
	font-family: Calibri;
	text-align: center;
	text-decoration: none;
	color: #515151;
	border-top-style: none;
	border-right-style: none;
	border-left-style: none;
	border-bottom-style: none;
}
    </style>
</head>
<body id="body">
    <form id="form1" runat="server"> 
    <asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager> 
    <div id="content">
    <center id="center">
    <div class="divFilter" id="divFilter" runat="server">
    </div>
    <telerik:ReportViewer ID="ReportViewer1" runat="server" ShowPrintButton="true" 
            width="99%" height="99%"  
            ShowHistoryButtons="False" ShowPrintPreviewButton="False"  
            ViewMode="PrintPreview" >
                                                    <Resources CurrentPageToolTip="<%$ DataCenter:ReportViewer.CurrentPageToolTip %>"
                                                        ExportButtonText="<%$ DataCenter:ReportViewer.ExportButtonText %>" 
                                                        ExportSelectFormatText="<%$ DataCenter:ReportViewer.ExportSelectFormatText %>" 
                                                        ExportToolTip="<%$ DataCenter:ReportViewer.ExportToolTip %>" 
                                                        FirstPageToolTip="<%$ DataCenter:ReportViewer.FirstPageToolTip %>" 
                                                        LabelOf="<%$ DataCenter:ReportViewer.LabelOf %>" 
                                                        LastPageToolTip="<%$ DataCenter:ReportViewer.LastPageToolTip %>"
                                                        NextPageToolTip="<%$ DataCenter:ReportViewer.NextPageToolTip %>" 
                                                        ParametersToolTip="<%$ DataCenter:ReportViewer.ParametersToolTip %>" 
                                                        PreviousPageToolTip="<%$ DataCenter:ReportViewer.PreviousPageToolTip %>" 
                                                        PrintToolTip="<%$ DataCenter:ReportViewer.PrintToolTip %>" 
                                                        ProcessingReportMessage="<%$ DataCenter:ReportViewer.ProcessingReportMessage %>" 
                                                        RefreshToolTip="<%$ DataCenter:ReportViewer.RefreshToolTip %>" 
                                                        ReportParametersInputDataError="<%$ DataCenter:ReportViewer.ReportParametersInputDataError %>" 
                                                        ReportParametersInvalidValueText="<%$ DataCenter:ReportViewer.ReportParametersInvalidValueText %>" 
                                                        ReportParametersNoValueText="<%$ DataCenter:ReportViewer.ReportParametersNoValueText %>" 
                                                        ReportParametersPreviewButtonText="<%$ DataCenter:ReportViewer.ReportParametersPreviewButtonText %>" 
                                                        ReportParametersSelectAllText="<%$ DataCenter:ReportViewer.ReportParametersSelectAllText %>" 
                                                        ReportParametersSelectAValueText="<%$ DataCenter:ReportViewer.ReportParametersSelectAValueText %>" 
                                                        ReportParametersNullText="<%$ DataCenter:ReportViewer.ReportParametersSelectAllText %>" 
                                                        TogglePageLayoutToolTip="<%$ DataCenter:ReportViewer.TogglePageLayoutToolTip %>"
                                                        ZoomToPageWidth="<%$ DataCenter:ReportViewer.ZoomToPageWidth %>"  
                                                        ZoomToWholePage="<%$ DataCenter:ReportViewer.ZoomToWholePage %>"  MissingReportSource="<%$ DataCenter:ReportViewer.ReportParametersInputDataError %>" />
                                                </telerik:ReportViewer></center>
                                                
                                                </div>
    </form>
</body>
</html>
