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
    public partial class modification : System.Web.UI.Page
    {
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
            txtFirstname.Text = user.firstname;
            txtLastname.Text = user.lastname;
            txtEmail.Text = user.email;
            birthday.Text = user.birthday.ToString("dd-MM-yyyy");

       }
    }
}