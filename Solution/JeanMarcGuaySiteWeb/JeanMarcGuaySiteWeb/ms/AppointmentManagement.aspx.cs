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
using BusinessLogic.Autres;
using System.IO;

namespace JeanMarcGuaySiteWeb.Admin
{
    public partial class AppointmentManagement : System.Web.UI.Page
    {
        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        static string adresseCabinet = ConfigurationManager.AppSettings["AdresseCabinet"];

        private AppointementFactory af = new AppointementFactory(cnnStr);
        private UserFactory uf = new UserFactory(cnnStr);
        private AvailabilityFactory avf = new AvailabilityFactory(cnnStr);

        protected void Page_Load(object sender, EventArgs e)
        {
            // -----------Vérification le l'état du module ----------- //
            ModuleFactory moduleFactory = new ModuleFactory(cnnStr);
            Module m = moduleFactory.Get((int)Module.AllModules.Appointment);/* Module id 1 = Module des prises de rendez-vous */
            if (m.active == false)
            {
                ActivationValidation.Visible = true;
                PageContent.Visible = false;
            }
            else
            {
                ActivationValidation.Visible = false;
                PageContent.Visible = true;
            }
            // ------------------------------------------------------- //

            if (Request.QueryString["notif"] != null)
            {
                switch (Request.QueryString["notif"])
                {
                    case "confirm":
                        notifWaiting.Visible = true;
                        notifWaiting.InnerText = "Le rendez-vous sélectionné a bien été confirmé";
                        notifConfirmed.Visible = false;
                        break;
                    case "refuse":
                        notifWaiting.Visible = true;
                        notifWaiting.InnerText = "Le rendez-vous sélectionné a bien été refusé";
                        notifConfirmed.Visible = false;
                        break;
                    case "cancel":
                        notifConfirmed.Visible = true;
                        notifConfirmed.InnerText = "Le rendez-vous sélectionné a bien été annulé";
                        notifWaiting.Visible = false;
                        break;
                }
            }
            else
            {
                notifConfirmed.Visible = false;
                notifWaiting.Visible = false;
            }

            UserFactory uf = new UserFactory(cnnStr);
            AvailabilityFactory avf = new AvailabilityFactory(cnnStr);
            AppointementFactory af = new AppointementFactory(cnnStr);
            Appointement[] unconfirmedAppointements = af.GetUnconfirmed();
            System.Diagnostics.Debug.WriteLine("TAB: " + unconfirmedAppointements.Length);
            Appointement[] confirmedAppointements = af.GetConfirmed();
            notifNoRdv.Visible = false;
            if (unconfirmedAppointements.Length > 0)
            {
                bool smth = false;
                foreach (Appointement a in unconfirmedAppointements)
                {
                    int availabilityId = a.availabilityId;
                    Availability availability = avf.GetById(availabilityId);
                    int userId = a.userId;
                    User user = uf.Get(userId);

                    DateTime dateTime = availability.strdt;
                    if (dateTime.CompareTo(DateTime.Now) < 0)
                    {
                        af.outdate(a.appointementId);
                    }
                    else
                    {
                        string dateToDisplay = dateTime.ToString("f", CultureInfo.CreateSpecificCulture("fr-FR"));
                        smth = true;
                        TableRow row = new TableRow();
                        TableCell cellDate = new TableCell();
                        TableCell cellLastname = new TableCell();
                        TableCell cellFirstname = new TableCell();
                        TableCell cellEmail = new TableCell();
                        TableCell cellMessage = new TableCell();
                        TableCell cellConfirm = new TableCell();
                        TableCell cellRefuse = new TableCell();
                        cellDate.Text = dateToDisplay;
                        cellLastname.Text = user.lastname;
                        cellFirstname.Text = user.firstname;
                        cellEmail.Text = user.email;
                        cellMessage.Text = a.message;
                        CheckBox cb = new CheckBox();
                        Button buttonConfirm = new Button();
                        buttonConfirm.Attributes.Add("class", "btn btn-success");
                        buttonConfirm.Click += new EventHandler(Click_Confirm);
                        buttonConfirm.OnClientClick = "ConfirmerRDV()";
                        buttonConfirm.Text = "Confirmer";
                        buttonConfirm.Attributes.Add("data-id", a.appointementId.ToString());
                        cellConfirm.Controls.Add(buttonConfirm);
                        Button buttonRefuser = new Button();
                        buttonRefuser.Attributes.Add("class", "btn btn-danger");
                        buttonRefuser.Click += new EventHandler(Click_Refuse);
                        buttonRefuser.OnClientClick = "RefuserRDV()";
                        buttonRefuser.Text = "Refuser";
                        buttonRefuser.Attributes.Add("data-id", a.appointementId.ToString());
                        cellRefuse.Controls.Add(buttonRefuser);


                        row.Cells.Add(cellDate);
                        row.Cells.Add(cellLastname);
                        row.Cells.Add(cellFirstname);
                        row.Cells.Add(cellEmail);
                        row.Cells.Add(cellMessage);
                        row.Cells.Add(cellConfirm);
                        row.Cells.Add(cellRefuse);
                        tabUnconfirmed.Rows.Add(row);
                    }
                }
                if (smth)
                {
                    cardUnconfirmed.Visible = true;
                }
                else
                {
                    cardUnconfirmed.Visible = false;
                }
            }
            else
            {
                cardUnconfirmed.Visible = false;
            }


            if (confirmedAppointements.Length > 0)
            {
                bool smth = false;
                foreach (Appointement a in confirmedAppointements)
                {
                    int availabilityId = a.availabilityId;
                    Availability availability = avf.GetById(availabilityId);
                    int userId = a.userId;
                    User user = uf.Get(userId);

                    DateTime dateTime = availability.strdt;
                    if (dateTime.CompareTo(DateTime.Now) < 0)
                    {
                        af.outdate(a.appointementId);
                    }
                    else
                    {
                        string dateToDisplay = dateTime.ToString("f", CultureInfo.CreateSpecificCulture("fr-FR"));
                        TableRow row = new TableRow();
                        TableCell cellDate = new TableCell();
                        TableCell cellLastname = new TableCell();
                        TableCell cellFirstname = new TableCell();
                        TableCell cellEmail = new TableCell();
                        TableCell cellMessage = new TableCell();
                        TableCell cellRefuse = new TableCell();
                        cellDate.Text = dateToDisplay;
                        cellLastname.Text = user.lastname;
                        cellFirstname.Text = user.firstname;
                        cellEmail.Text = user.email;
                        cellMessage.Text = a.message;
                        Button buttonRefuser = new Button();
                        buttonRefuser.Attributes.Add("class", "btn btn-danger");
                        buttonRefuser.Click += new EventHandler(Click_Cancel);
                        buttonRefuser.OnClientClick = "AnnulerRDV()";
                        buttonRefuser.Text = "Annuler";
                        buttonRefuser.Attributes.Add("data-id", a.appointementId.ToString());
                        cellRefuse.Controls.Add(buttonRefuser); ;
                        row.Cells.Add(cellDate);
                        row.Cells.Add(cellLastname);
                        row.Cells.Add(cellFirstname);
                        row.Cells.Add(cellEmail);
                        row.Cells.Add(cellMessage);
                        row.Cells.Add(cellRefuse);
                        tabConfirmed.Rows.Add(row);
                        smth = true;
                    }
                }
                if (smth)
                {
                    cardConfirmed.Visible = true;
                }
                else
                {
                    cardConfirmed.Visible = false;
                }
            }
            else
            {
                cardConfirmed.Visible = false;
            }

            //Afficher une notif si il n'y a rien a afficher
            if (cardUnconfirmed.Visible == false && cardConfirmed.Visible == false)
            {
                notifNoRdv.Visible = true;
            }
        }

