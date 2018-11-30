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
using System.Text.RegularExpressions;

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

            //Rempissage des dropdowns
            if (!Page.IsPostBack)
            {
                /*//Feed le DDL des catégories 
                CategoryFactory cf = new CategoryFactory(cnnStr);
                Category[] categories = cf.GetAll();
                DdlCategories.Items.Add(new ListItem("Toutes", "Toutes"));
                foreach (Category categorie in categories)
                {
                    DdlCategories.Items.Add(new ListItem(categorie.name, categorie.categoryId.ToString()));
                }

                //Affiche toutes les publications par défaut
                Publication[] publications = pf.GetAll();
                afficherTableauRepeater(publications);*/
            }
        }

        protected void buttonSubmitClick(object sender, EventArgs e)
        {
            int availabilityId = Convert.ToInt32(ddlDate.SelectedValue);
            string date = ddlDate.SelectedValue;
            string heure = ddlHeureDebut.SelectedValue;
            string dateHeure = date + " " + heure;
            string message = txtContent.Text;

            if (message.Length > 200)
            {
                notification.Style.Add("color", "red");
                notification.InnerText = "Le nombre maximum de caractère à été atteint. Veuillez réduire la longueur de votre message.";
                return;
            }

            Regex regex = new Regex(@"\w{26,}");
            if (regex.IsMatch(message))
            {
                notification.Style.Add("color", "red");
                notification.InnerText = "Le message actuel ne peux pas être envoyer. Veuillez vérifier votre message.";
                return;
            }


            
        }

    }
}