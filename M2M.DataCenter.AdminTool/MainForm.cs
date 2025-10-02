using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Threading;
using System.Data.SqlClient;
using System.IO;
using Csla;
using System.Runtime.InteropServices;

namespace M2M.DataCenter.AdminTool
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);

        static readonly IntPtr HWND_TOP = new IntPtr(0);

        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        const UInt32 SWP_NOSIZE = 0x0001;

        const UInt32 SWP_NOMOVE = 0x0002;

        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;



        [DllImport("user32.dll")]

        [return: MarshalAs(UnmanagedType.Bool)]

        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);


        private SuperUser m_SuperUser;
        public MainForm()
        {
            ThemeResolutionService.ApplicationThemeName = "Office2010";
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
            dateTimePicker1.Value = DateTime.Today;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
#if(!DEBUG)            
            using (LogonDlg dlg = new LogonDlg())
            {
                if (dlg.ShowDialog(this) == DialogResult.Cancel)
                {
                    this.Close();
                    return;
                }
            }
#endif
            pageInstall.Select();
        }

        private void pageSecurity_Enter(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            m_SuperUser = new SuperUser();
            if (m_SuperUser.Load())
            {
                tbUser.Text = m_SuperUser.UserId;
                tbPassword.Text = m_SuperUser.Password;
                tbUser.ReadOnly = true;
                tbPassword.ReadOnly = true;
                btnSuperUser.Text = "Ta bort superanvändare";
                btnSuperUser.Tag = "Remove";
            }
            else
            {
                tbUser.ReadOnly = false;
                tbPassword.ReadOnly = false;
                btnSuperUser.Text = "Lägg till superanvändare";
                btnSuperUser.Tag = "Add";
            }
            this.UseWaitCursor = false;
        }

        private void btnSuperUser_Click(object sender, EventArgs e)
        {
            switch (btnSuperUser.Tag.ToString())
            {
                case "Add":
                    if (!String.IsNullOrEmpty(tbUser.Text) && !String.IsNullOrEmpty(tbUser.Text))
                    {
                        m_SuperUser.UserId = tbUser.Text;
                        m_SuperUser.Password = tbPassword.Text;
                        m_SuperUser.Save();
                        tbUser.ReadOnly = true;
                        tbPassword.ReadOnly = true;
                        btnSuperUser.Text = "Ta bort superanvändare";
                        btnSuperUser.Tag = "Remove";
                    }
                    break;
                case "Remove":
                    m_SuperUser.Remove();
                    tbUser.Text = "";
                    tbPassword.Text = "";
                    tbUser.ReadOnly = false;
                    tbPassword.ReadOnly = false;
                    btnSuperUser.Text = "Lägg till superanvändare";
                    btnSuperUser.Tag = "Add";
                    break;
            }
            
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "Laddar...";
            progressStatus.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            for (int i = 0; i < 100; i++)
            {
                progressStatus.Value1 = i;
            //    progressStatus.Text = item.Text + "...";
                radStatusStrip1.Refresh();
                Thread.Sleep(10);
            }
            progressStatus.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            lbStatus.Text = "Klar";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = tbDbPath.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                tbDbPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnCreateDb_Click(object sender, EventArgs e)
        {
            radProgressList.Clear();
            radErrorList.Clear();
            string fileName = @"Create database.sql";
            SqlConnectionStringBuilder connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.IntegratedSecurity = true;
            connStringBuilder.DataSource = @".\SQLEXPRESS";
            Dictionary<string, string> variables = new Dictionary<string, string>(4);
            variables.Add("DbName", tbDbName.Text);
            variables.Add("DbPath", tbDbPath.Text);

            using (
                TextWriter standard = new RadTextBoxWriter(radProgressList),
                error = new RadTextBoxWriter(radErrorList))
            {
                SqlHelper.StandardOutput = standard;
                SqlHelper.ErrorOutput = error;
                Thread th = new Thread(new ThreadStart(delegate
                {
                    SqlHelper.RunSqlScript(fileName, connStringBuilder, variables, (int)radSpinEditor1.Value);
                }));
                lbStatus.Text = "Skapar databas...";
                th.Start();
           
                progressStatus.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                while (th.IsAlive)
                {
                    progressStatus.Value1++;
                    radStatusStrip1.Refresh();
                    Thread.Sleep(100);
                }
                progressStatus.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
                lbStatus.Text = "Klar";
                th.Join();
                standard.Flush();
                error.Flush();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "Comparing states and events...";
            radTextBox1.Clear();
            Application.DoEvents();
            int count = 0;

            if (textBox1.Text != "")
            {
                count = CompareStatesEvents(textBox1.Text);
            }
            else
            {
                List<PlainMachineListItem> machines = M2MDataCenter.GetMachineList();
                foreach (PlainMachineListItem machine in machines)
                {
                    count += CompareStatesEvents(machine.MachineId);
                    Application.DoEvents();
                }
            }

            lbStatus.Text = String.Format("{0} mismatches found", count);
        }

        private int CompareStatesEvents(string machineId)
        {
            int count = 0;

            //StateList.Criteria criteria = new StateList.Criteria();
            //criteria.MachineId = machineId;
            //criteria.StartDate = new SmartDate(dateTimePicker1.Value);

            //StateList states = StateList.GetStateList(criteria);



            //SmartDate lastDate = new SmartDate();

            //foreach (StateListItem state in states)
            //{
            //    if (state.StateType == StateType.ArticleSwitch)
            //        continue;

            //    if (!lastDate.IsEmpty && lastDate.CompareTo(state.TimeStampOnSet) != 0)
            //        count += CheckEventList(machineId, StateType.NotApplicable, lastDate, state.TimeStampOnSet);

            //    lastDate = state.TimeStampOnReset;

            //    count += CheckEventList(machineId, state.StateType, state.TimeStampOnSet, state.TimeStampOnReset);


            //}

            return count;
        }

        private int CheckEventList(string machineId, StateType stateType, SmartDate start, SmartDate stop)
        {
            int count = 0;
            using (TextWriter error = new RadTextBoxWriter(radTextBox1))
            {
                EventList.Criteria criteria = new EventList.Criteria();
                criteria.MachineId = machineId;
                criteria.Categories = M2MDataCenter.GetAvailableCategories();
                criteria.Ascending = true;
                criteria.StartDate = start;
                criteria.EndDate = stop;
                EventList events = EventList.GetEventList(criteria);

                foreach (EventListItem item in events)
                {
                    if (item.TagType == TagType.Informational)
                        continue;

                    switch (stateType)
                    {
                        case StateType.Auto:
                            if (item.TagType != TagType.Auto)
                            {
                                error.WriteLine(String.Format("Auto: {0}, {1} --- {2}, {3}, {4}, {5}", item.MachineId, start.ToString("yyyy-MM-dd HH:mm:ss.fff"), stop.ToString("yyyy-MM-dd HH:mm:ss.fff"), item.EventRaised.ToString("yyyy-MM-dd HH:mm:ss.fff"), item.TimeForNextEvent.ToString("yyyy-MM-dd HH:mm:ss.fff"), item.TagType.ToString()));
                                count++;
                            }
                            break;
                        case StateType.NoProduction:
                            if (item.TagType != TagType.ProductionSwitch)
                            {
                                error.WriteLine(String.Format("Prod: {0}, {1} --- {2}, {3}, {4}, {5}", item.MachineId, start.ToString("yyyy-MM-dd HH:mm:ss.fff"), stop.ToString("yyyy-MM-dd HH:mm:ss.fff"), item.EventRaised.ToString("yyyy-MM-dd HH:mm:ss.fff"), item.TimeForNextEvent.ToString("yyyy-MM-dd HH:mm:ss.fff"), item.TagType.ToString()));
                                count++;
                            }
                            break;
                        case StateType.NotConnected:
                            if ((int)item.TagType < 90)
                            {
                                error.WriteLine(String.Format("Conn: {0}, {1} --- {2}, {3}, {4}, {5}", item.MachineId, start.ToString("yyyy-MM-dd HH:mm:ss.fff"), stop.ToString("yyyy-MM-dd HH:mm:ss.fff"), item.EventRaised.ToString("yyyy-MM-dd HH:mm:ss.fff"), item.TimeForNextEvent.ToString("yyyy-MM-dd HH:mm:ss.fff"), item.TagType.ToString()));
                                count++;
                            }
                            break;
                        case StateType.NotApplicable:
                            if ((int)item.TagType >= 90 || item.TagType == TagType.Auto || item.TagType == TagType.ProductionSwitch)
                            {
                                error.WriteLine(String.Format("Stop: {0}, {1} --- {2}, {3}, {4}, {5}", item.MachineId, start.ToString("yyyy-MM-dd HH:mm:ss.fff"), stop.ToString("yyyy-MM-dd HH:mm:ss.fff"), item.EventRaised.ToString("yyyy-MM-dd HH:mm:ss.fff"), item.TimeForNextEvent.ToString("yyyy-MM-dd HH:mm:ss.fff"), item.TagType.ToString()));
                                count++;
                            }
                            break;
                    }
                }

                error.Flush();
            }
            Application.DoEvents();
            return count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "Validating events...";
            radTextBox1.Clear();
            Application.DoEvents();
            int count = 0;

            if (textBox1.Text != "")
            {
                count = ValidatingEvents(textBox1.Text);
            }
            else
            {
                List<PlainMachineListItem> machines = M2MDataCenter.GetMachineList();
                foreach (PlainMachineListItem machine in machines)
                {
                    count += ValidatingEvents(machine.MachineId);
                    Application.DoEvents();
                }
            }
            
            lbStatus.Text = String.Format("{0} errors found", count);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "Validating states";
            radTextBox1.Clear();
            Application.DoEvents();
            int count = 0;

            if (textBox1.Text != "")
            {
                count = ValidatingStates(textBox1.Text);
            }
            else
            {
                List<PlainMachineListItem> machines = M2MDataCenter.GetMachineList();
                foreach (PlainMachineListItem machine in machines)
                {
                    count += ValidatingStates(machine.MachineId);
                    Application.DoEvents();
                }
            }
            
            lbStatus.Text = String.Format("{0} errors found", count);
        }

        private int ValidatingEvents(string machineId)
        {
            int count = 0;

            using (TextWriter error = new RadTextBoxWriter(radTextBox1))
            {
                EventList.Criteria criteria = new EventList.Criteria();
                criteria.MachineId = machineId;
                criteria.StartDate = new SmartDate(dateTimePicker1.Value);
                criteria.Categories = M2MDataCenter.GetAvailableCategories();
                criteria.Ascending = true;
                EventList events = EventList.GetEventList(criteria);

                SmartDate lastDate = new SmartDate();

                foreach (EventListItem item in events)
                {
                    if (item.TagType == TagType.Informational)
                        continue;

                    if (!lastDate.IsEmpty)
                    {
                        TimeSpan diff = item.EventRaised.Date.Subtract(lastDate.Date);
                        if (diff.Ticks != 0)
                        {
                            error.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}", item.MachineId, item.EventRaised.ToString("yyyy-MM-dd HH:mm:ss.fff"), item.TimeForNextEvent.ToString("yyyy-MM-dd HH:mm:ss.fff"), item.TagType.ToString(), diff.TotalMilliseconds));
                            count++;
                        }
                    }

                    lastDate = item.TimeForNextEvent;
                }

                error.Flush();
            }
            return count;
        }

        private int ValidatingStates(string machineId)
        {
            int count = 0;
            //using (TextWriter error = new RadTextBoxWriter(radTextBox1))
            //{
            //    StateList.Criteria criteria = new StateList.Criteria();
            //    criteria.MachineId = machineId;
            //    criteria.StartDate = new SmartDate(dateTimePicker1.Value);
            //    StateList states = StateList.GetStateList(criteria);

            //    SmartDate lastDate = new SmartDate();

            //    foreach (StateListItem item in states)
            //    {
            //        if (item.StateType == StateType.ArticleSwitch)
            //            continue;

            //        if (!lastDate.IsEmpty)
            //        {
            //            TimeSpan diff = item.TimeStampOnSet.Date.Subtract(lastDate.Date);
            //            if (diff.Ticks < 0)
            //            {
            //                error.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}", item.MachineId, item.TimeStampOnSet.ToString("yyyy-MM-dd HH:mm:ss.fff"), item.TimeStampOnReset.ToString("yyyy-MM-dd HH:mm:ss.fff"), item.StateType.ToString(), -diff.TotalMilliseconds));
            //                count++;
            //            }
            //        }

            //        lastDate = item.TimeStampOnReset;
            //    }

            //    error.Flush();

            //}
            return count;
        }
    }
}
