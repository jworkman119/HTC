using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Globalization;

namespace frmPinnacle
{
    public delegate void CancelStaff(string strCancel);

    public partial class staffAddReview : UserControl
    {
        string strDB = resPinnacle.liveDB;
        string ID, Staff,StaffID, JobID, Employer, Job, ReviewID, MeetingID;
        public event CancelStaff CancelControl;
        public event Enable EnableButton;

        public staffAddReview()
        {
            InitializeComponent();
            
        }

        public void LoadControl(string strID, string strConsumer, string strStaffID)
        {
            fillComboBox();
            txtConsumer.Text = strConsumer;
            ID = strID;
            Staff = strStaffID;
            

            clsFormat objFormat = new clsFormat();
            string Day = objFormat.formatDate(dtDate.Text);
            getCurrentJob(strID,Day);
            LoadTimes();
            txtOutcome.Focus();
        }

        public void LoadControl(string strReviewID, string strStaff)
        {
            fillComboBox();

            clsDB objDB = new clsDB(strDB);
            string SQL = "Select Consumer.ID as Consumer_ID, Consumer.FirstName || ' ' || Consumer.LastName as Consumer,Staff_ID,  strftime('%m/%d/%Y',Date)";
            SQL = SQL + " From Review Join Consumer on Review.Consumer_ID = Consumer.ID";
            SQL = SQL + " Where Review.ID = " + strReviewID;

            SQLiteDataReader objReader = objDB.returnDataReader(SQL);

            txtConsumer.Text = objReader["Consumer"].ToString();
            ID = strReviewID;
            StaffID = objReader["Staff_ID"].ToString();

            clsFormat objFormat = new clsFormat();
            string Day = objFormat.formatDate(dtDate.Text);
            getCurrentJob(ID, Day);
            LoadTimes();
            txtOutcome.Focus();
        }

        private void LoadTimes()
        {
            var TimeInHour = TimeSpan.FromHours(Math.Floor(DateTime.Now.TimeOfDay.TotalHours));
            dtTimeIn.Text = TimeInHour.ToString();
            dtTimeOut.Text = updateTime("out", dtTimeIn.Text);
        }

        public void EditReview(string strReviewID)
        {
            clsDB objDB = new clsDB(strDB);
            ReviewID = strReviewID;

            string SQL = "Select Review.ID as ReviewID,Consumer.ID as ConsumerID, strftime('%m/%d/%Y',Date) as Date, DesiredOutcome, Barriers, Note, Meeting.Description as Meeting, Meeting.ID as MeetingID";
            SQL = SQL + " , Job_ID, Job.Title as Job, Job.Description as JobDescription, Job.Employer, Job.Address, Job.City, Job.Zip, strftime('%m/%d/%Y',Job.PlacementDate) as PlacementDate, Staff_ID";
            SQL = SQL + " , Review.TimeIn, Review.TimeOut, Consumer.FirstName || ' ' || Consumer.LastName as Consumer";
            SQL = SQL + " From Review";
            SQL = SQL + " Join Meeting on Review.Meeting_ID = Meeting.ID";
            SQL = SQL + " Left Join Job on Review.Job_ID = Job.ID";
            SQL = SQL + " Join Consumer on Review.Consumer_ID=Consumer.ID";
            SQL = SQL + " WHERE Review.Id =" + strReviewID;

            SQLiteDataReader objReader = objDB.returnDataReader(SQL);

            clsFormat objFormat = new clsFormat();
            while (objReader.Read())
            {
                ReviewID = objReader["ReviewID"].ToString();
                StaffID = objReader["Staff_ID"].ToString();
                JobID = objReader["Job_ID"].ToString();
                MeetingID = objReader["MeetingID"].ToString();
                ID = objReader["ConsumerID"].ToString();
                dtDate.Text = objReader["Date"].ToString();
                txtOutcome.Text = objReader["DesiredOutcome"].ToString();
                txtBarriers.Text = objReader["Barriers"].ToString();
                txtDetails.Text = objReader["Note"].ToString();
                cmbMeeting.Text = objReader["Meeting"].ToString();
                txtJob.Text = objReader["Job"].ToString();
                txtDescription.Text = objReader["JobDescription"].ToString();
                txtEmployer.Text = objReader["Employer"].ToString();
                txtAddress.Text = objReader["Address"].ToString();
                txtCity.Text = objReader["City"].ToString();
                txtZip.Text = objReader["Zip"].ToString();
                txtPlacement.Text = objReader["PlacementDate"].ToString();

                DateTime dtTime = objReader.GetDateTime(objReader.GetOrdinal("TimeIn"));
                dtTimeIn.Text = objFormat.convertTime_12hr(dtTime) ;

                dtTime = objReader.GetDateTime(objReader.GetOrdinal("TimeOut"));
                dtTimeOut.Text = objFormat.convertTime_12hr(dtTime);

                txtConsumer.Text = objReader["Consumer"].ToString();

                butEnter.Text = "Update";
            }
            
        }

