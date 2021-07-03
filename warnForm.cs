using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoInitio
{
    public partial class warnForm : Form
    {
        private string output;

        public warnForm(string text)
        {
            InitializeComponent();
            output = text;
        }

        private void warnForm_Load(object sender, EventArgs e)
        {
            textBoxOutput.Text = output;
        }
    }
}
