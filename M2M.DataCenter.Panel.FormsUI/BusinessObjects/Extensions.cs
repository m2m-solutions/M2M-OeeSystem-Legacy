using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.WinControls.UI;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.Panel.FormsUI.BusinessObjects
{
    public static class Extensions
    {
        public static RadButton SetButtonData(this RadButton button, List<ButtonData> buttonData, int row, int col)
        {
            if (buttonData.Exists(ButtonData.ByPosition(row, col)))
            {
                button.Tag = buttonData.Find(ButtonData.ByPosition(row, col));
                button.Text = (button.Tag as ButtonData).DisplayName;
            }
            else
            {
                button.Tag = new Coordinates(row, col);
                button.Text = ResourceStrings.GetString("Panel.DoNotUse");
            }
            return button;
        }
    }

}
