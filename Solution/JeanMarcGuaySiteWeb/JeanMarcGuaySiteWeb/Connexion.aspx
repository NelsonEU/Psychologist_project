<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Connexion.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Connexion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="connexion">
        <asp:Panel ID="panelConnexion" runat="server" DefaultButton="submit">
            <h3>Se connecter</h3>
            <label for="email">Votre adresse e-mail:</label>
            <div>
                <asp:TextBox runat="server" type="email" placeholder="E-mail" ID="email" name="email" required="required"></asp:TextBox>
            </div>
            <label for="password">Votre mot de passe:</label>
            <div>
                <asp:TextBox runat="server" type="password" placeholder="••••••••" ID="password" name="password" required="required"></asp:TextBox>
            </div>
            <asp:Button ID="submit" Text="Se connecter" runat="server" OnClick="Submit_click" />
            <div>
                Pas encore de compte ? <a href="Inscription.aspx">Cliquez ici !</a>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
