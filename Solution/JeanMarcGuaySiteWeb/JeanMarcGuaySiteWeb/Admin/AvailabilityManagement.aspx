<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AvailabilityManagement.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.AvailabilityManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <style>
    label, input { display:block; }
    input.text { margin-bottom:12px; width:95%; padding: .4em; }
    fieldset { padding:0; border:0; margin-top:25px; }
    h1 { font-size: 1.2em; margin: .6em 0; }
    div#users-contain { width: 350px; margin: 20px 0; }
    div#users-contain table { margin: 1em 0; border-collapse: collapse; width: 100%; }
    div#users-contain table td, div#users-contain table th { border: 1px solid #eee; padding: .6em 10px; text-align: left; }
    .ui-dialog .ui-state-error { padding: .3em; }
    .validateTips { border: 1px solid transparent; padding: 0.3em; }
  </style>
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
  $(document).ready(function () {

      var day;

  $( function() {
      var dialog, form,

      HeureDebut = $( "#hd" ),
      HeureFin = $( "#hf" ),
      allFields = $( [] ).add( HeureDebut ).add( HeureFin ),
      tips = $( ".validateTips" );
 
    function updateTips( t ) {
      tips
        .text( t )
        .addClass( "ui-state-highlight" );
      setTimeout(function() {
        tips.removeClass( "ui-state-highlight", 1500 );
      }, 500 );
    }
 
 
    function addTimeDay() {
      var valid = true;
      allFields.removeClass( "ui-state-error" );
 
      //check if fields are not empty

      if ( valid ) {
        //Requete

        dialog.dialog( "close" );
      }
      return valid;
    }
 
    dialog = $( "#dialog-form" ).dialog({
      autoOpen: false,
      height: 400,
      width: 350,
      modal: true,
        buttons: {
            "Ajouter plage horraire": addTimeDay,
        Cancel: function() {
          dialog.dialog( "close" );
        }
      },
      close: function() {
        //form[ 0 ].reset();
        allFields.removeClass( "ui-state-error" );
      }
    });
 
    form = dialog.find( "form" ).on( "submit", function( event ) {
      event.preventDefault();
      addUser();
    });
 
      $(".create-date").button().on("click", function () {
        event.preventDefault();
      dialog.dialog( "open" );
    });
          });
            });
  </script>

    <script>
        function storeDay(clicked_id) {
          day = clicked_id;
          alert(day);
      }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- <script>
        $(document).ready(function () {

        $('#timepicker1').timepicker();
        $('#timepicker2').timepicker();
        $(function () {
            var dialog, form,

            function addTimeDate() {
                var valid = true;

                if (valid) {
                    $("#users tbody").append("<tr>" +
                        "<td>" + name.val() + "</td>" +
                        "<td>" + email.val() + "</td>" +
                        "<td>" + password.val() + "</td>" +
                        "</tr>");
                    dialog.dialog("close");
                }
                return valid;
            }

            dialog = $("#dialog-form").dialog({
                autoOpen: false,
                height: 400,
                width: 350,
                modal: true,
                buttons: {
                    "Create an account": addUser,
                    Cancel: function () {
                        dialog.dialog("close");
                    }
                },
                close: function () {
                    form[0].reset();
                    allFields.removeClass("ui-state-error");
                }
            });

            form = dialog.find("form").on("submit", function (event) {
                event.preventDefault();
                addUser();
            });

            $("#create-avail-monday").button().on("click", function () {
                dialog.dialog("open");
            });
        });

            });
    </script> 
                <div id="dialog-form" title="Create new user">
            <p class="validateTips">All form fields are required.</p>
            <form>
                <fieldset>
                    <label for="start">Début</label>
                    <div class="input-group bootstrap-timepicker timepicker">
                        <input id="timepicker1" type="text" class="form-control input-small" />
                        <span class="input-group-addon"><i class="glyphicon glyphicon-time"></i></span>
                    </div>

                    <label for="end">Fin</label>
                    <div class="input-group bootstrap-timepicker timepicker">
                        <input id="timepicker2" type="text" class="form-control input-small" />
                        <span class="input-group-addon"><i class="glyphicon glyphicon-time"></i></span>
                    </div>
                    <!-- Allow form submission with keyboard without duplicating the dialog button
                    <input type="submit" tabindex="-1" style="position: absolute; top: -1000px">
                </fieldset>
            </form>
        </div>
        -->

    <div id="dialog-form" title="Créer nouvelle disponibilité">

  <form>
    <fieldset>
      <label for="hd">Heure début</label>
      <input type="text" name="hd" id="hd" value="" class="text ui-widget-content ui-corner-all">
      <label for="hf">Heure Fin</label>
      <input type="text" name="hf" id="hf" value="" class="text ui-widget-content ui-corner-all">
      <input type="submit" tabindex="-1" style="position:absolute; top:-1000px">
    </fieldset>
  </form>
</div>

    <div class="row pb-3">
        <div class="col-lg-12">
            <h1>Gestion des disponibilités</h1>
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
                <div class="col-md-4">
                    Lundi       
                --------
                </div>
                <div class="col-md-6" id="lundi">
                </div>
                <div class="col-md-1">
                    <button onclick="storeDay(this.id)" id="monday" class="create-date ui-button ui-corner-all ui-widget">+</button>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    Mardi       
                --------
                </div>
                <div class="col-md-6" id="mardi">
                </div>
                <div class="col-md-1">
                    <button onclick="storeDay(this.id)" id="tuesday" class="create-date ui-button ui-corner-all ui-widget">+</button>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    Mercredi    
                ---------
                </div>
                <div class="col-md-6" id="mercredi">
                </div>
                <div class="col-md-1">
                    <button onclick="storeDay(this.id)" id="wednesday" class="create-date ui-button ui-corner-all ui-widget">+</button>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    Jeudi       
                ---------
                </div>
                <div class="col-md-6" id="jeudi">
                </div>
                <div class="col-md-1">
                    <button onclick="storeDay(this.id)" id="thursday" class="create-date ui-button ui-corner-all ui-widget">+</button>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    Vendredi    
                ---------
                </div>
                <div class="col-md-6" id="vendredi">
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
    <script src="Javascript/bootstrap-timepicker.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
</asp:Content>