        private void fillComboBox()
        {
            clsDB objDB = new clsDB(strDB);

            string SQL = "Select Description From Meeting";

            SQLiteDataReader objReader =  objDB.returnDataReader(SQL);

            int j=0;
            while (objReader.Read())
            {
                cmbMeeting.Items.Add(objReader["Description"].ToString());
                
            }

            cmbMeeting.SelectedIndex = 0;
        }

        private void getCurrentJob(string ID,string Day)
        {
            string SQL = "SELECT Job.ID, Title, Description,Employer,Address,City,Zip,strftime('%m/%d/%Y',PlacementDate) as PlacementDate";
            SQL = SQL + " FROM Job";
            SQL = SQL + " Where Consumer_ID =" + ID;
            SQL = SQL + " and (Job.PlacementDate <=" + Day ;
            SQL = SQL + " or Job.PlacementDate is null)";
            SQL = SQL + " and (Job.EndDate>=" + Day;
            SQL = SQL + " or Job.EndDate is null)";

            clsDB objDB = new clsDB(strDB);
            SQLiteDataReader objReader = objDB.returnDataReader(SQL);

            if (objReader.HasRows == true)
            {
                chkEmployed.Checked = true;
                while (objReader.Read())
                {
                    JobID = objReader["ID"].ToString();
                    Employer = objReader["Employer"].ToString();
                    Job = objReader["Title"].ToString();
                    
                    txtJob.Text = objReader["Title"].ToString();
                    txtDescription.Text = objReader["Description"].ToString();
                    txtEmployer.Text = objReader["Employer"].ToString();
                    txtAddress.Text = objReader["Address"].ToString();
                    txtCity.Text = objReader["City"].ToString();
                    txtZip.Text = objReader["Zip"].ToString();
                    txtPlacement.Text = objReader["PlacementDate"].ToString();
                }
            }
            else
            {
                chkEmployed.Checked = false;
            }
        }

        private void chkEmployed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEmployed.Checked == true)
            {
                grpJob.Enabled = true;
            }
            else
            {
                grpJob.Enabled = false;
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            CancelControl("staffAddReview");
        }

        private void butEnter_Click(object sender, EventArgs e)
        {
            if (butEnter.Text == "Enter")
            {
                addMeeting();
            }
            else
            {
                updateMeeting();
            }

            CancelControl("staffAddReview");
        }

        private void addMeeting()
        {
            //checkNewJob();
            
            string strSQL = addMeetingSQL();
            clsDB objDB = new clsDB(strDB);
            bool blPass = objDB.executeNonQuery(strSQL);

            if (blPass == false)
                MessageBox.Show("Your review was not entered into the database, please consult IT if problem persists.");
              
        }

        private string addMeetingSQL()
        {
            clsFormat objFormat = new clsFormat();

            if (JobID == "" || JobID ==null)
                JobID = "null";
 /* Todo - update this SQL statement to fit in with new logic within system */          
            string strSQL = "Insert into Review(Date,DesiredOutcome,Barriers,Note,Job_ID, Staff_ID, Meeting_ID, Funding_ID, Consumer_ID, TimeIn, TimeOut)";
            strSQL = strSQL + " Select " + objFormat.formatDate(dtDate.Text) + ",'" + objFormat.removeApostrophe(txtOutcome.Text) + "','" + objFormat.removeApostrophe(txtBarriers.Text) + "',";
            strSQL = strSQL + " '" + objFormat.removeApostrophe(txtDetails.Text) + "'," + JobID + ", Staff.ID, Meeting.ID, Consumer.Funding_ID," + ID;
            strSQL = strSQL + ", '" + objFormat.convertTime_24hr(dtTimeIn.Value) + "', '" + objFormat.convertTime_24hr(dtTimeOut.Value) + "'";
            strSQL = strSQL + " FROM Staff, Consumer, Meeting ";
//            strSQL = strSQL + " Join ConsumerStaff  on Staff.ID = ConsumerStaff.Staff_ID";
//            strSQL = strSQL + " Join Consumer on ConsumerStaff.Consumer_ID = Consumer.ID";
//            strSQL = strSQL + " , Meeting";
            strSQL = strSQL + " WHERE Staff.FirstName || ' ' || Staff.LastName = '" + Staff + "'";
            strSQL = strSQL + " AND Meeting.Description = '" + cmbMeeting.Text + "'";
            strSQL = strSQL + " AND Consumer.ID = " + ID;
            

            return strSQL;
        }

