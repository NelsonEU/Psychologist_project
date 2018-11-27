<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AvailabilityManagement.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.AvailabilityManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style = "display: none;">
   <asp:Button runat="server" ID="invisButton" OnClick="invisButton_Click"/>
     <input runat="server" type="hidden" id="dayl1"/>
     <input id="hdnLabelState" type="hidden" runat="server" />
     <input runat="server"  type="hidden" id="time1l1" />
     <input runat="server" type="hidden"  id="time2l1" />
</div>
  <div id="dialog-form" title="Créer nouvelle disponibilité" style="background-color: darkgrey">
  <form>
    <fieldset>
      <input id="scrollDefaultExample" type="text" class="time ui-timepicker-input" autocomplete="off"/>
      <input id="scrollDefaultExample2" type="text" class="time ui-timepicker-input" autocomplete="off"/>
      <button tabindex="-1" style="position:absolute; top:-1000px"/>
    </fieldset>
  </form>
</div>
    <div class="row pb-3">
        <div class="col-lg-12">
            <h1 id="test">Gestion des disponibilités</h1>
        </div>
    </div>

    <div id="ActivationValidation" runat="server">
        Vous devez activer le module <b>« Module des prises de rendez-vous »</b> afin d'avoir accès à cette section.
    </div>

    <div id="PageContent" runat="server">

        <div class="container-fluid pt-5" runat="server">
            <div class="row">
                Disponibilité   
            </div>
            <div class="row">
                <div class="col-md-2">
                    Lundi       
                --------
                </div>
                <div class="col-md-8" id="lundi" runat="server">

                </div>
                <div class="col-md-1">
                    <button onclick="storeDay(this.id)" id="monday" class="create-date ui-button ui-corner-all ui-widget">+</button>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2">
                    Mardi       
                --------
                </div>
                <div class="col-md-8" id="mardi" runat="server">

                </div>
                <div class="col-md-1">
                    <button onclick="storeDay(this.id)" id="tuesday" class="create-date ui-button ui-corner-all ui-widget">+</button>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2">
                    Mercredi    
                ---------
                </div>
                <div class="col-md-8" id="mercredi" runat="server">

                </div>
                <div class="col-md-1">
                    <button onclick="storeDay(this.id)" id="wednesday" class="create-date ui-button ui-corner-all ui-widget">+</button>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2">
                    Jeudi       
                ---------
                </div>
                <div class="col-md-8" id="jeudi" runat="server">

                </div>
                <div class="col-md-1">
                    <button onclick="storeDay(this.id)" id="thursday" class="create-date ui-button ui-corner-all ui-widget">+</button>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2">
                    Vendredi    
                ---------
                </div>
                <div class="col-md-8" id="vendredi" runat="server">

                </div>
                <div class="col-md-1">
                    <button onclick="storeDay(this.id)" id="friday" class="create-date ui-button ui-corner-all ui-widget">+</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="additionalJS" runat="server">              
    <script src="//cdnjs.cloudflare.com/ajax/libs/underscore.js/1.7.0/underscore-min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.8.4/moment.min.js"></script>
    <link href="CSS/bootstrap-timepicker.css" rel="stylesheet" />
    <script src="Javascript/bootstrap-datepicker.js"></script>
    <link href="CSS/jquery.timepicker.min.css" rel="stylesheet" />
    <script src="Javascript/jquery.timepicker.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="Javascript/Availability.js"></script>
</asp:Content>
