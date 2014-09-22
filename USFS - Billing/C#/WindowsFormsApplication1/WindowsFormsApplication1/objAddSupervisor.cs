using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class objAssignSupervisor : UserControl
    {

        string strCurrentItem;
        DataTable dtWorkers;
        string strAction;
        // for reloading control
        string strDtDay = "";
        int intCmbShift = -1;
        int intCmbSupervisor = -1;
        int intWarning = 0; 
        



        public objAssignSupervisor()
        {
            InitializeComponent();
            LoadControl();
        }
    
        private void LoadControl()
        {

            if (intCmbShift != -1)
            {
                cmbShift.SelectedIndex = intCmbShift;
            }

            Load_dtDay();
            FillComboboxes();
            Load_ListBoxes();
        }

        


    
        private DataTable QueryDB(string strSQL)
        {
            objDatabase Database = new objDatabase();
            DataTable objDTable;


            return objDTable = Database.ReturnDataTable(strSQL);
        }

        private int UpdateDB(string strSQL)
        {
            objDatabase Database = new objDatabase();
            int intRows;

            return intRows = Database.AddData(strSQL);
        }

        private void Load_dtDay()
        {
            DateTime Today = System.DateTime.Now;
            DateTime StartDay = new DateTime(2010, 8, 26);
            int intDay = DateTime.Compare(Today, StartDay);

            if (strDtDay != "")
            {
                dtDay.Text = strDtDay;
            }
            else if (intDay <= 0)
            {
                dtDay.Text = StartDay.ToString();
            }
            else
            {
                dtDay.Text = Today.ToString();
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            string strPass;
            string strDBAction;
            
            while (lstWorkers.SelectedItems.Count > 0)
            {
                lstAssigned.DrawMode = DrawMode.OwnerDrawFixed;
                strPass = lstWorkers.SelectedItem.ToString();
                strCurrentItem = strCurrentItem + "|" + lstWorkers.SelectedItem.ToString();

                strDBAction = Update_dtAssigned(lstWorkers.SelectedItem.ToString(), cmbShift.Text, "Add");
                if (strDBAction == "Update")
                {
                    strAction = "Add";
                    lstAssigned.Items.Add(strPass);
                }
                else if (strDBAction == "")
                {
                    lstAssigned.Items.Remove(strPass);
                    strAction = "";
                    lstAssigned.Items.Add(strPass);
                }
                lstWorkers.Items.Remove(lstWorkers.SelectedItem);
            }
        }
        

          private string Update_dtAssigned(string strPerson, string strNewShift, string strStatus)
        {
            string strDBAction = "";

            foreach(DataRow objRow in dtWorkers.Rows)
            {
                if (objRow["Name"].ToString() == strPerson)
                {
                    if (objRow["Action"].ToString() == "Scheduled")
                    {
                        objRow["Action"] = strStatus;
                        strDBAction = "Update";
                    }
                    else if (objRow["Action"].ToString() != "")
                    {
                        objRow["Action"] = "";
                        strDBAction = "";
                    }
                    else
                    {
                        objRow["Action"] = strStatus;
                        strDBAction = "Update";
                    }
                
                    
                    //objRow["Shift"] = strNewShift;
                }
            }
            return strDBAction;
        }


        private void Load_ListBoxes()
        {
            string strSQL, strLast, strFirst;
            string[] strName;

            if (cmbSupervisor.Items.Count > 0 && cmbSupervisor.Text != "")
            {
                strName = cmbSupervisor.Text.Split();
                strFirst = strName[0];
                strLast = strName[1];

                lstWorkers.Items.Clear();
                lstAssigned.Items.Clear();
                strSQL = "spReturnSupervisor '" + cmbShift.Text + "', '" + dtDay.Value.ToShortDateString() + "',  '" + strLast + "',  '" + strFirst + "'";
                dtWorkers = QueryDB(strSQL);

                foreach (DataRow objRow in dtWorkers.Rows)
                {
                    if (objRow["Action"].ToString().Length <= 0)
                    {
                        lstWorkers.Items.Add(objRow["Name"]);
                    }
                    else
                    {
                        lstAssigned.Items.Add(objRow["Name"]);
                    }
                }
            }
            else 
            {
                if (intWarning == 0)
                {
                    lstWorkers.Items.Clear();
                    lstAssigned.Items.Clear();
                    MessageBox.Show(@"You have not assigned a supervisor for the current shift. Click on ""Manage schedule"" and add a supervisor to the current shift.");
                    intWarning++;
                }
                else
                {
                    intWarning = 0;
                }
            }
        }

        private void lstAssigned_DrawItem(object sender, DrawItemEventArgs e)
        {
            {
                e.DrawBackground();

                CheckStatus(lstAssigned.Items[e.Index].ToString());
                if (strAction != "")
                {
                    if (strAction == "Add")
                    {
                        e.Graphics.DrawString(lstAssigned.Items[e.Index].ToString(), new Font("Arial", 8, FontStyle.Bold), Brushes.Black, e.Bounds);
                    }
                    else if (strAction == "Delete")
                    {
                        e.Graphics.DrawString(lstAssigned.Items[e.Index].ToString(), new Font("Arial", 8, FontStyle.Strikeout), Brushes.Black, e.Bounds);
                    }
                    else
                    {
                        e.Graphics.DrawString(lstAssigned.Items[e.Index].ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, e.Bounds);
                    }
                    e.DrawFocusRectangle();
                    strCurrentItem = strCurrentItem.Replace(lstAssigned.Items[e.Index].ToString(), "");
                }
            }
        }

        private void CheckStatus(string strItem)
        {
            
            foreach (DataRow objRow in dtWorkers.Rows)
            {
                if (objRow["Name"].ToString() == strItem)
                {
                    strAction = objRow["Action"].ToString();
                }
            }
        }

        private void butRemove_Click(object sender, EventArgs e)
        {
            string strDBAction;
            string strPass;

            while (lstAssigned.SelectedItems.Count > 0)
            {
                strCurrentItem = strCurrentItem + "|" + lstAssigned.SelectedItem.ToString();
                strPass = lstAssigned.SelectedItem.ToString();
                lstWorkers.Items.Add(lstAssigned.SelectedItem.ToString());
                lstAssigned.DrawMode = DrawMode.OwnerDrawFixed;
                strDBAction = Update_dtAssigned(lstAssigned.SelectedItem.ToString(), cmbShift.Text, "Delete");
                lstAssigned.Items.Remove(lstAssigned.SelectedItem);

                if (strDBAction == "Update" )
                {
                    strAction = "Delete";
                    lstAssigned.Items.Add(strPass);
                }

            }
        }

        private void butEnter_Click(object sender, EventArgs e)
        {
            string[] strSupervisor;
            string[] strWorker;
            int intRows = 0;
            string strSQL;
            objDatabase Database = new objDatabase();

            strSupervisor = cmbSupervisor.SelectedItem.ToString().Split(' ');

            //Loop through all entries in dtWorkers 
            foreach (DataRow objRow in dtWorkers.Rows)
            {
                strWorker = objRow["Name"].ToString().Split(' ');
                if (objRow["Action"].ToString()== "Add")
                {
                    strSQL = "spUpdateSupervisor " + "'" + strSupervisor[0] + "','" + strSupervisor[1] + "','" + strWorker[0] + "','" + strWorker[1] + "','" + dtDay.Text.ToString() + "','" + cmbShift.SelectedItem.ToString() + "'";
                    intRows = intRows + Database.AddData(strSQL);  
                }
                else if (objRow["Action"].ToString() == "Delete")
                {
                    strSQL = "spRemoveSupervisor " + "'" + strSupervisor[0] + "','" + strSupervisor[1] + "','" + strWorker[0] + "','" + strWorker[1] + "','" + dtDay.Text.ToString() + "','" + cmbShift.SelectedItem.ToString() + "'";
                    intRows = intRows + Database.AddData(strSQL);  

                }
            }

            MessageBox.Show(intRows.ToString() + " rows have been updated.");

            strDtDay = dtDay.Value.ToShortDateString();
            intCmbShift = cmbShift.SelectedIndex;
            intCmbSupervisor = cmbSupervisor.SelectedIndex;

            LoadControl();
        
        }

        private void cmbShift_SelectedValueChanged(object sender, EventArgs e)
        {
            string strSQL;

            cmbSupervisor.Items.Clear();
            strSQL = "spFillcmbSupervisor '" + dtDay.Value.ToShortDateString() + "','" + cmbShift.Text + "'";

            Load_ComboBox(cmbSupervisor, strSQL,intCmbShift);
            Load_ListBoxes();
        }

        private void cmbSupervisor_SelectedValueChanged(object sender, EventArgs e)
        {
            Load_ListBoxes();
        }

        private void dtDay_ValueChanged(object sender, EventArgs e)
        {
            FillComboboxes();
            Load_ListBoxes();
        }


        private void FillComboboxes()
        {
            cmbShift.Items.Clear();
            Load_ComboBox(cmbShift, "Select Name From Shift", intCmbShift);
            

            
            cmbSupervisor.Items.Clear();
            // Loading cmbSupervisor
            string strSQL = "spFillcmbSupervisor '" + dtDay.Value.ToShortDateString() + "','" + cmbShift.Text + "'";
            Load_ComboBox(cmbSupervisor, strSQL, intCmbSupervisor);

        }

        private void Load_ComboBox(ComboBox objCombo, string strSQL, int intIndex)
        {
            DataTable objTable = QueryDB(strSQL);

            try
            {

                objCombo.Items.Clear();
                foreach (DataRow objRow in objTable.Rows)
                {
                    objCombo.Items.Add(objRow[0].ToString());
                }

                if (objCombo.Items.Count > 1 && intIndex > -1)
                {
                    objCombo.SelectedIndex = intIndex;
                }
                else
                {
                    objCombo.SelectedIndex = 0;
                }
            }
            catch{
                if (objCombo.Items.Count > 0)
                {
                    objCombo.SelectedIndex = 0;
                }
            }
                
        }

    }
}

