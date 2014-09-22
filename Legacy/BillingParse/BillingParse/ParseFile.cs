using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Office.Interop.Excel;

using System.Reflection;
using System.Windows.Forms;


namespace BillingParse
{
    class ParseFile
    {
        private struct USFS
        {
            public string Field;
            public int fldStart;
            public int fldLength;

        }

        private USFS[] arUSFS;
        private StreamWriter objWriter;
        private double[] dblTotals = new double[3];
        private string strYear = "";


        // constructor
        public ParseFile()
        {
            arUSFS = createUSFS();
        }

        public string ParseTheFile(string strOutputPath, string[] strFiles)
        {
            string strPath = OpenExcel_2dArray(strFiles, strOutputPath);
            return strPath;
        }

        //creates the USFS struct that will hold the fields to be parsed
        private USFS[] createUSFS()
        {
            USFS[] objUSFS;

            objUSFS = new USFS[12];

            objUSFS[0].Field = "Employee Name";
            objUSFS[0].fldLength = 30;
            objUSFS[0].fldStart = 22;

            objUSFS[1].Field = "Region";
            objUSFS[1].fldLength = 2;
            objUSFS[1].fldStart = 52;

            objUSFS[2].Field = "Unit";
            objUSFS[2].fldLength = 2;
            objUSFS[2].fldStart = 54;

            objUSFS[3].Field = "Order Entry Date";
            objUSFS[3].fldLength = 8;
            objUSFS[3].fldStart = 56;

            objUSFS[4].Field = "Credit Entry Date";
            objUSFS[4].fldLength = 8;
            objUSFS[4].fldStart = 64;


            objUSFS[5].Field = "Credit/Debit";
            objUSFS[5].fldLength = 1;
            objUSFS[5].fldStart = 72;

            objUSFS[6].Field = "Amount - Allowance Purchase";
            objUSFS[6].fldLength = 9;
            objUSFS[6].fldStart = 73;

            objUSFS[7].Field = "Amount - Unit Purchase - Ship";
            objUSFS[7].fldLength = 9;
            objUSFS[7].fldStart = 82;

            objUSFS[8].Field = "Amount - Unit Purchase";
            objUSFS[8].fldLength = 9;
            objUSFS[8].fldStart = 91;

            objUSFS[9].Field = "Amount - Personal Purchases";
            objUSFS[9].fldLength = 9;
            objUSFS[9].fldStart = 100;

            objUSFS[10].Field = "Order Number";
            objUSFS[10].fldLength = 7;
            objUSFS[10].fldStart = 109;

            objUSFS[11].Field = "Fiscal Year";
            objUSFS[11].fldLength = 4;
            objUSFS[11].fldStart = 124;

            return objUSFS;
        }


        private string ReturnFile(string strOutputPath, string[] strFiles, string strFilter)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            string strPath = "";
            int j, t = 1;
            double[] dblAmounts = new double[3];
            Workbook xlWB = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Sheets xlSheets = xlWB.Worksheets;
            Worksheet xlWS = new Worksheet();

            

            xlWS = xlSheets.get_Item(1);

            for (j = 0; j < strFiles.Length; j++)
            {
                t = 1;
                //adds new worksheet to workbook
                if (j > 0)
                {
                    xlWS = (Worksheet)xlSheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                }


                // Adding credits to spreadsheet
                dblAmounts = OpenExcel(ref t, "C", strFiles[j], ref xlWS);
                AddAmounts(ref t, dblAmounts, ref xlWS, "Credits");

                //Adding debits to spreadsheet
                dblAmounts = OpenExcel(ref t, "D", strFiles[j], ref xlWS);
                AddAmounts(ref t, dblAmounts, ref xlWS, "Debits");

                AddAmounts(ref t, dblTotals, ref xlWS, "Grand Total");
                //Naming worksheet
                xlWS.Name = strYear;

                xlWS.Columns.AutoFit();
                Range xlRange = xlWS.get_Range("A1", Missing.Value);
                xlRange.EntireRow.Font.Bold = true;
                xlRange.EntireRow.Font.Underline = true;
                
            }

            return strPath;
  
            }

