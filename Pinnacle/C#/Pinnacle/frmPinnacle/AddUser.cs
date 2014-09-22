using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;


/***** TODO - Units should be a required field *****/



namespace frmPinnacle
{
    public delegate void Cancel(string message);
    
    
    public partial class AddUser : UserControl
    {
        public event Cancel CancelControl;

        string ID;
        struct StaffID
        {
            public string Name;
            public string ID;
        }
        List<StaffID> StaffIDs = new List<StaffID>();
        List<string> deleteStaff = new List<string>();
        bool blVoucher = false;

        public AddUser()
        {
            InitializeComponent();
            LoadControl();
        }

        #region Tab_Consumer

            public void LoadControl_Edit(string strConsumerID)
            {
                clsDateTimePicker_Utils objPickerUtils = new clsDateTimePicker_Utils();
                
                clsDB objDB = new clsDB(resPinnacle.liveDB);

                SQLiteDataReader objReader = objDB.returnConsumer(strConsumerID);
                //LoadControl_Edit(objReader, this.Controls);
                ID = objReader[0].ToString();
                txtFirst.Text = objReader[1].ToString();
                txtLast.Text = objReader[2].ToString();
                txtSSN.Text = objReader[3].ToString();
                txtAVR.Text = objReader[4].ToString();
                txtVesid.Text = objReader[5].ToString();
                txtUnits.Text = objReader[6].ToString();
                dtReferral.Text = objReader[7].ToString();
                dtIntake.Text = objReader[8].ToString();
                setCombobox(cmbService, objReader[9].ToString());
                setCombobox(cmbFunding, objReader[10].ToString());
                setCombobox(cmbDisability, objReader[11].ToString());
                        
                butAdd.Text = "Update Consumer";
                objReader.Close();

            }

            private void LoadControl()
            {
                fillCombobox(cmbStaff, "Staff");
                fillCombobox(cmbCounselor, "VRC");
                fillCombobox(cmbFunding, "Funding");
                fillCombobox(cmbService, "Service");
                fillCombobox(cmbDisability, "Disability");
   
                butAdd.Text = "Add Consumer";

                // disabling tabs, control will break if you try to assign staff or add voucher, before a user has been entered.
                ((Control)tabAssigned).Enabled = false;
                ((Control)tabVoucher).Enabled = false;
             }

            private void butAdd_Click(object sender, EventArgs e)
            {
                bool blWorked = false;
                string strResponse = "";

                if (butAdd.Text == "Add Consumer")
                    blWorked = addNewConsumer(ref strResponse);
                else if (butAdd.Text == "Update Consumer")
                    blWorked = updateConsumer(ref strResponse);
                if (blWorked == true)
                {
                    setConsumerID();
                }

                MessageBox.Show(strResponse);
            }

            private void setConsumerID()
            {
                string SQL = "SELECT max(ID) as ID FROM Consumer";
                clsDB objDB = new clsDB(resPinnacle.liveDB);
                SQLiteDataReader objReader = objDB.returnDataReader(SQL);
                while (objReader.Read())
                {
                    ID = objReader[0].ToString();
                }
            }

            private bool addNewConsumer(ref string strResponse)
            {
                string strSQL;
                bool blAdded = false;
                bool blValidated = validateData(this.Controls);


                if (blValidated == true)
                {
                    clsDB objDB = new clsDB(resPinnacle.liveDB);
                    strSQL = returnAddConsumerSQL(objDB);
                    blAdded = objDB.executeNonQuery(strSQL);

                    if (blAdded == true)
                    {
                        strResponse = txtFirst.Text + " " + txtLast.Text + " has been successfully added to the database.";
                    }
                    else
                    {
                        strResponse = "The consumer was not added to the database. Please try again. Consult IT if problem persists";
                        txtFirst.Focus();
                    }
                }

                return blAdded;
            }

