<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="CSE445_Assignment5.Staff" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Page</title>
    <style>
        body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; padding: 25px; background-color: #f9f9f9; }
        .dashboard-panel { background-color: #ffffff; border: 1px solid #dcdcdc; padding: 20px; margin-bottom: 30px; box-shadow: 0 2px 4px rgba(0,0,0,0.05); }
        .action-btn { margin: 5px 0; padding: 8px 16px; cursor: pointer; background-color: #005A9C; color: white; border: none; border-radius: 3px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Staff Page</h2>
            <div class="dashboard-panel">
                <p>Welcome, <asp:Label ID="lblStaffUsername" runat="server" Font-Bold="true" />!</p>
                <p>This page is for staff only. Here you can manage store inventory and user accounts. </p> <p>You can return to defaultPage by clicking the left arrow button on top left of the browser!</p>
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="action-btn" />
            </div>
        </div>
    </form>
</body>
</html>