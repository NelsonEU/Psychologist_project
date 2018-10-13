<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row text-center pt-3">
        <div class="col-lg-12">
            <h4>Le message à été envoyé!</h4>
        </div>
    </div>
    <div class="row text-center pt-3">
        <div class="col-md-2 offset-md-5">
            <asp:Button ID="buttonSubmit" runat="server" Text="Retour à l'accueil" CssClass="form-control mainButton " OnClick="buttonSubmitClick" />
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
