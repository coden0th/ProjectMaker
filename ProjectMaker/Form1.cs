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

namespace ProjectMaker
{
    public partial class Form1 : Form
    {
        string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public Form1()
        {
            InitializeComponent();
        }
        public static string project_path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\codenoth\Planmaker\";
        public static List<string> steps_list = new List<string>();
        private void add_step_button_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && !steps_list.Contains(textBox2.Text))
            {
                Steps.name = textBox2.Text;
                steps_list.Add(textBox2.Text);
                Steps steps = new Steps();
                textBox2.Clear();
                flowLayoutPanel1.Controls.Add(steps);
            }
        }

        public static void Step_Remove(string name)
        {
            steps_list.Remove(name);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "" && steps_list.Contains(textBox2.Text))
            {
                add_step_button.Enabled = false;
            }
            else
            {
                add_step_button.Enabled = true;
            }
        }

        private void create_pr_Click(object sender, EventArgs e)
        {
            mainpanel.Hide();
            create_pr_panel.Show();
            my_projects_panel.Hide();
            create_pr_panel.Dock = DockStyle.Fill;
            add_step_button.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            mainpanel.Show();
            create_pr_panel.Hide();
            my_projects_panel.Hide();
            mainpanel.Dock = DockStyle.Fill;
            steps_list.Clear();
            Load_Path();
        }

        void Load_Path()
        {
            if(File.Exists($@"{documents}\codenoth\Planmaker\settings.txt"))
            {
                project_path = File.ReadAllText($@"{documents}\codenoth\Planmaker\settings.txt");
               // MessageBox.Show(project_path);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(project_path);
            Settings settings = new Settings();
            settings.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = $@"{project_path}\{textBox1.Text}";
            if (Directory.Exists(path))
            {
                MessageBox.Show("A project with this name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Create Project Folder
                button3.Enabled = false;
                Directory.CreateDirectory($@"{project_path}\{textBox1.Text}\Steps\");
                File.Create($@"{project_path}\{textBox1.Text}\Steps\Steps.txt").Close();
                foreach (string step in steps_list)
                {
                    //write steps to Steps.txt
                    File.AppendAllText($@"{project_path}\{textBox1.Text}\Steps\Steps.txt", step + "-Unfinished" + Environment.NewLine);
                }
                File.Create($@"{project_path}\{textBox1.Text}\Goal.txt").Close();
                File.WriteAllText($@"{project_path}\{textBox1.Text}\Goal.txt", richTextBox1.Text);
                textBox1.Clear();
                richTextBox1.Clear();
                flowLayoutPanel1.Controls.Clear();
                textBox2.Clear();
                steps_list.Clear();
                MessageBox.Show("Project Created Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button3.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                button3.Enabled = false;
                richTextBox1.Enabled = false;
                label3.Text = "Project name cannot be empty.";
               
            }
            else if (Directory.Exists($@"{project_path}\{textBox1.Text}\"))
            {
                button3.Enabled = false;
                richTextBox1.Enabled = false;
                label3.Text = "A project with this name already exists. Please choose a different name.";
            }
            else
            {
                button3.Enabled = true;
                richTextBox1.Enabled = true;
                label3.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainpanel.Hide();
            flowLayoutPanel2.Controls.Clear();
            create_pr_panel.Hide();
            my_projects_panel.Show();
            my_projects_panel.Dock = DockStyle.Fill;

            foreach (string dir in Directory.GetDirectories(project_path))
            {
                Projects.name = new DirectoryInfo(dir).Name;
                Projects.public_project_path = dir;
                Projects projects = new Projects();
                flowLayoutPanel2.Controls.Add(projects);
            }
        }

        public static void settings_Project_Path(string path)
        {
            project_path = path;
        }
    }
}
