namespace M2M.DataCenter.Panel.FormsUI.CustomControls
{
    partial class PanelButtonControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radButtonCause = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonCause)).BeginInit();
            this.SuspendLayout();
            // 
            // radButtonCause
            // 
            this.radButtonCause.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radButtonCause.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.radButtonCause.Location = new System.Drawing.Point(31, 22);
            this.radButtonCause.Name = "radButtonCause";
            this.radButtonCause.Size = new System.Drawing.Size(188, 73);
            this.radButtonCause.TabIndex = 66;
            this.radButtonCause.Text = "[DisplayValue]";
            this.radButtonCause.Click += new System.EventHandler(this.radButtonCause_Click);
            // 
            // PanelButtonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.radButtonCause);
            this.Name = "PanelButtonControl";
            this.Size = new System.Drawing.Size(250, 120);
            ((System.ComponentModel.ISupportInitialize)(this.radButtonCause)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton radButtonCause;
    }
}
