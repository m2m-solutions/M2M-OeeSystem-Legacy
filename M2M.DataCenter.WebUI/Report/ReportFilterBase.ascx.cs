using System;
using System.Collections.Generic;
using System.Linq;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.WebUI.Report
{
    public abstract partial class ReportFilterBase : System.Web.UI.UserControl
    {
        public event EventHandler RefreshClick;

        protected void OnRefreshClick(EventArgs e)
        {
            if (RefreshClick != null)
                RefreshClick(this, e);
        }

        public abstract void BindData();

        public abstract Dictionary<string, object> GetParameters();

        protected string GetResourceString(string key)
        {
            return ResourceStrings.GetString(key);
        }
    }
}