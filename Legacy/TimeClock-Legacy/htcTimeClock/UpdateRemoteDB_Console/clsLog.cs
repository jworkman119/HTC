using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace UpdateRemoteDB_Console
{
    class clsLog
    {
        public void writeToLog(string content)
        {
            //set up a filestream
            string logPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\HTC\\StateFair\\htcStateFairError.Log";
            FileStream fs = new FileStream(logPath, FileMode.OpenOrCreate, FileAccess.Write);

            //set up a streamwriter for adding text
            StreamWriter sw = new StreamWriter(fs);

            //find the end of the underlying filestream
            sw.BaseStream.Seek(0, SeekOrigin.End);

            //add the text
            sw.WriteLine(content);
            //add the text to the underlying filestream

            sw.Flush();
            //close the writer
            sw.Close();
        }
    }
}
