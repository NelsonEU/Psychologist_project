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
    public partial class Contact : System.Web.UI.Page
    {

        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void buttonSubmitClick(object sender, EventArgs e)
        {
            string subject = txtSubject.Text;
            string content = txtContent.Text;
            int id; 

            if (!string.IsNullOrEmpty(subject) && !string.IsNullOrEmpty(content))
            {
                RequestFactory rf = new RequestFactory(cnnStr);
                id = 6; //Pour le test, Sinon id = user.id;
                rf.Add(id, subject, content);

                Response.Redirect("Confirmation.aspx?User=" + id);
            }

        }
    }
}