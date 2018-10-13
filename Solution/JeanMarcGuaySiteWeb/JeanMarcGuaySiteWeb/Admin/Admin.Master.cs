using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessLogic.Factories;
using System.Configuration;

namespace JeanMarcGuaySiteWeb.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Vérification de connexion et du status d'admin*/
            if (Session["User"] != null)
            {
                User user = (User)Session["User"];
                if (!user.admin)
                {
                    Response.Redirect("../Default.aspx");
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }

        protected void OnClickUserManagement(object sender, EventArgs e)
        {
            
        }
    }
}