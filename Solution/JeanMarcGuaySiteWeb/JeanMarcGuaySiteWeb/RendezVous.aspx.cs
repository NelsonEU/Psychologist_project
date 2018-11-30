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
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;

namespace JeanMarcGuaySiteWeb
{
    public partial class RendezVous : System.Web.UI.Page
    {

        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        static string emailAddress = ConfigurationManager.AppSettings["emailAddress"];
        AvailabilityFactory af = new AvailabilityFactory(cnnStr);
        User user;
        string etat = "Contact";

        protected void Page_Load(object sender, EventArgs e)
        {
            divConnexion.Visible = false;

            // ----------- Vérification le l'état du module ----------- //
            ModuleFactory moduleFactory = new ModuleFactory(cnnStr);
            Module m = moduleFactory.Get((int)Module.AllModules.Appointment);/* Module id 1 = Module des prises de rendez-vous */
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
                divConnexion.Visible = true;
                divRendezVous.Visible = false;
                divRenseignement.Visible = false;
            }
            // ------------------------------------------------------- //

            // ----------- Vérification de l'autorisation ----------- //
            if (user != null)
            {
                if (user.authorized == true)
                {
                    divRendezVous.Visible = true;
                    divRenseignement.Visible = false;
                }
                else
                {
                    divRendezVous.Visible = false;
                    divRenseignement.Visible = true;

                    Module m2 = moduleFactory.Get((int)Module.AllModules.Contact);
                    if (m2.active == false)
                    {
                        etat = "Accueil";
                        btnRedirection.Text = "Retour à l'accueil";
                    }
                }
            }
            // ------------------------------------------------------- //

            //Rempissage des dropdowns
            if (!Page.IsPostBack)
            {
                Availability[] availabilities = af.GetAllFree();
                foreach (Availability availability in availabilities)
                {
                    //Dates
                    string dateToDisplay = availability.strdt.ToString("D", CultureInfo.CreateSpecificCulture("fr-FR"));
                    ddlDate.Items.Add(new ListItem(dateToDisplay, availability.availabilityId.ToString()));

                    //Heures
                    //string timeToDisplay = availability.strdt.ToString("t", CultureInfo.CreateSpecificCulture("fr-FR"));
                    //ddlHeureDebut.Items.Add(new ListItem(timeToDisplay, availability.availabilityId.ToString()));
                }
                ddlDate_SelectedIndexChanged(null, null);
            }
        }

        protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlHeureDebut.Items.Clear();
            int availabilityId = Convert.ToInt32(ddlDate.SelectedValue);
            Availability availability = af.GetById(availabilityId);

            DateTime[] heures = splitTime(availability.strdt, availability.enddt);

            foreach (DateTime heure in heures)
            {
                string timeToDisplay = heure.ToString("t", CultureInfo.CreateSpecificCulture("fr-FR"));
                ddlHeureDebut.Items.Add(new ListItem(timeToDisplay));
            }

        }

        protected DateTime[] splitTime(DateTime debut, DateTime fin)
        {
            List<DateTime> listeSplit = new List<DateTime>();
            DateTime temps = debut;

            while (temps < fin)
            {
                TimeSpan ts = new TimeSpan();
                ts = fin - temps;
                if (ts.Hours >= 1)
                {
                    listeSplit.Add(temps);
                }
                temps = temps.AddMinutes(30);
            }

            return listeSplit.ToArray();
        }

        protected void buttonSubmitClick(object sender, EventArgs e)
        {
            string dateAEnvoyee = ddlDate.SelectedItem.Text;

            int availabilityId = Convert.ToInt32(ddlDate.SelectedValue);
            Availability availability = af.GetById(availabilityId);
            DateTime date = availability.strdt;
            string temps = ddlHeureDebut.SelectedValue;
            int heure = Convert.ToInt32(temps.Substring(0, 2));
            int minutes = Convert.ToInt32(temps.Substring(3, 2));
            DateTime date2 = new DateTime(date.Year, date.Month, date.Day, heure, minutes, 00);

            string message = txtContent.Text;

            if (message.Length > 200)
            {
                notification.Style.Add("color", "red");
                notification.InnerText = "Le nombre maximum de caractère à été atteint. Veuillez réduire la longueur de votre message.";
                return;
            }

            Regex regex = new Regex(@"\w{26,}");
            if (regex.IsMatch(message))
            {
                notification.Style.Add("color", "red");
                notification.InnerText = "Le message actuel ne peux pas être envoyer. Veuillez vérifier votre message.";
                return;
            }

            Availability newAv = af.splitavail(availabilityId, date2);
            //enrRDV
            AppointementFactory ap = new AppointementFactory(cnnStr);
            ap.Add(user.userId, newAv.availabilityId, message);

            //Envoyer Email
            EmailController ec = new EmailController();
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Email/PriseRDV.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{date}", dateAEnvoyee);
            string minuteString;
            if (minutes == 0)
            {
                minuteString = minutes.ToString() + "0";
            }
            else
            {
                minuteString = minutes.ToString();
            }
            body = body.Replace("{heure}", heure.ToString() + "h"+ minuteString);
            body = body.Replace("{prenom}", user.firstname);
            body = body.Replace("{nom}", user.lastname);
            body = body.Replace("{email}", user.email);

            ec.SendMail(emailAddress, "Rendez-vous de " + user.firstname + " " + user.lastname , body);

            // Redirection à une page de confirmation
            Response.Redirect("ConfirmationRDV.aspx?User=" + user.userId);
        }

        protected void btnRedirection_Click(object sender, EventArgs e)
        {
            if (etat == "Accueil")
            {
                Response.Redirect("Accueil.aspx");
            }
            else
            {
                Response.Redirect("Contact.aspx");
            }
        }

    }
}