        private void checkNewJob()
        {
            if ((txtEmployer.Text != Employer || txtJob.Text !=Job) && txtJob.Text != "")
            {
                clsDB objDB = new clsDB(strDB);
                clsFormat objFormat = new clsFormat();

                string strInsert = "Insert Into Job(Title, Description, Employer, Address,City, Zip,PlacementDate,Consumer_ID)";
                string strValues = " Values('" + txtJob.Text + "','" + objFormat.removeApostrophe(txtDescription.Text) + "','" + objFormat.removeApostrophe(txtEmployer.Text) + "','" + txtAddress.Text + "'"; 
                strValues = strValues + ",'" +  txtCity.Text  + "','" + objFormat.formatZip(txtZip.Text) + "'," + objFormat.formatDate(txtPlacement.Text) + "," + ID + ")";

                objDB.assignJob(strInsert + strValues);

                // logic to email Kristen.
                clsEmail objEmail = new clsEmail();
                objEmail.MailInfo("Pinnacle@htcorp.net", txtConsumer.Text);
            }

        }

        private void updateMeeting()
        {
            clsDB objDB = new clsDB(strDB);
            string SQL = updateMeetingSQL();

            bool blPass = objDB.executeNonQuery(SQL);

            if (blPass == true)
            {
                MessageBox.Show(txtConsumer.Text + "'s review was successfully updated.");
            }
            else
            {
                MessageBox.Show(txtConsumer.Text + "'s review was NOT updated. Please try again if problem persists contact IT.");
            }
        }

        private string updateMeetingSQL()
        {
            clsFormat objFormat = new clsFormat();

            if (JobID == "" || JobID == null)
                JobID = "null";

            string SQL = "Update Review";
            SQL = SQL + " Set Date = " + objFormat.formatDate(dtDate.Text) + ", DesiredOutcome = '" + objFormat.removeApostrophe(txtOutcome.Text) + "'";
            SQL = SQL + ", Barriers ='" + objFormat.removeApostrophe(txtBarriers.Text) + "'";
            SQL = SQL + ", Note ='" + objFormat.removeApostrophe(txtDetails.Text) + "'";
            SQL = SQL + ",Job_ID = " + JobID + ", Staff_ID = " + StaffID +  ", Meeting_ID ='" + MeetingID + "'";
            SQL = SQL + ",TimeIn= '" + objFormat.convertTime_24hr(dtTimeIn.Value) + "', TimeOut = '" + objFormat.convertTime_24hr(dtTimeOut.Value) + "'";
            SQL = SQL + " Where Review.ID = " + ReviewID;
            return SQL;

        }

        private void dtTimeIn_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan OutTime = Convert.ToDateTime(dtTimeOut.Text).TimeOfDay;
            TimeSpan InTime = Convert.ToDateTime(dtTimeIn.Text).TimeOfDay;
            if (OutTime < InTime)
                dtTimeOut.Text = updateTime("out", dtTimeIn.Text);
        }

        private void dtTimeOut_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan OutTime = Convert.ToDateTime(dtTimeOut.Text).TimeOfDay;
            TimeSpan InTime = Convert.ToDateTime(dtTimeIn.Text).TimeOfDay;
            if(OutTime < InTime)
                dtTimeIn.Text = updateTime("in", dtTimeOut.Text);
        }

        // will take time and add 1/2 hour to out time, or remove 1/2 hour from output time
        private string updateTime(string Update, string strTime)
        {
            TimeSpan NewTime;
            if (Update == "out")
            {
                NewTime = Convert.ToDateTime(strTime).AddMinutes(60).TimeOfDay;
            }
            else
            {
                NewTime = Convert.ToDateTime(strTime).AddMinutes(-60).TimeOfDay;
            }

            string strOutput = NewTime.ToString("hh\\:mm");
            strOutput = DateTime.ParseExact(strOutput, "HH:mm", null).ToString("hh:mm tt", CultureInfo.GetCultureInfo("en-US"));

            return strOutput;
        }

        private void cmbMeeting_SelectedValueChanged(object sender, EventArgs e)
        {
            updateMeetingID(cmbMeeting.SelectedItem.ToString());
        }

        private void updateMeetingID(string strValue)
        {
            clsDB objDB = new clsDB(resPinnacle.liveDB);

            string SQL = "Select ID FROM Meeting Where Description = '" + strValue + "'";

            SQLiteDataReader objReader = objDB.returnDataReader(SQL);
            while (objReader.Read())
            {
                MeetingID = objReader["ID"].ToString();
            }
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            clsFormat objFormat = new clsFormat();
            string Day = objFormat.formatDate(dtDate.Text);
            getCurrentJob(ID,Day);
        }

        private void butEmpEnter_Click(object sender, EventArgs e)
        {
            checkNewJob();
        }
    }
}
