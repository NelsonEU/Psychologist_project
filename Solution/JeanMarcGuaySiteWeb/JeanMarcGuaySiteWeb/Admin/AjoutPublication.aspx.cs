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
    public partial class AjoutPublication : System.Web.UI.Page
    {
        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        static string emailAddress = ConfigurationManager.AppSettings["emailAddress"];
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
                }else if (Request.QueryString["conf"] == "false")
                {
                    StatusLabel.Style.Add("color", "red");
                    StatusLabel.Text = "Ce fichier à déjà été téléversé";
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

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            UploadButton.Enabled = false;
            try
            {
                if (fileUpload.HasFile)
                {
                    if (fileUpload.PostedFile.ContentType == "application/pdf")
                    {
                        if (fileUpload.PostedFile.FileName.Length < 80)
                        {

                            //Vérification que le fichier ne soit pas déjà ajouté
                            Publication publiTest = pf.GetByFileName(fileUpload.PostedFile.FileName);
                            if (publiTest.fileName == null)
                            {
                                // Televersement du fichier
                                string path = "/admin/pdf/" + fileUpload.PostedFile.FileName;
                                fileUpload.SaveAs(Server.MapPath(path));

                                // Ajout a la BD
                                pf.Add(Convert.ToInt32(DdlCategories.SelectedValue), txtTitle.Text, path, fileUpload.PostedFile.FileName);

                                // Notification Email aux utilisateurs abonnées
                                // -----------Vérification le l'état du module ----------- //
                                ModuleFactory moduleFactory = new ModuleFactory(cnnStr);
                                Module m = moduleFactory.Get(4); /* Module id 4 = Module des abonnements */
                                if (m.active != false)
                                {
                                    //Envoyer le email
                                    UserFactory uf = new UserFactory(cnnStr);
                                    User[] users = uf.GetAllSubscribed();

                                    foreach (User user in users)
                                    {
                                        EmailController ec = new EmailController();
                                        string body = string.Empty;
                                        using (StreamReader reader = new StreamReader(Server.MapPath("~/Email/Notification.html")))
                                        {
                                            body = reader.ReadToEnd();
                                        }

                                        //Remplacer la date
                                        body = body.Replace("{date}", DateTime.Now.ToString("dd-MM-yyyy"));

                                        //Remplacer les liens
                                        string strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
                                        string strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
                                        string lienPublication = strUrl + "Publications.aspx";
                                        body = body.Replace("{lienPublications}", lienPublication);

                                        string desabonner = strUrl + "Desabonnement.aspx" + "?email=" + user.email + "&tkn=" + user.token;
                                        body = body.Replace("{desabonner}", desabonner);
                                        
                                        ec.SendMail(user.email, "Nouvelle(s) publication(s) sur JMGuay.ca", body);
                                        
                                        //update le lastNotificationDate
                                        uf.notifyById(user.userId); //Requete dans une boucle >:(
                                    }



                                }
                                // ------------------------------------------------------- //

                                // Redirect
                                txtTitle.Text = "";
                                Response.Redirect("AjoutPublication.aspx" + "?conf=true");
                            }
                            else
                            {
                                //Ce fichier (ou un du même fileName) à déjà été uploadé
                                Response.Redirect("AjoutPublication.aspx" + "?conf=false");
                            }
                        }
                        else
                        {
                            StatusLabel.Style.Add("color", "red");
                            StatusLabel.Text = "Le nom du fichier (" + fileUpload.PostedFile.FileName + ") est trop long! Ce dernier doit contenir moins de 80 caractères";
                        }
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
            finally
            {
                UploadButton.Enabled = true;
            }


        }
    }
}