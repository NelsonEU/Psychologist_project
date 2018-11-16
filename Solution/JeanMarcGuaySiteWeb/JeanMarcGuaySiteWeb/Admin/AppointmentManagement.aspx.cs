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

namespace JeanMarcGuaySiteWeb.Admin
{
    public partial class AppointmentManagement : System.Web.UI.Page
    {
        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // -----------Vérification le l'état du module ----------- //
            ModuleFactory moduleFactory = new ModuleFactory(cnnStr);
            Module m = moduleFactory.Get(1);/* Module id 1 = Module des prises de rendez-vous */
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

            //
            UserFactory uf = new UserFactory(cnnStr);
            AvailabilityFactory avf = new AvailabilityFactory(cnnStr);
            AppointementFactory af = new AppointementFactory(cnnStr);
            Appointement[] unconfirmedAppointements = af.GetUnconfirmed();
            Appointement[] confirmedAppointements = af.GetConfirmed();
            if(unconfirmedAppointements.Length > 0)
            {
                foreach (Appointement a in unconfirmedAppointements)
                {
                    int availabilityId = a.availabilityId;
                    Availability availability = avf.GetById(availabilityId);
                    int userId = a.userId;
                    User user = uf.Get(userId);

                    DateTime dateTime = availability.schedule;
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
                    tabUnconfirmed.Rows.Add(row);
                }
                cardUnconfirmed.Visible = true;
            }
            else
            {
                cardUnconfirmed.Visible = false;
            }

            
            if(confirmedAppointements.Length > 0)
            {
                foreach(Appointement a in confirmedAppointements)
                {
                    int availabilityId = a.availabilityId;
                    Availability availability = avf.GetById(availabilityId);
                    int userId = a.userId;
                    User user = uf.Get(userId);

                    DateTime dateTime = availability.schedule;
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
                }
                cardConfirmed.Visible = true;
            }
            else{
                cardConfirmed.Visible = false;
            }

            

            //Afficher une notif si il n'y a rien a afficher
            if(cardUnconfirmed.Visible == false && cardConfirmed.Visible == false)
            {
                //Afficher une notif
            }



        }
    }
}