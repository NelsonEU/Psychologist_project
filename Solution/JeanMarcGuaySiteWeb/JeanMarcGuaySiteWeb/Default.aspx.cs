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
    public partial class WebForm1 : System.Web.UI.Page
    {
        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        //CryptographyHelper ch = new CryptographyHelper();
        UserFactory userF = new UserFactory(cnnStr);

        protected void Page_Load(object sender, EventArgs e)
        {
            //string HashedPassword = ch.HashPassword(password.Text)
            //if (userF.getByEmail(email.Text) == null)
            //{
            //    //userF.Add("TestLastName", "TestFirstName", "Test@test.test", "TestPassword", false, false);
            //}           
        }
    }
}