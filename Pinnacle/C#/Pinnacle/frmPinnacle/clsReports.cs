using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Collections;

namespace frmPinnacle
{
    class clsReports
    {

        string strActivityLogPath = Path.GetTempPath(); 

        public void CreateActivityLog(string meetingID)
        {
            string SQL = returnActivityLog_SQL(meetingID);
            SQLiteDataReader objReader = returnMeetingData(SQL);
            writeActivityLog_XML(objReader);
            CreateFO("Activity Log");

            string strPath = Path.GetTempPath() + "ActivityLog.pdf";
            if (File.Exists(strPath) == true)
            {
                System.Diagnostics.Process.Start(strPath);
            }
        }

        private SQLiteDataReader returnMeetingData(string SQL)
        {
            clsDB objDb = new clsDB(resPinnacle.liveDB);
            SQLiteDataReader objReader = objDb.returnDataReader(SQL);

            return objReader;
        }

        private string returnActivityLog_SQL(string meetingID)
        {
            string SQL = "Select Consumer.FirstName || ' ' || Consumer.LastName as Consumer ";
            SQL = SQL + " , Case Job_ID When Job_ID is null then 'Unemployed'";
            SQL = SQL + " Else Job.Employer End as Employer";
            SQL = SQL + " , strftime('%m/%d/%Y',Review.Date) as Date";
            SQL = SQL + " , Meeting.Description as MeetingType";
            SQL = SQL + " , Review.DesiredOutcome as ValuedOutcome";
            SQL = SQL + " , Review.Barriers";
            SQL = SQL + " , Job.Address";
            SQL = SQL + " , Job.City || ', NY ' || Job.Zip as CityStateZip";
            SQL = SQL + " , Review.Note as Notes, Review.TimeIn, Review.TimeOut";
            SQL = SQL + " From Review";
            SQL = SQL + "   Join Consumer on Review.Consumer_ID = Consumer.ID";
            SQL = SQL + "   Join Meeting on Review.Meeting_ID = Meeting.ID";
            SQL = SQL + "   Left Join Job on Review.Job_ID= Job.ID";
            SQL = SQL + " Where Review.ID = " + meetingID;

            return SQL;
        }

        private void writeActivityLog_XML(SQLiteDataReader objReader)
        {
            clsFormat objFormat = new clsFormat();

            strActivityLogPath = strActivityLogPath  + "ActivityLog.xml";
            XmlWriter xmlWrite = XmlWriter.Create(strActivityLogPath);
            xmlWrite.WriteStartDocument();
                xmlWrite.WriteStartElement("ActivityLog");
                xmlWrite.WriteElementString("Header", "");
                xmlWrite.WriteStartElement("Body");
                while (objReader.Read())
                {
                    xmlWrite.WriteElementString("Consumer",objReader["Consumer"].ToString());
                    xmlWrite.WriteStartElement("Employer");
                        xmlWrite.WriteElementString("Name", objReader["Employer"].ToString());
                        xmlWrite.WriteStartElement("Location");
                            xmlWrite.WriteElementString("Address", objReader["Address"].ToString());
                            xmlWrite.WriteElementString("CityStateZip", objReader["CityStateZip"].ToString());
                        xmlWrite.WriteEndElement();
                    xmlWrite.WriteEndElement();
                    xmlWrite.WriteStartElement("Review");
                        xmlWrite.WriteStartElement("Info");
                            xmlWrite.WriteElementString("Date", objReader["Date"].ToString());
                            xmlWrite.WriteElementString("MeetingType", objReader["MeetingType"].ToString());
                            
                            string Time = objFormat.convertTime_12hr(objReader.GetDateTime(objReader.GetOrdinal("TimeIn")));
                            xmlWrite.WriteElementString("TimeIn", Time);
                            Time = objFormat.convertTime_12hr(objReader.GetDateTime(objReader.GetOrdinal("TimeOut")));
                            xmlWrite.WriteElementString("TimeOut", Time);
                        xmlWrite.WriteEndElement();
                    
                     //xmlWrite.WriteElementString("WaiverEnrolled", objReader["WaiverEnrolled"].ToString());
                     xmlWrite.WriteElementString("ValuedOutcome", objReader["ValuedOutcome"].ToString());
                     xmlWrite.WriteElementString("Barriers", objReader["Barriers"].ToString());
                     xmlWrite.WriteElementString("Notes", objReader["Notes"].ToString());
                     xmlWrite.WriteEndElement(); //Review

                     xmlWrite.WriteEndElement(); //Body
                }
                xmlWrite.WriteStartElement("Footer");
                    xmlWrite.WriteElementString("Date", DateTime.Now.ToShortDateString());
                xmlWrite.WriteEndElement();

                xmlWrite.WriteEndElement();
                xmlWrite.Close();

                objReader.Close();
        }

