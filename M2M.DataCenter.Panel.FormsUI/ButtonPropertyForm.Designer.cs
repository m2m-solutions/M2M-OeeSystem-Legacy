namespace M2M.DataCenter.Panel.FormsUI
{
    partial class ButtonPropertyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radDropDownListReasonss = new Telerik.WinControls.UI.RadDropDownList();
            this.radCheckBox1 = new Telerik.WinControls.UI.RadCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownListReasonss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.radLabel1.Location = new System.Drawing.Point(12, 22);
            this.radLabel1.MaximumSize = new System.Drawing.Size(440, 100);
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.MaxSize = new System.Drawing.Size(440, 100);
            this.radLabel1.Size = new System.Drawing.Size(2, 2);
            this.radLabel1.TabIndex = 5;
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.radButton1.Location = new System.Drawing.Point(303, 120);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(131, 49);
            this.radButton1.TabIndex = 3;
            this.radButton1.Text = "Spara";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radDropDownListReasonss
            // 
            this.radDropDownListReasonss.AutoCompleteDisplayMember = "DisplayName";
            this.radDropDownListReasonss.AutoCompleteValueMember = "ReasonId";
            this.radDropDownListReasonss.DataMember = "ReasonId";
            this.radDropDownListReasonss.DisplayMember = "DisplayName";
            this.radDropDownListReasonss.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.radDropDownListReasonss.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDropDownListReasonss.Location = new System.Drawing.Point(34, 71);
            this.radDropDownListReasonss.Name = "radDropDownListReasonss";
            this.radDropDownListReasonss.NullText = "[Används ej]";
            this.radDropDownListReasonss.Size = new System.Drawing.Size(400, 31);
            this.radDropDownListReasonss.TabIndex = 7;
            this.radDropDownListReasonss.ValueMember = "ReasonId";
            this.radDropDownListReasonss.ItemDataBound += new Telerik.WinControls.UI.ListItemDataBoundEventHandler(this.radDropDownListReasonss_ItemDataBound);
            // 
            // radCheckBox1
            // 
            this.radCheckBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCheckBox1.Location = new System.Drawing.Point(34, 22);
            this.radCheckBox1.Name = "radCheckBox1";
            this.radCheckBox1.Size = new System.Drawing.Size(128, 34);
            this.radCheckBox1.TabIndex = 8;
            this.radCheckBox1.Text = "Använd ej";
            this.radCheckBox1.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox1_ToggleStateChanged);
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.radCheckBox1.GetChildAt(0))).Text = "Använd ej";
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.radCheckBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).CheckPrimitiveStyle = Telerik.WinControls.Enumerations.CheckPrimitiveStyleEnum.Vista;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.radCheckBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).DrawFill = false;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.radCheckBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).UseFixedCheckSize = false;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.radCheckBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).CheckThickness = 5;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.radCheckBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).PaintUsingParentShape = false;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.radCheckBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.radCheckBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).MinSize = new System.Drawing.Size(32, 32);
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.radCheckBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).StretchHorizontally = false;
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.radCheckBox1.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).StretchVertically = false;
            // 
            // ButtonPropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 188);
            this.ControlBox = false;
            this.Controls.Add(this.radCheckBox1);
            this.Controls.Add(this.radDropDownListReasonss);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radButton1);
            this.Name = "ButtonPropertyForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.ButtonPropertyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownListReasonss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadDropDownList radDropDownListReasonss;
        private Telerik.WinControls.UI.RadCheckBox radCheckBox1;
    }
}
