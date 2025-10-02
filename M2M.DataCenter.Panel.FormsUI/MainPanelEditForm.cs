using System;
using System.Collections.Generic;
using System.Drawing;
using M2M.DataCenter.Panel.FormsUI.BusinessObjects;
using Telerik.WinControls.UI;

namespace M2M.DataCenter.Panel.FormsUI
{
    public partial class MainPanelEditForm : Telerik.WinControls.UI.RadForm
    {
        private string TagId;
        private List<Reason> ReasonCodes;
        private List<ButtonData> AvailableButtons;
        private List<ButtonData> UsedButtons;

        public MainPanelEditForm()
        {
            InitializeComponent();
        }

        public MainPanelEditForm(string tagId, string tagName, List<Reason> reasonCodes) : this()
        {
            this.FormElement.TitleBar.Font = new Font("Segoe UI", 18f);
            this.FormElement.TitleBar.CloseButton.AutoSize = true;
            this.Text = tagName;
            this.TagId = tagId;
            this.ReasonCodes = reasonCodes;
            this.AvailableButtons = new List<ButtonData>();
            this.UsedButtons = new List<ButtonData>();
        }

        private void MainPanelEditForm_Load(object sender, EventArgs e)
        {
            CompareAndRepairLists();
            
            this.radButton20.SetButtonData(this.UsedButtons, 0, 0);
            this.radButton1.SetButtonData(this.UsedButtons, 0, 1);
            this.radButton2.SetButtonData(this.UsedButtons, 0, 2);
            this.radButton3.SetButtonData(this.UsedButtons, 0, 3);
            
            this.radButton7.SetButtonData(this.UsedButtons, 1, 0);
            this.radButton6.SetButtonData(this.UsedButtons, 1, 1);
            this.radButton5.SetButtonData(this.UsedButtons, 1, 2);
            this.radButton4.SetButtonData(this.UsedButtons, 1, 3);
            
            this.radButton11.SetButtonData(this.UsedButtons, 2, 0);
            this.radButton10.SetButtonData(this.UsedButtons, 2, 1);
            this.radButton9.SetButtonData(this.UsedButtons, 2, 2);
            this.radButton8.SetButtonData(this.UsedButtons, 2, 3);
            
            this.radButton15.SetButtonData(this.UsedButtons, 3, 0);
            this.radButton14.SetButtonData(this.UsedButtons, 3, 1);
            this.radButton13.SetButtonData(this.UsedButtons, 3, 2);
            this.radButton12.SetButtonData(this.UsedButtons, 3, 3);

            this.radButton19.SetButtonData(this.UsedButtons, 4, 0);
            this.radButton18.SetButtonData(this.UsedButtons, 4, 1);
            this.radButton17.SetButtonData(this.UsedButtons, 4, 2);
            this.radButton16.SetButtonData(this.UsedButtons, 4, 3);
        }

        private void UpdateButtonData(RadButton button, Coordinates coords)
        {
            button.SetButtonData(this.UsedButtons, coords.Row, coords.Column);
        }

        private bool UpdateLists(ButtonData oldButton, ButtonData newButton)
        {
            bool updateButton = false;
            
            if (oldButton != null)
            {
                SystemDatabase.DeleteButtonData(oldButton);
                this.UsedButtons.RemoveAll(ButtonData.ByReasonId(oldButton.ReasonId));
                this.AvailableButtons.Add(oldButton);
                updateButton = true;
            }
            if (newButton != null)
            {
                SystemDatabase.AddButtonData(newButton);
                this.AvailableButtons.RemoveAll(ButtonData.ByReasonId(newButton.ReasonId));
                this.UsedButtons.Add(newButton);
                updateButton = true;
            }

            return updateButton;
        }

        private void radButtonGeneric_Click(object sender, EventArgs e)
        {

            ButtonPropertyForm form = new ButtonPropertyForm(this.AvailableButtons, (sender as RadButton).Tag is ButtonData ? (sender as RadButton).Tag as ButtonData : null, (sender as RadButton).Tag is Coordinates ? (sender as RadButton).Tag as Coordinates: null);
            form.ShowDialog(this);
            if (UpdateLists(form.OldButton, form.NewButton))
                UpdateButtonData(sender as RadButton, form.Coords);
        }

        private void CompareAndRepairLists()
        {
            List<ButtonData> buttons = SystemDatabase.GetButtonDataList(this.TagId);
            foreach (ButtonData button in buttons)
            {
                ButtonData localButton = button;
                Reason reason = this.ReasonCodes.Find(a => a.ReasonCode == localButton.ReasonId);
                if (reason != null && reason.DisplayName == localButton.DisplayName)
                    this.UsedButtons.Add(localButton);
                else
                    SystemDatabase.DeleteButtonData(localButton);
            }

            buttons = SystemDatabase.GetButtonDataList(this.TagId);
            foreach (Reason reason in this.ReasonCodes)
            {
                if (!buttons.Exists(ButtonData.ByReasonId(reason.ReasonCode)))
                    this.AvailableButtons.Add(new ButtonData(reason.TagId, reason.ReasonCode, reason.DisplayName, -1, -1));
                
            }
        }

        
    }
}
