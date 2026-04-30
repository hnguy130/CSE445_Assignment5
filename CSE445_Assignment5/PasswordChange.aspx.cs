using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Hosting;
using System.Xml;

namespace CSE445_Assignment5
{
    public partial class PasswordChange: System.Web.UI.Page
    {

        public static string pathToFile = HostingEnvironment.MapPath("~/App_Data/Member.xml");
        public static XmlDocument database = new XmlDocument();
        public static XmlElement root;
        public static void readDatabase()
        {
            database.Load(pathToFile);
            root = database.DocumentElement;
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            string oldPassword = TextBox2.Text;
            string newPassword = TextBox3.Text;

            readDatabase();

            //hash old password to match against database's hashed password
            oldPassword = EncryptionLibrary.Hashing.GetHash(oldPassword);


            //search for username in database
            foreach(XmlNode account in root.ChildNodes)
            {
                //if username exists, check password
                if(account["Username"].InnerText == username)
                {
                    //if hashed password matches, change password to new password hashed
                    if(account["Password"].InnerText == oldPassword)
                    {
                        account["Password"].InnerText = EncryptionLibrary.Hashing.GetHash(newPassword);

                        database.Save(pathToFile);
                        Label1.Text = "Password has been set to new password";
                        return;
                    }
                    //username exists, yet old password is wrong, so return
                    Label1.Text = "Old password is entered incorrectly";
                    return;
                }
            }
            //after checking entire database, username doesn't exist
            Label1.Text = "Username doesn't exist";

        }
    }
}