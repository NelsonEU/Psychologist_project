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

        protected void Submit_click(object sender, EventArgs e)
        {

        }

        protected void Ajouter_Click(object sender, EventArgs e)
        {
            //check si blank
            //verifications
            //ajouter a la bd 
            date.Value.ToString();
            time1.Value.ToString();
            time2.Value.ToString();

        }

        protected void Supprimer_Click(object sender, EventArgs e)
        {
            //get le id du button 
            Button test = (Button)sender;
            test.ID.ToString();
            //supprimer 
        }
    }
}