        private string StreamFile(string strOutputPath, string[] strFiles, string strFilter)
        {

            string strPath, strNewLine = "";
            int j, t;
            double dblGTotal;

            //Create a new subfolder under the current active folder
            string newPath = System.IO.Path.Combine(strOutputPath, "NewBillingFile");

            // Create the subfolder
            System.IO.Directory.CreateDirectory(newPath);

            strPath = newPath + "\\" + "USFS_Billing-" + DateTime.Today.ToString("MM-dd-yyyy") + ".csv";

            objWriter = new StreamWriter(strPath);
            //Adding FieldName to top of file
            for (j = 0; j < arUSFS.Length - 1; j++)
            {
                strNewLine = strNewLine + "," + arUSFS[j].Field;
            }
            objWriter.WriteLine(strNewLine.Substring(1));

            for (j = 0; j < strFiles.Length; j++)
            {

                Process_File("C", objWriter, strFiles[j]);
                objWriter.WriteLine();
                objWriter.WriteLine();
                Process_File("D", objWriter, strFiles[j]);
                objWriter.WriteLine();
                objWriter.WriteLine();
                objWriter.WriteLine(",,,,,Debit/Credit Totals " + strYear + " , " + dblTotals[0].ToString() + "," + dblTotals[1].ToString() + "," + dblTotals[2].ToString());
                objWriter.WriteLine();
                dblGTotal = dblTotals[0] + dblTotals[1] + dblTotals[2];
                objWriter.WriteLine(",,,,,Grand Total " + strYear + " , " + dblGTotal.ToString());
                objWriter.WriteLine();
                for (t = 0; t < 3; t++)
                {
                    dblTotals[t] = 0;
                }
            }



            objWriter.Close();

            return strPath;
        }

        private void Process_File(string strFilter, StreamWriter objWriter, string strFile)
        {
            int t = 0, j = 0;
            string strType;
            string strLine, strNewLine;
            StreamReader objStream = new StreamReader(strFile);
            double[] dblAmounts = new double[3];


            //Printing output
            while ((strLine = objStream.ReadLine()) != null)
            {
                if (j == 0)
                {
                    objWriter.WriteLine();
                    strYear = strLine.Substring(arUSFS[11].fldStart, arUSFS[11].fldLength);
                    objWriter.WriteLine(arUSFS[11].Field + " - " + strYear);
                    j = 1;
                }
                strNewLine = "";
                if (strLine.Length == 128)
                {
                    strType = strLine.Substring(arUSFS[5].fldStart, arUSFS[5].fldLength);
                    if (strType == strFilter)
                    {
              //          objWriter.WriteLine(ParseLine(strLine, ref dblAmounts));
                    }

                }

            }

            if (strFilter == "C")
            {
                strType = "Credit";
            }
            else
            {
                strType = "Debit";
            }

            objWriter.WriteLine();
            objWriter.WriteLine(",,,,,Total Amount " + strType + " " + strYear + " , " + dblAmounts[0].ToString() + "," + dblAmounts[1].ToString() + "," + dblAmounts[2].ToString());
            objWriter.WriteLine();


            for (t = 0; t < 3; t++)
            {
                dblTotals[t] = dblTotals[t] + dblAmounts[t];
                dblAmounts[t] = 0;
            }

        }

        private double[] OpenExcel(ref int j, string strFilter, string strFile, ref Worksheet xlWS)
        {
            int t = 1, h = 65;
            string strLine, strType, strNewLine = "", strRange;
            double[] dblAmounts = new double[3];
            StreamReader objStream = new StreamReader(strFile);
            string[] strData;



            //Adding Headers
            if (j == 1)
            {
                for (t = 1; t <= arUSFS.Length - 1; t++)
                {
                    xlWS.Cells.set_Item(j, t, arUSFS[t - 1].Field);
                }
                j++;
            }
            //Adding Data
            while ((strLine = objStream.ReadLine()) != null)
            {
                if ((t == 1) && (strLine.Length == 128))
                {
                    strYear = strLine.Substring(arUSFS[11].fldStart, arUSFS[11].fldLength);
                }
                if (strLine.Length == 128)
                {

                    strType = strLine.Substring(arUSFS[5].fldStart, arUSFS[5].fldLength);
                    if (strType == strFilter)
                    {
                   //     strNewLine = ParseLine(strLine, strNewLine, arUSFS, ref dblAmounts);
                        strData = strNewLine.Split('|');
                        //Adding data to spreadsheet
                        for (t = 1; t <= strData.Length; t++)
                        {
                            //xlWS.Cells[j,t]= strData[t - 1].Trim();
                            xlWS.Cells.set_Item(j, t, (strData[t - 1].Trim()));
                        }
                        strNewLine = "";
                        j++;
                    }

                }

            }

            return dblAmounts;


        }

        private void AddAmounts(ref int t, double[] dblAmounts, ref Worksheet xlWS, string strType)
        {
            t = t + 1;
            xlWS.Cells.set_Item(t, 6, strType);

            int r, f = 0;
            for (r = 7; r < 10; r++)
            {
                xlWS.Cells.set_Item(t, r, dblAmounts[f]);
                dblTotals[f] = dblTotals[f] + dblAmounts[f];
                f++;
            }
            t = t + 2;
        }// End AddAmounts
 

