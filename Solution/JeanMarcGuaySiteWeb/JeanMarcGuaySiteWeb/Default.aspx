<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JeanMarcGuaySiteWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">
    <div class="parallax-window bannerCenter" data-parallax="scroll" data-image-src="/Images/DSC_2726.JPG" ">
        <div class="container-fluid">
            <div class="row text-center text-black" >
                <div class="col-lg-12">
                    <h1>Jean-Marc Guay</h1>
                </div>
            </div>
        </div>

    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div id="subsection_1" runat="server">

        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">

    <script src="Javascripts/parallax.min.js"></script>

</asp:Content>

