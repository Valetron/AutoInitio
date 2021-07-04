using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace AutoInitio
{
    static class Program
    {
        //private static AutostartProtector autostartProtector;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);*/
            Thread formThread = new Thread(startMainForm);
            //Thread protectorThread = new Thread(startProtector);
            formThread.Start();
            //protectorThread.Start();
        }

        private static void startMainForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }

        private static void startProtector()
        {
            //Process.Start("cmd.exe");
            //AutostartProtector autostartProtector = new AutostartProtector();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new warnForm());
        }

    }
}
