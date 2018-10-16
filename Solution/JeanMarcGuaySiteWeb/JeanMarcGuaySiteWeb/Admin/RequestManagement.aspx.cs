using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessLogic.Factories;
using System.Configuration;
using System.Linq;

namespace JeanMarcGuaySiteWeb.Admin
{
    public partial class RequestManagement : System.Web.UI.Page
    {
        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            // -----------Vérification le l'état du module ----------- //
            ModuleFactory moduleFactory = new ModuleFactory(cnnStr);           
            Module m = moduleFactory.Get(2);/* Module id 2 = Module de prises de contact */
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

            foreach (Request request in requests)
            {
                TableRow row = new TableRow();
                TableCell cellDate = new TableCell();
                TableCell cellSujet = new TableCell();
                TableCell cellContenu = new TableCell();
                TableCell cellNom = new TableCell();
                TableCell cellPrenom = new TableCell();
                TableCell cellEmail = new TableCell();

                if (dictionaryUser.ContainsKey(request.userId))
                {
                User user = dictionaryUser[request.userId];

                cellDate.Text = request.creationDate.ToString();
                cellSujet.Text = request.subject;
                cellContenu.Text = request.content;
                cellNom.Text = user.lastname;
                cellPrenom.Text = user.firstname;
                cellEmail.Text = user.email;

                row.Cells.Add(cellDate);
                row.Cells.Add(cellSujet);
                row.Cells.Add(cellContenu);
                row.Cells.Add(cellNom);
                row.Cells.Add(cellPrenom);
                row.Cells.Add(cellEmail);
                
                requestTable.Rows.Add(row);
                }
                

            }
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
    }
}