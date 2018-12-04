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
using System.Drawing;
using System.IO;

namespace JeanMarcGuaySiteWeb.Admin
{
    public partial class AjoutCategorie : System.Web.UI.Page
    {
        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        static int imageQuality = Convert.ToInt32(ConfigurationManager.AppSettings["imageQuality"]);
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

            //Vérifier si il y a moins de 10 catégories (obselete)
            /*int nbCategorie = cf.Count();
            if (nbCategorie < 10)
            {
                rowAjout.Visible = true;
                rowMaximum.Visible = false;
            }
            else
            {
                rowAjout.Visible = false;
                rowMaximum.Visible = true;
            } */

            if (Request.QueryString["conf"] != null)
            {
                if (Request.QueryString["Conf"] == "True")
                {
                    StatusLabel.Style.Add("color", "green");
                    StatusLabel.Text = "La catégorie à été créée avec succès";
                }
                else if (Request.QueryString["Conf"] == "False")
                {
                    StatusLabel.Style.Add("color", "red");
                    StatusLabel.Text = "Une des catégorie à déjà cette image";
                }
            }

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileUpload.HasFile)
                {
                    if (fileUpload.PostedFile.ContentType.ToLower() == "image/jpeg" || fileUpload.PostedFile.ContentType.ToLower() == "image/jpg")
                    {
                        if (!string.IsNullOrEmpty(txtTitle.Text))
                        {                      
                            if(fileUpload.PostedFile.FileName.Length < 80)
                            {
                                //Vérification que le fichier ne soit pas déjà ajouté
                                Category categoTest = cf.GetByFileName(fileUpload.PostedFile.FileName);
                                if (categoTest == null)
                                {
                                    // Televersement de l'image
                                    string path = "/Images/Categories/" + fileUpload.PostedFile.FileName;

                                    Bitmap imgBitmap = new Bitmap(fileUpload.PostedFile.InputStream);

                                    ImageQualityController iqc = new ImageQualityController();

                                    int targetWidth = imgBitmap.Width > 500 ? 500 : imgBitmap.Width;
                                    int targetHeight = imgBitmap.Height > 500 ? 500 : imgBitmap.Height;

                                    iqc.Save(imgBitmap, targetWidth, targetHeight, imageQuality, Server.MapPath(path));

                                    //Ajout à la BD
                                    cf.Add(txtTitle.Text, path, fileUpload.PostedFile.FileName);

                                    
                                    //Redirection
                                    Response.Redirect("AjoutCategorie.aspx" + "?Conf=True");
                                }
                                else
                                {
                                    //Cette image (ou un du même fileName) à déjà été uploadé
                                    Response.Redirect("AjoutCategorie.aspx" + "?Conf=False");
                                }
                            }
                            else
                            {
                                StatusLabel.Style.Add("color", "red");
                                StatusLabel.Text = "Le nom de l'image ("+ fileUpload.PostedFile.FileName +") est trop long! Ce dernier doit contenir moins de 80 caractères";
                            }                           
                        }
                        else
                        {
                            StatusLabel.Style.Add("color", "red");
                            StatusLabel.Text = "Veuillez inscrire un nom";
                        }
                        
                    }
                    else
                    {
                        StatusLabel.Style.Add("color", "red");
                        StatusLabel.Text = "Seulement les documents du format jpg (ou jpeg) sont acceptés";
                    }
                }
            }
            catch (Exception ex)
            {
                StatusLabel.Style.Add("color", "red");
                StatusLabel.Text = "L'image n'a pas pu être téléversé. L'erreur suivante s'est produite: " + ex.Message;
            }
        }

    }
}