        protected void Click_Confirm(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_rdv"];
            if (confirmValue == "Oui")
            {
                Button button = (Button)sender;
                int id = Convert.ToInt32(button.Attributes["data-id"]);
                Appointement app = af.Get(id);
                af.confirm(id);
                User user = uf.Get(app.userId);
                Availability avail = avf.GetById(app.availabilityId);

                //On envoie un mail de confirmation
                EmailController ec = new EmailController();
                string body = string.Empty;
                using (StreamReader reader2 = new StreamReader(Server.MapPath("~/Email/ConfirmationRDV.html")))
                {
                    body = reader2.ReadToEnd();
                }
                body = body.Replace("{user}", user.firstname);
                body = body.Replace("{date}", avail.strdt.ToString("f", CultureInfo.CreateSpecificCulture("fr-FR")));
                body = body.Replace("{AdresseCabinet}", adresseCabinet);
                ec.SendMail(user.email, "JMGuay.ca - Confirmation du rendez-vous [Message automatique]", body);
                Response.Redirect(Request.RawUrl + "?notif=confirm");
                return;
            }
            Response.Redirect(Request.RawUrl);

        }

        protected void Click_Refuse(object sender, EventArgs e)
        {

            string confirmValue = Request.Form["refuse_rdv"];
            if (confirmValue == "Oui")
            {

                Button button = (Button)sender;
                int id = Convert.ToInt32(button.Attributes["data-id"]);
                Refuse(id);
                Response.Redirect(Request.RawUrl + "?notif=refuse");
                return;
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void Click_Cancel(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["cancel_rdv"];
            if (confirmValue == "Oui")
            {
                Button button = (Button)sender;
                int id = Convert.ToInt32(button.Attributes["data-id"]);
                Refuse(id);
                Response.Redirect(Request.RawUrl + "?notif=cancel");
                return;
            }
            Response.Redirect(Request.RawUrl);
        }

        private void Refuse(int id)
        {


            Appointement app = af.Get(id);
            User user = uf.Get(app.userId);
            Availability avail = avf.GetById(app.availabilityId);
            af.DeleteAndFreeAvail(id);

             
            //On envoie un mail de refus
            EmailController ec = new EmailController();
            string body = string.Empty;
            using (StreamReader reader2 = new StreamReader(Server.MapPath("~/Email/RefusRDV.html")))
            {
                body = reader2.ReadToEnd();
            }
            body = body.Replace("{user}", user.firstname);
            body = body.Replace("{date}", avail.strdt.ToString("f", CultureInfo.CreateSpecificCulture("fr-FR")));

            ec.SendMail(user.email, "JMGuay.ca - Annulation du rendez-vous [Message automatique]", body);


        }
    }
}