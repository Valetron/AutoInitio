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
using Microsoft.Win32;

namespace AutoInitio
{
    public partial class mainForm : Form
    {
        private List<string> nodesFolders = new List<string>();
        private string[][] ns;

        public mainForm()
        {
            InitializeComponent();
        }

        private void notifyIconTray_MouseClick(object sender, MouseEventArgs e)
        {
            /*if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Activate();
            }
            *//*else if (this.WindowState == FormWindowState.Normal && !this.Ac)
            {
                this.Activate();
            }*//*
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }*/
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void buttonScheduler_Click(object sender, EventArgs e)
        {
            schedulerUpdate();
        }

        private void schedulerUpdate()
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
            ns = new string[output.Length][];

            for (int i = 0; i < ns.Length; i++)
            {
                ns[i] = output[i].Replace("\"", "").Split(',');
            }

            if (output.Length != 0)
            {
                for (int i = 0; i < ns.Length - 1; i++)
                {
                    Label labelTaskName = new Label();
                    labelTaskName.Location = new Point(10, 15 + (i * 30));
                    labelTaskName.AutoSize = false;
                    labelTaskName.BorderStyle = BorderStyle.None;
                    labelTaskName.AutoEllipsis = true;
                    labelTaskName.Text += ns[i][0];
                    panelMain.Controls.Add(labelTaskName);

                    Label labelTaskTime = new Label();
                    labelTaskTime.Location = new Point(120, 15 + (i * 30));
                    labelTaskTime.AutoSize = true;
                    labelTaskTime.BorderStyle = BorderStyle.None;
                    labelTaskTime.AutoEllipsis = true;
                    labelTaskTime.Text += ns[i][1];
                    panelMain.Controls.Add(labelTaskTime);

                    Label labelTaskStatus = new Label();
                    labelTaskStatus.Location = new Point(240, 15 + (i * 30));
                    labelTaskStatus.AutoSize = true;
                    labelTaskStatus.BorderStyle = BorderStyle.None;
                    labelTaskStatus.AutoEllipsis = true;
                    labelTaskStatus.Text += ns[i][2];
                    panelMain.Controls.Add(labelTaskStatus);

                    myButton buttonStopStart = new myButton();
                    buttonStopStart.Location = new Point(300, 10 + (i * 30));
                    buttonStopStart.index = i;
                    buttonStopStart.Text = ns[i][2].StartsWith("R") ? "Отключить" : "Включить";
                    buttonStopStart.Click += buttonSchedulerStopStart_Click;
                    panelMain.Controls.Add(buttonStopStart);

                    if (ns[i][2].StartsWith("D"))
                    {
                        myButton buttonRemove = new myButton();
                        buttonRemove.Location = new Point(390, 10 + (i * 30));
                        buttonRemove.index = i;
                        buttonRemove.Text = "Удалить";
                        buttonRemove.Click += buttonSchedulerDelete_Click;
                        panelMain.Controls.Add(buttonRemove);
                    }
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
            //Array.Clear(ns, 0, ns.Length);
            process.WaitForExit();
        }

        private void buttonRegistry_Click(object sender, EventArgs e)
        {
            registryUpdate();
        }

        private void registryUpdate()
        {
            panelMain.Controls.Clear();

            RegistryKey rkCUR = Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("Run");
            string[] keys = rkCUR.GetSubKeyNames();
            string[] values = rkCUR.GetValueNames();
            textBox1.Text += rkCUR + "\r\n"; // HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
            textBox1.Text += "Keys len " + keys.Length + "\r\n";
            textBox1.Text += "Values len " + values.Length + "\r\n";
            for (int i = 0; i < keys.Length; i++)
            {
                textBox1.Text += keys[i] + "\r\n";
            }
            for (int i = 0; i < values.Length; i++)
            {
                textBox1.Text += values[i] + "\r\n";
            }

            RegistryKey rkCURO = Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("RunOnce");
            RegistryKey rkLM = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("Run");
            RegistryKey rkLMO = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("RunOnce");
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

        private void buttonF_Click(object sender, EventArgs e)
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

        private void buttonSchedulerStopStart_Click(object sender, EventArgs e)
        {
            var button = (myButton)sender;

            if (button != null)
            {
                if (ns[button.index][2].StartsWith("D"))
                {
                    var result = MessageBox.Show("Вы уверены, что хотите возобновить " + ns[button.index][0] + " ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    Process process = new Process();
                    process.StartInfo.FileName = "schtasks.exe";
                    process.StartInfo.Arguments = "/run /tn " + ns[button.index][0];
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    process.StartInfo.FileName = "schtasks.exe";
                    process.StartInfo.Arguments = "/change /tn " + ns[button.index][0] + " /enable";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    //process.WaitForExit();
                }
                else if (ns[button.index][2].StartsWith("R"))
                {
                    var result = MessageBox.Show("Вы уверены, что хотите остановить " + ns[button.index][0] + " ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                    if (result == DialogResult.No)
                    {
                        return;
                    }

                    Process process = new Process();
                    process.StartInfo.FileName = "schtasks.exe";
                    process.StartInfo.Arguments = "/end /tn " + ns[button.index][0];
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();

                    process.StartInfo.FileName = "schtasks.exe";
                    process.StartInfo.Arguments = "/change /tn " + ns[button.index][0] + " /disable";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                }
                /*File.Delete(nodesFolders[button.index]);
                nodesFolders.Remove(nodesFolders[button.index]);
                updateFolders();*/
                schedulerUpdate();
            }
        }

        private void buttonSchedulerDelete_Click(object sender, EventArgs e)
        {
            var button = (myButton)sender;

            if (button != null)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить " + ns[button.index][0] + " ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.No)
                {
                    return;
                }

                Process process = new Process();
                process.StartInfo.FileName = "schtasks.exe";
                process.StartInfo.Arguments = "/delete /tn " + ns[button.index][0] + " /f";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                schedulerUpdate();
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
                button.Click += buttonF_Click;

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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBox1.Text += e.Node.Text;
        }
    }
}
