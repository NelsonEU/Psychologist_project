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
        AppointementFactory apf = new AppointementFactory(cnnStr);
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
                divRendezVousPris.Visible = false;
            }
            // ------------------------------------------------------- //

            // ----------- Vérification de l'autorisation ----------- //
            if (user != null)
            {
                Appointement appointement = apf.GetByUserId(user.userId);
                if (appointement != null) //Un rendez-vous déja actif
                {
                    divRendezVousPris.Visible = true;
                    divRendezVous.Visible = false;
                    divRenseignement.Visible = false;

                    Availability availability = af.GetById(appointement.availabilityId);
                    lblInfoRDV.Text = availability.strdt.ToString("f", CultureInfo.CreateSpecificCulture("fr-FR"));

                    if (appointement.confirmed)
                    {
                        lblConfirmation.Style.Add("color", "Green");
                        lblConfirmation.Text = "Confirmé";
                        lblNotice.Text = "";
                    }
                    else
                    {
                        lblConfirmation.Style.Add("color", "orange");
                        lblConfirmation.Text = "en attente de confirmation";
                    }

                }
                else if (user.authorized == true) //aucun rendez-vous actif et autoriser
                {
                    divRendezVous.Visible = true;
                    divRenseignement.Visible = false;
                    divRendezVousPris.Visible = false;
                }
                else //aucun rendez-vous actif et non autoriser
                {
                    divRendezVous.Visible = false;
                    divRenseignement.Visible = true;
                    divRendezVousPris.Visible = false;

                    Module m2 = moduleFactory.Get((int)Module.AllModules.Contact);
                    if (m2.active == false)
                    {
                        etat = "Accueil";
                        btnRedirection.Text = "Retour à l'accueil";
                        lblcontact.Text = "";
                    }
                }
            }
            // ------------------------------------------------------- //

            //Rempissage des dropdowns
            if (!Page.IsPostBack)
            {
                Availability[] availabilities = af.GetAllFree();
                HashSet<string> set = new HashSet<string>();
                foreach (Availability availability in availabilities)
                {
                    //Dates
                    
                    string dateToDisplay = availability.strdt.ToString("D", CultureInfo.CreateSpecificCulture("fr-FR"));
                    //CultureInfo.CurrentCulture.DateTimeFormat

                    if (!set.Contains(dateToDisplay))
                    {
                        ddlDate.Items.Add(new ListItem(dateToDisplay, dateToDisplay));
                    }
                    set.Add(dateToDisplay);

                    //ddlDate.Items.Add(new ListItem(dateToDisplay, availability.availabilityId.ToString()));

                }
                ddlDate_SelectedIndexChanged(null, null);
            }
        }

        protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlHeureDebut.Items.Clear();
                      
                string availabilityDayString = ddlDate.SelectedValue;

                    
                DateTime availabilityDay = DateTime.Parse(availabilityDayString, CultureInfo.CreateSpecificCulture("fr-FR"));
                Availability[] tab = af.GetAllByDate(availabilityDay);
                foreach(Availability a in tab)
                {
                    DateTime[] heures = splitTime(a.strdt, a.enddt);
                    foreach (DateTime heure in heures)
                    {
                        string timeToDisplay = heure.ToString("t", CultureInfo.CreateSpecificCulture("fr-FR"));
                        ddlHeureDebut.Items.Add(new ListItem(timeToDisplay));
                    }
                }
            }catch
            {
                buttonSubmit.Visible = false;
                notification.Style.Add("font-size","15pt;");
                notification.InnerText = "Le psychologue ne propose aucune disponibilité pour le moment.";               
            }
            
            /*
            int availabilityId = Convert.ToInt32(ddlDate.SelectedValue);
            Availability availability = af.GetById(availabilityId);

            DateTime[] heures = splitTime(availability.strdt, availability.enddt);

            foreach (DateTime heure in heures)
            {
                string timeToDisplay = heure.ToString("t", CultureInfo.CreateSpecificCulture("fr-FR"));
                ddlHeureDebut.Items.Add(new ListItem(timeToDisplay));
            }
            */

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
            //int availabilityId = Convert.ToInt32(ddlDate.SelectedValue);
            //Availability availability = af.GetById(availabilityId);
            
            string dateDebut = ddlDate.SelectedValue; //Mercredi 12 decembre 2018
            string[] heureMinutes = ddlHeureDebut.SelectedValue.Split(':');
            DateTime date;
            bool convertDate = DateTime.TryParseExact(dateDebut, "dddd d MMMM yyyy", CultureInfo.CreateSpecificCulture("fr-FR"), System.Globalization.DateTimeStyles.None, out date);
            DateTime dateH = date.AddHours(Double.Parse(heureMinutes[0]));
            DateTime dateM = dateH.AddMinutes(Double.Parse(heureMinutes[1]));        
            Availability availability = af.getByDate(dateM);
            string temps = ddlHeureDebut.SelectedValue;

            int heure = Convert.ToInt32(temps.Substring(0, 2));
            int minutes = Convert.ToInt32(temps.Substring(3, 2));
            //DateTime date2 = new DateTime(dateDebutDT.Year, dateDebutDT.Month, dateDebutDT.Day, heure, minutes, 00);

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

            Availability newAv = af.splitavail(availability.availabilityId, dateM);
            AppointementFactory ap = new AppointementFactory(cnnStr);
            ap.Add(user.userId, newAv.availabilityId, message);

            //Envoyer Email
            EmailController ec = new EmailController();
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Email/PriseRDV.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{date}", ddlDate.SelectedItem.Text);
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

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            //Annuler le  RDV
            Appointement appointement = apf.GetByUserId(user.userId);
            Availability availability = af.GetById(appointement.availabilityId);
            apf.DeleteAndFreeAvail(appointement.appointementId);

            //Envoyer le email d'annulation a jmGuay
            EmailController ec = new EmailController();
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Email/AnnulationRDV.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{date}", availability.strdt.ToString("D", CultureInfo.CreateSpecificCulture("fr-FR")));
            body = body.Replace("{prenom}", user.firstname);
            body = body.Replace("{nom}", user.lastname);
            body = body.Replace("{email}", user.email);

            ec.SendMail(emailAddress, "Annulation du rendez-vous de " + user.firstname + " " + user.lastname, body);

            Response.Redirect("RendezVous.aspx");
        }
    }
}