<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1>Gestion des modules</h1>
            
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <asp:GridView ID="gridModules" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover dataTable" OnRowCommand="gridCategorie_RowCommand" DataKeyNames="moduleId">
                <Columns>
                    <asp:BoundField DataField="moduleId" HeaderText="Identifiant" SortExpression="id" ItemStyle-CssClass="hidden-field" HeaderStyle-CssClass="hidden-field" />
                    <asp:BoundField DataField="title" HeaderText="Titre" SortExpression="nom" />
                    <asp:ButtonField CommandName="Toggle" Text="Activé" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
