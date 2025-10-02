using System;
using M2M.DataCenter.Localization;
using M2M.OeeCalculator.Library;
using M2M.StoppageCalculator.Library;

namespace M2M.DataCenter.WebUI.Admin
{
	public partial class DivisionControl : System.Web.UI.UserControl
	{
		#region Members

		public Division CurrentDivision
		{
			get
			{
				return (Division)Session["CurrentDivision"];
			}
			set
			{
				Session["CurrentDivision"] = value;
			}
		}

        public Machine CurrentMachine
        {
            get
            {
                return (Machine)Session["CurrentMachine"];
            }
            set
            {
                Session["CurrentMachine"] = value;
                Session["CurrentMachineId"] = value.MachineId;
            }
        }

		#endregion

		#region Event Handlers

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                lbOeeCalcInfo.Text = String.Format(ResourceStrings.GetString("OeeCalculateInfo"), M2MDataCenter.SystemSettings.CalculateInterval);
				dtStart.SelectedDate = DateTime.Today;
				dtEnd.SelectedDate = DateTime.Today;
			}

			ucDivisionEditControl.SaveClick += new EventHandler(ucDivisionEditControl_SaveClick);
		}

		void ucDivisionEditControl_SaveClick(object sender, EventArgs e)
		{
			CurrentDivision.DivisionId = ucDivisionEditControl.DivisionId;
			CurrentDivision.DisplayName = ucDivisionEditControl.DisplayName;
			CurrentDivision.Notes = ucDivisionEditControl.Notes;
			CurrentDivision.Save();
            M2MDataCenter.ReloadConfiguration();

			BindData();
		}

		protected void rcbDivision_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
		{
			CurrentDivision = Division.GetDivision(rcbDivision.SelectedValue);
            PlainMachineList machines = M2MDataCenter.GetMachineList(CurrentDivision.DivisionId);
            if(machines.Count > 0)
                CurrentMachine = Machine.GetMachine(machines[0].MachineId);

			BindData();
		}

		#endregion

		#region Methods

		public void BindData()
		{
			BindInfo();
			BindEdit();
			
			BindMachineList();
			BindProductionScheduler();
		}

		private void BindInfo()
		{
			rcbDivision.ClearSelection();
			rcbDivision.DataTextField = "DisplayName";
			rcbDivision.DataValueField = "DivisionId";
            rcbDivision.DataSource = M2MDataCenter.GetDivisionsAccessibleForUser();
			rcbDivision.DataBind();
			rcbDivision.SelectedValue = CurrentDivision.DivisionId;
		}

		private void BindEdit()
		{
			ucDivisionEditControl.DivisionId = CurrentDivision.DivisionId;
			ucDivisionEditControl.DisplayName = CurrentDivision.DisplayName;
			ucDivisionEditControl.Notes = CurrentDivision.Notes;
		}

		private void BindMachineList()
		{
			ucMachineListControl.BindData();
		}

		private void BindProductionScheduler()
		{
			ProductionSchemeControl1.BindData();
		}

		#endregion

		protected void btnCaluclate_Click(object sender, EventArgs e)
		{
			if (dtStart.SelectedDate.HasValue && dtEnd.SelectedDate.HasValue)
			{
                DateTime date = dtStart.SelectedDate.Value;
                while (date < dtEnd.SelectedDate.Value)
                {
                    DateTime next = date.AddDays(1);
                    OeeCalculateRequest oeeRequest = OeeCalculateRequest.NewOeeCalculateRequest();
                    oeeRequest.DivisionId = CurrentDivision.DivisionId;
                    oeeRequest.StartDate = new Csla.SmartDate(date);
                    oeeRequest.EndDate = new Csla.SmartDate(next);
                    oeeRequest.Save();

                    StoppageCalculateRequest stoppageRequest = StoppageCalculateRequest.NewStoppageCalculateRequest();
                    stoppageRequest.DivisionId = CurrentDivision.DivisionId;
                    stoppageRequest.StartDate = new Csla.SmartDate(date);
                    stoppageRequest.EndDate = new Csla.SmartDate(next);
                    stoppageRequest.Save();

                    date = next;
                }
			}
		}
	}
}