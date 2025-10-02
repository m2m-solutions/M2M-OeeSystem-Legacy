using System;
using System.Linq;
using System.Web.UI;
using Csla;
using M2M.DataCenter.Localization;
using Telerik.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Telerik.Charting;

namespace M2M.DataCenter.WebUI.Production
{
    public partial class DeviceUnitPage : System.Web.UI.Page
    {
        #region Members

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

        public bool ShowSystemErrors
        {
            get { return checkSystemErrors.Checked; }
            set { checkSystemErrors.Checked = value; }
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            Control labelAvailability = ucOEEControl.FindControl("lbAvailability");
            Control labelAvailabilityLoss = ucOEEControl.FindControl("lbAvailabilityLoss");
            Control labelPerformance = ucOEEControl.FindControl("lbPerformance");
            Control labelQuality = ucOEEControl.FindControl("lbQuality");
            Control labelOee = ucOEEControl.FindControl("lbOEE");
            Control labelPace = ucOEEControl.FindControl("lbPace");
            Control labelPaceUnit = ucOEEControl.FindControl("lbPaceUnit");
            Control gridDivisions = ucDivisionListControl.FindControl("gridDivisions");

            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(btnRefresh, labelAvailability);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(btnRefresh, labelAvailabilityLoss);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(btnRefresh, labelPerformance);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(btnRefresh, labelQuality);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(btnRefresh, labelOee);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(btnRefresh, labelPace);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(btnRefresh, labelPaceUnit);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(btnRefresh, chartOee);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(btnRefresh, gridDivisions);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(btnRefresh, chartStops);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(btnRefresh, chartStopTimes);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(btnRefresh, gridStops);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(btnRefresh, gridStopTimes);

            if (!Page.IsPostBack)
            {
                Page.Title = ResourceStrings.GetString("Page.Title.Facility");
                LoadShifts();
                BindData();
            }
        }

        protected void gridStops_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if ((e.Item.ItemType == GridItemType.Item) || (e.Item.ItemType == GridItemType.AlternatingItem))
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                AggregatedStoppageDataListItem stoppageItem = dataItem.DataItem as AggregatedStoppageDataListItem;

                Image imageMarker = (Image)dataItem["Marker"].FindControl("imageMarker");
                imageMarker.Height = Unit.Pixel(12);
                imageMarker.ImageUrl = string.Format("~/images/{0}.png", stoppageItem.Index + 1);

                dataItem["NumberOfStops"].Text = String.Format("{0:n0} {1}", stoppageItem.NumberOfStops, ResourceStrings.GetString("#-Stops"));

                if (stoppageItem.ElapsedTimeInSeconds < 1)
                {
                    dataItem["ElapsedTime"].Text = "< 1 " + ResourceStrings.GetString("#-Seconds.Abbr");
                }
                else if (stoppageItem.ElapsedTimeInHours <= 1)
                {
                    dataItem["ElapsedTime"].Text = String.Format("{0:n1} {1}", stoppageItem.ElapsedTimeInMinutes, ResourceStrings.GetString("#-Minutes.Abbr"));
                }
                else
                {
                    dataItem["ElapsedTime"].Text = String.Format("{0:n1} {1}", stoppageItem.ElapsedTimeInHours, ResourceStrings.GetString("#-Hours.Abbr"));
                }
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Criteria.StartDate = StartDate;
            Criteria.EndDate = EndDate;
            Criteria.ArticleNumber = ArticleNumber;
            Criteria.Shift = Shift;
            Criteria.ShowSystemErrors = ShowSystemErrors;

            BindData();
        }


        #endregion

        #region Methods

        public void BindData()
        {
            DivisionList divisions = DivisionList.GetDivisionList(Criteria.GetDivisionListCriteria());
            BindFilter();
            BindInfo();
            BindOee(divisions);
            BindGraph();
            BindStopGraphs();
            BindList(divisions);
        }

