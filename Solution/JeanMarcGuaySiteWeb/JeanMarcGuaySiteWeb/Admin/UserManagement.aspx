<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.UserManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row pb-3">
        <div class="col-lg-12">
            <h1>Gestion des utilisateurs</h1>
        </div>
    </div>

    <div class="card mb-3">
        <div class="card-body">
            <div class="table-responsive col-md-12">
                <div id="dataTable_wrapper" class="dataTables_wrapper dt-bootstrap4">
                    <div class="row pb-1">
                        <div class="col-sm-12 offset-md-10 col-md-2">
                            <asp:button class=" btn btn-success" runat="server" text="Authoriser" onclick="Click_Authorized" ID="btnAuthoriser" />
                        </div>
                    </div>
                    <div class="row pb-2">
                        <div class="col-sm-12 col-md-3">
                                <input type="search" class="form-control form-control-sm" aria-controls="dataTable" placeholder="Rechercher"/>
                        </div>
                        <divl class="col-sm-12 col-md-2">
                            <asp:button class="btn btn-secondary" runat="server" text="Rechercher"  ID="btnRechercher"/>
                        </divl>
                        <div class="col-sm-12 offset-md-5 col-md-2">
                            <asp:button class="btn btn-danger" runat="server" text="Supprimer" onclick="Click_Delete" ID="btnSupprimer"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div runat="server" visible="false" id="notif"></div>
                            <asp:table runat="server" id="tabUsers" aria-describedby="dataTable_info" cssclass="table table-bordered dataTable">
                                <asp:TableHeaderRow>
                                    <asp:TableHeaderCell>Prénom</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Nom</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>E-mail</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Abonné</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Autorisé*</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Sélectionner</asp:TableHeaderCell>
                                </asp:TableHeaderRow>
                            </asp:table>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
