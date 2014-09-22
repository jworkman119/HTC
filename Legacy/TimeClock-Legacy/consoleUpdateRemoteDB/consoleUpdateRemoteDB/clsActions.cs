using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Collections;

namespace consoleUpdateRemoteDB
{
    class clsActions
    {

        class Times
        {
            public int SQLite_ID;
            public string Query;
        }

        public void updateDBs()
        {
            

            List<Times> objTimesIn = createTimeIn_SQL();
            updateRemoteDB(objTimesIn,"TimeIn");
            List<Times> objTimesOut = createTimeOut_SQL();
            updateRemoteDB(objTimesOut, "TimeOut");
        }

        private List<Times> createTimeIn_SQL()
        {
            SQLiteDataReader objReader = returnTimeIns();
            List<Times> objData = new List<Times>();
            

            int j = 0;
            while (objReader.Read())
            {
                string strQuery = "AddTimeIn (" + objReader["PersonID"].ToString() + ",'" + ConvertDate(Convert.ToDateTime(objReader["TimeIn"])) + "'," +  objReader["ID"].ToString() + ")";
                Times objMySQL = new Times();
                objMySQL.Query = strQuery;
                objMySQL.SQLite_ID = Convert.ToInt32(objReader["ID"]);
                objData.Add(objMySQL);
                
            }


            return objData;
        }

        private List<Times> createTimeOut_SQL()
        {
            SQLiteDataReader objReader = returnTimeOuts();
            List<Times> objData = new List<Times>();

            int j = 0;
            while (objReader.Read())
            {
                string strQuery = "AddTimeOut ('" + ConvertDate(Convert.ToDateTime(objReader["TimeOut"])) + "'," + objReader["MySQL_ID"].ToString() + ")";
                Times objMySQL = new Times();
                objMySQL.Query = strQuery;
                objMySQL.SQLite_ID = Convert.ToInt32(objReader["ID"]);
                objData.Add(objMySQL);
            }


            return objData;
        }
        

        
        private SQLiteDataReader returnTimeIns()
        {
            clsLocalDB objLocalDB = new clsLocalDB(resStaticData.localDB);

            string SQL = "SELECT ID, PersonID, TimeIn";
            SQL = SQL + " FROM remoteTime";
            SQL = SQL + " WHERE TimeIn_Added='false'";

            SQLiteDataReader objReader = objLocalDB.returnDataReader(SQL);

            return objReader;
        }


        private SQLiteDataReader returnTimeOuts()
        {
            clsLocalDB objLocalDB = new clsLocalDB(resStaticData.localDB);
            string SQL = "SELECT ID, MySQL_ID, TimeOut";
            SQL = SQL + " FROM remoteTime";
            SQL = SQL + " WHERE TimeOut is not null";
            SQL = SQL + " AND TimeOut_Added= 'false'";
            SQL = SQL + " AND MySQL_ID is not null";

            SQLiteDataReader objReader = objLocalDB.returnDataReader(SQL);

            return objReader;
        }

        private void updateRemoteDB(List<Times> objQueries, string strType)
        {
            clsRemoteDB objRemoteDB = new clsRemoteDB();
            clsLocalDB objLocalDB = new clsLocalDB(resStaticData.localDB);

            int totalIns=0, totalOuts=0;
            clsLog objLog = new clsLog();

            foreach (Times i in objQueries)
            {
                string Query = i.Query;
                int SQLiteID = i.SQLite_ID;
                
                int Rows;

                if (strType == "TimeIn")
                {
                    int MySQL_ID = objRemoteDB.Update_MySQL(Query, "TimeIn");
                    if (MySQL_ID != -1)
                    {
                        objLocalDB.addMySQLID(MySQL_ID, SQLiteID);
                        totalIns++;
                    }
                    else
                    {
                        objLog.writeToLog("There was an error adding sqlite_ID = " + SQLiteID.ToString() + " to remoteDB.");
                        totalIns--;
                    }
                }
                else if (strType == "TimeOut")
                {
                    Rows = objRemoteDB.Update_MySQL(Query, "TimeOut");
                    if (Rows > 0)
                    {
                        objLocalDB.updateTimeOut_Added(SQLiteID);
                        totalOuts++;
                    }
                    else
                        totalOuts--;
                }
            }

            objLog.writeToLog(returnLogMsg(totalOuts + totalIns, strType));
        }

        private string returnLogMsg(int Rows, string strType)
        {
            string msgLog = "";

            if (strType == "TimeIn")
                msgLog = System.DateTime.Now.ToString("MM-dd-yyyy HH:mm") + " TimeIn - " + Rows.ToString() + " rows were added to the database";
            else if (strType == "TimeOut")
                msgLog = System.DateTime.Now.ToString("MM-dd-yyyy HH:mm") + " TimeOut - " + Rows.ToString() + " rows were added to the database";

            return msgLog;

        }

        private string ConvertDate(DateTime objDate)
        {
            string strDate = objDate.ToString("yyyy-MM-dd HH:mm");

            return strDate;
        }
    }
}
