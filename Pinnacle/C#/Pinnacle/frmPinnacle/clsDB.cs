using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace frmPinnacle
{
    class clsDB
    {
        private string strError;
        private SQLiteConnection sqlConnection;
        private string strOrderNumber;

        // Constructor
        public clsDB(string strDBPath)
        {
            // creating connection in constructor, so we only use 1 connection per session. Otherwise can overload DB.
            sqlConnection = new SQLiteConnection("Data Source=" + strDBPath);
            sqlConnection.Open();

        }

        // Destructor
        ~clsDB()
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

        public SQLiteDataReader returnComboBox(string strTable)
        {
            SQLiteCommand sqlCommand = new SQLiteCommand(sqlConnection);
            
            switch(strTable)
            {
                case ("Staff"):
                    sqlCommand.CommandText = returnStaff();
                    break;
                case("VRC"):
                    sqlCommand.CommandText = returnVRC();
                    break;
                case("Funding"):
                    sqlCommand.CommandText = "Select Description From Funding Order by Description";
                    break;
                case("Service"):
                    sqlCommand.CommandText = "Select ID From Service Order by ID";
                    break;
                case("Disability"):
                    sqlCommand.CommandText = "Select Description From Disability Order by Description";
                    break;
            }
            return sqlCommand.ExecuteReader();
        }

        public string returnComboBox_Key(string strTable, string strIdentifier, string strValue)
        {
            string strKey, strSQL ="";
            SQLiteCommand sqlCommand = new SQLiteCommand(sqlConnection);

            switch(strIdentifier)
            {
                case("Name"):
                    strSQL = "Select ID From " + strTable + " Where FirstName || ' '|| LastName ='" + strValue + "'";
                    break;
                case("Description"):
                    strSQL = "Select ID From " + strTable + " Where Description = '" + strValue + "'";
                    break;
            }

            sqlCommand.CommandText = strSQL;
            SQLiteDataReader objReader = sqlCommand.ExecuteReader();
            strKey = objReader[0].ToString();

            objReader.Close();
            return strKey;
        }

        public bool executeNonQuery(string strSQL)
        {
            bool blAdded = false;

            SQLiteCommand sqlCommand = new SQLiteCommand(sqlConnection);
            sqlCommand.CommandText = strSQL;
            int intRow = sqlCommand.ExecuteNonQuery();
            if (intRow > 0)
                blAdded = true;
            
            
            return blAdded;
        }

        private string returnStaff()
        {
            string strSQL = "Select Staff.FirstName || ' ' || Staff.LastName as Staff";
            strSQL = strSQL + " From Staff";
            strSQL = strSQL + " Where Staff.Active = 'true'";
            strSQL = strSQL + " and Staff.Role_ID = 'Stf'";
            strSQL = strSQL + " Order by Staff.FirstName, Staff.LastName";

            return strSQL;
        }

        private string returnVRC()
        {
            string strSQL = "Select VRC.FirstName || ' ' || VRC.LastName as Counselor";
            strSQL = strSQL + " From VRC";
            strSQL = strSQL + " Where VRC.Active = 'true'";
            strSQL = strSQL + " Order by VRC.FirstName, VRC.LastName";

            return strSQL;
        }

        public SQLiteDataReader returnConsumer(string strConsumer)
        {
            SQLiteCommand sqlCommand = new SQLiteCommand(sqlConnection);

            sqlCommand.CommandText = returnEditConsumer_SQL(strConsumer);
            return sqlCommand.ExecuteReader();
        }

        private string returnEditConsumer_SQL(string strID)
        {
            string strSQL = "Select Consumer.ID, Consumer.FirstName, Consumer.LastName, SSN, AVR,VESID,Units";
            strSQL = strSQL + ", strftime('%m/%d/%Y',ReferralDate), strftime('%m/%d/%Y',IntakeDate), Service.ID as Service";
            strSQL = strSQL + ", Funding.Description as Funding, Disability.Description as Disability";
            strSQL = strSQL + " From Consumer";
            strSQL = strSQL + " Left Join Service on Service.ID = Consumer.Service_ID";
            strSQL = strSQL + " Left Join Funding on Funding.ID = Consumer.Funding_ID";
            strSQL = strSQL + " Left Join Disability on Disability.ID = Consumer.Disability_ID";
            strSQL = strSQL + " Where Consumer.ID ='" + strID + "'";

            return strSQL;
        }

        public bool EditConsumer(string strSQL)
        {
            bool blPass = false;
            SQLiteCommand sqlCommand = new SQLiteCommand(sqlConnection);
            
            sqlCommand.CommandText = strSQL;

            
            int intRows = sqlCommand.ExecuteNonQuery();
                        
            if (intRows > 0)
                blPass = true;

            return blPass;
        }

       
        public bool makeInActive(string strID)
        {
            
            string strSQL = "Update Consumer Set Active = 'false' where Consumer.ID = " + strID;
            bool blActive = ExecuteNonQuery(strSQL);

            return blActive;
        }

        private bool ExecuteNonQuery(string strSQL)
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

        public SQLiteDataReader returnVouchers(string strID)
        {
            SQLiteCommand sqlCommand = new SQLiteCommand(sqlConnection);

            sqlCommand.CommandText = "Select ID,strftime('%m/%d/%Y',Start) as VoucherStart,strftime('%m/%d/%Y',End) as VoucherEnd from Voucher where Consumer_ID = '" + strID + "' Order by Start desc";
            return sqlCommand.ExecuteReader();

        }

        public bool AddVoucher(string strConsumer, string VoucherStart, string VoucherEnd)
        {
            bool blAdded = false;
            SQLiteCommand sqlCommand = new SQLiteCommand(sqlConnection);


            string strInsert = "Insert Into Voucher(Consumer_ID, Start)";
            string strSelect = " Select Consumer.ID, '" + VoucherStart + "'";
            string strFrom =  " From Consumer";
            string strWhere = " Where Consumer.FirstName || ' ' || Consumer.LastName = '" + strConsumer + "'";

            // Adding VoucherEnd if there is one.
            if (VoucherEnd != null)
            {
                strInsert = strInsert.Substring(0, strInsert.Length - 1) + ", End)";
                strSelect = strSelect.Substring(0, strSelect.Length - 1) + "','" + VoucherEnd + "'";
            }
            sqlCommand.CommandText = strInsert + strSelect + strFrom + strWhere;

            int intRows = sqlCommand.ExecuteNonQuery();
            
            if (intRows > 0)
                blAdded = true;

            return blAdded;
        }

        public string returnRole(string strFirstName, string strLastName)
        {
            SQLiteCommand sqlCommand = new SQLiteCommand(sqlConnection);
            string strSQL = "Select Role_ID FROM Staff Where FirstName = '" + strFirstName +  "'"; 
            strSQL = strSQL + " and Staff.LastName = '" + strLastName + "'";
            strSQL = strSQL + " and Staff.Active = 'true'";

            sqlCommand.CommandText = strSQL;
            SQLiteDataReader objReader = sqlCommand.ExecuteReader();
            string strRole = "";
            strRole = objReader[0].ToString();
            while (objReader.Read())
            {
                strRole = objReader[0].ToString();
            }

            return strRole;
        }

        public SQLiteDataReader returnConsumers_byStaff(string strStaff)
        {
            SQLiteCommand sqlCommand = new SQLiteCommand(sqlConnection);

            string strSQL = "Select Distinct Consumer.FirstName || ' ' || Consumer.LastName";
            strSQL = strSQL + " From Consumer";
            strSQL = strSQL + " Join ConsumerStaff on Consumer.ID = ConsumerStaff.Consumer_ID";
            strSQL = strSQL + " Join Staff on Staff.ID = ConsumerStaff.Staff_ID";
//            strSQL = strSQL + " Where Staff.FirstName || ' ' || Staff.LastName = '" + strStaff + "'";
            strSQL = strSQL + " Where Consumer.Active = 'true'";
            strSQL = strSQL + " Order By Consumer.FirstName";
            sqlCommand.CommandText = strSQL;
            return sqlCommand.ExecuteReader();
        }

        public int assignJob(string strSQL)
        {
            int Rows = 0;

            SQLiteCommand sqlCommand = new SQLiteCommand(sqlConnection);

            sqlCommand.CommandText = strSQL;
            Rows = sqlCommand.ExecuteNonQuery();

            return Rows;
        }

        public SQLiteDataReader returnDataReader(string strSQL)
        {
            SQLiteCommand objCommand = new SQLiteCommand(sqlConnection);

            objCommand.CommandText = strSQL;
            return objCommand.ExecuteReader();
        }


    }
}
