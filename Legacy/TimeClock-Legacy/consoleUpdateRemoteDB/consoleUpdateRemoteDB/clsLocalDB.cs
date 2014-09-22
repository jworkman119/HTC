using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace consoleUpdateRemoteDB
{
    class clsLocalDB
    {
        private SQLiteConnection sqlConnection;

        public clsLocalDB(string strDBPath)
        {
            // creating connection in constructor, so we only use 1 connection per session. Otherwise can overload DB.
            sqlConnection = new SQLiteConnection("Data Source=" + strDBPath);
            sqlConnection.Open();
        }

        // Destructor
        ~clsLocalDB()
        {
            sqlConnection.Close();
        }

        public SQLiteDataReader returnDataReader(string strSQL)
        {
            SQLiteCommand objCommand = new SQLiteCommand(sqlConnection);

            objCommand.CommandText = strSQL;
            return objCommand.ExecuteReader();
        }

        public int addMySQLID(int MySQLID, int SQLiteID)
        {
            int Rows = 0;
            SQLiteCommand objCommand = new SQLiteCommand(sqlConnection);

            string SQL = "Update remoteTime";
            SQL = SQL + " Set mySQL_ID = " + MySQLID.ToString();
            SQL = SQL + " , TimeIn_Added = 'true'";
            SQL = SQL + " Where ID = " + SQLiteID.ToString();

            objCommand.CommandText = SQL;
            Rows = objCommand.ExecuteNonQuery();

            return Rows;
        }

        public int updateTimeOut_Added(int SQLiteID)
        {
            int Rows = 0;
            SQLiteCommand objCommand = new SQLiteCommand(sqlConnection);

            string SQL = "Update remoteTime";
            SQL = SQL + " Set TimeOut_Added = 'true'";
            SQL = SQL + " Where ID = " + SQLiteID.ToString();

            objCommand.CommandText = SQL;
            Rows = objCommand.ExecuteNonQuery();

            return Rows;
        }

    }
}
