using System;
using System.Linq;

namespace M2M.DataCenter.Panel.FormsUI.BusinessObjects
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string DisplayName { get; set; }
        public bool ChangeOver { get; set; }
        public bool NoProduction { get; set; }
        
        public Category(int categoryId, string displayName, bool changeOver, bool noProduction)
        {
            this.CategoryId = categoryId;
            this.DisplayName = displayName;
            this.ChangeOver = changeOver;
            this.NoProduction = noProduction;
        }

        public static Predicate<Category> ByCategoryId(int categoryId)
        {
            return delegate(Category item) { return item.CategoryId == categoryId; };
        }
    }
}
