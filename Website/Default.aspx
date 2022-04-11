<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Website._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Salot lounaslistaaja™</h1>
        <h2"lead">Kirjaudu sisään<br />
        <asp:Button ID="LoginButton" runat="server" Text="Login" class="btn btn-primary btn-lg" OnClick="LoginButton_Click"/>
    </div>

     <div class="jumbotron">
        <h2"lead">Rekisteröidy<br />
        <asp:Button ID="Button3" runat="server" Text="Register" class="btn btn-primary btn-lg" OnClick="RegisterButton_Click"/>
    </div>
    </asp:Content>
