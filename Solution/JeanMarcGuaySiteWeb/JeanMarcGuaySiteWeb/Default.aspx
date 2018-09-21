<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JeanMarcGuaySiteWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BannerPlaceHolder" runat="server">

    <div class="parallax-window" data-parallax="scroll" data-image-src="/Images/DSC_2726.JPG"></div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row text-center">
            <div class="col-lg-12">
                Default.aspx
                <span id="test" runat="server"></span>
            </div>
        </div>

    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">

    <script src="Javascripts/parallax.min.js"></script>

</asp:Content>

