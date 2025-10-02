using System;
using System.Linq;
using System.Web.UI.WebControls;


using M2M.DataCenter.Localization;
using Telerik.Web.UI;

namespace M2M.DataCenter.WebUI.Admin
{
    public partial class SystemSettingsControl : System.Web.UI.UserControl
    {
 
        private SystemSettingCollection SystemSettings
        {
            get
			{
                return (SystemSettingCollection)(ViewState["SystemSettings"] ?? (ViewState["SystemSettings"] = SystemSettingCollection.GetSettingCollection()));
			}
			set
			{
                ViewState["SystemSettings"] = value;
			}
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            SqlDataSource1.ConnectionString = Database.SystemConnectionString;
            SqlDataSource2.ConnectionString = Database.SystemConnectionString;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                pnlDataCalculation.Enabled = M2MDataCenter.User.IsInRole("System");
                pnlUI.Enabled = M2MDataCenter.User.IsInRole("System");
                gridCategories.Enabled = M2MDataCenter.User.IsInRole("System");
                gridShifts.Enabled = M2MDataCenter.User.IsInRole("System");
                btnSave.Visible = M2MDataCenter.User.IsInRole("System");

                if(M2MDataCenter.User.IsInRole("System"))
                    RadAjaxPanel1.Height = Unit.Pixel(200);
                else
                    RadAjaxPanel1.Height = Unit.Pixel(170);

                LoadSettings();

            }
            ucResponse.Reset();
        }

        private void LoadSettings()
        {
            // UI
            tbStartDateOffset.Value = SystemSettings.StartDateOffset;
            tbStoppageGraphGroupCount.Value = SystemSettings.StoppageGraphGroupCount;

            //Data Calculation
            tbCalculatorInterval.Value = SystemSettings.CalculateInterval;
        }

        private void SaveSettings()
        {
            try
            {
                if (M2MDataCenter.User.IsInRole("System"))
                {
                    SystemSettings.StartDateOffset = (int)tbStartDateOffset.Value.Value;
                    SystemSettings.StoppageGraphGroupCount = (int)tbStoppageGraphGroupCount.Value;
                    SystemSettings.CalculateInterval = (int)tbCalculatorInterval.Value.Value;
                }

                SystemSettings = SystemSettings.Save();
                
                M2MDataCenter.ReloadSystemSettings();
                ucResponse.SetInformation(ResourceStrings.GetString("SettingsSaved"));
            }
            catch (Exception ex)
            {
                ucResponse.SetError(ResourceStrings.GetString("SettingsNotSaved"), ex);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
		{
            SaveSettings();
     	}
        
        protected void SqlDataSource1_Changed(object sender, SqlDataSourceStatusEventArgs e)
        {
            M2MDataCenter.ReloadCategories();
        }

        protected void SqlDataSource2_Changed(object sender, SqlDataSourceStatusEventArgs e)
        {
            M2MDataCenter.ReloadShifts();
        }

        protected string GetResourceString(string key)
        {
            return ResourceStrings.GetString(key);
        }

        protected void gridShifts_PreRender(object sender, EventArgs e)
        {
            if (SystemSettings.PurplepointMode)
            {
                ProductionModeWarning.Visible = true;
                foreach (GridDataItem dataItem in gridShifts.MasterTableView.Items)
                {
                    ((ImageButton)dataItem["EditCommandColumn"].Controls[0]).Visible = false;
                    ((ImageButton)dataItem["DeleteCommandColumn"].Controls[0]).Visible = false;
                    GridCommandItem cmdItem = (GridCommandItem)gridShifts.MasterTableView.GetItems(GridItemType.CommandItem)[0];
                    ((LinkButton)cmdItem.FindControl("InitInsertButton")).Visible = false;
                    ((Button)cmdItem.FindControl("AddNewRecordButton")).Visible = false;
                }
            }
        }
    }
}