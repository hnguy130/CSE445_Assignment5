<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CSE445_Assignment5.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; padding: 25px; background-color: #f9f9f9; }
        .action-btn { margin: 5px 0; padding: 8px 16px; cursor: pointer; background-color: #005A9C; color: white; border: none; border-radius: 3px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login</h2>
            <table>
                <tr>
                    <td>Username:</td>
                    <td><asp:TextBox ID="txtUsername" runat="server" /></td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="action-btn" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><a href="Register.aspx">Don't have an account? Register here.</a></td>
                </tr>
            </table>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>