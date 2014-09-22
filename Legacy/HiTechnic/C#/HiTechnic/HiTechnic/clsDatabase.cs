using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace HiTechnic
{
    class clsDatabase
    {
        private string strError;
        private SQLiteConnection sqlConnection;
        private string strOrderNumber;

        // Constructor
        public clsDatabase(string strDBPath)
        {
            // creating connection in constructor, so we only use 1 connection per session. Otherwise can overload DB.
            sqlConnection = new SQLiteConnection("Data Source=" + strDBPath);
            sqlConnection.Open();

        }

        // Destructor
        ~clsDatabase()
        {
            sqlConnection.Close();
        }

        public string Error
        {
            get
            {
                return strError;
            }
        }

        /* both parameters should be required and placed in a constructor. Preferably, two required properties */
       
        public int addToDB(clsUploadData.Data objData)
        {
            int intRows = 0;
            
            SQLiteCommand sqlCommand = new SQLiteCommand(sqlConnection);
            SQLiteTransaction objTransaction;

                try
                {
                    if (strOrderNumber != objData.OrderNumber)
                    {
                        objTransaction = sqlConnection.BeginTransaction();
                        //Adding Order Data
                        sqlCommand.CommandText = sqlAddOrder(objData);
                        intRows = sqlCommand.ExecuteNonQuery();
                        //Adding ShipTo Info
                        sqlCommand.CommandText = sqlAddShipTo(objData);
                        intRows = sqlCommand.ExecuteNonQuery();
                        //Adding BillTo Info
                        sqlCommand.CommandText = sqlAddBillTo(objData);
                        intRows = sqlCommand.ExecuteNonQuery();

                        //Adding OrderDetails Info
                        sqlCommand.CommandText = sqlAddOrderDetails(objData);
                        intRows = sqlCommand.ExecuteNonQuery();
                        objTransaction.Commit();

                        strOrderNumber = objData.OrderNumber;
                    }
                    else
                    {
                        sqlCommand.CommandText = sqlAddOrderDetails(objData);
                        sqlCommand.ExecuteNonQuery();
                        
                    }
                }
                catch(SQLiteException E)
                {
                    
                    switch (E.Message)
                    {
                        case "Abort due to constraint violation\r\ncolumn Number is not unique":
                            strError="Order has already been added to DB";
                            break;
                        default:
                            strError = E.Message;
                            break;
                    }
                }
                finally
                {
                    sqlCommand.Dispose();
                }
                return intRows;
        }
       
        public SQLiteDataReader returnData(string strSQL)
        {
            SQLiteCommand sqlCommand = new SQLiteCommand(sqlConnection);
            

            switch (strSQL)
            {
                case ("UnShipped"):
                    sqlCommand.CommandText = sqlReturnUnShipped();
                    break;
                case("Shipped200"):
                    sqlCommand.CommandText = sqlReturnShipped(true);
                    break;
                case ("ShippedAll"):
                    sqlCommand.CommandText = sqlReturnShipped(false);
                    break;
                default:
                    sqlCommand.CommandText = strSQL;
                    break;
            }
            return sqlCommand.ExecuteReader();
            
        }

        public bool deleteFromDB(string strOrder)
        {
            try
            {
                SQLiteCommand sqlCommand = new SQLiteCommand();
                sqlCommand.Connection = sqlConnection;
                SQLiteTransaction sqlTransaction;
                sqlTransaction = sqlConnection.BeginTransaction();

                sqlCommand.CommandText = "Delete from OrderDetails where OrderDetails.Orders_Number = '" + strOrder + "'";
                sqlCommand.ExecuteNonQuery();
                sqlCommand.CommandText = "Delete from ShipTo where ShipTo.Orders_Number = '" + strOrder + "'";
                sqlCommand.ExecuteNonQuery();
                sqlCommand.CommandText = "Delete from BillTo where BillTo.Orders_Number = '" + strOrder + "'";
                sqlCommand.ExecuteNonQuery();

                sqlCommand.CommandText = "Delete from Orders where Orders.Number = '" + strOrder + "'";
                sqlCommand.ExecuteNonQuery();
                
                sqlTransaction.Commit();
                return true;
            }
            catch (SQLiteException E)
            {
                return false;
            }

        }

        public string returnCountryCode(string strCountry)
        {
            SQLiteCommand sqlCommand = new SQLiteCommand(sqlConnection);

            sqlCommand.CommandText = "Select Country.Id From Country Where Name = '" + strCountry + "'";
            SQLiteDataReader objReader = sqlCommand.ExecuteReader();
            string strCountryCode = objReader["ID"].ToString();
            objReader.Close();
            sqlCommand.Dispose();

            return strCountryCode;
        }

        public string returnCountry(string strCountry)
        {
            
            SQLiteCommand sqlCommand = new SQLiteCommand(sqlConnection);

            sqlCommand.CommandText = "Select Country.Name From Country Where ID = '" + strCountry + "'";
            SQLiteDataReader objReader = sqlCommand.ExecuteReader();
            string strCountryCode = objReader["Name"].ToString();
            objReader.Close();
            sqlCommand.Dispose();

            return strCountryCode;
        }


        private string sqlAddOrder(clsUploadData.Data objData)
        {
            string strSQL = "Insert into Orders(Number,Email,Telephone,ShipMethod,ShippingAccount,AES, SubTotal)";
            strSQL = strSQL +  " Values('" + objData.OrderNumber + "','" + objData.CustEmailAddr + "','" + objData.TelephoneNbr + "','" + objData.ShipMethod + "','" + objData.ShippingAccountNo + "','" + objData.aesNumber + "','" + objData.Subtotal +  "')";

            return strSQL;
        }

        private string sqlAddShipTo(clsUploadData.Data objData)
        {
            string strSQL = "Insert into ShipTo(Orders_Number,Contact,Address1,Address2,Address3,City,State,Zip,Country)";
            strSQL = strSQL + " Values('" + objData.OrderNumber + "','" + objData.ShipToContact + "','" + objData.ShipToLine1 + "','" + objData.ShipToLine2 + "','" + objData.ShipToLine3 + "'";
            strSQL = strSQL + ",'" + objData.ShipToCity + "','" + objData.ShipToState + "','" + objData.ShipToPostalCode + "'";
            strSQL = strSQL + ",'" + objData.ShipToCountry + "')";

            return strSQL;
        }

        private string sqlAddBillTo(clsUploadData.Data objData)
        {
            string strSQL = "Insert into BillTo(Orders_Number,Contact,Address1,Address2,Address3,City,State,Zip,Country)";
            strSQL = strSQL + " Values('" + objData.OrderNumber + "','" + objData.BillToContact + "','" + objData.BillToLine1 + "','" + objData.BillToLine2 + "','" + objData.BillToLine3 + "'";
            strSQL = strSQL + ",'" + objData.BillToCity + "','" + objData.BillToState + "','" + objData.BillToPostalCode + "'";
            strSQL = strSQL + ",'" + objData.BillToCountry + "')";

            return strSQL;
        }

        private string sqlAddOrderDetails(clsUploadData.Data objData)
        {
            string strSQL = "Insert into OrderDetails(Orders_Number, PartID,Description,Qty)";
            strSQL = strSQL + " Values('" + objData.OrderNumber + "','" + objData.ItemNumber + "','" + objData.ItemDescription + "','" + objData.Qty + "')";
            
            return strSQL;
        }

        private string sqlReturnUnShipped()
        {
            string strSQL = "SELECT Orders.Number, Orders.ShipMethod";
            strSQL = strSQL + ", CASE WHEN CAST(strftime('%H', Orders.TS) AS INTEGER) = 12";
            strSQL = strSQL + " THEN strftime('%m/%d/%Y - %H:%M', Orders.TS) || ' PM'";
            strSQL = strSQL + " WHEN CAST(strftime('%H', Orders.TS) AS INTEGER) > 12";
            strSQL = strSQL + " THEN strftime('%m/%d/%Y - %H:%M', Orders.TS, '-12 Hours') || ' PM'";
            strSQL = strSQL + " ELSE strftime('%m/%d/%Y - %H:%M', Orders.TS) || ' AM'";
            strSQL = strSQL + " END Received";
            strSQL = strSQL + ", ShipTo.Contact";
            strSQL = strSQL + ", ShipTo.Address1 as Address";
            strSQL = strSQL + ", ShipTo.City || ', ' || ShipTo.State || ' ' || ShipTo.Zip as [City State Zip], ShipTo.Country";
            strSQL = strSQL + " FROM Orders";
            strSQL = strSQL + " JOIN ShipTo on Orders.Number = ShipTo.Orders_Number";
            strSQL = strSQL + " LEFT JOIN Tracking on Orders.Number = Tracking.Orders_Number";
            strSQL = strSQL + " WHERE Tracking.ID IS NULL";

            return strSQL;
        }

        private string sqlReturnShipped(bool bl200)
        {
            string strSQL = "select Orders.Number ,Orders.ShipMethod, Tracking.Tracking, Tracking.Weight, Tracking.Cost";
            strSQL = strSQL + ", CASE WHEN CAST(strftime('%H', Tracking.TS) AS INTEGER) = 12 THEN";
            strSQL = strSQL + " strftime('%m/%d/%Y - %H:%M', Tracking.TS) || ' PM'";
            strSQL = strSQL + " WHEN CAST(strftime('%H', Tracking.TS) AS INTEGER) > 12 THEN";
            strSQL = strSQL + " strftime('%m/%d/%Y - %H:%M', Tracking.TS, '-12 Hours') || ' PM'";
            strSQL = strSQL + " ELSE strftime('%m/%d/%Y - %H:%M', Tracking.TS) || ' AM'";
            strSQL = strSQL + " End Shipped";
            strSQL = strSQL + ", ShipTo.Address1 as Address";
            strSQL = strSQL + ", ShipTo.City || ', ' || ShipTo.State || ' ' || ShipTo.Zip as [City State Zip], ShipTo.Country";
            strSQL = strSQL + " From Tracking Join Orders on Orders.Number = Tracking.Orders_Number";
            strSQL = strSQL + " JOIN ShipTo on Orders.Number = ShipTo.Orders_Number";
            strSQL = strSQL + " Order by Tracking.TS desc";
            if (bl200 == true)
            {
                strSQL = strSQL + " Limit 200";
            }
            return strSQL;
        }
    }
}
