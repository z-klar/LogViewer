using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogViewer
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// 
        /// </summary>
        private void ReadLogFile()
        {

            alLogLines.Clear();
            try
            {
                StreamReader sw = null;
                FileStream fs = File.Open(txLogFileName.Text, FileMode.Open, FileAccess.Read);
                sw = new StreamReader(fs, System.Text.Encoding.ASCII);
                string sPom;
                while ((sPom = sw.ReadLine()) != null)
                {
                    alLogLines.Add(sPom);
                }
                sw.Close();
                fs.Close();
                DisplayBuffer();
                this.Text += " ";
               
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR:\n" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void DisplayBuffer()
        {
            lbMainLog.Items.Clear();
            foreach (string s in alLogLines)
            {
                if(FilterOk(s)) lbMainLog.Items.Add(s);
            }
        }

        private bool FilterOk(string line)
        {
            if(filterStrings.Count > 0)
            {
                foreach(string s in filterStrings)
                {
                    int n = line.ToLower().IndexOf(s.ToLower());
                    if (n >= 0) return (true);
                }
                return (false);
            }
            else
            {
                return (true);
            }
        }

        private void DisplayDetailLine()
        {
            int i = lbMainLog.SelectedIndex;
            txDetails.Text = lbMainLog.SelectedItem.ToString();
        }

        private void FilterOutput(object sender, ProcessNewParamsArgs e)
        {
            ArrayList al = e.searchString;
            filterStrings.Clear();
            for(int i=0; i<al.Count; i++) filterStrings.Add(al[i]);
            DisplayBuffer();
            if (al.Count > 0) btnFilter.BackColor = Color.Red;
            else btnFilter.BackColor = Color.Transparent;
            for (int i = 0; i < al.Count; i++) UpdateSearchedTexts(Convert.ToString(al[i]));
        }

    }
}
