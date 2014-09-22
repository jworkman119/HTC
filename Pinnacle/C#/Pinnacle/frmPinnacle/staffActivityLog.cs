using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace frmPinnacle
{
    //public delegate void Enable(bool blEnable);
    public delegate void Enable(string strButton);
    public delegate void Disable(string strButton);
    public delegate void PassConsumer(string ID, string Consumer);
    public delegate void EditReview(string ReviewID, string ControlName);
    public delegate void PassReview(string ReviewID);
    public delegate void PassMonthYear(DateTime dtDate);

    public partial class staffActivityLog : UserControl
    {
            string strDB = resPinnacle.liveDB;
            string StaffID;
            string ConsumerID; 
            bool firstLoad = true;
            bool blAllConsumers = true;
            string AdminID;

            public event Enable EnableButton;
            public event Disable DisableButton;
            public event PassConsumer PassConsumerID;
            public event EditReview EditReviewID;
            public event PassReview PassReviewID;
            public event PassMonthYear  PassMonthYr;

        public staffActivityLog(string strUser)
        {
            InitializeComponent();
            StaffID = strUser;
        }

        public void LoadControl()
        {
            firstLoad = false;
            setupTabAllActivity();
            loadConsumerList();
        }

        private void tabctlStaff_Selected(object sender, TabControlEventArgs e)
        {

            switch (tabctlStaff.SelectedIndex)
            {
                case 0:
                    setupTabAllActivity();
                    break;
                case 1:
                    setupTabConsumer();
                    break;
                case 2:
                    setupTabAdministrative();
                    break;
            }
        }

 #region Tab_Consumer
        private void setupTabConsumer()
        {
            txtConsumer.Select();
        }

        private void loadConsumerList()
        {
            clsDB objDB = new clsDB(strDB);
            string SQL = allConsumers_SQL(StaffID);

            SQLiteDataReader objReader = objDB.returnDataReader(SQL);

            while (objReader.Read())
            {
                txtConsumer.AutoCompleteCustomSource.Add(objReader["Consumer"].ToString());
            }
        }


        private string allConsumers_SQL(string strStaff)
        {
            string SQL = "SELECT Consumer.ID, Consumer.FirstName || ' ' || Consumer.LastName as Consumer";
            SQL = SQL + " , Job.Title as Job , Job.Employer, strftime('%m/%d/%Y', MAX(Review.Date)) as [Last Review], Meeting.Description as [Meeting Type]";
            SQL = SQL + " FROM Consumer";
            SQL = SQL + " LEFT JOIN Review on Consumer.ID = Review.Consumer_ID";
            SQL = SQL + " LEFT JOIN Job on Consumer.ID = Job.Consumer_ID";
            SQL = SQL + " AND Job.EndDate is null";
            SQL = SQL + " LEFT JOIN Meeting on Review.Meeting_ID = Meeting.ID";
            SQL = SQL + " LEFT JOIN Service on Consumer.Service_ID = Service.ID";
            SQL = SQL + " LEFT JOIN Disability on Consumer.Disability_ID = Disability.ID";
            SQL = SQL + " LEFT JOIN Funding on Consumer.Funding_ID = Funding.ID";
            SQL = SQL + " WHERE Consumer.Active = 'true'";
            SQL = SQL + " GROUP BY Consumer, Job.Title, Job.Employer";

            return SQL;
        }

        private void loadSelectedConsumer()
        {
            string strSQL = selectedConsumer_SQL();
            clsDB objDB = new clsDB(strDB);
            clsGridUtils objGrid = new clsGridUtils();

            SQLiteDataReader objReader = objDB.returnDataReader(strSQL);
            if (objReader.HasRows == true)
            {
                ConsumerID = objReader[0].ToString();
                objGrid.fillGrid(objReader, 2, ref grdActivity, this.CreateGraphics());
            }
            else
            {
                MessageBox.Show("The user has no meetings currently in the system");
               
            }

            blAllConsumers = false;
        }

        private string selectedConsumer_SQL()
        {
            string SQL = "SELECT Distinct Consumer.ID as ConsumerID, Review.ID as ReviewID" ;
            SQL = SQL + " , Job.Title as Job , Job.Employer, strftime('%m/%d/%Y', Review.Date) as [Reviewed], Meeting.Description as [Meeting Type]";
            SQL = SQL + " FROM Consumer";
            SQL = SQL + " JOIN Review on Consumer.ID = Review.Consumer_ID";
            SQL = SQL + " JOIN Staff on Review.Staff_ID = Staff.ID";
            SQL = SQL + " LEFT JOIN Job on Review.Job_ID = Job.ID ";
            SQL = SQL + " LEFT JOIN Meeting on Review.Meeting_ID = Meeting.ID";
            SQL = SQL + " WHERE Consumer.FirstName || ' ' || Consumer.LastName = '" + txtConsumer.Text + "'";
            SQL = SQL + " and (Job.PlacementDate<= Review.Date or Job.PlacementDate is NULL) ";
            SQL = SQL + " and (Job.EndDate>=Review.Date or EndDate is NULL)";
            SQL = SQL + " AND Consumer.Active = 'true'";
            SQL = SQL + " ORDER BY Review.Date desc";

            return SQL;
        }

        private void grdActivity_SelectionChanged(object sender, EventArgs e)
        {

            
            try
            {
                if (grdActivity.SelectedRows.Count > 0)
                {
                    if (blAllConsumers == true && firstLoad == false)
                    {
                        string strID = grdActivity[0, grdActivity.CurrentRow.Index].Value.ToString();
                        string strConsumer = grdActivity[1, grdActivity.CurrentRow.Index].Value.ToString();
                        loadConsumerDetail(strConsumer,strID);
                        PassReviewID(null);
                    }
                    else if (blAllConsumers == false && firstLoad == false)
                    {
                        // Pass Review ID to main frame.
                        string strReviewID = grdActivity[1, grdActivity.CurrentRow.Index].Value.ToString();
                        PassReviewID(strReviewID);
                    }
                }
               
            }
            catch
            {
                grpDetails.Visible = false;

            }
        }

        private void loadConsumerDetail(string strConsumer, string ID)
        {
            clsDB objDB = new clsDB(strDB);
            string SQL = consumerDetail_SQL(strConsumer, ID);
            SQLiteDataReader objReader = objDB.returnDataReader(SQL);

            //PassConsumerID(strConsumer);

            while (objReader.Read())
            {
                txtFunding.Text = objReader["Funding"].ToString();
                txtDisability.Text = objReader["Disability"].ToString();

                grpDetails.Visible = true;
                EnableButton("butMonthlyReport");
            }
        }

        private string consumerDetail_SQL(string strConsumer, string ID)
        {
            string SQL = "SELECT Service.Description as Service, Consumer.Funding_ID as Funding";
            SQL = SQL + ", Disability.Description as Disability, Consumer.AVR, Consumer.Units";
            SQL = SQL + " FROM Consumer";
            SQL = SQL + " LEFT JOIN Service on Consumer.Service_ID = Service.ID";
            SQL = SQL + " LEFT JOIN Disability on Consumer.Disability_ID = Disability.ID";
            SQL = SQL + " LEFT JOIN Funding on Consumer.Funding_ID = Funding.ID";
            SQL = SQL + " WHERE Consumer.FirstName || ' ' || Consumer.LastName = '" + strConsumer + "'";
            SQL = SQL + " and Consumer.ID = " + ID.ToString();

            return SQL;
        }

        private void grpDetails_VisibleChanged(object sender, EventArgs e)
        {
            if (grpDetails.Visible == true)
                EnableButton("butAddReview");
            else
                DisableButton("All");
        }

        private void mnuEdit_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string ReviewID = grdActivity[1,grdActivity.CurrentRow.Index].Value.ToString();
            switch (e.ClickedItem.Text)
            {
                case "Edit":
                    EditReview();
                    break;
                case "Delete":
                    DeleteReview();
                    break;
                case "Create Daily Report":
                    this.Cursor = Cursors.WaitCursor;
                        clsReports objReport = new clsReports();
                        objReport.CreateActivityLog(ReviewID);
                    this.Cursor = Cursors.Default;
                    break;
            }
        }

        private void EditReview()
        {
            if (EditReviewID != null)
                EditReviewID(grdActivity[1,grdActivity.CurrentRow.Index].Value.ToString(),"staffActivityLog");
        }

        private void DeleteReview()
        {
            DialogResult objResult;
            objResult = MessageBox.Show("Are you sure you want to delete this review","Delete Review",MessageBoxButtons.YesNo);
            if (objResult == DialogResult.Yes)
            {
                string SQL = "DELETE from Review where ID=" + grdActivity[1, grdActivity.CurrentRow.Index].Value.ToString();
                clsDB objDB = new clsDB(resPinnacle.liveDB);
                bool blDelete = objDB.executeNonQuery(SQL);
                if (blDelete == false)
                    MessageBox.Show("The review was not deleted. Please try again. If problem persists, please contact IT.");
                else
                    loadSelectedConsumer();
            }
        }

        private void grdActivity_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
                string strConsumer = grdActivity[1, grdActivity.CurrentRow.Index].Value.ToString();
                loadSelectedConsumer();
        }


        private void butSearch_Click(object sender, EventArgs e)
        {

            string strConsumer = txtConsumer.Text;
            PassReviewID(null);
            loadSelectedConsumer();
            ConsumerID = returnConsumerID(strConsumer);
            loadConsumerDetail(strConsumer,ConsumerID);
        }

        private void txtConsumer_Click(object sender, EventArgs e)
        {
            txtConsumer.SelectionStart = 0;
            txtConsumer.SelectionLength = txtConsumer.TextLength;
        }

        private string returnConsumerID(string strConsumer)
        {
            clsDB objDB = new clsDB(strDB);
            string SQL = returnConsumerID_SQL(strConsumer);
            SQLiteDataReader objReader = objDB.returnDataReader(SQL);
            
            string ID="";
            int iCount = 0;
            while (objReader.Read())
            {
                if (iCount < 1)
                {
                    ID = objReader["ID"].ToString();
                    PassConsumerID(ID,strConsumer);
                }
                iCount++;
            }

            return ID;
        }

        private string returnConsumerID_SQL(string strConsumer)
        {
            string SQL = "Select Consumer.ID, FirstName || ' ' || LastName as Name";
	        SQL = SQL + ", SSN, Funding_ID, Disability.Description as Disability";
            SQL = SQL + " From Consumer";
	        SQL = SQL + " Left Join Disability on Consumer.Disability_ID = Disability.ID";
            SQL = SQL + " Where FirstName || ' ' || LastName = '" + strConsumer + "'";
            SQL = SQL + " And Consumer.Active = 'true'";

            return SQL;
        }

