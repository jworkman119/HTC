using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;

using MySql.Data.MySqlClient;
using System.Data.SQLite;
//using System.Data.Common;




namespace UpdateRemoteDB_Console
{
    class objDatabase_URDB
    {
        /***********    - properties -   ***************/
        private string strError = "";

        public string Error
        {
            get { return strError; }
        }

        /***********    - functions -   ***************/

        public void UpdateDB(string URL) 
        {
            try
            {
                bool blSuccess = PingTest(URL);

                if (blSuccess == true)
                {

                    SQLiteConnection objLocalConnection = CreateSQLite_Connection();

                    if (strError == "")
                    {
                        SQLiteDataReader objReader = queryLocalDB(objLocalConnection);
                        if (objReader.HasRows == true)
                        {
                            MySqlConnection objRemoteConnection = CreateMySQL_Connection("htcCloudDB.net");

                            while (objReader.Read())
                            {
                                if (strError == "")
                                {
                                    //Updating remote db - * todo - do some sort of error checking to make sure query works
                                    int intUserID = Convert.ToInt16(objReader["Person_ID"]);
                                    DateTime dtTime = Convert.ToDateTime(objReader["Time"]);
                                    int intID = Convert.ToInt16(objReader["ID"]);

                                    MySqlDataReader objRemoteReader = UpdateRemoteDB(objRemoteConnection, intUserID, dtTime, intID);

                                    if (objRemoteReader.HasRows == true)
                                    {
                                        while (objRemoteReader.Read())
                                        {
                                            string strStatus = objRemoteReader["Status"].ToString();
                                            if (strStatus != "Double-Swipe")
                                            {
                                                intID = Convert.ToInt16(objReader["ID"]);
                                                updateLocalDB_Added(objLocalConnection, objRemoteReader, intID);
                                            }

                                        }
                                        objRemoteReader.Close();
                                    }
                                }
                            }
                        }
                    }

                }
            }
            catch(System.Exception e)
            {
                clsLog objLog = new clsLog();
                strError = e.Message.ToString();
                objLog.writeToLog(System.DateTime.Now.ToString() + " - " + e.Message.ToString());
            }
        }

        /* function pings server, if successful will update database */
        private bool PingTest(string strURL)
        {
            System.Net.NetworkInformation.Ping objPing = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingOptions objOptions = new System.Net.NetworkInformation.PingOptions();
            objOptions.DontFragment = true;

            try
            {
                System.Net.NetworkInformation.PingReply objReply = objPing.Send(strURL, 4);
                return true;
            }
            catch (SystemException e)
            {
                return false;
            }

        }
        
        
        
        private SQLiteConnection CreateSQLite_Connection()
        {

            string DB_Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\HTC\\StateFair\\TimeClock.sqlite";
            SQLiteConnection objConnection = new SQLiteConnection("Data Source=" + DB_Path);

            try
            {
                objConnection.Open();
            }
            catch(SQLiteException ex)
            {
                strError = "Error - " + ex.Message + "\r\n" + "The database is probably not installed in the Data Source= " + DB_Path;
            }

            return objConnection;
        }

        private SQLiteDataReader queryLocalDB(SQLiteConnection objConnection)
        {
            string strSQL = "Select *";
            strSQL = strSQL + " From Time";
            strSQL = strSQL + " Where Status is NULL";

            SQLiteCommand objCommand = new SQLiteCommand();
            objCommand.Connection = objConnection;
            objCommand.CommandText = strSQL;
            SQLiteDataReader objReader =  objCommand.ExecuteReader();

            return objReader;
        }


        private void updateLocalDB_Added(SQLiteConnection objConnection, MySqlDataReader objReader, int ID)
        {
     
            string strSQL = "update Time Set Status = '" + objReader["Status"] + "'";
            strSQL = strSQL + " where ID = " + ID.ToString();

           updateLocalDB(objConnection, strSQL);
        }

        private void updateLocalDB(SQLiteConnection objConnection, string strSQL)
        {
            SQLiteCommand objCommand = new SQLiteCommand();
            objCommand.Connection = objConnection;
            objCommand.CommandText = strSQL;
            objCommand.ExecuteScalar();
        }


        private MySqlConnection CreateMySQL_Connection(string strURL)
        {
            MySqlConnection objConnection = new MySqlConnection();

            try
            {
                objConnection.ConnectionString = "server=htcCloudDB.net;uid=TimeClock;pwd=!ce!ceBaby;database=htcStateFair;";
                objConnection.Open();
            }
            catch (MySqlException ex)
            {
                strError = ex.Message;
            }

            return objConnection;
        }

        private MySqlDataReader UpdateRemoteDB(MySqlConnection objConnection, int intUser,DateTime dtTime,int ID)
        {
            MySqlCommand objCommand = new MySqlCommand();
            string strSQL;

            strSQL = "call AddTime(" + intUser.ToString() + ",'" + dtTime.ToString("yyyy-MM-dd HH:mm:ss") + "'," + ID +")";
            objCommand.Connection = objConnection;
            objCommand.CommandText = strSQL;
            return objCommand.ExecuteReader();
            
        }

    }
}
