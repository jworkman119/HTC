using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    
    public partial class frmChangeTime : Form
    {
        
        private string strID;
        private DataTable dtTimes;

        public frmChangeTime()
        {
            
            InitializeComponent();
            LoadControl();
        }


        /******* Properties **************/
        public string Worker
        {
            set
            {
                lblHeading.Text = value;
            }
            
        }


        public string WorkerID
        {
            
            set
            {
                strID = value;
                FillGrid();
            }
        }
        /******* End Properties **********/
       

        /****************** Functions ******************/
        private void LoadControl()
        {
            dtStart.Text = dtStart.MinDate.ToString();
            dtEnd.Text = dtEnd.MinDate.ToString();

            butUpdate.Enabled = false;
            butAdd.Enabled = true;
            butAdjust.Enabled = false;

         
        }


        private void FillDataTable()
        {
            objDatabase Database = new objDatabase();
        }

        private void FillGrid()
        {
            objDatabase Database = new objDatabase();
            string strSQL = "spReturnUserTime " + strID;
            dtTimes = Database.ReturnDataTable(strSQL); 

            grdTimes.Columns.Clear();
            grdTimes.DataSource = dtTimes;

            grdTimes.Columns[0].Visible = false;
            grdTimes.Columns[2].Visible = false;
            grdTimes.Columns[4].Visible = false;
            grdTimes.Columns[5].Visible = false;

            SetupDateTime(dtStart, chkAddStartTime, false);
            SetupDateTime(dtEnd, chkAddEndTime, false);
           
            butAdjust.Enabled = false;
            butAdd.Enabled = false;
        }
            
        
        

        private void grdTimes_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow objRow = grdTimes.CurrentRow;

            objRow.Selected = true;

            dtStart.Text = objRow.Cells[1].Value.ToString();
            if (objRow.Cells[3].Value.ToString().Length > 0)
            {
                dtEnd.Text = objRow.Cells[3].Value.ToString();
                butAdjust.Enabled = true;
                SetupDateTime(dtStart, chkAddStartTime, true);
                SetupDateTime(dtEnd, chkAddEndTime, true);
            }
            else
            {
                SetupDateTime(dtStart, chkAddStartTime, true);
                SetupDateTime(dtEnd, chkAddEndTime, false);
                butAdjust.Enabled = false;
            }

            //Changing enable on buttons
            butAdd.Enabled = false;
            

        }

        private void FillTextBoxes(DataGridViewRow objRow)
        {
          
            dtStart.Text = objRow.Cells[1].Value.ToString();
            dtEnd.Text = objRow.Cells[3].Value.ToString();
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow objRow = grdTimes.CurrentRow;

            objRow.DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Strikeout);
            if (objRow.Cells[3].Value.ToString().Length > 0)
            {
                objRow.Cells[5].Value = "D";
            }
            objRow.Cells[4].Value = "D";

            butUpdate.Enabled = true;
        }

        private void butAdjust_Click(object sender, EventArgs e)
        {
            DataGridViewRow objRow = grdTimes.CurrentRow;
            DataGridViewCell objStartTime = objRow.Cells[1];
            DataGridViewCell objEndTime = objRow.Cells[3];

            string strDataCheck = Check_Data();

            if (strDataCheck == "")
            {
                if (dtStart.Text != objStartTime.Value.ToString())
                {
                    objStartTime.Value = dtStart.Text;
                    objRow.Cells[4].Value = "C"; // C = Change
                    objStartTime.Style.Font = new Font("Arial", 9, FontStyle.Bold);
                }

                if (objEndTime.Value != null)
                {
                    if (dtEnd.Text != objEndTime.Value.ToString())
                    {
                        objEndTime.Value = dtEnd.Text;
                        objRow.Cells[5].Value = "C"; //C = Change
                        objEndTime.Style.Font = new Font("Arial", 9, FontStyle.Bold);
                    }
                }
                else
                {
                    objEndTime.Value = dtEnd.Text;
                    objRow.Cells[5].Value = "A"; // A = Add
                    objEndTime.Style.Font = new Font("Arial", 9, FontStyle.Italic);
                }

                butUpdate.Enabled = true;
            }
            else
            {
                MessageBox.Show(strDataCheck);
            }

            butClear.PerformClick();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            DateTime StartTime = dtStart.Value;
            DateTime EndTime = dtEnd.Value;
            TimeSpan TimeDifference = EndTime - StartTime;

      

            if (chkAddStartTime.Checked == true)
            {
                AddNewRow();
            }
            else if (grdTimes.CurrentRow.Cells[3].Value != null)
            {
                DataGridViewRow objRow = grdTimes.Rows[grdTimes.Rows.Count - 1];
                if (dtEnd.Enabled == true)
                {
                    objRow.Cells[1].Value = dtStart.Text;
                    objRow.Cells[3].Style.Font = new Font("Arial", 9, FontStyle.Bold);
                    objRow.Cells[3].Value = dtEnd.Text;

                    objRow.Cells[5].Value = "A";
                }
            }
            else 
            {
                updateCurrentRow();
            }

            butUpdate.Enabled = true;
            butClear.PerformClick();
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            int intRows = 0;
            string strAction;
            string strSQL;
 
            foreach (DataGridViewRow objRow in grdTimes.Rows)
            {
                if (objRow.Cells[4].Value.ToString() != "")
                {
                    strAction = objRow.Cells[4].Value.ToString();
                    if (strAction != "A")
                    {
                        strSQL = "spUpdateTime2 '" + strAction + "','" + objRow.Cells[0].Value.ToString() + "','" + objRow.Cells[1].Value.ToString() + "'";
                        intRows = intRows + UpdateDatabase(strSQL);
                    }
                    else
                    {
                        strSQL = "spUpdateTime_In '" + objRow.Cells[1].Value.ToString() + "','" + strID.ToString() + "'";
                        intRows = intRows + UpdateDatabase(strSQL);
                    }
                }

                if (objRow.Cells[5].Value.ToString() != "")
                {
                    strAction = objRow.Cells[5].Value.ToString();
                    if (strAction != "A")
                    {
                        strSQL = "spUpdateTime2 '" + strAction + "','" + objRow.Cells[2].Value.ToString() + "','" + objRow.Cells[3].Value.ToString() + "'";
                        intRows = intRows + UpdateDatabase(strSQL);
                        
                    }
                    else
                    {
                        strSQL = "spUpdateTime_Out '" + objRow.Cells[3].Value.ToString() + "','" + strID.ToString() +"'";
                        intRows = intRows + UpdateDatabase(strSQL);
                    }                
                }
            }


            MessageBox.Show(intRows.ToString() + " times have been updated.");
            butClear.PerformClick();
            FillGrid();
            
        }

        private int UpdateDatabase(string strSQL)
        {
            objDatabase Database = new objDatabase();

                
                return Database.AddData(strSQL);
        }

        

        private void butClear_Click(object sender, EventArgs e)
        {
            dtEnd.Text = dtEnd.MinDate.ToString();
            dtStart.Text = dtEnd.MinDate.ToString();

            SetupDateTime(dtStart, chkAddStartTime, false);
            SetupDateTime(dtEnd, chkAddEndTime, false);

            butAdjust.Enabled = false;
            butAdd.Enabled = false;
        }


        private string Check_Data()
        {
            string strReturn = "";
            
            DateTime dtIn = DateTime.Parse(dtStart.Text);
            DateTime dtNewOut = DateTime.Parse(dtEnd.Text);
            
            if (grdTimes.CurrentRow.Index > 0)
            {
                DataGridViewRow objPrevRow = grdTimes.Rows[grdTimes.CurrentRow.Index - 1];

                DateTime dtOut = DateTime.Parse(objPrevRow.Cells[3].Value.ToString());

                if (dtIn > dtOut)
                {
                    strReturn = "You entered a start time, that is less than your previous rows end time. Please adjust.";
                    dtStart.Focus();
                }
            }
            
            if (dtNewOut < dtIn && strReturn == "" && dtEnd.Enabled == true)
            {
                strReturn = "Your new end time is less than your start time. Please adjust.";
                dtEnd.Focus();
            }

            return strReturn;
        }

        
        private void chkAddStartTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAddStartTime.Checked == true)
            {
                dtStart.Enabled = true;
                butAdjust.Enabled = false;
                butAdd.Enabled = true;
            }
            else
            {
                dtStart.Enabled = false;
                butAdjust.Enabled = false;
                butAdd.Enabled = false;
            }
        }

        private void chkAddEndTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAddEndTime.Checked == true)
            {
                dtEnd.Enabled = true;
                dtEnd.Text = dtStart.Value.AddHours(8).ToString();

                butAdjust.Enabled = false;
                butAdd.Enabled = true;
            }
            else
            {
                dtEnd.Enabled = false;
            }
        }

        private void SetupDateTime(DateTimePicker objDT, CheckBox objChk, bool blEnabled)
        {
            if (blEnabled == false)
            {
                objChk.Visible = true;
                objChk.Checked = false;
                objDT.Enabled = false;
            }
            else
            {
                objChk.Visible = false;
                objChk.Checked = false;
                objDT.Enabled = true;

                butAdjust.Enabled = true;
                butAdd.Enabled = false;
            }
            
        }

        private void updateCurrentRow()
        {
            if (dtStart.Text != grdTimes.CurrentRow.Cells[1].Value.ToString())
            {
                grdTimes.CurrentRow.Cells[1].Value.ToString();
                grdTimes.CurrentRow.Cells[1].Style.Font = new Font("Arial", 9, FontStyle.Italic);
                grdTimes.CurrentRow.Cells[4].Value = "C"; // Change
                
            }
            if (grdTimes.CurrentRow.Cells[3].Value == null)
            {
                grdTimes.CurrentRow.Cells[3].Value = dtEnd.Text;
                grdTimes.CurrentRow.Cells[5].Value = "A";
            }
            else if (grdTimes.CurrentRow.Cells[4].Value.ToString() != dtEnd.Text)
            {
                grdTimes.CurrentRow.Cells[3].Value = dtEnd.Text;
                grdTimes.CurrentRow.Cells[3].Style.Font = new Font("Arial", 9, FontStyle.Italic);
                grdTimes.CurrentRow.Cells[5].Value = "C";
            }
        }


        private void AddNewRow()
        {
            //grdTimes.Rows.Add();
            //DataGridViewRow objRow = grdTimes.Rows[grdTimes.Rows.Count - 1];

            
            DataRow objRow = dtTimes.Rows.Add();

            if (chkAddStartTime.Checked == true && chkAddStartTime.Visible == true)
            {
                
                objRow[1] = dtStart.Text;
                objRow[4] = "A"; // Add
                
                if (dtEnd.Enabled == true)
                {
                    objRow[3] = dtEnd.Text;
                    objRow[5] = "A";
                }
            }
            
        }

        /****************** End Functions ******************/
    }
}


/*
        
*/