using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace htcHealthCenter_TPDates
{
    class clsFormat
    {
        public string formatDate(string strDate)
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

        public string formatMonth(int intMonth)
        {
            string strMonth = "";
            if (intMonth < 10)
                strMonth = "0" + intMonth.ToString();
            else
                strMonth = intMonth.ToString();

            return strMonth;
        }

    }
}
