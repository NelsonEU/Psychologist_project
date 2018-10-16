<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activation.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Activation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container space-medium pt-4">
        <div class="row">
            <h1>Votre compte est actif !</h1>
        </div>
        <div class="row">
            <h5>Bienvenue !</h5>
        </div>
        <div class="row">
            <p>Votre compte est maintenant activé.</p>
        </div>
        <div class="row">
            <p>Vous pouvez des a present vous connecter:</p>
        </div>
        <div class="container">
            <a href="Connexion.aspx" class="btn btn-primary">Se connecter</a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
