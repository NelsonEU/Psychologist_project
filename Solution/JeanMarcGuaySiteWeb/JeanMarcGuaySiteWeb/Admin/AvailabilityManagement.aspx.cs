using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessLogic.Factories;
using System.Configuration;

namespace JeanMarcGuaySiteWeb.Admin
{
    public partial class AvailabilityManagement : System.Web.UI.Page
    {
        static string cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        private AvailabilityFactory uf = new AvailabilityFactory(cnnStr);
        List<Availability> avList;

        protected void Page_Load(object sender, EventArgs e)
        {
            // -----------Vérification le l'état du module ----------- //
            ModuleFactory moduleFactory = new ModuleFactory(cnnStr);
            Module m = moduleFactory.Get(1);/* Module id 1 = Module des prises de rendez-vous */
            AvailabilityFactory f = new AvailabilityFactory(cnnStr);
            if (m.active == false)
            {
                ActivationValidation.Visible = true;
                PageContent.Visible = false;
            }
            else
            {
                ActivationValidation.Visible = false;
                PageContent.Visible = true;
                resetDays();
                avList =  f.GetAll().ToList();
                fillDates();
            }
            // ------------------------------------------------------- //

            //
        }

        protected void Submit_click(object sender, EventArgs e)
        {

        }

        protected void invisButton_Click(object sender, EventArgs e)
        {
            string day = hdnLabelState.Value;
            //verfications
            //if not blank (btw jdois les rendre read only)
            //if (StartA <= EndB) and (EndA >= StartB) BAD
            //Else
            if (uf.checkifvalid(dayl1.Value, Convert.ToDateTime(time1l1.Value), Convert.ToDateTime(time2l1.Value)))
            {
                uf.Add(dayl1.Value, Convert.ToDateTime(time1l1.Value), Convert.ToDateTime(time2l1.Value));
                dayl1.Value = "";
                time1l1.Value = null;
                time2l1.Value = null;
            }
            else
                return; 
        }

        protected void fillDates()
        {
            foreach (Availability av in avList)
            {
                switch(av.day)
                {
                    case "monday":
                        lundi.InnerHtml += av.strdt.ToShortTimeString() + " - " + av.enddt.ToShortTimeString() + "x | ";
                        break;
                    case "tuesday":
                        mardi.InnerHtml += av.strdt.ToShortTimeString() + " - " + av.enddt.ToShortTimeString() + "x | ";
                        break;
                    case "wednesday":
                        mercredi.InnerHtml +=  av.strdt.ToShortTimeString() + " - " + av.enddt.ToShortTimeString() + "x | ";
                        break;
                    case "thursday":
                        jeudi.InnerHtml +=  av.strdt.ToShortTimeString() + " - " + av.enddt.ToShortTimeString() + "x | ";
                        break;
                    case "friday":
                        vendredi.InnerHtml += av.strdt.ToShortTimeString() + " - " + av.enddt.ToShortTimeString() + "x | ";
                        break;

                }
            }
        }

        protected void resetDays()
        {
            lundi.InnerHtml = "";
            mardi.InnerHtml = "";
            mercredi.InnerHtml = "";
            jeudi.InnerHtml = "";
            vendredi.InnerHtml = "";
        }
    }
}