            private bool updateConsumer(ref string strResponse)
            {
                clsDB objDB = new clsDB(resPinnacle.liveDB);
                string strSQL = returnUpdateConsumerSQL(objDB);

                bool blPass = false;
                blPass = objDB.EditConsumer(strSQL);

                if (blPass == true)
                {
                    //MessageBox.Show("Consumer " + txtFirst.Text + " " + txtLast.Text + " has been successfully updated.");
                    strResponse = "Consumer " + txtFirst.Text + " " + txtLast.Text + " has been successfully updated.";
                }
                else
                {
                    strResponse = "The consumer was not added to the database. Please try again. Consult IT if problem persists";
                    txtFirst.Focus();
                }

                return blPass;
            }

            private void formatName(TextBox txtBox)
            {
                if (txtBox.Text.Length > 0)
                {
                    string strFirst = txtBox.Text.Substring(0, 1);
                    strFirst = strFirst.ToUpper();
                    string strRest = txtBox.Text.Substring(1, txtBox.Text.Length - 1);
                    txtBox.Text = strFirst + strRest;
                }
            }

            private void tabConsumerInfo_Enter(object sender, EventArgs e)
            {
                txtSSN.Focus();
            }

            private void txtLast_Leave(object sender, EventArgs e)
            {
                formatName(txtLast);
            }

            private void txtFirst_Leave(object sender, EventArgs e)
            {
                formatName(txtFirst);
            }

            private bool validateData(Control.ControlCollection objControls)
            {
                bool blBreak = true;
                foreach (Control objControl in objControls)
                {
                    System.Type objType = objControl.GetType();
                    string strType = objType.Name;


                    if ((strType == "TextBox" | strType == "ComboBox" | strType == "MaskedTextBox" | strType == "DateTimePicker") && objControl.Tag != "NotRequired")
                    {
                        string strData = pullData(objControl.Text);
                        if (strData == "")
                        {
                            MessageBox.Show("You did not fill in all the required fields");
                            objControl.Focus();
                            blBreak = false;
                            break;
                        }
                    }
                    else if (strType == "GroupBox")
                    {
                        blBreak = validateData(objControl.Controls);
                        if (blBreak == false)
                        {
                            break;
                        }
                    }
                }

                return blBreak;
            }

            private string pullData(string strData)
            {
                string strReturn = "";
                if (strData.Length > 0)
                {
                    strReturn = strData;
                    //create sql string
                }
                else
                {
                    strReturn = "";
                }

                return strReturn;
            }

            private void txtUnits_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar)
                    && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if (e.KeyChar == '.'
                    && (sender as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }

            }

        #endregion

        #region Tab_Vouchers

            private void butAddVoucher_Click(object sender, EventArgs e)
            {
                addNewVoucher();

            }

            private void addNewVoucher()
            {
                clsDB objDB = new clsDB(resPinnacle.liveDB);

                string SQL = "Insert Into Voucher(Start,End,Consumer_ID)";

                clsFormat objFormat = new clsFormat();
                SQL = SQL + " Values('" + objFormat.formatDate(dtVoucherStart.Text) + "','" + objFormat.formatDate(dtVoucherEnd.Text)+ "','" + ID + "')";

                bool blPass = objDB.executeNonQuery(SQL);
                fillGridVoucher();
            }

            private void fillGridVoucher()
        {
            string SQL = "Select id";
            SQL = SQL + ", strftime('%m/%d/%Y',Start) as Start";
	        SQL = SQL + ", strftime('%m/%d/%Y',End) as End ";
            SQL = SQL + " From Voucher";
            SQL = SQL + " Where Consumer_ID = " + ID;

            clsDB objDB = new clsDB(resPinnacle.liveDB);
            SQLiteDataReader objReader = objDB.returnDataReader(SQL);
            clsGridUtils objGrid = new clsGridUtils();
            objGrid.fillGrid(objReader,1,ref grdVouchers,this.CreateGraphics());
            
        }

