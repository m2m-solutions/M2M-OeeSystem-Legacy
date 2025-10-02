using System;
using Csla;
using Csla.Data;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter
{
    [Serializable()]
    public class CategoryListItem : ReadOnlyBase<CategoryListItem>
    {
        #region Business Methods

        private int m_CategoryId = 0;
        private string m_DisplayName = String.Empty;
        private bool m_FlowError = false;
        private bool m_ChangeOver = false;
        private bool m_NoProduction = false;

        public int CategoryId
        {
            get
            {
                return m_CategoryId;
            }
        }

        public string DisplayName
        {
            get
            {
                return m_DisplayName;
            }
        }

        public bool FlowError
        {
            get
            {
                return m_FlowError;
            }
        }

        public bool ChangeOver
        {
            get
            {
                return m_ChangeOver;
            }
        }

        public bool NoProduction
        {
            get
            {
                return m_NoProduction;
            }
        }

        protected override object GetIdValue()
        {
            return m_CategoryId;
        }

        #endregion

        #region Factory Methods

        internal static CategoryListItem GetCategoryListItem(SafeDataReader dr)
        {
            return new CategoryListItem(dr);
        }

        internal static CategoryListItem GetEmptyCategoryItem(int categoryId)
        {
            return new CategoryListItem(categoryId);
        }

        private CategoryListItem()
        {
            /* require use of factory methods */
        }

        private CategoryListItem(SafeDataReader dr)
        {
            Fetch(dr);
        }

        private CategoryListItem(int categoryId)
        {
            m_CategoryId = categoryId;
            m_DisplayName = ResourceStrings.GetString("CategoryMissing");
        }

        #endregion

        #region Data Access

        private void Fetch(SafeDataReader dr)
        {
            m_CategoryId = dr.GetInt32("CategoryId");
            m_DisplayName = dr.GetString("DisplayName");
            m_FlowError = dr.GetBoolean("FlowError");
            m_ChangeOver = dr.GetBoolean("ChangeOver");
            m_NoProduction = dr.GetBoolean("NoProduction");
        }

        #endregion
    }
}