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
            UpdateSearchedTexts(cbSearchedText.Text);
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
            string stringToFind = cbSearchedText.Text;
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

        /// <summary>
        /// Check whether the text in SEARCHED_TEXT box is already in DB
        /// </summary>
        private void UpdateSearchedTexts(string text)
        {
            if(TextNotInDb(text))
            {
                AddNewText(text);
            }
        }

        private bool TextNotInDb(string text)
        {
            for(int i=0; i<noSearchedTexts; i++)
            {
                if (searchedTexts[i].Equals(text)) return (false);
            }
            return (true);
        }

        private void AddNewText(string text)
        {
            if(noSearchedTexts < SEARCH_DB_CAPACITY)
            {
                searchedTexts[noSearchedTexts] = text;
                noSearchedTexts++;
            }
            else
            {
                for(int i=1; i< SEARCH_DB_CAPACITY; i++)
                {
                    searchedTexts[i - 1] = searchedTexts[i];
                }
                searchedTexts[SEARCH_DB_CAPACITY - 1] = text;
            }
            cbSearchedText.Items.Clear();
            for (int i = 0; i < noSearchedTexts; i++) 
                cbSearchedText.Items.Add(searchedTexts[i]);
        }
    }
}