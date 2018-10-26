using BusinessLogic.Factories;
using BusinessLogic;
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
            if(Request.QueryString["email"] != null && Request.QueryString["tkn"] != null)
            {
                string email = Request.QueryString["email"];
                string token = Request.QueryString["tkn"];
                UserFactory uf = new UserFactory(cnnStr);
                User u = uf.GetByEmail(email);
                if (u != null)
                {
                    if (u.token == token)
                    {
                        uf.ActivateByEmail(email);
                    }
                }
                
            }
        }
    }
}