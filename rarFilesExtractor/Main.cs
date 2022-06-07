using System;
using System.IO;
using System.Windows.Forms;

namespace rarFilesExtractor
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config config = new Config();
            config.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // groupBox1.Enabled = EnvironmentVariables.getEnvironmentVariable("working_directory") != null 
                // && EnvironmentVariables.getEnvironmentVariable("output_folder") != null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            groupBox1.Enabled = EnvironmentVariables.getEnvironmentVariable("working_directory") != null
                && EnvironmentVariables.getEnvironmentVariable("output_folder") != null;

            label3.Visible = !groupBox1.Enabled;
            Directory.getFiles();

            FileInfo[] files = Directory.getFiles();

            for (int i = 0; i < files.Length; i++)
                Console.WriteLine(files[i].Name);
                // dataGridView1.Rows[i].Cells[0].Value = files[i].Name;
        }
    }
}
