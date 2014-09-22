using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace consoleMailLogFile
{
    class clsEmail
    {

        public void MailBill()
        {
            clsLog objLog = new clsLog();

            try
            {
                MailAddress SendFrom = new MailAddress(staticSettings.From);
                MailAddress SendTo = new MailAddress(staticSettings.To);
                

                MailMessage objMessage = new MailMessage(SendFrom, SendTo);

                Attachment objFile = new Attachment(staticSettings.FilePath);
                objMessage.Attachments.Add(objFile);

               
                objMessage.Subject = "htc State Fire Time Clock Log";
                objMessage.Body = "attached - Log file from state fair.";

                SmtpClient email = new SmtpClient(staticSettings.gmailSMTP,587);
                email.UseDefaultCredentials = false;
                NetworkCredential Credential = new NetworkCredential(staticSettings.UserName,staticSettings.pwd);
                email.Credentials = Credential;
                email.DeliveryMethod = SmtpDeliveryMethod.Network;
                email.EnableSsl = true;

                email.Send(objMessage);
                email.Dispose();
                objFile.Dispose();
                
                File.Delete(staticSettings.FilePath);

                objLog.writeToLog(System.DateTime.Now.ToString("MM-dd-yyyy HH:mm") + "consoleMailLogFile - Success");
            }
            catch (Exception e)
            {
                objLog.writeToLog(System.DateTime.Now.ToString("MM-dd-yyyy HH:mm") + "consoleMailLogFile - Mail Failure - " + e.Message);
            }

        }

       
    }
}
