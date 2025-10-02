using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using M2M.DataCenter.Panel.FormsUI.BusinessObjects;
using M2M.DataCenter.Panel.FormsUI.CustomControls;
using Telerik.WinControls.UI.Localization;
using System.Net.NetworkInformation;
using System.Data.SqlClient;
using Telerik.WinControls.Data;
using NLog;
using System.Threading;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.Panel.FormsUI
{
    public partial class Form1 : RadForm
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private List<TagInfo> SubscriptionTags;
        private List<Reason> ReasonCodes;
        private List<Category> Categories;
        private Dictionary<string, List<ButtonData>> ButtonDataDictionary;
        private EventInfo PendingEvent = null;
        private volatile ManualResetEvent AbortReconnect = new ManualResetEvent(false);
        private volatile ManualResetEvent PauseReconnect = new ManualResetEvent(true);
        private bool AllowPageChange = true;
        private Thread WorkerThread = null;
        private bool AdminMode = false;
        
        public Form1()
        {
            //ThemeResolutionService.L.LoadPackageResource(@"M2M.DataCenter.Panel.FormsUI.VisualStudio2012Dark2.tssp");
            InitializeComponent();

            GridViewCommandColumn commandColumn = new GridViewCommandColumn();
            commandColumn.UseDefaultText = true;
            commandColumn.HeaderText = "";
            commandColumn.DefaultText = ResourceStrings.GetString("Delete");
            commandColumn.MinWidth = 70;
            commandColumn.Name = "deleteCommand";
            commandColumn.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            commandColumn.UseDefaultText = true;
            commandColumn.Width = 136;
            this.radGridViewReasonCodes.Columns.Add(commandColumn);

            Localize();

            ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark";
            //ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark2";

            this.radPanelAlert.BackColor = Color.Transparent;
            this.radPanelButtonGrid.ForeColor = Color.Transparent;

            RadGridLocalizationProvider.CurrentProvider = new CustomRadGridLocalizationProvider();
            
            CheckIfDeveloperEnvironment();

           if (ApplicationSettings.KioskMode)
            {
                logger.Info("Kiosk mode enabled");
                notifyIcon1.Visible = false;
                Cursor.Hide();
                WinApi.SetWinFullScreen(this.Handle);
            }
            else
            {
                logger.Info("Kiosk mode disabled");
                notifyIcon1.Visible = true;
                MinimizeToTray();
            }

            SetApplicationInUserMode();

        }

        private void Localize()
        {
            radPageViewPage1.Text = ResourceStrings.GetString("Panel.PageViewPage1");
            radPageViewPage2.Text = ResourceStrings.GetString("Panel.PageViewPage2");
            radPageViewPage3.Text = ResourceStrings.GetString("Panel.PageViewPage3");
            radPageViewPage4.Text = ResourceStrings.GetString("Panel.PageViewPage4");
            radPageViewPage5.Text = ResourceStrings.GetString("Panel.PageViewPage5");
            radPageViewPage6.Text = ResourceStrings.GetString("Panel.PageViewPage6");
            radGridViewReasonCodes.Columns[2].HeaderText = ResourceStrings.GetString("Reason");
            radGridViewReasonCodes.Columns[3].HeaderText = ResourceStrings.GetString("Category");
            radLabel6.Text = ResourceStrings.GetString("Panel.NoStopPending");
            radLabel2.Text = ResourceStrings.GetString("Panel.AlwaysUpdate");
            radButton1.Text = ResourceStrings.GetString("Panel.UpdateReasonView");
            radDropDownListTags.NullText = ResourceStrings.GetString("Panel.ChooseSignal");
            btnClearPending.Text = ResourceStrings.GetString("Panel.ClearPending");
        }

        private void GetPendingAlerts()
        {
            logger.Info("GetPendingAlerts called");
            if (this.radPanelAlert == null)
                logger.Info("radPanelAlert is null");
            if (this.radPanelButtonGrid == null)
                logger.Info("radPanelButtonGrid is null");
            bool alertsPending = false;
            this.radPanelAlert.Visible = false;
            this.PendingEvent = null;
            this.radPanelButtonGrid.Controls.Clear();
            if(this.SubscriptionTags == null)
                logger.Info("SubscritionTags is null");
            if (this.SubscriptionTags != null && this.SubscriptionTags.Count > 0)
            {

                try
                {
                    //  You must stop the dependency before starting a new one.
                    //  You must start the dependency when creating a new one.
                    SqlDependency.Stop(SystemDatabase.ConnectionString);
                    SqlDependency.Start(SystemDatabase.ConnectionString);

                    using (SqlConnection cn = new SqlConnection(SystemDatabase.ConnectionString))
                    {
                        using (SqlCommand cmd = cn.CreateCommand())
                        {
                            string whereClause = "";
                            foreach (TagInfo tag in this.SubscriptionTags)
                            {
                                if (whereClause != "")
                                    whereClause += ",";
                                whereClause += String.Format("'{0}'", tag.TagId);
                            }
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = String.Format("SELECT EventId, TagId, DisplayName, MachineId, EventRaised FROM dbo.[PendingPanelRequests] WHERE TagId in ({0}) ORDER BY EventRaised DESC", whereClause);

                            cmd.Notification = null;

                            //  creates a new dependency for the SqlCommand
                            SqlDependency dep = new SqlDependency(cmd);
                            //  creates an event handler for the notification of data
                            //      changes in the database.
                            dep.OnChange += new OnChangeEventHandler(dep_OnChange);

                            cn.Open();
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    
                                    this.PendingEvent = new EventInfo(dr.GetGuid(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetDateTime(4));
                                    int count = 1;
                                    while (dr.Read())
                                        count++;

                                    this.AllowPageChange = this.AdminMode;
                                    this.radLabelAlert.Text = String.Format("{0} ({1})", this.PendingEvent.DisplayName, count);
                                    this.radLabelEventRaisedDate.Text = this.PendingEvent.EventRaised.Date == DateTime.Today ? "" : this.PendingEvent.EventRaised.ToString("yyyy:MM:dd");
                                    this.radLabelEventRaised.Text = this.PendingEvent.EventRaised.ToString("HH:mm:ss");
                                    this.radPanelAlert.Visible = true;
                                    logger.Info("Pending alert {0} : {1}", this.PendingEvent.TagId, this.PendingEvent.EventId);
                                    LoadButtonPanel();
                                    alertsPending = true;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    SystemDatabase.IsConnected = false;

                    logger.ErrorException("Failed to connect to server", ex);

                    if (!this.WorkerThread.IsAlive)
                    {
                        this.WorkerThread = new Thread(new ThreadStart(Reconnect));
                        this.WorkerThread.Start();
                    }
                   
                }
            }

            if (alertsPending)
            {
                if (!ApplicationSettings.KioskMode)
                   this.BeginInvoke(new MethodInvoker(MaximizeFromTray));
            }
            else
            {
                this.AllowPageChange = true;
                if (!ApplicationSettings.KioskMode && !ApplicationSettings.DeveloperIgnoreMinimize)
                    this.BeginInvoke(new MethodInvoker(MinimizeToTray));
            }
        }

        private void ShowConnected()
        {
            this.radPageViewPage1.Text = ResourceStrings.GetString("Panel.PageViewPage1.StateOk");
            this.radPageViewPage1.Item.ForeColor = Color.Green;
            this.radPageViewPage3.Enabled = true;
            this.radPageViewPage4.Enabled = this.AdminMode;

            webBrowser1.Refresh(WebBrowserRefreshOption.Normal);
        }

        private void ShowDisconnected()
        {
            this.radPageViewPage1.Text = ResourceStrings.GetString("Panel.PageViewPage1.StateNotOk");
            this.radPageViewPage1.Item.ForeColor = Color.OrangeRed;
            this.radPageViewPage3.Enabled = false;
            this.radPageViewPage4.Enabled = false;
            this.radPageView1.SelectedPage = this.radPageViewPage2;
        }

        void Reconnect()
        {
            if (this.InvokeRequired)
                this.radPageView1.BeginInvoke(new MethodInvoker(ShowDisconnected));
            else
                ShowDisconnected();

            if (SystemDatabase.IsConnected == false)
                Thread.Sleep(1000);

            bool logFailure = true;
            bool connectSuccesfull = false;
            while (true)
            {
                PauseReconnect.WaitOne(Timeout.Infinite);

                if (AbortReconnect.WaitOne(0))
                    break;
                try
                {
                    using (SqlConnection cn = new SqlConnection(SystemDatabase.ConnectionString))
                    {
                        cn.Open();
                        using (SqlCommand command = cn.CreateCommand())
                        {
                            command.CommandText = "SELECT 1";
                            command.CommandType = CommandType.Text;
                            command.ExecuteNonQuery();
                            connectSuccesfull = true;
                        }
                        break;
                    }
                }
                catch (Exception ex)
                {
                    if (logFailure)
                    {
                        logger.ErrorException("Failed to connect", ex);
                        logFailure = false;
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(500);

                        PauseReconnect.WaitOne(Timeout.Infinite);

                        if (AbortReconnect.WaitOne(0))
                            break;
                    }
                }

               
            }

            if (connectSuccesfull)
            {
                IAsyncResult res = null;
                if (this.InvokeRequired)
                    this.radPageView1.BeginInvoke(new MethodInvoker(ShowConnected));
                else
                    ShowConnected();

                if (this.InvokeRequired)
                    res = this.radPageView1.BeginInvoke(new MethodInvoker(LoadSettings));
                else
                    LoadSettings();

                if (res != null)
                {
                    while (!res.IsCompleted)
                    {
                        Thread.Sleep(100);
                    }
                }

                if (this.InvokeRequired)
                    this.BeginInvoke(new MethodInvoker(GetPendingAlerts));
                else
                    GetPendingAlerts();
            }
        }

        void dep_OnChange(object sender, SqlNotificationEventArgs e)
        {
            logger.Trace("{0} {1} {2}", e.Source, e.Type, e.Info);
            if(e.Source == SqlNotificationSource.Client && e.Type == SqlNotificationType.Change && e.Info == SqlNotificationInfo.Error)
            {
                if(!this.WorkerThread.IsAlive)
                {
                    this.WorkerThread = new Thread(new ThreadStart(Reconnect));
                    this.WorkerThread.Start();
                }
            }
            else
            {
                // this event is run asynchronously so you will need to invoke to run on UI thread(if required).
                if (this.InvokeRequired)
                    this.BeginInvoke(new MethodInvoker(GetPendingAlerts));
                else
                    GetPendingAlerts();
               
                SqlDependency dep = sender as SqlDependency;
                dep.OnChange -= new OnChangeEventHandler(dep_OnChange);
            }
        }

        private void radButtonEditButtonPanel_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // PageViewPage1 Overview

            logger.Info("Application started");
            logger.Info("SystemConnectionString = {0}", ApplicationSettings.SystemConnectionString);
            logger.Info("OeeSystemAddress = {0}", ApplicationSettings.OeeSystemAddress);
            logger.Info("DivisionId = {0}", ApplicationSettings.DivisionId);
            logger.Info("MachineId = {0}", ApplicationSettings.MachineId);
            logger.Info("MachineType = {0}", ApplicationSettings.MachineType);

            this.radPageViewPage1.Text = ResourceStrings.GetString("Panel.PageViewPage1.StateOk");
            this.radPageViewPage1.Item.ForeColor = Color.Green;
            SystemDatabase.LogException = true;

            // PageViewPage3 Oee System
            switch (ApplicationSettings.MachineType)
            {
                case "SingleMachine":
                    webBrowser1.Navigate(String.Format(ApplicationSettings.OeeSystemAddress, ApplicationSettings.DivisionId, ApplicationSettings.MachineId));
                    break;
                case "Line":
                    webBrowser1.Navigate(String.Format(ApplicationSettings.OeeSystemAddress, ApplicationSettings.DivisionId));
                    break;
            }

            this.WorkerThread = new Thread(new ThreadStart(Reconnect));
            this.WorkerThread.Start();

            
        }

        private void radPageViewPage5_Click(object sender, EventArgs e)
        {
        }

        private void radPageView1_PageIndexChanging(object sender, RadPageViewIndexChangingEventArgs e)
        {
            
        }

        private void radPageView1_SelectedPageChanging(object sender, RadPageViewCancelEventArgs e)
        {
            switch (e.Page.Name)
            {
                case "radPageViewPage1":
                    // Only allow minimize in admin mode or when there's no pending alerts
                    if(!ApplicationSettings.KioskMode && (this.AdminMode || this.PendingEvent == null))
                        MinimizeToTray();
                    e.Cancel = true;
                    break;
                case "radPageViewPage3":
                    if (!this.AllowPageChange)
                    {
                        CustomMessageBox messageBox = new CustomMessageBox();
                        messageBox.Show(this, ResourceStrings.GetString("Panel.Warning.Title"), ResourceStrings.GetString("Panel.Warning.Navigation"));
                        e.Cancel = true;
                    }
                    webBrowser1.Refresh(WebBrowserRefreshOption.Normal);
                    break;
                case "radPageViewPage4":
                    IAsyncResult res = null;
                    if (this.InvokeRequired)
                        res = this.radPageView1.BeginInvoke(new MethodInvoker(LoadSettings));
                    else
                        LoadSettings();

                    if (res != null)
                    {
                        while (!res.IsCompleted)
                        {
                            Thread.Sleep(100);
                        }
                    }
                    break;
                case "radPageViewPage5":
                    AbortReconnect.Set();
                    PauseReconnect.Set();
                    if(this.WorkerThread != null && this.WorkerThread.IsAlive)
                        this.WorkerThread.Join();
                    SqlDependency.Stop(SystemDatabase.ConnectionString);
                    logger.Info("Application stopped");
                    this.notifyIcon1.Dispose();
                    this.Close();
                    break;
                case "radPageViewPage6":
                    if(!this.AdminMode)
                    {
                        PauseReconnect.Reset();
                        LogonDialog dlg = new LogonDialog();

                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            SetApplicationInAdminMode();
                        }
                        else
                        {
                            PauseReconnect.Set();
                        }
                    }
                    else
                    {
                        SetApplicationInUserMode();
                        PauseReconnect.Set();

                        if (this.InvokeRequired)
                            this.radPageView1.BeginInvoke(new MethodInvoker(GetPendingAlerts));
                        else
                            GetPendingAlerts();
                    }
                    e.Cancel = true;
                    break;
                        
            }
        }

        private void LoadButtonPanel()
        {
            this.radPanelButtonGrid.Controls.Clear();
            
            if(this.PendingEvent == null 
                || !this.ButtonDataDictionary.ContainsKey(this.PendingEvent.TagId))
                return;

            List<ButtonData> buttons = this.ButtonDataDictionary[this.PendingEvent.TagId];
            
            foreach (ButtonData button in buttons.ToList<ButtonData>())
            {
                int categoryId = this.ReasonCodes.Find(Reason.ByReasonCode(this.PendingEvent.TagId, button.ReasonId)).CategoryId;
                bool changeOver = this.Categories.Find(Category.ByCategoryId(categoryId)).ChangeOver;
                this.radPanelButtonGrid.Controls.Add(new PanelButtonControl(button, this.PendingEvent, changeOver));
            }

        }

        

        private void LoadSettings()
        {
            logger.Info("LoadSettings called");
            this.SubscriptionTags = SystemDatabase.GetSubscriptionTags(ApplicationSettings.DivisionId, ApplicationSettings.MachineId, ApplicationSettings.MachineType);
            if (this.SubscriptionTags.Count > 0)
            {
                this.ReasonCodes = SystemDatabase.GetReasonCodes(ApplicationSettings.DivisionId, ApplicationSettings.MachineId, ApplicationSettings.MachineType);
                this.Categories = SystemDatabase.GetCategories();
                this.ButtonDataDictionary = SystemDatabase.GetButtonDataList(this.SubscriptionTags);

                this.radGridViewReasonCodes.TableElement.RowHeight = 40;
                this.radDropDownListTags.DropDownListElement.ItemHeight = 40;

                //allow the grid to genetate its columns
                this.radGridViewReasonCodes.MasterTemplate.AutoGenerateColumns = false;

                //set the grid data source
                this.radGridViewReasonCodes.DataSource = this.ReasonCodes;

                (this.radGridViewReasonCodes.Columns["Category"] as GridViewComboBoxColumn).DataSource = this.Categories;
                
                this.radDropDownListTags.BeginUpdate();
                this.radDropDownListTags.DataSource = this.SubscriptionTags;
                this.radDropDownListTags.SelectedIndex = 0;
                this.radDropDownListTags.EndUpdate();
            }
        }

        private void CheckIfDeveloperEnvironment()
        {
            var macAddresses = 
            (
                from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up
                select nic.GetPhysicalAddress().ToString()
            ).ToArray();

            ApplicationSettings.IsDeveloperEnvironment = macAddresses.Contains("00155D1E0503");

            
        }

        private void SetApplicationInAdminMode()
        {
            logger.Info("Admin Mode selected");
            this.radPageViewPage6.Text = ResourceStrings.GetString("Panel.PageViewPage6.On");
            this.radPageViewPage6.Item.ForeColor = Color.OrangeRed;
            this.radPageViewPage4.Enabled = true;
            this.radPageViewPage4.Item.ForeColor = Color.White;
            this.radPageViewPage5.Enabled = true;
            this.radPageViewPage5.Item.ForeColor = Color.White;
            this.AdminMode = true;
        }


        private void SetApplicationInUserMode()
        {
            logger.Info("User Mode selected");
            this.radPageViewPage6.Text = ResourceStrings.GetString("Panel.PageViewPage6.Off");
            this.radPageViewPage6.Item.ForeColor = Color.White;
            this.radPageViewPage4.Enabled = false;
            this.radPageViewPage4.Item.ForeColor = Color.Transparent;
            this.radPageViewPage5.Enabled = false;
            this.radPageViewPage5.Item.ForeColor = Color.Transparent;
            this.AdminMode = false;

            this.radPageView1.SelectedPage = this.radPageViewPage2;
        }

        

        private void radDropDownListTags_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            this.radGridViewReasonCodes.DataSource = this.ReasonCodes.FindAll(a => a.TagId == (sender as RadDropDownList).SelectedValue.ToString());
        }

        private void radGridViewReasonCodes_CommandCellClick(object sender, EventArgs e)
        {
            if(this.radGridViewReasonCodes.CurrentRow is GridViewNewRowInfo)
                return;
     
            this.radGridViewReasonCodes.Rows.Remove(this.radGridViewReasonCodes.CurrentRow);
           
        }

        private void radGridViewReasonCodes_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            Reason reason = null;

            if (e.Action == NotifyCollectionChangedAction.Add)
                reason = (e.NewItems[0] as GridViewRowInfo).DataBoundItem as Reason;
            else if (e.Action == NotifyCollectionChangedAction.ItemChanged || e.Action == NotifyCollectionChangedAction.Remove)
                reason = this.radGridViewReasonCodes.CurrentRow.DataBoundItem as Reason;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    SystemDatabase.AddReason(reason);
                    this.ReasonCodes.Add(reason);
                    break;
                case NotifyCollectionChangedAction.ItemChanged:
                    SystemDatabase.UpdateReason(reason);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    SystemDatabase.DeleteReason(reason);
                    this.ReasonCodes.Remove(reason);
                    break;
            }
        }

        private void radGridViewReasonCodes_UserDeletingRow(object sender, GridViewRowCancelEventArgs e)
        {
            e.Cancel = true;
        }

        
        private void radDropDownListTags_ItemDataBound(object sender, ListItemDataBoundEventArgs args)
        {
            args.NewItem.Font = this.radDropDownListTags.Font;
        }
        
        private void radGridViewReasonCodes_DefaultValuesNeeded(object sender, GridViewRowEventArgs e)
        {
            foreach (TagInfo tag in this.SubscriptionTags)
            {
                if (tag.TagId == this.radDropDownListTags.SelectedValue.ToString())
                {
                    e.Row.Cells["TagId"].Value = tag.TagId;
                    e.Row.Cells["ReasonCode"].Value = SystemDatabase.GetNextReasonCodeSequences(tag.TagId);
                    e.Row.Cells["Category"].Value = tag.CategoryId;
                    e.Row.Cells["DivisionId"].Value = tag.DivisionId;
                    e.Row.Cells["MachineId"].Value = tag.MachineId;
                    e.Row.Cells["DisplayName"].Value = "";
                }
            }
            
        }

        private void radGridViewReasonCodes_RowValidating(object sender, RowValidatingEventArgs e)
        {
            //if (e.Row is GridViewNewRowInfo)
            //{
            //    if (e.Row.Cells["DisplayName"].Value == null || (string)e.Row.Cells["DisplayName"].Value == "")
            //        e.Cancel = true;

            //    if (e.Row.Cells["ReasonCode"].Value == null)
            //        e.Cancel = true;
            //}
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            TagInfo tag = this.SubscriptionTags.Find(TagInfo.ByTagId(this.radDropDownListTags.SelectedValue.ToString()));
            MainPanelEditForm editForm = new MainPanelEditForm(tag.TagId, tag.DisplayName, this.ReasonCodes.Where(a => a.TagId == tag.TagId).ToList());
            editForm.ShowDialog(this);

            this.ButtonDataDictionary = SystemDatabase.GetButtonDataList(this.SubscriptionTags);
            LoadButtonPanel();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if (FormWindowState.Minimized == this.WindowState)
            //{
            //    MinimizeToTray();
            //}

            //else if (FormWindowState.Normal == this.WindowState)
            //{
            //    MaximizeFromTray();
            //}
        }

        private void MinimizeToTray()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Thread.Sleep(1000);
                this.TopMost = true;
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
        }


        private void MaximizeFromTray()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            MaximizeFromTray();
        }

        private void radGridViewReasonCodes_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
           
        }

        private void radGridViewReasonCodes_CellFormatting(object sender, CellFormattingEventArgs e)
        {
           
        }

        private void btnClearPending_Click(object sender, EventArgs e)
        {
            SystemDatabase.ClearPending(ApplicationSettings.DivisionId, ApplicationSettings.MachineId, ApplicationSettings.MachineType);
        }
    }
}
