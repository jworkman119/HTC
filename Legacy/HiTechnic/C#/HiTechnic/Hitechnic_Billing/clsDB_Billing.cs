using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace Hitechnic_Billing
{
    class clsDB_Billing
    {
        private string strError;
        private SQLiteConnection sqlConnection;
        private string strOrderNumber;

                // Constructor
        public clsDB_Billing(string strDBPath)
        {
            // creating connection in constructor, so we only use 1 connection per session. Otherwise can overload DB.
            sqlConnection = new SQLiteConnection("Data Source=" + strDBPath);
            sqlConnection.Open();

        }

        // Destructor
        ~clsDB_Billing()
        {
            sqlConnection.Close();
            sqlConnection.Dispose();
        }


        public SQLiteDataReader returnShippers(string strMonth, string strYear)
        {
            SQLiteCommand sqlCommand = new SQLiteCommand(sqlConnection);

            string strSQL = returnShipperSQL(strMonth, strYear);
            sqlCommand.CommandText = strSQL;
            return sqlCommand.ExecuteReader();
        }


        public SQLiteDataReader returnBill(string strShipper,string strMonth, string strYear)
        {
            SQLiteCommand sqlCommand = new SQLiteCommand(sqlConnection);

            string strSQL = returnBillingSQL(strShipper, strMonth, strYear);
            sqlCommand.CommandText = strSQL;
            return sqlCommand.ExecuteReader();

        }

        private string returnBillingSQL(string strShipper, string strMonth, string strYear)
        {
            string strSQL = "Select Order_Number, Qty, HTC_Charges, Cost, strftime('%m-%d-%Y',Received) as Received,  '''' || Tracking as Tracking, Carrier";
            strSQL = strSQL + " FROM vwBilling";
            strSQL = strSQL + " WHERE strftime('%m',vwBilling.Received)='" + strMonth + "'";
            strSQL = strSQL + " AND strftime('%Y',vwBilling.Received)='" + strYear + "'";
            strSQL = strSQL + " AND Carrier = '" + strShipper + "'";
            
            return strSQL;
        }

        private string returnShipperSQL(string strMonth, string strYear)
        {
            string strSQL = "Select Distinct Carrier";
            strSQL = strSQL + " FROM vwBilling";
            strSQL = strSQL + " WHERE strftime('%m',vwBilling.Received)='" + strMonth + "'";
            strSQL = strSQL + " AND strftime('%Y',vwBilling.Received)='" + strYear + "'";
            strSQL = strSQL + " Order by Carrier";
            return strSQL;
        }
    }
}
