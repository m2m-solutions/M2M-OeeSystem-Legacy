namespace M2M.DataCenter.AdminTool
{
    partial class LogonDlg
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
            this.btnLogon = new Telerik.WinControls.UI.RadButton();
            this.tbUser = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.tbPassword = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogon
            // 
            this.btnLogon.Location = new System.Drawing.Point(114, 90);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Size = new System.Drawing.Size(130, 24);
            this.btnLogon.TabIndex = 0;
            this.btnLogon.Text = "Logga in";
            this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(92, 22);
            this.tbUser.Name = "tbUser";
            this.tbUser.NullText = "<Användarnamn>";
            this.tbUser.Size = new System.Drawing.Size(152, 20);
            this.tbUser.TabIndex = 1;
            this.tbUser.TabStop = false;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(27, 24);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(62, 18);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "Användare:";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(92, 55);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.NullText = "<Lösenord>";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(152, 20);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.TabStop = false;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(27, 57);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(55, 18);
            this.radLabel2.TabIndex = 4;
            this.radLabel2.Text = "Lösenord:";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // LogonDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 129);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btnLogon);
            this.Name = "LogonDlg";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Inloggning";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.btnLogon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnLogon;
        private Telerik.WinControls.UI.RadTextBox tbUser;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox tbPassword;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}
