﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AvailabilityManagement.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.AvailabilityManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script> 
        $(document).ready(function () {
            $('#timepicker1').timepicker({
                'disableTimeRanges': [
                ]
            });
            $('#timepicker2').timepicker({
                'disableTimeRanges': [
                ]
            });
            $("#datepicker").datepicker(
                {
                    onSelect: function (dateText) {
                        document.getElementById("ContentPlaceHolder1_date").value = $(this).val();
                    }

                });

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
        <div id="ActivationValidation" runat="server">
        Vous devez activer le module <b>« Module des prises de rendez-vous »</b> afin d'avoir accès à cette section.
    </div>

    <div id="PageContent" runat="server">
        <div class="row pb-3">
            <div class="col-lg-12">
            <h1>Disponibilités</h1>
        </div>
        </div>
        <div class="row">
            <p>Date: <input type="text" id="datepicker"/>Heure Début: <input id="timepicker1" type="text" class="time ui-timepicker-input" autocomplete="off"/>Heure Fin:<input id="timepicker2" type="text" class="time ui-timepicker-input" autocomplete="off"/> <asp:Button id="Ajouter" Text="Submit" runat="server" OnClick="Ajouter_Click" /></p> 
            <asp:HiddenField ID="date" runat="server" />  
            <asp:HiddenField ID="time1" runat="server" />  
            <asp:HiddenField ID="time2" runat="server" />  
        </div>
        <div class="row">
            <div class="col-sm-12">
                <asp:Table runat="server" ID="tabAvail" aria-describedby="dataTable_info" CssClass="table table-bordered table-hover dataTable dataUsers">
                    <asp:TableHeaderRow>
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
    <link href="CSS/bootstrap-timepicker.css" rel="stylesheet" />
    <script src="Javascript/bootstrap-datepicker.js"></script>
    <link href="CSS/jquery.timepicker.min.css" rel="stylesheet" />
    <script src="Javascript/jquery.timepicker.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
</asp:Content>
