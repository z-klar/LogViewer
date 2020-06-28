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
    public partial class FilterOptions : Form
    {
        public FilterOptions(ArrayList filters, string [] suggestions)
        {
            InitializeComponent();
            foreach(string s in suggestions)
            {
                if(s != null)
                {
                    cbString0.Items.Add(s);
                    cbString1.Items.Add(s);
                    cbString2.Items.Add(s);
                    cbString3.Items.Add(s);
                    cbString4.Items.Add(s);
                }
            }
            if (filters.Count > 0) cbString0.Text = Convert.ToString(filters[0]);
            if (filters.Count > 1) cbString1.Text = Convert.ToString(filters[1]);
            if (filters.Count > 2) cbString2.Text = Convert.ToString(filters[2]);
            if (filters.Count > 3) cbString3.Text = Convert.ToString(filters[3]);
            if (filters.Count > 4) cbString4.Text = Convert.ToString(filters[4]);

        }

        public event EventHandler<ProcessNewParamsArgs> ProcessNewParams;

        private void btnOk_Click(object sender, EventArgs e)
        {
            ProcessNewParamsArgs args = new ProcessNewParamsArgs();
            args.searchString = new ArrayList();
            if (cbString0.Text.Length > 0) args.searchString.Add(cbString0.Text);
            if (cbString1.Text.Length > 0) args.searchString.Add(cbString1.Text);
            if (cbString2.Text.Length > 0) args.searchString.Add(cbString2.Text);
            if (cbString3.Text.Length > 0) args.searchString.Add(cbString3.Text);
            if (cbString4.Text.Length > 0) args.searchString.Add(cbString4.Text);
            OnProcessNewParams(args);
            this.Hide();
        }

        protected virtual void OnProcessNewParams(ProcessNewParamsArgs e)
        {
            EventHandler<ProcessNewParamsArgs> handler = ProcessNewParams;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            cbString0.Text = "";
            cbString1.Text = "";
            cbString2.Text = "";
            cbString3.Text = "";
            cbString4.Text = "";
        }
    }


    public class ProcessNewParamsArgs : EventArgs
    {
        public ArrayList searchString { get; set; }
    }
}
