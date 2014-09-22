using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace HiTechnic
{
    class clsEmail
    {

        public string sendEndOfDay(string strTo, string strFrom, string strSubject)
        {
            try
            {
                MailAddress SendFrom = new MailAddress(strFrom);
                MailAddress SendTo = new MailAddress(HiTecResources.HiTec_Email);
                MailAddress CC = new MailAddress(HiTecResources.HTC_EndOfDay);
                MailAddress Developer = new MailAddress("jeremyp@htcorp.net");

                MailMessage objMessage = new MailMessage(SendFrom,SendTo);

                objMessage.CC.Add(CC);
                objMessage.CC.Add(Developer);
                objMessage.Subject = strSubject;
                objMessage.Body = "Please see attatchment";

                SmtpClient email = new SmtpClient("webmail.htcorp.net");
                
                email.UseDefaultCredentials = true;
                bool blAttachments = attatchFiles(ref objMessage);
                if (blAttachments == true)
                {
                    email.Send(objMessage);
                    return "Mail Sent Successfully";
                }
                else
                {
                    return "Mail was not sent, there were no files produced today. Did you run end of Day?";
                }
            }
            catch(Exception e)
            {
                return "Mail Failure"; 
            }

        }

        private bool attatchFiles(ref MailMessage objMail)
        {
            attachFile(ref objMail, HiTecResources.FedExGround);
            attachFile(ref objMail, HiTecResources.FedExExpress);
            attachFile(ref objMail, HiTecResources.USPS_XLS);

            if (objMail.Attachments.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void attachFile(ref MailMessage objMail,string strPath)
        {
            DateTime createTime = File.GetLastWriteTime(strPath);

            if (createTime.Date.ToShortDateString() == System.DateTime.Now.Date.ToShortDateString())
            {
                Attachment objFile = new Attachment(strPath);
                objMail.Attachments.Add(objFile);
            }
        }

        public void sendErrors(System.Collections.ArrayList objErrors)
        {
            string strMessage="";
            string[] strErrors = (string[])objErrors.ToArray(typeof(string));

            strMessage = string.Join(Environment.NewLine,strErrors);

            MailMessage objMail = new MailMessage(HiTecResources.HTC_Email, HiTecResources.HiTec_Email);
            objMail.Subject = "Could not verify the address for the following orders";
            objMail.Body = strMessage;

            SmtpClient email = new SmtpClient("webmail.htcorp.net");

            email.UseDefaultCredentials = true;
            email.Send(objMail);
        }
    }
}
