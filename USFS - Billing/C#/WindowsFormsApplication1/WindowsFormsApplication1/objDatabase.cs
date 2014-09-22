using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication1
{
    class objDatabase
    {
        private string strError;

        public string Error
        {
            get
            {
                return strError;        
            }

        }


        public int AddData(string strSQL)
        {
           // string strConnection = "Persist Security Info=False;Integrated Security=SSPI;database=TimeClock;server=sqlServer01";
            string strConnection = "server = 10.0.0.17; Initial Catalog=TimeClock; User Id=TimeClock; Password = 1ce1ceBaby";
            SqlConnection objConnection = new SqlConnection(strConnection);
            SqlCommand objCommand = new SqlCommand(strSQL);

            objConnection.Open();
            objCommand.Connection = objConnection;
            return objCommand.ExecuteNonQuery();
                   
        }

       public SqlDataReader ReturnData(string strSQL)
        {
//            string strConnection = "Persist Security Info=False;Integrated Security=SSPI;database=TimeClock;server=sqlServer01"; 
            string strConnection = "server = 10.0.0.17; Initial Catalog=TimeClock; User Id=TimeClock; Password = 1ce1ceBaby";
           SqlConnection objConnection = new SqlConnection(strConnection);
            SqlCommand objCommand = new SqlCommand(strSQL);
            SqlDataReader objReader;

            objConnection.Open();

            objCommand.Connection = objConnection;

            return objReader = objCommand.ExecuteReader();
        }

       public DataTable ReturnDataTable(string strSQL)
       {
           DataTable objTable = new DataTable();

           try
           {
//               string strConnection = "Persist Security Info=False;Integrated Security=SSPI;database=TimeClock;server=sqlServer01";
               string strConnection = "server = 10.0.0.17; Initial Catalog=TimeClock; User Id=TimeClock; Password = 1ce1ceBaby";
               SqlCommand objCommand = new SqlCommand(strSQL);


               SqlDataAdapter objAdapter = new SqlDataAdapter(strSQL, strConnection);
               objAdapter.Fill(objTable);
           }
           catch (System.Exception e)
           {
               strError = e.ToString();
           }

           return objTable;
       }

       
    }
}
