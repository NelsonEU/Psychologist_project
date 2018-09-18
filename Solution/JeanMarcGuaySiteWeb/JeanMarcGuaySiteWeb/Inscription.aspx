<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Inscription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="inscription">
        <asp:Panel ID="panelInscription" runat="server" DefaultButton="submit">
            <h3>Créer un compte</h3>
            <label for="firstname">Votre prénom:</label>
            <div>
                <asp:TextBox runat="server" type="text" placeholder="Prénom" ID="firstname" name="firstname" required="required"></asp:TextBox>
            </div>
            <label for="lastname">Votre nom:</label>
            <div>
                <asp:TextBox runat="server" type="text" placeholder="Nom" ID="lastname" name="lastname" required="required"></asp:TextBox>
            </div>
            <label for="email">Votre adresse e-mail:</label>
            <div>
                <asp:TextBox runat="server" type="email" placeholder="E-mail" ID="email" name="email" required="required"></asp:TextBox>
            </div>
            <label for="password">Mot de passe:</label>
            <div>
                <asp:TextBox runat="server" type="password" placeholder="••••••••" ID="password" name="password" required="required"></asp:TextBox>
            </div>
            <label for="password">Confirmation du mot de passe:</label>
            <div>
                <asp:TextBox runat="server" type="password" ID="passwordConfirmation" name="password" required="required"></asp:TextBox>
            </div>
            <asp:Button ID="submit" Text="Se connecter" runat="server" OnClick="Submit_click"/>
        </asp:Panel>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
