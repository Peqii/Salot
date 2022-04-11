<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Website.WebFormTest" MasterPageFile="~/Site.Master" Async="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
       
     <br />

    <div class="col-md-4">
    Username: 
    <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
    <br />
    Password:    <asp:TextBox ID="PasswordTextbox" runat="server"></asp:TextBox> 
    <br />
  
    <asp:Button ID="Button1" runat="server" Text="Login" OnClick="LoginButtonClick" />
    <asp:Label ID="RegisterFailedError" runat="server" Text="" class="ErrorMessageText"></asp:Label>
    <br />
         <br />
        </div>

    </asp:content>

