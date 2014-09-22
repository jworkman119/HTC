using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;
using System.Resources;



namespace HiTechnic
{
    public partial class frmMain : System.Windows.Forms.Form
    {
        
        static void Main()
        {
            System.Windows.Forms.Application.Run(new frmMain());
        }
        
        public frmMain()
        {
            InitializeComponent();
            Load_Form();
        }

        private void Load_Form()
        {
            LoadGrid( "UnShipped");
        }

        private void LoadGrid(string strType)
        {
            this.Cursor = Cursors.WaitCursor;
                // Todo - move this string, probably should be put in an xml initialization file
                
                clsDatabase objDatabase = new clsDatabase(HiTecResources.DB);
                SQLiteDataReader objData = objDatabase.returnData(strType);
                int Row = 0;
                grdOrders.ColumnCount = objData.FieldCount;
                //for resizing columns
                Graphics objGraphics = this.CreateGraphics();
                int[] colW = new int[objData.FieldCount];

                grdOrders.Rows.Clear();

                //adding data to grid
                while (objData.Read())
                {
                    grdOrders.Rows.Add();    

                    for (int Col=0; Col < objData.FieldCount; Col++)
                    {
                        if (Row == 0)
                        {
                            string strHeader = objData.GetName(Col);
                            grdOrders.Columns[Col].HeaderText = objData.GetName(Col);
                        }

                        SizeF objSize = objGraphics.MeasureString(objData[Col].ToString(), grdOrders.Font);
                        if (objSize.Width > colW[Col])
                        {
                            colW[Col] = (int)objSize.Width + 5;
                        }
                        grdOrders[Col, Row].Value = objData[Col].ToString();

                    }
                    Row++;
                }
           
                //Resizing rows
               AdjustGrid(colW, grdOrders.Columns.Count);
                
                if (strType == "UnShipped" && mnuRightClick.Items.Count==1)
                {
                    mnuRightClick.Items.Add("Void Order");
                }
                else if(strType == "Shipped" && mnuRightClick.Items.Count==2)
                {
                    mnuRightClick.Items.Remove(mnuRightClick.Items[1]);
                }
           
            this.Cursor = Cursors.Default;
        }

        private void AdjustGrid(int[] colW, int intFields)
        {
            int intTotal = colW.Sum();

            int intAddTo = (grdOrders.Width - intTotal) / intFields;

            //Resizing rows
            
            for (int j = 0; j < intFields; j++)
            {
                if (intAddTo > 0)
                {
                    grdOrders.Columns[j].Width = colW[j] + intAddTo;
                    grdOrders.ScrollBars = ScrollBars.Vertical;
                }
                else
                {
                    grdOrders.Columns[j].Width = colW[j];
                    grdOrders.ScrollBars = ScrollBars.Both;
                }
            }

            
        }

        private void tabOrders_Selecting(object sender, TabControlCancelEventArgs e)
        {

            TabPage objTab = tabOrders.SelectedTab;
            objTab.Controls.Add(grdOrders);

            if (tabOrders.SelectedIndex == 0) 
            {  
                LoadGrid("UnShipped");
                chkSearch.Visible = false;
                grpSearch.Visible = false;
            }
            else if(tabOrders.SelectedIndex == 1 ) 
            {
                if (this.rdb200.Checked == true)
                {
                    LoadGrid("Shipped200");
                }
                chkSearch.Checked = false;
                chkSearch.Visible = true;
            }
            
 
        }
        
        private string Create_UpdateSQL(DataRow row)
        {
            string SQL;

            SQL = "Update MasterNotes";
            SQL = SQL + " Set [PickedFullIndicator] ="  + row[2].ToString();
            SQL = SQL + " ,[ShippingNotes] = '" + row[3].ToString() + "'";
            SQL = SQL + " , [Void] = " + row[4].ToString() ;
            SQL = SQL + " Where [RefNumber] = '" + row[0].ToString() + "'";
            return SQL;
        }

        private void butImport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            XLS2CSV();

            LoadGrid("UnShipped");
            this.Cursor = Cursors.Default;
        }

        private void butUSPS_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
           
            clsExcel objExcel = new clsExcel();

            string strDate = dtDate.Value.ToString("yyyyMMdd") ; 

            string strSQL = "Select * FROM EPostage where SHIPDATE ='" + strDate + "'";

