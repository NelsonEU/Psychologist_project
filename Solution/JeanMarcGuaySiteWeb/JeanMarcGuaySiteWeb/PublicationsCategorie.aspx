<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PublicationsCategorie.aspx.cs" Inherits="JeanMarcGuaySiteWeb.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
    <div class="banner2 pb-5 shadow">
        <div class="va-center2">
            <h1 class="titleBanner2">Publications</h1>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="publications">
        <div class="container mt-4 mb-4">
            <div class="row">              
                <h2 class="underline1 m-4 text-left" id="titreCategorie" runat="server"></h2>
            </div>
            <div id="divNotif" runat="server">              
                <div class="row">
                    <div class="col-sm-2 mt-2 mb-1">
                        <a href="Publications.aspx" class="btn mainButton3">Retour aux catégories</a>
                    </div>
                </div>
                <div class="row ml-1 mt-2 mb-2" runat="server">
                    <div id="notif">
                        <p>Il n'y a pas encore de publication pour cette catégorie</p>
                    </div>
                </div>
            </div>
            <div id="divPublications" runat="server">
                <div class="row mb-3">
                    <div class="col-sm-2 mb-1">
                        <a href="Publications.aspx" class="btn mainButton3">Retour aux catégories</a>
                    </div>
                    <div class="input-group stylish-input-group offset-sm-4 col-sm-6 col-xs-12">
                        <input type="text" class="form-control" placeholder="Rechercher" id="searchPublications" />
                    </div>
                </div>

                <div class="row" id="publicationsPortfolio" runat="server" style="margin-top: 75px;">
                </div>
                <!--
            <table class="table table-hover" id="tablePublications" runat="server">
            </table>
            -->
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
    <script src="Javascripts/Publications.js"></script>
</asp:Content>
