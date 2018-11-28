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
                        notifWaiting.InnerText = "Les rendez-vous sélectionnés ont bien été confirmés";
                        notifConfirmed.Visible = false;
                        break;
                    case "refuse":
                        notifWaiting.Visible = true;
                        notifWaiting.InnerText = "Les rendez-vous sélectionnés ont bien été refusés";
                        notifConfirmed.Visible = false;
                        break;
                    case "cancel":
                        notifConfirmed.Visible = true;
                        notifConfirmed.InnerText = "Les rendez-vous sélectionnés ont bien été annulés";
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
            Appointement[] confirmedAppointements = af.GetConfirmed();
            notifNoRdv.Visible = false;
            if(unconfirmedAppointements.Length > 0)
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
                        TableCell cellSelect = new TableCell();
                        cellDate.Text = dateToDisplay;
                        cellLastname.Text = user.lastname;
                        cellFirstname.Text = user.firstname;
                        cellEmail.Text = user.email;
                        cellMessage.Text = a.message;
                        CheckBox cb = new CheckBox();
                        cellSelect.Controls.Add(cb);
                        cellSelect.ID = a.appointementId.ToString();
                        cellSelect.CssClass = "selectUser";
                        row.Cells.Add(cellDate);
                        row.Cells.Add(cellLastname);
                        row.Cells.Add(cellFirstname);
                        row.Cells.Add(cellEmail);
                        row.Cells.Add(cellMessage);
                        row.Cells.Add(cellSelect);
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

            
            if(confirmedAppointements.Length > 0)
            {
                bool smth = false;
                foreach(Appointement a in confirmedAppointements)
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
                        TableCell cellSelect = new TableCell();
                        cellDate.Text = dateToDisplay;
                        cellLastname.Text = user.lastname;
                        cellFirstname.Text = user.firstname;
                        cellEmail.Text = user.email;
                        cellMessage.Text = a.message;
                        CheckBox cb = new CheckBox();
                        cellSelect.Controls.Add(cb);
                        cellSelect.ID = a.appointementId.ToString();
                        cellSelect.CssClass = "selectUser";
                        row.Cells.Add(cellDate);
                        row.Cells.Add(cellLastname);
                        row.Cells.Add(cellFirstname);
                        row.Cells.Add(cellEmail);
                        row.Cells.Add(cellMessage);
                        row.Cells.Add(cellSelect);
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
            else{
                cardConfirmed.Visible = false;
            }
  
            //Afficher une notif si il n'y a rien a afficher
            if(cardUnconfirmed.Visible == false && cardConfirmed.Visible == false)
            {
                notifNoRdv.Visible = true;
            }
        }

        protected void Click_Confirm(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_rdv"];
            if (confirmValue == "Oui")
            {
                AppointementFactory af = new AppointementFactory(cnnStr);
                UserFactory uf = new UserFactory(cnnStr);
                AvailabilityFactory avf = new AvailabilityFactory(cnnStr);
                List<String> listId = new List<String>();
                foreach (TableRow row in tabUnconfirmed.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        if (cell.CssClass == "selectUser" && ((CheckBox)cell.Controls[0]).Checked)
                        {
                            listId.Add(cell.ID);
                        }
                    }
                }
                String[] tabId = listId.ToArray();
                if(tabId.Length > 0)
                {
                    af.confirmByArray(tabId);
                    User[] tabUsers = uf.GetAll();
                    Dictionary<int, User> mapUser = new Dictionary<int, User>();
                    foreach(User u in tabUsers)
                    {
                        mapUser.Add(u.userId, u);
                    }
                    Availability[] tabAvailability = avf.GetAll();
                    Dictionary<int, Availability> mapAvailability = new Dictionary<int, Availability>();
                    foreach (Availability a in tabAvailability)
                    {
                        mapAvailability.Add(a.availabilityId, a);
                    }                  
                    Appointement[] tabAppointments = af.GetByArray(tabId);
                    foreach(Appointement a in tabAppointments)
                    {
                        //On envoie un mail de confirmation
                        EmailController ec = new EmailController();
                        string body = string.Empty;
                        using (StreamReader reader2 = new StreamReader(Server.MapPath("~/Email/ConfirmationRDV.html")))
                        {
                            body = reader2.ReadToEnd();
                        }
                        body = body.Replace("{user}", mapUser[a.userId].firstname);
                        body = body.Replace("{date}", mapAvailability[a.availabilityId].strdt.ToString("f", CultureInfo.CreateSpecificCulture("fr-FR")));
                        ec.SendMail(mapUser[a.userId].email, "JMGuay.ca - Confirmation du rendez-vous [Message automatique]", body);
                    }
                }

            }
            Response.Redirect(Request.RawUrl + "?notif=confirm");
        }

        protected void Click_Refuse(object sender, EventArgs e)
        {

            string confirmValue = Request.Form["refuse_rdv"];
            if (confirmValue == "Oui")
            {

                AppointementFactory af = new AppointementFactory(cnnStr);
                UserFactory uf = new UserFactory(cnnStr);
                AvailabilityFactory avf = new AvailabilityFactory(cnnStr);
                List<String> listId = new List<String>();
                foreach (TableRow row in tabUnconfirmed.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        if (cell.CssClass == "selectUser" && ((CheckBox)cell.Controls[0]).Checked)
                        {
                            listId.Add(cell.ID);
                        }
                    }
                }
                String[] tabId = listId.ToArray();
                Refuse(tabId);
                
            }
            Response.Redirect(Request.RawUrl + "?notif=refuse");
        }

        protected void Click_Cancel(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["cancel_rdv"];
            if (confirmValue == "Oui")
            {
                AppointementFactory af = new AppointementFactory(cnnStr);
                UserFactory uf = new UserFactory(cnnStr);
                AvailabilityFactory avf = new AvailabilityFactory(cnnStr);
                List<String> listId = new List<String>();
                foreach (TableRow row in tabConfirmed.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        if (cell.CssClass == "selectUser" && ((CheckBox)cell.Controls[0]).Checked)
                        {
                            listId.Add(cell.ID);
                        }
                    }
                }
                string[] tabId = listId.ToArray();
                Refuse(tabId);
            }
            Response.Redirect(Request.RawUrl + "?notif=cancel");
        }

        private void Refuse(string[] tabId)
        {
            AppointementFactory af = new AppointementFactory(cnnStr);
            UserFactory uf = new UserFactory(cnnStr);
            AvailabilityFactory avf = new AvailabilityFactory(cnnStr);
            if (tabId.Length > 0)
            {
                af.DeleteByArray(tabId);
                User[] tabUsers = uf.GetAll();
                Dictionary<int, User> mapUser = new Dictionary<int, User>();
                foreach (User u in tabUsers)
                {
                    mapUser.Add(u.userId, u);
                }
                Availability[] tabAvailability = avf.GetAll();
                Dictionary<int, Availability> mapAvailability = new Dictionary<int, Availability>();
                foreach (Availability a in tabAvailability)
                {
                    mapAvailability.Add(a.availabilityId, a);
                }
                Appointement[] tabAppointments = af.GetByArray(tabId);
                foreach (Appointement a in tabAppointments)
                {
                    //On envoie un mail de refus
                    EmailController ec = new EmailController();
                    string body = string.Empty;
                    using (StreamReader reader2 = new StreamReader(Server.MapPath("~/Email/RefusRDV.html")))
                    {
                        body = reader2.ReadToEnd();
                    }
                    body = body.Replace("{user}", mapUser[a.userId].firstname);
                    body = body.Replace("{date}", mapAvailability[a.availabilityId].strdt.ToString("f", CultureInfo.CreateSpecificCulture("fr-FR")));
                    ec.SendMail(mapUser[a.userId].email, "JMGuay.ca - Annulation du rendez-vous [Message automatique]", body);
                }
            }
        }
    }
}