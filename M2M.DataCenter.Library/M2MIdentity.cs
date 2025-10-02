using System;
using System.Security.Principal;

namespace M2M.DataCenter
{
	public class M2MIdentity: IIdentity
	{
        private readonly bool m_IsAuthenticated = false;
        private readonly string m_Name = "";

		#region IIdentity Members

		public string AuthenticationType
		{
			get { return "Csla"; }
		}

		public bool IsAuthenticated
		{
			get { return m_IsAuthenticated; }
		}

		public string Name
		{
			get { return m_Name; }
		}

		#endregion

		#region Factory Methods

		internal static M2MIdentity GetUnAuthenticatedIdentity()
		{
			return new M2MIdentity();
		}

		internal static M2MIdentity GetAuthenticatedIdentity(string name)
		{
			return new M2MIdentity(name);
		}

		protected M2MIdentity()
		{
		}

		protected M2MIdentity(string name)
		{
			m_IsAuthenticated = true;
			m_Name = name;
		}

		#endregion

	}
}
