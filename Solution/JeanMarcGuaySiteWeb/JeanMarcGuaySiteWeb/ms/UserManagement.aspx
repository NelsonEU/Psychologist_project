<%@ Page Title="" Language="C#" MasterPageFile="~/ms/Admin.Master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.UserManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row pb-3">
        <div class="col-lg-12">
            <h1>Gestion des utilisateurs</h1>
        </div>
    </div>

    <div class="card mb-3">
        <div class="card-body container-fluid">
            <div class="">
                <div id="dataTable_wrapper" class="dataTables_wrapper dt-bootstrap4">
                    <div class="form-row">
                        <div class="col-lg-4 col-md-12 form-group">
                            <input type="search" class="form-control" aria-controls="dataTable" placeholder="Rechercher" id="researchUser" />
                        </div>
                        <div class="offset-lg-2 col-lg-6 col-md-12 text-right">
                            <asp:Button class=" btn btn-success" runat="server" Text="Authoriser" OnClick="Click_Authorized" ID="btnAuthoriser" />
                            <asp:Button class="btn btn-warning" runat="server" Text="Désauthoriser" OnClick="Click_Deauthorized" OnClientClick="ConfirmerDesauthorisation()" ID="btnDesauthoriser" />
                            <asp:Button class=" btn btn-danger" runat="server" Text="Supprimer" OnClick="Click_Delete" OnClientClick="ConfirmerSuppression()" ID="btnSupprimer" />
                        </div>
                    </div>
                    <div class="row">
                        <div runat="server" visible="false" id="notif"></div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Table runat="server" ID="tabUsers" aria-describedby="dataTable_info" CssClass="table table-bordered table-hover dataTable dataUsers">
                                <asp:TableHeaderRow>
                                    <asp:TableHeaderCell>Prénom</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Nom</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>E-mail</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Abonné</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Autorisé*</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Sélectionner</asp:TableHeaderCell>
                                </asp:TableHeaderRow>
                            </asp:Table>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="additionalJS" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootbox.js/4.4.0/bootbox.min.js"></script>
    <script src="Javascript/Admin.js"></script>
</asp:Content>
