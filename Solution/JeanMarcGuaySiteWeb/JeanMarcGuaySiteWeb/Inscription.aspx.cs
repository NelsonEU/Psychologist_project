using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Factories;
using System.Configuration;
using BusinessLogic;

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

                if(user != null) {
                    notification.InnerText = "Un compte existe déjà pour cette adresse e-mail";
                }
                else
                {
                    uf.Add(lastname.Text, firstname.Text, email.Text, password.Text, false, false);
                    notification.InnerText = "Compte crée !";
                    notification.Visible = true;
                }
            }
        }
    }
}