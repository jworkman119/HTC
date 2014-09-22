using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

// Jeremy
using System.IO;

namespace BillingParse
{
    public partial class frmStateFairUpload : Form
    {
        string[] strFiles;
        string strResult;

        public frmStateFairUpload()
        {
            InitializeComponent();
            dtDate.Format = DateTimePickerFormat.Custom;
            dtDate.CustomFormat = "M-d";
            
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            

            objBrowse.Filter = "excel files (*.xls)|*.xls";
            DialogResult result = objBrowse.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtPath.Text = objBrowse.FileName;
                            
            }

          
        }



        private void butParse_Click(object sender, EventArgs e)
        {
            clsParseXL objParse = new clsParseXL();
            bool blSuccess = false;
            
            this.Cursor = Cursors.WaitCursor;
                lstErrors.Items.Clear();
                objParse.Date = dtDate.Text;
                objParse.Path = txtPath.Text.Replace("/", "\\");

                blSuccess = objParse.ParseFile();
                AddErrors_lstErrors(objParse.Errors);
            this.Cursor = Cursors.Default;
        }

        private void AddErrors_lstErrors(string strErrors)
        {
            if (strErrors != null)
            {
                Clipboard.Clear();
                StringBuilder buffer = new StringBuilder();
                string[] arErrors = strErrors.Split('|');
                for (int j = 0; j < arErrors.Count(); j++)
                {
                    lstErrors.Items.Add(arErrors[j]);
                    buffer.Append(arErrors[j]);
                    buffer.Append("\n");
                }
                Clipboard.SetText(buffer.ToString());
            }
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        private void mnuCutCopy_ItemClicked(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
        {
            Clipboard.Clear();
            string strOutput = "";
            if (e.ClickedItem.Text == "Copy")
            {
                foreach(object item in lstErrors.Items)
                {
                    strOutput = strOutput + item.ToString() + Environment.NewLine;
                }

                Clipboard.SetText(strOutput);
            }
        }








        
    }

       
}
