using System;
using Telerik.Web.UI;
using System.Collections.Generic;
using M2M.DataCenter.Localization;
using System.Collections;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter.WebUI.Report
{
    public partial class FilterArticleStoppageAnalyzeWeekly : ReportFilterBase
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

        public int Category
        {
            get
            {
                return Convert.ToInt32(Categories.SelectedValue);
            }
        }

        public string StopReason
        {
            get
            {
                return StopReasons.SelectedValue;
            }
        }

        public int ShowType
        {
            get
            {
                return ShowTypes.SelectedIndex;
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

        #endregion

        protected void Divisions_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Machines.Text = "";
            Machines.Items.Clear();

            LoadMachines(e.Value);

            StopReasons.Text = "";
            StopReasons.Items.Clear();

            LoadStopReasons(e.Value, Convert.ToInt32(Categories.SelectedValue));
        }

        protected void Categories_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            StopReasons.Text = "";
            StopReasons.Items.Clear();

            LoadStopReasons(Divisions.SelectedValue, Convert.ToInt32(e.Value));
        }

		#region Methods

        public override void BindData()
        {
            Divisions.DataTextField = "DisplayName";
            Divisions.DataValueField = "DivisionId";
            Divisions.DataSource = M2MDataCenter.GetDivisionsAccessibleForUser();
            Divisions.DataBind();

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

            Categories.DataTextField = "DisplayName";
            Categories.DataValueField = "CategoryId";
            Categories.DataSource = M2MDataCenter.GetCategoriesSelectList();
            Categories.DataBind();

            ShowTypes.DataTextField = "Value";
            ShowTypes.DataValueField = "Key";
            ShowTypes.DataSource = (typeof(AnalyzeShowType)).ToList();
            ShowTypes.DataBind();
            
            if (!Page.IsPostBack)
            {
                Divisions.SelectedIndex = 0;
                Categories.SelectedIndex = 0;
                ShowTypes.SelectedIndex = 0;
                LoadMachines(Divisions.SelectedValue);
                LoadStopReasons(Divisions.SelectedValue, Convert.ToInt32(Categories.SelectedValue));
            }
         
        }

        public override Dictionary<string, object> GetParameters()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("DivisionId", this.DivisionId);
            parameters.Add("MachineId", this.MachineId);
            parameters.Add("ShiftType", this.Shift);
            parameters.Add("Year", this.Year);
            parameters.Add("Week", this.Week);
            parameters.Add("Category", this.Category);
            parameters.Add("StopReason", this.StopReason);
            parameters.Add("ShowType", this.ShowType);

            return parameters;
        }

        protected void LoadMachines(string divisionId)
        {
            Machines.DataTextField = "DisplayName";
            Machines.DataValueField = "MachineId";
            Machines.DataSource = M2MDataCenter.GetMachineList(divisionId);
            Machines.DataBind();

        }

        protected void LoadStopReasons(string divisionId, int categoryId)
        {
            StopReasons.Items.Add(new RadComboBoxItem(ResourceStrings.GetString("ShowAll"), ""));
            StopReasons.AppendDataBoundItems = true;
            StopReasons.DataTextField = "DisplayName";
            StopReasons.DataValueField = "DisplayName";
            StopReasons.DataSource = M2MDataCenter.GetStoppageReasonList(divisionId, categoryId);
            StopReasons.DataBind();
        }

		#endregion
	}
}