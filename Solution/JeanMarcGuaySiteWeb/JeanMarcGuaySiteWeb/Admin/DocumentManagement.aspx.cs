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

            //
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                try
                {
                    if (fileUpload.HasFile)
                    {
                        if (fileUpload.PostedFile.ContentType == "application/pdf")
                        {
                            string path = "~/admin/pdf/" + fileUpload.PostedFile.FileName;
                            fileUpload.SaveAs(Server.MapPath(path));

                            //sql here

                            StatusLabel.Style.Add("color", "green");
                            StatusLabel.Text = "Le fichier à été téléversé avec succès";
                        }
                        else
                        {
                            StatusLabel.Style.Add("color", "red");
                            StatusLabel.Text = "Seulement les documents du format PDF sont acceptés";
                        }
                    }
                  
                }
                catch (Exception ex)
                {
                    StatusLabel.Style.Add("color", "green");
                    StatusLabel.Text = "Le fichier n'a pas pu être téléversé. L'erreur suivante s'est produite: " + ex.Message;
                }
            }
        }

    }
}