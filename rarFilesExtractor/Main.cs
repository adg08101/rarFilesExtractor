using System;
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
    }
}
