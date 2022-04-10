<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Website._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Salot lounaslistaaja™</h1>
        <h2"lead">Kirjaudu sisään</h2>
        <asp:Button ID="LoginButton" runat="server" Text="Login" class="btn btn-primary btn-lg" OnClick="Button2_Click"/>
    </div>

     <div class="jumbotron">
        <h2"lead">Rekisteröidy</h2>
        <asp:Button ID="Button3" runat="server" Text="Register" class="btn btn-primary btn-lg" OnClick="Button3_Click"/>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Button" />
</asp:Content>
