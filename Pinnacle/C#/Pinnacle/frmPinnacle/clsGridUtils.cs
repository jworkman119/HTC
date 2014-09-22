using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace frmPinnacle
{
    class clsGridUtils
    {
        public void fillGrid(SQLiteDataReader objReader, int ColStart,ref DataGridView Grid, Graphics objGraphics)
        {
            clsFormat objFormat = new clsFormat();
            int[] colW = new int[objReader.FieldCount];
            
            //Setting rows and columns
            Grid.Columns.Clear();
            Grid.Rows.Clear();
            int Row = 0;
            Grid.ColumnCount = objReader.FieldCount;
            
            //Adding Data
            while (objReader.Read())
            {
                SizeF objSize;
                Grid.Rows.Add();

                for (int Col = 0; Col < objReader.FieldCount; Col++)
                {

                    if (Row == 0)
                    {
                        string strHeader = objReader.GetName(Col);
                        Grid.Columns[Col].HeaderText = objReader.GetName(Col);
                        objSize = objGraphics.MeasureString(objReader.GetName(Col), Grid.Font);
                        if (Col >= ColStart)
                            colW[Col] = (int)objSize.Width;
                    }

                    string strValue = "";
                    if(objReader.GetDataTypeName(Col)=="Time")
                        strValue = objFormat.convertTime_12hr(objReader.GetDateTime(Col));
                    else
                        strValue = objReader[Col].ToString();

                    objSize = objGraphics.MeasureString(strValue.Trim(), Grid.Font);
                    if (objSize.Width > colW[Col] && Col > 0)
                    {
                        if (Col >= ColStart)
                            colW[Col] = (int)objSize.Width;
                    }

                    Grid[Col, Row].Value = strValue;

                }

                Row++;
            }

            //                grdActivity.AutoResizeColumns();
            AdjustGrid(colW, Grid.Columns.Count - ColStart, ColStart, ref Grid);


            if (Grid.RowCount > 0)
                Grid.Rows[0].Selected = false;

            
        }

        private void AdjustGrid(int[] colW, int intFields, int colStart, ref DataGridView Grid)
        {
            //Grid.Width = 825;
            int intTotal = colW.Sum();
            float fltAddTo = (float)(Grid.Width - intTotal) / (intFields);
            int j;

            //Resizing rows
            for (j = colStart; j < colW.Length; j++)
            {
                if (fltAddTo > 0 && j >= colStart)
                {
                    Grid.Columns[j].Width = (int)((float)colW[j] + fltAddTo);

                }
                else
                {
                    Grid.Columns[j].Width = colW[j];
                }
            }


            Grid.Columns[0].Visible = false;
                
            //hiding columns with IDs, that are only needed for DB purposes.
            if (colStart > 0)
            {
                for (j = colStart - 1; j >= 0; j--)
                {
                    Grid.Columns[j].Visible = false;
                }
            }
           
            Grid.Width = (int)(intTotal + (fltAddTo * (float)intFields - 1));
        }
    }
}
