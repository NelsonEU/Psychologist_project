<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activation.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Activation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container space-medium pt-4">
        <div class="row text-center paddingNav2">
            <div class="col-lg-12">
                <h1>Votre compte a été activé avec succès!</h1>
            </div>
        </div>
        <div class="row text-center pt-5">
            <div class="col-lg-12">
                <h5>Bienvenue!</h5>
            </div>
        </div>
        <div class="row text-center">
            <div class="col-lg-12">
                <span>Vous pouvez maintenant vous connecter.</span>
            </div>
        </div>
        <div class="row text-center pt-5">
            <div class="col-lg-12">
                <a href="Connexion.aspx" class="btn mainButton">Se connecter</a>
            </div>
        </div>
    </div>
    <!-- Footer  -->
    <footer class="footer fixed-bottom">
        <span>Jean-Marc Guay</span>
    </footer>
    <!-- Fin Footer -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
