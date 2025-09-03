using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMaker
{
    public partial class Steps : UserControl
    {
        public static string name;
        public Steps()
        {
            InitializeComponent();
        }

        private void Steps_Load(object sender, EventArgs e)
        {
            label1.Text = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.Step_Remove(label1.Text);
            this.Hide();
        }
    }
}