#endregion Tab_Consumer


#region Tab_Administrative

        private void setupTabAdministrative()
        {
            Clear_Administrative();
            fillGridAdmin();
            DisableButton("All");
        }

        private void fillGridAdmin()
        {
            string SQL = AdminSQL();
            clsDB objDB = new clsDB(resPinnacle.liveDB);
            SQLiteDataReader objReader = objDB.returnDataReader(SQL);
            clsGridUtils objGrid = new clsGridUtils();

            objGrid.fillGrid(objReader, 0, ref grdAdministrative, this.CreateGraphics());
        }

        private string AdminSQL()
        {
            string SQL;

            SQL = "Select Administrative.ID, strftime('%m/%d/%Y',Date) as Date";
            SQL = SQL + " ,Description, StartTime,EndTime";
            SQL = SQL + " From Administrative";
            SQL = SQL + " Join Staff on Administrative.Staff_ID = Staff.ID";
            SQL = SQL + " Where Staff.FirstName || ' ' || Staff.LastName = '" + StaffID + "'";
            SQL = SQL + " Order by Date desc";

            return SQL;
        }

        private void Clear_Administrative()
        {
            txtDescription.Clear();
            panelAdministrative.Visible = false;
            butAddAdmin.Visible = true;
        }

        private void butAddAdmin_Click(object sender, EventArgs e)
        {
            Clear_Administrative();
            butEnterAdmin.Text = "Enter";
            dtTimeIn.Text = setDefaultTime("In");
            dtTimeOut.Text = setDefaultTime("Out");
            panelAdministrative.Visible = true;
            butAddAdmin.Visible = false;
            txtDescription.Focus();
        }

        private string setDefaultTime(string Status)
        {
            TimeSpan Time = Convert.ToDateTime(System.DateTime.Now).TimeOfDay;
            TimeSpan Hour;
            if (Status == "In")
                Hour = TimeSpan.FromHours(Math.Floor(Time.TotalHours));
            else
                Hour = TimeSpan.FromHours(Math.Ceiling (Time.TotalHours));

            string strTime = Hour.ToString("hh\\:mm");
            return strTime;
        }

        private void butCancelAdmin_Click(object sender, EventArgs e)
        {
            Clear_Administrative();
            butAddAdmin.Visible = true;
            panelAdministrative.Visible = false;
        }

        private void dtTimeIn_ValueChanged(object sender, EventArgs e)
        {
            if (dtTimeIn.Text.Trim().Length > 0)
            {
                TimeSpan OutTime = Convert.ToDateTime(dtTimeOut.Text).TimeOfDay;
                TimeSpan InTime = Convert.ToDateTime(dtTimeIn.Text).TimeOfDay;
                if (OutTime <= InTime)
                    dtTimeOut.Text = updateTime("out", dtTimeIn.Text);
            }
        }

        private void dtTimeOut_ValueChanged(object sender, EventArgs e)
        {
            if (dtTimeOut.Text.Trim().Length > 0)
            {
                TimeSpan OutTime = Convert.ToDateTime(dtTimeOut.Text).TimeOfDay;
                TimeSpan InTime = Convert.ToDateTime(dtTimeIn.Text).TimeOfDay;
                if (OutTime <= InTime)
                    dtTimeIn.Text = updateTime("in", dtTimeOut.Text);
            }
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

            clsFormat objFormat = new clsFormat();
            string strOutput = objFormat.convertTime_12hr(NewTime);
            
            return strOutput;
        }

        private void butEnterAdmin_Click(object sender, EventArgs e)
        {
            updateAdministrative(butEnterAdmin.Text);
            
        }

        private void updateAdministrative(string Type)
        {
            clsDB objDB = new clsDB(resPinnacle.liveDB);

            string SQL="";
            if (Type == "Enter")
                SQL = addAdmin_SQL();
            else if (Type == "Update")
                SQL = updateAdmin_SQL();
            else if (Type == "Delete")
                SQL = deleteAdmin_SQL();

            bool blPass = objDB.executeNonQuery(SQL);

            if (blPass == true)
            {
                fillGridAdmin();
                Clear_Administrative();
            }
            else
                MessageBox.Show("Your administrative task was not updated, if problem persists please contact IT.");
        }

        private string addAdmin_SQL()
        {
            clsFormat objFormat = new clsFormat();

            string SQL = "Insert Into Administrative(Date,Description,StartTime,EndTime, staff_ID)";
            SQL = SQL + " Select " + objFormat.formatDate(dtDateAdmin.Text) ;
            SQL = SQL + " ,'" + objFormat.removeApostrophe(txtDescription.Text) + "'";
            SQL = SQL + " ,'" + objFormat.convertTime_24hr(dtTimeIn.Value) + "'";
            SQL = SQL + " ,'" + objFormat.convertTime_24hr(dtTimeOut.Value) + "'";
            SQL = SQL + " , Staff.ID";
            SQL = SQL + " From Staff";
            SQL = SQL + " Where FirstName || ' ' || LastName = '" + StaffID + "'";

            return SQL;
        }

        private string updateAdmin_SQL()
        {
            clsFormat objFormat = new clsFormat();
            string SQL = "Update Administrative";
            SQL = SQL + " Set Date = " + objFormat.formatDate(dtDateAdmin.Text);
            SQL = SQL + " , Description = '" + objFormat.removeApostrophe(txtDescription.Text) + "'";
            SQL = SQL + " , StartTime = '" + objFormat.convertTime_24hr(dtTimeIn.Value) + "'";
            SQL = SQL + " , EndTime = '" + objFormat.convertTime_24hr(dtTimeOut.Value) + "'";
            SQL = SQL + " Where Administrative.ID = " + AdminID;

            return SQL;
        }

        private void grdAdministrative_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fillAdmin_Edit();
        }

        private void fillAdmin_Edit()
        {
            butAddAdmin.Visible = false;
            butEnterAdmin.Text = "Update";
            panelAdministrative.Visible = true;
            AdminID = grdAdministrative.CurrentRow.Cells[0].Value.ToString();
            dtDateAdmin.Text = grdAdministrative.CurrentRow.Cells[1].Value.ToString();
            txtDescription.Text = grdAdministrative.CurrentRow.Cells[2].Value.ToString();
            dtTimeIn.Text = grdAdministrative.CurrentRow.Cells[3].Value.ToString();
            dtTimeOut.Text = grdAdministrative.CurrentRow.Cells[4].Value.ToString();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            DialogResult objResult = MessageBox.Show("Are you sure you want to delete the selected administrative task?", "Delete Administrative Task", MessageBoxButtons.YesNo);
            if (objResult == DialogResult.Yes)
                updateAdministrative("Delete");
            else
                Clear_Administrative();
        }

        private string deleteAdmin_SQL()
        {
            string SQL = "Delete from Administrative";
            SQL = SQL + " Where ID = " + grdAdministrative.CurrentRow.Cells[0].Value.ToString();

            return SQL;
        }
       
