using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Factories;
using BusinessLogic;

namespace JeanMarcGuaySiteWeb
{
    public partial class Connexion : System.Web.UI.Page
    {

        private string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] != null)
            {
                Response.Redirect("default.aspx");
            }
        }

        protected void Submit_click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(email.Text) && !string.IsNullOrEmpty(password.Text))
            {
                UserFactory uf = new UserFactory(cnnStr);
                User user = uf.Connexion(email.Text, password.Text);
                
                if(user == null)
                {
                    //Email ou mot de passe incorrect
                    notification.Visible = true;
                    notification.InnerText = "Adresse e-mail ou mot de passe incorrect";
                }
                else
                {
                    //Connecté
                    notification.Visible = true;
                    notification.InnerText = "Connexion réussie";
                    Response.Redirect("default.aspx");
                }
            }
            else{
                //Manque une info
                notification.Visible = true;
                notification.InnerText = "Veuillez remplir les deux champs";

            }
        }
            
    }  
}