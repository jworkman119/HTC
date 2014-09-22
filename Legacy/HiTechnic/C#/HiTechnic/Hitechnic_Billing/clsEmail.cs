using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;


namespace Hitechnic_Billing
{
    class clsEmail
    {
        public string MailBill(string strMonthYear,string FilePath)
        {
            try
            {
                MailAddress SendFrom = new MailAddress(HiTecBilling.EmailFrom);
                MailAddress SendTo = new MailAddress(HiTecBilling.FinanceEmail);
                MailAddress CC = new MailAddress(HiTecBilling.IT_Email);

                MailMessage objMessage = new MailMessage(SendFrom, SendTo);

                Attachment objFile = new Attachment(FilePath);
                objMessage.Attachments.Add(objFile);

                objMessage.CC.Add(CC);
                objMessage.Subject = "HiTechnic Bill - " + strMonthYear;
                objMessage.Body = "HiTechnic Bill see attatched";

                SmtpClient email = new SmtpClient("webmail.htcorp.net");
                email.UseDefaultCredentials = false;
                NetworkCredential Credential = new NetworkCredential("UPSPC", "Renfro57");
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
