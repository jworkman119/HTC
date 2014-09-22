using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace emailTotalHours
{
    class clsDB
    {
         private string strError;
        private SQLiteConnection sqlConnection;
        
        // Constructor
        public clsDB(string strDBPath)
        {
            // creating connection in constructor, so we only use 1 connection per session. Otherwise can overload DB.
            sqlConnection = new SQLiteConnection("Data Source=" + strDBPath);
            sqlConnection.Open();

        }

        // Destructor
        ~clsDB()
        {
            sqlConnection.Close();
        }

        public SQLiteDataReader returnData(string Type, int Month, string Year)
        {
            string SQL = returnHoursSQL(Month, Year, Type);
            SQLiteDataReader objReader = returnDataReader(SQL);

            return objReader;
        }

        public SQLiteDataReader returnHeaders()
        {
            string SQL = "Select * From ReportColumns Order By ID";
            SQLiteDataReader objReader = returnDataReader(SQL);

            return objReader;
        }

        private SQLiteDataReader returnDataReader(string SQL)
        {
            SQLiteCommand sqlCommand = new SQLiteCommand(sqlConnection);
            sqlCommand.CommandText = SQL;
            SQLiteDataReader objReader = sqlCommand.ExecuteReader();

            return objReader;
        }

        private string returnHoursSQL(int intMonth, string Year, string Type)
        {
            string strMonth = intMonth.ToString();
            if (intMonth < 10)
                strMonth = "0" + strMonth;

            string SQL = "Select ReportColumns.Name as Funding_ID, ReportColumns.ID as Column";
            SQL = SQL + " , Staff.FirstName || ' ' || Staff.LastName as Staff";
            SQL = SQL + " , Round(Avg(ReviewCost.PayRate),2) as Avg_PayRate";
            SQL = SQL + " , Round(sum(ReviewCost.Hours),2) as Hours";
            SQL = SQL + " , Round(sum(ReviewCost.Cost),2) as Cost";
            SQL = SQL + " From ReportColumns, Staff";
            SQL = SQL + " Left Join ReviewCost on ReviewCost.Funding_ID = ReportColumns.Name ";

            if (Type == "Month")
                SQL = SQL + "AND strftime('%m',ReviewCost.Date) ='" + strMonth + "'";
            else
                SQL = SQL + "AND strftime('%m',ReviewCost.Date) in (" + returnQtr(intMonth) + ")";

            SQL = SQL + " AND strftime('%Y',Date) ='" + Year + "'";
            SQL = SQL + " AND ReviewCost.Staff_ID = Staff.ID";
            SQL = SQL + " WHERE Staff.Role_ID = 'Stf'"; 
            SQL = SQL + " and  Staff.Active = 'true'";
            SQL = SQL + " GROUP BY  ReportColumns.Name, ReportColumns.ID, Staff.ID";
            SQL = SQL + " Order By Staff, ReportColumns.Name";
            return SQL;
        }

        private string returnQtr(int intMonth)
        {
            string qtr="";
            for (int j = 0; j < 3; j++)
            {
                if(intMonth<10)
                    qtr = qtr + ",'0" + intMonth.ToString() + "'";
                else
                    qtr = qtr + ",'" + intMonth.ToString() + "'";
                intMonth--;
            }

            qtr = qtr.Substring(1);
            return qtr;
        }
    }
}
