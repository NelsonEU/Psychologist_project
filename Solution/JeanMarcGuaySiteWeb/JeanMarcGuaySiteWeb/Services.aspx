<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.7.0/animate.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
    <div class="banner2 shadow">
        <div class="va-center2 animated fadeIn slow">
            <h1 class="titleBanner2">Services</h1>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="service">
        
    <!-- Contenu Intro Consulter -->
    <section>
        <!-- Texte -->
        <div>
            <div class="container evenBiggerBox">
                <div class="row">
                    <div class="col-lg-8">
                        <div class="col-md-6 pl0">
                            <h2 class="underline1 animated slow fadeInRight" style="opacity: 0;">Pourquoi consulter?</h2>
                        </div>
                        <div class="pt-3 divAnimation2" style="opacity: 0;">
                            <p id="triggerAnimationbcblueHead">L’un des premiers raisonnements que les gens font lorsqu’ils se rendent compte ou se font dire qu’ils ont besoin d’aide, est de croire qu’ils sont faibles ou inférieurs. En réalité, cela n’a rien à voir puisqu’il peut arriver à tout le monde de vivre à un moment donné des difficultés internes et externes qui dépassent ses capacités d’adaptation. Cet état de fait a souvent pour conséquence de modifier à différents niveaux, l’équilibre interne et externe de la personne.</p>
                            <p id="triggerAnimationbcblue">Le deuxième raisonnement qui est souvent constaté est celui où la personne se demande si elle est devenue anormale. Il est admis que des idées et des émotions latentes peuvent refaire surface, interférer dans le fonctionnement du métabolisme et s’exprimer pour certains, en douleurs physiques.</p>
                            <p>Finalement, il arrive que d’autres personnes croient que leur mal n’existe pas ou qu’elles souffrent d’une maladie imaginaire. Habituellement, c’est votre médecin qui vous dira le premier que votre problème est psychologique. Mieux que quiconque, il sait que votre souffrance est réelle et légitime. Il est aussi conscient que vous ressentez sincèrement un malaise intérieur, mais il croit que vous devriez rencontrer un psychologue. C’est cette personne qualifiée qui saura vous aider à traverser les difficultés qui se présentent à vous.</p>
                        </div>
                    </div>

                    <!-- Image -->
                    <div class="col-lg-4 text-center">
                        <img class="shadow img-thumbnail" id="h2Apropos" src="Images/photoService.jpg" alt="" />
                    </div>
                </div>
                <div id="paraTrigger"></div>
            </div>
        </div>
    </section>
    <!-- Fin Contenu Intro Consulter -->

    <!-- Contenu bc-blue-->
    <section>
        <div class="pb-5 bc-blue">
            <div class="container evenBiggerBox ">
                <div class="row pt-5">
                    <h2 class="underline2 animated slow" id="divAnimationbcBlueHead">Approche preconisée</h2>
                </div>
                <div id="divAnimationbcBlue" class="animated slow">
                    <div class="row pt-3 slow">
                        <p id="triggerPremiereRencontreHead">
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
                        <div class="col-md-3" id="triggerPremiereRencontre">
                            <ul>
                                <li>Systemique/interactionnelle</li>
                                <li>Comportementale/cognitive</li>
                            </ul>
                        </div>
                    </div>
                    <div class="row">
                        <p class="long-text">De part ses connaissances theoriques et ses experiences professionelles, les interventions sont toujours accomodees en fonction des problemes et des personnes qu'il rencontre.</p>
                        <p">Le therapeute prendra en compte tant les spheres emotionnelles et cognitives que comportementales et sociales.</p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Fin Contenu bc-blue-->

    <!-- Contenu Approche -->

    <!-- Texte -->
    <!--
                <div class="row">
                    <div class="col-md-12 divAnimation6">
                        <div>
                            <div class="col-md-4 " style="padding: 0px 0px 0px 0px;">
                                <h2 class="underline1">Approche Préconisé</h2>
                            </div>
                        </div> 
                        <div class="row pt-3 slow " style="padding-right: 15px;
    padding-left: 15px;">
                            <p>
                                Le thérapeute adapte ses interventions en fonction des problèmes et des personnes qu’il rencontre<br />
                                L’approche qui est préconisée au Cabinet privé de psychothérapie en est une d’orientation intégrative. Comme son nom le dit, il s’agit d’une approche dont la formation du thérapeute lui permet d’utiliser les outils de travail thérapeutique d’approches combinées telles que :
                            </p>

                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <ul style="list-style: none;">
                                    <li> <img src="Images/blue-check-mark-png-md.png" style="width: 10px; height 10px;"/> Psychoanalytique/analytique</li>
                                    <li><img src="Images/blue-check-mark-png-md.png" style="width: 10px; height 10px;"/> Existentielle/humaniste </li>
                                </ul>
                            </div>
                            <div class="col-md-4">
                                <ul style="list-style: none;">
                                    <li> <img src="Images/blue-check-mark-png-md.png"  style="width: 10px; height 10px;"/> Systemique/interactionnelle</li>
                                    <li> <img src="Images/blue-check-mark-png-md.png" style="width: 10px; height 10px;"/> Comportementale/cognitive</li>
                                </ul>
                            </div>
                        </div>
                        <div class="row" style="padding-right: 15px;
    padding-left: 15px;">
                            <p class="long-text">De part ses connaissances theoriques et ses experiences professionelles, les interventions sont toujours accomodees en fonction des problemes et des personnes qu'il rencontre.</p>
                            <p>Le therapeute prendra en compte tant les spheres emotionnelles et cognitives que comportementales et sociales.</p>
                        </div>                
                    </div>
                </div>
            </div>
        </div>
    </section>-->

    

    <!-- <div class="container">
                     Images -->
    <!-- <div class="row pb-3" style="height: 374px; max-width: 800px; margin-top: 40px;">
                        <!-- Image 1 -->
    <!-- <div class="col-md-9 divAnimation4" style="height: inherit;">
                            <img class="img-fluid shadow" src="http://wp2.commonsupport.com/newwp/mindron/wp-content/uploads/2018/02/services-13.jpg " alt="">
                        </div>
                        <!-- Image 2 -->
    <!--<div class="col-md-3 divAnimation5" style="height: inherit;">
                            <img style="height: inherit" class="shadow" src="http://wp2.commonsupport.com/newwp/mindron/wp-content/uploads/2018/02/services-14.jpg" alt="">
                        </div>-->

    <!--</div>
                </div>-->
    
    <!-- Première Rencontre -->
    <section>
        <div class="container evenBiggerBox">
            <div class="row pb-5">
                <div class="col-md-12">
                    <div id="PremiereRencontreHead" class="col-md-4 animated slow" style="padding: 0px 0px 0px 0px;">
                        <h2 class="underline1">Première rencontre</h2>
                    </div>
                    <div class="pt-3 animated slow" id="premiereRencontre">
                        <p>Habituellement, le temps alloué pour une rencontre est d’environ une heure. Quant à la fréquence des rencontres, celle-ci peut varier selon les besoins du client. Au début, la fréquence peut être d’une par semaine. Mais au fur et à mesure que la psychothérapie progresse dans le temps, les rencontres sont espacées, d’un commun accord. En ce qui concerne la durée d’une psychothérapie, celle-ci fluctue en fonction de nombreux facteurs dont : 
                        <br /><br /><img src="Images/blue-check-mark-png-md.png"  style="width: 10px; height:10px;"/><b style="line-height: 1.5; margin-inline-start: 7px;"> le problème présenté </b>
                        <br /><img src="Images/blue-check-mark-png-md.png"  style="width: 10px; height:10px;"/><b style="line-height: 1.5; margin-inline-start: 7px;"> la gravité du problème </b>
                        <br /><img src="Images/blue-check-mark-png-md.png"  style="width: 10px; height:10px;"/><b style="line-height: 1.5; margin-inline-start: 7px;"> la motivation </b>
                        <br /><img src="Images/blue-check-mark-png-md.png"  style="width: 10px; height:10px;"/><b style="line-height: 1.5; margin-inline-start: 7px;"> la période d’adaptation </b>
                        <br /><img src="Images/blue-check-mark-png-md.png"  style="width: 10px; height:10px;"/><b style="line-height: 1.5; margin-inline-start: 7px;"> la personnalité </b>
                        <br /><img src="Images/blue-check-mark-png-md.png"  style="width: 10px; height:10px;"/><b style="line-height: 1.5; margin-inline-start: 7px;"> les ressources environnantes, etc. </b><br />
                        <br />Le choix de mettre fin à la psychothérapie revient toujours à la personne requérante. Lors du processus thérapeutique, la personne est invitée à exprimer ses émotions et ses pensées, mais aussi elle est appelée à devenir son propre artisan. D’un côté, le rôle du thérapeute est de mettre tout en oeuvre pour favoriser les meilleures conditions thérapeutiques, préparer un plan d’action adapté, et enfin, outiller son client de façon appropriée. D’un autre côté, le rôle principal de la personne aidée est de travailler afin d’acquérir une plus grande maîtrise de son monde émotionnel, rationnel et relationnel.</p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Fin Première Rencontre -->

    </div>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/waypoints/4.0.1/jquery.waypoints.min.js"></script>
        <script src="Javascripts/animation.js"></script>
</asp:Content>
