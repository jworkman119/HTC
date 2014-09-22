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
    public delegate void Edit(string ID, string strConsumer);
    public delegate void Job(string ID, string strConsumer);
    public delegate void AllConsumers(string ID, string strConsumer);
    

    public partial class ConsumerList : UserControl
    {
        public event Edit EditConsumer;
        public event Job AssignJob;
        public event Job EditJob;
        public event AllConsumers EnableAllConsumers;
        public event PassReview PassReviewID;
        public event EditReview EditReviewID;
        string ConsumerID;
        string Consumer;
        string Status;
        //Test
        //string strDB = resPinnacle.testDB;

        //Live
        string strDB = resPinnacle.liveDB;

        public ConsumerList()
        {
            InitializeComponent();
            LoadControl();
        }
    
        private void LoadControl()
        {
            clsDB objDB = new clsDB(strDB);
            
            // Loading combobox cmbStaff
            cmbStaff.SelectedIndex = -1;
            SQLiteDataReader objReader = objDB.returnComboBox("Staff");
            cmbStaff.Items.Add("All Staff");
            while (objReader.Read())
            {
                cmbStaff.Items.Add(objReader["Staff"]);
            }
            cmbStaff.SelectedIndex = 0;
            objReader.Close();
            Status = "All";
        }

        private void DeleteReview(string strConsumer, string strReviewID)
        {
            clsDB objDB = new clsDB(resPinnacle.liveDB);
            string SQL = "Delete from Review where ID = " + strReviewID;
            bool blPass = objDB.executeNonQuery(SQL);

            if (blPass == false)
                MessageBox.Show("Your review was not deleted. If problem persists please contact IT.");

            SQL = selectedConsumer_SQL();
            SQLiteDataReader objReader = objDB.returnDataReader(SQL);
            clsGridUtils objGrid = new clsGridUtils();
            objGrid.fillGrid(objReader, 3, ref grdConsumers, this.CreateGraphics());

        }

        private void DeleteConsumer(string strConsumer, string strID)
        {
            clsDB objDB = new clsDB(strDB);
            DialogResult objResult = MessageBox.Show("Are you sure you want to delete " + strConsumer + " from the database? This permanently deletes the user from the database.", "Delete - " + strConsumer, MessageBoxButtons.YesNo);
            if (objResult == DialogResult.Yes)
            {
                string SQL = "Delete from Consumer where Consumer.ID = " + strID;
                bool blPass = objDB.executeNonQuery(SQL);
                if (blPass == true)
                {
                    MessageBox.Show(strConsumer + " was successfully deleted from the system");
                    LoadControl();
                }
            }
        }

        private void loadSelectedConsumer()
        {
            string strSQL = selectedConsumer_SQL();
            clsDB objDB = new clsDB(strDB);
            clsGridUtils objGrid = new clsGridUtils();

            SQLiteDataReader objReader = objDB.returnDataReader(strSQL);
            ConsumerID = objReader[0].ToString();
            Consumer = objReader[2].ToString();
            objGrid.fillGrid(objReader, 3, ref grdConsumers, this.CreateGraphics());
        }

        private void makeInactive(string strConsumer, string strID)
        {
            clsDB objDB = new clsDB(strDB);
            bool blPass = objDB.makeInActive(strID);
            if (blPass == true)
            {
                MessageBox.Show(strConsumer + " was successfully made Inactive.");
                LoadControl();
            }

        }

#region SQL

            private string selectedConsumer_SQL()
            {
                string strConsumer;
                if (Consumer == null)
                    strConsumer = grdConsumers.CurrentRow.Cells[1].Value.ToString();
                else
                    strConsumer = Consumer;


                string SQL = "SELECT Consumer.ID as ConsumerID, Review.ID as ReviewID, Consumer.FirstName || ' ' || Consumer.LastName as Consumer";
                SQL = SQL + " , Job.Title as Job , Job.Employer, strftime('%m/%d/%Y', Review.Date) as [Reviewed], Meeting.Description as [Meeting Type]";
                SQL = SQL + " , Staff.FirstName || ' ' || Staff.LastName as Staff";
                SQL = SQL + " FROM Consumer";
                SQL = SQL + " LEFT JOIN ConsumerStaff on Consumer.ID = ConsumerStaff.Consumer_ID";
                SQL = SQL + " LEFT JOIN Staff on ConsumerStaff.Staff_ID =  Staff.ID";
                SQL = SQL + " LEFT JOIN Review on Consumer.ID = Review.Consumer_ID";
                SQL = SQL + " LEFT JOIN Job on Review.Job_ID = Job.ID";
                SQL = SQL + " LEFT JOIN Meeting on Review.Meeting_ID = Meeting.ID";
                SQL = SQL + " WHERE Consumer.FirstName || ' ' || Consumer.LastName = '" + strConsumer + "'";
                SQL = SQL + " AND Consumer.Active = 'true'";


                return SQL;
            }

            private string returnHours_SQL()
            {
                string Staff = cmbStaff.Text;

                string SQL = "Select Sum(Hours) as Hours";
                SQL = SQL + " From(";
                SQL = SQL + " Select sum(round(((strftime('%s',TimeOut) - strftime('%s',TimeIn))/60),2)/60) as Hours";
                SQL = SQL + " From Staff";
                SQL = SQL + " Join Review on Staff.ID = Review.Staff_ID";
                if (rdMonth.Checked == true)
                {
                    SQL = SQL + " Where strftime('%m',Review.Date) = '" + dtTimeFrame.Value.ToString("MM") + "'";
                    SQL = SQL + " and strftime('%Y',Review.Date) = '" + dtTimeFrame.Value.ToString("yyyy") + "'";
                }
                else if (rdDay.Checked == true)
                    SQL = SQL + " Where Review.Date = '" + dtTimeFrame.Value.ToString("yyyy-MM-dd") + "'";

                if (Staff != "All Staff")
                    SQL = SQL + " and Staff.FirstName || ' ' || Staff.LastName = '" + Staff + "'";

                SQL = SQL + " Union";

                SQL = SQL + " Select sum(round(((strftime('%s',Endtime) - strftime('%s',StartTime))/60),2)/60) as Hours";
                SQL = SQL + " From Staff";
                SQL = SQL + " Left Join Administrative on Staff.ID = Administrative.Staff_ID";


                if (rdMonth.Checked == true)
                {
                    SQL = SQL + " Where strftime('%m',Administrative.Date) = '" + dtTimeFrame.Value.ToString("MM") + "'";
                    SQL = SQL + " and strftime('%Y',Administrative.Date) = '" + dtTimeFrame.Value.ToString("yyyy") + "'";
                }
                else if (rdDay.Checked == true)
                    SQL = SQL + " Where Administrative.Date = '" + dtTimeFrame.Value.ToString("yyyy-MM-dd") + "'";

                if (Staff != "All Staff")
                    SQL = SQL + " and Staff.FirstName || ' ' || Staff.LastName = '" + Staff + "'";

                SQL = SQL + ")";
                return SQL;
            }

            private string returnAllActivity_SQL()
            {
                string Staff = cmbStaff.Text;

                string SQL = "Select ID ";
                if (cmbStaff.Text == "All Staff")
                    SQL = SQL + ", Staff";
                SQL = SQL + ", Date, Consumer, Meeting";
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

                SQL = SQL + " FROM(";
                SQL = SQL + " Select";
                if (cmbStaff.Text == "All Staff")
                    SQL = SQL + " Staff.FirstName || ' ' || Staff.LastName as Staff,";
                SQL = SQL + " Review.ID, strftime('%m-%d-%Y',Review.Date) as Date";
                SQL = SQL + ", Consumer.FirstName || ' ' || Consumer.LastName as Consumer";
                SQL = SQL + ", Meeting.Description as Meeting";
                SQL = SQL + ", TimeIn as Start, TimeOut as End";
                SQL = SQL + ", round(((strftime('%s',TimeOut) - strftime('%s',TimeIn))/60),2)/60 as Hours";
                SQL = SQL + " FROM Review";
                SQL = SQL + " Join Meeting on Review.Meeting_ID = Meeting.ID";
                SQL = SQL + " Join Consumer on Review.Consumer_ID = Consumer.ID";
                SQL = SQL + " Join Staff on Staff.ID = Review.Staff_ID";
                if (rdMonth.Checked == true)
                {
                    SQL = SQL + " Where strftime('%m',Review.Date) = '" + dtTimeFrame.Value.ToString("MM") + "'";
                    SQL = SQL + " and strftime('%Y',Review.Date) = '" + dtTimeFrame.Value.ToString("yyyy") + "'";
                }
                else if (rdDay.Checked == true)
                    SQL = SQL + " Where Review.Date = '" + dtTimeFrame.Value.ToString("yyyy-MM-dd") + "'";
                if (Staff != "All Staff")
                    SQL = SQL + " and Staff.FirstName || ' ' || Staff.LastName = '" + Staff + "'";

                SQL = SQL + " UNION";

                SQL = SQL + " Select";
                if (cmbStaff.Text == "All Staff")
                    SQL = SQL + " Staff.FirstName || ' ' || Staff.LastName as Staff,";
                SQL = SQL + " Administrative.ID, strftime('%m-%d-%Y',Administrative.Date) as Date";
                SQL = SQL + " , ' - ' as Consumer, 'Administrative' as Meeting";
                SQL = SQL + " , Administrative.StartTime as Start, Administrative.EndTime as End";
                SQL = SQL + ", round(((strftime('%s',Endtime) - strftime('%s',starttime))/60),2)/60 as Hours";
                SQL = SQL + " from Administrative";
                SQL = SQL + " Join Staff on Staff.ID = Administrative.Staff_ID";

                if (rdMonth.Checked == true)
                {
                    SQL = SQL + " Where strftime('%m',Administrative.Date) = '" + dtTimeFrame.Value.ToString("MM") + "'";
                    SQL = SQL + " and strftime('%Y',Administrative.Date) = '" + dtTimeFrame.Value.ToString("yyyy") + "'";
                }
                else if (rdDay.Checked == true)
                    SQL = SQL + " Where Administrative.Date = '" + dtTimeFrame.Value.ToString("yyyy-MM-dd") + "'";
                if (Staff != "All Staff")
                    SQL = SQL + " and Staff.FirstName || ' ' || Staff.LastName = '" + Staff + "'";

                SQL = SQL + " ) as AllActivity Order by Date, Start";

                return SQL;
            }

            private string returnConsumersSQL(string Staff)
            {
                string SQL = "SELECT ConsumerList.*, Staff.FirstName || ' ' || Staff.LastName as Staff";
                SQL = SQL + " FROM ConsumerList";
                SQL = SQL + " LEFT JOIN ConsumerStaff on ConsumerList.ID = ConsumerStaff.Consumer_ID";
                SQL = SQL + " AND Staff.ID = ConsumerStaff.Staff_ID";
                SQL = SQL + " LEFT JOIN Staff on ConsumerStaff.Staff_ID = Staff.ID";
                if (Staff != "All Staff")
                    SQL = SQL + " Where Staff.FirstName || ' ' || Staff.LastName = '" + Staff + "'";
                SQL = SQL + " GROUP BY ID, Consumer, SSN, AVR, VESID, Units, Disability";
                SQL = SQL + " , Service, Funding, ReferralDate, IntakeDate, VRC, Created";
                SQL = SQL + " Having min(Staff_ID) or Staff_ID is null";
                SQL = SQL + " Order by Consumer";
                return SQL;
            }

#endregion 

#region Events

        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGrdConsumers();
        }

        private void menuGrid_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (grdConsumers.SelectedRows.Count > 0)
            {
                string strID = grdConsumers.CurrentRow.Cells[0].Value.ToString();
                string strConsumer = grdConsumers.CurrentRow.Cells[1].Value.ToString();
                menuGrid.Close();
                switch (e.ClickedItem.Text)
                {
                    case "View":
                        // retrieving Consumer
                        EditReviewID(grdConsumers[0, grdConsumers.CurrentRow.Index].Value.ToString(), "ConsumerList");
                        break;
/*
                    case "Assign Job":
                        AssignJob(strID, strConsumer);
                        break;
                    case "Edit Job":
                        EditJob(strID, strConsumer);
                        break;
                    case "Delete":
                        DeleteConsumer(strConsumer, strID);
                        break;
                    case "Make Inactive":
                        makeInactive(strConsumer, strID);
                        break;
*/ 
                }
            }
            else
                MessageBox.Show("You must select a row.");
        }

        private void grdConsumers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Status == "Consumer")
            {
                PassReviewID(grdConsumers.CurrentRow.Cells[1].Value.ToString());
            }
        }

        private void menuReview_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Edit Review":
                    EditReviewID(grdConsumers[1, grdConsumers.CurrentRow.Index].Value.ToString(),"ConsumerList");
                    break;
                case "Delete Review":
                    DeleteReview(Consumer, grdConsumers[1, grdConsumers.CurrentRow.Index].Value.ToString());
                    break;

            }
        }

        private void rdDay_Click(object sender, EventArgs e)
        {
            rdMonth.Checked = false;
            dtTimeFrame.CustomFormat = "MM/dd/yyyy";
            fillGrdConsumers();
        }

        private void rdMonth_Click(object sender, EventArgs e)
        {
            rdDay.Checked = false;
            dtTimeFrame.CustomFormat = "MMMM";
            fillGrdConsumers();
        }
#endregion 

        private void dtTimeFrame_ValueChanged(object sender, EventArgs e)
        {
            fillGrdConsumers();
        }

        private void returnHours()
        {

            clsDB objDB = new clsDB(strDB);
            string SQL = returnHours_SQL();
            SQLiteDataReader objReader = objDB.returnDataReader(SQL);

            while (objReader.Read())
            {

                if (objReader[0] != null)
                    lblHours.Text = "Hours: " + objReader[0].ToString();
            }
        }

        private void fillGrdConsumers()
        {
            clsDB objDB = new clsDB(strDB);
            clsGridUtils objGrid = new clsGridUtils();

            //SQLiteDataReader objReader = objDB.returnConsumers("Consumers", cmbStaff.Text, blActiveOnly);
            string SQL = returnAllActivity_SQL();
            SQLiteDataReader objReader = objDB.returnDataReader(SQL);

            objGrid.fillGrid(objReader, 1, ref grdConsumers, this.CreateGraphics());
            objReader.Close();

            returnHours();
        }

    }
}
