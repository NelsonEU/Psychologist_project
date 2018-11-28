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
            }
            // ------------------------------------------------------- //
            
            //
        }

        protected void Load_Avails()
        {
            foreach (Availability a in avList)
            {
                TableRow row = new TableRow();
                TableCell cellDate = new TableCell();
                TableCell cellstrtdt = new TableCell();
                TableCell cellenddt = new TableCell();
                TableCell cellSelect = new TableCell();
                cellDate.Text = a.strdt.Date.ToString();
                cellstrtdt.Text = a.strdt.TimeOfDay.ToString();
                cellenddt.Text = a.enddt.TimeOfDay.ToString();
                CheckBox cb = new CheckBox();
                cellSelect.Controls.Add(cb);
                cellSelect.ID = a.availabilityId.ToString();
                cellSelect.CssClass = "selectUser";
                row.Cells.Add(cellDate);
                row.Cells.Add(cellstrtdt);
                row.Cells.Add(cellenddt);
                row.Cells.Add(cellSelect);
                tabUnconfirmed.Rows.Add(row);
            }
        }

        protected void Submit_click(object sender, EventArgs e)
        {

        }
    }
}