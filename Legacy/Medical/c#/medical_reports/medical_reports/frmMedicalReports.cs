using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;




namespace medical_reports
{
    public partial class frmMedicalReports : Form
    {

        
        public frmMedicalReports()
        {
            InitializeComponent();
        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            string strRows;

            objFileDialog.InitialDirectory = "\\\\NtServer2\\h\\SM\\";
            objFileDialog.Filter = "txt files (*.txt)|*.txt";
            DialogResult result = objFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPath.Text = objFileDialog.FileName;
                StreamFile();
                strRows = UpdateDatabase();
            }
            
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void StreamFile()
        {

            string strPath;


            FileStream fileStream = new FileStream(txtPath.Text,
                                       FileMode.Open,
                                       FileAccess.Read,
                                       FileShare.Read);

            StreamReader objStream = new StreamReader(fileStream);
            strPath = "\\\\sqlserver01\\imports\\MedicalWeighted_" + DateTime.Today.ToString("MM-dd-yyyy") + ".txt"; 
            StreamWriter objWrite = new StreamWriter(strPath); //("C:\\Users\\jeremyp\\Documents\\Development\\Medical\\htcMedical\\DataDumps\\NewFile.txt");  
            string strLine;
            int j = 0;
            System.Collections.ArrayList objList = new System.Collections.ArrayList();            
            

            while ((strLine = objStream.ReadLine()) != null)
            {
                string[] arLine;
                if (j > 0)
                {
                    //hardcode to remove a comma from the provider's name
                    strLine = Regex.Replace(strLine, "MELNICK,", "MELNICK");
                    //hardcode to sync provider's name with DB
                    strLine = Regex.Replace(strLine, "LINDA ANNE TROUTMAN ZELOWS", "Linda Zelows");
                    //hardcode to sync provider's name with DB
                    strLine = Regex.Replace(strLine, "LAURA ANN SMITH-CREASER", "Laura Creaser");
                    //hardcode to sync provider's name with DB
                    strLine = Regex.Replace(strLine, "CYNTHIA LYNN GRIFFIN LMHC", "Cynthia Griffin");
                    
                    // replacing commas, double-quotes and whitespace
                    strLine = Regex.Replace(strLine, ",", "|");
                    strLine = Regex.Replace(strLine,"\"","");
                    

                    arLine = strLine.Split('|');
                    arLine[1] = Regex.Replace(arLine[1],"%","");
                    arLine[1] = Regex.Replace(arLine[1], ">", "");
                    arLine[2] = Regex.Replace(arLine[2], "%", "");
                    arLine[2] = Regex.Replace(arLine[2], ">", "");
                    //removing middle initial from string(provider's name)
                    arLine[8] = Regex.Replace(arLine[8], "\\w\\.\\040", "");
                    arLine[8] = Regex.Replace(arLine[8], "\\040\\w\\040", " ");
                    objList.AddRange(arLine[8].Split(' '));
                    if (objList.Count > 2)
                    {
                        do
                        {
                            objList.RemoveAt(2);
                        } while (objList.Count > 2);
                    }
                    string[] arField = (string[])objList.ToArray(typeof(string)) ;
                    arLine[8] = string.Join("|",arField);
                    objList.Clear();

                    strLine = string.Join("|",arLine);
                    strLine = Regex.Replace(strLine, " ", "");
                    strLine = CreateSubstring(strLine);


                    objWrite.WriteLine(strLine);
                    /*
                    for (int t = 0; t <= 3; t++)
                    {
                        strLine = strLine.Substring(0, strLine.LastIndexOf('|'));
                    }
                        objWrite.WriteLine(strLine + "||");
                    */
                }
                j++;
            }

            objStream.Close();
            objWrite.Close();

        }

        private string CreateSubstring(string strLine)
        {
            int t = 0;

            for (int j = 0; j < 30; j++)
            {
                t = strLine.IndexOf('|', t+1);
                
            }
            strLine = strLine.Substring(0,t);
            return strLine + "|0";
        }

        
        private string UpdateDatabase()
        {
             SqlConnection sqlConnection = new SqlConnection();
             ADODB.Connection adoConnection = new ADODB.Connection();
             ADODB.Recordset adoRecordset = new ADODB.Recordset();
             SqlCommand sqlCommand = new SqlCommand();
             SqlParameter sqlParameter = new SqlParameter();
             int intRows;

            sqlConnection.ConnectionString = "Persist Security Info=False;Integrated Security=SSPI;database=htcMedical;server=sqlServer01"; //"Provider = SQLOleDB; Data Source = SQLServer01; Initial Catalog = htcMedical; Integrated Security = SSPI; Trusted_Connection = True";
            sqlConnection.Open();


            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "spFill_NewMonth";
       
            intRows = sqlCommand.ExecuteNonQuery();

            if (intRows > 0)
            {
                return intRows.ToString() + " rows were updated";
            }
            else
            {
                return "no rows were updated";
            }
        }
 
    }
}
