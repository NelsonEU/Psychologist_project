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

            //
        }

        protected void Submit_click(object sender, EventArgs e)
        {

        }

        protected void invisButton_Click(object sender, EventArgs e)
        {
            string day = hdnLabelState.Value;

            //verfications
             //if not blank (btw jdois les rendre read only)
             //if (StartA <= EndB) and (EndA >= StartB) BAD
             //Else
            uf.Add(dayl1.Value, Convert.ToDateTime(time1l1.Value), Convert.ToDateTime(time2l1.Value)); 
        }
    }
}