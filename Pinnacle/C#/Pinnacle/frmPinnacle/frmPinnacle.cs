using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace frmPinnacle
{
    public partial class frmPinnacle : Form
    {
        private string Staff;
        private string Consumer;
        private string ConsumerID;
        private string Review;
        private string Role;
        private string Month;
        private string Year;

        public frmPinnacle(string strUser, string strRole)
        {
            InitializeComponent();

            this.Text = "Pinnacle - " + strUser;

            Role = strRole;
            // Loading user control based on Role
            switch(strRole)
            {
                case "Adm":
                    LoadForm_Administrator(strUser);
                    break;
                case "Stf":
                    LoadForm_Staff(strUser);
                    break;
            }
        }

        public void LoadForm_Administrator(string strUser)
        {
            ToolTip objTip = new ToolTip();

            objTip.SetToolTip(butAddUser, "Add Consumer");
            objTip.SetToolTip(butAllUsers, "Show All Consumers");
            Staff = strUser;
            LoadConsumerList("");

        }

        public void LoadForm_Staff(string strUser)
        {
            ToolTip objTip = new ToolTip();
            objTip.SetToolTip(butAddReview, "New Review");
            objTip.SetToolTip(butMonthlyReport, "Create Monthly Report");
            objTip.SetToolTip(butDailyReport, "Create Daily Report");

            butAddUser.Enabled = false;
            butAllUsers.Enabled = false;

            LoadStaffList(strUser,"");
        }

        private void butAddUser_Click(object sender, EventArgs e)
        {
            //Loading Add User
            lblStatus.Text = "Adding new consumer";
            AddUser objAddUser = new AddUser();
            objAddUser.CancelControl += new Cancel(CancelControl);
            LoadControl(objAddUser, "ConsumerList");

            // Enabling the right buttons, you don't want to load the control multiple times.
            butAllUsers.Enabled = true;
            butAddUser.Enabled = false;

            // objAddUser.Focus();
            
        }

        private void CancelControlStaff(string strCancel)
        {
            if (Role == "Stf")
            {
                LoadStaffList(Staff, strCancel);
            }
            else
            {
                LoadConsumerList(strCancel);
            }
        }

        private void CancelControl(string strCancel)
        {
            LoadConsumerList(strCancel);
        }

        private void EditConsumer(string strID,string strConsumer)
        {
            AddUser objAddUser = new AddUser();
            objAddUser.CancelControl += new Cancel(CancelControl);
            LoadControl(objAddUser, "ConsumerList");
            objAddUser.LoadControl_Edit(strID);

            // Enabling the right buttons, you don't want to load the control multiple times.
            butAllUsers.Enabled = true;
            butAddUser.Enabled = false;

            lblStatus.Text = "Editing Consumer - " + strConsumer;
        }

        private void AssignJob(string strID, string strConsumer)
        {
            assignJob objAssignJob = new assignJob();
            objAssignJob.CancelControl += new Cancel(CancelControl);
            LoadControl(objAssignJob, "ConsumerList");
            objAssignJob.loadControl_Assign(strConsumer, strID);
        }

        private void EditJob(string strID, string strConsumer)
        {
            assignJob objAssignJob = new assignJob();
            objAssignJob.CancelControl += new Cancel(CancelControl);
            LoadControl(objAssignJob, "ConsumerList");
            objAssignJob.LoadControl_Edit(strConsumer, strID);
        }

        private void butAllUsers_Click(object sender, EventArgs e)
        {
            string CurrentControl = this.Controls[this.Controls.Count -1].Name;
            LoadConsumerList(CurrentControl);
        }

        private void LoadStaffList(string strUser,string strCancel)
        {
            lblStatus.Text = "Showing Consumer List for " + strUser;
            Staff = strUser;
            staffActivityLog objStaff = new staffActivityLog(strUser);
            objStaff.EnableButton += new Enable(EnableButton);
            objStaff.DisableButton += new Disable(DisableButton);
            objStaff.PassConsumerID += new PassConsumer(passConsumer);
            objStaff.EditReviewID += new EditReview(editReview);
            objStaff.PassReviewID += new PassReview(setReviewID);
            objStaff.PassMonthYr += new PassMonthYear(setMonthYear);

            LoadControl(objStaff,strCancel);
            objStaff.LoadControl();
        }

        private void LoadConsumerList(string strRemove)
        {
            //Loading Add User
            lblStatus.Text = "Showing all consumers";
            ConsumerList objConsumers = new ConsumerList();
            objConsumers.EditConsumer += new Edit(EditConsumer);
            objConsumers.AssignJob += new Job(AssignJob);
            objConsumers.EditJob += new Job(EditJob);
            objConsumers.EnableAllConsumers += new AllConsumers(EnableAllUsers);
            objConsumers.PassReviewID += new PassReview(setReviewID);
            objConsumers.EditReviewID += new EditReview(editReview);
            
            LoadControl(objConsumers, strRemove);

            // Enabling the right buttons, you don't want to load the control multiple times.
            butAllUsers.Enabled = false;
            butAddUser.Enabled = true;
            butMonthlyReport.Enabled = false;
            butAddReview.Enabled = false;
            butDailyReport.Enabled = false;
            objConsumers.Focus();
        }

        private void LoadControl(Control objControl, string strCtlRemove)
        {
            //Removing ConsumerList
            for (int j = 0; j < this.Controls.Count; j++)
            {
                string strName = this.Controls[j].Name;
                if (strName == strCtlRemove)
                {
                    this.Controls.RemoveAt(j);
                }
            }

            objControl.Location = new Point(0, 90);
            this.Controls.Add(objControl);
            this.Width = objControl.Width + 20;
            this.Height = objControl.Height + 150;
        }

        private void butAddReview_Click(object sender, EventArgs e)
        {
            addReview();

        }

        private void addReview()
        {
            staffAddReview objReview = new staffAddReview();
            objReview.CancelControl += new CancelStaff(CancelControlStaff);
            objReview.EnableButton += new Enable(EnableButton);

            if (Role == "Stf")
                LoadControl(objReview, "staffActivityLog");
            else
                LoadControl(objReview, "ConsumerList");

            objReview.LoadControl(ConsumerID, Consumer,Staff);
            butAddReview.Enabled = false;
            butMonthlyReport.Enabled = false;
            butDailyReport.Enabled = false;
            
        }

        private void editReview(string ReviewID, string strControl)
        {
            staffAddReview objReview = new staffAddReview();
            objReview.CancelControl += new CancelStaff(CancelControlStaff);
            objReview.EnableButton += new Enable(EnableButton);


            LoadControl(objReview, strControl);
           
            objReview.LoadControl(ReviewID,Staff);
            objReview.EditReview(ReviewID);
            DisableButton("All");
        }

        private void EnableButton(string strButton)
        {
            if (strButton == "butMonthlyReport")
                butMonthlyReport.Enabled = true;
            else if (strButton == "butAddReview")
                butAddReview.Enabled = true;
            else if (strButton == "butDailyReport")
                butDailyReport.Enabled = true;
        }

        private void DisableButton(string strButton)
        {
            if (strButton == "All")
            {
                butDailyReport.Enabled = false;
                butAddReview.Enabled = false;
                butMonthlyReport.Enabled = false;
            }
        }

        private void passConsumer(string strID, string strConsumer)
        {
            ConsumerID = strID;
            Consumer = strConsumer;
        }

        private void setReviewID(string ReviewID)
        {
            Review = ReviewID;
            if (Review != null && Review !="")
                butDailyReport.Enabled = true;
        }

        private void butMonthlyReport_Click(object sender, EventArgs e)
        {
            
            frmReports objReports = new frmReports();

            objReports.Consumer = Consumer;
            objReports.ConsumerID = ConsumerID;
            int intMonth = System.DateTime.Now.Month - 1;
            objReports.Month = intMonth.ToString();
            objReports.LoadForm();
            objReports.ShowDialog();
            
            // clsReports objReports = new clsReports();
            //objReports.CreateMonthlyActivityLog(ConsumerID, Month, Year);
        }

        private void butDailyReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (Review != null)
            {
                clsReports objReports = new clsReports();
                objReports.CreateActivityLog(Review);
            }
            else
                MessageBox.Show("You have not selected a review.");

            this.Cursor = Cursors.Default;
        }

        private void EnableAllUsers(string strID, string strConsumer)
        {
            butAllUsers.Enabled = true;
            butAddUser.Enabled = false;
            butMonthlyReport.Enabled = true;
            butAddReview.Enabled = true;
            lblStatus.Text = "Consumer - " + strConsumer;
            Consumer = strConsumer;
            ConsumerID = strID;
        }

        private void setMonthYear(DateTime Date)
        {
            Month = Date.Month.ToString();
            Year = Date.Year.ToString();
        }
    }
}
