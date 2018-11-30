<%@ Page Title="" Language="C#" MasterPageFile="~/ms/Admin.Master" AutoEventWireup="true" CodeBehind="AjoutCategorie.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.AjoutCategorie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row pb-3">
        <div class="col-lg-12">
            <h1>Ajouter une catégorie</h1>
        </div>
    </div>

    <div id="ActivationValidation" runat="server">
        Vous devez activer le module <b>« Module des documents PDF »</b> afin d'avoir accès à cette section.
    </div>

    <div id="PageContent" runat="server">
        <a href="CategoryManagement.aspx" class="lienAdmin">Liste des catégories</a>
        <div class="row" id="rowAjout" runat="server">
            <div class="col-8 border">
                <div class="row text-center pb-4 pt-4">
                    <div class="col-8 offset-2">
                        <label for="txtTitle" class="form-check-label"><b>Nom:</b></label>
                        <asp:TextBox ID="txtTitle" runat="server" MaxLength="40" ClientIDMode="Static" placeholder="Titre" class="form-control" Style="resize: none;" required="required" />
                    </div>
                </div>
                <div class="row text-center pb-4">
                    <div class="col-12">
                        <label for="fileUpload" class="form-check-label"><b>Image</b> (format jpeg):</label><br />
                        <label for="fileUpload" class="form-check-label textSmaller">Attention, Il est fortement recommendé d'utiliser des images de petite taille. Le format idéal est 500 x 500 px <i id="tooltipImage" class="far fa-question-circle mainAdminColor biggerbiggerText" title="Pour bien formater votre image, vous pouvez utiliser un site web tiers comme https://imageresize.org/ ou bien https://befunky.com/create et n'hésiter pas a réduire un peu la qualité de l'image afin qu'elle prenne moins d'espace."></i></label>
                        <br />
                        <asp:FileUpload ID="fileUpload" runat="server" class="pt-2" style="margin:auto"/>
                    </div>
                </div>
                <div class="row text-center">
                    <div class="col-12 marginAuto" >
                        <asp:Button runat="server" ID="UploadButton" Text="Ajouter" OnClick="UploadButton_Click" CssClass="btn btn-success" />
                    </div>
                </div>
                <div class="row text-center pb-4">
                    <div class="col-12 text-center">
                        <asp:Label runat="server" ID="StatusLabel" Text="" ClientIDMode="Static" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row" id="rowMaximum" runat="server">
            <div class="col-8 border">
                <div class="row text-center pb-4 pt-4">
                    <div class="col-8 offset-2">
                        <asp:Label runat="server" ID="lblMaximum">Le nombre maximum de catégorie (10) a été atteint. Vous devez donc en supprimer une pour pouvoir en créer une nouvelle.</asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="additionalJS" runat="server">
    <script src="Javascript/categorieAdmin.js"></script>
</asp:Content>
