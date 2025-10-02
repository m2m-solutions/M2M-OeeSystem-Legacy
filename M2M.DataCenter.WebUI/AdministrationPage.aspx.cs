using System;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.WebUI
{
	public partial class AdministrationPage : System.Web.UI.Page
	{
		#region Members

		protected enum FormState { System, Users, Facility, Division, Machine };

		protected FormState m_FormState
		{
			get
			{
				object o = ViewState["m_FormState"];
				if (o == null)
                    return FormState.System;
				else
					return (FormState)o;
			}
			set
			{
				ViewState["m_FormState"] = value;
			}
		}

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
            if(!M2MDataCenter.User.IsInRole("Admin"))
                Response.Redirect("~/Logon.aspx");
			
            if (!IsPostBack)
			{
                Page.Title = ResourceStrings.GetString("Page.Title.Administration");

                m_FormState = FormState.System;

				string divisionId = Request.QueryString["DivisionId"];
				string machineId = Request.QueryString["MachineId"];

				if (!String.IsNullOrEmpty(divisionId))
				{
					if (divisionId == "New")
					{
						CurrentDivision = Division.NewDivision();
					}
					else
					{
						CurrentDivision = Division.GetDivision(divisionId);
					}

					m_FormState = FormState.Division;
				}
				else if (!String.IsNullOrEmpty(machineId))
				{
					if (machineId == "New")
					{
						CurrentMachine = Machine.NewMachine();
						CurrentMachine.DivisionId = CurrentDivision.DivisionId;
					}
					else
					{
						CurrentMachine = Machine.GetMachine(machineId);
					}

					m_FormState = FormState.Machine;
				}

				BindData();
			}
		}

        protected void btnSystemSettings_Click(object sender, EventArgs e)
        {
            m_FormState = FormState.System;
            BindData();
        }

        protected void btnUserSettings_Click(object sender, EventArgs e)
        {
            m_FormState = FormState.Users;
            BindData();
        }

		protected void btnFacility_Click(object sender, EventArgs e)
		{
			m_FormState = FormState.Facility;
			BindData();
		}

		protected void btnDivision_Click(object sender, EventArgs e)
		{
			m_FormState = FormState.Division;
			BindData();
		}

		protected void btnMachine_Click(object sender, EventArgs e)
		{
			m_FormState = FormState.Machine;
			BindData();
		}

		#endregion

		#region Methods

		protected void HideAndShowControls()
		{
            subMenuItemUserSettings.Visible = M2MDataCenter.User.IsInRole("System");

            switch (m_FormState)
			{
                case FormState.System:
                    ucSystemSettingsControl.Visible = true;
                    ucUserSettingsControl.Visible = false;
                    ucFacilityControl.Visible = false;
                    ucDivisionControl.Visible = false;
                    ucMachineControl.Visible = false;
                    subMenuItemSystemSettings.Attributes["class"] = "subMenuItemSelected";
                    subMenuItemUserSettings.Attributes["class"] = "subMenuItem";
                    subMenuItemFacility.Attributes["class"] = "subMenuItem";
                    subMenuItemDivision.Attributes["class"] = "subMenuItem";
                    subMenuItemMachine.Attributes["class"] = "subMenuItem";
                    subMenuItemDivision.Visible = (CurrentDivision != null);
                    subMenuItemMachine.Visible = (CurrentMachine != null);
                    break;
                case FormState.Users:
                    ucSystemSettingsControl.Visible = false;
                    ucUserSettingsControl.Visible = true;
                    ucFacilityControl.Visible = false;
                    ucDivisionControl.Visible = false;
                    ucMachineControl.Visible = false;
                    subMenuItemSystemSettings.Attributes["class"] = "subMenuItem";
                    subMenuItemUserSettings.Attributes["class"] = "subMenuItemSelected";
                    subMenuItemFacility.Attributes["class"] = "subMenuItem";
                    subMenuItemDivision.Attributes["class"] = "subMenuItem";
                    subMenuItemMachine.Attributes["class"] = "subMenuItem";
                    subMenuItemDivision.Visible = (CurrentDivision != null);
                    subMenuItemMachine.Visible = (CurrentMachine != null);
                    break;
				case FormState.Facility:
                    ucSystemSettingsControl.Visible = false;
                    ucUserSettingsControl.Visible = false;
					ucFacilityControl.Visible = true;
					ucDivisionControl.Visible = false;
					ucMachineControl.Visible = false;
                    subMenuItemSystemSettings.Attributes["class"] = "subMenuItem";
                    subMenuItemUserSettings.Attributes["class"] = "subMenuItem";
					subMenuItemFacility.Attributes["class"] = "subMenuItemSelected";
					subMenuItemDivision.Attributes["class"] = "subMenuItem";
					subMenuItemMachine.Attributes["class"] = "subMenuItem";
					subMenuItemDivision.Visible = (CurrentDivision != null);
					subMenuItemMachine.Visible = (CurrentMachine != null);
					break;
				case FormState.Division:
                    ucSystemSettingsControl.Visible = false;
                    ucUserSettingsControl.Visible = false;
                    ucFacilityControl.Visible = false;
					ucDivisionControl.Visible = true;
					ucMachineControl.Visible = false;
                    subMenuItemSystemSettings.Attributes["class"] = "subMenuItem";
                    subMenuItemUserSettings.Attributes["class"] = "subMenuItem";
                    subMenuItemFacility.Attributes["class"] = "subMenuItem";
					subMenuItemDivision.Attributes["class"] = "subMenuItemSelected";
					subMenuItemMachine.Attributes["class"] = "subMenuItem";
					subMenuItemDivision.Visible = (CurrentDivision != null);
					subMenuItemMachine.Visible = (CurrentMachine != null);
					break;
				case FormState.Machine:
                    ucSystemSettingsControl.Visible = false;
                    ucUserSettingsControl.Visible = false;
                    ucFacilityControl.Visible = false;
					ucDivisionControl.Visible = false;
					ucMachineControl.Visible = true;
                    subMenuItemSystemSettings.Attributes["class"] = "subMenuItem";
                    subMenuItemUserSettings.Attributes["class"] = "subMenuItem";
                    subMenuItemFacility.Attributes["class"] = "subMenuItem";
					subMenuItemDivision.Attributes["class"] = "subMenuItem";
					subMenuItemMachine.Attributes["class"] = "subMenuItemSelected";
					subMenuItemDivision.Visible = (CurrentDivision != null);
					subMenuItemMachine.Visible = (CurrentMachine != null);
					break;
			}
		}

		protected void BindData()
		{
			HideAndShowControls();

			switch (m_FormState)
			{
                case FormState.System:
                    break;
                case FormState.Users:
                    break;
                case FormState.Facility:
                    ucFacilityControl.BindData();
					break;
				case FormState.Division:
					ucDivisionControl.BindData();
					break;
				case FormState.Machine:
					ucMachineControl.BindData();
					break;
			}
		}

		#endregion
	}
}
