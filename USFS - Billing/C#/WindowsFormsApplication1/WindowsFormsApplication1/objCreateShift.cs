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
    public partial class objCreateShift : UserControl
    {
        private DataTable  objTable;
        
        public objCreateShift()
        {
            InitializeComponent();
            LoadControl();
        }

        private void LoadControl()
        {
            objDatabase Database = new objDatabase();
            string strSQL;


            cmbShift.Items.Clear();
            strSQL = "Select Name, TimeIn, TimeOut";
            strSQL = strSQL + " From Shift";

            objTable = Database.ReturnDataTable(strSQL);

            // Loading Shifts into combobox
            
            foreach (DataRow objRow in objTable.Rows)
            {
                cmbShift.Items.Add(objRow[0].ToString());

            }

            cmbShift.SelectedIndex = -1;
            cmbShift.Text = "<New Shift>";
            dtStartTime.Text = "12:00 AM";
            dtEndTime.Text = "12:00 AM";
            cmbShift.Focus();
        }

        private void cmbShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cycle through datareader to load times in combobox

            foreach (DataRow objRow in objTable.Rows)
            {
                if (objRow[0].ToString() == cmbShift.Text)
                {
                    dtStartTime.Text = objRow[1].ToString();
                    dtEndTime.Text = objRow[2].ToString();
                }
            }
        }

        private void butEnter_Click(object sender, EventArgs e)
        {
            if (VerifyData() == true)
            {
                objDatabase Database = new objDatabase();
                string strSQL = "spAddShift '" + cmbShift.Text + "', '" + dtStartTime.Text + "', '" + dtEndTime.Text + "'";

                Cursor.Current = Cursors.WaitCursor;
                int intRows = Database.AddData(strSQL);
                LoadControl();
                Cursor.Current = Cursors.Default;

                if (intRows > 0)
                {
                    MessageBox.Show("The shift has been successfully updated.");
                }
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            objDatabase Database = new objDatabase();
            string strSQL = "Delete From Shift Where Shift.Name = '" + cmbShift.Text + "'";
            Cursor.Current = Cursors.WaitCursor;
            int intRows = Database.AddData(strSQL);
            LoadControl();
            Cursor.Current = Cursors.Default;

            if (intRows > 0)
            {
                MessageBox.Show("The shift has been deleted.");
            }
        }

        private bool VerifyData()
        {
            bool blVerify = false;
            DateTime dtmStartTime = DateTime.Parse(dtStartTime.Text);
            DateTime dtmEndTime = DateTime.Parse(dtEndTime.Text);
            TimeSpan dtmTime;
            double dblTimeSpan;

            if (dtmStartTime.ToString().IndexOf("AM") >= 0)
            {
                dtmTime = dtmEndTime - dtmStartTime;
                dblTimeSpan = dtmTime.TotalHours;
            }
            else
            {
                dtmTime = (dtmStartTime - dtmEndTime);
                dblTimeSpan = 24 - dtmTime.TotalHours;
            }
            

            if (cmbShift.Text == "<New Shift>")
            {
                MessageBox.Show("You do not have a unique name for your shift, please enter one.");
                cmbShift.Focus();
            }

            else if(dblTimeSpan == 0)
            {
                MessageBox.Show("Your timespan = 0, please enter a proper timespan.");
                dtStartTime.Focus();
            }
           else
            {
                blVerify = true;
            }
            return blVerify;
        }
    
    
    }
}
