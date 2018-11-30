using System;
using System.Data;
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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            /* Vérification des modules */
            ModuleFactory mf = new ModuleFactory(cnnStr);
            Module[] modules = mf.GetAll();

            foreach (Module module in modules)
            {

                if (module.moduleId == 1 && module.active == false) // Module id 1 = Module des prises de rendez-vous
                {
                    //Enlever le div rdv et dispo
                    divRDV.Attributes.Add("class", "hidden");
                    divDispo.Attributes.Add("class", "hidden");
                }
                else if (module.moduleId == 2 && module.active == false) // Module id 2 = Module de prises de contact
                {
                    //Enlever le div Contact
                    divContact.Attributes.Add("class", "hidden");
                }
                else if (module.moduleId == 3 && module.active == false) // Module id 3 = Module des documents PDF
                {
                    //Enlever le div Publications
                    divPubli.Attributes.Add("class", "hidden");
                }

            }

        }

    }
}