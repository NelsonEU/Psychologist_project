<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modification.aspx.cs" Inherits="JeanMarcGuaySiteWeb.modification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">

    <div class="banner2 pb-5 shadow">
        <div class="va-center2">
            <h1 class="titleBanner2">Modification du compte</h1>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

        <div class="row text-center">
            <div class="col-lg-12">
                prenom
            </div>
        </div>

        <div class="row text-center">
            <div class="col-lg-12">
                nom
            </div>
        </div>

        <div class="row text-center">
            <div class="col-lg-12">
                courriel
            </div>
        </div>

        <div class="row text-center">
            <div class="col-lg-12">
                date de naissance
            </div>
        </div>

        <div class="row text-center">
            <div class="col-lg-12">
                Confirmer
            </div>
        </div>

        <div class="row text-center">
            <div class="col-lg-12">
                Changer de mot de passe
            Demande suppression du compte
            </div>
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
