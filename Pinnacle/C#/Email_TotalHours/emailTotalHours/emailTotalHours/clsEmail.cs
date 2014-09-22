using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace emailTotalHours
{
    class clsEmail
    {
        public string mailReport(string strMonthYear, List<string> Files)
        {
            try
            {
                MailAddress SendFrom = new MailAddress(staticVariables.MailFrom);
                MailAddress SendTo = new MailAddress(staticVariables.MailTo);
                MailAddress CC = new MailAddress("jeremyp@htcorp.net");

                MailMessage objMessage = new MailMessage(SendFrom, SendTo);

                for (int j = 0; j < Files.Count; j++)
                {
                    Attachment objFile = new Attachment(Files[j]);
                    objMessage.Attachments.Add(objFile);
                }
                objMessage.CC.Add(CC);
                objMessage.Subject = "Oneida County Reports - " + strMonthYear;
                string strBody = "Monthly Report - \"" + Files[0].ToString() + "\"";
                if (Files.Count > 1)
                    strBody = strBody + System.Environment.NewLine + " Qtr Report - \"" + Files[1].ToString() + "\"";
                objMessage.Body = strBody;

                SmtpClient email = new SmtpClient("webmail.htcorp.net");
                email.UseDefaultCredentials = false;
                NetworkCredential Credential = new NetworkCredential("reports", "qw964a");
                email.Credentials = Credential;
                //email.UseDefaultCredentials = true;

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
