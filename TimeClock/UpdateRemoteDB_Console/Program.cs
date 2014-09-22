using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UpdateRemoteDB_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            objDatabase_URDB clsDB = new objDatabase_URDB();

            try
            {
                clsDB.UpdateDB("htcCloudDB.net");
                if (clsDB.Error == "")
                    Console.WriteLine("Success - all rows were updated");
                else
                    Console.WriteLine(clsDB.Error.ToString());
            }
            catch (System.Exception e)
            {
                clsLog objLog = new clsLog();
                objLog.writeToLog(e.Message);
            }
        }
    }
}
