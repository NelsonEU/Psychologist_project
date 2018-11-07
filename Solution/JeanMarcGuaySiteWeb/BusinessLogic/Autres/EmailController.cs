using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.IO;
using System.Reflection;

namespace BusinessLogic.Autres
{
    public class EmailController
    {


        string WebsiteEmail { get; set; }
        string WebsiteEmailPassword { get; set; }

        public void SendMail(string email, string subject, string body)
        {

            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress("cabinet.jmguay@gmail.com");
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Credentials = new System.Net.NetworkCredential("cabinet.jmguay@gmail.com", "jmguay&2018");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(mail);

        }



    }
}
