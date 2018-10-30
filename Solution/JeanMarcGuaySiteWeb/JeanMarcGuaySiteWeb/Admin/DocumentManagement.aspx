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

        <asp:FileUpload id="fileUpload" runat="server"/>
        <asp:Button runat="server" id="UploadButton" text="Téléverser" onclick="UploadButton_Click" cssClass="btn btn-success"/>
        <asp:Label runat="server" id="StatusLabel" text="" />
        <!--
        <div class="card mb-3">
            <div class="card-header">
                Ajouter une nouvelle publication
            </div>
            <div class="card-body">

            </div>
        </div>

            -->

    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
