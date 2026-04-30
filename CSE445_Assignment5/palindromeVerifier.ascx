<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="palindromeVerifier.ascx.cs" Inherits="defaultPage.palindromeVerifier" %>
Enter string to check if it is palindrome<br />
<asp:TextBox ID="TextBox1" runat="server" Height="86px" Width="468px" TextMode="MultiLine"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Check" />
<p>
    Result</p>
<p>
    <asp:TextBox ID="TextBox2" runat="server" Height="86px" Width="468px"></asp:TextBox>
</p>

