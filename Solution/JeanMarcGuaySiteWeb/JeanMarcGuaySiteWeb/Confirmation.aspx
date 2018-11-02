<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row text-center pt-3 paddingNav2">
        <div class="col-lg-12">
            <h4>Le message à été envoyé!</h4>
        </div>
    </div>
    <div class="row text-center pt-3 pb-5">
        <div class="col-md-2 offset-md-5">
            <asp:Button ID="buttonSubmit" runat="server" Text="Retour à l'accueil" CssClass="btn mainButton " OnClick="buttonSubmitClick" />
        </div>
    </div>

    <!-- Footer  -->
    <footer class="footer">
        <span>Jean-Marc Guay</span>
    </footer>
    <!-- Fin Footer -->

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
