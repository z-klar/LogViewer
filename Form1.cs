using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogViewer
{
    public partial class Form1 : Form
    {
        private const int SEARCH_DB_CAPACITY = 30;
        private String[] searchedTexts = new string[SEARCH_DB_CAPACITY];
        private int noSearchedTexts = 0;
        private ArrayList filterStrings = new ArrayList();

        private ArrayList alLogLines = new ArrayList();
        private int LineToStartSearching;

        public Form1()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.O | Keys.Control))
            {
                openFile();
                return true; // indicate that you handled this keystroke
            }
            else if (keyData == (Keys.N | Keys.Control))
            {
                FindNext();
                return true; // indicate that you handled this keystroke
            }
            else if (keyData == (Keys.P | Keys.Control))
            {
                FindPrev();
                return true; // indicate that you handled this keystroke
            }
            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void openFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txLogFileName.Text = ofd.FileName;
            }
            ReadLogFile();
        }
        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ReadLogFile();
        }

        private void mainSelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayDetailLine();
        }

        private void txLogFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            FindNext();
        }

        private void btnFindPrev_Click(object sender, EventArgs e)
        {
            FindPrev();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FilterOptions dlg = new FilterOptions(filterStrings, searchedTexts);
            dlg.ProcessNewParams += new EventHandler<ProcessNewParamsArgs>(FilterOutput);
            dlg.Show();
        }
    }
}
