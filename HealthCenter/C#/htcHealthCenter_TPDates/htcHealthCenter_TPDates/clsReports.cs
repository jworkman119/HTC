using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Xml;
using System.IO;
using System.Net;

namespace htcHealthCenter_TPDates
{
    class clsReports
    {

        public bool createReport(SQLiteDataReader objReader, string TimeFrame, string Source)
        {
            bool blPass = false;

            createXML(objReader, TimeFrame, Source);
            CreateFO(Source);

            string strPath = Path.GetTempPath() + "htc" + Source + ".pdf";
            if (File.Exists(strPath) == true)
            {
                System.Diagnostics.Process.Start(strPath);
                blPass = true;
            }
            return blPass;

        }

        private void createXML(SQLiteDataReader objReader, string TimeFrame, string Source)
        {
            string strPath = Path.GetTempPath();
            string strXMLFile = "htc" + Source + ".xml";
            XmlWriter objXML = XmlWriter.Create(strPath + strXMLFile);
            objXML.WriteStartDocument();
            objXML.WriteStartElement(Source);
            // Header
            objXML.WriteStartElement("Header");
                objXML.WriteElementString("TimeFrame", TimeFrame);
            objXML.WriteEndElement();

            //Body
            if (Source == "TPDates")
                writeBodyTPDates(ref objXML, ref objReader);
            else
                writeBodyWaitList(ref objXML, ref objReader);

            //Footer
            objXML.WriteStartElement("Footer");
                
                objXML.WriteElementString("Date", System.DateTime.Now.ToString("MM/dd/yyyy"));
            objXML.WriteEndElement();


            objXML.Close();
            objReader.Close();
        }

        private void writeBodyTPDates(ref XmlWriter objXML, ref SQLiteDataReader objReader)
        {
            string DrName = "";
            string Resource = "";
            objXML.WriteStartElement("Body");
                objXML.WriteStartElement("Table");
                   
            
                    int j = 0;
                    while (objReader.Read())
                    {
                        if (j == 0)
                        {
                            //writing Column Headers
                            objXML.WriteStartElement("Headers");
                                objXML.WriteElementString("Column", "Account");
                                objXML.WriteElementString("Column", "Patient");
                                objXML.WriteElementString("Column", "TP Date");
                                objXML.WriteElementString("Column", "Resource");
                                objXML.WriteElementString("Column", "Location");
                            objXML.WriteEndElement();
                            objXML.WriteStartElement("TableBody");
                            objXML.WriteStartElement("Appointments");
                            j++;
                        }

                            objXML.WriteStartElement("Appointment");
                            objXML.WriteElementString("Account", objReader["Account"].ToString());
                            string strTest = objReader["Patient"].ToString();
                            objXML.WriteElementString("Patient", objReader["Patient"].ToString());
                            objXML.WriteElementString("Date", objReader["TP_Date"].ToString());
                            objXML.WriteElementString("Location", objReader["Location"].ToString());
                            Resource = objReader["Resource"].ToString();
                            objXML.WriteElementString("Resource", Resource );
                            if (Resource == DrName)
                                objXML.WriteElementString("Previous", objReader["Resource"].ToString());
                            else
                            {
                                objXML.WriteElementString("Previous", DrName);
                                
                            }
                            DrName = Resource;
                            objXML.WriteEndElement();
                    
                    }
                            objXML.WriteEndElement(); // appointments
                            objXML.WriteEndElement(); // TableBody
                objXML.WriteEndElement(); // Table
            objXML.WriteEndElement(); // Body
        }

        private void writeBodyWaitList(ref XmlWriter objXML, ref SQLiteDataReader objReader)
        {
            objXML.WriteStartElement("Body");
            objXML.WriteStartElement("Table");

            int j = 0;
            while (objReader.Read())
            {
                if (j == 0)
                {
                    //writing Column Headers
                    objXML.WriteStartElement("Headers");
                    objXML.WriteElementString("Column", "Account");
                    objXML.WriteElementString("Column", "Patient");
                    objXML.WriteElementString("Column", "StartDate");
                    objXML.WriteElementString("Column", "EndDate");
                    objXML.WriteElementString("Column", "Resource");
                    objXML.WriteEndElement();
                    objXML.WriteStartElement("TableBody");
                    objXML.WriteStartElement("Rows");
                    j++;
                }

                objXML.WriteStartElement("Row");
                    objXML.WriteElementString("Account", objReader["Account"].ToString());
                    objXML.WriteElementString("Patient", objReader["Patient"].ToString());
                    objXML.WriteElementString("StartDate", objReader["StartDate"].ToString());
                    objXML.WriteElementString("EndDate", objReader["EndDate"].ToString());
                    objXML.WriteElementString("Resource", objReader["Resource"].ToString());
                objXML.WriteEndElement();
            }
            objXML.WriteEndElement(); // Rows
            objXML.WriteEndElement(); // TableBody
            objXML.WriteEndElement(); // Table
            objXML.WriteEndElement(); // Body

        }

        private bool CreateFO(string Source)
        {
            System.Diagnostics.Process objProcess = new System.Diagnostics.Process();

            string rootPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles);
            
            if (rootPath.IndexOf("x86")>0)
                rootPath = "c:\\progra~2";
            else
                rootPath = "c:\\progra~1";
            
            objProcess.StartInfo.WorkingDirectory = rootPath + "\\HTC\\FOP";

            objProcess.StartInfo.FileName = "fop.bat";
            string strArguments = @"-xml %Temp%\htc" + Source + ".xml -xsl " + rootPath + "\\HTC\\htcTreatmentPlanDates\\" + Source + ".xsl " + @" -pdf %Temp%\htc" + Source + ".pdf";
            objProcess.StartInfo.Arguments = strArguments;
            objProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            objProcess.Start();

            //sleeping the code, until the process completes. If it takes more than 7 seconds I will produce an error.
            int intSleep = 0;
            bool blProcess = false;
            while (objProcess.HasExited == false)
            {
                System.Threading.Thread.Sleep(500);
                if (intSleep == 14)
                {
                    // raise an error, and place in messagebox
                    //                    RelayStatus("Error - the pdf could not be created. Please contact tech support");
                    blProcess = true;
                    break;
                }
                intSleep++;
            }
            objProcess.Close();
            return blProcess;
        }

       
    }
}
