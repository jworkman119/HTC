using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Data.SQLite;
using System.Globalization;

namespace emailTotalHours
{
    class clsCreateReport
    {
       
        public void CreateReport()
        {
            string strMonth = System.DateTime.Now.Month.ToString();
            int Month = returnMonth(strMonth);
            string Year = returnYear(Month.ToString());
            List<string> Files = new List<string>();
            clsDB objDB = new clsDB(staticVariables.dbPath);
            

            clsCreateXML objXML = new clsCreateXML();
            objXML.Month = Month;
            objXML.Year = Year;

            objXML.createXML("Month");
            CreateFO("Month");

            clsSaveReports objSave = new clsSaveReports();

            string strFile = objSave.saveFile("pinnacleMonthlyReviewCosts.pdf","Month",CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Month),Year);
            Files.Add(strFile);

            // Create Qtr report if the Month/3 has no remainder (% = mod function) 
            if (Month % 3 == 0)
            {
                objXML.Qtr = Month / 3;
                objXML.createXML("Qtr");
                CreateFO("Qtr");
                string Qtr = objXML.returnOrdinal(Month/3);
                strFile = objSave.saveFile("pinnacleQtrReviewCosts.pdf","Qtr",Qtr+"Qtr",Year);
                Files.Add(strFile);
            }

 //           clsEmail objEmail = new clsEmail();
//            objEmail.mailReport(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Month) + " " + Year, Files);
        }

        private bool CreateFO(string strType)
        {
            System.Diagnostics.Process objProcess = new System.Diagnostics.Process();

            setProcessProperties(strType, ref objProcess);

            objProcess.Start();

            //sleeping the code, until the process completes. If it takes more than 7 seconds I will produce an error.
            int intSleep = 0;
            bool blProcess = false;
            while (objProcess.HasExited == false)
            {
                System.Threading.Thread.Sleep(500);
                if (intSleep == 14)
                {
                    // raise an error, and place in messagebox
                    //                    RelayStatus("Error - the pdf could not be created. Please contact tech support");
                    blProcess = true;
                    break;
                }
                intSleep++;
            }
            objProcess.Close();
            return blProcess;
        }

        // setting fop's working directory based on the hostname. setting arguments based on type. Avoids comment/uncomment upon each compile.
        private void setProcessProperties(string strType, ref System.Diagnostics.Process objProcess)
        {
            IPHostEntry objHost;

            objHost = Dns.GetHostEntry(Dns.GetHostName());
            string strArguments;
            
            string strHost = objHost.HostName.ToLower();
            if (strHost.IndexOf("iomega-nas") < 0)
            {
                objProcess.StartInfo.WorkingDirectory = staticVariables.fopDirectory_Test;
                strArguments = @"-xml %Temp%\PinnacleMonthlyCosts.xml -xsl " + staticVariables.xslDirectory_Test + @" -pdf %Temp%\pinnacleMonthlyReviewCosts.pdf";
            }
            else
            {
                objProcess.StartInfo.WorkingDirectory = staticVariables.fopDirectory;
                strArguments = @"-xml %Temp%\PinnacleMonthlyCosts.xml -xsl " + staticVariables.xslDirectory + @" -pdf %Temp%\pinnacleMonthlyReviewCosts.pdf";
            }

            if (strType == "Qtr")
                strArguments = strArguments.Replace("Monthly", "Qtr");


            objProcess.StartInfo.FileName = "fop.bat";
            objProcess.StartInfo.Arguments = strArguments;
            objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        }

        private string returnYear(string strMonth)
        {
            string strYear;

            if (strMonth != "12")
            {
                strYear = System.DateTime.Now.Year.ToString();
            }
            else
            {
                int intYear = System.DateTime.Now.Year - 1;
                strYear = intYear.ToString();
            }

            return strYear;
        }

        private int returnMonth(string strMonth)
        {
            int intMonth = Convert.ToInt16(strMonth) - 1;
            if (intMonth == 0) // 
                intMonth = 12;

            return intMonth;
        }
    }
}
