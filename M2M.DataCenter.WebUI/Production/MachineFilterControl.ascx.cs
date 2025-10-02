using System;
using System.Web;
using System.Web.UI.WebControls;
using Csla;
using Telerik.Web.UI;
using System.Collections.Generic;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.WebUI.Production
{
	public partial class MachineFilterControl : System.Web.UI.UserControl
	{
		#region Members

        private List<int> m_Categories
        {
            get
            {
                object o = ViewState["m_Categories"];
                if (o == null)
                    return new List<int>();
                else
                    return (List<int>)o;
            }
            set
            {
                ViewState["m_Categories"] = value;
            }
        }

        public GenericFilter Criteria
		{
			get
			{
				return (GenericFilter)Session["CurrentCriteria"];
			}
		}

		public SmartDate StartDate
		{
			get 
			{
				if (dtStart.IsEmpty)
					return new SmartDate();

				return new SmartDate(dtStart.SelectedDate.Value); 
			}
			set 
			{
				if (value.IsEmpty)
					dtStart.SelectedDate = null;
				else
					dtStart.SelectedDate = value.Date; 
			}
		}

		public SmartDate EndDate
		{
			get
			{
				if (dtEnd.IsEmpty)
					return new SmartDate();

				return new SmartDate(dtEnd.SelectedDate.Value);
			}
			set
			{
				if (value.IsEmpty)
					dtEnd.SelectedDate = null;
				else
					dtEnd.SelectedDate = value.Date;
			}
		}

		public int Shift
		{
			get
			{
				return Convert.ToInt32(ProductionShifts.SelectedValue);
			}
			set
			{
				ProductionShifts.SelectedValue = value.ToString();
			}
		}

		public string ArticleNumber
		{
			get
			{
				return rcbArticles.Text;
			}
			set
			{
				rcbArticles.Text = value;
			}
		}

		public bool ShowInformation
		{
			get { return checkInfo.Checked; }
			set { checkInfo.Checked = value; }
		}

        public List<int> Categories
        {
            get
            {
                List<int> categories = new List<int>();

                int selectedCount = 0;
                foreach (RadComboBoxItem item in cbCategories.Items)
                {
                    CheckBox checkBox = item.FindControl("chk1") as CheckBox;
                    if (checkBox.Checked)
                    {
                        categories.Add(Convert.ToInt32(item.Value));
                        selectedCount++;
                    }
                }

                return categories;
            }
            set
            {
                m_Categories = value;
            }
        }

		public bool ExcludeNoProductionTime
		{
			get { return checkExcludeNoProduction.Checked; }
			set { checkExcludeNoProduction.Checked = value; }
		}

		#endregion

		#region Event Handlers

		public event EventHandler RefreshClick;

		protected void Page_Load(object sender, EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);

			if (!Page.IsPostBack)
			{
				
			}
		}

		protected void btnRefresh_Click(object sender, EventArgs e)
		{
            if (!checkInfo.Checked && cbCategories.Text == ResourceStrings.GetString("ShowNoAlerts"))
                return;

            if (RefreshClick != null)
				RefreshClick(this, e);
		}

        protected void cbCategories_PreRender(object sender, EventArgs e)
        {
            int selected = 0;

            foreach (RadComboBoxItem item in cbCategories.Items)
            {
                CheckBox checkBox = item.FindControl("chk1") as CheckBox;
                checkBox.Checked = m_Categories.Contains(Convert.ToInt32(item.Value));

                if (checkBox.Checked)
                {
                    selected++;
                    if (cbCategories.Text != "")
                        cbCategories.Text += ",";

                    cbCategories.Text += item.Text;
                }
            }

            if (selected == cbCategories.Items.Count)
                cbCategories.Text = ResourceStrings.GetString("ShowAllAlerts");
            else if (selected == 0)
                cbCategories.Text = ResourceStrings.GetString("ShowNoAlerts");
        }

		#endregion

		#region Methods

        public void BindData()
        {
            ProductionShifts.DataTextField = "Value";
            ProductionShifts.DataValueField = "Key";
            ProductionShifts.DataSource = M2MDataCenter.GetShiftSelectList(true);
            ProductionShifts.DataBind();

            cbCategories.DataBind();
        }

        protected string GetResourceString(string key)
        {
            return ResourceStrings.GetString(key);
        }

		#endregion



	}
}