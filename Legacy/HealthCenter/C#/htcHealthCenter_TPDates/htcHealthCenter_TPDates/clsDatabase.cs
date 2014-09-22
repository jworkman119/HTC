using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace htcHealthCenter_TPDates
{
    class clsDatabase
    {
        private string strError;
        private SQLiteConnection sqlConnection;

        public clsDatabase(string dbPath)
        {
            // creating connection in constructor, so we only use 1 connection per session. Otherwise can overload DB.
            sqlConnection = new SQLiteConnection("Data Source=" + dbPath);
            sqlConnection.Open();
        }

        // Destructor
        ~ clsDatabase()
        {
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        public string Error
        {
            get
            {
                return strError;
            }
        }

        public SQLiteDataReader returnDataReader(string strSQL)
        {
            SQLiteCommand objCommand = new SQLiteCommand(sqlConnection);

            objCommand.CommandText = strSQL;
            return objCommand.ExecuteReader();
        }

        public bool ExecuteNonQuery(string strSQL)
        {
            bool blPass = true;

            SQLiteCommand objCommand = new SQLiteCommand(sqlConnection);

            // Todo - need to change to so it works as a transaction, for deleting entries from
            objCommand.CommandText = strSQL;
            int intRows = objCommand.ExecuteNonQuery();
            if (intRows > 0)
            {
                blPass = true;
            }

            return blPass;
        }

    }
}
