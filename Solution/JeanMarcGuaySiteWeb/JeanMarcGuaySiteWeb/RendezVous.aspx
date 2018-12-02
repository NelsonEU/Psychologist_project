<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RendezVous.aspx.cs" Inherits="JeanMarcGuaySiteWeb.RendezVous" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">

    <div class="banner2 pb-5 shadow">
        <div class="va-center2">
            <h1 class="titleBanner2">Rendez-vous</h1>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="rdv">

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

        <div class="container-fluid pt-5" runat="server" id="divRenseignement">
            <!-- Cette section apparait lorsque l'utilisateur est connecté et non-autorisé -->
            <div class="row">
                <div class="col-md-8 offset-md-2 col-sm-12 text-center">
                    <h3>Vous n'êtes pas autorisé(e) à prendre rendez-vous.</h3>
                    <h5>Un utilisateur doit être manuellement autorisé par le psychologue afin de pouvoir prendre rendez-vous.</h5>

                    <div runat="server" id="divContact" class="pt-5">
                        <asp:Button ID="btnRedirection" runat="server" Text="Contactez-moi" CssClass="btn mainButton " OnClick="btnRedirection_Click" />
                    </div>
                </div>
            </div>
        </div>

        <div class="container-fluid pt-5" runat="server" id="divRendezVous">
            <!-- Cette section apparait lorsque l'utilisateur est connecté et autorisé -->
            <div class="row">
                <div class="col-md-8 offset-md-2 col-sm-12 text-center">
                    <h3>Prendre rendez-vous avec Jean-Marc Guay</h3>
                    <h5 class="pt-3"><b>Attention:</b> le rendez-vous n'est pas confirmé tant que vous n'avez pas reçu un email de confirmation. <i id="tooltipImage" class="far fa-question-circle mainAdminColor biggerbiggerText" title="Si vous n'avez pas reçu de email de confirmation la journée du rendez-vous, ne vous présentez pas. N'oubliez pas de vérifier vos spams"></i></h5>
                </div>
            </div>

            <div class="row pt-5">
                <div class="col-md-4 offset-md-2 col-sm-12 text-center">
                    <asp:Label runat="server" ID="Label1"><b>Date:</b></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlDate" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged" style="width:100%;"></asp:DropDownList>
                </div>
                <div class="col-md-4 col-sm-12 text-center">
                    <asp:Label runat="server" ID="Label3"><b>Heure:</b></asp:Label>
                    <asp:DropDownList runat ="server" ID="ddlHeureDebut" CssClass="form-control" style="width:100%;"></asp:DropDownList>
                </div>
            </div>

            <div class="row pt-4">
                <div class="col-md-8 offset-md-2">
                    <asp:TextBox ID="txtContent" TextMode="multiline" Columns="50" Rows="5" runat="server" MaxLength="200" ClientIDMode="Static" placeholder="Vous pouvez laisser un message ou une note (optionnel)" class="form-control" Style="resize: none;" />
                </div>
            </div>

            <div class="row pb-3">
                <div class="col-md-8 offset-md-2 text-right form-text text-muted">
                    <span>*Vos informations seront inscrits automatiquement. </span>
                </div>
            </div>

            <div class="row pb-3">
                <div class="col-md-8 offset-md-2 text-right" runat="server" id="nbCharacter">
                    <h5><span id="characters"></span><span>/200</span></h5>
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

        <div class="container-fluid pt-5" runat="server" id="divRendezVousPris">
            <!-- Cette section apparait lorsque l'utilisateur est connecté, autorisé et a déjà un rendez-vous actif -->
            <div class="row">
                <div class="col-md-8 offset-md-2 col-sm-12 text-center">
                    <!-- <h3>Vous n'êtes pas autorisé(e) à prendre rendez-vous.</h3>
                    <h5>Un utilisateur doit être manuellement autorisé par le psychologue afin de pouvoir prendre rendez-vous.</h5>

                    <div runat="server" id="div2" class="pt-5">
                        <asp:Button ID="Button1" runat="server" Text="Contactez-moi" CssClass="btn mainButton " OnClick="btnRedirection_Click" />
                    </div> -->
                </div>
            </div>
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
    <script src="Javascripts/RendezVous.js"></script>
</asp:Content>
