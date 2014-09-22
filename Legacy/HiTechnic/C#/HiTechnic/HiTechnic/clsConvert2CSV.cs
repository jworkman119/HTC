using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;

namespace HiTechnic
{
    class clsConvert2CSV
    {
        public int Rows;

        public void convertExcelToCSV(string sourceFile, string worksheetName, string targetFile)
        {

            string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + sourceFile + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"";

            OleDbConnection conn = null;
            StreamWriter wrtr = null;
            OleDbCommand cmd = null;
            OleDbDataAdapter da = null;

            try
            {
                conn = new OleDbConnection(strConn);
                conn.Open();
                cmd = new OleDbCommand("SELECT * FROM [" + worksheetName + "$]", conn);
                cmd.CommandType = CommandType.Text;
                wrtr = new StreamWriter(targetFile);

                da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //Returning rows, so I know where to stop page breaks in xsl-fo (packing slip)
                Rows = dt.Rows.Count;

                //moving data from datatable to .csv via text stream.
                for (int x = 0; x < dt.Rows.Count; x++)
                    {
                        string rowString = "";
                        for (int y = 0; y < dt.Columns.Count; y++)
                        {
                            rowString += dt.Rows[x][y].ToString() + "|";
                        }
                        //writing data to file
                        wrtr.WriteLine(rowString);

                }

            }

            catch (Exception exc)
            {
                
                Console.WriteLine(exc.ToString());
                Console.ReadLine();

            }

            finally
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                    cmd.Dispose();
                    if (da != null)
                    {
                        da.Dispose();
                    }
                    if (wrtr != null)
                    {
                        wrtr.Close();
                        wrtr.Dispose();
                    }
                }
            }
        }

    }
}
