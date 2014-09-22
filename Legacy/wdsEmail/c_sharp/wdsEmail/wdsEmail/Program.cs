using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace wdsEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            clsEmail objEmail = new clsEmail();
            objEmail.sendMail();
        }
    }
}
