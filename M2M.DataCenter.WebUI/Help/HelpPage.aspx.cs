using System;
using System.Linq;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.WebUI.Help
{
    public partial class HelpPage : System.Web.UI.Page
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
                    string helpContext = Request.QueryString["Context"];
                    Page.Title = String.Format("{0} - {1}", ResourceStrings.GetString("Help"), ResourceStrings.GetString("Help." + helpContext));
                    
                    switch(ResourceStrings.GetString("CurrentCulture"))
                    {
                        case "Svenska":
                            PlaceHolder1.Controls.Add(LoadControl("HelpOeeControl_sv.ascx"));
                            break;
                        case "Deutsch":
                            PlaceHolder1.Controls.Add(LoadControl("HelpOeeControl_de.ascx"));
                            break;
                        case "English":
                        default:
                            PlaceHolder1.Controls.Add(LoadControl("HelpOeeControl.ascx"));
                            break;
                    }
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