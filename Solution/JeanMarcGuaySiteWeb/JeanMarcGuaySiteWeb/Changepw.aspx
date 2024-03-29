﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Changepw.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Changepw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
    <div class="banner2 pb-5 shadow">
        <div class="va-center2">
            <h1 class="titleBanner2">Mon compte</h1>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid rdv" runat="server">
        <div class="row">
            <div class="col-lg-6 offset-lg-3 text-center pt-3">
                <h3>Changement de mot de passe</h3>
            </div>
        </div>
        <div class="row text-center pt-4">
            <div class="col-lg-6 offset-lg-3">
                <label for="txtOldPassword">Mot de passe actuel:</label>
                <asp:TextBox runat="server" class="form-control" type="Password" placeholder="Votre mot de passe actuel" ID="txtOldPassword" name="oldpassword" required="required" MaxLength="40"></asp:TextBox>
            </div>
        </div>

        <div class="row text-center pt-4">
            <div class="col-lg-6 offset-lg-3">
                <label for="txtNewPassword">Nouveau mot de passe:</label>
                <asp:TextBox runat="server" class="form-control" type="Password" placeholder="Nouveau mot de passe" ID="txtNewPassword" name="newpassword" required="required" MaxLength="40"></asp:TextBox>
            </div>
        </div>

        <div class="row text-center pt-4 pb-4">
            <div class="col-lg-6 offset-lg-3">
                <label for="txtNewPassword2">Confirmation:</label>
                <asp:TextBox runat="server" class="form-control" type="Password" placeholder="Confirmation du nouveau mot de passe" ID="txtConfirm" name="confirm" required="required" MaxLength="40"></asp:TextBox>
            </div>
        </div>

        <div class="row text-center pt-1">
            <div class="col-lg-12">
                <asp:Button runat="server" ID="btnConfirm" CssClass="btn mainButton3" Text="Confirmer" Style="width: 300px" OnClick="btnConfirm_Click" />
            </div>
        </div>

       <div runat="server" class="text-center mt-2" id="notification" visible="false">
       </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
