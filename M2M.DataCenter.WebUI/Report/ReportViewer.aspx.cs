using System;
using System.Web.UI;
using Telerik.Reporting;
using M2M.DataCenter.Localization;
using System.Collections.Generic;

namespace M2M.DataCenter.WebUI.Report
{

    public partial class ReportViewer : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string reportName = Server.UrlDecode(this.Request.QueryString["ReportName"]);
            
            
            if (!string.IsNullOrEmpty(reportName))
            {
                string filterControlName = String.Format("Filter{0}.ascx", Server.UrlDecode(this.Request.QueryString["Filter"]));
                this.Page.Title = String.Format(ResourceStrings.GetString("Page.Title.ReportViewer"), Server.UrlDecode(this.Request.QueryString["Title"]));

                ReportFilterBase filterControl = (ReportFilterBase)LoadControl(filterControlName);
                filterControl.RefreshClick += new EventHandler(filterControl_RefreshClick);
                filterControl.BindData();
                divFilter.Controls.Add(filterControl);
            }
        }
        
        protected void  filterControl_RefreshClick(object sender, EventArgs e)
        {
            
            string reportName = Server.UrlDecode(this.Request.QueryString["ReportName"]);
            
            if (!string.IsNullOrEmpty(reportName))
            {
                Type reportType = Type.GetType(reportName);
                IReportDocument report = (IReportDocument)Activator.CreateInstance(reportType);

                
                Telerik.Reporting.InstanceReportSource instanceReportSource = new Telerik.Reporting.InstanceReportSource();

                Dictionary<string, object> parameters = (sender as ReportFilterBase).GetParameters();

                foreach (KeyValuePair<string, object> param in parameters)
                {
                    instanceReportSource.Parameters.Add(new Parameter(param.Key, param.Value));
                }
                
                instanceReportSource.ReportDocument = report;
                this.ReportViewer1.ReportSource = null;
                this.ReportViewer1.ReportSource = instanceReportSource;

            }
        }
   }
}