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
                        <p>Membre de l'Ordre des Psychologues du Québec, Jean-Marc Guay est un psychologue clinicien de la région du Saguenay. En plus d'être practicien en programmation neuro-linguistique, il est également professeur de psychologie.</p>
                    </div>
                    <div class="row pt-3 divAnimation1">
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
        <div class="container-fluid bc-blue" id="divTrigger">
            <div class="pb-5">
                <div class="container biggerBox">
                    <div class="row pt-5">
                        <h2 class="underline2 animated" id="h2Approche">Approche preconisée</h2>
                    </div>
                    <div class="animated animatedWA slow">
                    <div class="row pt-3 slow">
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
                    <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12 text-center pt-3">
                        <a href="Services.aspx" id="btnEnSavoirPlus" class="btn mainButton2 slow animated">En savoir plus</a>
                    </div>
                        </div>
                </div>
            </div>
        </div>

        <div class="container biggerBox">
            <div class="row pt-5">
                <h2 class="underline1" id="h2Publications">Publications</h2>
            </div>
            <div id="carouselCategories" class="carousel_categorie pt-3">
                <div class="text-center text-secondary">
                    <asp:ImageButton runat="server" ImageUrl="Images/stress.jpg" class="imageCarousel mb-2" />
                    <a class="link-carousel text-secondary" href="Publications.aspx">
                        <h2>Stress</h2>
                    </a>
                </div>
                <div class="text-center text-secondary">
                    <asp:ImageButton runat="server" ImageUrl="Images/troubleSommeil.jpg" class="imageCarousel mb-2" />
                    <a class="link-carousel text-secondary" href="Publications.aspx">
                        <h2>Trouble du sommeil</h2>
                    </a>
                </div>
                <div class="text-center text-secondary">
                    <asp:ImageButton runat="server" ImageUrl="Images/phobie.jpg" class="imageCarousel mb-2" />
                    <a class="link-carousel text-secondary" href="Publications.aspx">
                        <h2>Phobie</h2>
                    </a>
                </div>
                <div class="text-center text-secondary">
                    <asp:ImageButton runat="server" ImageUrl="Images/depression.jpg" class="imageCarousel mb-2" />
                    <a class="link-carousel text-secondary" href="Publications.aspx">
                        <h2>Dépression</h2>
                    </a>
                </div>
                <div class="text-center text-secondary">
                    <asp:ImageButton runat="server" ImageUrl="Images/anxiete.jpg" class="imageCarousel mb-2" />
                    <a class="link-carousel text-secondary" href="Publications.aspx">
                        <h2>Anxiete</h2>
                    </a>
                </div>
            </div>
        </div>



    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
    <script type="text/javascript" src="http://cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/waypoints/4.0.1/jquery.waypoints.min.js"></script>
    <script src="Javascripts/Carousel.js"></script>
    <script src="Javascripts/parallax.min.js"></script>

</asp:Content>

