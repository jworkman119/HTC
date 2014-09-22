using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClosedXML.Excel;
using System.Xml;
using System.ComponentModel;
using System.IO;
using System.Data;



namespace BillParse
{
    class clsParse2XL
    {
        public string parseFiles(string strDirectory, string[] fileNames)
        {
            // we only want the month and year from the file name
            string[] strName = fileNames[0].Split(' ').Where((x,index)=> index !=2).ToArray();
            string strWBName = string.Join("", strName) + ".xlsx";
            
            XLWorkbook xlWB = new XLWorkbook();
            
            for(int j = 0 ; j<fileNames.Length;j++)
            {
                string shtName = fileNames[j].Replace(".txt","");
                if (shtName.Length > 30)
                {
                    clsUnZip objUnzip = new clsUnZip();
                    shtName = objUnzip.RenameFile(shtName);
                }
                IXLWorksheet xlSht = xlWB.Worksheets.Add(shtName);
                int iRow = 2;
                iRow=streamFile(ref iRow,strDirectory, fileNames[j],ref xlSht,"C");


                addFormulas(xlSht, iRow, iRow + 2, "Debit");
                addFormulas(xlSht, iRow, iRow + 3, "Credit");

                addFormulas(xlSht, iRow, iRow + 5, "Grand Total");

                formatSheet(xlSht, iRow + 5);

            }

            string strFile = strDirectory + "//" + strWBName; 
            xlWB.SaveAs(strFile);
            return strFile;
        }


        //recursive function call - needed because we have to sort the data by credit/debits
        private int streamFile(ref int iRow, string strDirectory, string fileName,ref IXLWorksheet xlSheet,string strFilter)
        {
            List<Field> objFields = GetFields();
            if(iRow==2)
                xlSheet = addHeaders(objFields, xlSheet);

                string strFile = strDirectory + "\\" + fileName;
                StreamReader objStream = new StreamReader(strFile);
           
                string strLine;
           
                while ((strLine = objStream.ReadLine()) != null)
                {

                    if (strLine.Length == 128)
                    {
                        bool blProcessed = parseLine(strFilter, strLine, iRow, objFields, xlSheet);
                        if(blProcessed==true)
                            iRow++;
                    }

                }

                objStream.Close();

                if (strFilter == "C")
                    streamFile(ref iRow,strDirectory, fileName, ref xlSheet, "D");

                return iRow;
        }

        private bool parseLine(string strFilter, string strLine, int iRow, List<Field> objFields, IXLWorksheet xlSheet)
        {
            
            Field objCredDeb = returnField("Credit/Debit",objFields);
            string strCredit = strLine.Substring(objCredDeb.Start, objCredDeb.Length);
            bool blProcess = false;

            //Only parsing lines based on the filter (Credit or Debit)
            if (strCredit == strFilter)
            {
                int iCol = 1;
                foreach (Field objField in objFields)
                {
                    string sValue = formatValue(objField.Type, strLine.Substring(objField.Start, objField.Length).Trim());
                    if (objField.Name == "Credit/Debit")
                        strCredit = sValue;
                    if (strCredit == "C" && objField.Name == "Amount - Allowance Purchase")
                    {
                        formatCredit(xlSheet, sValue, iRow, iCol);
                    }
                    else
                    {
                        xlSheet.Cell(iRow, iCol).Value = sValue;
                    }
                    iCol++;
                }

                blProcess = true;
            }

            return blProcess;
        }

        private Field returnField(string strName, List<Field> objFields)
        {
            
            Field objInfo = objFields.Find(delegate(Field objField)
            {
                return objField.Name == strName;  
            });

            return objInfo;
        }

        private IXLWorksheet formatSheet(IXLWorksheet xlWorksheet,int iRows)
        {

            IXLRange objRange = xlWorksheet.Range("A2",Convert.ToChar(64+12)+iRows.ToString());

            objRange.Style.Font.SetFontName("Times New Roman");
            objRange.Style.Font.SetFontSize(8);

            xlWorksheet.Columns("7:10").Style.NumberFormat.Format = "#,##0.00";

            xlWorksheet.Columns(1, 12).AdjustToContents();
            return xlWorksheet;
        }

