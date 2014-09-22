using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace Hitechnic_Billing
{
    class clsDatabase
    {
        private string strError;
        private SQLiteConnection sqlConnection;
        
        // Constructor
        public clsDatabase(string strDBPath)
        {
            // creating connection in constructor, so we only use 1 connection per session. Otherwise can overload DB.
            sqlConnection = new SQLiteConnection("Data Source=" + strDBPath);
            sqlConnection.Open();

        }

        // Destructor
        ~clsDatabase()
        {
            sqlConnection.Close();
        }

        public SQLiteDataReader returnData(string strMonth, string strYear)
        {
            SQLiteCommand sqlCommand = new SQLiteCommand(sqlConnection);
            sqlCommand.CommandText = BillingSQL(strMonth, strYear);
                        
            SQLiteDataReader objReader = sqlCommand.ExecuteReader();
            return objReader;
        }

        private string BillingSQL(string strMonth, string strYear)
        {
            string strSQL = "SELECT Orders.Number, sum(OrderDetails.Qty) as Qty";
            strSQL = strSQL + " , CASE WHEN SUM(OrderDetails.Qty) > 19 THEN	7.80";
            strSQL = strSQL + " ELSE ROUND(SUM(OrderDetails.Qty) * .23,2) END AS HTC_Charges";
            strSQL = strSQL + " , strftime( '%m/%d/%Y',Orders.TS) AS Received";
            strSQL = strSQL + " , CASE WHEN Tracking.ShipMethod = 'UPS' THEN 'UPS'";
            strSQL = strSQL + " WHEN substr(Tracking.ShipMethod,0,5) = 'FedEx' THEN	'FedEx'";
            strSQL = strSQL + " ELSE 'USPS' End as ShipMethod";
            strSQL = strSQL + " FROM Orders JOIN OrderDetails ON Orders.Number = OrderDetails.Orders_Number";
            strSQL = strSQL + " JOIN Tracking ON Orders.Number = Tracking.Orders_Number";
            strSQL = strSQL + " WHERE strftime('%m',Orders.ts) = '" + strMonth + "'";
	        strSQL = strSQL + " AND strftime('%Y',Orders.ts)='" + strYear + "'";
            strSQL = strSQL + " GROUP BY Orders.Number";
            strSQL = strSQL + " ORDER BY ShipMethod, Orders.TS";
            return strSQL;
        }
    }
}
