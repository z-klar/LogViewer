using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogViewer
{
    public partial class Form1 : Form
    {
        private ArrayList alLogLines = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txLogFileName.Text = ofd.FileName;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ReadLogFile();
        }

        private void mainSelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayDetailLine();
        }
    }
}
