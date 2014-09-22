using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace consoleMailLogFile
{
    class Program
    {
        static void Main(string[] args)
        {
            clsEmail objMail = new clsEmail();

            objMail.MailBill();
              
        }
    }
}