#endregion Tab_Administrative

#region Tab_AllActivity

    private void setupTabAllActivity()
        {
            DateTime dtToday = System.DateTime.Now;
            fillGrid_AllActivity();
        }

    private void fillGrid_AllActivity()
    {
        string SQL = returnAllActivity_SQL();

        clsDB objDB = new clsDB(strDB);
        SQLiteDataReader objReader = objDB.returnDataReader(SQL);

        clsGridUtils objGrid = new clsGridUtils();

        bool Loaded = false;
        if (objReader.HasRows == true)
        {
            objGrid.fillGrid(objReader, 1, ref grdAllActivity, this.CreateGraphics());
            returnHours();
        }
        else
        {
            grdAllActivity.Rows.Clear();
            lblHours.Text = "Hours: 0";
        }
    }

    private string returnAllActivity_SQL()
    {
        string SQL = "Select ID, Date, Consumer, Meeting";
		SQL = SQL + ", Case"; 
		SQL = SQL + " When (strftime('%H',Start) - 12) = -12 Then";
		SQL = SQL + " '12:' || strftime('%M', Start) ||' '|| 'am'";
		SQL = SQL + " When (strftime('%H',Start) - 12) = 0 Then ";
		SQL = SQL + " '12:' || strftime('%M', Start) ||' '|| 'pm'";
		SQL = SQL + " When (strftime('%H', Start) - 12) < 0 Then";
		SQL = SQL + " cast(strftime('%H', Start) as integer) ||':'|| strftime('%M', Start) ||' '|| 'pm'";
		SQL = SQL + " ELSE (cast(strftime('%H', Start) as integer) - 12) ||':'|| strftime('%M', Start) ||' '|| 'pm' End as Start";
		SQL = SQL + " , Case When (strftime('%H',End) - 12) = -12 Then";
		SQL = SQL + " '12:' || strftime('%M', End) ||' '|| 'am'";
		SQL = SQL + " When (strftime('%H',End) - 12) = 0 Then";
		SQL = SQL + " '12:' || strftime('%M', End) ||' '|| 'pm'";
		SQL = SQL + " When (strftime('%H', End) - 12) < 0 Then";
		SQL = SQL + " cast(strftime('%H', End) as integer) ||':'|| strftime('%M', End) ||' '|| 'pm'";
        SQL = SQL + " ELSE (cast(strftime('%H', End) as integer) - 12) ||':'|| strftime('%M', End) ||' '|| 'pm' End as End";
        SQL = SQL + " , Hours";
		
		SQL = SQL + " FROM( Select Review.ID, strftime('%m-%d-%Y',Review.Date) as Date";
	    SQL = SQL + ", Consumer.FirstName || ' ' || Consumer.LastName as Consumer";
	    SQL = SQL + ", Meeting.Description as Meeting";
	    SQL = SQL + ", TimeIn as Start, TimeOut as End";
        SQL = SQL + ", round(((strftime('%s',TimeOut) - strftime('%s',TimeIn))/60),2)/60 as Hours";
        SQL = SQL + " FROM Review";
	    SQL = SQL + " Join Meeting on Review.Meeting_ID = Meeting.ID";
	    SQL = SQL + " Join Consumer on Review.Consumer_ID = Consumer.ID";
        SQL = SQL + " Join Staff on Staff.ID = Review.Staff_ID";
        SQL = SQL + " Where Staff.FirstName || ' ' || Staff.LastName = '" + StaffID + "'";
        if (rdMonth.Checked == true)
        {
            SQL = SQL + " and strftime('%m',Review.Date) = '" + dtTimeFrame.Value.ToString("MM") + "'";
            SQL = SQL + " and strftime('%Y',Review.Date) = '" + dtTimeFrame.Value.ToString("yyyy") + "'";
        }
        else if(rdDay.Checked==true)
            SQL = SQL + " and Review.Date = '" + dtTimeFrame.Value.ToString("yyyy-MM-dd") + "'";

        SQL = SQL + " UNION";
	    
        SQL = SQL + " Select Administrative.ID, strftime('%m-%d-%Y',Administrative.Date) as Date";
	    SQL = SQL + " , ' - ' as Consumer, 'Administrative' as Meeting";
	    SQL = SQL + " , Administrative.StartTime as Start, Administrative.EndTime as End";
        SQL = SQL + ", round(((strftime('%s',Endtime) - strftime('%s',starttime))/60),2)/60 as Hours";
        SQL = SQL + " from Administrative";
	    SQL = SQL + " Join Staff on Staff.ID = Administrative.Staff_ID";
        SQL = SQL + " Where  Staff.FirstName || ' ' || Staff.LastName = '" + StaffID + "'";
        if (rdMonth.Checked == true)
        {
            SQL = SQL + " and strftime('%m',Administrative.Date) = '" + dtTimeFrame.Value.ToString("MM") + "'";
            SQL = SQL + " and strftime('%Y',Administrative.Date) = '" + dtTimeFrame.Value.ToString("yyyy") + "'";
        }
        else if (rdDay.Checked == true)
            SQL = SQL + " and Administrative.Date = '" + dtTimeFrame.Value.ToString("yyyy-MM-dd") + "'";

        SQL = SQL + " ) as AllActivity Order by Date, Start";
       
        return SQL;
    }

    private void grdAllActivity_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        passConsumerOrAdminID(grdAllActivity.CurrentRow.Index);
    }

    private void passConsumerOrAdminID(int Row)
    {
        if (grdAllActivity[3, Row].Value.ToString() != "Administrative")
        {
            txtConsumer.Text = grdAllActivity[2, Row].Value.ToString();
            loadSelectedConsumer();
            tabctlStaff.SelectTab(1);

        }
        else
            tabctlStaff.SelectTab(2);
    }
