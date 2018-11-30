<%@ Page Title="" Language="C#" MasterPageFile="~/ms/Admin.Master" AutoEventWireup="true" CodeBehind="ModuleManagement.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.ModuleManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row pb-3">
        <div class="col-lg-12">
            <h1>Gestion des modules</h1>            
        </div>
    </div>
    <div class="row">
        <div class="col-lg-8">
            <asp:Table runat="server" id="moduleTable"  CssClass="table table-bordered table-hover dataTable">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Nom du module</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Description</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Actif</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
