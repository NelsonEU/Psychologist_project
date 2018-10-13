﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Factories;
using BusinessLogic.Autres;
using BusinessLogic;

namespace JeanMarcGuaySiteWeb
{
    public partial class Connexion : System.Web.UI.Page
    {

        private string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Session.Remove("User"); //Déconnexion
                Response.Redirect("default.aspx");
            }
        }

        protected void Submit_click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(email.Text) && !string.IsNullOrEmpty(password.Text))
            {
                UserFactory uf = new UserFactory(cnnStr);
                User user = uf.Connexion(email.Text, password.Text);

                if (user == null)
                {
                    //Email ou mot de passe incorrect
                    notification.Style.Add("color", "red");
                    notification.InnerText = "Adresse e-mail ou mot de passe incorrect";
                    notification.Visible = true;
                }
                else
                {
                    //User existe
                    if (user.activated == false)
                    {
                        //Compte pas activé
                        notification.Style.Add("color", "red");
                        notification.InnerText = "Votre compte n'est pas activé. Un e-mail de confirmation vous a été renvoyé.";
                        notification.Visible = true;
                        EmailController ec = new EmailController();
                        // ec.SendActivationMail(email.Text);
                    }
                    else
                    {
                        //Compte activé
                        //notification.InnerText = "Connexion réussie";
                        //notification.Visible = true;
                        Session["User"] = user;
                        Response.Redirect("Default.aspx"); //Renvois à la page d'ou il arrive
                    }
                }
            }
            else
            {
                //Manque une info
                notification.Visible = true;
                notification.InnerText = "Veuillez remplir tous les champs";

            }
        }

    }
}