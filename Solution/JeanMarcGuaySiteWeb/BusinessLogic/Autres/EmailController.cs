﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace BusinessLogic.Autres
{
    public class EmailController
    {


        string WebsiteEmail { get; set; } // Mettre dans le fichier de config ?
        string WebsiteEmailPassword { get; set; }

        public void SendMail(string email, string subject, string body)
        {

            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(WebsiteEmail);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Credentials = new System.Net.NetworkCredential(WebsiteEmail, WebsiteEmailPassword);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(mail);

        }

        public void SendActivationMail(string email)
        {
            string subject = "Bienvenue !";
            string body = "blabla";
            SendMail(email, subject, body);
        }



    }
}
