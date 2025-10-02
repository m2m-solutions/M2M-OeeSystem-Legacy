using System;
using Telerik.Web.UI;
using System.Collections.Generic;
using M2M.DataCenter.Utilities;
using System.Collections;

namespace M2M.DataCenter.WebUI.Report
{
    public partial class FilterDivisionStoppageMonthly : ReportFilterBase
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

        public List<int> Categories
        {
            get
            {
                List<int> categories = new List<int>();

                foreach (RadComboBoxItem item in SelectCategories.CheckedItems)
                {
                    categories.Add(Convert.ToInt32(item.Value));
                }

                return categories;
            }
        }

        public int OrderBy
        {
            get
            {
                return OrderBys.SelectedIndex;
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

        protected void SelectCategories_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            e.Item.Checked = true;
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

            SelectCategories.DataTextField = "DisplayName";
            SelectCategories.DataValueField = "CategoryId";
            SelectCategories.DataSource = M2MDataCenter.GetCategoriesSelectList();
            SelectCategories.DataBind();
            
            OrderBys.DataTextField = "Value";
            OrderBys.DataValueField = "Key";
            OrderBys.DataSource = (typeof(StoppageOrderBy)).ToList();
            OrderBys.DataBind();
            OrderBys.SelectedIndex= 0;

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
            parameters.Add("Category", this.Categories);
            parameters.Add("OrderBy", this.OrderBy);

            return parameters;
        }

		#endregion

        
	}
}