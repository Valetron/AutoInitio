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
using System.Diagnostics;

namespace AutoInitio
{
    public partial class mainForm : Form
    {
        private List<string> nodesFolders = new List<string>();
        private List<string[]> nodesScheduler = new List<string[]>();

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
            panelMain.Controls.Clear();

            Process process = new Process();
            process.StartInfo.FileName = "schtasks.exe";
            process.StartInfo.Arguments = "/query /fo csv /nh";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            StreamReader reader = process.StandardOutput;

            string[] output = reader.ReadToEnd().Split('\n');

            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            foreach (string str in output)
            {
                nodesScheduler.Add(str.Split(','));
                /*if (str.Replace("\"", "").Split(',')[2] != "Disabled")
                {
                    nodesScheduler.Add(str.Replace("\"", "").Split(','));
                }*/
            }
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            if (output.Length != 0) // исправить ошибку, но какую?
            {
                for (int i = 0; i < nodesScheduler.Count - 1; i++)
                {
                    Label labelTaskName = new Label();
                    labelTaskName.Location = new Point(10, 15 + (i * 30));
                    labelTaskName.AutoSize = false;
                    labelTaskName.BorderStyle = BorderStyle.None;
                    labelTaskName.AutoEllipsis = true;
                    labelTaskName.Text = Path.GetFileName(nodesScheduler[i][0]);
                    panelMain.Controls.Add(labelTaskName);

                    // проблема с выходом за границы
                    /*Label labelTaskTime = new Label();
                    labelTaskTime.Location = new Point(90, 15 + (i * 30));
                    labelTaskTime.AutoSize = false;
                    labelTaskTime.BorderStyle = BorderStyle.None;
                    labelTaskTime.AutoEllipsis = true;
                    labelTaskTime.Text = Path.GetFileName(nodesScheduler[i][1]);
                    panelMain.Controls.Add(labelTaskTime);*/

                    // можно сделать в обе стороны работу
                    /*Label labelTaskStatus = new Label();
                    labelTaskStatus.Location = new Point(10, 15 + (i * 30));
                    labelTaskStatus.AutoSize = false;
                    labelTaskStatus.BorderStyle = BorderStyle.None;
                    labelTaskStatus.AutoEllipsis = true;
                    labelTaskStatus.Text = Path.GetFileName(nodesScheduler[i][3]);
                    panelMain.Controls.Add(labelTaskStatus);*/
                }
            }
            else // невозможно, но вдруг 
            {
                Label label = new Label();
                label.Location = new Point(0, 0);
                label.Dock = DockStyle.Fill;
                label.AutoSize = false;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Text = "Задачи не запланированы";
                panelMain.Controls.Add(label);
            }

            process.WaitForExit();
        }

        private void buttonRegistry_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
        }

        private void buttonFolder_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();

            string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Startup));

            if ((files.Length == 1 && Path.GetFileName(files[0]) == "desktop.ini") || files.Length == 0)
            {
                Label label = new Label();
                label.Location = new Point(0, 0);
                label.Dock = DockStyle.Fill;
                label.AutoSize = false;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Text = "Папка пуста";
                panelMain.Controls.Add(label);
            }
            else
            {
                foreach (string file in files)
                {
                    if (Path.GetFileName(file) != "desktop.ini")
                    {
                        nodesFolders.Add(file);
                    }
                }
                updateFolders();
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            var button = (myButton)sender;

            if (button != null)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить " + Path.GetFileName(nodesFolders[button.index]) + " ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                File.Delete(nodesFolders[button.index]);
                nodesFolders.Remove(nodesFolders[button.index]);
                updateFolders();
            }
        }

        private void updateFolders()
        {
            panelMain.Controls.Clear();

            for (int i = 0; i < nodesFolders.Count; i++)
            {
                Label label = new Label();
                label.Location = new Point(10, 15 + (i * 30));
                label.AutoSize = true;
                label.Text = Path.GetFileName(nodesFolders[i]);

                myButton button = new myButton();
                button.Location = new Point(410, 10 + (i * 30));
                button.index = i;
                button.Text = "Удалить";
                button.Click += button_Click;

                panelMain.Controls.Add(label);
                panelMain.Controls.Add(button);
            }
        }

        private void buttonFolderOpen_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Startup));
        }

        private void buttonSchedulerOpen_Click(object sender, EventArgs e)
        {
            Process.Start("taskschd.msc");
        }

        private void buttonRegistryOpen_Click(object sender, EventArgs e)
        {
            Process.Start("regedit.exe");
        }

    }
}
