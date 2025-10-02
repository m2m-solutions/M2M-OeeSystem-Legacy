using System;

namespace M2M.DataCenter.WebUI.Admin
{
	public partial class MachineControl : System.Web.UI.UserControl
	{
		#region Members

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
     		}

			ucMachineEditControl.SaveClick += new EventHandler(ucMachineEditControl_SaveClick);
		}

		void ucMachineEditControl_SaveClick(object sender, EventArgs e)
		{
			CurrentMachine.MachineId = ucMachineEditControl.MachineId;
			CurrentMachine.DisplayName = ucMachineEditControl.DisplayName;
			CurrentMachine.Notes = ucMachineEditControl.Notes;
			CurrentMachine.IdealRunRate = ucMachineEditControl.IdealRunRate;
			CurrentMachine.RunRateUnit = ucMachineEditControl.RunRateUnit;
            CurrentMachine.MomentUnit = ucMachineEditControl.MomentUnit;

			CurrentMachine.Save();

			CurrentMachine = Machine.GetMachine(rcbMachine.SelectedValue);
            M2MDataCenter.ReloadConfiguration();

			BindData();
		}

		protected void rcbMachine_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
		{
			CurrentMachine = Machine.GetMachine(rcbMachine.SelectedValue);

			BindData();
		}

		#endregion

		#region Methods

		public void BindData()
		{
			BindInfo();
			BindEdit();

            BindArticleList();
      }

		private void BindInfo()
		{
			rcbMachine.ClearSelection();
			rcbMachine.DataTextField = "DisplayName";
			rcbMachine.DataValueField = "MachineId";
            
			rcbMachine.DataSource = M2MDataCenter.GetMachineList(CurrentMachine.DivisionId);
			rcbMachine.DataBind();
			rcbMachine.SelectedValue = CurrentMachine.MachineId;
		}

		private void BindEdit()
		{
			ucMachineEditControl.MachineId = CurrentMachine.MachineId;
			ucMachineEditControl.DisplayName = CurrentMachine.DisplayName;
			ucMachineEditControl.Notes = CurrentMachine.Notes;
			ucMachineEditControl.IdealRunRate = CurrentMachine.IdealRunRate;
			ucMachineEditControl.LastModified = String.Format(" ({0})", CurrentMachine.LastModified("IdealRunRate"));
			ucMachineEditControl.RunRateUnit = CurrentMachine.RunRateUnit;
            ucMachineEditControl.MomentUnit = CurrentMachine.MomentUnit;
		}

		private void BindArticleList()
		{
			ucArticleListControl.BindData();
		}
		
		#endregion
	}
}