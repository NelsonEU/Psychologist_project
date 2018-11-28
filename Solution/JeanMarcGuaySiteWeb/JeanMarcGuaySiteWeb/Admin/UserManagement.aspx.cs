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
                        TableCell cellAutorizhed = new TableCell();
                        TableCell cellSelect = new TableCell();
                        CheckBox cb = new CheckBox();
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
                        if (u.authorized)
                        {
                            cellAutorizhed.Text = "Oui";
                        }
                        else
                        {
                            cellAutorizhed.Text = "Non";
                        }
                        cellSelect.Controls.Add(cb);
                        cellSelect.ID = u.email;
                        cellSelect.CssClass = "selectUser";
                        row.Cells.Add(cellFirstname);
                        row.Cells.Add(cellLastname);
                        row.Cells.Add(cellEmail);
                        row.Cells.Add(cellSubscriber);
                        row.Cells.Add(cellAutorizhed);
                        row.Cells.Add(cellSelect);
                        tabUsers.Rows.Add(row);
                    }
                }
                tabUsers.Visible = true;
            }
        }

        protected void Click_Authorized(object sender, EventArgs e)
        {
            foreach (TableRow r in tabUsers.Rows)
            {
                foreach (TableCell c in r.Cells)
                {
                    if (c.CssClass == "selectUser" && ((CheckBox)c.Controls[0]).Checked)
                    {
                        uf.AuthorizeByEmail(c.ID, true);
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
                        ec.SendMail(c.ID, "Cabinet Jean-Marc Guay", body);
                    }
                }
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void Click_Delete(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_delete"];
            if (confirmValue == "Oui")
            {
                foreach (TableRow r in tabUsers.Rows)
                {
                    foreach (TableCell c in r.Cells)
                    {
                        if (c.CssClass == "selectUser" && ((CheckBox)c.Controls[0]).Checked)
                        {
                            uf.DeleteByEmail(c.ID);
                        }
                    }
                }

                Response.Redirect(Request.RawUrl);
            }
        }

        protected void Click_Deauthorized(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_unauthorized"];
            if (confirmValue == "Oui")
            {
                foreach (TableRow r in tabUsers.Rows)
                {
                    foreach (TableCell c in r.Cells)
                    {
                        if (c.CssClass == "selectUser" && ((CheckBox)c.Controls[0]).Checked)
                        {
                            uf.AuthorizeByEmail(c.ID, false);
                        }
                    }
                }
                Response.Redirect(Request.RawUrl);
            }
        }
    }


}