using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessLogic.Factories;
using System.Configuration;
using System.IO;

namespace JeanMarcGuaySiteWeb.Admin
{
    public partial class DocumentManagement : System.Web.UI.Page
    {
        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        PublicationFactory pf = new PublicationFactory(cnnStr);
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

            if (Request.QueryString["conf"] != null)
            {
                if (Request.QueryString["conf"] == "true")
                {
                    StatusLabel.Style.Add("color", "green");
                    StatusLabel.Text = "Le fichier à été téléversé avec succès";
                }
            }

            //Feed les catégories 
            if (!Page.IsPostBack)
            {
                CategoryFactory cf = new CategoryFactory(cnnStr);
                Category[] categories = cf.GetAll();

                foreach (Category categorie in categories)
                {
                    DdlCategories.Items.Add(new ListItem(categorie.name, categorie.categoryId.ToString()));
                }
            }

            Publication[] publications = pf.GetAll();

            foreach (Publication publication in publications)
            {
                TableRow row = new TableRow();
                TableCell cellTitle = new TableCell();
                TableCell cellTelecharger = new TableCell();
                TableCell cellSupprimer = new TableCell();

                cellTitle.Text = publication.title;

                Button buttonDownload = new Button();
                buttonDownload.Text = "Télécharger";
                buttonDownload.Attributes.Add("class", "btn btn-success");
                buttonDownload.Attributes.Add("data-id", publication.publicationId.ToString());
                buttonDownload.Click += new EventHandler(btn_Telecharger_Click);
                cellTelecharger.Controls.Add(buttonDownload);

                Button buttonSupprimer = new Button();
                buttonSupprimer.Text = "Supprimer";
                buttonSupprimer.Attributes.Add("class", "btn btn-danger");
                buttonSupprimer.Attributes.Add("data-id", publication.publicationId.ToString());
                buttonSupprimer.Click += new EventHandler(btn_Supprimer_Click);
                cellSupprimer.Controls.Add(buttonSupprimer);

                row.Cells.Add(cellTitle);
                row.Cells.Add(cellTelecharger);
                row.Cells.Add(cellSupprimer);

                publicationTable.Rows.Add(row);
            }

        }

        private void btn_Telecharger_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.Attributes["data-id"]);
            //Telecharger ici :O
        }
        private void btn_Supprimer_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.Attributes["data-id"]);
            //Telecharger ici :O
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileUpload.HasFile)
                {
                    if (fileUpload.PostedFile.ContentType == "application/pdf")
                    {
                        string path = "~/admin/pdf/" + fileUpload.PostedFile.FileName;
                        fileUpload.SaveAs(Server.MapPath(path));                       
                        pf.Add(Convert.ToInt32(DdlCategories.SelectedValue), txtTitle.Text, path);
                        txtTitle.Text = "";
                        Response.Redirect(Request.RawUrl + "?conf=true");
                    }
                    else
                    {
                        StatusLabel.Style.Add("color", "red");
                        StatusLabel.Text = "Seulement les documents du format PDF sont acceptés";
                    }
                }
                else
                {
                    StatusLabel.Style.Add("color", "red");
                    StatusLabel.Text = "Veuillez insérer un ficher PDF";
                }
            }
            catch (Exception ex)
            {
                StatusLabel.Style.Add("color", "red");
                StatusLabel.Text = "Le fichier n'a pas pu être téléversé. L'erreur suivante s'est produite: " + ex.Message;
            }


        }

    }
}