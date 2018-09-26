using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessLogic.Factories;
using System.Configuration;

namespace JeanMarcGuaySiteWeb.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        ModuleFactory moduleFactory = new ModuleFactory(cnnStr);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Module[] modules = moduleFactory.GetAll();
                gridModules.DataSource = modules;
                gridModules.DataBind();
            }
        }
        protected void gridCategorie_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            int ID = (int)gridModules.DataKeys[index].Value; // value of the datakey
            switch (e.CommandName)
            {
                case "Toggle":
                    toggle(ID);
                    break;
            }
        }

        protected void toggle(int id)
        {
            Module module = moduleFactory.Get(id);
            if(module.active == true)
            {
                moduleFactory.Update(id, false);
            }
            else
            {
                moduleFactory.Update(id, true);
            }
            
        }


    }
}