            objExcel.Return_SpreadSheet(strSQL, HiTecResources.USPS_XLS);
       
            clsEmail objMail = new clsEmail();
            strDate = DateTime.Today.ToString("MM/dd/yyyy");

            string strResponse = objMail.sendEndOfDay(HiTecResources.HiTec_Email, HiTecResources.HTC_Email, "All End of Day Files -" + strDate);
            
            this.Cursor = Cursors.Default;

            if (strResponse == "Mail Sent Successfully")
            {
                MessageBox.Show(strResponse);

            }
            else
            {
                MessageBox.Show(strResponse);
            }
            
        }

      

        private void grdIncomplete_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.mnuRightClick.Show(this.grdOrders,new Point(e.X,e.Y));
            }
        }

        private void grdIncomplete_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hti = ((DataGridView)sender).HitTest(e.X, e.Y);
            if (hti.RowIndex > -1)
            {
                grdOrders.Rows[hti.RowIndex].Selected = true;
            }
        }
        
        private void XLS2CSV()
        {
            clsConvert2CSV obj2CSV = new clsConvert2CSV();
            clsUploadData objUploadData = new clsUploadData();
            string csvDailyFinal = Path.GetTempPath() + "\\DailyFinal.csv";

            obj2CSV.convertExcelToCSV(HiTecResources.DailyOrders_XLS, "DailyFINAL", csvDailyFinal);

            objUploadData.RelayStatus += new SystemStatus(NewStatus);
            objUploadData.uploadData(csvDailyFinal, HiTecResources.DB, obj2CSV.Rows);

            if (lblStatus.Text.Substring(0, 5) != "Error")
            {
                lblStatus.Text = "";
                MessageBox.Show("The orders have been entered in the DB and the Packing Lists have been sent to the printer");
            }
        }

        private void NewStatus(string Status)
        {
            lblStatus.Text = Status;
        }

        private void mnuRightClick_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            switch (e.ClickedItem.Text)
            {
                case "Print":
                    clsPackingList objPackingList = new clsPackingList();
                    objPackingList.returnPackingList(grdOrders[0, grdOrders.CurrentRow.Index].Value.ToString(),tabOrders.SelectedTab.Text);
                    mnuRightClick.Close();
                    MessageBox.Show("Your packing list has been sent to the printer");
                    break;
                case "Void Order":
                    VoidOrder();
                    break;
                default:
                    break;
            }

            mnuRightClick.Close();
            this.Cursor = Cursors.Default;
        }

        private void VoidOrder()
        {
            string strOrder = grdOrders.CurrentRow.Cells[0].Value.ToString();
            DialogResult result = MessageBox.Show("Are you sure you want to delete Order #: " + strOrder,"Delete Order",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                clsDatabase objDatabase = new clsDatabase(HiTecResources.DB);
                bool blSuccess = objDatabase.deleteFromDB(strOrder);
                if (blSuccess == true)
                {
                    MessageBox.Show("Order #" + strOrder + " has been deleted from the sytem.");
                    LoadGrid("UnShipped");
                }
                else
                {
                    MessageBox.Show("Order #" + strOrder + " has been deleted from the sytem.","Error on Delete",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string strTest = txtSearch.Text;
            for (int j = 0; j<grdOrders.Rows.Count; j++)
            {
                int intLen = strTest.Length;
                string strValue = grdOrders[0,j].Value.ToString();
                if (strValue.Length >= strTest.Length)
                {
                    if (strValue.Substring(0, intLen) != strTest)
                    {
                        grdOrders.Rows[j].Visible = false;
                    }
                    else
                    {
                        grdOrders.Rows[j].Visible = true;
                    }
                }
                else
                {
                    grdOrders.Rows[j].Visible = false;
                }
            }
        }

        private void chkSearch_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkSearch.Checked == true)
            {
                grpSearch.Visible = true;
                txtSearch.Focus();
            }
            else
            {
                grpSearch.Visible = false;
            }
        }

        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAll.Checked == true)
            {
                rdb200.Checked = false;
                LoadGrid("ShippedAll");
            }
        }

        private void rdb200_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb200.Checked == true)
            {
                rdbAll.Checked = false;
                LoadGrid("Shipped200");
            }
        }

        
    }
}
