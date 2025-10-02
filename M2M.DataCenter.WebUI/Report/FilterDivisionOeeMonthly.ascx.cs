using System;
using System.Collections.Generic;
using System.Collections;

namespace M2M.DataCenter.WebUI.Report
{
    public partial class FilterDivisionOeeMonth : ReportFilterBase
	{
		#region Members

        public int Year
		{
			get 
			{
				return Convert.ToInt32(Years.SelectedValue); 
			}
		}

		public int Month
		{
			get
			{
                return Convert.ToInt32(Months.SelectedValue); 
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
            Years.SelectedValue = DateTime.Today.AddMonths(-1).Year.ToString();

            SortedList months = new SortedList();
            for (int i = 12; i >= 1; i--)
            {
                months.Add(i, String.Format("{0:dMM}", new DateTime(2009, i, 1).ToString("MMMM")));
            }

            Months.DataTextField = "Value";
            Months.DataValueField = "Key";
            Months.DataSource = months;
            Months.DataBind();
            Months.SelectedValue = DateTime.Today.AddMonths(-1).Month.ToString();
        }

        public override Dictionary<string, object> GetParameters()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("DivisionId", this.DivisionId);
            parameters.Add("ShiftType", this.Shift);
            parameters.Add("Year", this.Year);
            parameters.Add("Month", this.Month);

            return parameters;
        }

		#endregion



	}
}