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
    public partial class Projects : UserControl
    {
        public static string name;
        public static string public_project_path;
        string project_path;
        public Projects()
        {
            InitializeComponent();
        }

        private void Projects_Load(object sender, EventArgs e)
        {
            project_path = public_project_path;
            button1.Text = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(project_path, "Project Path", MessageBoxButtons.OK, MessageBoxIcon.Information);
            project_form.public_project_path = project_path;
            project_form.project_name = button1.Text;
            project_form project_Form = new project_form();
            project_Form.Show();
        }
    }
}
