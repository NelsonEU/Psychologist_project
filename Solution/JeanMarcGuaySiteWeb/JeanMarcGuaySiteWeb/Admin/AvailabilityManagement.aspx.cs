using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessLogic.Factories;
using System.Configuration;

namespace JeanMarcGuaySiteWeb.Admin
{
    public partial class AvailabilityManagement : System.Web.UI.Page
    {
        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        private AvailabilityFactory uf = new AvailabilityFactory(cnnStr);
        List<Availability> avList;

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
                avList =  uf.GetAll().ToList();
                Load_Avails();
            }
            // ------------------------------------------------------- //
            
            //
        }

        protected void Load_Avails()
        {
          //  tabAvail = new Table();
            foreach (Availability a in avList)
            {
                TableRow row = new TableRow();
                TableCell cellDate = new TableCell();
                TableCell cellstrtdt = new TableCell();
                TableCell cellenddt = new TableCell();
                TableCell cellBtn = new TableCell();
                cellDate.Text = a.strdt.Day+"/"+a.strdt.Month+"/"+a.strdt.Year;
                cellstrtdt.Text = a.strdt.TimeOfDay.ToString();
                cellenddt.Text = a.enddt.TimeOfDay.ToString();
                Button bt = new Button();
                bt.CssClass = "btn - danger";
                bt.Text = "Supprimer";
                bt.ID = a.availabilityId.ToString();
                bt.Click += new EventHandler(this.Supprimer_Click);
                cellBtn.Controls.Add(bt);
                row.Cells.Add(cellDate);
                row.Cells.Add(cellstrtdt);
                row.Cells.Add(cellenddt);
                row.Cells.Add(cellBtn);
                tabAvail.Rows.Add(row);
            }
        }

        protected void Ajouter_Click(object sender, EventArgs e)
        {
            //check si blank
            //verifications
            //ajouter a la bd 
            String tdate = date.Value.ToString();
            String ttime1 = time1.Value.ToString();
            String ttime2 = time2.Value.ToString();

            if (tdate != "" && ttime1 != "" && ttime2 != "" && Convert.ToDateTime(ttime1) < Convert.ToDateTime(ttime2))
            {
                int month =  Convert.ToInt32(tdate.Substring(0, 2));
                int day = Convert.ToInt32(tdate.Substring(3, 2));
                int year = Convert.ToInt32(tdate.Substring(6, 4));
                int hour = Convert.ToInt32(ttime1.Substring(0, 2));
                int minute = Convert.ToInt32(ttime1.Substring(3, 2));
                int second = 00;

                int month2 = Convert.ToInt32(tdate.Substring(0, 2));
                int day2 = Convert.ToInt32(tdate.Substring(3, 2));
                int year2 = Convert.ToInt32(tdate.Substring(6, 4));
                int hour2 = Convert.ToInt32(ttime2.Substring(0, 2));
                int minute2 = Convert.ToInt32(ttime2.Substring(3, 2));
                int second2 = 00;
                //verif si existe pas deja dans le range
                DateTime strdt = new DateTime(year, month, day, hour, minute, second);
                DateTime enddt = new DateTime(year2, month2, day2, hour2, minute2, second2);

                bool legit = uf.checkifvalid(strdt, enddt);

                if (legit)
                {
                    uf.Add(strdt, enddt);
                    Response.Redirect(Request.RawUrl);
                }

            }
            else
            {
                //invalid
            }

        }

        protected void Supprimer_Click(object sender, EventArgs e)
        {
            //get le id du button 
            Button theButton = (Button)sender;

            uf.delete(Convert.ToInt32(theButton.ID));
            Response.Redirect(Request.RawUrl);

        }
    }
}