using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace consoleUpdateRemoteDB
{
    class Program
    {
        static void Main(string[] args)
        {
            clsPingTest objPing = new clsPingTest();
            clsLog objLog = new clsLog();

            bool blPass = objPing.PingTest("htcCloudServer.net");
            if (blPass == true)
            {
                clsActions objActions = new clsActions();
                objActions.updateDBs();
            }
            else
            {
                string strError = System.DateTime.Now.ToString("MM-dd-yyyy HH:mm") + "- clsPingTest- the cloud server could not be reached.";
                objLog.writeToLog(strError);
            }
        }

        
    }
}
