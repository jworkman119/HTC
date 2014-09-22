using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace emailTotalHours
{
    class clsSaveReports
    {
        public string saveFile(string strFile, string Type, string TimePeriod, string Year)
        {
            string strDir = staticVariables.reportsDirectory + "\\" + Year;
            bool blExists = Directory.Exists(strDir);

            if (blExists == false)
            {
                Directory.CreateDirectory(strDir);
                Directory.CreateDirectory(strDir + "\\Month");
                Directory.CreateDirectory(strDir + "\\Qtr");
            }

            string strPath;
            string strTempFile = System.IO.Path.GetTempPath() + strFile;
            if(Type =="Month")
            {
                strPath = strDir + "\\Month\\" + TimePeriod + "_" + Year + ".pdf";
                if (File.Exists(strPath) == true)
                    File.Delete(strPath);

                File.Move(strTempFile, strPath);
            }
            else
            {
                strPath = strDir + "\\Qtr\\" + TimePeriod + "_" + Year + ".pdf";
                if (File.Exists(strPath) == true)
                    File.Delete(strPath);

                File.Move(strTempFile, strPath);
            }

            return strPath;
        }

    }
}
