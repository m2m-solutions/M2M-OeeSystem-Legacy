using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OPCDA.NET;
using NLog;

namespace M2M.DataCenter.OPC
{
	public class TagDefinitionList
	{
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
            
		public class TagDefinition
		{
            private readonly string m_MachineId = String.Empty;
            private readonly TagType m_TagType = TagType.NotApplicable;
            private readonly bool m_InvertedSignal = false;
            private readonly bool m_SendPanelRequest = false;
            private readonly int m_RequestDelay = 0;
            private readonly string m_DisplayName = "";
            private readonly int m_CategoryId = 0;
            private readonly OPCItemDef m_OpcItemDef = null;
            private bool m_Loaded = false;

            public string MachineId
			{
				get
				{
					return m_MachineId;
				}
			}

            public string TagId
			{
				get
				{
					return m_OpcItemDef.ItemID;
				}
			}

			public int Handle
            {
                get
                {
                    return m_OpcItemDef.HandleClient;
                }
            }

            public VarEnum DataType
            {
                get
                {
                    return m_OpcItemDef.RequestedDataType;
                }
            }

			public TagType TagType
			{
				get
				{
					return m_TagType;
				}
			}

            public bool InvertedSignal
            {
                get
                {
                    return m_InvertedSignal;
                }
            }

            public bool SendPanelRequest
            {
                get
                {
                    return m_SendPanelRequest;
                }
            }

            public int RequestDelay
            {
                get
                {
                    return m_RequestDelay;
                }
            }

            public string DisplayName
            {
                get
                {
                    return m_DisplayName;
                }
            }

            public int CategoryId
            {
                get
                {
                    return m_CategoryId;
                }
            }


            public OPCItemDef OpcItemDef
            {
                get
                {
                    return m_OpcItemDef;
                }
            }

            public int Priority
            {
                get
                {
                    switch (m_TagType)
                    {
                        case TagType.ConnectionCheck:
                            return 100;
                        case TagType.Cycles:
                            return 30;
                        case TagType.Rejected:
                            return 20;
                        case TagType.ProductionSwitch:
                            return 10;
                        case TagType.ArticleNumber:
                            return 8;
                        case TagType.Auto:
                            return 5;
                        default:
                            return 0;
                    }
                }
            }

            public bool Loaded
            {
                get
                {
                    return m_Loaded;
                }
                set
                {
                    m_Loaded = value;
                }
            }


            public TagDefinition(string machineId, TagType tagType, bool invertedSignal, bool sendPanelRequest, int requestDelay, string displayName, int categoryId, OPCItemDef opcItemDef)
			{
				m_MachineId = machineId;
            	m_TagType = tagType;
                m_InvertedSignal = invertedSignal;
                m_SendPanelRequest = sendPanelRequest;
                m_RequestDelay = requestDelay;
                m_DisplayName = displayName;
                m_CategoryId = categoryId;
                m_OpcItemDef = opcItemDef;
			}

            public static Predicate<TagDefinition> ByTagId(string tagId)
            {
                return delegate(TagDefinition item) { return item.TagId == tagId; };
            }

            public static Predicate<TagDefinition> ByHandle(int handle)
            {
                return delegate(TagDefinition item) { return item.Handle == handle; };
            }

            public static Predicate<TagDefinition> ByTagType(string machineId, TagType tagType)
            {
                return delegate(TagDefinition item) { return item.MachineId == machineId && item.TagType == tagType; };
            }

            public static Predicate<TagDefinition> ByMachineId(string machineId)
            {
                return delegate(TagDefinition item) { return item.MachineId == machineId; };
            }
		}

        private readonly List<TagDefinition> m_SubscribeTags = null;
       
		public OPCItemDef[] GetSubscribeItemDefs()
		{
			List<OPCItemDef> opcItemDefs = new List<OPCItemDef>();

            foreach (TagDefinition tagDefinition in m_SubscribeTags)
            {
                if(!tagDefinition.Loaded)
                    opcItemDefs.Add(tagDefinition.OpcItemDef);
            }

            return opcItemDefs.ToArray();
		}

		public TagDefinitionList()
		{
			m_SubscribeTags = new List<TagDefinition>();
     	}

        public string GetSpecialTagId(string accessPath, TagType tagType)
        {
            string tagId = String.Format("{0}.{1}", accessPath, tagType.ToString());
            return tagId;
        }

		public void LoadItemDefs()
		{
			TagInfoList subscribeTags = TagInfoList.GetActiveTags();

			int index = 0;

			foreach (TagInfoListItem tag in subscribeTags)
			{
                MachineSettingList settings = MachineSettingList.GetMachineSettingList(tag.MachineId);
                if (!settings.DisableCollection && tag.TagType > 0)
                {
                    m_SubscribeTags.Add(new TagDefinition(tag.MachineId, tag.TagType, tag.Inverted, tag.SendPanelRequest, tag.RequestDelay, tag.DisplayName, tag.CategoryId, new OPCItemDef(tag.TagId, true, index, (VarEnum)tag.DataType)));
                    index++;
                }
			}
		}

        public TagDefinition GetByHandle(int handle)
        {
            return m_SubscribeTags.Find(TagDefinition.ByHandle(handle));
        }

        public TagDefinition GetByTagId(string tagId)
		{
			return m_SubscribeTags.Find(TagDefinition.ByTagId(tagId));
		}

        public TagDefinition GetByTagType(string machineId, TagType tagType)
        {
            return m_SubscribeTags.Find(TagDefinition.ByTagType(machineId, tagType));
        }

        public List<string> GetMachines()
        {
            List<string> machines = new List<string>();

            foreach (TagDefinition tagDefinition in m_SubscribeTags)
            {
                if (!machines.Contains(tagDefinition.MachineId))
                    machines.Add(tagDefinition.MachineId);
            }

            return machines;
        }

	}
}
