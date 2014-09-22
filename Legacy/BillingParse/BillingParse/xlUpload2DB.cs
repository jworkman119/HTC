using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace BillingParse
{
    class xlUpload2DB
    {

        public string Return1Item(string strSQL, MySqlConnection objConnection)
        {
            string strReturn = "";
            

            try
            {
               
                MySqlCommand objCommand = new MySqlCommand();
                objConnection.Open();
                objCommand.Connection = objConnection;
                objCommand.CommandText = strSQL;
                objCommand.Prepare();

                MySqlDataReader objReader = objCommand.ExecuteReader();
                
                
                if (objReader.HasRows == true)
                {
                    while (objReader.Read())
                    {
                        strReturn = objReader[0].ToString();
                    }
                }
                else
                {
                    strReturn = "Fail";
                }
                objReader.Close();
                objConnection.Close();
                return strReturn;
            }
            catch
            {
                objConnection.Close();
                return "Fail";
            }

        }

        public int ExecuteScalar(string strSQL, MySqlConnection objConnection)
        {
            int intRows = 0;
            
            try
            {
                
 
                
                    MySqlCommand objCommand = new MySqlCommand();
                    objConnection.Open();
                    objCommand.Connection = objConnection;
                    objCommand.CommandText = strSQL;
                    objCommand.Prepare();

                    intRows = objCommand.ExecuteNonQuery();
                
                    objConnection.Close();
            }
            catch
            {
                objConnection.Close();
                intRows = 0;
            }

            return intRows;
        }

        private string Create_MySQLConnection(ref MySqlConnection objConnection)
        {
            try
            {
                objConnection.ConnectionString = "server=htcCloudServer.net;uid=TimeClock;pwd=!ce!ceBaby;database=htcStateFair;";
                objConnection.Open();
                return "Success";
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
        }

    }
}
