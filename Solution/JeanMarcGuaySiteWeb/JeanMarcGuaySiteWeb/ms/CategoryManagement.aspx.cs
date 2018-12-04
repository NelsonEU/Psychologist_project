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
            Module m = moduleFactory.Get((int)Module.AllModules.Publications); /* Module id 3 = Module des documents PDF */
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

            //Request.QueryString
            /*if (Request.QueryString["Conf"] != null)
            {
                if (Request.QueryString["Conf"] == "False")
                {
                    notification.Style.Add("color", "red");
                    notification.Text = "Vous avez déjà atteint le nombre minimum de catégories";
                }
            }*/

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
                buttonSupprimer.Attributes.Add("class", "btn btn-danger btnSupprCategorie");
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
                string confirmValue = Request.Form["confirm_delete"];
                if (confirmValue == "Oui")
                {
                    Button button = (Button)sender;
                    int id = Convert.ToInt32(button.Attributes["data-id"]);
                    Category category = cf.GetCategoryById(id);

                    try
                    {
                        //Supprimer l'image
                        string FileToDelete = Server.MapPath(category.pictureUrl);
                        File.Delete(FileToDelete);

                        //Supprimer les publications de la catégorie
                        PublicationFactory pf = new PublicationFactory(cnnStr);
                        Publication[] publicationsASupprimer = pf.GetAllByCategoryId(id);
                        if (publicationsASupprimer.Length > 0)
                        {
                            string[] IDsToString = new string[publicationsASupprimer.Length];
                            string[] PDFs = new string[publicationsASupprimer.Length];
                            for (int i = 0; i < publicationsASupprimer.Length; i++)
                            {
                                IDsToString[i] = publicationsASupprimer[i].publicationId.ToString();
                                PDFs[i] = publicationsASupprimer[i].url;
                            }
                            pf.DeleteByArray(IDsToString);
                            //Supprimer les PDFs
                            for (int j = 0; j < publicationsASupprimer.Length; j++)
                            {
                                string PDFtoDelete = Server.MapPath(PDFs[j]);
                                File.Delete(PDFtoDelete);
                            }
                        }


                        //Supprime de la BD (deletionDate)
                        cf.delete(id);

                    }
                    finally
                    {
                        Response.Redirect(Request.RawUrl);
                    }
            }
        }
    }
}