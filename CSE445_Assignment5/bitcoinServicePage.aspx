<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bitcoinServicePage.aspx.cs" Inherits="tryitpages.wsdl_elective_service" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            WSDL service - elective - Sign up, log in, view balance, increase balance, withdraw balance, of bitcoin, with database as json file<br />
            url: <a href="https://localhost:44358/bitcoin_service.asmx">https://localhost:44358/bitcoin_service.asmx</a><br />
            Methods:<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string createAccount(string account, string password)
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string login(string account, string password)<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string viewBalance(string account, string password, string cookie)<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string addBalance(string account, string password, string cookie, double amount)<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string withdrawBalance(string account, string password, string cookie, double amount)<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp; Sign up<br />
            <br />
            Input new account&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:TextBox ID="newAccount" runat="server"></asp:TextBox>
            <br />
            Input new password<br />
            <asp:TextBox ID="newPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="buttonSignUp" runat="server" OnClick="buttonSignUp_Click" Text="Sign up" />
            <br />
            Result<br />
            <asp:TextBox ID="signUpResult" runat="server" Width="284px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp; Sign in<br />
            <br />
            Input existing account<br />
            <asp:TextBox ID="existingAccount" runat="server"></asp:TextBox>
&nbsp;example account &quot;a&quot;, password &quot;1&quot; one<br />
            Input existing password<br />
            <asp:TextBox ID="existingPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="buttonSignIn" runat="server" OnClick="buttonSignIn_Click" Text="Sign in" />
            <br />
            Result<br />
            <asp:TextBox ID="signInResult" runat="server" Width="278px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp; View balance, increase balance, withdraw balance with correct cookie to indicate current session<br />
            <br />
            Cookie<br />
            <asp:TextBox ID="cookie" runat="server" Width="278px"></asp:TextBox>
&nbsp;Cookie updates on its own. If cookie is changed, session is deleted<br />
            Balance<br />
            <asp:TextBox ID="balance" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="buttonViewBalance" runat="server" OnClick="buttonViewBalance_Click" Text="View Balance" />
            <br />
            <br />
            Increase balance by amount<br />
            <asp:TextBox ID="increaseBalanceAmount" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="buttonIncreaseBalance" runat="server" OnClick="buttonIncreaseBalance_Click" Text="Increase" />
            <br />
            Withdraw balance by amount<br />
            <asp:TextBox ID="withdrawBalanceAmount" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="buttonWithdrawBalance" runat="server" OnClick="buttonWithdrawBalance_Click" Text="Withdraw" />
        </div>
    </form>
</body>
</html>
