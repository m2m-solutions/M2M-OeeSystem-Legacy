using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using M2M.DataCenter.Localization;
using System.Threading;
using System.Globalization;

namespace M2M.DataCenter.WebUI
{
	public partial class Logon : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!Page.IsPostBack)
			{
                Page.Title = ResourceStrings.GetString("Page.Title.Logon");
				M2MDataCenter.Logout();
				Session.Abandon();
				FormsAuthentication.SignOut();
			}

            this.divCheck.Visible = ApplicationSettings.ShowLogonCheckBox;
		}

        protected override void InitializeCulture()
        {
            string culture = "";

            
            if (Request.Form["selectedLanguage"] != null)
            {
                culture = Request.Form["selectedLanguage"];
            }
            else
            {
                culture = CultureList.GetCulture(M2MDataCenter.SystemSettings.Culture);
            }

            if (culture != "")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            }

            base.InitializeCulture();
        }

       	protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
		{
            Database.ShowOld = ApplicationSettings.ShowLogonCheckBox && showCheck.Checked;
			e.Authenticated = M2MDataCenter.ValidateUser(Login1.UserName, Login1.Password);
		}

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            if (UserProfile.StartPage != "")
                Response.Redirect(UserProfile.StartPage);
            
        }

        protected void btnEnglish_Click(object sender, EventArgs e)
        {
            this.selectedLanguage.Value = "en";
          
        }

        protected void btnSwedish_Click(object sender, EventArgs e)
        {
            this.selectedLanguage.Value = "sv";
        }

        protected void selectedLanguage_ValueChanged(object sender, EventArgs e)
        {

        }

	}
}
