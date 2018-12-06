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
    public partial class ConfirmationRDV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Session["User"] != null)
                {
                    User user = (User)Session["User"];
                    if (!string.IsNullOrEmpty(Request.QueryString["User"]) && user.userId.ToString() == Request.QueryString["User"]) /* Request.QueryString["User"] est est un id */
                    {
                        //Tout est OK! rien à faire... 
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
                else /* l'utilisateur n'est pas connecté */
                {
                    Response.Redirect("Default.aspx");
                }

            }
        }

        protected void buttonSubmitClick(object sender, EventArgs e)
        {
            Response.Redirect("RendezVous.aspx");
        }

    }
}