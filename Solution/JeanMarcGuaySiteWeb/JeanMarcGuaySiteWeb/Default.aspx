<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JeanMarcGuaySiteWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.7.0/animate.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
    <div class="banner shadow">
        <div class="va-center animated fadeIn slow">
            <h1 class="titleBanner">Jean-Marc Guay</h1>
            <h5 class="titleBanner">Psychologue</h5>
        </div>
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="accueil">
        <div class="container-fluid">
            <div class="pb-5">
                <div class="container biggerBox">
                    <div class="row">
                        <h2 class="underline1" id="h2Apropos">À propos</h2>
                    </div>

                    <div class="row pt-3 divAnimation1">
                        <p>Membre de l'Ordre des Psychologues du Québec, Jean-Marc Guay est un psychologue clinicien de la région du Saguenay. En plus d'être praticien en programmation neuro-linguistique, il est également professeur de psychologie.</p>
                    </div>
                    <div class="row pt-3 divAnimation1" id="paraTrigger">
                        <p>Vous trouverez sur ce site différentes informations concernant la psychotérapie ainsi que tous les services offerts par le psychologue. Les publications de Jean-Marc sont également mises à votre disposition et sont disponibles dans la section « <a href="Publications.aspx">Publications</a> ».</p>
                    </div>
                    <div class="row pt-3 divAnimation1">
                        <p id="pTrigger">Vous êtes également invités à vous créer un compte sur le site. Cela vous permettra de pouvoir contacter le practicien et, si vous le souhaitez, de vous abonner à ses publications.</p>
                    </div>
                    <div class="row pt-3 divAnimation1">
                        <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12 text-center pt-3">
                            <a href="Inscription.aspx" class="btn mainButton">Créer un compte</a>
                        </div>
                    </div>
                </div>
            </div>

        </div>

         <div class="container-fluid bc-blue evenBiggerBox" id="evenBiggerBox">
            <div class="container divAnimation3 animated slow">
                <div class="row">
                    <!-- Texte -->
                    <div class="col-md-6">
                        <div class="bigSquare">
                            <div class="sq square1"></div>
                            <br />
                            <div class="sq square2"></div>
                            <div class="sq square3"></div>
                            <br />
                            <div class="sq square4"></div>
                            <div class="sq square5"></div>
                            <div class="sq square6"></div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div>
                            <div class="col-md-11" style="padding: 0px 0px 0px 0px;">
                                <h2 class="underline2">N'attendez pas pour consulter</h2>
                            </div>
                        </div>
                        <p id="triggerAnimationCarousel" class="pt-3">La plus grande marque de respect que vous pouvez porter à votre égard est de reconnaître que vous avez besoin d'aide. Le plus beau geste d'amour pour soi et pour les siens est de se donner la liberté de mettre de son côté toutes les chances de s’en sortir.</p>
                        <p>
                            D’une certaine façon, attendre à la dernière minute revient à épuiser les forces disponibles qui pourraient être utilisées en psychothérapie et servir à prévenir une détresse psychologique.
                        </p>
                    </div>
                </div>
                <div id="paraTrigger2"></div>
            </div>
            <div id="paraTrigger3"></div>
        </div>

        <div class="container biggerBox pb150">
            <div class="row pt-5">
                <h2 class="underline1 animated slow" id="h2Publications">Publications</h2>
            </div>
            <div id="carouselCategories" class="carousel_categorie pt-3" runat="server">

            </div>
        </div>


    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/waypoints/4.0.1/jquery.waypoints.min.js"></script>
    <script src="Javascripts/Carousel.js"></script>
    <script src="Javascripts/animation.js"></script>
    <script src="Javascripts/slick.min.js"></script>
</asp:Content>

