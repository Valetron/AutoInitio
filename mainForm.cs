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
        private List<string> nodesFolders = new List<string>();

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
        }

        private void buttonRegistry_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
        }

        private void buttonFolder_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Startup));

            if (files.Length == 0 || Path.GetFileName(files[0]) == "desktop.ini")
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

                updatePanel();
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            var button = (myButton)sender;

            if (button != null)
            {
                MessageBox.Show("Вы уверены, что хотите удалить " + Path.GetFileName(nodesFolders[button.index]) + " ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                File.Delete(nodesFolders[button.index]);
                nodesFolders.Remove(nodesFolders[button.index]);
                updatePanel();
            }
        }

        private void updatePanel()
        {
            panelMain.Controls.Clear();

            for (int i = 0; i < nodesFolders.Count; i++)
            {
                Label label = new Label();
                label.Location = new Point(10, 15 + (i * 30));
                label.Text = Path.GetFileName(nodesFolders[i]);

                myButton button = new myButton();
                button.Location = new Point(120, 10 + (i * 30));
                button.index = i;
                button.Text = "кнопка" + button.index;
                button.Click += button_Click;

                panelMain.Controls.Add(label);
                panelMain.Controls.Add(button);
            }
        }
    }
}
