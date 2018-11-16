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
	public partial class Publications1 : System.Web.UI.Page
	{
        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        User user = null;
        protected void Page_Load(object sender, EventArgs e)
		{
            // ----------- Vérification le l'état du module ----------- //
            ModuleFactory moduleFactory = new ModuleFactory(cnnStr);
            Module m = moduleFactory.Get(3);/* Module id 3 = Module des documents PDF */
            if (m.active == false)
            {
                Response.Redirect("Default.aspx");
            }
            // ------------------------------------------------------- //

            CategoryFactory cf = new CategoryFactory(cnnStr);
            Category[] categories = cf.GetAll();

            string toAppend = string.Empty;

            foreach(Category c in categories){
                toAppend += "<div class=\"col-lg-4 col-md-6 col-sm-6 col-xs-1 portfolio-item pb-4\"><div class=\"card h-100\"><a href=\""+ c.urlRedirect +"\"><img class=\"card-img-top\" src=\""+ c.pictureUrl + "\" alt=\"\"></a><div class=\"card-body\"><h4 class=\"card-title\"><a href=\""+ c.urlRedirect +"\" >"+ c.name +"</a></h4></div></div></div>";
            }

            // Bouton Abonnement
            btnAbonnements.Visible = false;
            if (Session["User"] != null)
            {
                user = (User)Session["User"];
                btnAbonnements.Visible = true;
                if (user.subscriber)
                {
                    btnAbonnements.Text = "<i class='fas fa-bell-slash'></i> Se désabonner";
                }
                else
                {
                    btnAbonnements.Text = "<i class='fas fa-bell'></i> S'abonner aux publications";
                }
            }

            categoriesPortfolio.InnerHtml = toAppend;
        }

        protected void abonnementDesabonnement(object sender, EventArgs e)
        {
            UserFactory uf = new UserFactory(cnnStr);
            if (user != null)
            {
                if (user.subscriber)
                {
                    uf.OptOutById(user.userId);
                    user.subscriber = false;
                    Session["User"] = user;
                    btnAbonnements.Text = "<i class='fas fa-bell'></i> S'abonner aux publications";
                }
                else
                {
                    uf.OptInById(user.userId);
                    user.subscriber = true;
                    Session["User"] = user;
                    btnAbonnements.Text = "<i class='fas fa-bell-slash'></i> Se désabonner";
                }
            }
        }

    }
}