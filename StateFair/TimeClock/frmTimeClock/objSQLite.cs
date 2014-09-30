using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace frmTimeClock
{
    class objSQLite
    {
        private DateTime dtInTime;
        private DateTime dtOutTime;
        private string strWorker;
        private string strStatus;
        private string strError;
        private bool blDoubleSwipe;


        /************** Properties ********************/
        public DateTime InTime
        {
            get { return dtInTime; }
        }

        public DateTime OutTime
        {
            get { return dtOutTime; }
        }

        public string Worker
        {
            get { return strWorker; }
        }

        public string Status
        {
            get { return strStatus; }
        }

        public string Error
        {
            get { return strError; }
        }

        public bool DoubleSwipe
        {
            get { return blDoubleSwipe; }
        }
        /*************** Functions *********************/
        public void UpdateDB(int intID)
        {
            DateTime dtTime = DateTime.Now;
            int InID = 0;
            string strTime = dtTime.ToString("yyyy-MM-dd HH:mm:ss");
            SQLiteConnection objConnection = CreateSQLite_Connection();
            strWorker = getWorker(intID, objConnection);
            strStatus = getStatus(intID, strTime, ref InID, objConnection);
            if (strStatus != "Double-Swipe")
                updateLocalDB(intID, strTime, strStatus, objConnection);

 //           objConnection.Close();
        }


        private string getStatus(int intPerson, string strTime, ref int InID, SQLiteConnection objConnection)
        {
            string SQL = "SELECT ID, LocalStatus, MAX(Time) as Time";
            SQL = SQL + " FROM Time";
            SQL = SQL + " WHERE Person_ID = " + intPerson.ToString();

            SQLiteCommand objCommand = new SQLiteCommand();
            objCommand.CommandText = SQL;
            objCommand.Connection = objConnection;
            SQLiteDataReader objReader = objCommand.ExecuteReader();

            string strStatus = "";
            while (objReader.Read())
            {
                strStatus = objReader["LocalStatus"].ToString();
                if (strStatus.Trim() == "In")
                {
                    DateTime dtLastTime = Convert.ToDateTime(objReader["Time"].ToString());
                    InID = Convert.ToInt32(objReader["ID"]);
                    strStatus = statusBasedOnTime(strStatus, Convert.ToDateTime(strTime), dtLastTime);
                }
                else
                {
                    dtInTime = Convert.ToDateTime(strTime);
                    strStatus = "In";
                }
            }


            // disposing of DataReaders
            objReader.Close();

            return strStatus;
        }

        private void updateLocalDB(int intPerson, string strTime, string strStatus, SQLiteConnection objConnection)
        {
            string strSQL = "";

            strSQL = "Insert into Time(Person_ID, Time, LocalStatus)";
            strSQL = strSQL + " Values(" + intPerson + ", '" + strTime + "','" + strStatus + "')";

            addData(objConnection, strSQL);
        }


        private string getWorker(int ID, SQLiteConnection objConnection)
        {
            string Person = "";

            string strSQL = "Select FirstName || ' ' || LastName as Person From Person Where ID = " + ID.ToString();

            SQLiteCommand objCommand = new SQLiteCommand();
            objCommand.CommandText = strSQL;
            objCommand.Connection = objConnection;
            SQLiteDataReader objReader = objCommand.ExecuteReader();

            while (objReader.Read())
            {
                Person = objReader["Person"].ToString();
            }

            // disposing of DataReaders
            objReader.Close();


            return Person;
        }


        private SQLiteConnection CreateSQLite_Connection()
        {
            string DB_Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\HTC\\StateFair\\TimeClock.sqlite" ;
            SQLiteConnection objConnection = new SQLiteConnection("Data Source="+DB_Path);

            try
            {
                objConnection.Open();
            }
            catch (SQLiteException ex)
            {
                strError = "Error - " + ex.Message + "\r\n" + "The database is probably not installed in the Data Source= c:\\Program Files\\HTC\\StateFair\\TimeClock.sqlite.";
            }

            return objConnection;
        }

        private void addData(SQLiteConnection objConnection, string strSQL)
        {
            SQLiteCommand objCommand = new SQLiteCommand();
            objCommand.CommandText = strSQL;
            objCommand.Connection = objConnection;
            int Rows = objCommand.ExecuteNonQuery();
            string Test = "Test";
        }

        private string statusBasedOnTime(string strCurrentStatus, DateTime Time, DateTime LastTime)
        {

            TimeSpan TimeDiff = Time.Subtract(LastTime);
            if (TimeDiff.Days > 0 | TimeDiff.Hours > 18)
                strCurrentStatus = "In"; // assuming the person, forgot to punch out.
            else if (TimeDiff.Hours == 0 && TimeDiff.Minutes < 5)
                strCurrentStatus = "Double-Swipe";
            else if (strCurrentStatus == "In")
            {
                strCurrentStatus = "Out";
                dtInTime = LastTime;
                dtOutTime = Time;
            }
            else if (strCurrentStatus == "Out")
            {
                strCurrentStatus = "In";
                dtInTime = Time;
            }
            return strCurrentStatus;
        }

    }
}
