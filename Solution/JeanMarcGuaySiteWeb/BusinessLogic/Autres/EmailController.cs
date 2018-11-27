using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.IO;
using System.Reflection;
using System.Configuration;

namespace BusinessLogic.Autres
{
    public class EmailController
    {

        static string SmtpHost = ConfigurationManager.AppSettings["SmtpHost"];
        static string emailAddress = ConfigurationManager.AppSettings["emailAddress"];
        static string password = ConfigurationManager.AppSettings["password"];
        static int SmtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);

        public void SendMail(string email, string subject, string body)
        {

            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(emailAddress);
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = SmtpHost;
            smtp.Credentials = new System.Net.NetworkCredential(emailAddress, password);
            smtp.Port = SmtpPort;
            smtp.EnableSsl = true;
            smtp.Send(mail);

        }



    }
}
