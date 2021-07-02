using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AutoInitio
{
    static class AutostartProtector
    {
        static AutostartProtector()
        {
            Process.Start("cmd.exe");
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
