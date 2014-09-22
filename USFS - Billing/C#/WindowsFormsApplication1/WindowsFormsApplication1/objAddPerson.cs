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
    public partial class objAddPerson : UserControl
    {

        string strPicPath = "";

        
        public objAddPerson()
        {
            InitializeComponent();
            LoadControl();
        }

        private void butEnter_Click(object sender, EventArgs e)
        {
            AddPerson();
        }

        private void AddPerson()
        {
            string strSQL;
            objDatabase Database = new objDatabase();
            int intRows;
            bool blReady;

            blReady = CheckControl();
            if (blReady == true)
            {
                strSQL = "spAddPerson '" + txtFirstName.Text + "','" + txtLastName.Text + "','" + cmbRole.SelectedItem.ToString() + "','" + strPicPath + "'";
                intRows = Database.AddData(strSQL);

                if (intRows > 0) 
                {
                    MessageBox.Show( txtFirstName.Text + " " + txtLastName.Text + " has been added to the database.");
                    ClearControl();
                }
            }
        }

        private bool CheckControl()
        {
            bool blReady = false;
            
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("You did not enter a first name, please enter one.");
                txtFirstName.Focus();
            }
            else if (txtLastName.Text == "")
            {
                MessageBox.Show("You did not enter a last name, please enter one.");
                txtLastName.Focus();
            }
            else if (strPicPath == "")
            {
                DialogResult result = MessageBox.Show("You have not entered a picture for the new worker, are you sure you want to add the person to the database?", "No picture has been added.", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    butAddPic.Focus();
                }
                else
                {
                    picWorker.ImageLocation = "c:\\htcStateFair\\Silhoutte.jpg";
                    strPicPath = "c:\\htcStateFair\\Silhoutte.jpg";
                    blReady = true;
                }
            }
            else
            {
                blReady = true;
            }

            return blReady;
        }


        private void butCancel_Click(object sender, EventArgs e)
        {

            this.Parent.Dispose();

        }

        private void LoadControl()
        {
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

        private void butAddPic_Click(object sender, EventArgs e)
        {
            string strDirectory = Environment.CurrentDirectory + "\\Pics-NYStateFair";
            objOpenFile.InitialDirectory = strDirectory;
            objOpenFile.Filter = "jpeg files |*.jpg; *.jpeg";
            
            if (objOpenFile.ShowDialog() == DialogResult.OK)
            {

                strPicPath = System.IO.Path.GetDirectoryName(objOpenFile.FileName) + "\\" +  System.IO.Path.GetFileName(objOpenFile.FileName);
            } 
            

            picWorker.ImageLocation = strPicPath;
        }


        private void ClearControl()
        {
            strPicPath = "";
            txtFirstName.Clear();
            txtLastName.Clear();
            cmbRole.SelectedIndex = 0;
            picWorker.Image = null;
            txtFirstName.Focus();
        }

        private void objAddPerson_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblFirst_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblLast_Click(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblRole_Click(object sender, EventArgs e)
        {

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
      
    }
}
