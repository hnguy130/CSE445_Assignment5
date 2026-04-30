using System;
using System.Web.Security;

namespace CSE445_Assignment5
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If already logged in, skip login page
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string passwordHash = EncryptionLibrary.Hashing.GetHash(password);

            string role = UserManager.ValidateUser(username, passwordHash);

            if (role == "Member")
            {
                Session["Username"] = username;
                Session["Role"] = role;
                FormsAuthentication.SetAuthCookie(username, false);
                Response.Redirect("~/Member.aspx");
            }
            else if (role == "Staff")
            {
                Session["Username"] = username;
                Session["Role"] = role;
                FormsAuthentication.SetAuthCookie(username, false);
                Response.Redirect("~/Staff.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
            }
        }
    }
}