using System;
using System.Drawing;
using System.Web.UI;
using System.Globalization;

namespace M2M.DataCenter.WebUI.Status
{
	public partial class StatusControl : System.Web.UI.UserControl
	{
        public GenericFilter Criteria
        {
            get
            {
                return (GenericFilter)Session["CurrentCriteria"];
            }
        }

		protected void Page_Load(object sender, EventArgs e)
		{
            
            
     	}

        #region Methods

        public void BindData()
        {
            MachineList machines = MachineList.GetMachineList(Criteria.GetMachineListCriteria());

            Panel1.BackImageUrl = string.Format("~/CustomerSpecifics/{0}", M2MDataCenter.GetDivision(Criteria.DivisionId).Settings.OverviewImageFile);

            Decimal upperLimit = machines.GetUpperLimit(M2MDataCenter.GetDivision(Criteria.DivisionId).Settings.UpperLimitCount);
            Decimal lowerLimit = machines.GetLowerLimit(M2MDataCenter.GetDivision(Criteria.DivisionId).Settings.LowerLimitCount);

            foreach (MachineListItem machine in machines)
            {
                if (machine.Settings.UIPos != Point.Empty)
                    Panel1.Controls.Add(CreateLabel(machine, GetColor(machine.AvailabilityLossBasedOnActualStops, upperLimit, lowerLimit)));
            }
        }

        public Color GetColor(Decimal actual, Decimal upperLimit, Decimal lowerLimit)
        {
            if (actual > upperLimit)
                return Color.FromArgb(255, 0, 0);
            
            if (actual > lowerLimit)
                return Color.FromArgb(255, 186, 0);

            return Color.FromArgb(0, 255, 0);
        }
        public Control CreateLabel(MachineListItem machine, Color color)
        {
            var label = new System.Web.UI.WebControls.Label();
            label.Width = new System.Web.UI.WebControls.Unit(40, System.Web.UI.WebControls.UnitType.Pixel);
            label.ForeColor = color;
            label.Text = machine.AvailabilityLossBasedOnActualStops<1.0m ? (machine.AvailabilityLossBasedOnActualStops*100.0m).ToString("N1", NumberFormatInfo.InvariantInfo) : "100";
            label.Style["top"] = String.Format("{0}px", machine.Settings.UIPos.Y);
            label.Style["left"] = String.Format("{0}px", machine.Settings.UIPos.X);
            label.Style["position"] = "absolute";
            label.Style["text-align"] = "center";
            return label;
        }

        #endregion
    }
}