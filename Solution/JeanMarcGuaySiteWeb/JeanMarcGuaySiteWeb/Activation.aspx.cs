using BusinessLogic.Factories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JeanMarcGuaySiteWeb
{
    public partial class Activation : System.Web.UI.Page
    {
        private string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["email"] != null)
            {
                string email = Request.QueryString["email"];
                UserFactory uf = new UserFactory(cnnStr);
                uf.ActivateByEmail(email);
            }
        }
    }
}