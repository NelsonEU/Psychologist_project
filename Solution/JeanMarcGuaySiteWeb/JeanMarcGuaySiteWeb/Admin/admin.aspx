<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row align-item-center">

        <div class="col-md box-admin box-shadow" id="divRDV" runat="server" ClientIDMode="static">
            <h5>Gestion des <br /><span class="highlightH4">Rendez-vous</span></h5><br />
            <p>Page permettant de <b>Visualiser, Confirmer ou Annuler</b> des rendez-vous.</p>
        </div>

        <div class="col-md box-admin box-shadow" id="divDispo" runat="server" ClientIDMode="static">
            <h5>Gestion des <br /><span class="highlightH4">Disponibilités</span></h5><br />
            <p>Page de <b>Gérer</b> les disponibilités pour les rendez-vous</p>
        </div>

    </div>

    <div class="row align-item-center">

        <div class="col-md box-admin box-shadow" id="divPubli" runat="server" ClientIDMode="static">
            <h5>Gestion des <br /><span class="highlightH4">Publications</span></h5><br />
            <p>Pages permettant d’<b>Ajouter ou Supprimer</b> des <b>documents de format PDF</b> afin de les rendre accessibles à tous les utilisateurs. Permet aussi de gérer les <b>catégories</b> </p>
        </div>

        <div class="col-md box-admin box-shadow" id="divContact" runat="server" ClientIDMode="static">
            <h5>Gestion des <br /><span class="highlightH4">Contacts</span></h5><br />
            <p>Page permettant de <b>Visualiser</b> la liste des <b>contacts</b> récents</p>
        </div>

        <div class="col-md box-admin box-shadow" id="divUtili" runat="server" ClientIDMode="static">
            <h5>Gestion des <br /><span class="highlightH4">Utilisateurs</span></h5><br />
            <p>Page permettant de <b>Visualiser</b> la liste des utilisateurs et permet de performer des actions telque: <b>Autoriser ou Supprimer</b> des utilisateurs</p>
        </div>

        <div class="col-md box-admin box-shadow" id="divModules" runat="server" ClientIDMode="static">
            <h5>Gestion des <br /><span class="highlightH4">Modules</span></h5><br />
            <p>Page permettant d'<b>Activer ou Désactiver</b> les différents modules</p>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="additionalJS" runat="server">
    <script src="Javascript/pageadmin.js"></script>
</asp:Content>
