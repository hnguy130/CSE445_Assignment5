<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordChange.aspx.cs" Inherits="CSE445_Assignment5.PasswordChange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Change password<br />
            <br />
            Enter username </div>
        <asp:TextBox ID="TextBox1" runat="server" Width="418px"></asp:TextBox>
        <p>
            Enter old password</p>
        <asp:TextBox ID="TextBox2" runat="server" Width="414px"></asp:TextBox>
        <br />
        <br />
        Enter new password<br />

        <br />
        <asp:TextBox ID="TextBox3" runat="server" Width="410px"></asp:TextBox>
        <br />
        <p>
            <asp:Button ID="Button1" runat="server" Text="Change Password" OnClick="Button1_Click" />
        </p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
</body>
</html>
