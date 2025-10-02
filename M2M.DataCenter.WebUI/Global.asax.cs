using System;


namespace M2M.DataCenter.WebUI
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// Application_AcquireRequestState
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Application_AcquireRequestState(Object sender, EventArgs e)
		{
			M2MPrincipal.ResetPrincipal();
		}
	}
}