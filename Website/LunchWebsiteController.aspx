<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LunchWebsiteController.aspx.cs" Inherits="Website.LunchWebsiteController" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1> Lunch website controller</h1>
    <h2>Add new website for analyser</h2>
Website: <asp:TextBox runat="server" ID="LunchWebsiteTextbox" Width="320px"></asp:TextBox> </br>
    <asp:Button ID="Button1" runat="server" Text="Add" OnClick="AddWebsiteForUser" Width="37px" />
&nbsp;
        <asp:Label ID="ErrorText" runat="server" Text=" "  ></asp:Label>
    <h2>My subscribed websites:</h2>

      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting">
    <Columns>
        <asp:TemplateField HeaderText="Address">
            <ItemTemplate>
                <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Address") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete" ItemStyle-Width="150">
            <ItemTemplate>
                <asp:Button Text="Unsubscribe" runat="server" CommandName="Unsubscribe" CommandArgument="<%# Container.DataItemIndex %>" /> />
            </ItemTemplate>
        </asp:TemplateField>
           <asp:TemplateField HeaderText="ID" ItemStyle-Width="0">
            <ItemTemplate>
                <asp:TextBox Text='<%# Eval("ID") %>' runat="server"  Visible ="false" ID="ID" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
    </form>
    </body>
</html>
