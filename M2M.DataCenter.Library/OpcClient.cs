using System;
using OPCDA;
using OPCDA.NET;

namespace M2M.DataCenter
{
	[Serializable]
	public class OpcClient
	{
        private readonly OpcServer m_OpcServer = null;
        private SyncIOGroup m_SyncIoGroup = null;

        public OpcClient()
		{
			m_OpcServer = new OpcServer();
            m_OpcServer.ErrorsAsExecptions = true;
		}

		public void Connect(string opcServer)
		{
            m_OpcServer.Connect(opcServer);
       	}

		public object Read(string itemName)
		{
			if (m_SyncIoGroup == null)
			{
				m_SyncIoGroup = new SyncIOGroup(m_OpcServer);
			}

			OPCItemState result;

			m_SyncIoGroup.Read(OPCDATASOURCE.OPC_DS_CACHE, itemName, out result);

			if (result == null)
				return null;

			return result.DataValue;
		}

		public void Write(string itemName, object itemValue)
		{
			if (m_SyncIoGroup == null)
			{
				m_SyncIoGroup = new SyncIOGroup(m_OpcServer);
			}
			
			m_SyncIoGroup.Write(itemName, itemValue);
		}

		public void Disconnect()
		{
			if (m_SyncIoGroup != null)
			{
				m_SyncIoGroup.Dispose();
				m_SyncIoGroup = null;
			}

			if (m_OpcServer != null)
			{
				m_OpcServer.Disconnect();
            }
		}

	}
}
