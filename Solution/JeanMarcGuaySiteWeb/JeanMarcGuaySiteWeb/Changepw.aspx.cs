using BusinessLogic;
using BusinessLogic.Autres;
using BusinessLogic.Factories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JeanMarcGuaySiteWeb
{
    public partial class Changepw : System.Web.UI.Page
    {
        private string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //redirect si pas connecté
            if (Session["User"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            //Check si les truc du form sont valide

            //Affiche page de confirmation

            //Send email de confirmation

            if (!string.IsNullOrEmpty(txtNewPassword.Text) && !string.IsNullOrEmpty(txtOldPassword.Text) && !string.IsNullOrEmpty(txtConfirm.Text))
            {
                if(txtNewPassword.Text != txtConfirm.Text)
                {
                    notification.Visible = true;
                    notification.Style.Add("color", "red");
                    notification.InnerText = "Le nouveau mot de passe et le mot de passe dans la boite de confirmation doivent être identique";
                }
                else
                {
                    UserFactory uf = new UserFactory(cnnStr);

                    //if le mot de passe en haut est le bon

                    //if les 2 mdp sont pareil 
                    User curr = (User)Session["User"];

                    User user = uf.Connexion(curr.email, txtOldPassword.Text);

                    if (user == null)
                    {
                        //Email ou mot de passe incorrect
                        txtOldPassword.Text = "";
                        txtNewPassword.Text = "";
                        txtConfirm.Text = "";
                        notification.Style.Add("color", "red");
                        notification.InnerText = "Mot de passe incorrecte";
                        notification.Visible = true;
                    }
                    else
                    {
                        txtOldPassword.Text = "";
                        txtNewPassword.Text = "";
                        txtConfirm.Text = "";

                        //envoi du email de confirmation
                        EmailController ec = new EmailController();
                        string body = string.Empty;
                        using (StreamReader reader = new StreamReader(Server.MapPath("~/Email/ConfirmationPassword.html")))
                        {
                            body = reader.ReadToEnd();
                        }

                        string strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
                        string strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
                        string lienActivation = strUrl + "ConfirmationChangement.aspx" + "?email=" + curr.email + "&tkn=" + curr.token;

                        body = body.Replace("{email}", user.email);
                        body = body.Replace("{lienActivation}", lienActivation);
                        ec.SendMail(user.email, "Changement de mot de passe", body);


                        notification.Style.Add("color", "red");
                        notification.InnerText = "Un courriel de confirmation a été envoyé dans votre boite de courriel.";
                    }
                }
            }
            else
            {
                notification.Visible = true;
                notification.Style.Add("color", "red");
                notification.InnerText = "Veuillez remplir tous les champs";
            }
        }
    }
}