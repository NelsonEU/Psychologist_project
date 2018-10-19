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
                    <asp:ListItem Text="7 derniers jours" Value="semaine"></asp:ListItem>
                    <asp:ListItem Text="Tout" Value="tout"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">

                <asp:Repeater ID="rptRequest" runat="server" OnItemCommand="rptRequest_ItemCommand">
                    <ItemTemplate>

                        <div class="row">
                            <div class="col-lg-10">
                                <div class="divRequest">
                                    <div class="row text-center divDate">
                                        <div class="col-lg-12 col-sm-12 biggerText">
                                            <span>Message de: <b> <%# Eval("Prenom") %> <%# Eval("Nom") %></b></span>
                                            <asp:Button runat="server" Text="X" CommandName="Delete" class="buttonX" CommandArgument='<%# Eval("requestId") %>'/>
                                        </div>
                                    </div>
                                    <div class="row text-center divInfo">
                                        <div class="col-lg-6 text-left">
                                            <span><%# Eval("Date") %></span>
                                            
                                        </div>
                                        <div class="col-lg-6 col-sm-12 text-right">
                                            <span><%# Eval("Email") %></span>
                                        </div>
                                    </div>

                                    <div class="row text-center divSujet">
                                        <div class="col-lg-12">
                                            <span><%# Eval("Sujet") %></span>
                                        </div>
                                    </div>

                                    <div class="row text-center divContenu">
                                        <div class="col-lg-12">
                                            <span><%# Eval("Contenu") %></span>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
