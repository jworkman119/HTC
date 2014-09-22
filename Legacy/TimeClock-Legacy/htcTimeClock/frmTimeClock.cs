using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;




namespace htcTimeClock
{
    public partial class frmTimeClock : Form
    {
        private bool blStarted;
        

        public class dbError : System.ApplicationException
        {

        }

        public frmTimeClock()
        {
            InitializeComponent();
            LoadForm();
            blStarted = true;

        }



        private void LoadForm()
        {
            txtTime.Text = DateTime.Now.ToShortDateString() + "     " + DateTime.Now.ToString("h:mm:ss tt");
        }

        private void tmrDigitalClock_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToShortDateString() + "     " + DateTime.Now.ToString("h:mm:ss tt");
           
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


        private void UpdateDatabase()
        {
            
            try
            {
                objDatabase Database = new objDatabase();
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

                }
            }
            catch(System.Exception e)
            {
                System.Console.Beep();
                System.Console.Beep();
                System.Console.Beep();
                lblError.Visible = true;
                lblError.Text = "There was an error, please swipe again";
            }

            
            
        }

        /**** Events *****/
        private void frmTimeClock_Load(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblInstructions_Click(object sender, EventArgs e)
        {

        }

        private void lblTimeIn_Click(object sender, EventArgs e)
        {

        }

        private void lblTimeOut_Click(object sender, EventArgs e)
        {

        }

        private void txtTime_Click(object sender, EventArgs e)
        {

        }



    }
}



