<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RendezVous.aspx.cs" Inherits="JeanMarcGuaySiteWeb.RendezVous" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">

    <div class="banner2 pb-5 shadow">
        <div class="va-center2">
            <h1 class="titleBanner2">Rendez-vous</h1>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="rdv">
        <div class=" pb-1 pt-1 text-center" runat="server" id="divDev">
            <span><b>Cette section est en cours de développement</b></span>
        </div>

        <div class="container-fluid pt-5" runat="server" id="divConnexion">
            <div class="row pb-1 text-center pb-3">
                <div class="col-md-8 offset-md-2">
                    <div class="row pb-5">
                        <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12 text-center">
                            <h3>Vous devez être connecté(e) pour avoir accès à cette fonctionnalité.</h3>
                        </div>
                    </div>

                    <div class="row pb-3">
                        <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12 text-center">
                            <a href="connexion.aspx" class="btn mainButton pr-5 pl-5">Se connecter</a>
                        </div>
                    </div>

                    <div class="row pb-3">
                        <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12 text-center">
                            <h5>&boxh;&boxh;&boxh;&nbsp; Ou &nbsp;&boxh;&boxh;&boxh;</h5>
                        </div>
                    </div>

                    <div class="row pb-3">
                        <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12 text-center">
                            <a href="inscription.aspx" class="btn mainButton pr-5 pl-5">S'inscrire</a>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <div class=" pb-5 text-center" style="padding-top: 125px;" runat="server" id="divRenseignement">
            <span>
                <p class="text-center">Cette section apparait lorsque l'utilisateur est connecté et non-autorisé (Renseignements (Vous devez d'abord avoir été autorisé...))</p>
            </span>
        </div>

        <div class=" pb-5 text-center" style="padding-top: 125px;" runat="server" id="divRendezVous">
            <span>
                <p class="text-center">Cette section apparait lorsque l'utilisateur est connecté et autorisé</p>
            </span>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
