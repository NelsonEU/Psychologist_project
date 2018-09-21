<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1>Gestion des modules</h1>
            <asp:Button ID="PublishButton" runat="server" Text="Save" onclick="SwitchSelectChanged" />
        </div>
    </div>

        <asp:Repeater runat="server" ID="rptModules">
            <ItemTemplate>
                <div class="row">
                    <div class="col-lg-12">
                        <asp:Label runat="server" class="switchLabel" data-id='<%# Eval("active") %>' Text='<%# Eval("labelModule") %>' />                     
                    </div>
                </div>
            </ItemTemplate>
    </asp:Repeater>

</asp:Content>
