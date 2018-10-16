<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JeanMarcGuaySiteWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
        <div class="banner">
           <div class="va-center">
                <h1 class="titleBanner">Jean-Marc Guay</h1>
                <h5 class="titleBanner">Psychologue</h5>
            </div>
        </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div id="accueil">
        <div class="pb-5">
            <div class="container">
                <div class="row pb-5">
                    <div class="col-md-12">
                        <div class="text-center">
                            <h1>Cabinet de psychologie</h1>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-sm-12">
                        <h2>A propos</h2>
                        <ul>
                            <li>Psychologue clinicien</li>
                            <li>Practicien en programmation neuro-linguistique</li>
                            <li>Professeur</li>
                        </ul>
                    </div>
                    <div class="col-md-6 col-sm-12">
                        <h2>Mes services</h2>
                        <ul>
                            <li>Therapie breve et a long terme</li>
                            <li>Approche integrative</li>
                            <li>Developpement - Techniques - Comportement</li>
                        </ul>
                    </div>
                    <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12 text-center pt-3">
                        <a href="Connexion.aspx" class="btn mainButton">En savoir plus</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid bc-blue">
            <div class="pb-5">
                <div class="container">
                    <div class="row pt-5">
                        <h1>Approche preconisee</h1>
                    </div>
                    <div class="row">
                        <p>
                            L'approche preconisee au cabinet est celle d'une orientation integrative.<br />
                            Celle-ci permet d'utiliser des outils d'approches combinees telles que:
                        </p>

                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <ul>
                                <li>Analytique</li>
                                <li>Existentielle/humaniste</li>
                            </ul>
                        </div>
                        <div class="col-md-3">
                            <ul>
                                <li>Systemique/interactionnelle</li>
                                <li>Comportementale/cognitive</li>
                            </ul>
                        </div>
                    </div>
                    <div class="row">
                        <p class="long-text">De part ses connaissances theoriques et ses experiences professionelles, les interventions sont toujours accomodees en fonction des problemes et des personnes qu'il rencontre.</p>
                        <p>Le therapeute prendra en compte tant les spheres emotionnelles et cognitives que comportementales et sociales.</p>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">

    <script src="Javascripts/parallax.min.js"></script>

</asp:Content>

