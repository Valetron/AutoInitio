using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AutoInitio
{
    class AutostartProtector
    {
        public AutostartProtector()
        {
            //Process.Start("cmd.exe");
            Process process = new Process();
            process.StartInfo.FileName = "schtasks.exe";
            process.StartInfo.Arguments = "/query /fo csv /nh";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            StreamReader reader = process.StandardOutput;
            string output = reader.ReadToEnd();
            /*Form form = new warnForm();
            form.Show();*/
            //process.WaitForExit();
        }

        private static void checkAutostartFolder()
        {

        }

        private static void checkSheduler()
        {

        }

        private static void checkRegistry()
        {

        }

        public static void Update()
        {
            checkAutostartFolder();
            checkSheduler();
            checkRegistry();
        }

    }
}
