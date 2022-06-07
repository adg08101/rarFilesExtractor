using System;
using System.Diagnostics;
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
            button2_Click(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            groupBox1.Enabled = EnvironmentVariables.getEnvironmentVariable("working_directory") != null
                && EnvironmentVariables.getEnvironmentVariable("output_folder") != null;

            label3.Visible = !groupBox1.Enabled;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();

                dataGridView1.Columns[0].Width = 300;
                dataGridView1.Columns[1].Width = 200;

                Directory.getFiles();

                FileInfo[] files = Directory.getFiles();

                for (int i = 0; i < files.Length; i++)
                    dataGridView1.Rows.Add(files[i].FullName, files[i].LastWriteTimeUtc);

                dataGridView1.Sort(dataGridView1.Columns[1], System.ComponentModel.ListSortDirection.Descending);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
                processStartInfo.RedirectStandardInput = true;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.UseShellExecute = false;

                Process process = Process.Start(processStartInfo);

                if (process != null)
                {
                    // if ()
                    process.StandardInput.WriteLine("start C:\\Environments");
                    process.StandardInput.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
