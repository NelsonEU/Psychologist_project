<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Publications.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Publications1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">

    <div class="banner2 pb-5 shadow">
        <div class="va-center2">
            <h1 class="titleBanner2">Publications</h1>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-center pt-1 evenBiggerBox mt-4">
        <div class="container" id="publications">

            <!-- Page Heading -->
            <div class="row">
                    <h2 class="underline1 m-4 text-left">Catégories</h2>            
            </div>
            <div class="row pb-4">
                <div class="col-lg-12 text-left">
                    <h5>Choisissez une des catégories suivantes pour accéder aux publications associées.</h5>
                </div>
            </div>

            <div class="row" id="categoriesPortfolio" runat="server">
                
            </div>

            <!-- /.row -->
            <div class="row pt-3">
                <div class="col-lg-12 text-center">
                    <asp:LinkButton runat="server" id="btnAbonnements" cssClass="btn mainButton2" OnClick="abonnementDesabonnement" AutoPostBack="true" ><i class="fas fa-bell"></i> S'abonner aux publications</asp:LinkButton>
                </div>
            </div>

        </div>
    </div>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
