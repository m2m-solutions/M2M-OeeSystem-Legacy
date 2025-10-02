using System;
using System.Linq;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.WebUI.Help
{
    public partial class AboutPage : System.Web.UI.Page
    {
        #region Members

        
        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                

                try
                {
                    Page.Title = ResourceStrings.GetString("Help.About");

                    lbCustomer.Text = M2MDataCenter.SystemSettings.Customer;
                }
                catch (Exception)
                {
                }
            }
        }

        #endregion

        #region Methods


        #endregion
    }
}