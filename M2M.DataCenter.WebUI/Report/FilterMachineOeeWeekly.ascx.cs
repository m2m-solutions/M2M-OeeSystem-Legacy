using System;
using Telerik.Web.UI;
using System.Collections.Generic;
using M2M.DataCenter.Utilities;
using System.Collections;

namespace M2M.DataCenter.WebUI.Report
{
    public partial class FilterMachineOeeWeekly : ReportFilterBase
	{
		#region Members

        public int Year
		{
			get 
			{
				return Convert.ToInt32(Years.SelectedValue); 
			}
		}

        public int Week
        {
            get
            {
                return Convert.ToInt32(Weeks.SelectedValue);
            }
        }

		public int Shift
		{
			get
			{
				return Convert.ToInt32(ProductionShifts.SelectedValue);
			}
		}

		public string DivisionId
		{
			get
			{
				return Divisions.SelectedValue;
			}
		}

        public string MachineId
        {
            get
            {
                return Machines.SelectedValue;
            }
        }

        #endregion

		#region Event Handlers

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				
			}
		}

		protected void btnRefresh_Click(object sender, EventArgs e)
		{
            EventArgs ea = new EventArgs();
            OnRefreshClick(ea);
		}

        protected void Divisions_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Machines.Text = "";
            Machines.Items.Clear();

            LoadMachines(e.Value);
        }

        #endregion

		#region Methods

        public override void BindData()
        {
            Divisions.DataTextField = "DisplayName";
            Divisions.DataValueField = "DivisionId";
            Divisions.DataSource = M2MDataCenter.GetDivisionsAccessibleForUser();
            Divisions.DataBind();
            
            if (!Page.IsPostBack)
            {
                Divisions.SelectedIndex = 0;
                LoadMachines(Divisions.SelectedValue);
            }

            ProductionShifts.DataTextField = "Value";
            ProductionShifts.DataValueField = "Key";
            ProductionShifts.DataSource = M2MDataCenter.GetShiftSelectList(true);
            ProductionShifts.DataBind();

            ArrayList years = new ArrayList();
            for (int i = DateTime.Today.Year; i >= 2005; i--)
            {
                years.Add(i.ToString());
            }

            Years.DataSource = years;
            Years.DataBind();
            Years.SelectedValue = DateTime.Today.AddDays(-7).Year.ToString();

            ArrayList weeks = new ArrayList();

            for (int i = 1; i <= 53; i++)
            {
                weeks.Add(i.ToString());
            }

            Weeks.DataSource = weeks;
            Weeks.DataBind();
            Weeks.SelectedValue = DateTime.Today.AddDays(-7).GetWeek().ToString();
        }

        protected void LoadMachines(string divisionId)
        {
            Machines.DataTextField = "DisplayName";
            Machines.DataValueField = "MachineId";
            Machines.DataSource = M2MDataCenter.GetMachineList(divisionId);
            Machines.DataBind();

        }

        public override Dictionary<string, object> GetParameters()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("DivisionId", this.DivisionId);
            parameters.Add("MachineId", this.MachineId);
            parameters.Add("ShiftType", this.Shift);
            parameters.Add("Year", this.Year);
            parameters.Add("Week", this.Week);
   
            return parameters;
        }

		#endregion

        

        
	}
}