        private void BindStopGraphs()
        {
            StoppageDataList.Criteria criteria = Criteria.GetStoppageDataListCriteria();
            criteria.DivisionId = null;
            criteria.MachineId = null;
            StoppageDataList stoppages = StoppageDataList.GetStoppageDataList(criteria);
            List<AggregatedStoppageDataListItem> aggregatedStoppages = stoppages.GetTopTimes(M2MDataCenter.SystemSettings.StoppageGraphGroupCount, true);

            chartStopTimes.Series[0].Items.Clear();
            ChartSeriesItemsCollection stopTimeItems = new ChartSeriesItemsCollection();

            chartStopTimes.ChartTitle.TextBlock.Text = ResourceStrings.GetString("Chart.StopTimes.Title");
            int itemCount = aggregatedStoppages.Count;

            if (itemCount > 0)
            {
                for (int i = 0; i < itemCount; i++)
                {
                    ChartSeriesItem item = new ChartSeriesItem(aggregatedStoppages[i].ElapsedTime.TotalSeconds);
                    item.Name = aggregatedStoppages[i].Reason;
                    item.Label.Visible = false;
                    item.ActiveRegion.Tooltip = String.Format(ResourceStrings.GetString("Chart.StopTimes.Item"), aggregatedStoppages[i].Reason, aggregatedStoppages[i].NumberOfStops, FormatStateTime(aggregatedStoppages[i].ElapsedTime));
                    stopTimeItems.Add(item);


                }
            }

            chartStopTimes.Series[0].Items.AddRange(stopTimeItems);

            gridStopTimes.DataSource = aggregatedStoppages;
            gridStopTimes.Rebind();

            aggregatedStoppages = stoppages.GetTopCount(M2MDataCenter.SystemSettings.StoppageGraphGroupCount, true);

            chartStops.Series[0].Items.Clear();
            ChartSeriesItemsCollection stopItems = new ChartSeriesItemsCollection();

            chartStops.ChartTitle.TextBlock.Text = ResourceStrings.GetString("Chart.Stops.Title");
            itemCount = aggregatedStoppages.Count;

            if (itemCount > 0)
            {
                for (int i = 0; i < itemCount; i++)
                {
                    ChartSeriesItem item = new ChartSeriesItem(aggregatedStoppages[i].NumberOfStops);
                    item.Name = aggregatedStoppages[i].Reason;
                    item.Label.Visible = false;
                    item.ActiveRegion.Tooltip = String.Format(ResourceStrings.GetString("Chart.Stops.Item"), aggregatedStoppages[i].Reason, aggregatedStoppages[i].NumberOfStops, FormatStateTime(aggregatedStoppages[i].ElapsedTime));
                    stopItems.Add(item);
                }
            }

            chartStops.Series[0].Items.AddRange(stopItems);

            gridStops.DataSource = aggregatedStoppages;
            gridStops.Rebind();
        }

        private void BindFilter()
        {
            StartDate = Criteria.StartDate;
            EndDate = Criteria.EndDate;
            Shift = Criteria.Shift;
            ArticleNumber = Criteria.ArticleNumber;
            ShowSystemErrors = Criteria.ShowSystemErrors;
        }

        private void BindInfo()
        {
            lbInfo.Text = ResourceStrings.GetString("AllDivisions");
        }

        private void BindGraph()
        {
            OEEForFacility oeeForFacility = OEEForFacility.GetOEEForFacility(Criteria.GetOEEForMachineCriteria());
            chartOee.PlotArea.XAxis.LabelStep = oeeForFacility.Count / 10 + 1;
            chartOee.DataSource = oeeForFacility;
            chartOee.DataBind();
        }

        private void BindOee(DivisionList divisions)
        {
            ucOEEControl.Availability = divisions.AvailabilityAsString;
            ucOEEControl.AvailabilityLoss = divisions.AvailabilityLossBasedOnActualStopsAsString;
            ucOEEControl.Performance = divisions.PerformanceAsString;
            ucOEEControl.Quality = divisions.QualityAsString;
            ucOEEControl.OEE = divisions.OEEAsString;
            ucOEEControl.ShowPace = false;
        }

        private void BindList(DivisionList divisions)
        {
            ucDivisionListControl.BindData(divisions);
        }

        protected void LoadShifts()
        {
            ProductionShifts.DataTextField = "Value";
            ProductionShifts.DataValueField = "Key";
            ProductionShifts.DataSource = M2MDataCenter.GetShiftSelectList(true);
            ProductionShifts.DataBind();
        }

        private string FormatStateTime(TimeSpan stateTime)
        {
            string time = "";


            if (stateTime.TotalMinutes < 1)
            {
                time = "< 1 " + ResourceStrings.GetString("#-Minutes.Abbr");
            }
            else if (stateTime.TotalDays >= 1)
            {
                time = String.Format("{0:n1} {1}", stateTime.TotalHours, ResourceStrings.GetString("#-Hours.Abbr"));
            }
            else
            {
                time = String.Format("{0:n2} {1}", stateTime.TotalHours, ResourceStrings.GetString("#-Hours.Abbr"));
            }

            return time;
        }

        private string CalculateRatio(int stops, int cycles, int multiplier)
        {
            double ratio = 0;
            if (cycles > 0)
                ratio = (double)multiplier * (double)stops / (double)cycles;

            return String.Format("{0:n1}", ratio);
        }


        #endregion

    }
}