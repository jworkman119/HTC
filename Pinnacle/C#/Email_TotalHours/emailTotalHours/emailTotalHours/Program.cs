using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace emailTotalHours
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating Report
            clsCreateReport objReport = new clsCreateReport();
            objReport.CreateReport();
        }
    }
}