        public string CreateMonthlyActivityLog(string ConsumerID, string Month, string Year)
        {
            clsDB objDB = new clsDB(resPinnacle.liveDB);
            string SQL = returnMonthlyActivityLog_SQL(ConsumerID, Month, Year);
            SQLiteDataReader objReader = objDB.returnDataReader(SQL);
            string strReturn="";

            if (objReader.HasRows == true)
            {
                writeMonthlyActivityLog_XML(objReader);
                CreateFO("Monthly Activity Log");
                string strPath = Path.GetTempPath() + "MonthlyActivityLog.pdf";
                if (File.Exists(strPath) == true)
                {
                    System.Diagnostics.Process.Start(strPath);
                }
            }
            else
            {
                strReturn = "No rows were returned, for the month requested.";
            }

            return strReturn;
        }

        private void writeMonthlyActivityLog_XML(SQLiteDataReader objReader)
        {
            clsFormat objFormat = new clsFormat();
            float fltTotalTime = 0;
            strActivityLogPath = strActivityLogPath + "MonthlyActivityLog.xml";
            ArrayList strBarriers = new ArrayList();
            XmlWriter xmlWrite = XmlWriter.Create(strActivityLogPath);
            xmlWrite.WriteStartDocument();
            xmlWrite.WriteStartElement("MonthlyActivityLog");

            bool blStart = true;
            while (objReader.Read())
            {
                if (blStart == true)
                {
                    xmlWrite.WriteStartElement("Header");
                        // getting Month Name from .net
                        int intMonth = Convert.ToInt16(objReader["Month"].ToString());
                        var LongMth = CultureInfo.CurrentCulture.DateTimeFormat;
                        string strMonth = LongMth.GetMonthName(intMonth);
                        xmlWrite.WriteElementString("Month", strMonth);

                        xmlWrite.WriteElementString("Year", objReader["Year"].ToString());
                    xmlWrite.WriteEndElement();

                    xmlWrite.WriteStartElement("Body");
                        xmlWrite.WriteStartElement("Consumer");
                            xmlWrite.WriteElementString("Name", objReader["Consumer"].ToString());
                            xmlWrite.WriteElementString("SSN", objReader["SSN"].ToString());
                        xmlWrite.WriteEndElement();

                        xmlWrite.WriteStartElement("Reviews");
                    blStart = false;
                }
                xmlWrite.WriteStartElement("Review");
                    xmlWrite.WriteElementString("Staff", objReader["Staff"].ToString());
                    xmlWrite.WriteElementString("Date", objReader["Date"].ToString());
                    xmlWrite.WriteElementString("Employer", objReader["Employer"].ToString());
                    xmlWrite.WriteElementString("MeetingType", objReader["MeetingType"].ToString());
                    xmlWrite.WriteElementString("Note", objReader["Note"].ToString());


                    string Time = objFormat.convertTime_12hr(objReader.GetDateTime(objReader.GetOrdinal("TimeIn")));
                    xmlWrite.WriteElementString("TimeIn", Time);
                    Time = objFormat.convertTime_12hr(objReader.GetDateTime(objReader.GetOrdinal("TimeOut")));
                    xmlWrite.WriteElementString("TimeOut", Time);
                    float fltTime = ReturnHours(objReader["TimeIn"].ToString(), objReader["TimeOut"].ToString());

                    xmlWrite.WriteElementString("Hours", fltTime.ToString());
                    fltTotalTime = fltTotalTime + fltTime;
                    // Adding to Barriers Collection, to be used later
                    if (objReader["Barriers"].ToString().Trim() !="" && objReader["Barriers"].ToString() !=null)
                        strBarriers.Add(objReader["Barriers"].ToString());
                xmlWrite.WriteEndElement();
            }
                xmlWrite.WriteElementString("TotalHours", fltTotalTime.ToString());
            xmlWrite.WriteEndElement(); //Reviews
            writeMonthlyActivityLog_BarriersXML(ref xmlWrite, strBarriers);
            xmlWrite.WriteEndElement(); //Body
            
            //footer
            xmlWrite.WriteStartElement("Footer");
                xmlWrite.WriteElementString("Date", System.DateTime.Today.ToShortDateString());
            xmlWrite.WriteEndElement();

            xmlWrite.Close();

            objReader.Close();
        }

