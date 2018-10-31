<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AjoutPublication.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.AjoutPublication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row pb-3">
        <div class="col-lg-12">
            <h1>Ajouter une publication</h1>           
        </div>
    </div>

    <div id="ActivationValidation" runat="server">
        Vous devez activer le module <b>« Module des documents PDF »</b> afin d'avoir accès à cette section.
    </div>

    <div id="PageContent" runat="server">
        <div class="container-fluid">
            <a href="DocumentManagement.aspx">Retour</a>
            <div class="row">
                <div class="col-8 border">
                    <div class="row text-center pt-4 ">
                        <div class="col-12">
                            <label for="DdlCategories" class="form-check-label">Catégorie:</label>
                        </div>
                    </div>
                    <div class="row text-center pb-4">
                        <div class="col-12">
                            <asp:DropDownList runat="server" ID="DdlCategories" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row text-center pb-4">
                        <div class="col-8 offset-2">
                            <label for="txtTitle" class="form-check-label">Titre:</label>
                            <asp:TextBox ID="txtTitle" runat="server" MaxLength="500" ClientIDMode="Static" placeholder="Titre" class="form-control" Style="resize: none;" required="required" />
                        </div>
                    </div>
                    <div class="row text-center pb-4">
                        <div class="col-12">
                            <asp:FileUpload ID="fileUpload" runat="server" />
                        </div>
                    </div>
                    <div class="row text-center">
                        <div class="col-12">
                            <asp:Button runat="server" ID="UploadButton" Text="Téléverser" OnClick="UploadButton_Click" CssClass="btn btn-success" />
                        </div>
                    </div>
                    <div class="row text-center pb-4">
                        <div class="col-12">
                            <asp:Label runat="server" ID="StatusLabel" Text="" />
                        </div>
                    </div>
                </div>
            </div>

        </div>
        </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
