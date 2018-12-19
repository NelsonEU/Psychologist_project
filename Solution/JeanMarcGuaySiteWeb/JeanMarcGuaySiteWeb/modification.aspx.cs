using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessLogic.Factories;
using System.Configuration;
using System.Globalization;
using System.IO;
using BusinessLogic.Autres;

namespace JeanMarcGuaySiteWeb
{
    public partial class modification : System.Web.UI.Page
    {
        private static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        UserFactory uf = new UserFactory(cnnStr);
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                user = (User)Session["User"];
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

            //Remplir les champs avec les anciennes infos
            if (!Page.IsPostBack)
            {
                txtFirstname.Text = user.firstname;
                txtLastname.Text = user.lastname;
                txtEmail.Text = user.email;
                birthday.Text = user.birthday.ToString("dd-MM-yyyy");
                if (user.subscriber)
                {
                    chkSubscription.Checked = true;
                }
                else
                {
                    chkSubscription.Checked = false;
                }
            }

            // -----------Vérification le l'état des modules ----------- //
            ModuleFactory moduleFactory = new ModuleFactory(cnnStr);
            Module m = moduleFactory.Get((int)Module.AllModules.Publications);
            if (m.active == true)
            {
                m = moduleFactory.Get((int)Module.AllModules.Subscription);
                if (m.active == true)
                {
                    chkSubscription.Visible = true;
                }
                else
                {
                    chkSubscription.Visible = false;
                }
            }
            else
            {
                chkSubscription.Visible = false;
            }
            // ------------------------------------------------------- //

            if (Request.QueryString["Conf"] != null)
            {
                if (Request.QueryString["Conf"] == "True")
                {
                    StatusLabel.Style.Add("color", "green");
                    StatusLabel.Text = "La demande de suppression à été envoyée.";
                }
            }

        }

        protected void btnConfirmer_Click(object sender, EventArgs e)
        {
            DateTime birthdayDate = Convert.ToDateTime(DateTime.ParseExact(birthday.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture));
            uf.Update(user.userId, txtLastname.Text, txtFirstname.Text, txtEmail.Text, birthdayDate, chkSubscription.Checked);
            user.lastname = txtLastname.Text;
            user.firstname = txtFirstname.Text;
            user.email = txtEmail.Text;
            user.birthday = birthdayDate;
            user.subscriber = chkSubscription.Checked;
            Session["User"] = user;
            Response.Redirect("ConfirmationChangement.aspx?User="+user.userId.ToString());
        }

        protected void btnMDP_Click(object sender, EventArgs e)
        {
            Response.Redirect("Changepw.aspx");
        }

        protected void bntSuppr_Click(object sender, EventArgs e)
        {
            //Envoyer email de confirmation
            EmailController ec = new EmailController();
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Email/DemandeSuppression.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{emailU}", user.email);
            body = body.Replace("{firstname}", user.firstname);
            body = body.Replace("{lastname}", user.lastname);
            body = body.Replace("{dateC}", DateTime.Now.ToString());
            body = body.Replace("{dateE}", DateTime.Now.ToString("f", CultureInfo.CreateSpecificCulture("fr-FR")));
            ec.SendMail(ConfigurationManager.AppSettings["emailAddress"], "Demande de supression definitive d'un utilisateur", body);

            Response.Redirect("modification.aspx?Conf=True");

        }
    }
}