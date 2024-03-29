﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Factories;
using BusinessLogic.Autres;
using System.Configuration;
using BusinessLogic;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;

namespace JeanMarcGuaySiteWeb
{
    public partial class Inscription : System.Web.UI.Page
    {
        private string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        private bool verifNotification = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            notification.Visible = false;

            // -----------Vérification le l'état des modules ----------- //
            ModuleFactory moduleFactory = new ModuleFactory(cnnStr);
            Module m = moduleFactory.Get((int)Module.AllModules.Publications);
            if (m.active == true)
            {
                m = moduleFactory.Get((int)Module.AllModules.Subscription);
                if (m.active == true)
                {
                    subscriber.Visible = true;
                    lblSubscriber.Visible = true;
                    verifNotification = true;
                }
                else
                {
                    subscriber.Visible = false;
                    lblSubscriber.Visible = false;
                    verifNotification = false;
                }
            }
            else
            {
                subscriber.Visible = false;
                lblSubscriber.Visible = false;
                verifNotification = false;
            }

            
            // ------------------------------------------------------- //

        }

        protected void Submit_click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(email.Text) && !string.IsNullOrEmpty(password.Text) && !string.IsNullOrEmpty(passwordConfirmation.Text)
                && !string.IsNullOrEmpty(firstname.Text) && !string.IsNullOrEmpty(lastname.Text))
            {
                if (email.Text.Length > 50 || lastname.Text.Length > 40 || firstname.Text.Length > 40 || password.Text.Length > 40 || passwordConfirmation.Text.Length > 40)
                {
                    notification.Style.Add("color", "red");
                    notification.InnerText = "Les données sont trop longues";
                    notification.Visible = true;
                }
                else
                {
                    UserFactory uf = new UserFactory(cnnStr);
                    User user = uf.GetByEmail(email.Text);

                    if (user != null)
                    {
                        notification.Style.Add("color", "red");
                        notification.InnerText = "Un compte existe déjà pour cette adresse e-mail";
                        notification.Visible = true;
                    }
                    else
                    {
                        System.Text.RegularExpressions.Regex regexDate = new Regex(@"^\d{2}-\d{2}-\d{4}$");
                        System.Diagnostics.Debug.WriteLine(birthday.Text);
                        if (!regexDate.IsMatch(birthday.Text))
                        {
                            notification.Style.Add("color", "red");
                            notification.InnerText = "La date de naissance doit correspondre à jj-mm-aaaa";
                            notification.Visible = true;
                        }
                        else if (password.Text.Length < 6)
                        {
                            notification.Style.Add("color", "red");
                            notification.InnerText = "Le mot de passe doit contenir au moins 6 caractères";
                            notification.Visible = true;
                        }
                        else if (password.Text != passwordConfirmation.Text)
                        {
                            notification.Style.Add("color", "red");
                            notification.InnerText = "Les deux mots de passe doivent être identiques";
                            notification.Visible = true;
                        }
                        else
                        {
                            bool sub;
                            if (verifNotification == true)
                            {
                                sub = subscriber.Checked;
                            }
                            else
                            {
                                sub = false;
                            }
                            DateTime birthdayDate = Convert.ToDateTime(DateTime.ParseExact(birthday.Text,"dd-MM-yyyy", CultureInfo.InvariantCulture));
                            string token = rndToken(40);
                            uf.Add(lastname.Text, firstname.Text, email.Text, password.Text, false, sub, false, birthdayDate, token);
                            notification.Style.Add("color", "green");
                            notification.InnerText = "Bienvenue ! Un e-mail vous a été envoyé afin de confirmer votre inscription";
                            notification.Visible = true;
                            EmailController ec = new EmailController();
                            string body = string.Empty;
                            using (StreamReader reader = new StreamReader(Server.MapPath("~/Email/ActivationEmail.html")))
                            {
                                body = reader.ReadToEnd();
                            }
                            string strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
                            string strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
                            string lienActivation = strUrl + "Activation.aspx" + "?email=" + email.Text + "&tkn=" + token;

                            body = body.Replace("{lienActivation}", lienActivation);
                            ec.SendMail(email.Text, "Bienvenue !", body);

                        }
                    }
                }
            }
        }

        protected static string rndToken(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();
        }

    }
}