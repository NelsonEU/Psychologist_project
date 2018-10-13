using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;


namespace JeanMarcGuaySiteWeb
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                User user = (User)Session["User"];
                connexionButton.InnerText = "Se Déconnecter";
            }
        }
    }
}