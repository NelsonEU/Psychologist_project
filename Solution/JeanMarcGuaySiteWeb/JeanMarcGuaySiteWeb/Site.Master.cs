using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessLogic.Factories;
using System.Configuration;


namespace JeanMarcGuaySiteWeb
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        private string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            User user = null;
            /* Vérification de connexion */
            if (Session["User"] != null)
            {
                user = (User)Session["User"];
                connexionButton.InnerText = "Se Déconnecter";
            }

            if (user == null || user.admin == false)
            {
                liAdmin.Visible = false;
            }

            /* Vérification des modules */
            ModuleFactory mf = new ModuleFactory(cnnStr);
            Module[] modules = mf.GetAll();

            foreach (Module module in modules)
            {

                if (module.moduleId == 1 && module.active == false) // Module id 1 = Module des prises de rendez-vous
                {
                    //Enlever Publications du menu
                    liRendezVous.InnerHtml = "";
                }
                else if (module.moduleId == 2 && module.active == false) // Module id 2 = Module de prises de contact
                {
                    //Enlever Contact du menu
                    liContact.InnerHtml = "";
                }
                else if (module.moduleId == 3 && module.active == false) // Module id 3 = Module des documents PDF
                {
                    //Enlever Publications du menu
                    liPublication.InnerHtml = "";
                }

            }
            
        }
    }
}