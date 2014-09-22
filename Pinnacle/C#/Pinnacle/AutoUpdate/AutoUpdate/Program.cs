using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           


namespace AutoUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            
            clsVersion objVersion = new clsVersion();
            clsProcess objProcess = new clsProcess();

            bool blMatch = objVersion.checkVersions();
                        
            if (blMatch == true)
            {
                objProcess.startLocal();              
            }
            else
            {
                string strSuccess = objProcess.Install();
                if (strSuccess.Substring(0, 7) == "Success")
                {
                    objVersion.writeVersion();
                    objProcess.startLocal();
                }
                    
            }

        }

       
    }
}
