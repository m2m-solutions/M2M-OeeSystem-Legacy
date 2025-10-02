using System;
using System.Collections.Generic;
using M2M.DataCenter.Utilities;
using System.Collections;

namespace M2M.DataCenter.WebUI.Report
{
    public partial class FilterDivisionOeeWeekly : ReportFilterBase
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
        }

        public override Dictionary<string, object> GetParameters()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("DivisionId", this.DivisionId);
            parameters.Add("ShiftType", this.Shift);
            parameters.Add("Year", this.Year);
            parameters.Add("Week", this.Week);

            return parameters;
        }

		#endregion



	}
}