using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Timers;

namespace updateRemoteDB
{
    public partial class serviceUpdateDB : ServiceBase
    {
        Timer objTimer = new Timer();

        public serviceUpdateDB()
        {
            InitializeComponent();
            this.ServiceName = "htcUpdateMySQL";
            this.EventLog.Log = "Application";

            // These Flags set whether or not to handle that specific
            //  type of event. Set to true if you need it, false otherwise.
            this.CanHandlePowerEvent = true;
            this.CanHandleSessionChangeEvent = true;
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.CanStop = true;

        }

        protected override void OnStart(string[] args)
        {
          //add this line to text file during start of service
            TraceService(System.DateTime.Now.ToString("MM-dd-yyyy HH:mm") + " - Starting service");

            //handle Elapsed event
            objTimer.Elapsed += new ElapsedEventHandler(OnElapsedTime);

            //This statement is used to set interval to 1 minute (= 60,000 milliseconds)
            objTimer.Interval = 60000;

            //enabling the timer
            objTimer.Enabled = true;
        }

        protected override void OnStop()
        {
            objTimer.Enabled = false;
            TraceService(System.DateTime.Now.ToString("MM-dd-yyyy HH:mm") + " - The service has stopped.");
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            int Hour = Convert.ToInt16(DateTime.Now.Hour);
            int Minute = Convert.ToInt16(DateTime.Now.Minute);
            if (Hour == 6 | Hour == 13 | Hour == 21 && Minute == 15)
            {
                // mail the file
                runConsoleProgram(@"C:\Program Files\HTC\TimeClock\consoleMailLogFile.exe");
                // checking to see if any new people have been added to database.
                runConsoleProgram(@"C:\Program Files\HTC\TimeClock\consoleUpdatePerson.exe");
            }
            else
            {
                runConsoleProgram(@"C:\Program Files\HTC\TimeClock\consoleUpdateRemoteDB.exe");
                
                TraceService("Service running console application at " + DateTime.Now);
            }

        }


        //writes to TimeClock.log
        private void TraceService(string content)
        {
            //set up a filestream
            FileStream fs = new FileStream(@"C:\Program Files\HTC\TimeClock\TimeClock.log", FileMode.OpenOrCreate, FileAccess.Write);

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

        private void runConsoleProgram(string strFile)
        {

            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = @strFile;
                process.StartInfo = startInfo;
                process.Start();
            }
            catch(Exception e)
            {
                TraceService(System.DateTime.Now.ToString("MM-dd-yyyy HH:mm") + " - Error - serviceUpdateDB - runConsoleUpdateRemoteDB - " + e.Message.ToString());
            }

        }

   
    }
 
}