#endregion

    private void rdMonth_Click(object sender, EventArgs e)
    {
        rdDay.Checked = false;
        dtTimeFrame.CustomFormat = "MMMM";
        fillGrid_AllActivity();
    }

    private void rdDay_Click(object sender, EventArgs e)
    {
        rdMonth.Checked = false;
        dtTimeFrame.CustomFormat = "MM/dd/yyyy";
        fillGrid_AllActivity();
    }

    private void dtTimeFrame_ValueChanged(object sender, EventArgs e)
    {
        fillGrid_AllActivity();
    }

    private void returnHours()
    {
       
        clsDB objDB = new clsDB(strDB);
        string SQL = returnHours_SQL();
        SQLiteDataReader objReader = objDB.returnDataReader(SQL);
  
        while(objReader.Read())
        {

            if (objReader[0] != null)
                lblHours.Text = "Hours: " + objReader[0].ToString();
        }
    }

    private string returnHours_SQL()
    {
        string SQL = "Select Sum(Hours) as Hours";
        SQL = SQL + " From(";
        SQL = SQL + " Select sum(round(((strftime('%s',TimeOut) - strftime('%s',TimeIn))/60),2)/60) as Hours";
        SQL = SQL + " From Staff";
	    SQL = SQL + " Join Review on Staff.ID = Review.Staff_ID";
        SQL = SQL + " Where  Staff.FirstName || ' ' || Staff.LastName = '" + StaffID + "'";
        if (rdMonth.Checked == true)
        {
            SQL = SQL + " and strftime('%m',Review.Date) = '" + dtTimeFrame.Value.ToString("MM") + "'";
            SQL = SQL + " and strftime('%Y',Review.Date) = '" + dtTimeFrame.Value.ToString("yyyy") + "'";
        }
        else if (rdDay.Checked == true)
            SQL = SQL + " and Review.Date = '" + dtTimeFrame.Value.ToString("yyyy-MM-dd") + "'";

	    SQL = SQL + " Union";
	    SQL = SQL + " Select sum(round(((strftime('%s',Endtime) - strftime('%s',StartTime))/60),2)/60) as Hours";
        SQL = SQL + " From Staff";
	    SQL = SQL + " Left Join Administrative on Staff.ID = Administrative.Staff_ID";
        SQL = SQL + " Where  Staff.FirstName || ' ' || Staff.LastName = '" + StaffID + "'";

        if (rdMonth.Checked == true)
        {
            SQL = SQL + " and strftime('%m',Administrative.Date) = '" + dtTimeFrame.Value.ToString("MM") + "'";
            SQL = SQL + " and strftime('%Y',Administrative.Date) = '" + dtTimeFrame.Value.ToString("yyyy") + "')";
        }
        else if (rdDay.Checked == true)
            SQL = SQL + " and Administrative.Date = '" + dtTimeFrame.Value.ToString("yyyy-MM-dd") + "')";

        return SQL;
    }




















    }
}
