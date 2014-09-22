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
    public delegate void returnName(string strName);

    public partial class frmMain : Form
    {
        string strAccount = "";
        bool blWaitList = false;
        int WaitList_ID =0;
        bool blTP = false;
        int TP_ID = 0;
        string strDB = StaticValues.RemoteDB;

        public frmMain()
        {
            InitializeComponent();
            loadControl();
        }

        private void loadControl()
        {
            ToolTip objTip = new ToolTip();

            objTip.SetToolTip(butCustomer, "Add Patient");
            objTip.SetToolTip(butReport, "Run Report");
            loadConsumerList();
            loadResource(cmbResource);
            loadResource(cmbCounselor);
            txtPatient.Focus();
            rbTPno.Checked = true;
        }

        private void loadResource(ComboBox cmbCombo)
        {
            string SQL = "Select Resource.FirstName || ' ' || Resource.LastName as Counselor";
            SQL = SQL + " From Resource Where Active = 1 order by FirstName ";

            clsDatabase objDB = new clsDatabase(strDB);
            SQLiteDataReader objReader =  objDB.returnDataReader(SQL);
            while (objReader.Read())
            {
                cmbCombo.Items.Add(objReader[0].ToString());
            }

        }

        private void loadConsumerList()
        {
            clsDatabase objDB = new clsDatabase(strDB);
            string SQL = returnPatientsSQL();

            SQLiteDataReader objReader = objDB.returnDataReader(SQL);

            while (objReader.Read())
            {
                txtPatient.AutoCompleteCustomSource.Add(objReader["Patient"].ToString());
            }
        }

        private string returnPatientsSQL()
        {
            string SQL = "Select FirstName || ' ' || LastName as Patient";
            SQL = SQL + " From Patient";

            return SQL;
        }

        private void returnPatientInfo()
        {
            clsDatabase objDB = new clsDatabase(strDB);
            string SQL = returnPatientSQL();
            SQLiteDataReader objReader = objDB.returnDataReader(SQL);
            

            while (objReader.Read())
            {
                txtAccount.Text = objReader["Account"].ToString();
                txtDOB.Text = objReader["DOB"].ToString();
                txtCounselor.Text = objReader["Counselor"].ToString();
                txtPhone.Text = objReader["Phone"].ToString();
                strAccount = objReader["Account"].ToString();
            }

            clearTPPanel();
            loadTP_Dates(strAccount);
            tabApps.SelectedIndex = 0;
        }

        private void clearTPPanel()
        {
            TP_ID = 0;
            cmbCounselor.SelectedIndex = -1;
            dtDate.Value = System.DateTime.Today;
            cmbLocation.SelectedIndex = 0;
            rbTPno.Checked = true;
            
        }

        private string returnPatientSQL()
        {
            string SQL = "Select Patient.Account, Patient.FirstName || ' ' || Patient.LastName as Patient";
            SQL = SQL + " ,  strftime('%m/%d/%Y',Patient.DOB) as DOB, Resource.FirstName || ' ' || Resource.LastName as Counselor";
            SQL = SQL + " ,  Phone";
            SQL = SQL + " From Patient";
            SQL = SQL + " Left Join Resource on Patient.Resource_ID = Resource.ID";
            SQL = SQL + " Where Patient.FirstName || ' ' || Patient.LastName = '" + txtPatient.Text + "'";

            return SQL;
        }

        private void loadTP_Dates(string sAccount)
        {
            clsDatabase objDB = new clsDatabase(strDB);
            string SQL = returnTP_SQL(sAccount);
            SQLiteDataReader objReader = objDB.returnDataReader(SQL);
            TP_ID = 0;

            while (objReader.Read())
            {
                int.TryParse(objReader["ID"].ToString(),out TP_ID);
                dtDate.Text = objReader["Date"].ToString();
                setupComboBox(cmbCounselor, objReader["Counselor"].ToString());
                setupComboBox(cmbLocation, objReader["Location"].ToString());
                rbTPyes.Checked = true;
            }
        }

        private void setupComboBox(ComboBox cmbBox, string strValue)
        {
            cmbBox.SelectedIndex = -1;
            for (int j = 0; j < cmbBox.Items.Count; j++)
            {
                if (cmbBox.Items[j].ToString() == strValue)
                {
                    cmbBox.SelectedIndex = j;
                    break;
                }
            }
        }

        private string returnTP_SQL(string strAccount)
        {
            string SQL = "Select TP.ID, strftime('%m/%d/%Y',tp.Date) as Date";
            SQL = SQL + ", Resource.FirstName || ' ' || Resource.LastName as Counselor, TP.Location";
            SQL = SQL + " From TP";
            SQL = SQL + " Left Join Resource on TP.Resource_ID = Resource.ID";
            SQL = SQL + " Where TP.Patient_Account='" + strAccount + "'";
            SQL = SQL + " Order by Date";

            return SQL;
        }

        private void txtPatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                returnPatientInfo();
            }
        }

        private void addDate()
        {
            clsDatabase objDB = new clsDatabase(strDB);
            string SQL = addDate_SQL();
            bool blPass = objDB.ExecuteNonQuery(SQL);
            if (blPass != true)
                MessageBox.Show("Your date was not added to database, if problem persists please contact IT.");
            else
            {
                loadTP_Dates(strAccount);
                MessageBox.Show("A new Treatment Plan has been added to the database.");
            }
        }

        private string addDate_SQL()
        {
            clsFormat objFormat = new clsFormat();
            string SQL = "";
            if (TP_ID == 0)
            {
                SQL = "Insert into TP(Patient_Account,Date, Resource_ID, Location)";
                SQL = SQL + " Values (" + strAccount + "," + objFormat.formatDate(dtDate.Text);
                if (cmbCounselor.SelectedIndex >= 0)
                    SQL = SQL + ",(Select ID From Resource Where FirstName || ' ' || LastName ='" + cmbCounselor.Text + "')";
                else
                    SQL = SQL + ",null";

                if (cmbLocation.SelectedIndex >= 0)
                    SQL = SQL + ",'" + cmbLocation.Text + "')";
                else
                    SQL = SQL + ",null)";
            }
            else
            {
                SQL = "Update TP";
                SQL = SQL + " Set Date = " + objFormat.formatDate(dtDate.Text);
                if (cmbLocation.SelectedIndex >= 0)
                    SQL = SQL + ", Location = '" + cmbLocation.Text + "'";

                if (cmbCounselor.SelectedIndex >= 0)
                    SQL = SQL + " , Resource_ID=(Select ID From Resource Where FirstName || ' ' || LastName ='" + cmbCounselor.Text + "')";
                
                SQL = SQL + " Where TP.ID = " + TP_ID.ToString() ;
            }
            return SQL;
        }

        private void butDate_Click(object sender, EventArgs e)
        {
            if (strAccount != "")
                addDate();
            else
                MessageBox.Show("You do not have a patient selected.");
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            deleteDate();            
        }

        private void deleteDate()
        {
            clsFormat objFormat = new clsFormat();
            string strDelete = objFormat.formatDate(dtDate.Text);
            string SQL = returnDeleteDate_SQL(strDelete);


            clsDatabase objDatabase = new clsDatabase(strDB);
            bool blPass = objDatabase.ExecuteNonQuery(SQL);
            if (blPass != true)
                MessageBox.Show("The date was not deleted, if problem persists please contact IT.");
            else
                loadTP_Dates(strAccount);
        }

        private string returnDeleteDate_SQL(string strDate)
        {
            string SQL = "Delete from TP";
            SQL = SQL + " Where Patient_Account = " + strAccount ;
            SQL = SQL + " And Date = " + strDate ;

            return SQL;
        }

        private void butCustomer_Click(object sender, EventArgs e)
        {
            frmPerson objPerson = new frmPerson();
            objPerson.returningName += new returnName(objPerson_returningName);
            objPerson.ShowDialog();
        }

        private void objPerson_returningName(string strName)
        {
            txtPatient.AutoCompleteCustomSource.Add(strName);
        }

        private void butReport_Click(object sender, EventArgs e)
        {
            frmReports objReports = new frmReports();
            objReports.ShowDialog();
        }

        private void addToWaitList()
        {
            clsDatabase objDB = new clsDatabase(StaticValues.RemoteDB);
            string SQL = add2WaitListSQL();
            bool blPass = objDB.ExecuteNonQuery(SQL);
            if (blPass==true)
                MessageBox.Show(txtPatient.Text + " has been added to the wait list.");
            else
                MessageBox.Show("Error - was not able to add the user to the wait list. If the problem persists please contact IT.");
        }

        private bool returnWaitList()
        {
            WaitList_ID = 0;
            bool blRows = false;
            clsDatabase objDB = new clsDatabase(strDB);
            string SQL = returnWaitListSQL();
            SQLiteDataReader objReader = objDB.returnDataReader(SQL);
            if (objReader.HasRows == true)
            {
                blRows = true;
                while (objReader.Read())
                {
                    WaitList_ID = Convert.ToInt32(objReader["ID"]);
                    dtWaitStart.Text = objReader["StartDate"].ToString();
                    dtWaitEnd.Text = objReader["EndDate"].ToString();
                    //Setting up combobox
                    int Items = cmbResource.Items.Count;
                    for (int j = 0; j < Items; j++)
                    {
                        if (cmbResource.Items[j].ToString() == objReader["Resource"].ToString())
                        {
                            cmbResource.SelectedIndex = j;
                            break;
                        }
                    }
                    rdYes.Checked = true;
                }
            }
            
            return blRows;
        }

        private void deleteWaitList()
        {
            if (blWaitList == true)
            {
                clsDatabase objDB = new clsDatabase(strDB);
                string SQL = deleteWaitListSQL();
                bool blPass = objDB.ExecuteNonQuery(SQL);
                if (blPass == true)
                    MessageBox.Show(txtPatient.Text + " has been deleted from the wait list.");
                else
                    MessageBox.Show("Error - was not able to delete the user to the wait list. If the problem persists please contact IT.");
            }
            else
                blWaitList = true;
      
        }

        private string add2WaitListSQL()
        {
            string SQL = "";
            if (WaitList_ID == 0)
            {
                SQL = addNew2WaitList_SQL();
            }
            else
            {
                SQL = updateWaitList_SQL(WaitList_ID);
            }
            return SQL;
        }

        private string addNew2WaitList_SQL()
        {
            string SQL = "Insert into WaitList(Patient_Account, StartDate,EndDate, Resource_ID)";

            if (cmbResource.SelectedIndex >= 0)
            {
                SQL = SQL + "Select '" + strAccount + "','" + dtWaitStart.Value.ToString("yyyy-MM-dd") + "','" + dtWaitEnd.Value.ToString("yyyy-MM-dd") + "'";
                SQL = SQL + ", Resource.ID";
                SQL = SQL + " From Resource";
                SQL = SQL + " Where Resource.FirstName || ' ' || Resource.LastName = '" + cmbResource.Text + "'";
            }
            else
            {
                SQL = SQL + "Values('" + strAccount + "','" + dtWaitStart.Value.ToString("yyyy-MM-dd") + "','" + dtWaitEnd.Value.ToString("yyyy-MM-dd") + "',null";
            }

            return SQL;
        }

        private string updateWaitList_SQL(int ID)
        {
            string SQL = "Update WaitList";
            SQL = SQL + " Set StartDate = '" + dtWaitStart.Value.ToString("yyyy-MM-dd") + "'";
            SQL = SQL + " , EndDate = '" + dtWaitEnd.Value.ToString("yyyy-MM-dd") + "'";
            if (cmbResource.SelectedIndex >= 0)
            {
                SQL = SQL + " , Resource_ID=(Select ID From Resource Where FirstName || ' ' || LastName ='" + cmbResource.Text + "')";
            }
            SQL = SQL + " Where WaitList.ID=" + ID.ToString(); 
            return SQL;
        }

        private string returnWaitListSQL()
        {
            string SQL = "Select WaitList.ID, WaitList.StartDate, WaitList.EndDate, Resource.FirstName || ' ' || Resource.LastName as Resource";
            SQL = SQL + " From WaitList";
            SQL = SQL + " Left Join Resource on Resource.ID = WaitList.Resource_ID";
            SQL = SQL + " Where Patient_Account = '" + strAccount + "'";

            return SQL;
        }

        private string deleteWaitListSQL()
        {
            string SQL = "Delete from WaitList where Patient_Account='" + strAccount + "'";

            return SQL;
        }

        private void rdYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdYes.Checked == true)
            {
                blWaitList = returnWaitList();
                pnlWaitList.Visible = true;
            }
        }

        private void rdNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNo.Checked == true)
            {
                //remove from wait list
                deleteWaitList();
                pnlWaitList.Visible = false;
            }

        }

        private void tabApps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabApps.SelectedIndex == 0)
            {
                dtWaitStart.Value = System.DateTime.Now;
                dtWaitEnd.Value = System.DateTime.Now;
            }
            else
            {
 
                bool blHasRows = returnWaitList();
                if (blHasRows == false)
                    rdNo.Checked = true;
                else
                    rdYes.Checked = true;
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            addToWaitList();
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            returnPatientInfo();
        }

        private void rbTPno_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTPno.Checked == true)
            {
                rbTPyes.Checked = false;
                pnlTreatmentPlan.Visible = false;
                deleteTP();
            }
        }

        private void rbTPyes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTPyes.Checked == true)
            {
                rbTPno.Checked = false;
                pnlTreatmentPlan.Visible = true;
            }
        }

        private void deleteTP()
        {
            if (TP_ID != 0)
            {
                clsDatabase objDB = new clsDatabase(strDB);
                string SQL = deleteTPSQL();
                bool blPass = objDB.ExecuteNonQuery(SQL);
                if (blPass == true)
                {
                    MessageBox.Show(txtPatient.Text + " has removed his treatment plan.");
                    clearTPPanel();
                }
                else
                    MessageBox.Show("Error - was not able to delete the user to the treatment plan. If the problem persists please contact IT.");
            }
            else
                blTP = true;
        }

        private string deleteTPSQL()
        {
            string SQL = "Delete from TP where Patient_Account='" + strAccount + "'";

            return SQL;
        }


    }
}