        private void writeMonthlyActivityLog_BodyXML(ref XmlWriter xmlWrite)
        {

        }

        private void writeMonthlyActivityLog_BarriersXML(ref XmlWriter xmlWrite, ArrayList objList)
        {
            xmlWrite.WriteStartElement("Barriers");
            foreach (string Barrier in objList)
            {
                xmlWrite.WriteStartElement("Barrier");
                xmlWrite.WriteElementString("Item", Barrier.ToString());
                xmlWrite.WriteEndElement();
            }
            xmlWrite.WriteEndElement();
        }

        private string returnMonthlyActivityLog_SQL(string ConsumerID, string Month, string Year)
        {
            string SQL = "Select Consumer.FirstName || ' ' || Consumer.LastName as Consumer, Consumer.SSN";
            SQL = SQL + " , strFtime('%Y',date) as Year, strFtime('%m',date) as Month";
            SQL = SQL + " , strFtime('%m/%d/%Y',Review.Date) as Date, Review.Note, Review.Barriers, Job.Title as Job, Job.Employer";
            SQL = SQL + " , Staff.FirstName || ' ' || Staff.LastName as Staff, Meeting.Description as MeetingType";
            SQL = SQL + " , Review.Note , Review.TimeIn, Review.TimeOut";
            SQL = SQL + " From Review";
            SQL = SQL + " Left Join Job on Review.Job_ID = Job.ID";
	        SQL = SQL + " Join Consumer on Review.Consumer_ID = Consumer.ID";
	        SQL = SQL + " Join Meeting on Review.Meeting_ID = Meeting.ID";
            SQL = SQL + " Join Staff on Review.Staff_ID = Staff.ID";
            SQL = SQL + " Where Review.Consumer_ID = '" + ConsumerID + "'";
            SQL = SQL + " and strFtime('%m',Date) = '" + Month + "'";
            SQL = SQL + " and strFtime('%Y',Date) = '" + Year + "'";

            return SQL;
        }

        public bool CreateFO(string strType)
        {
            System.Diagnostics.Process objProcess = new System.Diagnostics.Process();

            
            objProcess.StartInfo.WorkingDirectory = returnFopPath();
            string strPath = returnXSLPath();
            
            objProcess.StartInfo.FileName = "fop.bat";
            if (strType == "Activity Log")
            {
                objProcess.StartInfo.Arguments = "-xml %Temp%\\ActivityLog.xml -xsl "  + strPath + "\\ActivityLog.xsl -pdf %Temp%\\ActivityLog.pdf";
            }
            else if (strType == "Monthly Activity Log")
            {
                objProcess.StartInfo.Arguments = "-xml %Temp%\\MonthlyActivityLog.xml -xsl " +  strPath + "\\MonthlyActivityLog.xsl  -pdf %Temp%\\MonthlyActivityLog.pdf";
            }
            objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
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

        private string returnFopPath()
        {
            string strPath = Directory.GetCurrentDirectory();
            if (strPath.Contains("(x86)") == true)
            {
                strPath = "c:\\Progra~2\\HTC\\fop";
            }
            else
            {
                strPath = "c:\\Progra~1\\HTC\\fop";
            }

            return strPath;
        }

        private string returnXSLPath()
        {
            string strPath = Directory.GetCurrentDirectory();
            if (strPath.Contains("(x86)") == true)
            {
                strPath = "c:\\Progra~2\\HTC\\Pinnacle\\Reports\\ActivityLog"; 
            }
            else
            {
                strPath = "c:\\Progra~1\\HTC\\Pinnacle\\Reports\\ActivityLog"; 
            }

            return strPath;
        }
        
        private float ReturnHours(string TimeIn, string TimeOut)
        {
            DateTime dtTimeIn = Convert.ToDateTime(TimeIn);
            DateTime dtTimeOut = Convert.ToDateTime(TimeOut);

            TimeSpan dtTotalTime = dtTimeOut - dtTimeIn;
            float fltTime = (float)dtTotalTime.TotalMinutes / 60;

            return fltTime;
        }
    }
}
