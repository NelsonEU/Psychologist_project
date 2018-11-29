using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessLogic.Factories;
using System.Configuration;
using System.Data;

namespace JeanMarcGuaySiteWeb.Admin
{
    public partial class RequestManagement : System.Web.UI.Page
    {
        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            // -----------Vérification le l'état du module ----------- //
            ModuleFactory moduleFactory = new ModuleFactory(cnnStr);           
            Module m = moduleFactory.Get((int)Module.AllModules.Contact);/* Module id 2 = Module de prises de contact */
            if(m.active == false){
                ActivationValidation.Visible = true;
                PageContent.Visible = false;
            }else{
                ActivationValidation.Visible = false;
                PageContent.Visible = true;
            }
            // ------------------------------------------------------- //

            if (!Page.IsPostBack)
            {
                Request[] requests = getRequestArray("mois");
                Feed(requests);
            }
            //

        }

        protected void Feed(Request[] requests)
        {
            /*Dictionnaire de User*/
            Dictionary<int, BusinessLogic.User> dictionaryUser = getDictionary();
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("Date"), new DataColumn("requestId"), new DataColumn("Sujet"), new DataColumn("Contenu"), new DataColumn("Prenom"), new DataColumn("Nom"), new DataColumn("Email")});
            foreach (Request request in requests)
            {
                if (dictionaryUser.ContainsKey(request.userId))
                {
                    User user = dictionaryUser[request.userId];
                    dt.Rows.Add(request.creationDate.ToString(),request.requestId,request.subject,request.content, user.firstname, user.lastname, user.email);
                }
            }
            rptRequest.DataSource = dt;
            rptRequest.DataBind();
        }

        protected Request[] getRequestArray(string ddlValue)
        {
            RequestFactory rf = new RequestFactory(cnnStr);
            Request[] requests;
            switch (ddlValue)
            {
                case "mois":
                    {
                        requests = rf.GetLastMonth();
                        break;
                    }
                case "semaine":
                    {
                        requests = rf.GetLastWeek();
                        break;
                    }
                case "tout":
                    {
                        requests = rf.GetAll();
                        break;
                    }
                default:
                    {
                        requests = rf.GetAll();
                        break;
                    }
            }

            return requests;

        }

        protected Dictionary<int,User> getDictionary()
        {
            Dictionary<int, BusinessLogic.User> dictionaryUser = new Dictionary<int, BusinessLogic.User>();
            UserFactory uf = new UserFactory(cnnStr);
            User[] users = uf.GetAll();
            foreach (User u in users)
            {
                dictionaryUser.Add(u.userId, u);
            }
            return dictionaryUser;
        }

        protected void DdlRangeChanged(object sender, EventArgs e)
        {
            Request[] requests = getRequestArray(DdlRange.SelectedValue);
            Feed(requests);
        }

        protected void rptRequest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    {
                        RequestFactory rf = new RequestFactory(cnnStr);
                        rf.delete(Convert.ToInt32(e.CommandArgument));
                        Response.Redirect(Request.RawUrl);
                        break;
                    }
                default:
                    {
                        break;
                    }  
            }
        }

    }
}