using System;
using System.Linq;
using Telerik.WinControls.UI.Localization;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.Panel.FormsUI
{
    public class CustomRadGridLocalizationProvider : RadGridLocalizationProvider 
    {
         
        public override string  GetLocalizedString(string id)
        {
            switch (id)
            {
                case RadGridStringId.NoDataText: return "";
                case RadGridStringId.AddNewRowString: return ResourceStrings.GetString("Panel.AddObject");
                case RadGridStringId.DeleteRowMenuItem: return ResourceStrings.GetString("Delete");
            }
 	         return base.GetLocalizedString(id);
        }
    }
}
