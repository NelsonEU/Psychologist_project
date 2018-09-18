using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JeanMarcGuaySiteWeb
{
    public partial class Connexion : System.Web.UI.Page
    {

        //private string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] != null)
            {
                Response.Redirect("default.aspx");
            }
        }

        protected void Submit_click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(email.Text) && !string.IsNullOrEmpty(password.Text))
            {
             
            }
        }
            
    }  
}