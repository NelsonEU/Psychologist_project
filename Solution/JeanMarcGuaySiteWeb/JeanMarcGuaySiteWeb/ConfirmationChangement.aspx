<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmationChangement.aspx.cs" Inherits="JeanMarcGuaySiteWeb.ConfirmationChangement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        /* Sinon le menu est invisible sur cette page */
        #mainNav {
            background-color: rgb(255,255,255,0.9) !important;
            box-shadow: 4px 7px 31px -8px rgba(0,0,0,0.75);
        }

        .nav-item a {
            color: rgb(29, 98, 128) !important;
        }
    </style>
    <div class="row text-center pt-3 paddingNav2">
        <div class="col-lg-12">
            <h4>Vous informations ont été changées!</h4>
        </div>
    </div>
    <div class="row text-center pt-3 pb-5">
        <div class="col-md-2 offset-md-5">
            <asp:Button ID="buttonSubmit" runat="server" Text="Retour à l'accueil" CssClass="btn mainButton " OnClick="buttonSubmitClick" />
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
