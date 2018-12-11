<%@ Page Title="" Language="C#" MasterPageFile="~/ms/Admin.Master" AutoEventWireup="true" CodeBehind="DocumentManagement.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.DocumentManagement" %>
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
            <div class="row pb-3">
                <div class="col-lg-2 col-md-12 text-left">
                    <asp:DropDownList runat="server" ID="DdlCategories" AutoPostBack="true" onselectedindexchanged="SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4 col-md-12 form-group">
                    <input type="search" class="form-control" aria-controls="dataTable" placeholder="Rechercher" id="researchUser" />
                </div>
                <div class="col-lg-4 col-md-12 right">
                    <a href="ajoutPublication.aspx" class="align-middle lienAdmin"><i class="fas fa-plus"></i> Ajouter une publication</a>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4 col-md-12 form-group">
                    <span id="notification" runat="server" class="notification"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-8 col-md-12">
                    <table id="publicationTable" class="table table-bordered table-hover dataTable text-center">
                        <tr>
                            <td><b>Titre</b></td>
                            <td><b>Nom du fichier</b></td>
                            <td><b>Télécharger</b></td>
                            <td><b>Supprimer</b></td>
                        </tr>
                        <asp:Repeater ID="rptPublicationTable" runat="server" OnItemCommand="rptPublication_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Titre") %></td>
                                    <td><%# Eval("fileName") %></td>
                                    <td><asp:Button runat="server" Text="Telecharger" CssClass="btn btn-success" CommandName="Download" CommandArgument='<%# Eval("id1") %>'/> </td>
                                    <td><asp:Button runat="server" Text="Supprimer" CssClass="btn btn-danger btnSuppr" CommandName="Delete" CommandArgument='<%# Eval("id2") %>'/> </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>

    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="additionalJS" runat="server">
    <script src="Javascript/Admin.min.js"></script>
    <script src="Javascript/publicationAdmin.min.js"></script>
</asp:Content>
