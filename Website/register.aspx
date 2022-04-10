<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Website.register" async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <h1>Register to Salot</h1>
        </div>
        <div class="col-md-4">
        Email: 
        <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
        <br />
        Password:    <asp:TextBox ID="PasswordTextbox" runat="server"></asp:TextBox> 
        <br />
  

        <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
        <asp:Label ID="RegisterFailedError" runat="server" Text="" class="ErrorMessageText"></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="" class="ErrorMessageText"></asp:Label>
        <br />
        <br />
            </div>
    </form>
</body>
</html>
