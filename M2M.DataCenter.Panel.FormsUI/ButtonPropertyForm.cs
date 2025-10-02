using System;
using System.Collections.Generic;
using System.Drawing;
using M2M.DataCenter.Panel.FormsUI.BusinessObjects;
using Telerik.WinControls.Enumerations;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.Panel.FormsUI
{
    public partial class ButtonPropertyForm : Telerik.WinControls.UI.RadForm
    {
        private List<ButtonData> AvailableButtons { get; set; }
        private ButtonData CurrentButton { get; set; }
        public ButtonData NewButton { get; set; }
        public ButtonData OldButton { get; set; }
        public Coordinates Coords { get; set; }

        public ButtonPropertyForm()
        {
            InitializeComponent();

            Localize();
        }

        private void Localize()
        {
            this.Text = ResourceStrings.GetString("Panel.ButtonPropertyForm.ConnectReason");
            this.radCheckBox1.Text = ResourceStrings.GetString("Panel.ButtonPropertyForm.NotInUse");
            this.radButton1.Text = ResourceStrings.GetString("Save");
        }

        public ButtonPropertyForm(List<ButtonData> availableButtons, ButtonData currentButton, Coordinates coords) : this()
        {
            this.FormElement.TitleBar.Font = new Font("Segoe UI", 18f);
            
            this.AvailableButtons = availableButtons;
            this.CurrentButton = currentButton;
            this.Coords = coords != null ? coords : new Coordinates(currentButton.Row, currentButton.Column);
            this.radDropDownListReasonss.DropDownListElement.ItemHeight = 40;
        }
        
        private void radButton1_Click(object sender, EventArgs e)
        {
            this.OldButton = null;
            this.NewButton = null;

            if (this.CurrentButton == null && !this.radCheckBox1.Checked)
            {
                this.NewButton = this.AvailableButtons.Find(ButtonData.ByReasonId((int)this.radDropDownListReasonss.SelectedValue));
                this.NewButton.Row = this.Coords.Row;
                this.NewButton.Column = this.Coords.Column;
            }
            else if (this.CurrentButton != null && this.radCheckBox1.Checked)
            {
                this.OldButton = this.CurrentButton;
            }
            else if (this.CurrentButton != null && this.radDropDownListReasonss.SelectedValue != null && this.CurrentButton.ReasonId != this.AvailableButtons.Find(ButtonData.ByReasonId((int)this.radDropDownListReasonss.SelectedValue)).ReasonId)
            {
                this.OldButton = this.CurrentButton;
                this.NewButton = this.AvailableButtons.Find(ButtonData.ByReasonId((int)this.radDropDownListReasonss.SelectedValue));
                this.NewButton.Row = this.Coords.Row;
                this.NewButton.Column = this.Coords.Column;
            }
                
            this.Close();
        }

        private void ButtonPropertyForm_Load(object sender, EventArgs e)
        {
            this.radCheckBox1.Checked = this.CurrentButton == null;
            this.radDropDownListReasonss.DataSource = this.AvailableButtons;
            if (this.CurrentButton != null)
            {
                this.radDropDownListReasonss.SelectedValue = this.CurrentButton.ReasonId;
            }
        }

        private void radCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.radDropDownListReasonss.Enabled = args.ToggleState == ToggleState.Off;
        }

        private void radDropDownListReasonss_ItemDataBound(object sender, Telerik.WinControls.UI.ListItemDataBoundEventArgs args)
        {
            args.NewItem.Font = this.radDropDownListReasonss.Font;
        }

        
    }
}
