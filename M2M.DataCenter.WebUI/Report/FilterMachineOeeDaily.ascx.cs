using System;
using Telerik.Web.UI;
using System.Collections.Generic;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter.WebUI.Report
{
    public partial class FilterMachineOeeDaily : ReportFilterBase
	{
		#region Members

        public DateTime Date
		{
			get 
			{
				return dtDate.SelectedDate.Value; 
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

            SelectCategories.DataTextField = "DisplayName";
            SelectCategories.DataValueField = "CategoryId";
            SelectCategories.DataSource = M2MDataCenter.GetCategoriesSelectList();
            SelectCategories.DataBind();
            
            OrderBys.DataTextField = "Value";
            OrderBys.DataValueField = "Key";
            OrderBys.DataSource = (typeof(StoppageOrderBy)).ToList();
            OrderBys.DataBind();
            OrderBys.SelectedIndex= 0;
            
            dtDate.SelectedDate = DateTime.Today.AddDays(-1);
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
            parameters.Add("Date", this.Date);
            parameters.Add("Category", this.Categories);
            parameters.Add("OrderBy", this.OrderBy);

            return parameters;
        }

		#endregion

        

        
	}
}