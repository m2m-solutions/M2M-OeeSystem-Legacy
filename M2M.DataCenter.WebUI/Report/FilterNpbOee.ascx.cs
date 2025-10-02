using System;
using System.Collections.Generic;
using System.Collections;

namespace M2M.DataCenter.WebUI.Report
{
    public partial class FilterNpbOee : ReportFilterBase
	{
        #region Members

        public DateTime RangeStart
        {
            get
            {
                return dtFrom.SelectedDate.Value;
            }
        }

        public DateTime RangeEnd
        {
            get
            {
                return dtTo.SelectedDate.Value;
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

            dtTo.SelectedDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtFrom.SelectedDate = dtTo.SelectedDate.Value.AddMonths(-1);
        }

        public override Dictionary<string, object> GetParameters()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("DivisionId", this.DivisionId);
            parameters.Add("RangeStart", this.RangeStart);
            parameters.Add("RangeEnd", this.RangeEnd);

            return parameters;
        }

		#endregion



	}
}