            private void contextVoucher_Click(object sender, EventArgs e)
        {
            DialogResult Response = MessageBox.Show("Are you sure you want to delete the selected voucher.", "Delete Voucher", MessageBoxButtons.YesNo);
            if (Response == DialogResult.Yes)
            {
                DeleteVoucher();
            }
        }

            private void DeleteVoucher()
        {
            string strVoucherID = grdVouchers.SelectedRows[0].Cells[0].Value.ToString();

            string SQL = "Delete From Voucher";
            SQL = SQL + " Where ID = " + strVoucherID;

            clsDB objDB = new clsDB(resPinnacle.liveDB);
            bool blPass = objDB.executeNonQuery(SQL);
            if (blPass == true)
                fillGridVoucher();
            else
                MessageBox.Show("There was an error, your voucher was not deleted. If problem persists please notify IT.");
        }
 


#endregion

        #region Tab_AssignedTo

            private void fillAddStaff(bool EditStaff)
            {
                if (EditStaff == true)
                    getAssignedStaff();
                // else // Need to add condition to fill controls in tab.
             }

            private void addStaff(string strStaff)
            {
                StaffID objStaff = new StaffID();
                    lstStaff.Items.Add(cmbStaff.Text);
                    clsDB objDB = new clsDB(resPinnacle.liveDB);
                    string SQL = "Select ID";
                    SQL = SQL + " From Staff";
                    SQL = SQL + " Where Staff.FirstName || ' ' || LastName = '" + strStaff + "'";

                    SQLiteDataReader objReader = objDB.returnDataReader(SQL);
                    while (objReader.Read())
                        objStaff.ID = objReader[0].ToString();
                        objStaff.Name = strStaff; 
                        StaffIDs.Add(objStaff);
            }

            private void getAssignedStaff()
            {
                clsDB objDB = new clsDB(resPinnacle.liveDB);
                string SQL = "Select Staff.FirstName || ' ' || Staff.LastName as Staff";
                SQL = SQL + " From Staff";
                SQL = SQL + " Join ConsumerStaff on Staff.ID=ConsumerStaff.Staff_ID";
                SQL = SQL + " Where ConsumerStaff.Consumer_ID = '" + ID + "'";

                SQLiteDataReader objReader = objDB.returnDataReader(SQL);
                string strStaff="";
                while (objReader.Read())
                {   
                    strStaff = objReader[0].ToString();
                    int intSpot = lstStaff.FindString(strStaff);
                    if (intSpot == -1)
                        lstStaff.Items.Add(strStaff);
                }
                getAssignedVRC();
            }

            private void getAssignedVRC()
            {
                clsDB objDB = new clsDB(resPinnacle.liveDB);
                string SQL = "Select VRC.FirstName || ' ' || VRC.LastName as VRC";
                SQL = SQL + " From VRC";
                SQL = SQL + "   Join Consumer on VRC.ID = Consumer.VRC_ID";
                SQL = SQL + "  Where Consumer.ID = " + ID; 

                SQLiteDataReader objReader = objDB.returnDataReader(SQL);
                while (objReader.Read())
                    cmbCounselor.SelectedIndex = cmbCounselor.FindString(objReader[0].ToString());
            }

            private void butAddStaff_Click(object sender, EventArgs e)
            {
                bool blNotAdded = false;
                blNotAdded = lstStaff.Items.Contains(cmbStaff.Text);
                if (blNotAdded == false)
                    addStaff(cmbStaff.Text);
            }

            private void butAssign_Click(object sender, EventArgs e)
            {
                string Status = "Updating Staff";
                bool blPass = updateStaff();
            
                if (blPass == true)
                {
                    Status = "Removing Staff";
                    blPass = removeStaff_DB();
                    if (blPass == true)
                    {
                        Status = "Updating Counselour";
                        blPass = updateVRC();
                    }
                }

                if (blPass == false)
                    MessageBox.Show("Error - " + Status);
                else
                    MessageBox.Show("The staff has been updated");

                getAssignedStaff();
                getAssignedVRC();
            }

