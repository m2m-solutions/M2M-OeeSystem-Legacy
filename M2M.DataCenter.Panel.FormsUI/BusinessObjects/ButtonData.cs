using System;
using System.Linq;

namespace M2M.DataCenter.Panel.FormsUI.BusinessObjects
{
    public class ButtonData
    {
        public string TagId { get; set; }
        public string DisplayName { get; set; }
        public int ReasonId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        

        public ButtonData()
        {
        }

        public ButtonData(string tagId, int reasonCode, string displayName, int column, int row)
        {
            this.TagId = tagId;
            this.ReasonId = reasonCode;
            this.DisplayName = displayName;
            this.Row = row;
            this.Column = column;
        }

        public static Predicate<ButtonData> ByReasonId(int reasonId)
        {
            return delegate(ButtonData item) { return item.ReasonId == reasonId; };
        }

        public static Predicate<ButtonData> ByPosition(int row, int col)
        {
            return delegate(ButtonData item) { return item.Row == row && item.Column == col; };
        }
    }
}
