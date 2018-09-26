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
                    TableCell cellSelect = new TableCell();
                    CheckBox cb = new CheckBox();
                    cb.ID = u.email;
                    //AJOUTER ICI LE CHECKBOX DANS LA CELULLE
                    cellLastname.Text = u.lastname;
                    cellFirstname.Text = u.firstname;
                    cellEmail.Text = u.email;
                    row.Cells.Add(cellFirstname);
                    row.Cells.Add(cellLastname);
                    row.Cells.Add(cellEmail);
                    tabUsers.Rows.Add(row);
                }
                tabUsers.Visible = true;
            }
        }
    }
}