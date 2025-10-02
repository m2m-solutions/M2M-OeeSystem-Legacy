namespace M2M.DataCenter.Panel.FormsUI
{
    partial class LogonDialog
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
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radMaskedEditBox1 = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.radLabelValidation = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMaskedEditBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelValidation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.radLabel1.Location = new System.Drawing.Point(32, 13);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(79, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Lösenord:";
            // 
            // radButton1
            // 
            this.radButton1.Enabled = false;
            this.radButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.radButton1.Location = new System.Drawing.Point(32, 81);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(131, 49);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "Logga in";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radButton2
            // 
            this.radButton2.CausesValidation = false;
            this.radButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.radButton2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.radButton2.Location = new System.Drawing.Point(190, 81);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(134, 49);
            this.radButton2.TabIndex = 3;
            this.radButton2.Text = "Avbryt";
            // 
            // radMaskedEditBox1
            // 
            this.radMaskedEditBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.radMaskedEditBox1.Location = new System.Drawing.Point(117, 11);
            this.radMaskedEditBox1.Name = "radMaskedEditBox1";
            this.radMaskedEditBox1.NullText = "Ange lösenord";
            this.radMaskedEditBox1.PasswordChar = '*';
            this.radMaskedEditBox1.Size = new System.Drawing.Size(207, 27);
            this.radMaskedEditBox1.TabIndex = 1;
            this.radMaskedEditBox1.TabStop = false;
            this.radMaskedEditBox1.ValueChanged += new System.EventHandler(this.radMaskedEditBox1_ValueChanged);
            this.radMaskedEditBox1.ValueChanging += new System.ComponentModel.CancelEventHandler(this.radMaskedEditBox1_ValueChanging);
            this.radMaskedEditBox1.TextChanged += new System.EventHandler(this.radMaskedEditBox1_TextChanged);
            // 
            // radLabelValidation
            // 
            this.radLabelValidation.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.radLabelValidation.ForeColor = System.Drawing.Color.Red;
            this.radLabelValidation.Location = new System.Drawing.Point(117, 44);
            this.radLabelValidation.Name = "radLabelValidation";
            this.radLabelValidation.Size = new System.Drawing.Size(204, 25);
            this.radLabelValidation.TabIndex = 1;
            this.radLabelValidation.Text = "* Fel lösenord. Försök igen.";
            this.radLabelValidation.Visible = false;
            // 
            // LogonDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 149);
            this.ControlBox = false;
            this.Controls.Add(this.radLabelValidation);
            this.Controls.Add(this.radMaskedEditBox1);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.radLabel1);
            this.Name = "LogonDialog";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inloggning";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMaskedEditBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelValidation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadMaskedEditBox radMaskedEditBox1;
        private Telerik.WinControls.UI.RadLabel radLabelValidation;
    }
}
