<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Website.register"  MasterPageFile="~/Site.Master" async="true" Title="Register to Salot"%>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
    
     <br />
        <div class="col-md-4">
        Email: 
        <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
        <br />
        Password:    <asp:TextBox ID="PasswordTextbox" runat="server"></asp:TextBox> 
        <br />
  

        <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
        <asp:Label ID="RegisterFailedError" runat="server" Text="" class="ErrorMessageText"></asp:Label>
        <br />
            </div>
 
</asp:Content>

