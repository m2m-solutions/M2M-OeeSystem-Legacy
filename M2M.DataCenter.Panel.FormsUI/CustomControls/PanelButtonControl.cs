using System;
using System.Linq;
using System.Windows.Forms;
using M2M.DataCenter.Panel.FormsUI.BusinessObjects;
using Telerik.WinControls.UI;
using NLog;

namespace M2M.DataCenter.Panel.FormsUI.CustomControls
{
    public partial class PanelButtonControl : UserControl
    {
        #region Fields

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public EventInfo PendingEvent { get; set; }
        public bool ChangeOver { get; set; }
        
        #endregion

        #region Constructors

        public PanelButtonControl()
        {
            InitializeComponent();
   //         this.radButtonCause.Click += new EventHandler(radButtonCause_Click);
        }

        public PanelButtonControl(ButtonData buttonData, EventInfo pendingEvent, bool changeOver) : this()
        {
            this.Left = buttonData.Column * Globals.PanelButton.Width;
            this.Top = buttonData.Row * Globals.PanelButton.Height;
            this.radButtonCause.Text = buttonData.DisplayName;
            this.radButtonCause.Tag = buttonData;
            this.PendingEvent= pendingEvent;
            this.ChangeOver = changeOver;
        }

       
                

        #endregion

        #region Properties

        public ButtonData Data
        {
            get
            {
                return this.radButtonCause.Tag as ButtonData;
            }
        }

        

        #endregion

        #region Methods

        
        #endregion

        #region Event Handlers

        void radButtonCause_Click(object sender, EventArgs e)
        {
            ButtonData btnData = (sender as RadButton).Tag as ButtonData;
            logger.Info("Cause selected {0} : {1} ({2})", btnData.TagId, btnData.DisplayName, btnData.ReasonId);
            SystemDatabase.UpdateEvent(this.PendingEvent.EventId, btnData);
            if (this.ChangeOver)
            {
                logger.Info("Change-over request {0} : {1} ({2})", btnData.TagId, btnData.DisplayName, btnData.ReasonId);
                SystemDatabase.AddChangeOverRequest(this.PendingEvent);
            }
        }

        #endregion
    }
}
