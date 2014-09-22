using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Xml;

namespace AutoUpdate
{
    class clsProcess
    {
        public void startLocal()
        {
            // Todo - place static data in res file - LocalPath, LocalProcess
            runProcess(staticValues.LocalPath, staticValues.LocalProcess,"");
        }                                                                                                                                                                                                                                                                            

        public string Install()
        {
            string strArguments;
            string strSuccess="Success";

            bool blExists = File.Exists(staticValues.LocalPath + "\\" + staticValues.LocalProcess);
            if (blExists == true)
            {
                string Guid = returnGuid();
                strArguments = " /x " + Guid + " /qn";
                strSuccess = runProcess(staticValues.LocalPath, "msiexec", strArguments);
            }

            strArguments = " /i " + staticValues.NetworkPath + " /qn";
            if(strSuccess.Substring(0,5)!="Error")
                strSuccess = runProcess(staticValues.NetworkPath, "msiexec" , strArguments);

            return strSuccess;
        }

        private string returnGuid()
        {
            string strValue = "";
            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            strPath = strPath + "\\HTC\\Pinnacle\\Version.xml";

            XmlReader xmlReader = XmlReader.Create(strPath);
            while (xmlReader.Read())
            {
                string strName = xmlReader.GetAttribute("Name");
                if (strName == "Pinnacle")
                    strValue = xmlReader.GetAttribute("Guid");
            }

            xmlReader.Close();
            return strValue;
        }

        private string runProcess(string strDirectory, string strProcess, string strArguments)
        {
            Process objProcess = new Process();
            string Status = "Success";
            objProcess.StartInfo.WorkingDirectory = strDirectory;
            if (strArguments != "")
                objProcess.StartInfo.Arguments = strArguments;
            
            objProcess.StartInfo.FileName = strProcess;
            objProcess.Start();

            //sleeping the code, until the process completes. If it takes more than 7 seconds I will produce an error.
            int intSleep = 0;
            bool blProcess = false;

            while (objProcess.HasExited == false)
            {
                System.Threading.Thread.Sleep(500);
                if (intSleep == 20)
                {
                    // raise an error, and place in messagebox
                    Status = "Error - the application did not install correctly. Please contact tech support";
                    blProcess = true;
                    break;
                }
                intSleep++;
            }
            objProcess.Close();
            return Status;
        }
    }
}
