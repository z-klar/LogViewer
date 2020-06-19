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
        /// <summary>
        /// 
        /// </summary>
        private void Find()
        {
            LineToStartSearching = 0;
            SearchText(false);
        }

        /// <summary>
        /// 
        /// </summary>
        private void FindNext()
        {
            LineToStartSearching++;
            SearchText(false);
        }

        /// <summary>
        /// 
        /// </summary>
        private void FindPrev()
        {
            LineToStartSearching--;
            SearchText(true);
        }
        private void SearchText(bool back)
        {
            string stringToFind = txFind.Text;
            if(stringToFind.Length == 0)
            {
                MessageBox.Show("Please provide a text to search !");
                return;
            }
            if(LineToStartSearching >= alLogLines.Count)
            {
                MessageBox.Show("End of log reached !");
                return;
            }
            if (LineToStartSearching < 0)
            {
                MessageBox.Show("Start of log reached !");
                return;
            }
            if (back)
            {
                for (int i = LineToStartSearching; i >= 0; i--)
                {
                    string logLine = Convert.ToString(alLogLines[i]);
                    int n = logLine.ToLower().IndexOf(stringToFind.ToLower());
                    if (n >= 0) // found
                    {
                        ShowSelectedLine(i);
                        LineToStartSearching = i;
                        return;
                    }
                }
            }
            else
            {
                for (int i = LineToStartSearching; i < alLogLines.Count; i++)
                {
                    string logLine = Convert.ToString(alLogLines[i]);
                    int n = logLine.ToLower().IndexOf(stringToFind.ToLower());
                    if (n >= 0) // found
                    {
                        ShowSelectedLine(i);
                        LineToStartSearching = i;
                        return;
                    }
                }
            }
            MessageBox.Show("Provided string not found !!!");
        }

        private void ShowSelectedLine(int line)
        {
            lbMainLog.SelectedIndex = line;
            
        }
    }
}