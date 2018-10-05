using System;
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

namespace JeanMarcGuaySiteWeb
{
    public partial class Inscription : System.Web.UI.Page
    {
        private string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            notification.Visible = false;
        }

        protected void Submit_click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(email.Text) && !string.IsNullOrEmpty(password.Text) && !string.IsNullOrEmpty(passwordConfirmation.Text)
                && !string.IsNullOrEmpty(firstname.Text) && !string.IsNullOrEmpty(lastname.Text))
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
                    System.Text.RegularExpressions.Regex regexDate = new Regex(@"^\d{2}/\d{2}/\d{4}$");
                    if (!regexDate.IsMatch(birthday.Text))
                    {
                        notification.Style.Add("color", "red");
                        notification.InnerText = "La date de naissance doit correspondre à jj/mm/aaaa";
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
                        DateTime birthdayDate = Convert.ToDateTime(birthday.Text);
                        uf.Add(lastname.Text, firstname.Text, email.Text, password.Text, false, subscriber.Checked, false, birthdayDate);
                        notification.Style.Add("color", "green");
                        notification.InnerText = "Bienvenue ! Un e-mail vous a été envoyé afin de confirmer votre inscription";
                        notification.Visible = true;
                        EmailController ec = new EmailController();
                        ec.SendActivationMail(email.Text);

                    }
                }
            }
        }
    }
}