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
    public partial class ConfirmationChangementMdp : System.Web.UI.Page
    {
        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                User user = (User)Session["User"];

                if (Request.QueryString["email"] != null && Request.QueryString["tkn"] != null)
                {
                    string email = Request.QueryString["email"];
                    string token = Request.QueryString["tkn"];
                    UserFactory uf = new UserFactory(cnnStr);
                    User u = uf.GetByEmail(email);
                    if (u != null)
                    {
                        if (u.token == token)
                        {
                            uf.setNewPassword(user.userId);
                        }
                    }
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

        protected void buttonSubmitClick(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}