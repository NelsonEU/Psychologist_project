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
using System.Web.UI.HtmlControls;

namespace JeanMarcGuaySiteWeb.Admin
{
    public partial class ModuleManagement : System.Web.UI.Page
    {

        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        ModuleFactory moduleFactory = new ModuleFactory(cnnStr);

        protected void Page_Load(object sender, EventArgs e)
        {

            Module[] modules = moduleFactory.GetAll();

            foreach (Module m in modules)
            {
                TableRow row = new TableRow();
                TableCell cellName= new TableCell();
                TableCell cellDescription = new TableCell();
                TableCell cellActive = new TableCell();
                CheckBox cb = new CheckBox();

                cellName.Text = m.title;
                cellDescription.Text = m.description;
                if (m.active == true)
                {
                    cb.Checked = true;          
                }
                cb.Attributes.Add("data-id", m.moduleId.ToString());
                cb.AutoPostBack = true;
                cb.InputAttributes.Add("class", "toggle");
                cb.CheckedChanged += new System.EventHandler(cb_Changed);

                cellActive.Controls.Add(cb);


                row.Cells.Add(cellName);
                row.Cells.Add(cellDescription);
                row.Cells.Add(cellActive);

                moduleTable.Rows.Add(row);
            }

        }


        protected void cb_Changed(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            string id = cb.Attributes["data-id"];
            toggle(Convert.ToInt32(id));

        }


        protected void toggle(int id)
        {
            Module module = moduleFactory.Get(id);
            if (module.active == true)
            {
                moduleFactory.Update(id, false);
            }
            else
            {
                moduleFactory.Update(id, true);
            }

            Response.Redirect(Request.RawUrl);
        }


    }
}