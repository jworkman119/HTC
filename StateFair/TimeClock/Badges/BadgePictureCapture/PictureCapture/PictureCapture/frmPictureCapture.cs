using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;


namespace PictureCapture
{
    

    public partial class frmPictureCapture : Form
    {

        Capture objCapture = new Capture();
        ImageBox bxPic = new ImageBox();

        

        public frmPictureCapture()
        {
            InitializeComponent();
            LoadFrame();
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            Image<Bgr, Byte> frame = objCapture.QuerySmallFrame();
            //frame.Resize(250,200,Emgu.CV.CvEnum.INTER.);
            bxPic.Image = frame;
            
        }

        private void LoadFrame()
        {
            addImageBox();
            

            if (Directory.Exists(StaticValues.PicDirectory) != true)
                Directory.CreateDirectory(StaticValues.PicDirectory);

            //Loading Logitech camera controls
            LoadLogitech();
            txtFirst.Focus();
        }

        private void LoadLogitech()
        {
            Process objProcess = new Process();
            objProcess.StartInfo.WorkingDirectory = StaticValues.CameraControls;
            objProcess.StartInfo.FileName = "CameraHelperShell.exe";
            objProcess.Start();
        }

        private void addImageBox()
        {
            
            bxPic.SetBounds(54, 12, 250, 200);

            
            bxPic.FunctionalMode = ImageBox.FunctionalModeOption.Minimum;
            this.Controls.Add(bxPic);

            if (objCapture != null)
                Application.Idle += ProcessFrame;

        }
        private void butSave_Click(object sender, EventArgs e)
        {
            if (txtFirst.Text.Length > 0 && txtLast.Text.Length > 0)
            {
                bxPic.Image.Save(StaticValues.PicDirectory + "\\" + txtFirst.Text + "_" + txtLast.Text + ".jpg");
                editXML(txtFirst.Text, txtLast.Text);
                MessageBox.Show("The picture was successfully saved");
                clearControl();
            }
            else
            {
                MessageBox.Show("You did not enter a first or last name.");
                txtFirst.Focus();
            }
        }

        private void butCapture_Click(object sender, EventArgs e)
        {
            if (butCapture.Text == "Capture Picture")
            {
                Application.Idle -= ProcessFrame;
                butCapture.Text = "Stream Video";
                butSave.Enabled = true;
            }
            else if (butCapture.Text == "Stream Video")
            {
                StreamVideo();
            }
        }

        private void StreamVideo()
        {
            Application.Idle += ProcessFrame;
            butCapture.Text = "Capture Picture";
            butSave.Enabled = false;
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            clearControl();
        }

        private void clearControl()
        {
            txtFirst.Clear();
            txtLast.Clear();

            StreamVideo();
            txtFirst.Focus();
        }

        private void editXML(string FirstName, string LastName)
        {
            
            if (File.Exists(StaticValues.xmlPicPath) != true)
                createXML(FirstName, LastName);
            else
                appendXML(FirstName, LastName);
                
        }

        private void createXML(string FirstName, string LastName)
        {
            XmlWriter xmlWriter = XmlWriter.Create(StaticValues.xmlPicPath);
            string[] arTest = new string[3];

            xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("StateFair");
                    xmlWriter.WriteStartElement("Worker");
                        xmlWriter.WriteElementString("FirstName", FirstName);
                        xmlWriter.WriteElementString("LastName", LastName);
                        xmlWriter.WriteElementString("PicFile", FirstName + "_" + LastName + ".jpg");
                    xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
                xmlWriter.Close();
        }

        private void appendXML(string FirstName, string LastName)
        {
          XmlDocument xmlDom = new XmlDocument();
            xmlDom.Load(StaticValues.xmlPicPath);

            XmlNode xmlNode = xmlDom["StateFair"].AppendChild(xmlDom.CreateElement("Worker"));
                xmlNode.AppendChild(xmlDom.CreateElement("FirstName")).AppendChild(xmlDom.CreateTextNode(FirstName));
                xmlNode.AppendChild(xmlDom.CreateElement("LastName")).AppendChild(xmlDom.CreateTextNode(LastName));
                xmlNode.AppendChild(xmlDom.CreateElement("PicFile")).AppendChild(xmlDom.CreateTextNode(FirstName + "_" + LastName + ".jpg"));


                xmlDom.Save(StaticValues.xmlPicPath);
/*
            XDocument xDoc = XDocument.Load(XmlReader.Create(StaticValues.xmlPicPath));
            xDoc.Element("StateFair").Add(new XElement("Worker"
                    ,new XElement("FirstName",FirstName)
                    ,new XElement("LastName", LastName)
                    ,new XElement("PicPath", FirstName + "_" + LastName + ".jpg")));

            //XmlWriter xmlWrite = XmlWriter.Create(StaticValues.xmlPicPath);
            //xDoc.WriteTo(xmlWrite);
            
            xDoc.Save(StaticValues.xmlPicPath);
*/
            /*
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.OmitXmlDeclaration = true;
            xws.Indent = true;

            using (var stream = File.Create(@"C:\test.xml"))
            using (XmlWriter xw = XmlWriter.Create(stream, xws))
            {
                var xml = new XElement(
                    "root",
                    new XElement("subelement1", "1"),
                    new XElement("subelement2", "2"));

                xml.Save(xw);
            }
            */
        }                                                                                                                                                                  
    }
}
