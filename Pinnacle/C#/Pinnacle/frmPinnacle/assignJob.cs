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
    
    
    public partial class assignJob : UserControl
    {
        public event Cancel CancelControl;
        private string ID;
        private string Role;
        private string JobID;

        public assignJob()
        {
            InitializeComponent();
        }

        public void loadControl_Assign(string strUser, string strID)
        {
            txtConsumer.Text = strUser;
            ID = strID;
            Role = "Assign";
            txtJob.Focus();
        }

        public void LoadControl_Edit(string strUser, string strID)
        {
            clsDB objDB = new clsDB(resPinnacle.liveDB);

            txtConsumer.Text = strUser;
            ID = strID;
            Role = "Edit";
            txtJob.Focus();

            string strSQL = "Select ID, Title, Description, Employer, Address, City, Zip";
            strSQL = strSQL + " , strftime('%m/%d/%Y',PlacementDate) as PlacementDate, strftime('%m/%d/%Y',ExtendedDate) as ExtendedDate";
            strSQL = strSQL + " From Job";
            strSQL = strSQL + " Where Consumer_ID = '" + strID + "'";

            SQLiteDataReader objReader = objDB.returnDataReader(strSQL);

            JobID = objReader["ID"].ToString();
            if (JobID == "")
            {
                MessageBox.Show("The consumer is currently unemployed.");
                Role = "Assign";
            }
            else
            {
                txtJob.Text = objReader["Title"].ToString();
                txtDescription.Text = objReader["Description"].ToString();
                txtEmployer.Text = objReader["Employer"].ToString();
                txtAddress.Text = objReader["Address"].ToString();
                txtCity.Text = objReader["City"].ToString();
                txtZip.Text = objReader["Zip"].ToString();
                txtPlacement.Text = objReader["PlacementDate"].ToString();
                txtExtended.Text = objReader["ExtendedDate"].ToString();
            }

            objReader.Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            CancelControl("assignJob");
        }

        private void addJob()
        {
            clsDB objDB = new clsDB(resPinnacle.liveDB);
            
            string strInsert = "Insert Into Job(Title, Description, Employer, Address,City, Zip,PlacementDate,ExtendedDate, Consumer_ID)";
            string strValues = " Values('" + txtJob.Text + "','" + removeApostrophe(txtDescription.Text) + "','" + removeApostrophe(txtEmployer.Text) + "','" + txtAddress.Text + "'"; 
            strValues = strValues + ",'" +  txtCity.Text  + "','" + formatZip(txtZip.Text) + "'," + formatDate(txtPlacement.Text) + "," + formatDate(txtExtended.Text) + ",'" + ID + "')";

            int Rows = objDB.assignJob(strInsert + strValues);

            if (Rows == 1)
                MessageBox.Show(txtConsumer.Text + " was assigned a new job.");
            else
                MessageBox.Show("The system was not able to assign a job, please contact IT if problem persists");

            CancelControl("assignJob");

        }

        private void editJob()
        {
            clsDB objDB = new clsDB(resPinnacle.liveDB);

            string strInsert = "Update Job";
            string strValues = " Set Title = '" + txtJob.Text + "', Description = '" + removeApostrophe(txtDescription.Text) + "', Employer = '" + removeApostrophe(txtEmployer.Text) + "'";
            strValues = strValues + ", Address = '" + txtAddress.Text + "', City = '" + txtCity.Text + "', Zip = '" + formatZip(txtZip.Text) + "'";
            strValues = strValues + ", PlacementDate = " + formatDate(txtPlacement.Text) + ", ExtendedDate = " + formatDate(txtExtended.Text);
            string strWhere = " Where ID = '" + JobID + "'";
            int Rows = objDB.assignJob(strInsert + strValues + strWhere);

            if (Rows == 1)
                MessageBox.Show(txtConsumer.Text + "'s job was updated.");
            else
                MessageBox.Show("The system was not able to edit the current job, please contact IT if problem persists");

            CancelControl("assignJob");
        }

        private void butJob_Click(object sender, EventArgs e)
        {
            switch (Role)
            {
                case "Assign":
                    addJob();
                    break;
                case "Edit":
                    editJob();
                    break;
            }
        }

        private string formatZip(string strZip)
        {
            strZip = strZip.Trim();
            if (strZip.Length == 1)
                strZip = "null";
            else if (strZip.Substring(strZip.Length-1, 1) == "-")
                strZip = strZip.Substring(0, 5);

            return strZip;
        }

        private string formatDate(string strDate)
        {
            if (strDate != @"  /  /")
            {
                if (validateDate(strDate) == true)
                {
                    DateTime dtDate = Convert.ToDateTime(strDate);
                    strDate = "'" + dtDate.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    strDate = "null";
                }

            }
            else
                strDate = "null";

            return strDate;
        }

        private bool validateDate(string strDate)
        {
            try
            {
                DateTime dtDate = DateTime.Parse(strDate);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string removeApostrophe(string strData)
        {
            strData = strData.Replace("'", "''");
            return strData;
        }
    }
}
