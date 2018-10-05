<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.UserManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card mb-3">
        <div class="card-header">
            <i class="fas fa-table"></i>
            Gestion des utilisateurs
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <div id="dataTable_wrapper" class="dataTables_wrapper dt-bootstrap4">
                    <div class="row">
                        <div class="col-sm-12 col-md-6">
                            <div id="dataTable_filter" class="dataTables_filter">
                                <label>Rechercher:<input type="search" class="form-control form-control-sm" placeholder="" aria-controls="dataTable" /></label>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                            <asp:Button runat="server" Text="Autoriser"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div runat="server" visible="false" id="notif"></div>
                            <asp:Table runat="server" ID="tabUsers" class="table table-bordered dataTable">
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
</asp:Content>
