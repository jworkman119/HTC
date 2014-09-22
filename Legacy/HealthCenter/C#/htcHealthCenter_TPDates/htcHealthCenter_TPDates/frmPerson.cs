using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace htcHealthCenter_TPDates
{
    public partial class frmPerson : Form
    {
        private string strName = "";
        public event returnName returningName;

       

        public frmPerson()
        {
            InitializeComponent();
            fillCombobox();
        }

        private void butEnter_Click(object sender, EventArgs e)
        {

            bool Pass = checkForm();
            if (Pass == true)
                addPerson();
        }


        private void fillCombobox()
        {
            clsDatabase objDB = new clsDatabase(StaticValues.RemoteDB);
            SQLiteDataReader objReader = objDB.returnDataReader("Select FirstName || ' ' || LastName as Counselor FROM Resource");
            while (objReader.Read())
            {
                cmbResource.Items.Add(objReader["Counselor"]);
            }
        }

        private bool checkForm()
        {
            bool Pass=true;

            foreach (Control objControl in this.Controls)
            {
                if (objControl is TextBox || objControl.Name == "cmbResource")
                {
                    if (objControl.Text == "")
                    {
                        MessageBox.Show("You did not fill in all the data.");
                        objControl.Focus();
                        Pass = false;
                        break;
                    }
                }
            }

            return Pass;
        }

        private void addPerson()
        {
      
            clsDatabase objDB = new clsDatabase(StaticValues.RemoteDB);
            string SQL = addPerson_SQL();
            bool blPass = objDB.ExecuteNonQuery(SQL);

            if (blPass == true)
            {
                MessageBox.Show("The patient has been added to the DB");
                returningName(txtFirst.Text + " " + txtLast.Text);
                CancelControl();
            }

            
        }

        private string addPerson_SQL()
        {
            string strFirst = txtFirst.Text.Replace("'", "''");
            string strLast = txtLast.Text.Replace("'", "''");
            clsFormat objFormat = new clsFormat();
            string SQL = "Insert into Patient(Account,FirstName,LastName,Resource_ID, DOB, Phone)";
            SQL = SQL + " Select " + txtAccount.Text + ",'" + strFirst + "','" + strLast + "',";
            SQL = SQL + " Resource.ID";
            SQL = SQL + " ,'" + dtDOB.Value.ToString("yyyy-MM-dd") + "','" + txtPhone.Text + "'"; 
            SQL = SQL + " From Resource";
            SQL = SQL + " Where FirstName || ' ' || LastName = '" + cmbResource.Text + "'";

            return SQL;
        }

        private void CancelControl()
        {
            this.Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            CancelControl();
        }
    }
}
