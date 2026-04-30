using System;
using System.Web.Security;

namespace CSE445_Assignment5
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null || Session["Role"].ToString() != "Staff")
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                lblStaffUsername.Text = Session["Username"].ToString();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }
    }
}