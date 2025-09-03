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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            //Open browser dialog
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
            }
        }
        string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Text = $"Projects will be saved at: \n {textBox1.Text}\\codenoth\\Planmaker\\";
            Form1.settings_Project_Path($@"{textBox1.Text}\codenoth\Planmaker\");
            if(File.Exists($@"{documents}\codenoth\Planmaker\settings.txt"))
            {
                File.Delete($@"{documents}\codenoth\Planmaker\settings.txt");
            }
            else
            {
                File.Create($@"{documents}\codenoth\Planmaker\settings.txt").Close();
                File.WriteAllText($@"{documents}\codenoth\Planmaker\settings.txt", $@"{textBox1.Text}\codenoth\Planmaker\");
            } 
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            label3.Text = $"Current Project Path: {Form1.project_path}";
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show(Form1.project_path);
            Directory.CreateDirectory($@"{Form1.project_path}");
        }
    }
}
