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
    public partial class Register : System.Web.UI.Page
    {

        public static string pathToFile = HostingEnvironment.MapPath("~/App_Data/Users.xml");
        public static XmlDocument database = new XmlDocument();
        public static XmlElement root;
        public static void readDatabase()
        {
            database.Load(pathToFile);
            root = database.DocumentElement;
        }
        public static void addAccountAndSaveDatabase(string username, string password)
        {
            XmlElement account = database.CreateElement("User");
            XmlElement accountUsername = database.CreateElement("Username");
            XmlElement accountPassword = database.CreateElement("Password");
            XmlElement accountRole = database.CreateElement("Role");

            accountUsername.InnerText = username;
            accountPassword.InnerText = password;
            accountRole.InnerText = "Member";

            account.AppendChild(accountUsername);
            account.AppendChild(accountPassword);
            account.AppendChild(accountRole);

            root.AppendChild(account);
            database.Save(pathToFile);
        }

        public void generateNewImageCode()
        {
            string imageCode = new Random().Next(100, 500).ToString();
            Session["imageCode"] = imageCode;
            Label2.Text = imageCode;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // when page first loads, IsPostBack is false, so generate new image code
            // when page loads after clicking a button, IsPostBack is true, so nothing happens
            if(!IsPostBack)
            {
                generateNewImageCode();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            string password = TextBox2.Text;
            string userImageCode = TextBox3.Text;
            
            //check user's code for verifying code image
            if(userImageCode != Session["imageCode"].ToString())
            {
                Label1.Text = "Wrong bot verification code, enter again.";
                generateNewImageCode();
                return;
            }

            //read database of accounts and see if username already exists
            readDatabase();
            foreach(XmlNode account in root.ChildNodes)
            {
                if(account["Username"].InnerText == username)
                {
                    Label1.Text = "Username was taken";
                    generateNewImageCode();
                    return;
                }
            }

            //username doesn't exist, so add account with username and hashed password to database
            password = EncryptionLibrary.Hashing.GetHash(password);

            addAccountAndSaveDatabase(username, password);

            Label1.Text = "Account successfully added";

            //generate new image code again after successfully adding new password
            generateNewImageCode();
        }
    }
}