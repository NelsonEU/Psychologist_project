<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Accueil.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Accueil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="accueil">
        <div class="space-medium">
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
                        <a href="Connexion.aspx" class="btn btn-primary">En savoir plus</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
