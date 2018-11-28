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
using System.Text.RegularExpressions;

namespace JeanMarcGuaySiteWeb
{
    public partial class Contact : System.Web.UI.Page
    {

        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        static string emailAddress = ConfigurationManager.AppSettings["emailAddress"];
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
                divConnexion.Visible = false;
                divContact.Visible = true;
            }
            else
            {
                divConnexion.Visible = true;
                divContact.Visible = false;
                //Response.Redirect("Connexion.aspx");
            }
            // ------------------------------------------------------- //

        }

        protected void buttonSubmitClick(object sender, EventArgs e)
        {
            string subject = txtSubject.Text;
            string content = txtContent.Text;
            
            if (content.Length > 500)
            {
                notification.Style.Add("color", "red");
                notification.InnerText = "Le nombre maximum de caractère à été atteint. Veuillez réduire la longueur de votre message.";
                return;
            }

            System.Text.RegularExpressions.Regex regex = new Regex(@"\w{26,}");
            if (regex.IsMatch(content))
            {
                notification.Style.Add("color", "red");
                notification.InnerText = "Le message actuel ne peux pas être envoyer. Veuillez vérifier votre message.";
                return;
            }

            if (!string.IsNullOrEmpty(subject) && !string.IsNullOrEmpty(content))
            {

                RequestFactory rf = new RequestFactory(cnnStr);
                int id = user.userId;

                // Ajout de la prise de contact dans la BD
                rf.Add(id, subject, content);

                // Envoi du Email a jmguay
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
                ec.SendMail(emailAddress, "Nouveau message de "+user.firstname + " " + user.lastname, body);           

                // Envoi du Email de confirmation d'envoi a l'utilisateur
                body = string.Empty;
                using (StreamReader reader2 = new StreamReader(Server.MapPath("~/Email/ConfirmationContact.html")))
                {
                    body = reader2.ReadToEnd();
                }
                string strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
                string strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
                string lienAccueil = strUrl + "Default.aspx";     

                body = body.Replace("{date}", DateTime.Now.ToString("dd-MM-yyyy"));
                body = body.Replace("{subject}", subject);
                body = body.Replace("{content}", content);
                body = body.Replace("{lienAccueil}", lienAccueil);
                body = body.Replace("{lien}", strUrl);
                body = body.Replace("{emailHost}", emailAddress);

                ec.SendMail(user.email, "JMGuay.ca - Confirmation de l'envoi du message [Message automatique]", body);

                // Redirection à une page de confirmation
                Response.Redirect("Confirmation.aspx?User=" + id);
            }

        }
    }
}