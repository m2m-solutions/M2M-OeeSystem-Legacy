using System;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
	[Serializable()]
	public class ArticlesInProductionListItem : ReadOnlyBase<ArticlesInProductionListItem>
	{
		#region Business Methods

		private string m_ArticleNumber = String.Empty;
		
		public string ArticleNumber
		{
			get
			{
				return m_ArticleNumber;
			}
		}

		
		protected override object GetIdValue()
		{
			return m_ArticleNumber;
		}

		#endregion

		#region Factory Methods

		internal static ArticlesInProductionListItem GetArticlesInProductionListItem(SafeDataReader dr)
		{
			return new ArticlesInProductionListItem(dr);
		}

		private ArticlesInProductionListItem()
		{
			/* require use of factory methods */
		}

		private ArticlesInProductionListItem(SafeDataReader dr)
		{
			Fetch(dr);
		}

		#endregion

		#region Data Access

		private void Fetch(SafeDataReader dr)
		{
			m_ArticleNumber = dr.GetString("ArticleNumber");
			
		}

		#endregion
	}
}