using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AutoInitio
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void notifyIconTray_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void buttonScheduler_Click(object sender, EventArgs e)
        {
            groupBoxMain.Text = "Планировщик заданий";
        }

        private void buttonRegistry_Click(object sender, EventArgs e)
        {
            groupBoxMain.Text = "Реестр";
        }

        private void buttonFolder_Click(object sender, EventArgs e)
        {
            groupBoxMain.Text = "Папка автозагрузки";
            //string[] files = Directory.GetFiles(@"C:\Users\%userprofile%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup");
            string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Startup));
            foreach (string file in files)
            {
                if (Path.GetFileName(file) != "desktop.ini" && files.Length > 1)
                {
                    label1.Text = Path.GetFileName(file);
                }
                else
                {
                    label1.Text = "Пусто";
                }
                
            }
        }
    }
}
