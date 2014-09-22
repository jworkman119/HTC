using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Data.OleDb;
using Microsoft.Office.Interop.Access;




namespace HiTechnic
{
    class clsAccess
    {
        private string DBPath;

        public clsAccess(string strDBPath)
        {
            DBPath = strDBPath;
        }


        //Calls procedure in Access
        public int AddData(string strSQL)
        {
            OleDbConnection objConnection = MakeDBConnection();

            OleDbCommand objCommand = new OleDbCommand(strSQL);
            objCommand.CommandType = System.Data.CommandType.Text; 

            objConnection.Open();
            objCommand.Connection = objConnection;
            int intRows = objCommand.ExecuteNonQuery();
            objConnection.Close();

            return intRows;
        }

        public DataTable ReturnData(string strSQL)
        {
            OleDbConnection objConnection = MakeDBConnection();

            OleDbCommand objCommand = new OleDbCommand(strSQL);
            objCommand.CommandType = System.Data.CommandType.Text;

            objConnection.Open();
            objCommand.Connection = objConnection;
            OleDbDataReader objReader = objCommand.ExecuteReader();

            DataTable objTable = new DataTable();
            objTable.Load(objReader);
            return objTable;
        }

        private OleDbConnection MakeDBConnection()
        {
            string strConnection = "Data Source=" + DBPath + ";Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False";
            OleDbConnection objConnection = new OleDbConnection(strConnection);
            return objConnection;
        }


        public void PrintReports()
        {
            Microsoft.Office.Interop.Access.Application objAccess = new Microsoft.Office.Interop.Access.Application();


            objAccess.OpenCurrentDatabase(DBPath, false);

            // Print 2 copies of the selected object:
            objAccess.DoCmd.OpenReport("PickTicketAuto");
            objAccess.DoCmd.OpenReport("PickTicketAuto");

            objAccess.Visible = false;
            objAccess.CloseCurrentDatabase();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objAccess);
        }

        public void PrintReports2(string strRefNumber)
        {
            Microsoft.Office.Interop.Access.Application objAccess = new Microsoft.Office.Interop.Access.Application();
            objAccess.OpenCurrentDatabase(DBPath, false);

            objAccess.DoCmd.OpenForm("PickTicketFinal", AcFormView.acNormal, Type.Missing, Type.Missing, AcFormOpenDataMode.acFormPropertySettings, AcWindowMode.acHidden, Type.Missing);
            

            // Print 2 copies of the selected object:
            objAccess.DoCmd.OpenReport("PickTicketFinal");
            objAccess.DoCmd.OpenReport("PickTicketFinal");

            objAccess.Visible = false;
            objAccess.CloseCurrentDatabase();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objAccess);
        }
       
           
    
    }
}
