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

        protected void Page_Load(object sender, EventArgs e)
        {
            // ----------- Vérification le l'état du module ----------- //
            ModuleFactory moduleFactory = new ModuleFactory(cnnStr);
            Module m = moduleFactory.Get(1);/* Module id 1 = Module des prises de rendez-vous */
            if (m.active == false)
            {
                Response.Redirect("Default.aspx");
            }
            // ------------------------------------------------------- //
        }
    }
}