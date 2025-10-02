using System;
using System.Security.Principal;

namespace M2M.DataCenter
{
	public class M2MImpersonatingPrincipal : IPrincipal, IM2MPrincipal
	{
        private readonly IIdentity m_Identity;

        public M2MImpersonatingPrincipal(string name)
		{
			m_Identity = M2MIdentity.GetAuthenticatedIdentity(name);
		}

		public bool IsInRole(string Role)
		{
			return true;
		}

		public IIdentity Identity
		{
			get { return m_Identity; }
		}

		public static void Login(string name)
		{
			Csla.ApplicationContext.User = new M2MImpersonatingPrincipal(name);
		}

		public static void Logout()
		{
			M2MPrincipal principal = M2MPrincipal.NewM2MPrincipal("");
			Csla.ApplicationContext.User = principal;
		}
	}
}
