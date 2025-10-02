using System;
using System.Linq;

namespace M2M.DataCenter.Panel.FormsUI.BusinessObjects
{
    public class TagInfo
    {
        public string TagId { get; set; }
        public string DisplayName { get; set; }
        public string DivisionId { get; set; }
        public string MachineId { get; set; }
        public int CategoryId { get; set; }

        public TagInfo(string tagId, string displayName, string divisionId, string machineId, int categoryId)
        {
            this.TagId = tagId;
            this.DisplayName = displayName;
            this.DivisionId = divisionId;
            this.MachineId = machineId;
            this.CategoryId = categoryId;
        }

        public static Predicate<TagInfo> ByTagId(string tagId)
        {
            return delegate(TagInfo item) { return item.TagId == tagId; };
        }
    }
}
