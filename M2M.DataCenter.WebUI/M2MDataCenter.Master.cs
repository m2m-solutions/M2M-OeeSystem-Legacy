using System;
using Csla;
using Telerik.Web.UI;
using M2M.DataCenter.Localization;
using System.Collections.Generic;

namespace M2M.DataCenter.WebUI
{
	public partial class M2MDataCenterMaster : System.Web.UI.MasterPage
	{
		#region Members
		protected int SessionTimeout
		{
			get { return Session.Timeout; }
		}
		#endregion

		
		#region Event Handlers
		protected void Page_Init(object sender, EventArgs e)
		{
			
			if (!Page.IsPostBack)
			{
				SetGenericFilter();
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!Page.IsPostBack)
			{
				#region Production
				RadMenuItem menuItemProduction = new RadMenuItem(ResourceStrings.GetString("Production"));
                
                
                RadMenuItem menuItemFacility = new RadMenuItem(ResourceStrings.GetString("AllDivisions"), "~/Production/FacilityPage.aspx");
                menuItemFacility.Value = menuItemFacility.NavigateUrl;
                menuItemFacility.Selected = true;
                menuItemProduction.Items.Add(menuItemFacility);

                RadMenuItem menuItemSeparator = new RadMenuItem();
                menuItemSeparator.IsSeparator = true;
                menuItemProduction.Items.Add(menuItemSeparator);

                foreach (PlainDivisionListItem division in M2MDataCenter.GetDivisionsAccessibleForUser())
                {
                    RadMenuItem menuItemDivision = new RadMenuItem(division.DisplayName, "~/Production/DivisionPage.aspx?DivisionId=" + division.DivisionId);
                    menuItemDivision.Value = menuItemDivision.NavigateUrl;

                    foreach (PlainMachineListItem machine in M2MDataCenter.GetMachineList(division.DivisionId))
                    {
                        RadMenuItem menuItemMachine = new RadMenuItem(machine.DisplayName, "~/Production/MachinePage.aspx?DivisionId=" + division.DivisionId + "&MachineId=" + machine.MachineId);
                        menuItemMachine.Value = menuItemMachine.NavigateUrl;
                        menuItemDivision.Items.Add(menuItemMachine);
                    }

                    menuItemProduction.Items.Add(menuItemDivision);
                }

                radMainMenu.Items.Add(menuItemProduction);
               
          
          		#endregion

				#region Report
                
                RadMenuItem menuItemReport = new RadMenuItem(ResourceStrings.GetString("Reports"), "~/Report/ReportPage.aspx");
                menuItemReport.Value = menuItemReport.NavigateUrl;

                radMainMenu.Items.Add(menuItemReport);
               
                #endregion

				#region Admin
				if (M2MDataCenter.User.IsInRole("Admin"))
				{
					RadMenuItem menuItemAdministration = new RadMenuItem(ResourceStrings.GetString("Administration"), "~/AdministrationPage.aspx");
                    menuItemAdministration.Value = menuItemAdministration.NavigateUrl;

                    radMainMenu.Items.Add(menuItemAdministration);
				}
				#endregion

                #region Help
                RadMenuItem menuItemHelp = new RadMenuItem(ResourceStrings.GetString("Help"));
                
                RadMenuItem menuItemOee = new RadMenuItem(ResourceStrings.GetString("Help.Oee"), "~/Help/HelpPage.aspx?Context=Oee");
                menuItemOee.Value = menuItemOee.NavigateUrl;
                menuItemHelp.Items.Add(menuItemOee);

                RadMenuItem menuItemAbout = new RadMenuItem(ResourceStrings.GetString("Help.About"), "~/Help/AboutPage.aspx");
                menuItemAbout.Value = menuItemAbout.NavigateUrl;
                menuItemHelp.Items.Add(menuItemAbout);

                radMainMenu.Items.Add(menuItemHelp);
                #endregion

                //RadMenuItem menuItemScheduler = new RadMenuItem(ResourceStrings.GetString("Scheduler"), "~/Admin/SchedulerPage.aspx");
                //menuItemScheduler.Value = menuItemScheduler.NavigateUrl;

                //radMainMenu.Items.Add(menuItemScheduler);
         
				lbUser.Text = M2MDataCenter.User.Name;
			}

            string relativePath = Request.AppRelativeCurrentExecutionFilePath;
            if (Request.QueryString.Count > 0)
                relativePath += "?" + Request.QueryString.ToString();
            RadMenuItem item = radMainMenu.FindItemByValue(relativePath, true);

            if (item != null)
            {
                item.HighlightPath();
            }
		}

		protected void btnLogOut_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Logon.aspx");
		}

		#endregion

		#region Methods

		private void SetGenericFilter()
		{
			if (Session["CurrentCriteria"] == null)
			{
				GenericFilter filter = new GenericFilter();
				if (!M2MDataCenter.User.CanAccessAllDivisions())
				{
					filter.DivisionId = M2MDataCenter.User.Divisions[0].DivisionId;
				}

				if (!String.IsNullOrEmpty(filter.DivisionId))
				{
					MachineList machines = MachineList.GetMachineList(filter.DivisionId, false);

					if (machines.Count > 0)
					{
						filter.MachineId = MachineList.GetMachineList(filter.DivisionId, false)[0].MachineId;
					}

				}
				
				filter.ArticleNumber = "";
                filter.StartDate = new SmartDate(DateTime.Today.AddDays(-M2MDataCenter.SystemSettings.StartDateOffset));
                filter.EndDate = new SmartDate();
				filter.Shift = -1;
				filter.ShowInformation = false;
                filter.ShowSecondaryFailures = false;
                filter.ShowSystemErrors = false;
				filter.Categories.Clear();
                foreach (int category in M2MDataCenter.GetAvailableCategories())
                    if(M2MDataCenter.GetCategoryDisplayName(category) != "Systemfel")
                        filter.Categories.Add(category);
				
				Session["CurrentCriteria"] = filter;
			}

            if (M2MDataCenter.User.IsInRole("Admin"))
			{
                List<PlainDivisionListItem> divisions = M2MDataCenter.GetDivisionsAccessibleForUser();

				if (Session["CurrentDivision"] == null)
				{
					if (divisions.Count > 0)
					{
						Session["CurrentDivision"] = Division.GetDivision(divisions[0].DivisionId);
					}
				}

				if (Session["CurrentMachine"] == null)
				{
					if (divisions.Count > 0)
					{
						MachineList machines = MachineList.GetMachineList(divisions[0].DivisionId, false);

						if (machines.Count > 0)
						{
							Session["CurrentMachine"] = Machine.GetMachine(machines[0].MachineId);
                            Session["CurrentMachineId"] = machines[0].MachineId;
                      	}
					}
				}
			}
		}

		#endregion

		protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
		{
            
		}
	}
}
