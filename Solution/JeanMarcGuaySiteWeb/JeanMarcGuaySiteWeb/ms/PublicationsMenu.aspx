<%@ Page Title="" Language="C#" MasterPageFile="~/ms/Admin.Master" AutoEventWireup="true" CodeBehind="PublicationsMenu.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.PublicationsMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row pb-3">
        <div class="col-lg-12">
            <h1>Publications</h1>
        </div>
    </div>

    <div id="ActivationValidation" runat="server">
        Vous devez activer le module <b>« Module des documents PDF »</b> afin d'avoir accès à cette section.
    </div>

    <div id="PageContent" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md box-admin box-shadow" runat="server" id="listePublications" clientidmode="static">
                    <h5><span class="highlightH4">Liste des publications</span></h5>
                    <br />
                    <p>Page permettant d’<b>afficher la liste</b> de tous les documents de format PDF publiés, triés par catégorie</p>
                </div>

                <div class="col-md box-admin box-shadow" runat="server" id="AjoutPublication" clientidmode="static">
                    <h5><span class="highlightH4">Ajouter une publication</span></h5>
                    <br />
                    <p>Page permettant d’<b>ajouter une publication</b> en téléversant un fichier PDF et en y associant une catégorie</p>
                </div>

                <div class="col-md box-admin box-shadow" runat="server" id="listeCategories" clientidmode="static">
                    <h5><span class="highlightH4">Liste des catégories</span></h5>
                    <br />
                    <p>Page permettant d’<b>afficher la liste</b> de tous les <b>catégories</b></p>
                </div>

                <div class="col-md box-admin box-shadow" runat="server" id="AjoutCategorie" clientidmode="static">
                    <h5><span class="highlightH4">Ajouter une catégorie</span></h5>
                    <br />
                    <p>Page permettant d’<b>ajouter une catégorie</b> en y associant un titre et une image.</p>                   
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="additionalJS" runat="server">
    <script src="Javascript/publicationMenu.min.js"></script>
    
</asp:Content>
