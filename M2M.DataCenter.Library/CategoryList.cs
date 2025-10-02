using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace M2M.DataCenter
{
    [Serializable()]
    public class CategoryList : ReadOnlyListBase<CategoryList, CategoryListItem>
    {
        #region Business Methods

        public CategoryListItem GetItem(int categoryId)
        {
            foreach (CategoryListItem item in this)
            {
                if ((item.CategoryId == categoryId))
                {
                    return item;
                }
            }

            return CategoryListItem.GetEmptyCategoryItem(categoryId);

        }
        
        #endregion

        #region Authorization Rules

        public static bool CanGetObject()
        {
            return true;
        }

        #endregion

        #region Factory Methods

        public static CategoryList GetCategoryList()
        {
            return DataPortal.Fetch<CategoryList>();
        }

        private CategoryList()
        {
            /* require use of factory methods */
        }

        #endregion

        #region Data Access

        private void DataPortal_Fetch()
        {
            RaiseListChangedEvents = false;
            IsReadOnly = false;

            using (SqlConnection connection = new SqlConnection(Database.SystemConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT CategoryId,DisplayName,FlowError,ChangeOver,NoProduction FROM EventCategories";

                    using (SafeDataReader dr = new SafeDataReader(command.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            Add(CategoryListItem.GetCategoryListItem(dr));
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

