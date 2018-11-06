﻿using System;
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


            //Feed les catégories 
            if (!Page.IsPostBack)
            {
                publicationTable.Rows.Clear();
                CategoryFactory cf = new CategoryFactory(cnnStr);
                Category[] categories = cf.GetAll();

                DdlCategories.Items.Add(new ListItem("Tous", "Tous"));
                foreach (Category categorie in categories)
                {
                    DdlCategories.Items.Add(new ListItem(categorie.name, categorie.categoryId.ToString()));
                }

                Publication[] publications = pf.GetAll();
                afficherTableau(publications);
            }
            else
            {
                SelectedIndexChanged(null, null);
            }

        }

        protected void SelectedIndexChanged(object sender, EventArgs e)
        {
            string categorie = DdlCategories.SelectedValue;
            publicationTable.Rows.Clear();
            if (categorie == "Tous")
            {
                Publication[] publications = pf.GetAll();
                afficherTableau(publications);
            }
            else
            {
                Publication[] publications = pf.GetAllByCategoryId(Convert.ToInt32(categorie));
                afficherTableau(publications);
            }
        }

        protected void afficherTableau( Publication[] publications)
        {
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
                buttonSupprimer.Attributes.Add("class", "btn btn-warning btnSuppr");
                buttonSupprimer.Text = "Supprimer";
                buttonSupprimer.Attributes.Add("data-id", publication.publicationId.ToString());
                buttonSupprimer.Click += new EventHandler(btn_Supprimer_Click);
                cellSupprimer.Controls.Add(buttonSupprimer);

                row.Cells.Add(cellTitle);
                row.Cells.Add(cellTelecharger);
                row.Cells.Add(cellSupprimer);

                publicationTable.Rows.Add(row);
            }
        }

        protected void btn_Telecharger_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.Attributes["data-id"]);
            Publication publication = pf.Get(id);

            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + publication.title + ".pdf");
            Response.TransmitFile(Server.MapPath(publication.url));
            Response.End();
        }
        protected void btn_Supprimer_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_delete"];
            if (confirmValue == "Oui")
            {
                Button button = (Button)sender;
                int id = Convert.ToInt32(button.Attributes["data-id"]);
                Publication publication = pf.Get(id);
                pf.delete(id);
                try
                {
                    string FileToDelete = Server.MapPath(publication.url);
                    File.Delete(FileToDelete);
                }
                finally
                {
                    Response.Redirect(Request.RawUrl);
                }
            } 
        }

       

    }
}