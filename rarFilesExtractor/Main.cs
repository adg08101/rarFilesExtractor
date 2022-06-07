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

            textBox1.Text = EnvironmentVariables.getEnvironmentVariable("folder_name");
            textBox2.Text = EnvironmentVariables.getEnvironmentVariable("inner_folder_name");
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
                dataGridView1.Rows[0].Selected = true;
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

        private string concatenateIfOneCharacter(string input, string fill)
        {
            return input.Length == 1 ? fill + input : input;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                EnvironmentVariables.setEnvironmentVariable("folder_name", textBox1.Text);
                EnvironmentVariables.setEnvironmentVariable("inner_folder_name", textBox2.Text);

                ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
                processStartInfo.RedirectStandardInput = true;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.UseShellExecute = false;

                Process process = Process.Start(processStartInfo);

                String surfix = EnvironmentVariables.getEnvironmentVariable("surfix");

                if (surfix != null)
                {
                    DateTime today = DateTime.Today;

                    switch (surfix)
                    {
                        case "Current Date":
                            surfix = today.Year.ToString() +
                                concatenateIfOneCharacter(today.Month.ToString(), "0") +
                                concatenateIfOneCharacter(today.Day.ToString(), "0");
                            break;
                        default:
                            surfix = String.Empty;
                            break;
                    }
                }

                if (process != null)
                {
                    String containingFolder = textBox1.Text + surfix;

                    if (textBox1.Text != string.Empty)
                    {
                        process.StandardInput.WriteLine("cd " + EnvironmentVariables.getEnvironmentVariable("output_folder"));
                        process.StandardInput.WriteLine("mkdir " + containingFolder);

                        if (textBox2.Text != string.Empty)
                        {
                            process.StandardInput.WriteLine("cd " + containingFolder);
                            process.StandardInput.WriteLine("mkdir " + textBox2.Text);
                            EnvironmentVariables.setEnvironmentVariable("destination", EnvironmentVariables.getEnvironmentVariable("output_folder") +
                                "\\" + containingFolder + "\\" + textBox2.Text);
                        }
                    }
                    else
                    { 
                        // Continue here
                    }

                    Console.WriteLine(dataGridView1.SelectedCells[0].Value);
                    Console.WriteLine(EnvironmentVariables.getEnvironmentVariable("destination"));

                    String command = "7z e \"" + dataGridView1.SelectedCells[0].Value +
                        "\" - o \"" + EnvironmentVariables.getEnvironmentVariable("destination") + "\" -r - y";

                    Console.Write(command);

                    process.StandardInput.WriteLine(command);
                    // 7z e "%file%" - o % destination % -r - y

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
