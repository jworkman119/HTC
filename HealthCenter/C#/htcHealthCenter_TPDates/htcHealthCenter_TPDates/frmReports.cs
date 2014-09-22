using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SQLite;

namespace htcHealthCenter_TPDates
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
            LoadForm();
        }

        private void LoadForm()
        {
            LoadRanges();
            

          //  LayoutForm();
        }


        private void LoadRanges()
        {
            cmbRange.Items.Add("Monthly");
            cmbRange.Items.Add("Date Range");
            cmbRange.Items.Add("Greater Than Today");

            cmbRange.SelectedIndex=0;
        }

        private void cmbRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayoutForm();
        }

        private void LayoutForm()
        {


            if (cmbRange.Text == "Greater Than Today")
            {
                pnlRange.Visible = false;
                pnlMonth.Visible = false;

                butRun.Location = new Point(97, 60);

                this.Size= new Size(300,130);

            }
            else if (cmbRange.Text == "Monthly")
            {
                pnlRange.Visible = false;
                pnlMonth.Visible = true;

                butRun.Location = new Point(97, 103);
                this.Size = new Size(300, 175);
            }
            else
            {
                pnlRange.Visible = true;
                pnlMonth.Visible = false;

                pnlRange.Location = new Point(26, 62);
                butRun.Location = new Point(97, 160);
                this.Size = new Size(300, 235);
            }


        }


        private string returnTPDateSQL()
        {
            clsFormat objFormat = new clsFormat();

            string SQL = "Select Patient.Account, Patient.LastName || ', ' || Patient.FirstName as Patient";
            SQL = SQL + " , strftime('%m/%d/%Y',max(TP.Date)) as TP_Date, Resource.FirstName || ' ' || Resource.LastName as Resource, TP.Location";
            SQL = SQL + " From Patient";
            SQL = SQL + " Join TP on TP.Patient_Account = Patient.Account";
            SQL = SQL + " left Join Resource on TP.Resource_ID = Resource.ID";

            if (cmbRange.Text == "Greater Than Today")
                SQL = SQL + " Where TP.Date >= date('now')";
            else if (cmbRange.Text == "Monthly")
            {
                DateTime dtDate = dtMonth.Value;
                SQL = SQL + " Where strftime('%m',TP.Date)='" + objFormat.formatMonth(dtDate.Month) + "'";
                SQL = SQL + " and strftime('%Y',TP.Date)='" + dtDate.Year.ToString() + "'";
            }
            else
            {
                
                SQL = SQL + " Where TP.Date >= " + objFormat.formatDate(dtFrom.Text);
                SQL = SQL + " and TP.Date <= " + objFormat.formatDate(dtTo.Text);
            }

            SQL = SQL + " Group By Patient.Account, Patient.FirstName, Patient.LastName";
            SQL = SQL + ", Resource.FirstName, Resource.LastName Order by Resource.LastName,TP.Date,TP.Location, Patient.LastName";
            return SQL;
        }

        private string returnWaitListSQL()
        {
            clsFormat objFormat = new clsFormat();

            string SQL = "Select Patient_Account as Account, Patient.LastName || ', ' || Patient.FirstName as Patient";
            SQL = SQL + " ,  strftime('%m/%d/%Y',WaitList.StartDate) as StartDate, strftime('%m/%d/%Y',WaitList.EndDate) as EndDate, Resource.FirstName || ' ' || Resource.LastName as Resource";
            SQL = SQL + " From WaitList";
            SQL = SQL + " Join Patient on WaitList.Patient_Account = Patient.Account";
            SQL = SQL + " Join Resource on WaitList.Resource_ID = Resource.ID";

            if (cmbRange.Text == "Greater Than Today")
                SQL = SQL + " Where WaitList.EndDate >= date('now')";
            else if (cmbRange.Text == "Monthly")
            {
                DateTime dtDate = dtMonth.Value;
                SQL = SQL + " Where strftime('%m',WaitList.EndDate)='" + objFormat.formatMonth(dtDate.Month) + "'";
                SQL = SQL + " and strftime('%Y',WaitList.EndDate)='" + dtDate.Year.ToString() + "'";
            }
            else
            {
                SQL = SQL + " Where WaitList.StartDate >= " + objFormat.formatDate(dtFrom.Text);
                SQL = SQL + " and WaitList.EndDate <= " + objFormat.formatDate(dtTo.Text);
            }

            SQL = SQL + " Order by Patient.LastName";
            return SQL;
        }

        private void butRun_Click(object sender, EventArgs e)
        {
            bool blPass = false;

            clsDatabase objDB = new clsDatabase(StaticValues.RemoteDB);
            string SQL = "";
            if (rdTPDates.Checked == true)
                SQL = returnTPDateSQL();
            else
                SQL = returnWaitListSQL();

            SQLiteDataReader objReader = objDB.returnDataReader(SQL);

            if (objReader.HasRows == true)
            {
                clsReports objReport = new clsReports();
                string TimeFrame = returnTimeFrame();
                this.Cursor = Cursors.WaitCursor;

                if (rdTPDates.Checked == true)
                    blPass = objReport.createReport(objReader, TimeFrame, "TPDates");
                else
                    blPass = objReport.createReport(objReader, TimeFrame, "WaitList");

                this.Cursor = Cursors.Default;

                if (blPass == true)
                    this.Close();
                else
                {
                    MessageBox.Show("The report did not run properly if the problem persists please contact IT");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("The report did not return any rows for the requested time frame.");
            }
 
        }

        private string returnTimeFrame()
        {
            string TimeFrame = "";
            if (cmbRange.Text == "Greater Than Today")
                TimeFrame = "All Dates From " + System.DateTime.Now.ToString("MM/dd/yyyy");
            else if (cmbRange.Text == "Monthly")
                TimeFrame = dtMonth.Text + " " + dtMonth.Value.Year.ToString();
            else
                TimeFrame = dtFrom.Value.ToString("MM/dd/yyyy") + " - " + dtTo.Value.ToString("MM/dd/yyyy");

            return TimeFrame;
        }

        private void rdWaitList_Click(object sender, EventArgs e)
        {
            rdTPDates.Checked = false;
        }

        private void rdTPDates_Click(object sender, EventArgs e)
        {
            rdWaitList.Checked = false;
        }

       
    }
}
