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

    public partial class frmReports : Form
    {
        private string strConsumer;
        private string strConsumerID;
        private string strMonth;

        public string Consumer
        {
            set { strConsumer = value; }
        }

        public string ConsumerID
        {
            set { strConsumerID = value; }
        }

        public string Month
        {
            set { strMonth = value; }
        }


        public frmReports()
        {
            InitializeComponent();
        }

        public void LoadForm()
        {
            lblConsumer.Text = "Consumer: " + strConsumer;
            this.Text = "Create Report -" + strConsumer;
            cmbMonth.SelectedIndex = (System.DateTime.Now.Month - 1) - 1;
            load_cmbYear();
        }

        private void load_cmbYear()
        {
            for (int j = 0; j < 3; j++)
            {
                int Year = System.DateTime.Now.Year - j;
                cmbYear.Items.Add(Year.ToString());
            }
            cmbYear.SelectedIndex = 0;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butEnter_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            clsReports objReports = new clsReports();
            
            string[] Month = cmbMonth.Text.Split('-');
            strMonth = Month[0].Trim();
            string strReturn = objReports.CreateMonthlyActivityLog(strConsumerID, strMonth, cmbYear.Text);
            if (strReturn.Length > 0)
                MessageBox.Show(strReturn);
            else
                this.Dispose();

            this.Cursor = Cursors.Default;
        }
    }
}
