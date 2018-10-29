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
                    if (fileUpload.PostedFile.ContentType == "application/pdf")
                    {
                        if (fileUpload.PostedFile.ContentLength < 102400)
                        {
                            string filename = Path.GetFileName(fileUpload.FileName);
                            fileUpload.SaveAs(Server.MapPath("~/admin/pdf/") + filename);
                            StatusLabel.Text = "Upload status: File uploaded!";
                        }
                        else
                            StatusLabel.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                    else
                        StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }

    }
}