using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace frmPinnacle
{
    class clsFormat
    {
        public string formatZip(string strZip)
        {
            strZip = strZip.Trim();
            if (strZip.Length == 1)
                strZip = "null";
            else if (strZip.Substring(strZip.Length - 1, 1) == "-")
                strZip = strZip.Substring(0, 5);

            return strZip;
        }

        public string formatDate(string strDate)
        {
            if (strDate != @"  /  /")
            {
                if (validateDate(strDate) == true)
                {
                    DateTime dtDate = Convert.ToDateTime(strDate);
                    strDate = "'" + dtDate.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    strDate = "null";
                }

            }
            else
                strDate = "null";

            return strDate;
        }

        private bool validateDate(string strDate)
        {
            try
            {
                DateTime dtDate = DateTime.Parse(strDate);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string removeApostrophe(string strData)
        {
            strData = strData.Replace("'", "''");
            return strData;
        }


        public string convertTime_12hr(DateTime Time)
        {
            string strTime = Time.ToShortTimeString();
            return strTime;
        }

        public string convertTime_12hr(TimeSpan Time)
        {
            string strTime = Time.ToString("hh\\:mm");
            strTime = DateTime.ParseExact(strTime, "HH:mm", null).ToString("hh:mm tt", CultureInfo.GetCultureInfo("en-US"));
            return strTime;
        }

        public string convertTime_24hr(DateTime Time)
        {
            string strTime = Time.ToString("HH\\:mm");

            return strTime;
        }

       
    }
}
