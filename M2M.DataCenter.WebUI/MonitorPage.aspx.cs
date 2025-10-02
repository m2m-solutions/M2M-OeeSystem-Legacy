using Csla;
using M2M.Monitor.Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M2M.DataCenter.WebUI
{
    public partial class MonitorPage : System.Web.UI.Page
    {
        private string DivisionId
        {
            get
            {
                object obj = ViewState["DivisionId"];
                if (obj == null)
                    return null;
                return obj.ToString();
            }
            set
            {
                ViewState["DivisionId"] = value;
            }
        }

        public GenericFilter Criteria
        {
            get
            {
                return (GenericFilter)ViewState["CurrentCriteria"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            DivisionId = Request.QueryString["d"];
            if (!IsPostBack)
            {
                TimerRefresh.Interval = M2MDataCenter.SystemSettings.MonitorRefreshInterval;
                M2MDataCenter.ReloadSystemSettings();
                Panel1.BackImageUrl = string.Format("~/CustomerSpecifics/{0}", M2MDataCenter.GetDivision(DivisionId).Settings.MonitorImageFile);
                BindData();
            }
        }

        protected void OnRefreshTimer(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData()
        {
            Panel1.Controls.Clear();
            MonitorData monitorData = MonitorHelper.GetData(DivisionId);
            if (monitorData == null)
                return;

            DivisionSettingList divisionSettings = DivisionSettingList.GetDivisionSettingList(DivisionId);
            
            if (divisionSettings.MonitorPace.HasValue)
                Panel1.Controls.Add(CreateLabel(monitorData.Pace, divisionSettings.MonitorPace, ColorTranslator.FromHtml(monitorData.PaceColor), "center"));

            if (divisionSettings.MonitorPaceIdeal.HasValue)
                Panel1.Controls.Add(CreateLabel(monitorData.PaceIdeal, divisionSettings.MonitorPaceIdeal, Color.Gray, "center"));

            if (divisionSettings.MonitorPaceIdeal2.HasValue)
                Panel1.Controls.Add(CreateLabel(monitorData.PaceIdeal2, divisionSettings.MonitorPaceIdeal2, Color.Gray, "center"));

            if (divisionSettings.MonitorOee.HasValue)
                Panel1.Controls.Add(CreateLabel(monitorData.Oee, divisionSettings.MonitorOee));

            foreach (MonitorDetail detail in monitorData.MonitorDetails)
            {
                MachineSettingList machineSettings = MachineSettingList.GetMachineSettingList(detail.MachineId);
                if (machineSettings.MonitorData.HasValue)
                    Panel1.Controls.Add(CreateLabel(detail.Value, machineSettings.MonitorData, ColorTranslator.FromHtml(detail.Color)));
            }

            if (divisionSettings.MonitorChangeOverCount.HasValue)
                Panel1.Controls.Add(CreateLabel(monitorData.ChangeOvers, divisionSettings.MonitorChangeOverCount));

            if (divisionSettings.MonitorChangeOverLatest.HasValue)
                Panel1.Controls.Add(CreateLabel(monitorData.Latest, divisionSettings.MonitorChangeOverLatest));

            if (divisionSettings.MonitorChangeOverAverage.HasValue)
                Panel1.Controls.Add(CreateLabel(monitorData.Average, divisionSettings.MonitorChangeOverAverage));

            if (divisionSettings.MonitorChangeOverIdeal.HasValue)
                Panel1.Controls.Add(CreateLabel(monitorData.Ideal, divisionSettings.MonitorChangeOverIdeal));
        }

        public Control CreateLabel(string value, MonitorObject settings)
        {
            return CreateLabel(value, settings, Color.Black, "center");
        }

        public Control CreateLabel(string value, MonitorObject settings, Color color)
        {
            return CreateLabel(value, settings, color, "center");
        }

        public Control CreateLabel(string value, MonitorObject settings, string align)
        {
            return CreateLabel(value, settings, Color.Black, align);
        }

        public Control CreateLabel(string value, MonitorObject settings, Color color, string align)
        {
            var label = new System.Web.UI.WebControls.Label();
            label.Width = new System.Web.UI.WebControls.Unit(settings.Width, System.Web.UI.WebControls.UnitType.Pixel);
            label.ForeColor = color;
            label.Font.Size = new System.Web.UI.WebControls.FontUnit(settings.FontSize, System.Web.UI.WebControls.UnitType.Pixel);
            label.Text = value;
            label.Style["top"] = String.Format("{0}px", settings.Position.Y);
            label.Style["left"] = String.Format("{0}px", settings.Position.X);
            label.Style["position"] = "absolute";
            label.Style["text-align"] = align;
            return label;
        }
        
    }
}