        private string OpenExcel_2dArray(string[] strFiles, string strOutputPath)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            
            string[,] arData;
            char cColumn;
            string strRange, strPath;
            Range xlRange;
            int j;



            Workbook xlWB = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Sheets xlSheets = xlWB.Worksheets;
            _Worksheet xlWS;

            xlWS = (_Worksheet)xlSheets.get_Item(1);

            for (j = 0; j < strFiles.Length; j++)
            {
                //adds new worksheet to workbook
                if (j > 0)
                {
                    xlWS = xlSheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                }
                int t;
                for(t=0;t<3;t++){
                    dblTotals[t] = 0;
                }
                arData = Create2DArray(strFiles[j]);
                cColumn = Convert.ToChar(arData.GetLength(1) + 64);
                strRange = "A1:" + cColumn.ToString() + arData.GetLength(0).ToString();
                //strRange = String.Format("A1:{0}{1}", "L", 39);

                xlRange = xlWS.get_Range(strRange, Missing.Value);

                //xlRange.get_Resize(arData.GetLength(0), arData.GetLength(1));
                xlRange.set_Value(Type.Missing, arData);
                xlWS.Name = strYear;

                xlWS.Name = strYear;

                xlWS.Columns.AutoFit();
                xlRange = xlWS.get_Range("A1", Missing.Value);
                xlRange.EntireRow.Font.Bold = true;
                xlRange.EntireRow.Font.Underline = true;

                
                xlRange = xlWS.UsedRange;
                xlRange.Formula = xlRange.Value;
                
                
                                
            }

            //Create a new subfolder under the current active folder
            string newPath = System.IO.Path.Combine(strOutputPath, "NewBillingFile");

            // Create the subfolder
            System.IO.Directory.CreateDirectory(newPath);

            strPath = newPath + "\\" + "USFS_Billing-" + DateTime.Today.ToString("MM-dd-yyyy") + ".xls";
            System.IO.Directory.CreateDirectory(newPath);
            xlWB.SaveAs(@strPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            xlApp.Quit();

            return strPath;
        }
      
        private string[,] Create2DArray(string strFile)
        {
            StreamReader objStream = new StreamReader(strFile);
            string strLine;
            int j, t = 0;
            int intDebits = 0, intCredits = 0;
            int DebitSpot, CreditSpot;
            string strFilter;
            double[] dblAmounts = new double[4];
            double[] dblCredits = new double[4];
            double[] dblDebits = new double[4];
            double[] dblPersonal = new double[3];
            string[] strNewLine;

            string[,] arData = new string[ReturnRows(objStream, ref intDebits, ref intCredits), arUSFS.Length];

            //resetting stream to fill the array
            objStream.DiscardBufferedData();
            objStream.BaseStream.Seek(0, SeekOrigin.Begin);
            objStream.BaseStream.Position = 0;

            CreditSpot = 1;
            DebitSpot = arData.GetLength(0) - 5;

            //Adding Headers to Array
            for (j = 0; j < arUSFS.Length -1; j++)
            {
                arData[0, j] = arUSFS[j].Field;
            }

            //Filling array with data
            while ((strLine = objStream.ReadLine()) != null)
            {
                if (strLine.Length == 128)
                {
                    strFilter = strLine.Substring(arUSFS[5].fldStart, arUSFS[5].fldLength);
                    strYear = strLine.Substring(arUSFS[11].fldStart, arUSFS[11].fldLength);
                    strNewLine = ParseLine(strLine, ref dblAmounts, ref dblCredits, ref dblDebits).Split('|');
                    //Filling in Columns
                    for (j = 0; j < strNewLine.Length; j++)
                    {
                        if (strFilter == "C")
                        {

                            arData[CreditSpot, j] = strNewLine[j];
                        }
                        else if (strFilter == "D")
                        {
                            arData[DebitSpot, j] = strNewLine[j];
                        }


                    }

                    //Resetting Row for sort routine
                    if (strFilter == "C")
                    {
                        CreditSpot++;
                    }
                    else if (strFilter == "D")
                    {
                        DebitSpot--;
                    }

                    //Entering Amounts into array if applicable

                    if (t == intCredits + intDebits - 1)
                    {

                        AddAmounts(ref arData, intCredits + 2, "|||||Amount Credits|" + dblCredits[0].ToString("$ #,###.##") + "|" + dblCredits[1].ToString("$ #,###.##") + "|" + dblCredits[2].ToString("$ #,###.##") + "|" + dblCredits[3].ToString("$ #,###.##") + "|");

                        AddAmounts(ref arData, arData.GetLength(0) - 3, "|||||Amount Debits|" + dblDebits[0].ToString("$ #,###.##") + "|" + dblDebits[1].ToString("$ #,###.##") + "|" + dblDebits[2].ToString("$ #,###.##") + "|" + dblDebits[3].ToString("$ #,###.##") + "|");

                        AddAmounts(ref arData, arData.GetLength(0) - 1, "|||||Grand Totals|" + dblAmounts[0].ToString("$ #,###.##") + "|" + dblAmounts[1].ToString("$ #,###.##") + "|" + dblAmounts[2].ToString("$ #,###.##") + "|" + dblAmounts[3].ToString("$ #,###.##") + "|");
                    }
                    else
                    {
                        t++;
                    }
                }
            }
            objStream.Close();
            return arData;
        }

