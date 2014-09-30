using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace frmTimeClock
{
    public partial class frmTimeClock : Form
    {
        public frmTimeClock()
        {
            InitializeComponent();
        }

        private void txtData_KeyPress(object sender, KeyPressEventArgs e)
        {
            // char 13 = carriage return (enter key), pass what's in the textbox to the database
            if (e.KeyChar == 13)
            {

                UpdateDatabase();
                System.Console.Beep();
                Application.DoEvents();
                System.Threading.Thread.Sleep(2000);
                ClearControl();
            }
           
        }

        private void ClearControl()
        {
            lblError.Text = "";
            lblError.Visible = false;
            txtName.Text = "";

            txtTimeIn.Text = "";
            txtTimeOut.Text = "";
            txtData.Text = "";
            txtData.Focus();
        }


        private void UpdateDatabase()
        {
            Timer objTimer = new Timer();
            try
            {

                objSQLite Database = new objSQLite();
                int intData = Convert.ToInt16(txtData.Text.Substring(1, txtData.Text.Length - 2));



                Database.UpdateDB(intData);
                if (Database.Error == null && Database.Status != "Double-Swipe")
                {
                    txtName.Text = Database.Worker;
                    txtTimeIn.Text = Database.InTime.ToString("h:mm tt");
                    if (Database.Status == "Out")
                    {
                        txtTimeOut.Text = Database.OutTime.ToString("h:mm tt");
                    }
                }
                else if (Database.Status == "Double-Swipe")
                {
                    System.Console.Beep();
                    System.Console.Beep();
                    lblError.Visible = true;
                    lblError.Text = "You double-swiped, if you would like to swipe again please wait 5 mins.";
                    txtData.Clear();
                    txtData.Focus();
                }
                
            }
            catch (System.Exception e)
            {
                System.Console.Beep();
                System.Console.Beep();
                System.Console.Beep();
                lblError.Visible = true;
                //lblError.Text = "There was an error (" + e.Message.ToString() + "), please swipe again";
                MessageBox.Show(e.Message.ToString());
                txtData.Clear();
                txtData.Focus();
            }

            

        }
    }
}
