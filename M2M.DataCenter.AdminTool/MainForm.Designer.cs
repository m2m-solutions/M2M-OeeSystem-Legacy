namespace M2M.DataCenter.AdminTool
{
    partial class MainForm
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
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.pageInstall = new Telerik.WinControls.UI.RadPageViewPage();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.radSpinEditor1 = new Telerik.WinControls.UI.RadSpinEditor();
            this.radErrorList = new Telerik.WinControls.UI.RadTextBox();
            this.radProgressList = new Telerik.WinControls.UI.RadTextBox();
            this.btnCreateDb = new Telerik.WinControls.UI.RadButton();
            this.btnBrowse = new Telerik.WinControls.UI.RadButton();
            this.tbDbPath = new Telerik.WinControls.UI.RadTextBox();
            this.tbDbName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.pageDatabase = new Telerik.WinControls.UI.RadPageViewPage();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.tbPassword = new Telerik.WinControls.UI.RadTextBox();
            this.btnSuperUser = new Telerik.WinControls.UI.RadButton();
            this.tbUser = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.pageDebug = new Telerik.WinControls.UI.RadPageViewPage();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.pageMiscellaneous = new Telerik.WinControls.UI.RadPageViewPage();
            this.office2010Theme1 = new Telerik.WinControls.Themes.Office2010BlackTheme();
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.lbStatus = new Telerik.WinControls.UI.RadLabelElement();
            this.progressStatus = new Telerik.WinControls.UI.RadProgressBarElement();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.pageInstall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSpinEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radErrorList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateDb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDbPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDbName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            this.pageDatabase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSuperUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.pageDebug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.pageInstall);
            this.radPageView1.Controls.Add(this.pageDatabase);
            this.radPageView1.Controls.Add(this.pageDebug);
            this.radPageView1.Controls.Add(this.pageMiscellaneous);
            this.radPageView1.Location = new System.Drawing.Point(0, 1);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.pageInstall;
            this.radPageView1.Size = new System.Drawing.Size(726, 447);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.Text = "radPageView1";
            // 
            // pageInstall
            // 
            this.pageInstall.Controls.Add(this.radGroupBox3);
            this.pageInstall.Location = new System.Drawing.Point(10, 37);
            this.pageInstall.Name = "pageInstall";
            this.pageInstall.Size = new System.Drawing.Size(705, 399);
            this.pageInstall.Text = "Installation";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.radSpinEditor1);
            this.radGroupBox3.Controls.Add(this.radErrorList);
            this.radGroupBox3.Controls.Add(this.radProgressList);
            this.radGroupBox3.Controls.Add(this.btnCreateDb);
            this.radGroupBox3.Controls.Add(this.btnBrowse);
            this.radGroupBox3.Controls.Add(this.tbDbPath);
            this.radGroupBox3.Controls.Add(this.tbDbName);
            this.radGroupBox3.Controls.Add(this.radLabel4);
            this.radGroupBox3.Controls.Add(this.radLabel3);
            this.radGroupBox3.FooterImageIndex = -1;
            this.radGroupBox3.FooterImageKey = "";
            this.radGroupBox3.HeaderImageIndex = -1;
            this.radGroupBox3.HeaderImageKey = "";
            this.radGroupBox3.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.radGroupBox3.HeaderText = "Databas";
            this.radGroupBox3.Location = new System.Drawing.Point(25, 15);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            // 
            // 
            // 
            this.radGroupBox3.RootElement.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.radGroupBox3.Size = new System.Drawing.Size(657, 378);
            this.radGroupBox3.TabIndex = 12;
            this.radGroupBox3.Text = "Databas";
            // 
            // radSpinEditor1
            // 
            this.radSpinEditor1.Location = new System.Drawing.Point(311, 11);
            this.radSpinEditor1.Name = "radSpinEditor1";
            // 
            // 
            // 
            this.radSpinEditor1.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.radSpinEditor1.ShowBorder = true;
            this.radSpinEditor1.Size = new System.Drawing.Size(100, 20);
            this.radSpinEditor1.TabIndex = 14;
            this.radSpinEditor1.TabStop = false;
            // 
            // radErrorList
            // 
            this.radErrorList.Location = new System.Drawing.Point(23, 261);
            this.radErrorList.Multiline = true;
            this.radErrorList.Name = "radErrorList";
            // 
            // 
            // 
            this.radErrorList.RootElement.StretchVertically = true;
            this.radErrorList.Size = new System.Drawing.Size(622, 104);
            this.radErrorList.TabIndex = 13;
            this.radErrorList.TabStop = false;
            // 
            // radProgressList
            // 
            this.radProgressList.Location = new System.Drawing.Point(22, 73);
            this.radProgressList.Multiline = true;
            this.radProgressList.Name = "radProgressList";
            // 
            // 
            // 
            this.radProgressList.RootElement.StretchVertically = true;
            this.radProgressList.Size = new System.Drawing.Size(622, 182);
            this.radProgressList.TabIndex = 12;
            this.radProgressList.TabStop = false;
            // 
            // btnCreateDb
            // 
            this.btnCreateDb.Location = new System.Drawing.Point(562, 37);
            this.btnCreateDb.Name = "btnCreateDb";
            this.btnCreateDb.Size = new System.Drawing.Size(83, 20);
            this.btnCreateDb.TabIndex = 11;
            this.btnCreateDb.Text = "Skapa databas";
            this.btnCreateDb.Click += new System.EventHandler(this.btnCreateDb_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(532, 37);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(20, 20);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "...";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tbDbPath
            // 
            this.tbDbPath.Location = new System.Drawing.Point(155, 37);
            this.tbDbPath.Name = "tbDbPath";
            this.tbDbPath.ReadOnly = true;
            this.tbDbPath.Size = new System.Drawing.Size(370, 20);
            this.tbDbPath.TabIndex = 8;
            this.tbDbPath.TabStop = false;
            this.tbDbPath.Text = "C:\\Program Files\\Microsoft SQL Server\\MSSQL.1\\MSSQL\\Data";
            // 
            // tbDbName
            // 
            this.tbDbName.Location = new System.Drawing.Point(22, 37);
            this.tbDbName.Name = "tbDbName";
            this.tbDbName.Size = new System.Drawing.Size(126, 20);
            this.tbDbName.TabIndex = 0;
            this.tbDbName.TabStop = false;
            this.tbDbName.Text = "M2M.DataCenter";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(154, 20);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(45, 18);
            this.radLabel4.TabIndex = 9;
            this.radLabel4.Text = "Sökväg:";
            this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(21, 20);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(39, 18);
            this.radLabel3.TabIndex = 7;
            this.radLabel3.Text = "Namn:";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pageDatabase
            // 
            this.pageDatabase.Controls.Add(this.radGroupBox2);
            this.pageDatabase.Controls.Add(this.radGroupBox1);
            this.pageDatabase.Description = null;
            this.pageDatabase.Location = new System.Drawing.Point(10, 37);
            this.pageDatabase.Name = "pageDatabase";
            this.pageDatabase.Size = new System.Drawing.Size(705, 399);
            this.pageDatabase.Text = "Databas";
            this.pageDatabase.Title = "Säkerhet";
            this.pageDatabase.Enter += new System.EventHandler(this.pageSecurity_Enter);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.FooterImageIndex = -1;
            this.radGroupBox2.FooterImageKey = "";
            this.radGroupBox2.HeaderImageIndex = -1;
            this.radGroupBox2.HeaderImageKey = "";
            this.radGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.radGroupBox2.HeaderText = "S";
            this.radGroupBox2.Location = new System.Drawing.Point(27, 17);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            // 
            // 
            // 
            this.radGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.radGroupBox2.Size = new System.Drawing.Size(657, 291);
            this.radGroupBox2.TabIndex = 11;
            this.radGroupBox2.Text = "S";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.tbPassword);
            this.radGroupBox1.Controls.Add(this.btnSuperUser);
            this.radGroupBox1.Controls.Add(this.tbUser);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.FooterImageIndex = -1;
            this.radGroupBox1.FooterImageKey = "";
            this.radGroupBox1.HeaderImageIndex = -1;
            this.radGroupBox1.HeaderImageKey = "";
            this.radGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.radGroupBox1.HeaderText = "Superanvändare";
            this.radGroupBox1.Location = new System.Drawing.Point(27, 314);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            // 
            // 
            // 
            this.radGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.radGroupBox1.Size = new System.Drawing.Size(657, 70);
            this.radGroupBox1.TabIndex = 9;
            this.radGroupBox1.Text = "Superanvändare";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(27, 32);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(62, 18);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "Användare:";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(310, 30);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.NullText = "<Lösenord>";
            this.tbPassword.ReadOnly = true;
            this.tbPassword.Size = new System.Drawing.Size(152, 20);
            this.tbPassword.TabIndex = 7;
            this.tbPassword.TabStop = false;
            // 
            // btnSuperUser
            // 
            this.btnSuperUser.Location = new System.Drawing.Point(479, 28);
            this.btnSuperUser.Name = "btnSuperUser";
            this.btnSuperUser.Size = new System.Drawing.Size(144, 24);
            this.btnSuperUser.TabIndex = 0;
            this.btnSuperUser.Text = "Skapa superanvändare";
            this.btnSuperUser.Click += new System.EventHandler(this.btnSuperUser_Click);
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(92, 30);
            this.tbUser.Name = "tbUser";
            this.tbUser.NullText = "<Användarnamn>";
            this.tbUser.ReadOnly = true;
            this.tbUser.Size = new System.Drawing.Size(152, 20);
            this.tbUser.TabIndex = 5;
            this.tbUser.TabStop = false;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(250, 32);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(55, 18);
            this.radLabel2.TabIndex = 8;
            this.radLabel2.Text = "Lösenord:";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pageDebug
            // 
            this.pageDebug.Controls.Add(this.dateTimePicker1);
            this.pageDebug.Controls.Add(this.button3);
            this.pageDebug.Controls.Add(this.button2);
            this.pageDebug.Controls.Add(this.textBox1);
            this.pageDebug.Controls.Add(this.button1);
            this.pageDebug.Controls.Add(this.radTextBox1);
            this.pageDebug.Location = new System.Drawing.Point(10, 37);
            this.pageDebug.Name = "pageDebug";
            this.pageDebug.Size = new System.Drawing.Size(705, 399);
            this.pageDebug.Text = "Felsök";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Location = new System.Drawing.Point(4, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(131, 20);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(460, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "States";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(366, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Events";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(150, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.Text = "1012";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Compare";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radTextBox1
            // 
            this.radTextBox1.Location = new System.Drawing.Point(0, 35);
            this.radTextBox1.Multiline = true;
            this.radTextBox1.Name = "radTextBox1";
            // 
            // 
            // 
            this.radTextBox1.RootElement.StretchVertically = true;
            this.radTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.radTextBox1.Size = new System.Drawing.Size(705, 364);
            this.radTextBox1.TabIndex = 13;
            this.radTextBox1.TabStop = false;
            // 
            // pageMiscellaneous
            // 
            this.pageMiscellaneous.Description = null;
            this.pageMiscellaneous.Location = new System.Drawing.Point(10, 37);
            this.pageMiscellaneous.Name = "pageMiscellaneous";
            this.pageMiscellaneous.Size = new System.Drawing.Size(705, 341);
            this.pageMiscellaneous.Text = "Övrigt";
            this.pageMiscellaneous.Title = "Övrigt";
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.AutoSize = true;
            this.radStatusStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.lbStatus,
            this.progressStatus});
            this.radStatusStrip1.LayoutStyle = Telerik.WinControls.UI.RadStatusBarLayoutStyle.Stack;
            this.radStatusStrip1.Location = new System.Drawing.Point(0, 450);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.Size = new System.Drawing.Size(724, 26);
            this.radStatusStrip1.SizingGrip = false;
            this.radStatusStrip1.TabIndex = 2;
            this.radStatusStrip1.Text = "radStatusStrip1";
            // 
            // lbStatus
            // 
            this.lbStatus.AccessibleDescription = "Klar";
            this.lbStatus.AccessibleName = "Klar";
            this.lbStatus.Margin = new System.Windows.Forms.Padding(1);
            this.lbStatus.Name = "lbStatus";
            this.radStatusStrip1.SetSpring(this.lbStatus, false);
            this.lbStatus.Text = "Klar";
            this.lbStatus.TextWrap = true;
            this.lbStatus.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // progressStatus
            // 
            this.progressStatus.Alignment = System.Drawing.ContentAlignment.TopCenter;
            this.progressStatus.Hatch = false;
            this.progressStatus.Margin = new System.Windows.Forms.Padding(1);
            this.progressStatus.Name = "progressStatus";
            this.progressStatus.SeparatorColor1 = System.Drawing.Color.White;
            this.progressStatus.SeparatorColor2 = System.Drawing.Color.White;
            this.progressStatus.SeparatorColor3 = System.Drawing.Color.White;
            this.progressStatus.SeparatorColor4 = System.Drawing.Color.White;
            this.progressStatus.SeparatorGradientAngle = 0;
            this.progressStatus.SeparatorGradientPercentage1 = 0.4F;
            this.progressStatus.SeparatorGradientPercentage2 = 0.6F;
            this.progressStatus.SeparatorNumberOfColors = 2;
            this.progressStatus.ShowProgressIndicators = false;
            this.radStatusStrip1.SetSpring(this.progressStatus, false);
            this.progressStatus.StepWidth = 14;
            this.progressStatus.SweepAngle = 90;
            this.progressStatus.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Ange sökväg till SQL Server\'s datakatalog";
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 476);
            this.Controls.Add(this.radStatusStrip1);
            this.Controls.Add(this.radPageView1);
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "M2M DataCenter - Adminstrationsverktyg";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.pageInstall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            this.radGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSpinEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radErrorList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateDb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDbPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDbName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            this.pageDatabase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSuperUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.pageDebug.ResumeLayout(false);
            this.pageDebug.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage pageDatabase;
        private Telerik.WinControls.UI.RadPageViewPage pageMiscellaneous;
        private Telerik.WinControls.UI.RadButton btnSuperUser;
        private Telerik.WinControls.UI.RadTextBox tbPassword;
        private Telerik.WinControls.UI.RadTextBox tbUser;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.Themes.Office2010BlackTheme office2010Theme1;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private Telerik.WinControls.UI.RadLabelElement lbStatus;
        private Telerik.WinControls.UI.RadProgressBarElement progressStatus;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadPageViewPage pageInstall;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadPageViewPage pageDebug;
        private Telerik.WinControls.UI.RadTextBox tbDbName;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox tbDbPath;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadButton btnBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private Telerik.WinControls.UI.RadButton btnCreateDb;
        private Telerik.WinControls.UI.RadTextBox radProgressList;
        private Telerik.WinControls.UI.RadTextBox radErrorList;
        private Telerik.WinControls.UI.RadSpinEditor radSpinEditor1;
        private System.Windows.Forms.Button button1;
        private Telerik.WinControls.UI.RadTextBox radTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}
