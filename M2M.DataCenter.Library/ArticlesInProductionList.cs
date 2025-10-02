using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class ArticlesInProductionList : ReadOnlyListBase<ArticlesInProductionList, ArticlesInProductionListItem>
	{
		#region Business Methods

		
		#endregion


		#region Authorization Rules

		public static bool CanGetObject()
		{
			return true;
		}

		#endregion

		#region Factory Methods

		public static ArticlesInProductionList GetArticlesInProductionList()
		{
			return DataPortal.Fetch<ArticlesInProductionList>(new Criteria());
		}

		public static ArticlesInProductionList GetArticlesInProductionList(Criteria criteria)
		{
			return DataPortal.Fetch<ArticlesInProductionList>(criteria);
		}

		private ArticlesInProductionList()
		{
			/* require use of factory methods */
		}

		#endregion

		#region Data Access

		[Serializable()]
		public class Criteria
		{
			private string m_DivisionId = null;
			private string m_MachineId = null;
			private SmartDate m_StartDate = new SmartDate();
			private SmartDate m_EndDate = new SmartDate();
			private int m_Shift = -1;
			private string m_ArticlesFilter = "";
			
			public Criteria()
			{
			}

			public string DivisionId
			{
				get { return m_DivisionId; }
				set { m_DivisionId = value; }
			}

			public string MachineId
			{
				get { return m_MachineId; }
				set { m_MachineId = value; }
			}

			public SmartDate StartDate
			{
				get { return m_StartDate; }
				set { m_StartDate = value; }
			}

			public SmartDate EndDate
			{
				get { return m_EndDate; }
				set { m_EndDate = value; }
			}

			public int Shift
			{
				get { return m_Shift; }
				set { m_Shift = value; }
			}

			public string ArticlesFilter
			{
				get { return m_ArticlesFilter; }
				set { m_ArticlesFilter = value; }
			}
		}

		private void DataPortal_Fetch(Criteria criteria)
		{
			RaiseListChangedEvents = false;
			IsReadOnly = false;

			using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
			{
				connection.Open();

				using (SqlCommand command = connection.CreateCommand())
				{
                    string whereClause = "";

                    if (!String.IsNullOrEmpty(criteria.MachineId))
                    {
                        if (whereClause != "")
                            whereClause += " AND ";

                        whereClause += "MachineId=@MachineId";
                        command.Parameters.AddWithValue("@MachineId", criteria.MachineId);
                    }

                    if (!String.IsNullOrEmpty(criteria.DivisionId))
                    {
                        if (whereClause != "")
                            whereClause += " AND ";

                        whereClause += "DivisionId=@DivisionId";
                        command.Parameters.AddWithValue("@DivisionId", criteria.DivisionId);
                    }

                    if (!String.IsNullOrEmpty(criteria.ArticlesFilter))
                    {
                        if (whereClause != "")
                            whereClause += " AND ";

                        whereClause += "ArticleNumber LIKE @ArticlesFilter";
                        command.Parameters.AddWithValue("@ArticlesFilter", criteria.ArticlesFilter + "%");
                    }


                    if (criteria.Shift >= 0)
                    {
                        if (whereClause != "")
                            whereClause += " AND ";

                        whereClause += "Shift=@Shift";
                        command.Parameters.AddWithValue("@Shift", criteria.Shift);
                    }

                    if (!criteria.StartDate.IsEmpty)
                    {
                        if (whereClause != "")
                            whereClause += " AND ";

                        whereClause += "(EndTime IS NULL OR EndTime>@StartDate)";
                        command.Parameters.AddWithValue("@StartDate", criteria.StartDate.DBValue);
                    }

                    if (!criteria.EndDate.IsEmpty)
                    {
                        if (whereClause != "")
                            whereClause += " AND ";

                        whereClause += "StartTime<@EndDate";
                        command.Parameters.AddWithValue("@EndDate", criteria.EndDate.DBValue);
                    }

                    if (whereClause != "")
                        whereClause = " WHERE " + whereClause;

					command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT DISTINCT ArticleNumber " +
	                                      @" FROM OeeData" + whereClause +
	                                      @" ORDER BY ArticleNumber ASC";

										
					using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
					{
						while (dr.Read())
						{
							Add(ArticlesInProductionListItem.GetArticlesInProductionListItem(dr));
						}
					}
				}
			}

			IsReadOnly = true;
			RaiseListChangedEvents = true;
		}

		#endregion
	}
}

