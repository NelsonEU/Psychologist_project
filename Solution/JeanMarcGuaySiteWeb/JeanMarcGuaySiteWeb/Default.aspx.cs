﻿using System;
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
        UserFactory userF = new UserFactory(cnnStr);

        protected void Page_Load(object sender, EventArgs e)
        {
            //userF.Add("TestLastName", "TestFirstName", "Test@test.test", "TestPassword", false, false);
        }
    }
}