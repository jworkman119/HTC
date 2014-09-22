using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace WindowsFormsApplication1
{
    public partial class frmReportViewer : Form
    {

        private DateTime dtDate;
        private string strShift;
        private string strReport;
        
        public DateTime Date
        {
            set
            {
                dtDate = value;
            }
        }

        public string Shift
        {
            set
            {
                strShift = value;
            }
        }

        public string Report
        {
            set
            {
                strReport = value;
                LoadReport("c:\\htcStateFair\\Reports\\" + strReport + ".rpt");
            }
        }

        public frmReportViewer()
        {
            InitializeComponent();
        }

        private void LoadReport(string strReport)
        {
            ReportDocument objReport = new ReportDocument();

            Cursor.Current = Cursors.WaitCursor;
                objReport.Load(strReport);
                
                if (strReport.IndexOf("Schedule") > 0)
                {
                    objReport.SetParameterValue("@Day", dtDate);
                    objReport.SetParameterValue("@Shift", strShift);
                }
                else if (strReport.IndexOf("Accounting") > 0 )
                {
                    objReport.SetParameterValue("@Date", dtDate);
                }
                objReportViewer.ReportSource = objReport;
            Cursor.Current = Cursors.WaitCursor;
        }


        
        
    }
}

/*
*/