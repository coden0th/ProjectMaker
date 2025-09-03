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
    public partial class completable_steps : UserControl
    {
        public completable_steps()
        {
            InitializeComponent();
        }
        public static string publlic_step;
        string step_new;
        string step;
        private void completable_steps_Load(object sender, EventArgs e)
        {
            step = publlic_step;
            checkBox1.Text = step.Replace("-Unfinished", "").Replace("-finished", "");
            if (step.Contains("-Unfinished"))
            {
                checkBox1.Checked = false;
                this.BackColor = Color.White;
            }
            else if(step.Contains("-finished"))
            {
                checkBox1.Checked = true;
                this.BackColor = Color.LightGreen;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                step_new = step.Replace("-Unfinished", "-finished");
                project_form.step_renew(step, step_new);
                this.BackColor = Color.LightGreen;
            }
            else if(checkBox1.Checked == false)
            {
                step_new = step.Replace("-finished", "-Unfinished");
                project_form.step_renew(step, step_new);
                this.BackColor = Color.White;
            }
        }
    }
}
