<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Connexion.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Connexion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        /* Sinon le menu est invisible sur cette page */
        #mainNav {
            background-color: rgb(255,255,255,0.9) !important;
            box-shadow: 4px 7px 31px -8px rgba(0,0,0,0.75);
        }

        .nav-item a {
            color: rgb(29, 98, 128) !important;
        }
    </style>

    <div class="connexion">
        <asp:Panel ID="panelConnexion" runat="server" DefaultButton="submit">
            <div class="container">
                <div class="row paddingNav">
                    <div class="col-sm-9 col-md-7 col-lg-5 mx-auto">
                        <div class="card card-signin my-5">
                            <div class="card-body">
                                <div class="text-center">
                                    <img class="mb-4" src="Images/logoOriginal.png" alt="" width="72" height="72" />
                                </div>
                                <h3 class="card-title text-center">Accéder à votre compte</h3>

                                <label for="email" class="sr-only mt-4">Votre adresse e-mail:</label>
                                <div>
                                    <asp:TextBox runat="server" class="form-control mt-4" type="email" placeholder="Adresse e-mail" ID="email" name="email" required="required autofocus" MaxLength="50"></asp:TextBox>
                                </div>


                                <label for="password" class="sr-only mt-2">Votre mot de passe:</label>
                                <div>
                                    <asp:TextBox runat="server" class="form-control mt-2" type="password" placeholder="Mot de passe" ID="password" name="password" required="required" MaxLength="40"></asp:TextBox>
                                </div>

                                <div runat="server" class="text-center mt-2" id="notification" visible="false">
                                </div>
                                <asp:Button ID="submit" class="mt-4 btn btn-lg mainButton2 btn-block" Text="Se connecter" runat="server" OnClick="Submit_click" />
                                <div class="mt-2 mb-3">
                                    Pas encore de compte? <a href="Inscription.aspx">Cliquez ici !</a>
                                </div>
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
