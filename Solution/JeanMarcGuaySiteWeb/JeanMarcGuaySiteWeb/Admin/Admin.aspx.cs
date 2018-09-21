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
        string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            ModuleFactory moduleFactory = new ModuleFactory(cnnStr);
            Module[] modules = moduleFactory.GetAll();
            DataTable rptModulesSource = new DataTable();
            rptModulesSource.Columns.AddRange(new DataColumn[2] { new DataColumn("labelModule"), new DataColumn("active") });
            
            if (modules.Length > 0)
            {
                for (int i = 0; i < modules.Length; i++)
                {
                    rptModulesSource.Rows.Add(modules[i].title, modules[i].moduleId.ToString());
                }
            }

            rptModules.DataSource = rptModulesSource;
            rptModules.DataBind();
        }

    }
}