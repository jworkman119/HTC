using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;





namespace htcTimeClock
{
    class objDatabase
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
            get{return dtInTime;}
        }

        public DateTime OutTime
        {
            get{return dtOutTime;}
        }

        public string Worker
        {
            get{return strWorker;}
        }

        public string Status
        {
            get{return strStatus;}
        }

        public string Error
        {
            get{return strError;}
        }

        public bool DoubleSwipe
        {
            get { return blDoubleSwipe; }
        }
        /*************** Functions *********************/
        public void UpdateDB(int intID)
        {

            Update_MySQL(intID);

        }


        private string Create_MySQLConnection(ref MySqlConnection objConnection)
        {
            try
            {
                objConnection.ConnectionString = "server=htcCloudServer.net;uid=TimeClock;pwd=!ce!ceBaby;database=htcStateFair;";
                objConnection.Open();
                return "Success";    
            }
            catch(MySqlException ex)
            {
                return ex.Message;
            }
        }


        private void Update_MySQL(int intID)
        {
            MySqlConnection objConnection = new MySqlConnection();
            string strConnect = Create_MySQLConnection(ref objConnection);

            try{
                if (strConnect == "Success")
                {
                    MySqlCommand objCommand = new MySqlCommand();
                    objCommand.Connection = objConnection;
                    objCommand.CommandText = "Call AddTime(@PersonID)";
                    objCommand.Prepare();
                    objCommand.Parameters.AddWithValue("@PersonID", intID);

                    MySqlDataReader objReader = objCommand.ExecuteReader();
                    processDataReader(objReader);
                   
                }
            }
            catch(MySqlException ex)
            {
                strError =  "Error - " +  ex.Message;
            }
               
        }

        private void processDataReader(MySqlDataReader objReader)
        {
            
            if (objReader.HasRows == true)
            {
            
                while (objReader.Read())
                {
                    strStatus = objReader["Status"].ToString();
                    if (strStatus != "Double-Swipe")
                    {
                        strWorker = objReader["Person"].ToString();
                        dtInTime = (DateTime)objReader["TimeIn"];
                        if (strStatus == "Out")
                        {
                            dtOutTime = (DateTime)objReader["TimeOut"];
                        }
                    }
                    else
                    {
                        blDoubleSwipe = true;
                    }
                }

            }
            else
            {
                strError = "Error - No rows were returned, please see your advisor. Person is most likely not entered in database";
            }

        }

       
    }
}
