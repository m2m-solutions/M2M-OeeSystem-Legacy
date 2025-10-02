using System;
using Csla;
using System.Data.SqlClient;
using System.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public class StoppageListItem : ReadOnlyBase<StoppageListItem>
    {
        #region Business Methods

        private Guid m_StoppageId = Guid.Empty;
        private string m_MachineId = String.Empty;
        private int m_Shift = -1;
        private int m_CategoryId = -1;
        private string m_ArticleNumber = String.Empty;
        private string m_DisplayName = String.Empty;
        private TagType m_TagType = TagType.NotApplicable;
        private SmartDate m_StartTime = new SmartDate();
        private SmartDate m_EndTime = new SmartDate();
        private string m_Category = String.Empty;
        private double m_StopRatio = 1.0;

        public Guid StoppageId
        {
            get
            {
                return m_StoppageId;
            }
        }

        public string MachineId
        {
            get
            {
                return m_MachineId;
            }
        }

        public string ArticleNumber
        {
            get
            {
                return m_ArticleNumber;
            }
        }

        public int Shift
        {
            get
            {
                return m_Shift;
            }
        }

        public int CategoryId
        {
            get
            {
                return m_CategoryId;
            }
        }

        public SmartDate StartTime
        {
            get
            {
                return m_StartTime;
            }
        }

        public SmartDate EndTime
        {
            get
            {
                return m_EndTime;
            }
        }

        public string DisplayName
        {
            get
            {
               return m_DisplayName;
            }
        }

        public string Category
        {
            get
            {
                return m_Category;
            }
        }

        public TagType TagType
        {
            get
            {
                return m_TagType;
            }
        }

        public TimeSpan ElapsedTime
        {
            get
            {
                return m_EndTime.Date.Subtract(m_StartTime.Date);
            }
        }

        public double StopRatio
        {
            get
            {
                return m_StopRatio;
            }
        }

        protected override object GetIdValue()
        {
            return m_StoppageId;
        }
        #endregion

        #region Factory Methods

        internal static StoppageListItem GetStoppageListItem(EventListItem eventItem, ExpandedProductionSchemeItem schemeItem)
        {
            return new StoppageListItem(eventItem, schemeItem);
        }

        private StoppageListItem()
        {
            /* require use of factory methods */
        }

        private StoppageListItem(EventListItem eventItem, ExpandedProductionSchemeItem schemeItem)
        {
            Fetch(eventItem, schemeItem);
        }

        #endregion

        #region Data Access

        private void Fetch(EventListItem eventItem, ExpandedProductionSchemeItem schemeItem)
        {
            m_StoppageId = eventItem.EventId;
            m_MachineId = eventItem.MachineId;
            m_CategoryId = eventItem.CategoryId;
            m_Category = eventItem.Category;
            m_Shift = schemeItem.Shift;
            m_ArticleNumber = eventItem.ArticleNumber;
            m_StartTime = eventItem.EventRaised > schemeItem.StartTime ? eventItem.EventRaised : schemeItem.StartTime;
            m_EndTime = GetEndTime(eventItem, schemeItem);
            m_TagType = eventItem.TagType;
            m_DisplayName = eventItem.DisplayName;
            m_StopRatio = ElapsedTime.TotalSeconds > 0 ? ElapsedTime.TotalSeconds / eventItem.ElapsedTime.TotalSeconds : 0;
        }

        private SmartDate GetEndTime(EventListItem eventItem, ExpandedProductionSchemeItem schemeItem)
        {
            SmartDate endTime = eventItem.TimeForNextEvent;

            if (endTime.IsEmpty || endTime > schemeItem.EndTime)
                endTime = schemeItem.EndTime;

            return endTime;
        }

        public string GetPreviousArticle()
        {
            string result = "";
            using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT TOP 1 ArticleNumber From States" +
                                          @" WHERE MachineId=@MachineId AND TimeStampOnSet<@TimeStampOnSet AND StateType=@StateType AND Overridden=0" +
                                          @" ORDER BY TimeStampOnSet desc";
                    command.Parameters.AddWithValue("@MachineId", m_MachineId);
                    command.Parameters.AddWithValue("@TimeStampOnSet", m_StartTime.DBValue);
                    command.Parameters.AddWithValue("@StateType", (int)StateType.Auto);
                    
                    result = (string)command.ExecuteScalar();
                    if (result == null)
                    {
                        result = "";
                    }
                }
            }
            return result;
        }

        #endregion
    }
}