        private int ReturnRows(StreamReader objStream, ref int intDebits, ref int intCredits)
        {
            string strLine, strFilter, strType;
            int j = 0;


            while ((strLine = objStream.ReadLine()) != null)
            {

                if (strLine.Length == 128)
                {
                    strFilter = strLine.Substring(arUSFS[5].fldStart, arUSFS[5].fldLength);
                    j++;
                    switch (strFilter)
                    {
                        case "C":
                            intCredits++;
                            break;
                        case "D":
                            intDebits++;
                            break;
                    }
                }

            }
            return j + 8; //adding 7 places to accomodate for amounts + 1 for the Headers
        }

        private void AddAmounts(ref string[,] arData,int intSpot,string strLine)
        {
            int j;
            string[] strData;


            strData = strLine.Split('|');
            for (j = 0; j < strData.Length; j++)
            {
                arData[intSpot, j] = strData[j];
            }
        }

        private string ParseLine(string strLine, ref double[] dblAmounts, ref double[] dblCredits, ref double[] dblDebits)
        {

            int intAmount, j, t = 0, r=0;
            double dblAmount;
            string strAmount, strType = "";
            string strNewLine = "";


            strType = strLine.Substring(arUSFS[5].fldStart, arUSFS[5].fldLength);
            for (j = 0; j < arUSFS.Length - 1; j++)
            {
                // ToDo - work off IndexOf "Amount"
                intAmount = arUSFS[j].Field.IndexOf("Amount", 0);
                
                if (j >= 6 && j < 10)
                {
                    strAmount = strLine.Substring(arUSFS[j].fldStart, arUSFS[j].fldLength);
                    if (strType == "D") //Debits
                    {
                        dblAmount = Math.Round((Convert.ToDouble(strAmount) * .01),2); //debit
                        dblDebits[t] = dblDebits[t] + dblAmount;

                    }
                    else // credits
                    {
                        dblAmount = Math.Round((Convert.ToDouble(strAmount) * -.01),2); //credit
                        dblCredits[t] = dblCredits[t] + dblAmount;
                    }

                    dblAmounts[t] = dblAmounts[t] + dblAmount;
                    strNewLine = strNewLine + "|" + dblAmount.ToString();


                    //resetting array = 0, so it can total up amounts properly
                    if (t == 3)
                    {
                        t = 0;
                    }
                    else
                    {
                        t++;
                    }

                }
                else
                {

                    if (arUSFS[j].Field == "Credit/Debit")
                    {

                        strNewLine = strNewLine + "|" + strLine.Substring(arUSFS[j].fldStart, arUSFS[j].fldLength);
                    }
                    else if (arUSFS[j].Field == "Order Number")
                    {
                        Int64 intOrder;

                        intOrder = Convert.ToInt64(strLine.Substring(arUSFS[j].fldStart, arUSFS[j].fldLength));
                        strNewLine = strNewLine + "|" + intOrder.ToString();
                    }

                    else if (arUSFS[j].Field.IndexOf("Date", 0) > 0)
                    {
                        string strDate = strLine.Substring(arUSFS[j].fldStart, arUSFS[j].fldLength);
                        if (strDate.Trim().Length == 8)
                        {
                            try
                            {
                                DateTime dtDate = DateTime.ParseExact(strDate, "MMddyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                strDate = dtDate.ToString(@"MM-dd-yyyy");
                            }
                            catch
                            {
                                strDate = "";
                            }

                            strNewLine = strNewLine + "|" + strDate;
                        }
                        else
                        {
                            strNewLine = strNewLine + "|" + strDate;
                        }
                    }

                    else
                    {
                        strNewLine = strNewLine + "|" + strLine.Substring(arUSFS[j].fldStart, arUSFS[j].fldLength);
                    }

                }

            }

            return strNewLine.Substring(1);
        }
       
    }
}