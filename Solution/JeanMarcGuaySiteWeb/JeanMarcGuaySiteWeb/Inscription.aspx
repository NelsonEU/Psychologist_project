<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Inscription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="inscription">
        <asp:Panel ID="panelInscription" runat="server" DefaultButton="submit">
            <div class="container">
                <div class="row">
                    <div class="col-sm-9 col-md-7 col-lg-5 mx-auto">
                        <div class="card card-signin my-5">
                            <div class="card-body">
                                <div class="text-center">
                                    <img class="mb-4" src="Images/logoOriginal.png" alt="" width="72" height="72" />
                                </div>
                                <h3 class="card-title text-center">Créer un compte</h3>
                                <label for="firstname" class="sr-only mt-4">Votre prénom:</label>
                                <div>
                                    <asp:TextBox runat="server" class="form-control mt-4" type="text" placeholder="Prénom" ID="firstname" name="firstname" required="required"></asp:TextBox>
                                </div>
                                <label for="lastname" class="sr-only mt-2">Votre nom:</label>
                                <div>
                                    <asp:TextBox runat="server" class="form-control mt-2" type="text" placeholder="Nom" ID="lastname" name="lastname" required="required"></asp:TextBox>
                                </div>
                                <label for="email" class="sr-only mt-2">Votre adresse e-mail:</label>
                                <div>
                                    <asp:TextBox runat="server" class="form-control mt-2" type="email" placeholder="Adresse e-mail" ID="email" name="email" required="required"></asp:TextBox>
                                </div>
                                <label for="password" class="sr-only mt-2">Mot de passe:</label>
                                <div>
                                    <asp:TextBox runat="server" class="form-control mt-2" type="password" placeholder="Mot de passe" ID="password" name="password" required="required"></asp:TextBox>
                                </div>
                                <label for="password" class="sr-only mt-2">Confirmation du mot de passe:</label>
                                <div>
                                    <asp:TextBox runat="server" class="form-control mt-2" type="password" placeholder="Confirmation du mot de passe" ID="passwordConfirmation" name="password" required="required"></asp:TextBox>
                                </div>
                                <div class="form-group text-center mt-2">
                                    <asp:Checkbox runat="server" tabindex="3" class="" name="subscriber" id="subscriber"/>
                                    <label for="remember">S'abonner aux publications</label>
                                </div>
                                <div runat="server" id="notification" visible="false">
                                </div>
                                <asp:Button ID="submit" class="mt-3 btn btn-lg btn-primary btn-block" Text="S'inscrire" runat="server" OnClick="Submit_click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
