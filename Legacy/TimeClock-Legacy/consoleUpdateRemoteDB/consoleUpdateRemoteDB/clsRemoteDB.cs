using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace consoleUpdateRemoteDB
{
    class clsRemoteDB
    {
        MySqlConnection objConnection =new MySqlConnection();
        string strError="";


        public string Error
        {
            get { return strError; }
        }

        public clsRemoteDB()
        {
            clsLog objLog = new clsLog();

            try
            {
                objConnection.ConnectionString = resStaticData.MySQL_ConnectionString;
                objConnection.Open();
                    
            }
            catch(MySqlException ex)
            {
                strError = System.DateTime.Now.ToString("MM-dd-yyyy HH:mm") + " - Error - " + ex.Message;
                objLog.writeToLog(strError);
            }
        }
        
        ~clsRemoteDB()
        {
            objConnection.Close();
        }

       public int Update_MySQL(string SQL,string strType)
       {
           int ID = -1;
           MySqlDataReader objReader;
           clsLog objLog = new clsLog();

           try
           {
               if (strError == "")
               {
                   MySqlCommand objCommand = new MySqlCommand();
                   objCommand.Connection = objConnection;
                   objCommand.CommandText = "Call " + SQL;

                    
                    if (strType=="TimeIn")
                    {
                        objReader = objCommand.ExecuteReader();
                        ID = returnMySqlID(objReader);
                        objReader.Close();
                    }
                    else if (strType == "TimeOut")
                    {
                        ID = objCommand.ExecuteNonQuery();
                    }
                    
                    
               }
           }
           catch (MySqlException ex)
           {
               strError = System.DateTime.Now.ToString("MM-dd-yyyy HH:mm") + " - Error - " + ex.Message;
               objLog.writeToLog(strError);
           }

           return ID;
        }

       private int returnMySqlID(MySqlDataReader objReader)
       {
           int ID=-1;

           while (objReader.Read())
           {
               ID = Convert.ToInt32(objReader[0]);
           }

           return ID;
       }

       
    


    }
}
