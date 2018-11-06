using BusinessLogic;
using BusinessLogic.Factories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace JeanMarcGuaySiteWeb
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        private PublicationFactory pf = new PublicationFactory(cnnStr);

        protected void Page_Load(object sender, EventArgs e)
        {
            // ----------- Vérification le l'état du module ----------- //
            ModuleFactory moduleFactory = new ModuleFactory(cnnStr);
            Module m = moduleFactory.Get(3);/* Module id 3 = Module des documents PDF */
            if (m.active == false)
            {
                Response.Redirect("Default.aspx");
            }
            // ------------------------------------------------------- //

            int category;
            if (Request.QueryString["cat"] != null)
            {
                if(Int32.TryParse(Request.QueryString["cat"], out category))
                {
                    Publication[] publications = pf.GetAllByCategoryId(category);

                    CategoryFactory cf = new CategoryFactory(cnnStr);
                    Category cat = cf.GetCategoryById(category);

                    if (cat.IsNull())
                    {
                        Response.Redirect("Publications.aspx");
                    }

                    titreCategorie.InnerText = cat.name;

                    if (publications.Length < 1)
                    {
                        divPublications.Visible = false;
                        divNotif.Visible = true;
                    }
                    else
                    {
                        divPublications.Visible = true;
                        divNotif.Visible = false;
                        HtmlTableRow headerRow = new HtmlTableRow();
                        HtmlTableCell cellTitre = new HtmlTableCell("th");
                        HtmlTableCell cellTelecharger = new HtmlTableCell("th");
                        cellTitre.InnerText = "Titre";
                        cellTitre.Attributes.Add("class", "col-8 align-middle");
                        cellTelecharger.InnerText = "PDF";
                        headerRow.Cells.Add(cellTitre);
                        headerRow.Cells.Add(cellTelecharger);
                        tablePublications.Rows.Add(headerRow);
                        foreach (Publication p in publications)
                        {
                            HtmlTableRow row = new HtmlTableRow();
                            HtmlTableCell cellD = new HtmlTableCell("td");
                            HtmlTableCell cellT = new HtmlTableCell("td");
                            cellD.InnerText = p.title;
                            cellD.Attributes.Add("class", "col-8 align-middle");
                            Button button = new Button();
                            button.Text = "Télécharger";
                            button.CssClass = "btn btn-primary";
                            button.CommandName = "download";
                            button.CommandArgument = p.publicationId.ToString();
                            button.Click += new EventHandler(Download_Click);
                            cellT.Controls.Add(button);
                            row.Cells.Add(cellD);
                            row.Cells.Add(cellT);
                            tablePublications.Rows.Add(row);
                        }
                    }
                }
                else{
                    Response.Redirect("Publications.aspx");
                }
            }
            else
            {
                Response.Redirect("Publications.aspx");
            }
            
           

        }

        protected void Download_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.CommandName == "download")
            {
                int pubId = Int32.Parse(btn.CommandArgument.ToString());
                Publication publication = pf.Get(pubId);
                string fileName = publication.title.Replace(" ","_");
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName + ".pdf"); 
                Response.TransmitFile(Server.MapPath(publication.url));
            }
        }
    }
}