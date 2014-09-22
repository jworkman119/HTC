using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Xml;
using System.IO;
using System.Globalization;

namespace emailTotalHours
{
    class clsCreateXML
    {
        string _Year;
        int _Qtr;
        int _Month;

        public int Month
        {
            set
            {
                this._Month = value;
            }
        }

        public int Qtr
        {
            set
            {
                this._Qtr = value;
            }
        }

        public string Year
        {
            set
            {
                this._Year = value;
            }
        }

        public void createXML(string Type)
        {
            SQLiteDataReader objReader = returnDataReader(Type);

            string strActivityLogPath = Path.GetTempPath();
            if (Type=="Month")
                strActivityLogPath = strActivityLogPath + "pinnacleMonthlyCosts.xml";
            else
                strActivityLogPath = strActivityLogPath + "pinnacleQtrCosts.xml";

            XmlWriter xmlWrite = XmlWriter.Create(strActivityLogPath);
            xmlWrite.WriteStartElement("ReviewCosts");
                xmlWrite.WriteStartElement("Header");

                xmlWrite.WriteStartElement("TimeFrame");
                xmlWrite.WriteAttributeString("Type", Type);
                
                if (Type == "Month")
                {
                        xmlWrite.WriteElementString("Period", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(_Month));

                }
                else
                {
                        xmlWrite.WriteElementString("Period", returnOrdinal(_Month / 3) + " Qtr");
                }
                    xmlWrite.WriteEndElement(); // TimeFrame
                    xmlWrite.WriteElementString("Year", _Year);

                xmlWrite.WriteEndElement(); // Header
                
                xmlWrite.WriteStartElement("Body");

                xmlWrite.WriteStartElement("Table");
                    // Entering Headers     
                    addTableHeaders(ref xmlWrite);    

                    // Entering Staff Data - will be in table body of report
                    addTableData(ref xmlWrite, objReader);

                xmlWrite.WriteEndElement();//Table

                xmlWrite.WriteEndElement();//Body

                xmlWrite.Close();
        }

        private void addTableHeaders(ref XmlWriter xmlWrite)
        {
            clsDB objDB = new clsDB(staticVariables.dbPath);
            SQLiteDataReader objReader = objDB.returnHeaders();

            xmlWrite.WriteStartElement("Headers");
            while (objReader.Read())
            {
                xmlWrite.WriteStartElement("Column");
                    xmlWrite.WriteElementString("Header", objReader["Name"].ToString());
                xmlWrite.WriteEndElement();
            }
            xmlWrite.WriteEndElement();
        }

        private void addTableData(ref XmlWriter xmlWrite, SQLiteDataReader objReader)
        {
            string strStaff = "";

            xmlWrite.WriteStartElement("TableBody");

            while (objReader.Read())
            {
                if (strStaff != objReader["Staff"].ToString())
                {
                    if (strStaff != "")
                    {
                        xmlWrite.WriteEndElement();//Staff
                        xmlWrite.WriteEndElement();//Funds
                    }

                    xmlWrite.WriteStartElement("Staff");
                    xmlWrite.WriteAttributeString("Name", objReader["Staff"].ToString());
                    strStaff = objReader["Staff"].ToString();
                    xmlWrite.WriteStartElement("Funds");
                }

                xmlWrite.WriteStartElement("Fund");
                xmlWrite.WriteAttributeString("Name", objReader["Funding_ID"].ToString());
                xmlWrite.WriteElementString("Hours", objReader["Hours"].ToString());
                if (objReader.IsDBNull(objReader.GetOrdinal("Cost")) != true)
                {
                    decimal decCost = Convert.ToDecimal(objReader["Cost"]);
                    string strCost = string.Format("{0:C}", decCost);
                    xmlWrite.WriteElementString("Cost", strCost);
                }
                else
                    xmlWrite.WriteElementString("Cost", "");

                xmlWrite.WriteEndElement(); //Fund
            }

            xmlWrite.WriteEndElement();//Funds
            xmlWrite.WriteEndElement();//Staff
            xmlWrite.WriteEndElement();// TableBody
        }

        public string returnOrdinal(int Number)
        {
            string strNumber;
            switch (Number)
            {
                case 1:
                    strNumber = Number.ToString() + "st";
                    break;
                case 2:
                    strNumber =  Number.ToString() + "nd";
                    break;
                case 3:
                    strNumber =  Number.ToString() + "rd";
                    break;
                default:
                    strNumber =  Number.ToString() + "th";
                    break;
            }

            return strNumber;
        }

        private SQLiteDataReader returnDataReader(string strType)
        {
            clsDB objDB = new clsDB(staticVariables.dbPath);
            
            SQLiteDataReader objReader = objDB.returnData(strType, _Month, _Year);
            
            return objReader;
        }
    }
}
