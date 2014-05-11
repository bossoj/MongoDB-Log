using System;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace BJ.MongoDB.ClientUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            Application.Run(new frmLogs());
        }
    }
}