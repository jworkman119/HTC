using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace Hitechnic_Billing
{
    class clsBilling
    {
        public void ProcessBill()
        {
            int intMonth=0, intYear=0;
            clsDB_Billing objDB = new clsDB_Billing(HiTecBilling.DBPath);
            SQLiteDataReader objShippers, objShipments;
            int Cols = 0;
            
            Retrieve_PreviousMonth(ref intMonth,ref intYear);
            string strMonth = intMonth.ToString("00");
            string strYear = intYear.ToString();
            
            // Todo move next two lines to resource file
            string strFileName = "HT_Bill " + strMonth + " - " + strYear;
            string strWorkSheet = strMonth + " - " + strYear;
            clsExcel objXL = new clsExcel(strFileName,strWorkSheet);
            objShippers = objDB.returnShippers(strMonth, strYear);
            while (objShippers.Read())
            {
                string strShipper = objShippers[0].ToString();
                objShipments = objDB.returnBill(strShipper, strMonth, intYear.ToString());

                objXL.CreateExcel(objShipments, strMonth, strYear);
                Cols = objShipments.FieldCount;
            }
            objXL.TotalAllRows();
            objXL.ResizeColumns(Cols);
            objXL.SaveExcel();

            clsEmail objEmail = new clsEmail();
            string strPath = Path.GetTempPath() + "//" + strFileName + ".xlsx";
            string strResult = objEmail.MailBill(strMonth + "/" + strYear, strPath);
            if (strResult.IndexOf("Failure") > 0)
            {
                clsLogFile objLog = new clsLogFile();
                objLog.CreateLogFile(strResult);
            }
        }

        

        private void Retrieve_PreviousMonth(ref int Month, ref int Year)
        {
            if (System.DateTime.Today.Month != 1)
            {
                Month = System.DateTime.Today.Month - 1;
                Year = System.DateTime.Today.Year;
            }
            else
            {
                Month = 12;
                Year = System.DateTime.Today.Year - 1;
            }

            
        }

    }
}
