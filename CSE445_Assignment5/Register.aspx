<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CSE445_Assignment5.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Register new account<br />
            <br />
            Enter new username </div>
        <asp:TextBox ID="TextBox1" runat="server" Width="418px"></asp:TextBox>
        <p>
            Enter new password</p>
        <asp:TextBox ID="TextBox2" runat="server" Width="414px"></asp:TextBox>
        <br /> 
        <br />
        Enter code from image<br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="TextBox3" runat="server" Width="410px"></asp:TextBox>
        <br />
        <p>
            <asp:Button ID="Button1" runat="server" Text="Register Account" OnClick="Button1_Click" />
        </p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
</body>
</html>
