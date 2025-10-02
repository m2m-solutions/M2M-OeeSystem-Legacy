using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using M2M.DataCenter.Panel.FormsUI.BusinessObjects;

namespace M2M.DataCenter.Panel.FormsUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(ApplicationSettings.Language);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(ApplicationSettings.Language);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new Form1());
        }
    }
}
