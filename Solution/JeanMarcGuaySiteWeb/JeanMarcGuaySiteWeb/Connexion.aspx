<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Connexion.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Connexion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <div class="container">
            <div class="login-form">
                <asp:Panel ID="panelConnexion" runat="server" DefaultButton="submit">
                    <img class="mb-4" src="Images/logoOriginal.png" alt="" width="72" height="72" />
                    <h3 class="h3 mb-3 font-weight-normal">Se connecter</h3>
                    <label for="email" class="sr-only">Votre adresse e-mail:</label>
                    <div>
                        <asp:TextBox runat="server" class="form-control" type="email" placeholder="E-mail" ID="email" name="email" required="required"></asp:TextBox>
                    </div>
                    <label for="password" class="sr-only">Votre mot de passe:</label>
                    <div>
                        <asp:TextBox runat="server" class="form-control" type="password" placeholder="••••••••" ID="password" name="password" required="required"></asp:TextBox>
                    </div>
                    <div runat="server" id="notification" visible="false">
                    </div>
                    <asp:Button ID="submit" class="btn btn-lg btn-primary btn-block" Text="Se connecter" runat="server" OnClick="Submit_click" />
                    <div>
                        Pas encore de compte ? <a href="Inscription.aspx">Cliquez ici !</a>
                    </div>
                </asp:Panel>
            </div>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