            private bool updateStaff()
            {
                clsDB objDB = new clsDB(resPinnacle.liveDB);
                bool blPass = true; // if value is not updated it will return false

                // Creating SQL to update ConsumerSTaff
                for (int j = 0; j < StaffIDs.Count; j++)
                {
                    string SQL = "Insert into ConsumerStaff(Staff_ID, Consumer_ID)";
                    SQL = SQL + " Values(" + StaffIDs[j].ID + "," + ID + ")";
                    blPass = objDB.executeNonQuery(SQL);

                    if (blPass != true)
                        break;
                }

                return blPass;
            }

            private void butRemoveStaff_Click(object sender, EventArgs e)
            {
                removeStaff(lstStaff.SelectedItem.ToString());
            }

            private void removeStaff(string strStaff)
            {
                bool blRemoved = false;
                //checking array StaffIDs to make sure the staff member is not included.
                for (int j = 0; j < StaffIDs.Count; j++)
                {
                    if (StaffIDs[j].Name == strStaff)
                    {
                        StaffIDs.RemoveAt(j);
                        blRemoved = true;
                    }
                }

                if (blRemoved == false)
                {
                    deleteStaff.Add(strStaff);
                }

                lstStaff.Items.Remove(lstStaff.SelectedItem);
            }

            private bool removeStaff_DB()
            {
                string SQL = "";
                clsDB objDB = new clsDB(resPinnacle.liveDB);
                bool blPass = true; // if value is not updated it will return false
                for(int j = 0 ; j < deleteStaff.Count;j++)
                {
                    SQL = "Delete from ConsumerStaff Where ConsumerStaff.ID = (";
                    SQL = SQL + " Select ConsumerStaff.ID from ConsumerStaff";
	                SQL = SQL + " Join Staff on ConsumerStaff.Staff_ID = Staff.ID";
                    SQL = SQL + " Where Consumer_ID = " + ID; 
                    SQL = SQL + " and Staff.FirstName || ' ' || Staff.LastName = '" + deleteStaff[j]  + "')";

                    blPass = objDB.executeNonQuery(SQL);
                }

                return blPass;
            }

            private bool updateVRC()
            {
                clsDB objDB = new clsDB(resPinnacle.liveDB);

                string SQL = "Update Consumer";
                if (cmbCounselor.Text == "")
                    SQL = SQL + " Set VRC_ID = null";
                else
                {
                    SQL = SQL + " Set VRC_ID = (Select VRC.ID From VRC Where VRC.FirstName || ' ' || VRC.LastName = '" + cmbCounselor.Text + "'";
                    SQL = SQL + " and Consumer.ID = " + ID + ")";
                }
                SQL = SQL + " Where Consumer.ID = " + ID;

                bool blPass = objDB.executeNonQuery(SQL);
                return blPass;
            }

        #endregion

        #region SQL

            private string returnAddConsumerSQL(clsDB objDB)
            {
                string SQL = "Insert into Consumer(SSN,AVR, VESID, FirstName, LastName, Disability_ID, Service_ID,Units, Funding_ID, ReferralDate,IntakeDate)";
                SQL = SQL + " Values(";
                SQL = SQL + "'" + txtSSN.Text + "'";
                SQL = SQL + ",'" + txtAVR.Text + "'";
                SQL = SQL + ",'" + txtVesid.Text + "'";
                SQL = SQL + ",'" + txtFirst.Text + "'";
                SQL = SQL + ",'" + txtLast.Text + "'";
                SQL = SQL + ",'" + objDB.returnComboBox_Key("Disability", "Description", cmbDisability.Text) + "'";
                SQL = SQL + ",'" + cmbService.Text + "'";
                SQL = SQL + ",'" + txtUnits.Text + "'";
                SQL = SQL + ",'" + objDB.returnComboBox_Key("Funding", "Description", cmbFunding.Text) + "'";


                clsFormat objFormat = new clsFormat();
                if (dtReferral.Checked == true)
                    SQL = SQL + ", " + objFormat.formatDate(dtReferral.Text);
                else
                    SQL = SQL + ", null";

                if (dtIntake.Checked == true)
                    SQL = SQL + ", " + objFormat.formatDate(dtIntake.Text);
                else
                    SQL = SQL + ", null";

                SQL = SQL + ")";
                return SQL;
            }

