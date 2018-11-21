using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessLogic.Factories;
using BusinessLogic.Autres;
using System.Configuration;
using System.IO;

namespace JeanMarcGuaySiteWeb.Admin
{
    public partial class CategoryManagement : System.Web.UI.Page
    {

        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        CategoryFactory cf = new CategoryFactory(cnnStr);

        protected void Page_Load(object sender, EventArgs e)
        {
            // -----------Vérification le l'état du module ----------- //
            ModuleFactory moduleFactory = new ModuleFactory(cnnStr);
            Module m = moduleFactory.Get(3); /* Module id 3 = Module des documents PDF */
            if (m.active == false)
            {
                ActivationValidation.Visible = true;
                PageContent.Visible = false;
            }
            else
            {
                ActivationValidation.Visible = false;
                PageContent.Visible = true;
            }
            // ------------------------------------------------------- //

            Category[] categories = cf.GetAll();
            afficherTableau(categories);

        }


        protected void afficherTableau(Category[] categories)
        {
            foreach (Category categorie in categories)
            {
                TableRow row = new TableRow();
                TableCell cellTitle = new TableCell();
                TableCell cellFileName = new TableCell();
                TableCell cellSupprimer = new TableCell();

                cellTitle.Text = categorie.name;
                cellFileName.Text = categorie.pictureName;

                Button buttonSupprimer = new Button();
                buttonSupprimer.Attributes.Add("class", "btn btn-danger btnSuppr");
                buttonSupprimer.Text = "Supprimer";
                buttonSupprimer.Attributes.Add("data-id", categorie.categoryId.ToString());
                buttonSupprimer.Click += new EventHandler(btn_Supprimer_Click);
                cellSupprimer.Controls.Add(buttonSupprimer);

                row.Cells.Add(cellTitle);
                row.Cells.Add(cellFileName);
                row.Cells.Add(cellSupprimer);

                categorieTable.Rows.Add(row);
            }
        }

        private void btn_Supprimer_Click(object sender, EventArgs e)
        {
            //string confirmValue = Request.Form["confirm_delete"];
            //if (confirmValue == "Oui")
            //{
                Button button = (Button)sender;
                int id = Convert.ToInt32(button.Attributes["data-id"]);
                Category category = cf.GetCategoryById(id);
                cf.delete(id);
                try
                {
                    string FileToDelete = Server.MapPath(category.pictureUrl);
                    File.Delete(FileToDelete);
                }
                finally
                {
                    Response.Redirect(Request.RawUrl);
                }
            //}
        }

    }
}