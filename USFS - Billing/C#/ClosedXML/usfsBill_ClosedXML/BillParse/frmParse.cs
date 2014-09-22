using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;


namespace BillParse
{
    public partial class frmParse : Form
    {
        string strXL = "";
        string Source = "";
        List<string> Delete = new List<string> { };
        string strInitialDir = "";

        public frmParse()
        {
            InitializeComponent();
            LoadForm();
        }

        private void LoadForm()
        {
            loadSettings();
            lblStatus.Text = "Browse to the folder where the zip file(s) are located";
            butParse.Enabled = false;
            objBrowseDir.RootFolder = Environment.SpecialFolder.MyDocuments;
        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            if (Source == "zip")
            {
                BrowseDirectory();
            }
            else if (Source == "txt")
            {
                BrowseFile();
            }
            
        }

        private void BrowseFile()
        {
            objBrowseFile.InitialDirectory = @strInitialDir;
            DialogResult result = objBrowseFile.ShowDialog();

            setUpControl_Parse(result, objBrowseFile.FileName);
        }

        private void BrowseDirectory()
        {
            DialogResult result = objBrowseDir.ShowDialog();

            setUpControl_Parse(result, objBrowseDir.SelectedPath);
            
        }

        private void setUpControl_Parse(DialogResult result, string strPath)
        {
            if (result == DialogResult.OK)
            {
                txtPath.Text = strPath;
                lblStatus.Text = "Parse the file.";
                butParse.Enabled = true;
                butExcel.Enabled = false;
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butParse_Click(object sender, EventArgs e)
        {
            Cursor.Current =  Cursors.WaitCursor;
            if (Source == "zip")
                UnzipFiles(txtPath.Text);
            else if (Source == "txt")
                parseTxt(txtPath.Text);

            Cursor.Current = Cursors.Default;
        }

        private void parseTxt(string strPath)
        {
            string File = strPath.Substring(strPath.LastIndexOf("\\") + 1, strPath.Length - (strPath.LastIndexOf("\\") + 1));
            strPath = strPath.Substring(0,strPath.LastIndexOf("\\"));
            string[] FileNames = new string[]{File};

            strXL = parseFiles(strPath, FileNames);
            butExcel.Enabled = true;
            lblStatus.Text = "";
        }

        private void UnzipFiles(string strPath)
        {
            
            string[] FileNames;
            string[] filePaths = Directory.GetFiles(strPath, "*.zip");
            if (filePaths.Count() == 0)
                MessageBox.Show("There were no zip files in the directory selected, please navigate to the appropriate directory");
            else
            {
                clsUnZip objUnZip = new clsUnZip();
                FileNames = objUnZip.UnzipFiles(strPath,filePaths);
                if (FileNames.Length > 0)
                {
                    strXL = parseFiles(strPath, FileNames);
                    butExcel.Enabled = true;
                    lblStatus.Text = "";
                }
                else
                    MessageBox.Show("The files did not unzip properly. Try again, if the problem persists contact IT.");
            }
        }

        private string parseFiles(string strPath, string[] fileNames)
        {
            clsParse2XL objParse = new clsParse2XL();
            string strFile = objParse.parseFiles(strPath, fileNames);
            if (Delete.Count > 0 && Source == "zip")
                deleteFiles(strPath);
            else if (Delete.Count > 0 && Source == "txt")
                deleteFile(strPath, fileNames);
            return strFile;
        }

        private void deleteFile(string strPath, string[] fileNames)
        {
            for (int j = 0; j < Delete.Count(); j++)
            {
                if (Delete[j] == "txt")
                {
                    File.Delete(strPath + "\\" + fileNames[0]); //only one filename to delete.
                }
            }
        }

        private void deleteFiles(string strPath)
        {
            DirectoryInfo Dir = new DirectoryInfo(strPath);
            FileInfo[] files = Dir.GetFiles();
            for (int j = 0; j < Delete.Count; j++)
            {
                string strExtension = Delete[j];
                for (int t = 0; t < files.Count(); t++)
                {
                    if (files[t].Extension.ToString() == "." + strExtension)
                        files[t].Delete();
                }
            }
        }

        private void butExcel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@strXL);
        }

        private void mnuSource_Zip_Click(object sender, EventArgs e)
        {
            changeSource("zip");
            writeSettings();
        }

        private void mnuSource_txt_Click(object sender, EventArgs e)
        {
            changeSource("txt");
            writeSettings();
        }

        private void changeSource(string strSender)
        {
            if (strSender == "zip")
            {
                mnuSource_Zip.Checked = true;
                mnuSource_txt.Checked = false;
                Source = "zip";
            }
            else if(strSender == "txt")
            {
                mnuSource_Zip.Checked = false;
                mnuSource_txt.Checked = true;
                Source = "txt";
            }

            
        }

        private void loadSettings()
        {
            using (XmlTextReader xmlReader = new XmlTextReader("Settings.xml"))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.Name == "Source")
                    {
                        changeSource(xmlReader.ReadString());
                    }
                    else if (xmlReader.Name == "Extension")
                    {
                        changeDelete(xmlReader.ReadString());
                    }
                    else if (xmlReader.Name == "InitialDirectory")
                    {
                        strInitialDir = xmlReader.ReadString();
                    }
                }

                xmlReader.Close();
            }
        }

        private void changeDelete(string strExtension)
        {
            Delete.Add(strExtension);
            if (strExtension == "txt")
                mnuDelete_txt.Checked = true;
            else if (strExtension == "zip")
                mnuDelete_zip.Checked = true;
                
        }

        private void writeSettings()
        {
             XmlWriter xmlWriter = XmlWriter.Create("Settings.xml");
             
            xmlWriter.WriteStartElement("Settings");
                xmlWriter.WriteElementString("Source", Source);
                xmlWriter.WriteStartElement("Delete");
                if (Delete != null)
                {
                    for (int j = 0; j < Delete.Count; j++)
                    {
                        xmlWriter.WriteElementString("Extension", Delete[j]);
                    }
                }
                xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            
            xmlWriter.Close();
        }

        private void mnuDelete_zip_Click(object sender, EventArgs e)
        {
            updateDelete(mnuDelete_zip, "zip");
        }

        private void mnuDelete_txt_Click(object sender, EventArgs e)
        {
            updateDelete(mnuDelete_txt, "txt");
        }

        private void updateDelete(ToolStripMenuItem objMenu,string Value)
        {
            if (objMenu.Checked == true)
                Delete.Add(Value);
            else
                Delete.Remove(Value);

            writeSettings();
        }


    }
}
