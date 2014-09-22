using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace BillingParse
{
    class clsMySQLConnection
    {
        public MySqlConnection Create_MySQLConnection()
        {
            MySqlConnection objConnection = new MySqlConnection();
            objConnection.ConnectionString = "server=htcCloudServer.net;uid=TimeClock;pwd=!ce!ceBaby;database=htcStateFair;";
                           
            
            return objConnection;
        }

    }
}
