using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace FrontDesk
{
    public partial class frmFrontDesk : Form
    {
        // string strDB = "C:\\Users\\jeremyp.HTC\\Documents\\Development\\FrontDesk\\Database\\FrontDesk.sqlite";
        string strDB = "\\\\iomega-nas\\Public1\\IT Department\\FrontDesk\\FrontDesk.sqlite";


        public frmFrontDesk()
        {
            InitializeComponent();
            setupForm();
        }

        private void butSignIn_Click(object sender, EventArgs e)
        {
            grpTimes.Enabled = true;
            dtDate.Value = System.DateTime.Now;
            DateTime dtTime = System.DateTime.Now;
            setupTimePicker(dtIn,System.DateTime.Now, 0);
            if ( dtTime.Hour == 12 || dtTime.Hour == 11)
                dtOut = setupTimePicker(dtOut,System.DateTime.Now, 30);
            else
                dtOut = setupTimePicker(dtOut, System.DateTime.Now, 15);

        }


        private DateTimePicker setupTimePicker(DateTimePicker objPicker,DateTime dtTime, int intMin)
        {
            if (intMin > 0)
            {
                dtTime = getNearest15(dtTime);
                objPicker.Value = dtTime.AddMinutes(intMin);
            }
            else
                objPicker.Value = getNearest15(dtTime);

            objPicker.Format = DateTimePickerFormat.Custom;
            objPicker.CustomFormat = "hh:mm tt";

            return objPicker;
        }

        private DateTime getNearest15(DateTime dtTime)
        {
            int intMin = (dtTime.Minute / 15) * 15;
            intMin = dtTime.Minute - intMin;
            dtTime = dtTime.AddMinutes(intMin * -1);

            return dtTime;
        }

        private void setupForm()
        {
            cmbWorker.Items.Clear();
            clsDB objDB = new clsDB(strDB);
            //returning workers that have times
            string SQL = returnWorkers_NULLSQL();
            SQLiteDataReader objReader = objDB.returnDataReader(SQL);
            loadComboBox(objReader);
            objReader.Close();

            SQL = returnWorkersSQL();
            objReader = objDB.returnDataReader(SQL);
            loadComboBox(objReader);

            grpTimes.Enabled = false;
            cmbWorker.SelectedIndex = -1;
            if (cmbWorker.SelectedIndex != -1)
                cmbWorker.SelectedIndex = 0;
            
        }

        private void loadComboBox(SQLiteDataReader objReader)
        {

            while (objReader.Read())
            {
                cmbWorker.Items.Add(objReader["Worker"].ToString());
            }
        }

        private string returnWorkersSQL()
        {
            string SQL = "Select FirstName || ' ' || LastName as Worker";
            SQL = SQL + " From Worker";
            SQL = SQL + " Left Join TimeWorked on Worker.ID = TimeWorked.Worker_ID";
            SQL = SQL + " Where Active = 'true'";
	        SQL = SQL + " and TimeIn is not Null";
            SQL = SQL + " Group By FirstName,LastName";
            SQL = SQL + " Order by TimeIn";

            return SQL;

        }

        private string returnWorkers_NULLSQL()
        {
            string SQL = "Select FirstName || ' ' || LastName as Worker";
            SQL = SQL + " From Worker";
            SQL = SQL + " Left Join TimeWorked on Worker.ID = TimeWorked.Worker_ID";
            SQL = SQL + " Where Active = 'true'";
            SQL = SQL + " and TimeIn is Null";


            return SQL;
        }

        private void butSubmit_Click(object sender, EventArgs e)
        {
            updateDB();   
        }

        private void updateDB()
        {
            clsDB objDB = new clsDB(strDB);
            string SQL = returnUpdateSQL();
            bool blPass = objDB.ExecuteNonQuery(SQL);

            if (blPass == true)
                MessageBox.Show("Your time has been added to the database.");
            else
                MessageBox.Show("The application failed to update the database, please try again. If the problem persists call x5101");

            setupForm();
        }

        private string returnUpdateSQL()
        {
            string strTimeIn = dtIn.Value.ToString("yyyy-MM-dd hh:mm");
            string strTimeOut = dtOut.Value.ToString("yyyy-MM-dd hh:mm");
            string SQL = "Insert Into TimeWorked(TimeIn,TimeOut, Worker_ID)";
            SQL = SQL + " Select '" + strTimeIn + "', '" + strTimeOut + "', Worker.ID";
            SQL = SQL + " From Worker";
            SQL = SQL + " Where Worker.FirstName || ' ' || Worker.LastName = '" + cmbWorker.Text +  "'";



            return SQL;
        }

        private void dtIn_ValueChanged(object sender, EventArgs e)
        {
            setupTimePicker(dtOut, dtIn.Value, 30);
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime dtTime = dtDate.Value;
            setupTimePicker(dtIn, dtDate.Value, 0);
            if (dtTime.Hour == 12 || dtTime.Hour == 11)
                dtOut = setupTimePicker(dtOut,dtDate.Value , 30);
            else
                dtOut = setupTimePicker(dtOut,dtDate.Value, 15);
        }
    }
}
