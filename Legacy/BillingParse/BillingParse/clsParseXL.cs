using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using ExcelLibrary.SpreadSheet;
using MySql.Data.MySqlClient;

namespace BillingParse
{
    class clsParseXL
    {
        private string strPath;
        private string strDate;
        private string strSupervisor;
        private string strErrors;
        private string strTimeOfDay;
        private MySqlConnection objConnection; 
        
        public string Errors
        {
            get
            {
                return strErrors;
            }
        }


        public string Path
        {
            set
            {
                strPath = value;
            }

        }

        public string Date
        {
            set
            {
                strDate = value;
            }

        }

        public bool ParseFile()
        {
            bool blSuccess = false;
            clsMySQLConnection objConnect = new clsMySQLConnection();
            objConnection = objConnect.Create_MySQLConnection();

            DeleteWorkersForDay();
            StreamXL(strPath);
            objConnection.Close();
            return blSuccess;
        }

        private bool StreamXL(string strPath)
        {
            bool blSuccess = false;
            Workbook xlWB = Workbook.Load(strPath);

            for (int j = 0; j < xlWB.Worksheets.Count; j++)
            {
                ExcelLibrary.SpreadSheet.Worksheet xlSheet = xlWB.Worksheets[j];
                string strName = xlSheet.Name;
                strName = strName.Replace("'", "''");


                bool blVerify = VerifySpreadSheet(strName);
                if (blVerify == true)
                {
                    TraverseSpreadsheet(xlSheet);
                }
            }
            
            return blSuccess;    
        }


        private bool VerifySpreadSheet(string strName)
        {
            if (strName.IndexOf("Morning") > 0)
            {
                
                strTimeOfDay = "Morning";
                return true;
            }
            else if (strName.IndexOf("Evening") > 0)
            {
                strTimeOfDay = "Evening";
                return true;
            }
            else if (strName.IndexOf("Overnight") > 0)
            {
                strTimeOfDay = "Overnight";
                return true;
            }
            else
            {
                return false;
            }
        }



        private void TraverseSpreadsheet(Worksheet xlSheet)
        {
            string strWorker;
            string strZone="";

            // traverse rows by Index
            int intUpdateCol = GetColumnToUpdate(xlSheet.Cells.GetRow(0));
            if (intUpdateCol > 0)
            {
                for (int j = 1; j <= xlSheet.Cells.LastRowIndex; j++)
                {
                    Row row = xlSheet.Cells.GetRow(j);
                    Cell xlCell = row.GetCell(intUpdateCol);
                    strWorker = xlCell.StringValue.Trim();
                    strWorker = strWorker.Replace("'", "''");
                    Cell xlZone = row.GetCell(1);
                    
                    if (xlZone.IsEmpty == false)
                    {
                        strZone = xlZone.ToString();
                    }

                    if (strWorker.Length > 4)
                    {
                        Cell xlTime = row.GetCell(0);
                        string strTime = xlTime.ToString();
                        if (strTime.Trim() == "" || strWorker == "")
                        {
                            strErrors = strErrors + "|" + strWorker + " - " + strTime + "-" + " - Zone=" + strZone; 
                        }
                        else
                        {
                            UploadPerson2Schedule(strWorker, strTime, strZone);
                        }
                    }
                    
                }
            }
        }

        private void DeleteWorkersForDay()
        {
            
            xlUpload2DB Upload2DB = new xlUpload2DB();
            string strSQL = "Delete From Schedule where day ='" + FormatDate() + "'";

            Upload2DB.ExecuteScalar(strSQL,objConnection);
        }

        private void UploadPerson2Schedule(string strWorker, string strTime, string strZone)
        {
            string strSQL="";
            xlUpload2DB Upload2DB = new xlUpload2DB();

            string strTimeIn = "", strTimeOut = "";
            getTimes(strTime, ref strTimeIn, ref strTimeOut);
            string strDt = FormatDate();
                strSQL = "call addSchedule_Auto('" + strWorker + "','" + strZone + "','" + strDt + "','" + strTimeIn + "','" + strTimeOut + "')";
            
            int intRow = Upload2DB.ExecuteScalar(strSQL,objConnection);
            if (intRow == 0)
            {
                strErrors = strErrors + "|" + strWorker + " - " + strTimeIn + "-" + strTimeOut + " - Zone="  + strZone; 
            }
        }



        private void getTimes(string strShift, ref string strTimeIn, ref string strTimeOut)
        {
            xlUpload2DB Upload2DB = new xlUpload2DB();

            string[] arShift = strShift.Split('-');
            strTimeIn = Convert24Hr(arShift[0]);
            strTimeOut = Convert24Hr(arShift[1]);
        }

        private string Convert24Hr(string strTime)
        {
            int intHour;
            strTime = strTime.Trim();
            string[] arTime = strTime.Split(':');
            if (strTime.Substring(strTime.Length - 2, 2) == "pm")
            {
                
                int.TryParse(arTime[0], out intHour);

                if (intHour != 12)
                {
                    intHour = intHour + 12;
                }
                else
                {
                    intHour = 12;
                }
                strTime = intHour.ToString() + ":" + arTime[1];
            }
            else if(strTime.Substring(strTime.Length - 2, 2) == "am" && arTime[0] == "12")
            {
                int.TryParse(arTime[0], out intHour);

                intHour = 0;
                strTime = intHour.ToString() + ":" + arTime[1];
            }

            //removing am or pm
            strTime = strTime.Remove(strTime.Length - 2);
            return strTime;
        }

        private string FormatDate()
        {
            string[] arDate = strDate.Split('-');
            return System.DateTime.Now.Year.ToString() + "-" + arDate[0] + "-" + arDate[1];
        }

        private int GetColumnToUpdate(Row xlRow)
        {
            int intValue = 0;

            //traverse row and match date
            for (int j = 3; j <= xlRow.LastColIndex; j++)
            {
                Cell xlCell = xlRow.GetCell(j);

                
                if (xlCell.IsEmpty != true)
                {
                    string strCell = xlCell.DateTimeValue.Month.ToString() + "-" + xlCell.DateTimeValue.Day.ToString();
                    if (strCell == strDate)
                    {
                        intValue = j;
                    }
                }

                if (intValue > 0)
                {
                    break;
                }
                
            }

            return intValue;
        }


        private bool UpdateDB()
        {
            bool blSuccess = false;

            return blSuccess;
        }
    }
}
