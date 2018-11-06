<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DocumentManagement.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.DocumentManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row pb-3">
        <div class="col-lg-12">
            <h1>Gestion des publications</h1>
        </div>
    </div>

    <div id="ActivationValidation" runat="server">
        Vous devez activer le module <b>« Module des documents PDF »</b> afin d'avoir accès à cette section.
    </div>

    <div id="PageContent" runat="server">

        <div class="container-fluid">
            <div class="row pb-2">
                <div class="col-lg-2 col-md-12 text-left">
                    <asp:DropDownList runat="server" ID="DdlCategories" AutoPostBack="true" onselectedindexchanged="SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="col-lg-4 offset-lg-2 col-md-12 right">
                    <a href="ajoutPublication.aspx">Ajouter une publication</a>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-8 col-md-12">
                    <asp:Table runat="server" ID="publicationTable" CssClass="table table-bordered table-hover dataTable text-center">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell>Titre</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Télécharger</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Supprimer</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
            </div>
        </div>

    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
