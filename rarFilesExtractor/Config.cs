using System;
using System.Windows.Forms;

namespace rarFilesExtractor
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = folderBrowserDialog1.SelectedPath + "\\*" + textBox1.Text + "*.zip";
            button2.Enabled = folderBrowserDialog1.SelectedPath == string.Empty ? false : true;
            button2.Enabled = folderBrowserDialog2.SelectedPath == string.Empty ? false : true;
            textBox1.Enabled = button2.Enabled;
            label8.Text = folderBrowserDialog2.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // EnvironmentVariables.MainEnvironmentVariables();
            EnvironmentVariables.setEnvironmentVariable("working_directory", folderBrowserDialog1.SelectedPath);
            EnvironmentVariables.setEnvironmentVariable("files_full_path", label2.Text);
            EnvironmentVariables.setEnvironmentVariable("files_name_containing_string", textBox1.Text);
            EnvironmentVariables.setEnvironmentVariable("prefix", comboBox1.Text);
            EnvironmentVariables.setEnvironmentVariable("prefix_format", textBox2.Text);
            EnvironmentVariables.setEnvironmentVariable("surfix", comboBox2.Text);
            EnvironmentVariables.setEnvironmentVariable("surfix_format", textBox3.Text);
            EnvironmentVariables.setEnvironmentVariable("output_folder", label8.Text);
        }

        private void Config_MouseHover(object sender, EventArgs e)
        {
            // EnvironmentVariables.MainEnvironmentVariables();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            textBox1.Text = EnvironmentVariables.getEnvironmentVariable("files_name_containing_string");
            folderBrowserDialog1.SelectedPath = EnvironmentVariables.getEnvironmentVariable("working_directory");
            label2.Text = EnvironmentVariables.getEnvironmentVariable("files_full_path");
            folderBrowserDialog2.SelectedPath = EnvironmentVariables.getEnvironmentVariable("output_folder");
            label8.Text = EnvironmentVariables.getEnvironmentVariable("output_folder");
            comboBox1.Text = EnvironmentVariables.getEnvironmentVariable("prefix");
            textBox2.Text = EnvironmentVariables.getEnvironmentVariable("prefix_format");
            comboBox2.Text = EnvironmentVariables.getEnvironmentVariable("surfix");
            textBox3.Text = EnvironmentVariables.getEnvironmentVariable("surfix_format");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.ShowDialog();
        }
    }
}
