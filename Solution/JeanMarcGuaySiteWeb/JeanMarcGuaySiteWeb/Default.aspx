<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JeanMarcGuaySiteWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.7.0/animate.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
    <div class="banner shadow">
        <div class="va-center animated fadeIn slow">
            <h1 class="titleBanner">Jean-Marc Guay</h1>
            <h5 class="titleBanner">Psychologue, M.A.Ps</h5>
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
                        <p>Vous trouverez sur ce site différentes informations concernant la psychotérapie ainsi que tous les services offerts par le psychologue. Différentes publications sous forme de documents PDF sont également mises à votre disposition dans la section « <a href="Publications.aspx">Publications</a> ».</p>
                    </div>
                    <div class="row pt-3 divAnimation1">
                        <p id="pTrigger">Vous êtes également invités à vous créer un compte sur le site. Cela vous permettra de pouvoir contacter le practicien et, si vous le souhaitez, de vous abonner aux publications.</p>
                    </div>
                    <div class="row pt-3 divAnimation1">
                        <div runat="server" id="divButtonCompte" class="col-lg-12 col-sm-12 col-md-12 col-xs-12 text-center pt-3">
                            <a href="Inscription.aspx" class="btn mainButton">Créer un compte</a>
                        </div>
                        <div runat="server" id="divButtonSavoir" class="col-lg-12 col-sm-12 col-md-12 col-xs-12 text-center pt-3">
                            <a href="Services.aspx" class="btn mainButton">En savoir plus</a>
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

        <div class="container biggerBox" runat="server" id="divCarouselOuvert">
            <div class="row pt-5">
                <h2 class="underline1 animated slow" id="h2Publications">Publications</h2>
            </div>
            <div id="carouselCategories" class="carousel_categorie pt-3 animated slow" runat="server" ClientIDMode="static">

            </div>
        </div>

        <div class="container evenBiggerBox" runat="server" id="divCarouselFermer" ClientIDMode="static">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="row">
                            <h2 class="underline1 animated slow" id="h2Pourquoi">Pourquoi consulter?</h2>
                        </div>
                        <div class="row pt-3" id="divCarouselFermerTexte">
                            <p>L’un des premiers raisonnements que les gens font lorsqu’ils se rendent compte ou se font dire qu’ils ont besoin d’aide, est de croire qu’ils sont faibles ou inférieurs. En réalité, cela n’a rien à voir puisqu’il peut arriver à tout le monde de vivre à un moment donné des difficultés internes et externes qui dépassent ses capacités d’adaptation. Cet état de fait a souvent pour conséquence de modifier à différents niveaux, l’équilibre interne et externe de la personne.</p>
                            <p>Le deuxième raisonnement qui est souvent constaté est celui où la personne se demande si elle est devenue anormale. Il est admis que des idées et des émotions latentes peuvent refaire surface, interférer dans le fonctionnement du métabolisme et s’exprimer pour certains, en douleurs physiques.</p>
                            <p>Finalement, il arrive que d’autres personnes croient que leur mal n’existe pas ou qu’elles souffrent d’une maladie imaginaire. Habituellement, c’est votre médecin qui vous dira le premier que votre problème est psychologique. Mieux que quiconque, il sait que votre souffrance est réelle et légitime. Il est aussi conscient que vous ressentez sincèrement un malaise intérieur, mais il croit que vous devriez rencontrer un psychologue. C’est cette personne qualifiée qui saura vous aider à traverser les difficultés qui se présentent à vous.</p>
                        </div>
                    </div>
                </div>
            </div>

        <!--
        <div class="container biggerBox" runat="server" id="divNonCarousel">

        </div>
        -->

    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/waypoints/4.0.1/jquery.waypoints.min.js"></script>
    <script src="Javascripts/Carousel.js"></script>
    <script src="Javascripts/animation.js"></script>
    <script src="Javascripts/slick.min.js"></script>
</asp:Content>

