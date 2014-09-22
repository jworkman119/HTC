using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class objCreateSchedule : UserControl
    {

        DataTable dtSchedule;
        string strCurrentItem;
        string strAction;
        int intCmbShiftIndex = -1;
        string strDtDay = "";
        
        
        public objCreateSchedule()
        {
            strAction = "";
            InitializeComponent();
            LoadControl();
        }


        private void LoadControl()
        {
            lstScheduled.Items.Clear();
            Load_dtFair();
            Load_cmbShift();

            if (strDtDay != "")
            {
                dtDay.Text = strDtDay;
            }


            if (intCmbShiftIndex > -1)
            {
                cmbShift.SelectedIndex = intCmbShiftIndex;
                update_ListBoxes();

            }
        }

        private void Load_dtFair()
        {
            DateTime Today = System.DateTime.Now;
            DateTime StartDay = new DateTime(2010,8,26); 
            int intDay = DateTime.Compare(Today,StartDay);

            if (intDay <= 0)
            {
                dtDay.Text = StartDay.ToString();
            }
            else
            {
                dtDay.Text = Today.ToString();
            }
        }

        private void Load_cmbShift()
        {
            objDatabase Database = new objDatabase();
            string strSQL = "Select Shift.Name from Shift";
            SqlDataReader objReader;

            cmbShift.Items.Clear();
            objReader = Database.ReturnData(strSQL);

            while (objReader.Read())
            {
                cmbShift.Items.Add(objReader[0].ToString());
                cmbShift.SelectedIndex = 0;
            }
            

        }

        private void cmbShift_SelectedIndexChanged(object sender, EventArgs e)
        {

            update_ListBoxes();

        }


        private void update_ListBoxes()
        {
            if (dtDay.Value.ToShortDateString() != "")
            {
                lstScheduled.Items.Clear();
                lstWorkers.Items.Clear();

                objDatabase Database = new objDatabase();
                string strSQL = "spReturnSchedule '" + dtDay.Value.ToShortDateString() + "'";

                dtSchedule = Database.ReturnDataTable(strSQL);
                dtSchedule.Columns.Add("Action", typeof(string));


                foreach (DataRow objRow in dtSchedule.Rows)
                {
                    if (objRow["Shift"].ToString() == cmbShift.Text)
                    {
                        lstScheduled.DrawMode = DrawMode.OwnerDrawFixed;
                        lstScheduled.Items.Add(objRow["Worker"]);
                    }
                    else if (objRow["Shift"].ToString() == "")
                    {
                        lstWorkers.DrawMode = DrawMode.OwnerDrawFixed;
                        strCurrentItem = strCurrentItem + "|" + objRow["Worker"];
                        lstWorkers.Items.Add(objRow["Worker"]);
                    }
                }
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            while(lstWorkers.SelectedItems.Count > 0)
            {
                string strDBAction;
                string strPass;
                
                lstScheduled.DrawMode = DrawMode.OwnerDrawFixed;
                strPass = lstWorkers.SelectedItem.ToString();
                strCurrentItem = strCurrentItem + "|" + lstWorkers.SelectedItem.ToString();
                //strAction = "Add";
                strDBAction = Update_dtSchedule(lstWorkers.SelectedItem.ToString(), cmbShift.Text, "new");
                if (strDBAction == "Update")
                {
                    strAction = "Add";
                    lstScheduled.Items.Add(strPass);
                }
                else if (strDBAction == "")
                {
                    lstScheduled.Items.Remove(strPass);
                    strAction = "";
                    lstScheduled.Items.Add(strPass);
                }
                lstWorkers.Items.Remove(lstWorkers.SelectedItem);
            }
            //lstScheduled.Items.Add();
        }

        private void butRemove_Click(object sender, EventArgs e)
        {
            string strDBAction;
            string strPass;

            while(lstScheduled.SelectedItems.Count > 0) 
            {
                strCurrentItem = strCurrentItem + "|" + lstScheduled.SelectedItem.ToString();
                strPass = lstScheduled.SelectedItem.ToString();
                lstWorkers.Items.Add(lstScheduled.SelectedItem.ToString());
                lstScheduled.DrawMode = DrawMode.OwnerDrawFixed;
                strDBAction = Update_dtSchedule(lstScheduled.SelectedItem.ToString(), cmbShift.Text, "delete");
                lstScheduled.Items.Remove(lstScheduled.SelectedItem);

                if (strDBAction == "Update")
                {
                    strAction = "Delete";
                    lstScheduled.Items.Add(strPass);
                }
                
            }
        }

        private void butEnter_Click(object sender, EventArgs e)
        {
            objDatabase Database = new objDatabase();
            string strSQL;
            string strMsg = "";
            int intRows = 0, intDelete = 0 , intAdd = 0;

            Cursor.Current = Cursors.WaitCursor;
            foreach (DataRow objRow in dtSchedule.Rows)
            {
                if (objRow["Action"].ToString().Length > 0)
                {
                    strSQL = "spAddSchedule '" + objRow["Worker"] + "','" + objRow["shift"] + "','" + dtDay.Text + "','" + objRow["Action"] + "'";
                    //update database
                    intRows = Database.AddData(strSQL);
                    if (objRow["Action"].ToString() == "delete")
                    {
                        intDelete = intRows + intDelete;
                    }
                    else if (objRow["Action"].ToString() == "new")
                    {
                        intAdd = intRows + intAdd;
                    }
                }
            }
            Cursor.Current = Cursors.Default;

            if (intAdd > 0)
            {
                strMsg = intAdd.ToString() + " worker(s) have been added to the " + cmbShift.Text + "."; 
            }
            
            if (intDelete > 0)
            {
                if (strMsg.Length > 0)
                {
                    strMsg = strMsg + "\r\n";
                }

                strMsg = strMsg + intDelete.ToString() + " worker(s) have been removed from the " + cmbShift.Text + ".";
            }

            MessageBox.Show(strMsg);
            intCmbShiftIndex = cmbShift.SelectedIndex;
            strDtDay = dtDay.Value.ToLongDateString();
            lstScheduled.Items.Clear();
            lstWorkers.Items.Clear();
            strAction = "";
            LoadControl();
        }

        private string Update_dtSchedule(string strPerson, string strNewShift, string strStatus)
        {
            string strDBAction = "";

            foreach(DataRow objRow in dtSchedule.Rows)
            {
                if (objRow["Worker"].ToString() == strPerson)
                {
                    if (objRow["Action"].ToString() != "")
                    {
                        objRow["Action"] = "";
                        strDBAction = "";
                    }
                    else
                    {
                        objRow["Action"] = strStatus;
                        strDBAction = "Update";
                    }
                    objRow["Shift"] = strNewShift;
                }
            }
            return strDBAction;
        }

        private void lstScheduled_DrawItem(object sender, DrawItemEventArgs e)
        {
            drawListBox(lstScheduled, sender, e);
        }


        private void lstWorkers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (lstWorkers.Items.Count > 0)
            {
                drawListBox(lstWorkers, sender, e);
            }
        }

        private void drawListBox(ListBox objListBox, object sender, DrawItemEventArgs e)
        {
            string strRole = Return_Role(objListBox.Items[e.Index].ToString());
            Brush objBrushes;

            if (strRole == "Supervisor")
            {
                objBrushes = Brushes.Red;
            }
            else
            {
                objBrushes = Brushes.Black;
            }

            e.DrawBackground();
            if ((strCurrentItem.IndexOf(objListBox.Items[e.Index].ToString()) >= 0) && (strAction == "Add") && (objListBox.Name.ToString() != "lstWorkers"))
            {
                e.Graphics.DrawString(objListBox.Items[e.Index].ToString(), new Font("Arial", 8, FontStyle.Bold), objBrushes, e.Bounds);
            }
            else if ((strCurrentItem.IndexOf(objListBox.Items[e.Index].ToString()) >= 0) && (strAction == "Delete"))
            {
                e.Graphics.DrawString(objListBox.Items[e.Index].ToString(), new Font("Arial", 8, FontStyle.Strikeout), objBrushes, e.Bounds);
            }
            else
            {
                e.Graphics.DrawString(objListBox.Items[e.Index].ToString(), new Font("Arial", 8, FontStyle.Regular), objBrushes, e.Bounds);
            }
            e.DrawFocusRectangle();
            strCurrentItem = strCurrentItem.Replace(objListBox.Items[e.Index].ToString(), "");

        }

        private string Return_Role(string strName)
        {
            string strRole = "";

            foreach (DataRow objRow in dtSchedule.Rows)
            {
                if (objRow["Worker"].ToString() == strName)
                {
                    strRole = objRow["Role"].ToString();
                }
            }

            return strRole;
        }

        private void dtDay_ValueChanged(object sender, EventArgs e)
        {
            update_ListBoxes();
        }

       


    }
}