            private string returnUpdateConsumerSQL(clsDB objDB)
            {
                string strSQL = "Update Consumer";
                strSQL = strSQL + " Set FirstName = '" + txtFirst.Text + "'";
                strSQL = strSQL + ", LastName= '" + txtLast.Text + "'";
                strSQL = strSQL + ", SSN = '" + txtSSN.Text + "'";
                strSQL = strSQL + ", AVR = '" + txtAVR.Text + "'";
                strSQL = strSQL + ", VESID = '" + txtVesid.Text + "'";
                strSQL = strSQL + ", Units = '" + txtUnits.Text + "'";
                strSQL = strSQL + ", Service_ID = '" + cmbService.Text + "'";
                strSQL = strSQL + ", Disability_ID = '" + objDB.returnComboBox_Key("Disability", "Description", cmbDisability.Text) + "'";
                strSQL = strSQL + ", Funding_ID = '" + objDB.returnComboBox_Key("Funding", "Description", cmbFunding.Text) + "'";

                clsFormat objFormat = new clsFormat();
                if (dtReferral.Checked == true)
                    strSQL = strSQL + ", ReferralDate = " + objFormat.formatDate(dtReferral.Text);
                else
                    strSQL = strSQL + ", ReferralDate = null";

                if (dtIntake.Checked == true)
                    strSQL = strSQL + ", IntakeDate = " + objFormat.formatDate(dtIntake.Text);
                else
                    strSQL = strSQL + ", IntakeDate = null";

                strSQL = strSQL + " Where Consumer.ID = " + ID;

                strSQL = strSQL.Replace("'   -  -'", "null");
                strSQL = strSQL.Replace("''", "null");
                return strSQL;
            }

        #endregion

        private void tabConsumerInfo_Click(object sender, EventArgs e)
        {
            int intTab = tabConsumerInfo.SelectedIndex;

            if (intTab == 0) //tab Consumer
            {
                    
            }
            else if (intTab == 1 && ID!=null) //tab AssignedTo
            {
                ((Control)tabAssigned).Enabled = true;
                
                getAssignedStaff();
            }
            else if (intTab == 2 && ID != null) // tab Voucher
            {
                ((Control)tabVoucher).Enabled = true;
                fillGridVoucher();
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            CancelControl("AddUser");
        }

        private void fillCombobox(ComboBox objCombo, string strTable)
        {
            clsDB objDB = new clsDB(resPinnacle.liveDB);

            SQLiteDataReader objReader = objDB.returnComboBox(strTable);

            while (objReader.Read())
            {
                objCombo.Items.Add(objReader[0]);
            }
            objCombo.SelectedIndex = -1;
            objReader.Close();

            // adding empty space
            objCombo.Items.Add("");
        }

        private void setCombobox(ComboBox objCombo, string strItem)
        {
            for (int j = 0; j < objCombo.Items.Count; j++)
            {
                if (objCombo.Items[j].ToString() == strItem)
                {
                    objCombo.SelectedIndex = j;
                    break;
                }

            }
        }

        private void ClearControl(Control.ControlCollection objControls)
        {
            foreach (Control objControl in objControls)
            {
                System.Type objType = objControl.GetType();
                string strType = objType.Name;
                if (strType == "TextBox" | strType == "MaskedTextBox")
                    objControl.Text = "";
                else if (strType == "ComboBox")
                    ((ComboBox)objControl).SelectedIndex = -1;
                else if (strType == "DateTimePicker")
                    ((DateTimePicker)objControl).Value = DateTime.Now;
                else if (strType == "GroupBox")
                    ClearControl(objControl.Controls);
            }


        }
 
  
  
        
    }
}
