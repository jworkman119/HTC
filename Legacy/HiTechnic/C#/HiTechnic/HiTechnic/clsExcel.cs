using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ADODB;
using Microsoft.Office.Interop.Excel;


namespace HiTechnic
{
    class clsExcel
    {
        public void Return_SpreadSheet(string strSQL, string strPath)
        {
            ADODB.Connection adoConnection = new ADODB.Connection();
            ADODB.Recordset objRecordset = ReturnRecordset(strSQL,ref adoConnection);
            if (objRecordset.RecordCount > 0)
            {
                CreateSpreadSheet(objRecordset, strPath);
            }
        }

        
        private void CreateSpreadSheet(ADODB.Recordset objRS, string strPath)
        {
            
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook xlWB = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Sheets xlSheets = xlWB.Worksheets;
            Worksheet xlWS = new Worksheet();
            
            xlWS = xlSheets.get_Item(1);
            //adding headers to spreadsheet
            xlWS.Columns["AM"].NumberFormat="@";


            int t = 1;
            while(objRS.EOF != true)
            {
                
                for (int j = 0; j < objRS.Fields.Count; j++)
                {
                    if (t == 1)
                    {
                        
                        xlWS.Cells.set_Item(t, j + 1, objRS.Fields[j].Name.ToString());
                    }
                    // try - to catch bogus data that might appear in recordset (bad characters, etc.)
                    try
                    {
                        xlWS.Cells.set_Item(t + 1, j + 1, objRS.Fields[j].Value);
                    }
                    catch
                    {
                        xlWS.Cells.set_Item(t + 1, j + 1,"");
                    }

                }

                if (objRS.EOF != true)
                {
                    objRS.MoveNext();
                    t++;
                }
            
            }


            xlWS.Columns.AutoFit();
            if (File.Exists(strPath))
            {
                File.Delete(strPath);
            }

            xlWB.SaveAs(strPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            
            //Kill excel object from memory
            xlWB.Close();
            xlApp.Quit();
            
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWS);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWB);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            

            xlWS = null;
            xlWB = null;
            xlApp = null;

            GC.GetTotalMemory(false);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.GetTotalMemory(true);

            
        }

        private ADODB.Recordset ReturnRecordset(string strSQL,ref ADODB.Connection objConnection)
        {

            ADODB.Recordset rsDBase = new ADODB.Recordset();

            try
            {

                objConnection.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\\\fedex01dwyer\\fedex;Extended Properties=dBASE IV;");

                // objConnection.Execute("Select * from EPOSTAGE.dbf",rsDBase);
                
                rsDBase.Open(strSQL, objConnection, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, -1);
                
            }
            catch
            {
                
            }

            return rsDBase;
        
       }
            
    }
}
