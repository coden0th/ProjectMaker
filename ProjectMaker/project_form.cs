using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMaker
{
    public partial class project_form : Form
    {
        public static List<string> steps_list = new List<string>();
        public static string public_project_path;
        public static string project_name;
        public static string pp_project_path;
        public project_form()
        {
            InitializeComponent();
        }
        string project_path;
        private void project_form_Load(object sender, EventArgs e)
        {
            label1.Text = project_name;
            project_path = public_project_path;
            pp_project_path = project_path;
            this.Text = project_name;
            button1.Enabled = true;
            Create_List();
            Load_Description();
        }

        void Load_Description()
        {
            string desc = File.ReadAllText(project_path + @"\Goal.txt");
            richTextBox1.Text = desc;
        }
        void Create_List()
        {
            steps_list.Clear();
            string[] steps = File.ReadAllLines(project_path + @"\Steps\steps.txt");
            foreach (string step in steps)
            {
                steps_list.Add(step);
            }
            //steps_list.Sort();
            Update_List();
        }
        void Update_List()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (string step in steps_list.ToList())
            {
                completable_steps.publlic_step = step;
                completable_steps steps = new completable_steps();
                flowLayoutPanel1.Controls.Add(steps);
            }   
        }
        public static void step_renew(string step, string step_new)
        {
            steps_list.Remove(step);
            steps_list.Add(step_new);
            System.IO.File.WriteAllLines(pp_project_path + @"\Steps\steps.txt", steps_list);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(string step in steps_list)
            {
                if(step.Contains("-Unfinished"))
                {
                    button1.Text = "Complete All Steps First";
                    return;
                }
                else
                {
                    button1.Text = "All Steps Completed!";
                    this.Close();
                }
            }
        }

        private void project_form_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
