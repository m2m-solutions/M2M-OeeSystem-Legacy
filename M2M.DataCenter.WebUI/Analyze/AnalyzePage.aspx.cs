using System;
using System.Linq;
using System.Web.UI;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.WebUI.Analyze
{
    public partial class AnalyzePage : System.Web.UI.Page
    {
        #region Members

        public GenericFilter Criteria
        {
            get
            {
                return (GenericFilter)Session["CurrentCriteria"];
            }
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!M2MDataCenter.User.CanAccessModule("Analyze"))
                Response.Redirect("~/Logon.aspx");

            Control refreshButton = ucFilterControl.FindControl("btnRefresh");

            Control gridEvents = ucEventListControl.FindControl("gridEvents");
            
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(refreshButton, gridEvents);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(gridEvents , gridEvents);
            
            if (!IsPostBack)
            {
                
                Criteria.DivisionId = Request.QueryString["DivisionId"];
                Criteria.MachineId = Request.QueryString["MachineId"];

                if (Criteria.MachineId == null)
                {
                    Page.Title = String.Format(ResourceStrings.GetString("Page.Title.Analyze.Division"), M2MDataCenter.GetDivision(Criteria.DivisionId).DisplayName);
                }
                else
                {
                    Page.Title = String.Format(ResourceStrings.GetString("Page.Title.Analyze.Machine"), M2MDataCenter.GetDivision(Criteria.DivisionId).DisplayName, M2MDataCenter.GetMachine(Criteria.DivisionId, Criteria.MachineId).DisplayName);
                }

                BindData();
            }


            ucFilterControl.RefreshClick += new EventHandler(ucFilterControl_RefreshClick);
        }

        private void ucFilterControl_RefreshClick(object sender, EventArgs e)
        {
            Criteria.StartDate = ucFilterControl.StartDate;
            Criteria.EndDate = ucFilterControl.EndDate;
            Criteria.ArticleNumber = ucFilterControl.ArticleNumber;
            Criteria.ShowInformation = ucFilterControl.ShowInformation;
            Criteria.ShowAuto = ucFilterControl.ShowAuto;
            Criteria.ShowProductionSwitch = ucFilterControl.ShowProductionSwitch;
            Criteria.ShowSecondaryFailures = ucFilterControl.ShowSecondaryFailures;
            Criteria.Categories = ucFilterControl.Categories;
            Criteria.Shift = ucFilterControl.Shift;
            Criteria.ShowSystemErrors = ucFilterControl.ShowSystemErrors;
            ucEventListControl.PageIndex = 0;
            BindData();
        }

        #endregion

        #region Methods

        public void BindData()
        {
            BindFilter();
            BindInfo();
            BindEvents();
        }

        private void BindFilter()
        {
            ucFilterControl.StartDate = Criteria.StartDate;
            ucFilterControl.EndDate = Criteria.EndDate;
            ucFilterControl.Shift = Criteria.Shift;
            ucFilterControl.ArticleNumber = Criteria.ArticleNumber;
            ucFilterControl.ShowInformation = Criteria.ShowInformation;
            ucFilterControl.ShowAuto = Criteria.ShowAuto;
            ucFilterControl.ShowProductionSwitch = Criteria.ShowProductionSwitch;
            ucFilterControl.ShowSecondaryFailures = Criteria.ShowSecondaryFailures;
            ucFilterControl.Categories = Criteria.Categories;
            ucFilterControl.ShowSystemErrors = Criteria.ShowSystemErrors;
            ucFilterControl.BindData();
        }

        private void BindInfo()
        {
            if (Criteria.MachineId == null)
            {
                lbInfo.Text = M2MDataCenter.GetDivision(Criteria.DivisionId).DisplayName;
                buttonUp.Text = ResourceStrings.GetString("ShowAllDivisions");
                buttonUp.PostBackUrl = "../Production/FacilityPage.aspx";
                buttonShowDefault.PostBackUrl = "../Production/DivisionPage.aspx?DivisionId=" + Criteria.DivisionId;
                buttonShowGraphical.PostBackUrl = "../Status/StatusPage.aspx?DivisionId=" + Criteria.DivisionId;
                buttonShowGraphical.Style["display"] = M2MDataCenter.User.CanAccessModule("Status") && M2MDataCenter.GetDivision(Criteria.DivisionId).Settings.OverviewImageFile != "" ? "block" : "none";
            }
            else
            {
                lbInfo.Text = M2MDataCenter.GetDivision(Criteria.DivisionId).DisplayName + " - " + M2MDataCenter.GetMachine(Criteria.DivisionId, Criteria.MachineId).DisplayName;
                buttonUp.Text = ResourceStrings.GetString("ShowDivision");
                buttonUp.PostBackUrl = "../Production/DivisionPage.aspx?DivisionId=" + Criteria.DivisionId;
                buttonShowDefault.PostBackUrl = "../Production/MachinePage.aspx?DivisionId=" + Criteria.DivisionId + "&MachineId=" + Criteria.MachineId;
                buttonShowGraphical.Style["display"] = "none";
            }
        }

        private void BindEvents()
        {
            ucEventListControl.BindData();
        }

        #endregion
    }
}