        private void addFormulas(IXLWorksheet xlWorksheet, int iRows, int iNewRow, string DebCred)
        {
            string Formula = "";
            int Col = 71; // ascii value for G

            string sDebCred = DebCred.Substring(0, 1);

            xlWorksheet.Cell(iNewRow,5).Value = DebCred;
            // if debit or credit
            for (int j = 7; j < 11; j++)
            {
                char cCol = Convert.ToChar(Col);
                if (sDebCred != "G")
                {
                    
                    Formula = "=SUMIF(F2:F" + iRows.ToString() + ",\"" + sDebCred + "\"," + cCol + "2" + ":" + cCol + iRows.ToString() + ")";
                    if(sDebCred == "D")
                        xlWorksheet.Cell(iNewRow, j).FormulaA1 = Formula;
                    else
                        xlWorksheet.Cell(iNewRow, j).FormulaA1 = Formula + "* -1";
                    
                }
                else
                {
                    string sRowDebit = cCol + Convert.ToString(iNewRow-3);
                    string sRowCredit = cCol + Convert.ToString(iNewRow-2);
                    Formula = "=Sum(" + sRowDebit + "," + sRowCredit + ")";
                    xlWorksheet.Cell(iNewRow, j).FormulaA1 = Formula;
                }

                Col++;
            }
            
        }

        private string formatValue(string sType, string sValue)
        {
            try
            {
                if (sType == "Date")
                    sValue = formatDate(sValue);
                else if (sType == "Currency")
                    sValue = formatCurrency(sValue);

                sValue.Trim();
            }
            catch
            {
                sValue = "";
            }
            return sValue;
        }

        private string formatCurrency(string strMoney)
        {
            double dblMoney= (float)(Convert.ToInt64(strMoney) * .01);
            dblMoney = Math.Round(dblMoney, 2);
            strMoney = String.Format("{0:#,##0.00}", dblMoney);
            return dblMoney.ToString();
        }

        private string formatDate(string strDate)
        {
            if (strDate.Trim().Length > 0)
            {
                strDate = strDate.Insert(2, "/");
                strDate = strDate.Insert(5, "/");
                DateTime objDate = Convert.ToDateTime(strDate);
                strDate = objDate.ToString("MM/dd/yyyy");
            }
            return strDate;
        }

        private IXLWorksheet addHeaders(List<Field> objFields,IXLWorksheet xlSheet)
        {
            int t = 1;
            foreach (Field objField in objFields)
            {
                xlSheet.Cell(1, t).Value = objField.Name;
                t++;
            }

            //Formatting the headers
            string sRange= "A1:" + (char)(64+t-1) + "1";
            var rngTable = xlSheet.Range(sRange);
            var rngHeaders = rngTable.Range(sRange); // The address is relative to rngTable (NOT the worksheet)
            rngHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rngHeaders.Style.Font.Bold = true;
            rngHeaders.Style.Font.SetUnderline();
            rngHeaders.Style.Font.SetFontName("Calibri");
            rngHeaders.Style.Font.SetFontSize(10);

            return xlSheet;
        }

        private List<Field> GetFields()
        {
            List<Field> fields = new List<Field>();
            XmlDocument xmlDoc = new XmlDocument();

            //Load the mapping file into the XmlDocument
            string strXMLPath = returnXMLPath();
            xmlDoc.Load(strXMLPath);

            //Load the field nodes.
            XmlNodeList fieldNodes = xmlDoc.SelectNodes("/BillFields/Field");

            //Loop through the nodes and create a field object
            // for each one.
            foreach (XmlNode fieldNode in fieldNodes)
            {
                Field field = new Field();

                //Set the field's name
                field.Name = fieldNode.InnerText;

                //Set the field's length
                field.Length = Convert.ToInt32(fieldNode.Attributes["Length"].Value);

                //Set the field's starting position
                field.Start = Convert.ToInt32(fieldNode.Attributes["Start"].Value);

                field.Type = fieldNode.Attributes["Type"].Value;
                //Add the field to the Field list.
                fields.Add(field);
            }

            return fields;
        }

        private IXLWorksheet formatCredit(IXLWorksheet xlSheet, string sValue, int iRow, int iCol)
        {
            float fValue = float.Parse(sValue) * -1;

            xlSheet.Cell(iRow, iCol).Value = fValue;
            if (fValue < 0)
                xlSheet.Cell(iRow, iCol).Style.Font.SetFontColor(XLColor.Red);

            return xlSheet;
        }

        private string returnXMLPath()
        {
            string strPath = Directory.GetCurrentDirectory();
            if (strPath.Contains("(x86)") == true)
            {
                strPath = "c:\\Progra~2\\HTC\\USFS\\usfsFields.xml";
            }
            else
            {
                strPath = "c:\\Progra~1\\HTC\\USFS\\usfsFields.xml";
            }

            return strPath;
        }
    }
}
