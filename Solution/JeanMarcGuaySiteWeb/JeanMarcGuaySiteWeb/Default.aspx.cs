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
    public partial class WebForm1 : System.Web.UI.Page
    {
        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        UserFactory userF = new UserFactory(cnnStr);

        protected void Page_Load(object sender, EventArgs e)
        {
            SubsectionFactory subFact = new SubsectionFactory(cnnStr);
            Subsection subsection = subFact.Get("test1");

            ModuleFactory moduleFactory = new ModuleFactory(cnnStr);
            Module m = moduleFactory.Get((int)Module.AllModules.Publications);/* Module id 3 = Module des documents PDF */
            if (m.active == false)
            {
                divCarouselOuvert.Visible = false;
                divCarouselFermer.Visible = true;
            }
            else
            {
                divCarouselOuvert.Visible = true;
                divCarouselFermer.Visible = false;
                CategoryFactory cf = new CategoryFactory(cnnStr);
                Category[] categories = cf.GetAll();

                string toAppend = string.Empty;

                foreach (Category c in categories)
                {
                    toAppend += "<div class=\"text-center text-secondary\"><a href=\"PublicationsCategorie.aspx?cat=" + c.categoryId + "\"><img src=\"" + c.pictureUrl + "\" class=\"imageCarousel mb-2\" /></a><a class=\"link-carousel text-secondary\" href=\"PublicationsCategorie.aspx?cat=" + c.categoryId + "\"> <h2>" + c.name + "</h2></a></div>";
                }

                carouselCategories.InnerHtml = toAppend;
            }

            /*Verification de connexion pour afficher le bouton "Créer un compte"*/
            if (Session["User"] != null)
            {
                divButtonCompte.Visible = false;
                divButtonSavoir.Visible = true;       
            }
            else
            {
                divButtonCompte.Visible = true;
                divButtonSavoir.Visible = false;
            }

        }
    }
}