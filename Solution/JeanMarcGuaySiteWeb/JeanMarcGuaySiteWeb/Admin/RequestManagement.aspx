<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="RequestManagement.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.RequestManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row pb-3">
        <div class="col-lg-12">
            <h1>Aperçu des contacts</h1>            
        </div>
    </div>


    <div id="ActivationValidation" runat="server" >
        Vous devez activer le module <b>« Module des prises de contact »</b> afin d'avoir accès à cette section.
    </div>


    <div id="PageContent" runat="server">
        <div class="row pb-3">
            <div class="col-lg-2 col-sm-6">
                <asp:DropDownList runat="server" ID="DdlRange" OnSelectedIndexChanged="DdlRangeChanged" AutoPostBack="true"> 
                    <asp:ListItem Text="30 derniers jours" Value="mois"></asp:ListItem>
                    <asp:ListItem Text="Cette semaine" Value="semaine"></asp:ListItem>
                    <asp:ListItem Text="Tout" Value="tout"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-8">

                <asp:Table runat="server" id="requestTable" CssClass="table table-bordered table-hover dataTable">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Sujet</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Contenu</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Nom</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Prénom</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Adresse email</asp:TableHeaderCell>
                        
                    </asp:TableHeaderRow>
                </asp:Table>

            </div>
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
