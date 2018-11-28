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

namespace JeanMarcGuaySiteWeb
{
    public partial class RendezVous : System.Web.UI.Page
    {

        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        User user;

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
            }
            // ------------------------------------------------------- //

            // ----------- Vérification de l'autorisation ----------- //
            if (user != null)
            {
                if (user.authorized == true)
                {
                    divRendezVous.Visible = true;
                    divRenseignement.Visible = false;
                }
                else
                {
                    divRendezVous.Visible = false;
                    divRenseignement.Visible = true;
                }
            }
            // ------------------------------------------------------- //
        }
    }
}