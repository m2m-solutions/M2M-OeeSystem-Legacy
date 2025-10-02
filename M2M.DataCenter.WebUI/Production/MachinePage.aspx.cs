using System;
using System.Linq;
using System.Web.UI;
using Telerik.Charting;
using M2M.DataCenter.Localization;
using System.Collections.Generic;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

namespace M2M.DataCenter.WebUI.Production
{
    public partial class MachinePage : System.Web.UI.Page
    {
        #region Members

        public GenericFilter Criteria
        {
            get
            {
                return (GenericFilter)Session["CurrentCriteria"];
            }
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            Control refreshButton = ucFilterControl.FindControl("btnRefresh");

            Control labelStatus = ucStatusControl.FindControl("lbStatus");
            Control labelArticle = ucStatusControl.FindControl("lbArticle");
            Control labelAvailability = ucOEEControl.FindControl("lbAvailability");
            Control labelAvailabilityLoss = ucOEEControl.FindControl("lbAvailabilityLoss");
            Control labelPerformance = ucOEEControl.FindControl("lbPerformance");
            Control labelQuality = ucOEEControl.FindControl("lbQuality");
            Control labelOee = ucOEEControl.FindControl("lbOEE");
            Control labelPace = ucOEEControl.FindControl("lbPace");
            Control labelPaceUnit = ucOEEControl.FindControl("lbPaceUnit");
            
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(refreshButton, labelStatus);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(refreshButton, labelArticle);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(refreshButton, labelAvailability);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(refreshButton, labelAvailabilityLoss);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(refreshButton, labelPerformance);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(refreshButton, labelQuality);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(refreshButton, labelOee);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(refreshButton, labelPace);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(refreshButton, labelPaceUnit);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(refreshButton, chartOee);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(refreshButton, chartStates);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(refreshButton, chartStops);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(refreshButton, chartStopTimes);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(refreshButton, gridStops);
            RadAjaxManagerProxy1.AjaxSettings.AddAjaxSetting(refreshButton, gridStopTimes);
            
            if (!IsPostBack)
            {
                Criteria.DivisionId = Request.QueryString["DivisionId"];
                Criteria.MachineId = Request.QueryString["MachineId"];
                Page.Title = String.Format(ResourceStrings.GetString("Page.Title.Machine"), M2MDataCenter.GetDivision(Criteria.DivisionId).DisplayName, M2MDataCenter.GetMachine(Criteria.DivisionId, Criteria.MachineId).DisplayName);
                chartStates.CustomPalettes.Add(CustomPalette.StatePalette);
                chartStates.SeriesPalette = CustomPalette.StatePalette.Name;
                chartStopTimes.CustomPalettes.Add(CustomPalette.DownTimePalette);
                chartStopTimes.SeriesPalette = CustomPalette.DownTimePalette.Name;
                chartStops.CustomPalettes.Add(CustomPalette.DownTimePalette);
                chartStops.SeriesPalette = CustomPalette.DownTimePalette.Name;
                BindData();
            }


            ucFilterControl.RefreshClick += new EventHandler(ucFilterControl_RefreshClick);
        }


        private void ucFilterControl_RefreshClick(object sender, EventArgs e)
        {
            Criteria.StartDate = ucFilterControl.StartDate;
            Criteria.EndDate = ucFilterControl.EndDate;
            Criteria.ArticleNumber = ucFilterControl.ArticleNumber;
            Criteria.ShowInformation = ucFilterControl.ShowInformation;
            Criteria.ShowAuto = ucFilterControl.ShowAuto;
            Criteria.ShowProductionSwitch = ucFilterControl.ShowProductionSwitch;
            Criteria.ShowSecondaryFailures = ucFilterControl.ShowSecondaryFailures;
            Criteria.Categories = ucFilterControl.Categories;
            Criteria.Shift = ucFilterControl.Shift;
            Criteria.ShowSystemErrors = ucFilterControl.ShowSystemErrors;

            BindData();
        }

        protected void gridStops_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if ((e.Item.ItemType == GridItemType.Item) || (e.Item.ItemType == GridItemType.AlternatingItem))
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                AggregatedStoppageDataListItem stoppageItem = dataItem.DataItem as AggregatedStoppageDataListItem;

                Image imageMarker = (Image)dataItem["Marker"].FindControl("imageMarker");
                imageMarker.Height = Unit.Pixel(12);
                imageMarker.ImageUrl = string.Format("~/Production/imagehandler.ashx?ix={0}", stoppageItem.Index);
                
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
 
        #endregion

        #region Methods

        public void BindData()
        {
            BindFilter();
            BindInfo();
            BindStatus();
            BindOEE();
            BindOeeGraph();

            OeeDataList.Criteria criteria = Criteria.GetOeeDataListCriteria();
            OeeDataList oeedata = OeeDataList.GetOeeDataList(criteria);

            BindStateGraph(oeedata);
            BindStopGraphs();
        }

