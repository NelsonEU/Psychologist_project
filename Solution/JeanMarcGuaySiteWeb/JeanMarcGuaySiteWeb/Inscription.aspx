<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Inscription" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        /* Sinon le menu est invisible sur cette page */
        #mainNav{
            background-color: rgb(255,255,255,0.9) !important;
            box-shadow: 4px 7px 31px -8px rgba(0,0,0,0.75);
        }
        .nav-item a{
            color:rgb(29, 98, 128) !important;
        }
    </style>
    <div class="inscription">
        <asp:Panel ID="panelInscription" runat="server" DefaultButton="submit">
            <div class="container">
                <div class="row paddingNav">
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
                                <label for="birthday" class="sr-only mt-2">Votre date de naissance:</label>
                                <div>
                                    <asp:TextBox runat="server" class="form-control mt-2" ID="birthday" ClientIDMode="Static" name="birthday" AutoCompleteType="Disabled" Style="background: white;" required="required" type="text" placeholder="Date de naissance"></asp:TextBox>
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
                                    <asp:CheckBox runat="server" TabIndex="3" class="" name="subscriber" ID="subscriber" />
                                    <label for="remember">S'abonner aux publications</label>
                                </div>
                                <div runat="server" id="notification" visible="false">
                                </div>
                                <asp:Button ID="submit" class="mt-3 btn btn-lg mainButton2 btn-block" Text="S'inscrire" runat="server" OnClick="Submit_click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
    <!-- Footer  -->
    <footer class="footer absolute">
        <span>Jean-Marc Guay</span>
    </footer>
    <!-- Fin Footer -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="Javascripts/Inscription.js"></script>
</asp:Content>
