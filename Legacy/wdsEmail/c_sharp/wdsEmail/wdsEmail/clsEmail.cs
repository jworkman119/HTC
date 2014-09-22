using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;


namespace wdsEmail
{
    class clsEmail
    {
        public void sendMail()
        {


            MailAddress SendFrom = new MailAddress("htcadmin@htcorp.net");
            MailAddress SendTo = new MailAddress("mikek@htcorp.net");
            MailAddress CC = new MailAddress("chrisj@htcorp.net");

            MailMessage objMessage = new MailMessage(SendFrom, SendTo);



            objMessage.CC.Add(CC);
            objMessage.Subject = "WDS_Connect Down - Exchange 2";
            string strTime = System.DateTime.Now.ToString();
            objMessage.Body = strTime + " - WDS_Connect has gone down twice, restart the service.";

            SmtpClient email = new SmtpClient("webmail.htcorp.net");
            email.UseDefaultCredentials = false;
            NetworkCredential Credential = new NetworkCredential("htcadmin", "goldstar");
            email.Credentials = Credential;
            //email.UseDefaultCredentials = true;

            email.Send(objMessage);
        }
    }
}
