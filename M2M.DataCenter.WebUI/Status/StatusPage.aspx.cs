using System;
using System.Linq;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.WebUI.Status
{
    public partial class StatusPage : System.Web.UI.Page
    {
        #region Members


        public GenericFilter Criteria
        {
            get
            {
                try
                {
                    return (GenericFilter)Session["CurrentCriteria"];
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!M2MDataCenter.User.CanAccessModule("Status"))
                Response.Redirect("~/Logon.aspx");

            if (!IsPostBack)
            {
                try
                {
                    Criteria.DivisionId = Request.QueryString["DivisionId"];
                    Page.Title = String.Format(ResourceStrings.GetString("Page.Title.Division"), M2MDataCenter.GetDivision(Criteria.DivisionId).DisplayName);

                    BindData();
                }
                catch (Exception)
                {
                }
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

            BindData();
        }

        #endregion

        #region Methods

        public void BindData()
        {
            BindFilter();
            BindInfo();
            BindOverviewData();
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
            lbInfo.Text = M2MDataCenter.GetDivision(Criteria.DivisionId).DisplayName;
            buttonUp.PostBackUrl = "../Production/FacilityPage.aspx";
            buttonShowDefault.PostBackUrl = "../Production/DivisionPage.aspx?DivisionId=" + Criteria.DivisionId;
            buttonShowAnalytical.PostBackUrl = "../Analyze/AnalyzePage.aspx?DivisionId=" + Criteria.DivisionId;
            buttonShowAnalytical.Style["display"] = M2MDataCenter.User.CanAccessModule("Analyze") ? "block" : "none";
        }

        private void BindOverviewData()
        {
            ucStatusControl.BindData();
        }

        #endregion
    }
}