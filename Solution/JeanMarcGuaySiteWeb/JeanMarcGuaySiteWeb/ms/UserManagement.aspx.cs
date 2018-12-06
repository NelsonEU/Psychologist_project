using System;
using BusinessLogic.Factories;
using static BusinessLogic.User;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Configuration;
using BusinessLogic.Autres;
using System.IO;

namespace JeanMarcGuaySiteWeb.Admin
{
    public partial class UserManagement : System.Web.UI.Page
    {
        private static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        private UserFactory uf = new UserFactory(cnnStr);


        protected void Page_Load(object sender, EventArgs e)
        {
            User[] allUsers = uf.GetAll();
            if (allUsers.Length < 1)
            {
                notif.InnerText = "Aucun utilisateur n'est inscrit sur le site.";
                notif.Visible = true;
                tabUsers.Visible = false;
            }
            else
            {
                foreach (User u in allUsers)
                {
                    if (!u.admin)
                    {
                        TableRow row = new TableRow();
                        TableCell cellLastname = new TableCell();
                        TableCell cellFirstname = new TableCell();
                        TableCell cellEmail = new TableCell();
                        TableCell cellSubscriber = new TableCell();
                        TableCell cellAuthoriser = new TableCell();
                        TableCell cellSupprimer = new TableCell();

                        Button buttonSupprimer = new Button();
                        buttonSupprimer.Attributes.Add("class", "btn btn-danger btnDeleteUser");
                        buttonSupprimer.Text = "Supprimer";
                        buttonSupprimer.Attributes.Add("data-id", u.userId.ToString());
                        buttonSupprimer.Click += new EventHandler(Click_Delete);
                        cellSupprimer.Controls.Add(buttonSupprimer);
                        buttonSupprimer.Attributes.Add("data-id", u.userId.ToString());
                        buttonSupprimer.Click += new EventHandler(Click_Delete);
                        buttonSupprimer.OnClientClick = "ConfirmerSuppression()";

                        Button buttonAuthorize = new Button();
                        if (u.authorized)
                        {
                            buttonAuthorize.Attributes.Add("class", "btn btn-warning btnUnauthorize");
                            buttonAuthorize.Click += new EventHandler(Click_Deauthorized);
                            buttonAuthorize.OnClientClick = "ConfirmerDesauthorisation";
                            buttonAuthorize.Text = "Desauthoriser";
                        }
                        else
                        {
                            buttonAuthorize.Attributes.Add("class", "btn btn-success btnAuthorize");
                            buttonAuthorize.Click += new EventHandler(Click_Authorized);
                            buttonAuthorize.Text = "Authoriser";
                        }
                        buttonAuthorize.Attributes.Add("data-id", u.userId.ToString());


                        cellLastname.Text = u.lastname;
                        cellFirstname.Text = u.firstname;
                        cellEmail.Text = u.email;
                        if (u.subscriber)
                        {
                            cellSubscriber.Text = "Oui";
                        }
                        else
                        {
                            cellSubscriber.Text = "Non";
                        }
                        cellSupprimer.Controls.Add(buttonSupprimer);
                        cellAuthoriser.Controls.Add(buttonAuthorize);
                        row.Cells.Add(cellFirstname);
                        row.Cells.Add(cellLastname);
                        row.Cells.Add(cellEmail);
                        row.Cells.Add(cellSubscriber);
                        row.Cells.Add(cellAuthoriser);
                        row.Cells.Add(cellSupprimer);
                        tabUsers.Rows.Add(row);
                    }
                }
                tabUsers.Visible = true;
            }
        }

        protected void Click_Authorized(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.Attributes["data-id"]);
            uf.AuthorizeById(id, true);
            User u = uf.Get(id);
            EmailController ec = new EmailController();
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Email/AuthorisationEmail.html")))
            {
                body = reader.ReadToEnd();
            }
            string strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
            string strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
            string lienActivation = strUrl + "Connexion.aspx";

            body = body.Replace("{lienConnexion}", lienActivation);
            ec.SendMail(u.email, "Cabinet Jean-Marc Guay", body);
            Response.Redirect(Request.RawUrl);
        }





        protected void Click_Delete(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string confirmValue = Request.Form["confirm_delete"];
            if (confirmValue == "Oui")
            {
                int id = Convert.ToInt32(button.Attributes["data-id"]);
                uf.Delete(id);
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void Click_Deauthorized(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string confirmValue = Request.Form["confirm_unauthorized"];
            if (confirmValue == "Oui")
            {
                int id = Convert.ToInt32(button.Attributes["data-id"]);
                uf.AuthorizeById(id, false);
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}


