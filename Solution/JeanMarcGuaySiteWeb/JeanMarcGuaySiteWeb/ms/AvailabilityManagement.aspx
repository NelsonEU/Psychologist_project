<%@ Page Title="" Language="C#" MasterPageFile="~/ms/Admin.Master" AutoEventWireup="true" CodeBehind="AvailabilityManagement.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.AvailabilityManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/bootstrap-timepicker.min.css" rel="stylesheet" />
    <link href="https://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="CSS/AvailMngt.min.css" rel="stylesheet" type="text/css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script> 
        $(document).ready(function () {
            $('#timepicker1').timepicker({
                'timeFormat': 'H:i', 'forceRoundTime': true,
                'scrollDefault': '08:00',
            });
            $('#timepicker2').timepicker({
                'timeFormat': 'H:i', 'forceRoundTime': true,
                'scrollDefault': '08:00',
            });
            $("#datepicker").datepicker(
                {
                    minDate: 0,
                    altField: "#datepicker",
                    closeText: 'Fermer',
                    prevText: 'Précédent',
                    nextText: 'Suivant',
                    currentText: 'Aujourd\'hui',
                    monthNames: ['Janvier', 'Février', 'Mars', 'Avril', 'Mai', 'Juin', 'Juillet', 'Août', 'Septembre', 'Octobre', 'Novembre', 'Décembre'],
                    monthNamesShort: ['Janv.', 'Févr.', 'Mars', 'Avril', 'Mai', 'Juin', 'Juil.', 'Août', 'Sept.', 'Oct.', 'Nov.', 'Déc.'],
                    dayNames: ['Dimanche', 'Lundi', 'Mardi', 'Mercredi', 'Jeudi', 'Vendredi', 'Samedi'],
                    dayNamesShort: ['Dim.', 'Lun.', 'Mar.', 'Mer.', 'Jeu.', 'Ven.', 'Sam.'],
                    dayNamesMin: ['D', 'L', 'M', 'M', 'J', 'V', 'S'],
                    weekHeader: 'Sem.',
                    dateFormat: 'dd-mm-yy',
                    onSelect: function (dateText) {
                        document.getElementById("ContentPlaceHolder1_date").value = $(this).val();
                    }


                }).attr('readonly', 'readonly');

            $('#timepicker1').on('changeTime', function () {
                document.getElementById("ContentPlaceHolder1_time1").value = $(this).val();
            });

            $('#timepicker2').on('changeTime', function () {
                document.getElementById("ContentPlaceHolder1_time2").value = $(this).val();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row pb-3">
        <div class="col-lg-12">
            <h1>Disponibilités</h1>
        </div>
    </div>

    <div id="ActivationValidation" runat="server">
        Vous devez activer le module <b>« Module des prises de rendez-vous »</b> afin d'avoir accès à cette section.
    </div>

    <div id="PageContent" runat="server">
        <div class="row">
            <div class="col-lg-3">
                <label for="datepicker">Date:</label>
                <input type="text" id="datepicker" class="form-control" autocomplete="off" />
            </div>
            <div class="col-lg-3">
                <label for="timepicker1">Heure Début:</label>
                <input id="timepicker1" type="text" class="time ui-timepicker-input form-control" autocomplete="off" />
            </div>
            <div class="col-lg-3">
                <label for="timepicker2">Heure Fin:</label>
                <input id="timepicker2" type="text" class="time ui-timepicker-input form-control" autocomplete="off" />
            </div>
            <div class="col-lg-3 align-bottom">
                <label> </label><br />
                <asp:Button ID="Ajouter" Text="Ajouter" runat="server" OnClick="Ajouter_Click" CssClass="btn btn-success" Style="width: 100%; float:none; vertical-align:bottom" />
            </div>
        </div>
        <div class="row pb-3 text-center">
        </div>
        <asp:HiddenField ID="date" runat="server" />
        <asp:HiddenField ID="time1" runat="server" />
        <asp:HiddenField ID="time2" runat="server" />
        <div class="row pb-3">
            <div class="col-sm-12">
                <asp:Label runat="server" ID="emsg01"></asp:Label>
            </div>
        </div>
        <div class="row pb-3">
            <div class="col-sm-12">
                <asp:Table runat="server" ID="tabAvail" aria-describedby="dataTable_info" CssClass="table table-bordered table-hover dataTable dataUsers">
                    <asp:TableHeaderRow ID="headerRowAvail" runat="server" >
                        <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Heure début</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Heure fin</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Supprimer</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="additionalJS" runat="server">
    <script src="//cdnjs.cloudflare.com/ajax/libs/underscore.js/1.7.0/underscore-min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.8.4/moment.min.js"></script>
    <script src="Javascript/bootstrap-datepicker.min.js"></script>
    <link href="CSS/jquery.timepicker.min.css" rel="stylesheet" />
    <script src="Javascript/jquery.timepicker.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
</asp:Content>
