using System;
using System.Collections.Generic;
using System.Linq;

namespace M2M.DataCenter.Panel.FormsUI.BusinessObjects
{
    public class PanelObjects
    {
        public string Machine { get; set; }
        public string Division { get; set; }
        public List<ButtonData> Buttons { get; set; }

        public PanelObjects()
        {
            this.Buttons = new List<ButtonData>();
        }
    }
}