        private void BindOeeGraph()
        {
            OEEForMachine oeeForMachine = OEEForMachine.GetOEEForMachine(Criteria.GetOEEForMachineCriteria());
            chartOee.PlotArea.XAxis.LabelStep = oeeForMachine.Count / 5 + 1;
            chartOee.DataSource = oeeForMachine;
            chartOee.DataBind();
        }

        private void BindStateGraph(OeeDataList oeedata)
        {
            chartStates.Series[0].Items.Clear();
            ChartSeriesItemsCollection items = new ChartSeriesItemsCollection();
            chartStates.ChartTitle.TextBlock.Text = ResourceStrings.GetString("Chart.States.Title");

            if ((oeedata.TotalTime - oeedata.TotalNotConnectedTime) > 0)
            {
                if (oeedata.TotalAutoTime > 0)
                {
                    ChartSeriesItem item = new ChartSeriesItem(oeedata.TotalAutoTime);
                    item.Name = String.Format(ResourceStrings.GetString("Chart.States.Item.Running"), FormatStateTime(new TimeSpan(0, 0, (int)oeedata.TotalAutoTime)));
                    item.Label.Visible = false;
                    items.Add(item);
                }

                if (oeedata.TotalStopTime > 0)
                {
                    ChartSeriesItem item = new ChartSeriesItem(oeedata.TotalStopTime);
                    item.Name = String.Format(ResourceStrings.GetString("Chart.States.Item.Stopped"), FormatStateTime(new TimeSpan(0, 0, (int)oeedata.TotalStopTime)));
                    item.Label.Visible = false;
                    items.Add(item);
                }

                if (oeedata.TotalNoProductionTime > 0)
                {
                        ChartSeriesItem item = new ChartSeriesItem(oeedata.TotalNoProductionTime);
                        item.Name = String.Format(ResourceStrings.GetString("Chart.States.Item.NotInProduction"), FormatStateTime(new TimeSpan(0, 0, (int)oeedata.TotalNoProductionTime)));
                        item.Label.Visible = false;
                        items.Add(item);
                }
            }

            chartStates.Series[0].Items.AddRange(items);

        }

        private void BindStopGraphs()
        {
            StoppageDataList.Criteria criteria = Criteria.GetStoppageDataListCriteria();
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
            ucFilterControl.StartDate = Criteria.StartDate;
            ucFilterControl.EndDate = Criteria.EndDate;
            ucFilterControl.Shift = Criteria.Shift;
            ucFilterControl.ArticleNumber = Criteria.ArticleNumber;
            ucFilterControl.ShowInformation = Criteria.ShowInformation;
            ucFilterControl.ShowAuto = Criteria.ShowAuto;
            ucFilterControl.ShowProductionSwitch = Criteria.ShowProductionSwitch;
            ucFilterControl.ShowSecondaryFailures = Criteria.ShowSecondaryFailures;
            ucFilterControl.Categories = Criteria.Categories;
            ucFilterControl.ShowSystemErrors = Criteria.ShowSystemErrors;
            ucFilterControl.BindData();
        }

        private void BindInfo()
        {
            lbInfo.Text = M2MDataCenter.GetDivision(Criteria.DivisionId).DisplayName + " - " + M2MDataCenter.GetMachine(Criteria.DivisionId,Criteria.MachineId).DisplayName;
            buttonUp.PostBackUrl = "DivisionPage.aspx?DivisionId=" + Criteria.DivisionId;
            buttonShowAnalytical.PostBackUrl = "../Analyze/AnalyzePage.aspx?DivisionId=" + Criteria.DivisionId + "&MachineId=" + Criteria.MachineId;
            buttonShowAnalytical.Style["display"] = M2MDataCenter.User.CanAccessModule("Analyze") ? "block" : "none";
        }


 
        private void BindStatus()
        {
            RealTimeValues realTimeValues = RealTimeValues.GetRealTimeValues(Criteria.MachineId);

            ucStatusControl.Status = ResourceStrings.GetString("NotAvailable");
            ucStatusControl.Article = ResourceStrings.GetString("NotAvailable");

            if (realTimeValues != null)
            {
                ucStatusControl.Status = realTimeValues.Status;
                ucStatusControl.Article = realTimeValues.ArticleNumber;

                if (realTimeValues.ProductionSwitch)
                    ucStatusControl.StatusColor = realTimeValues.Auto ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                else
                    ucStatusControl.StatusColor = System.Drawing.Color.Black;
            }
        }

        private void BindOEE()
        {
            MachineListItem machine = MachineListItem.GetMachineListItem(Criteria.GetOeeDataListCriteria());
            ucOEEControl.Availability = machine.AvailabilityAsString;
            ucOEEControl.AvailabilityLoss = machine.AvailabilityLossBasedOnActualStopsAsString;
            ucOEEControl.Performance = machine.PerformanceAsString;
            ucOEEControl.Quality = machine.QualityAsString;
            ucOEEControl.OEE = machine.OEEAsString;
            ucOEEControl.Pace = machine.PaceAsString;
            ucOEEControl.ShowPace = true;
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