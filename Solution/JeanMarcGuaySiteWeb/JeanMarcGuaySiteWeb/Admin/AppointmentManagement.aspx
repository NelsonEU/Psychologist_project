﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AppointmentManagement.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.AppointmentManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row pb-3">
        <div class="col-lg-12">
            <h1>Gestion des rendez-vous</h1>
        </div>
    </div>

    <div id="ActivationValidation" runat="server">
        Vous devez activer le module <b>« Module des prises de rendez-vous »</b> afin d'avoir accès à cette section.
    </div>


    <div id="PageContent" runat="server">


        <div class="card mb-3" runat="server" id="cardUnconfirmed">
            <div class="card-header">
                <i class="fas fa-bullhorn"></i>Rendez-vous en attente
            </div>
            <div class="card-body container-fluid">
                <div class="">
                    <div id="dataTable_wrapper" class="dataTables_wrapper dt-bootstrap4">
                        <div class="form-row">
                            <div class="col-lg-4 col-md-12 form-group">
                                <input type="search" class="form-control" aria-controls="dataTable" placeholder="Rechercher" id="researchUser" />
                            </div>
                            <div class="offset-lg-2 col-lg-6 col-md-12 text-right">
                                <asp:Button class=" btn btn-danger" runat="server" Text="Refuser" ID="btnRefuser" OnClick="Click_Refuse" />
                                <asp:Button class=" btn btn-success" runat="server" Text="Confirmer" ID="btnConfirmer" OnClick="Click_Confirm" />
                            </div>
                        </div>
                        <div class="row" runat="server" visible="false" id="notifConfirme">
                            <div style="background-color: red">Les rendez-vous sélectionnés ont bien été confirmés.</div>
                        </div>
                        <div class="row" runat="server" visible="false" id="notifRefuse">
                            <div style="background-color: red">Les rendez-vous sélectionnés ont bien été refusés.</div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:Table runat="server" ID="tabUnconfirmed" aria-describedby="dataTable_info" CssClass="table table-bordered table-hover dataTable dataUsers">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Nom</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Prénom</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>E-mail</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Message</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Sélectionner</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="card mb-3" runat="server" id="cardConfirmed">
            <div class="card-header">
                <i class="fas fa-th-list"></i>Rendez-vous planifiés
            </div>
            <div class="card-body container-fluid">
                <div class="">
                    <div class="dataTables_wrapper dt-bootstrap4">
                        <div class="form-row">
                            <div class="col-lg-4 col-md-12 form-group">
                                <input type="search" class="form-control" aria-controls="dataTable" placeholder="Rechercher" id="researchConfirmed" />
                            </div>
                            <div class="offset-lg-2 col-lg-6 col-md-12 text-right">
                                <asp:Button class=" btn btn-danger" runat="server" Text="Annuler" ID="btnAnnuler" OnClick="Click_Cancel" />
                            </div>
                        </div>
                        <div class="row" runat="server" visible="false" id="notifAnnule">
                            <div style="background-color: red">Les rendez-vous sélectionnés ont bien été annulés.</div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:Table runat="server" ID="tabConfirmed" aria-describedby="dataTable_info" CssClass="table table-bordered table-hover dataTable dataUsers">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Nom</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Prénom</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>E-mail</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Message</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Sélectionner</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div runat="server" id="notifNoRdv">Pas de rendez-vous à afficher</div>

    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
