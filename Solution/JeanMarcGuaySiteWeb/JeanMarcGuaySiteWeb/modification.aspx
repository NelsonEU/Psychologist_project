<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modification.aspx.cs" Inherits="JeanMarcGuaySiteWeb.modification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">

    <div class="banner2 pb-5 shadow">
        <div class="va-center2">
            <h1 class="titleBanner2">Modification du compte</h1>
        </div>
    </div>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid rdv" runat="server">
        <div class="row text-center pt-5">
            <div class="col-lg-6 offset-lg-3">
                <label for="txtFirstname">Prénom:</label>
                <asp:TextBox runat="server" class="form-control" type="text" placeholder="Prénom" ID="txtFirstname" name="firstname" required="required"></asp:TextBox>
            </div>
        </div>

        <div class="row text-center pt-4">
            <div class="col-lg-6 offset-lg-3">
                <label for="txtLastname">Nom:</label>
                <asp:TextBox runat="server" class="form-control" type="text" placeholder="Nom" ID="txtLastname" name="lastname" required="required"></asp:TextBox>
            </div>
        </div>

        <div class="row text-center pt-4">
            <div class="col-lg-6 offset-lg-3">
                <label for="txtEmail">Email:</label>
                <asp:TextBox runat="server" class="form-control" type="email" placeholder="Adresse email" ID="txtEmail" name="email" required="required"></asp:TextBox>
            </div>
        </div>

        <div class="row text-center pt-4">
            <div class="col-lg-6 offset-lg-3">
                    <label for="birthday">Date de naissance:</label>
                    <asp:TextBox runat="server" class="form-control" ID="birthday" ClientIDMode="Static" name="birthday" AutoCompleteType="Disabled" Style="background: white;" required="required" type="text" placeholder="Date de naissance"></asp:TextBox>
            </div>
        </div>

        <div class="row text-center pt-4">
            <div class="col-lg-6 offset-lg-3">
                <asp:CheckBox runat="server" ID="chkSubscription" Text="Abonné(e) aux publications" />
            </div>
        </div>

        <div class="row text-center pt-5">
            <div class="col-lg-12">
                <asp:Button runat="server" ID="btnConfirmer" CssClass="btn mainButton3" text="Confirmer" style="width:200px" OnClick="btnConfirmer_Click"/>
            </div>
        </div>

        <div class="row text-center pt-5">
            <div class="col-lg-12">
                <asp:Button runat="server" ID="btnMDP" CssClass="btn btn-warning" text="Changer de mot de passe" style="width:300px" OnClick="btnMDP_Click" />

            </div>
        </div>

        <div class="row text-center pt-1">
            <div class="col-lg-12">
                <asp:Button runat="server" ID="bntSuppr" CssClass="btn btn-danger" text="Demander la suppression du compte" style="width:300px" OnClick="bntSuppr_Click" />
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="Javascripts/Inscription.js"></script>
</asp:Content>
