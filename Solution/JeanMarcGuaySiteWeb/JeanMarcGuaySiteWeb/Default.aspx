<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JeanMarcGuaySiteWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BannerPlaceHolder" runat="server">

    <section id="banner">
        <img class="logoBanner" src="Images/logoOriginal2.png" />
        <div class="inner">
            <h1>Jean-Marc Guay</h1>
            <p></p>
        </div>
    </section>

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
