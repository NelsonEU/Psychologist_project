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
                    </div>
                    <div class="row">
                        <div runat="server" visible="false" id="notif"></div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:table runat="server" id="tabUsers" aria-describedby="dataTable_info" cssclass="table table-bordered table-hover dataTable dataUsers">
                                <asp:TableHeaderRow>
                                    <asp:TableHeaderCell>Prénom</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Nom</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>E-mail</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Abonné</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Autoriser</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Supprimer</asp:TableHeaderCell>
                                </asp:TableHeaderRow>
                            </asp:table>
                        </div>
                    </div>
                    <div class="form-row pt-3">

                        <div class="col-md-4 col-lg-4 col-xl-4 pb-1">
                            <input type="email" class="form-control" aria-controls="dataTable" name="deleteUser" placeholder="exemple@mail.com" id="textMOAD" runat="server" />
                        </div>
                        <div class="col-md-4 col-lg-4 col-xl-4">
                            <asp:button runat="server" id="Click_Moad" class="btn btn-danger clickMOAD" text="Supprimer définitivement" onclick="Click_MOAD" />
                        </div>
                        <div class="col-12 notifMOAD" runat="server" id="notifMOAD" visible="false">
                        </div>
                    </div>


                </div>
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="additionalJS" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootbox.js/4.4.0/bootbox.min.js"></script>
    <script src="Javascript/Admin.min.js"></script>
</asp:Content>
