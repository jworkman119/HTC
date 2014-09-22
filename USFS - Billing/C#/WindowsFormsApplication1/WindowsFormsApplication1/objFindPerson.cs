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
    public partial class objFindPerson : UserControl
    {
        
        // Declare a new DataGridTableStyle in the
        // declarations area of your form.
        DataGridTableStyle objTblStyle = new DataGridTableStyle();
        string strRole = "";

        public objFindPerson()
        {
            InitializeComponent();
            LoadControl();
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            objDatabase Database = new objDatabase();
            string strSQL = CreateSQL();
            DataTable objTable = new DataTable();


            //objDataReader = Database.ReturnData(strSQL);
            objTable = Database.ReturnDataTable(strSQL);

            if (objTable.Rows.Count > 0)
            {
                objGrid.DataSource = objTable;
                objGrid.Columns[0].Visible = false;
                objGrid.Columns[4].Visible = false;

                if (objTable.Rows.Count == 1)
                {
                    Fill_Control(objGrid.Rows[0]);
                }
            }
            else
            {
                MessageBox.Show("No rows were returned, for the given critera, please try again");
                ClearControl();
            }
        }

        private string CreateSQL()
        {
            string strSQL;

            strSQL = "Select Person.ID, FirstName, LastName, Role.Description, PicPath";
            strSQL = strSQL + " From Person";
            strSQL = strSQL + " join Role on Person.Role_ID = Role.ID";
            strSQL = strSQL +  " Where Role.Description = " + "'" + cmbRole.Text + "'";    
            if (txtFirstName.Text != "")
            {
                strSQL = strSQL + " and FirstName like " + "'" + txtFirstName.Text + "'"; 
            }
            
            if (txtLastName.Text != "")
            {
                strSQL = strSQL + " and LastName like " + "'" + txtLastName.Text + "'";
            }
            strSQL = strSQL + " Group By Person.ID, FirstName, LastName, Role.Description, PicPath";
            return strSQL;
        }

        private void LoadControl()
        {
            txtID.ReadOnly = true;
            objDatabase Database = new objDatabase();
            SqlDataReader objReader;

            string strSQL = "Select Role.Description from Role";

            objReader = Database.ReturnData(strSQL);

            while (objReader.Read())
            {
                cmbRole.Items.Add(objReader[0].ToString());
            }

            cmbRole.SelectedIndex = 0;
            txtFirstName.Focus();

        }

        private void objGrid_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow objRow = objGrid.CurrentRow;

            objRow.Selected = true;
            Fill_Control(objRow);

        }


        private void Fill_Control(DataGridViewRow objRow)
        {
            txtID.Text = objRow.Cells[0].Value.ToString();
            txtFirstName.Text = objRow.Cells[1].Value.ToString();
            txtLastName.Text = objRow.Cells[2].Value.ToString();
            picWorker.ImageLocation = objRow.Cells[4].Value.ToString();
            butChangeTime.Enabled = true;

            int j;

            for (j = 0; j < cmbRole.Items.Count; j++)
            {
                if (cmbRole.Items[j].ToString() == objRow.Cells[3].Value.ToString())
                {
                    cmbRole.SelectedIndex = j;
                    strRole = objRow.Cells[3].Value.ToString();
                }
            }
        }

        private void objGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow objRow = objGrid.CurrentRow;
            objRow = objGrid.CurrentRow;

            objRow.Selected = true;
        }

        private void objGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow objRow = objGrid.CurrentRow;
            objRow = objGrid.CurrentRow;

            objRow.Selected = true;
        }


        private void ClearControl()
        {

            objGrid.DataSource = null;
            txtID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            picWorker.Image = null;
            butRole.Enabled = false;
            butChangeTime.Enabled = false;
            txtFirstName.Focus();
            strRole = "";
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void cmbRole_SelectedValueChanged(object sender, EventArgs e)
        {
            
            if (cmbRole.Text != strRole && strRole !="")
            {
                butRole.Enabled = true;
            }
            else
            {
                butRole.Enabled = false;
            }
        }

        private void butRole_Click(object sender, EventArgs e)
        {
            objDatabase Database = new objDatabase();
            string strSQL;
            int intRows;

            strSQL = "spUpdateRole '" + txtFirstName.Text + "','" +txtLastName.Text + "','" + cmbRole.Text + "'";
            intRows = Database.AddData(strSQL);

            if (intRows > 0)
            {
                MessageBox.Show(txtFirstName.Text + " " + txtLastName.Text + "'s role has been updated.");
            }
            ClearControl();
        }

        private void butChangeTime_Click(object sender, EventArgs e)
        {
            frmChangeTime objChangeTime = new frmChangeTime();

            objChangeTime.Worker = txtFirstName.Text + " " + txtLastName.Text + "'s Work Times";
            objChangeTime.WorkerID = txtID.Text;
            objChangeTime.ShowDialog();
         
        }

    }
}
