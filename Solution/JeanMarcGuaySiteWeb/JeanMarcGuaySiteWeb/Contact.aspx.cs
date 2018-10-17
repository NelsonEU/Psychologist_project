using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessLogic.Factories;
using BusinessLogic.Autres;
using System.Configuration;
using System.IO;

namespace JeanMarcGuaySiteWeb
{
    public partial class Contact : System.Web.UI.Page
    {

        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {

            // ----------- Vérification le l'état du module ----------- //
            ModuleFactory moduleFactory = new ModuleFactory(cnnStr);
            Module m = moduleFactory.Get(2);/* Module id 2 = Module de prises de contact */
            if (m.active == false)
            {
                Response.Redirect("Default.aspx");
            }
            // ------------------------------------------------------- //


            // ----------- Vérification de la connexion ----------- //
            if (Session["User"] != null)
            {
                user = (User)Session["User"];
            }
            else
            {
                Response.Redirect("Connexion.aspx");
            }
            // ------------------------------------------------------- //

        }

        protected void buttonSubmitClick(object sender, EventArgs e)
        {
            string subject = txtSubject.Text;
            string content = txtContent.Text;

            if (!string.IsNullOrEmpty(subject) && !string.IsNullOrEmpty(content))
            {

                RequestFactory rf = new RequestFactory(cnnStr);
                int id = user.userId;

                // Ajout de la prise de contact dans la BD
                rf.Add(id, subject, content);

                // Envoi du Email
                EmailController ec = new EmailController();
                string body = string.Empty;
                using (StreamReader reader = new StreamReader(Server.MapPath("~/Email/ContactEmail.html")))
                {
                    body = reader.ReadToEnd();
                }

                body = body.Replace("{firstname}", user.firstname);
                body = body.Replace("{lastname}", user.lastname);
                body = body.Replace("{date}", DateTime.Now.ToString("dd-MM-yyyy"));
                body = body.Replace("{email}", user.email);
                body = body.Replace("{subject}", subject);
                body = body.Replace("{content}", content);

                /* Changer ce email */
                ec.SendMail("flexonze@gmail.com", "Nouveau message de "+user.firstname + " " + user.lastname, body);

                // Redirection à une page de confirmation
                Response.Redirect("Confirmation.aspx?User=" + id);
            }

        }
    }
}