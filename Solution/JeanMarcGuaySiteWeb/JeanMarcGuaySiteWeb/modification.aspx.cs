using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessLogic.Factories;
using System.Configuration;
using System.Globalization;

namespace JeanMarcGuaySiteWeb
{
    public partial class modification : System.Web.UI.Page
    {
        private static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        UserFactory uf = new UserFactory(cnnStr);
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                user = (User)Session["User"];
            }
            else
            {
                Response.Redirect("Default.aspx");
            }


            //Remplir les champs avec les anciennes infos
            if (!Page.IsPostBack)
            {
                txtFirstname.Text = user.firstname;
                txtLastname.Text = user.lastname;
                txtEmail.Text = user.email;
                birthday.Text = user.birthday.ToString("dd-MM-yyyy");
                if (user.subscriber)
                {
                    chkSubscription.Checked = true;
                }
                else
                {
                    chkSubscription.Checked = false;
                }
            }

       }

        protected void btnConfirmer_Click(object sender, EventArgs e)
        {
            DateTime birthdayDate = Convert.ToDateTime(DateTime.ParseExact(birthday.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture));
            uf.Update(user.userId, txtLastname.Text, txtFirstname.Text, txtEmail.Text, birthdayDate, chkSubscription.Checked);
            user.lastname = txtLastname.Text;
            user.firstname = txtFirstname.Text;
            user.email = txtEmail.Text;
            user.birthday = birthdayDate;
            user.subscriber = chkSubscription.Checked;
            Session["User"] = user;
            Response.Redirect("ConfirmationChangement.aspx?User="+user.userId.ToString());
        }

        protected void btnMDP_Click(object sender, EventArgs e)
        {

        }

        protected void bntSuppr_Click(object sender, EventArgs e)
        {

        }
    }
}