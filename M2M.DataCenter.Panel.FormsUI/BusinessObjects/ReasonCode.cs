using System;
using System.Linq;

namespace M2M.DataCenter.Panel.FormsUI.BusinessObjects
{
    public class Reason
    {
        public string TagId { get; set; }
        public int ReasonCode { get; set; }
        public string DisplayName { get; set; }
        public string DivisionId { get; set; }
        public string MachineId { get; set; }
        public int CategoryId { get; set; }
  
        public Reason()
        {
        }

        public Reason(string tagId, int reasonCode, string displayName, string divisionId, string machineId, int categoryId)
        {
            this.TagId = tagId;
            this.ReasonCode = reasonCode;
            this.DisplayName = displayName;
            this.DivisionId = divisionId;
            this.MachineId = machineId;
            this.CategoryId = categoryId;
        }

        public static Predicate<Reason> ByReasonCode(string tagId, int reasonCode)
        {
            return delegate(Reason item) { return item.TagId == tagId && item.ReasonCode  == reasonCode; };
        }
    }
}
