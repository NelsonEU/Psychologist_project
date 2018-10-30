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

            CategoryFactory cf = new CategoryFactory(cnnStr);
            Category[] categories = cf.GetAll();

            string toAppend = string.Empty;
            
            foreach(Category c in categories)
            {
                toAppend += "<div class=\"text-center text-secondary\"><a href=\"" + c.urlRedirect + "\"><img src=\"" + c.pictureUrl + "\" class=\"imageCarousel mb-2\" /></a><a class=\"link-carousel text-secondary\" href=\"" + c.urlRedirect + "\"> <h2>" + c.name + "</h2></a></div>";
            }

            carouselCategories.InnerHtml = toAppend;
           
        }
    }
}