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

                    if (cat.name == null && cat.pictureUrl == null)
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
                                     
                        HtmlGenericControl ht = publicationsPortfolio;

                        foreach(Publication p in publications)
                        {
                            HtmlGenericControl newDiv = new HtmlGenericControl("div");
                            HtmlGenericControl divPubli = new HtmlGenericControl("div");
                            Button button = new Button();
                            button.Text = "Télécharger";
                            button.CssClass = "btn mainButton3";
                            button.CommandName = "download";
                            button.CommandArgument = p.publicationId.ToString();
                            button.Click += new EventHandler(Download_Click);
                            newDiv.Attributes["class"] = "col-lg-6 pt-2 pb-5 text-center";
                            divPubli.InnerHtml = "<div><h2>" + p.title + "</h2></div><object data=\"" + p.url + "\" type=\"application/pdf\" style=\"width:100%; height:300px;\" class=\"box-shadow box-admin\"></object>";                            newDiv.Controls.Add(divPubli);
                            newDiv.Controls.Add(button);
                            publicationsPortfolio.Controls.Add(newDiv);                          ;

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

        
        public  void Download_Click(object sender, EventArgs e)
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