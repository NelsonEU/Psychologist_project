<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DocumentManagement.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.DocumentManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row pb-3">
        <div class="col-lg-12">
            <h1>Gestion des documents</h1>
        </div>
    </div>

    <div id="ActivationValidation" runat="server" >
        Vous devez activer le module <b>« Module des documents PDF »</b> afin d'avoir accès à cette section.
    </div>

    <div id="PageContent" runat="server">

        Le contenu de cette page ici!

    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
