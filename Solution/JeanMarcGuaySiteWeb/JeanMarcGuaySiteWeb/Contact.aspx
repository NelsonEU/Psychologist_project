<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">

    <div class="banner2 pb-5 shadow">
        <div class="va-center2">
            <h1 class="titleBanner2">Contactez-moi</h1>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid pt-5" runat="server" id="divConnexion">
        <div class="row pb-1 text-center pb-3">
            <div class="col-md-8 offset-md-2">
                <div class="row pb-5">
                    <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12 text-center">
                        <h3>Vous devez être connecté(e) pour avoir accès à cette fonctionnalité.</h3>
                    </div>
                </div>

                <div class="row pb-3">
                    <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12 text-center">
                        <a href="connexion.aspx" class="btn mainButton pr-5 pl-5">Se connecter</a>
                    </div>
                </div>

                <div class="row pb-3">
                    <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12 text-center">
                        <h5>&boxh;&boxh;&boxh;&nbsp; Ou &nbsp;&boxh;&boxh;&boxh;</h5>
                    </div>
                </div>

                <div class="row pb-3">
                    <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12 text-center">
                        <a href="inscription.aspx" class="btn mainButton pr-5 pl-5">S'inscrire</a>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <div class="container-fluid pt-5" runat="server" id="divContact">
        <div class="row pb-1 text-center">
            <div class="col-md-8 offset-md-2">
                <h3>Questions, commentaires, suggestions? N'hésitez pas à me contacter.</h3>
            </div>
        </div>
        <div class="row pb-5">
            <div class="col-md-8 offset-md-2 text-center">
                <h5>Au besoin, je vous répondrai par courriel. Ce service est totalement confidentiel!</h5>
            </div>
        </div>
        <div class="row pb-3">
            <div class="col-md-8 offset-md-2">
                <asp:TextBox runat="server" ID="txtSubject" class="form-control" MaxLength="40" placeholder="Sujet" required="required"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8 offset-md-2">
                <asp:TextBox ID="txtContent" TextMode="multiline" Columns="50" Rows="5" runat="server" MaxLength="500" ClientIDMode="Static" placeholder="Message" class="form-control" Style="resize: none;" required="required" />
            </div>
        </div>
        <div class="row ">
            <div class="col-md-8 offset-md-2 text-right form-text text-muted">
                <span>*Votre nom et courriel seront inscrits automatiquement. </span>
            </div>
        </div>
        <div class="row pb-3">
            <div class="col-md-8 offset-md-2 text-right" runat="server" id="nbCharacter">            
                <h5><span id="characters"></span><span>/500</span></h5>
            </div>
        </div>
        <div class="row pb-3">
            <div class="col-md-2 offset-md-5 text-center" runat="server" id="notification">
            </div>
        </div>
        <div class="row pb-3">
            <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12 text-center">
                <asp:Button runat="server" ID="buttonSubmit" Text="Envoyer" OnClick="buttonSubmitClick" CssClass="btn mainButton pr-5 pl-5" />
            </div>
        </div>

    </div>
    <!-- Footer  -->
    <footer class="footer fixed-bottom">
        <span>Jean-Marc Guay</span>
    </footer>
    <!-- Fin Footer -->

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
    <script src="Javascripts/Contact.js"></script>
</asp:Content>
