using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BillingParse
{
    public partial class frmBillingParse : Form
    {
        public frmBillingParse()
        {
            InitializeComponent();
        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            
            DialogResult result = objBrowse.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                txtPath.Text = objBrowse.FileName;

            }
        }

        private void butParse_Click(object sender, EventArgs e)
        {
            ParseFile objParse = new ParseFile();
            string strPath = txtPath.Text;
            strPath = strPath.Substring(0,strPath.LastIndexOf('\\'));
            string[] objFiles = Directory.GetFiles(strPath);
            string strPass = objParse.ParseTheFile(strPath, objFiles);
            this.Cursor = Cursors.WaitCursor;
            if (strPass == "Success")
            {
                MessageBox.Show("Your File has finished");

            }
            this.Cursor = Cursors.Default;
        }

        
    }
}
