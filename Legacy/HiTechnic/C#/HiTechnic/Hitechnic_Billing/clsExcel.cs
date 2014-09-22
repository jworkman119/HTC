using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using ClosedXML.Excel;
using System.Collections;

namespace Hitechnic_Billing
{
    class clsExcel
    {
        XLWorkbook objWB = new XLWorkbook();
        IXLWorksheet objWS;
        int Row;
        string FileName;
        ArrayList objRowsToTotal = new ArrayList();

        public clsExcel(string strFileName, string strWorkSheet)
        {

            FileName = Path.GetTempPath()  + strFileName + ".xlsx";
            objWS = objWB.AddWorksheet(strWorkSheet);
            Row = 2;
        }


        ~clsExcel()
        {
            SaveExcel();
        }

        public void CreateExcel(SQLiteDataReader objReader, string strMonth, string strYear)
        {
            if (Row == 2)
            {
                FormatHeaders(objReader, strMonth, strYear);
            }
            AddData(objReader);
        }

        public void SaveExcel()
        {
            objWB.SaveAs(FileName);
        }

        // used to provide name, and headers
        private void FormatHeaders(SQLiteDataReader objReader, string strMonth, string strYear)
        {
            objWS.Name = strMonth + " - " + strYear;

            int Cols = objReader.FieldCount -1;
            for (int Col = 0; Col < Cols; Col++)
            {
                objWS.Cell(1, Col + 2).Value = objReader.GetName(Col);
            }
            //Formatting Headers
            var objTable = objWS.Range(1,2,1,7);
            var objHRow = objTable.AsRange();

            objHRow.Style.Font.Bold = true;
            objHRow.Style.Font.FontName = "Calibri";
            objHRow.Style.Font.FontSize = 10;
            objHRow.Style.Font.Underline = XLFontUnderlineValues.Single;

        }

        private void FormatColHeader(int EndRow)
        {
            var objTable = objWS.Range(1,1,EndRow,1);
            var objHRow = objTable.AsRange();

            objHRow.Style.Font.Bold = true;
            objHRow.Style.Font.FontName = "Calibri";
            objHRow.Style.Font.FontSize = 10;
        }

        //Adds Data to spreadSheet
        private void AddData(SQLiteDataReader objReader)
        {
            int Cols = objReader.FieldCount -1;
            int StartRow = Row;
            string strPreviousOrder="";
            string Carrier = objReader[Cols].ToString();            
            
            while (objReader.Read())
            {
                for (int Col = 0; Col < Cols; Col++)
                {
                    /* Checks to see if there is multiple lines for the same order. This is usually caused
                        by an Order having multiple shipments producing multiple lines.*/
                    if (strPreviousOrder == objReader[0].ToString() && Col==1)
                    {
                        Col = 4;
                    }
                    objWS.Cell(Row, Col + 2).Value = objReader[Col];
                    if (Col >= 2 && Col <= 3)
                    {
                        objWS.Cell(Row, Col+2).Style.NumberFormat.Format = "#,##0.00";
                    }
                }
                strPreviousOrder = objReader[0].ToString();    
                Row++;
                
            }
            
            //Adding Formula 
            int EndRow = Row - 1;
            setFormula(Row,StartRow, EndRow,Carrier);

            //formatting data
            var objTable = objWS.Range(StartRow, 1, Row, objReader.FieldCount);
            var objRange = objTable.AsRange();
            objRange.Style.Font.FontName = "Courier New";
            objRange.Style.Font.FontSize=10;

            
        }


        private void setFormula(int CurrentRow, int StartRow,int EndRow,string Carrier)
        {

            objWS.Cell(StartRow, 1).Value = Carrier;
            for (int j = 3; j <= 5; j++)
            {
                var sumQty = objWS.Cell(CurrentRow, j);
                char letter = (char)('A' + (j - 1) % 26);
                string strFormula = "=sum(" + letter + StartRow.ToString() + ":" + letter + EndRow + ")";
                sumQty.FormulaA1 = strFormula;
                
            }
            objWS.Cell(CurrentRow, 1).Value = Carrier + " Total";
            // Adding to array list to be totaled later
            objRowsToTotal.Add(CurrentRow.ToString());
            Row = Row + 2;
        }

        public void ResizeColumns(int Cols)
        {
            objWS.Columns(1,Cols).AdjustToContents();
        }

        public void TotalAllRows()
        {
            int CurrentRow = Row + 1;
            objWS.Cell(CurrentRow, 1).Value = "Grand Total";
            
            for (int j = 3; j <= 5; j++)
            {
                var xlCell = objWS.Cell(CurrentRow, j);
                char letter = (char)('A' + (j - 1) % 26);

                string strFormula = "=sum(" + letter +  string.Join(","+letter, (string[])objRowsToTotal.ToArray(Type.GetType("System.String")))  + ")";
                xlCell.FormulaA1 = strFormula;

            }

            FormatColHeader(CurrentRow);
            objRowsToTotal.Add(CurrentRow);
            FormatTotalRows();
        }

        private void FormatTotalRows()
        {
            for (int j = 0; j < objRowsToTotal.Count; j++)
            {
                var objTable = objWS.Range(Convert.ToInt16(objRowsToTotal[j]), 1, Convert.ToInt16(objRowsToTotal[j]), 5);
                var objRange = objTable.AsRange();
                objRange.Style.Font.FontName = "Calibri";
                objRange.Style.Font.Bold = true;
                objRange.Style.Font.FontSize = 10;

                objWS.Cell(Convert.ToInt16(objRowsToTotal[j]), 4).Style.NumberFormat.Format = "$#,##0.00";
                objWS.Cell(Convert.ToInt16(objRowsToTotal[j]), 5).Style.NumberFormat.Format = "$#,##0.00";
            }
        }
    }
}
