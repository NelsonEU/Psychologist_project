﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="JeanMarcGuaySiteWeb.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BannerPlaceHolder" runat="server">

    <div class="banner2 pb-5">
        <div class="va-center2">
                <h1 class="titleBanner2">Contactez moi</h1>
              
            </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid pt-5">
        <div class="row pb-3">
            <div class="col-md-8 offset-md-2">
                <asp:TextBox runat="server" ID="txtSubject" class="form-control" MaxLength="40" placeholder="Sujet" required="required"></asp:TextBox>
            </div>
        </div>
        <div class="row pb-3">
            <div class="col-md-8 offset-md-2">
                <asp:TextBox ID="txtContent" TextMode="multiline" Columns="50" Rows="5" runat="server" MaxLength="500" placeholder="Message" class="form-control" Style="resize: none;" required="required" />
            </div>
        </div>
        <div class="row pb-3">
            <div class="col-md-2 offset-md-5">
                <asp:Button runat="server" ID="buttonSubmit" Text="Envoyer" OnClick="buttonSubmitClick" CssClass="form-control mainButton" />
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="additionalJS" runat="server">
</asp:Content>
