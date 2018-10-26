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

    <!-- Contenu Intro Consulter -->
    <section>
        <!-- Texte -->
        <div class="pb-5" style="margin-top: 40px;">
            <div class="container biggerBox">
                <div class="row">
                    <div class="col-lg-8">
                        <div class="col-md-6 ">
                             <h2 class="underline1 animated slow fadeInRight" style="opacity: 0;">Pourquoi consulter?</h2>
                        </div>
                        <div class="pt-3 divAnimation2" style="opacity: 0;">
                            <p>L’un des premiers raisonnements que les gens font lorsqu’ils se rendent compte ou se font dire qu’ils ont besoin d’aide, est de croire qu’ils sont faibles ou inférieurs. En réalité, cela n’a rien à voir puisqu’il peut arriver à tout le monde de vivre à un moment donné des difficultés internes et externes qui dépassent ses capacités d’adaptation. Cet état de fait a souvent pour conséquence de modifier à différents niveaux, l’équilibre interne et externe de la personne.</p>
                            <p>Le deuxième raisonnement qui est souvent constaté est celui où la personne se demande si elle est devenue anormale. Il est admis que des idées et des émotions latentes peuvent refaire surface, interférer dans le fonctionnement du métabolisme et s’exprimer pour certains, en douleurs physiques.</p>
                            <p>Finalement, il arrive que d’autres personnes croient que leur mal n’existe pas ou qu’elles souffrent d’une maladie imaginaire. Habituellement, c’est votre médecin qui vous dira le premier que votre problème est psychologique. Mieux que quiconque, il sait que votre souffrance est réelle et légitime. Il est aussi conscient que vous ressentez sincèrement un malaise intérieur, mais il croit que vous devriez rencontrer un psychologue. C’est cette personne qualifiée qui saura vous aider à traverser les difficultés qui se présentent à vous.</p>
                        </div>
                    </div>

                <!-- Image -->
                <div class="col-lg-4 text-center">
                    <img class="shadow img-thumbnail" id="h2Apropos" src="http://wp2.commonsupport.com/newwp/mindron/wp-content/uploads/2018/02/about.jpg" alt="">
                </div>
                </div>
              <div  id="paraTrigger"></div>
            </div>
        </div>
    </section>

    <!-- Contenu Parralax -->
    <section>
        <div class="pb-5 container-fluid bc-blue biggerBox">
            <div class="container divAnimation3" style="opacity: 0;">
                <div class="row">
                    <!-- Texte -->
                    <div class="col-md-6 offset-md-6">
                        <div>
                            <div class="col-md-11" style="padding: 0px 0px 0px 0px;">
                                <h2 class="underline2">N'attendez pas pour consulter</h2>
                            </div>
                        </div>
                        <p>La plus grande marque de respect que vous pouvez porter à votre égard est de reconnaître que vous avez besoin d'aide. Le plus beau geste d'amour pour soi et pour les siens est de se donner la liberté de mettre de son côté toutes les chances de s’en sortir.</p>
                        <p id="ImgTrigger">
                            D’une certaine façon, attendre à la dernière minute revient à épuiser les forces disponibles qui pourraient être utilisées en psychothérapie et servir à prévenir une détresse psychologique.
                        </p>
                    </div>
                </div>
               <div  id="paraTrigger2"></div>
            </div>
        </div>
    </section>

    <!-- Contenu Approche -->
    <section>
       
    </section>
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

    <!-- Première Rencontre -->
    <section>
        <div class="pb-5">
             <div class="pb-5">
            <div class="container">
                <!-- Images -->
                <div class="row pb-3" style="height: 374px; max-width: 800px; margin-top: 40px;">
                    <!-- Image 1 -->
                    <div class="col-md-9 divAnimation4" style="height: inherit;">
                        <img class="img-fluid shadow" src="http://wp2.commonsupport.com/newwp/mindron/wp-content/uploads/2018/02/services-13.jpg " alt="">
                    </div>
                    <!-- Image 2 -->
                    <div class="col-md-3 divAnimation5" style="height: inherit;">
                        <img style="height: inherit" class="shadow" src="http://wp2.commonsupport.com/newwp/mindron/wp-content/uploads/2018/02/services-14.jpg" alt="">
                    </div>
                    <div id="paraTrigger3"></div>
                </div>
                </div>
            </div>
            <div class="container divAnimation6">
                <div class="row pb-3">
                    <div class="col-md-12">
                        <div class="col-md-5" style="padding: 0px 0px 0px 0px;">
                            <h2 class="underline1">Première rencontre</h2>
                        </div>
                        <div class="pt-3">
                            <p>Habituellement, le temps alloué pour une rencontre est d’environ une heure. Quant à la fréquence des rencontres, celle-ci peut varier selon les besoins du client. Au début, la fréquence peut être d’une par semaine. Mais au fur et à mesure que la psychothérapie progresse dans le temps, les rencontres sont espacées, d’un commun accord. En ce qui concerne la durée d’une psychothérapie, celle-ci fluctue en fonction de nombreux facteurs dont : 1) le problème présenté, 2) la gravité du problème, 3) la motivation, 4) la période d’adaptation, 5) la personnalité, 6) les ressources environnantes, etc. Le choix de mettre fin à la psychothérapie revient toujours à la personne requérante. Lors du processus thérapeutique, la personne est invitée à exprimer ses émotions et ses pensées, mais aussi elle est appelée à devenir son propre artisan. D’un côté, le rôle du thérapeute est de mettre tout en oeuvre pour favoriser les meilleures conditions thérapeutiques, préparer un plan d’action adapté, et enfin, outiller son client de façon appropriée. D’un autre côté, le rôle principal de la personne aidée est de travailler afin d’acquérir une plus grande maîtrise de son monde émotionne, rationnel et relationnel.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/waypoints/4.0.1/jquery.waypoints.min.js"></script>
</asp:Content>
