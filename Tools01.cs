using System;
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
            foreach (string s in alLogLines) lbMainLog.Items.Add(s);
        }

        private void DisplayDetailLine()
        {
            int i = lbMainLog.SelectedIndex;
            txDetails.Text = Convert.ToString(alLogLines[i]);
        }
    }
}
