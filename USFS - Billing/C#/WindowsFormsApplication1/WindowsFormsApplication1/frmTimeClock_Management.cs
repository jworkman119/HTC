using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            objAddPerson AddPerson = new objAddPerson();
            LoadControls(AddPerson, "Add Person");
        }

        private void LoadControls(Control objControl, string strFrameName)
        {

            objTabs.SelectedIndex = 0;
            radFindWorker.Select();

            // uncomment if you don't want the reports tab to display.
           // objTabs.TabPages.Remove(objTab3);
            
           // this.Controls.Add(objControl);
           // this.Width = objControl.Width + 20;
           // this.Height = objControl.Height + 20;
        }

        private void radFindWorker_CheckedChanged(object sender, EventArgs e)
        {
            if (radFindWorker.Checked == true)
            {
                objFindPerson FindPerson = new objFindPerson();
                radAddWorker.Checked = false;
                objPanel.Controls.Clear();
                objPanel.Controls.Add(FindPerson);
                ActiveControl = FindPerson;
                ActiveControl.Focus();
            }
        }

        private void radAddWorker_CheckedChanged(object sender, EventArgs e)
        {
            if (radAddWorker.Checked == true)
            {
                objAddPerson AddPerson = new objAddPerson();
                radFindWorker.Checked = false;
                objPanel.Controls.Clear();
                objPanel.Controls.Add(AddPerson);
                this.ActiveControl = objPanel;
                ActiveControl = AddPerson;
                ActiveControl.Focus();
            }
        }

        private void radSchedule_CheckedChanged(object sender, EventArgs e)
        {
            if (radSchedule.Checked == true)
            {
                objCreateSchedule CreateSchedule = new objCreateSchedule();
                radShifts.Checked = false;
                objPanel2.Controls.Clear();
                objPanel2.Controls.Add(CreateSchedule);
                this.ActiveControl = objPanel2;
                ActiveControl = CreateSchedule;
                ActiveControl.Focus();
            }
        }

        private void radShifts_CheckedChanged(object sender, EventArgs e)
        {
            if (radShifts.Checked == true)
            {
                objCreateShift CreateShift = new objCreateShift();
                radSchedule.Checked = false;
                objPanel2.Controls.Clear();
                objPanel2.Controls.Add(CreateShift);
                this.ActiveControl = objPanel2;
                ActiveControl = CreateShift;
                ActiveControl.Focus();
            }
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radSupervisor_CheckedChanged(object sender, EventArgs e)
        {
            if (radSupervisor.Checked == true)
            {
                objAssignSupervisor AddSuperVisor = new objAssignSupervisor();
                radSchedule.Checked = false;
                radShifts.Checked = false;
                objPanel2.Controls.Clear();
                objPanel2.Controls.Add(AddSuperVisor);
                this.ActiveControl = objPanel2;
                ActiveControl = AddSuperVisor;
                ActiveControl.Focus();
            }
        }

        private void objTabs_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (objTabs.SelectedIndex == 2)
            {
                cmbShift.Items.Clear();
                // Filing cmbShifts
                objDatabase DataBase = new objDatabase();
                string strSQL = "Select Shift.Name From Shift";
                DataTable objDTable = DataBase.ReturnDataTable(strSQL);
                foreach (DataRow objRow in objDTable.Rows)
                {
                    cmbShift.Items.Add(objRow[0]);
                }

                cmbReports.Items.Clear();
                cmbReports.Items.Add("Schedule");
                cmbReports.Items.Add("Accounting");
                cmbReports.SelectedIndex = -1;

            }

        }

        private void cmbReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReports.SelectedIndex == 0)
            {
                cmbShift.Visible = true;
                dtDay.Visible = true;
                dtDay.Value.ToShortDateString();
                butGetReport.Visible = true;
            }
            else if (cmbReports.SelectedIndex == 1)
            {
                cmbShift.Visible = false;
                dtDay.Visible = true;
                dtDay.Value.ToShortDateString();
                butGetReport.Visible = true;
            }
            else
            {
                dtDay.Visible = false;
                cmbShift.Visible = false;
                butGetReport.Visible = false;
            }
            
        }

        private void butGetReport_Click(object sender, EventArgs e)
        {
            frmReportViewer objReportViewer = new frmReportViewer();

            
            objReportViewer.Date = dtDay.Value;
           
            objReportViewer.Shift = cmbShift.Text;
           
            objReportViewer.Report = cmbReports.Text;
            objReportViewer.Show();
       }
    }
}
