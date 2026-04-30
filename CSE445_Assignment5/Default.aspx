<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSE445_Assignment5.Default" %>
<%@ Register Src="~/palindromeVerifier.ascx" TagPrefix="uc" TagName="Palindrome" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assignment 5 - Web Application Portal</title>
    <style>
        body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; padding: 25px; background-color: #f9f9f9; }
        .dashboard-panel { background-color: #ffffff; border: 1px solid #dcdcdc; padding: 20px; margin-bottom: 30px; box-shadow: 0 2px 4px rgba(0,0,0,0.05); }
        .data-grid { width: 100%; border-collapse: collapse; margin-top: 15px; font-size: 14px; }
        .data-grid th, .data-grid td { border: 1px solid #e0e0e0; padding: 12px; text-align: left; }
        .data-grid th { background-color: #f0f8ff; color: #333; }
        .action-btn { margin: 5px 0; padding: 8px 16px; cursor: pointer; background-color: #005A9C; color: white; border: none; border-radius: 3px; }
        .action-btn:hover { background-color: #004080; }
        .metric-highlight { color: #d2691e; font-weight: bold; font-size: 1.1em; }
        .result-text { font-family: monospace; color: #2e8b57; display: block; margin-top: 10px; }
    </style>
</head>
<body>
    <form id="mainForm" runat="server">
        <h2>Assignment 5 Application Portal</h2>
        <p>Team Submission by: <strong>Chin Kuo, Ho Dang Khoa Nguyen, Kesler Lee</strong> (Site 93)</p>

        <div class="dashboard-panel">
            <h3>Navigation Hub</h3>
            <asp:Button ID="memberPortalBtn" runat="server" Text="Access Member Area" PostBackUrl="~/Member.aspx" CssClass="action-btn" />
            <asp:Button ID="staffPortalBtn" runat="server" Text="Access Staff Area" PostBackUrl="~/Staff.aspx" CssClass="action-btn" />
        </div>

        <div class="dashboard-panel">
            <h3>Implemented Components Directory</h3>
            <table class="data-grid">
                <thead>
                    <tr>
                        <th>Provider Name</th>
                        <th>Component Type</th>
                        <th>Component Description</th>
                        <th>Actual Resources & Methods</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Chin Kuo</td>
                        <td>Local Component (DLL)</td>
                        <td>Generates a SHA256 cryptographic hash from a given string input.</td>
                        <td>C# Class Library utilized for secure data transformation.</td>
                    </tr>
                    <tr>
                        <td>Chin Kuo</td>
                        <td>Local Component (Global.asax)</td>
                        <td>Tracks global application sessions to maintain a visitor count.</td>
                        <td>Session_Start event handler incrementing an Application state variable.</td>
                    </tr>
                    <tr>
                        <td>Chin Kuo</td>
                        <td>Remote Service (WCF)</td>
                        <td>Processes strings to return the reversed character sequence.</td>
                        <td>WSDL .svc service deployed on WebStrar architecture.</td>
                    </tr>
                    <tr>
                        <td>Ho Dang Khoa Nguyen</td>
                        <td>User control</td>
                        <td>Verifies if a string is a palindrome or not</td>
                        <td>User control embedded in this page</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Ho Dang Khoa Nguyen</td>
                        <td>WSDL Service</td>
                        <td>Bitcoin management service that allows viewing balance, increasing balance, deducting balance, sign up, log in</td>
                        <td class="auto-style4">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="bitcoinServicePage.aspx">WSDL service written in C#, and called as service reference to TryIt page</asp:HyperLink>
            </td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div class="dashboard-panel">
            <h3>Component Testing Interface (TryIt)</h3>
            
            <div>
                <h4>1. Global State Monitor</h4>
                <span>Total Active Sessions/Visits: </span>
                <asp:Label ID="visitorCountLbl" runat="server" Text="0" CssClass="metric-highlight"></asp:Label>
            </div>
            
            <hr style="border-top: 1px solid #eee; margin: 20px 0;" />

            <div>
                <h4>2. Cryptographic Hash Generator (DLL)</h4>
                <asp:TextBox ID="plainTextBox" runat="server" Width="300px" placeholder="Enter text to hash..."></asp:TextBox>
                <asp:Button ID="executeHashBtn" runat="server" Text="Generate SHA256" OnClick="executeHashBtn_Click" CssClass="action-btn" />
                <asp:Label ID="hashOutputLbl" runat="server" CssClass="result-text"></asp:Label>
            </div>

            <hr style="border-top: 1px solid #eee; margin: 20px 0;" />

            <div>
                <h4>3. String Manipulation Service (WCF)</h4>
                <asp:TextBox ID="serviceInputBox" runat="server" Width="300px" placeholder="Enter text to reverse..."></asp:TextBox>
                <asp:Button ID="executeServiceBtn" runat="server" Text="Process String" OnClick="executeServiceBtn_Click" CssClass="action-btn" />
                <asp:Label ID="serviceOutputLbl" runat="server" CssClass="result-text"></asp:Label>
            </div>
            <div>
                <h4>4. Palindrome verifier</h4>
                <uc:Palindrome ID="myPalindrome" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>