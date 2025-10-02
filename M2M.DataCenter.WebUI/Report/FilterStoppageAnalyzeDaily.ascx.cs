using System;
using Telerik.Web.UI;
using System.Collections.Generic;
using M2M.DataCenter.Localization;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter.WebUI.Report
{
    public partial class FilterStoppageAnalyzeDaily : ReportFilterBase
	{
		#region Members

        public DateTime EndDate
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
                LoadStopReasons(Divisions.SelectedValue, Convert.ToInt32(Categories.SelectedValue));
            }
            
            dtDate.SelectedDate = DateTime.Today.AddDays(-1);
        }

        public override Dictionary<string, object> GetParameters()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("DivisionId", this.DivisionId);
            parameters.Add("ShiftType", this.Shift);
            parameters.Add("EndDate", this.EndDate);
            parameters.Add("Category", this.Category);
            parameters.Add("StopReason", this.StopReason);
            parameters.Add("ShowType", this.ShowType);

            return parameters;
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