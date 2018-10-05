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

namespace JeanMarcGuaySiteWeb.Admin
{
    public partial class UserManagement : System.Web.UI.Page
    {
        private string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            UserFactory uf = new UserFactory(cnnStr);
            User[] allUsers = uf.GetAll();
            if(allUsers.Length < 1)
            {
                notif.InnerText = "Aucun utilisateur n'est inscrit sur le site.";
                notif.Visible = true;
                tabUsers.Visible = false;
            }
            else{
                foreach(User u in allUsers)
                {
                    TableRow row = new TableRow();
                    TableCell cellLastname = new TableCell();
                    TableCell cellFirstname = new TableCell();
                    TableCell cellEmail = new TableCell();
                    TableCell cellSubscriber = new TableCell();
                    TableCell cellAutorizhed = new TableCell();
                    TableCell cellSelect = new TableCell();
                    CheckBox cb = new CheckBox();
                    cb.ID = u.email;
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
                    row.Cells.Add(cellFirstname);
                    row.Cells.Add(cellLastname);
                    row.Cells.Add(cellEmail);
                    row.Cells.Add(cellSubscriber);
                    row.Cells.Add(cellAutorizhed);
                    row.Cells.Add(cellSelect);
                    tabUsers.Rows.Add(row);
                }
                tabUsers.Visible = true;
            }
        }
    }
}