using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Hitechnic_Billing
{
    class clsLogFile
    {

        public void CreateLogFile(string strMessage)
        {
            StreamWriter Log;

            string LogPath = Path.GetTempPath() + "//HiTec_Billing-LogFile.log";

            if (!File.Exists(LogPath))
            {
                Log = new StreamWriter(LogPath);
            }
            else
            {
                Log = File.AppendText(LogPath);
            }


            // Write to the file:
            Log.WriteLine(DateTime.Now);
            Log.WriteLine(strMessage);
            Log.WriteLine();

            // Close the stream:
            Log.Close();
        }
    }
}
