using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace frmPinnacle
{
    class clsEmail
    {

        public string MailInfo(string Email, string ConsumerName)
        {
            try
            {
                MailAddress SendFrom = new MailAddress(resPinnacle.EmailFrom);
                MailAddress SendTo = new MailAddress(resPinnacle.EmailTo);
                

                MailMessage objMessage = new MailMessage(SendFrom, SendTo);

                objMessage.Subject = "New Job - " + ConsumerName;
                objMessage.Body = ConsumerName + " has changed jobs, please update job info";

                SmtpClient email = new SmtpClient("webmail.htcorp.net");
                email.UseDefaultCredentials = true;


                email.Send(objMessage);
                return "Mail Sent Successfully";

            }
            catch (Exception e)
            {
                return "Mail Failure - " + e.Message;
            }

        }
    }
}
