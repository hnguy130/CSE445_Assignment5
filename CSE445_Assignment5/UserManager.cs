using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CSE445_Assignment5
{
    public class UserManager
    {
        private static readonly string xmlPath = HttpContext.Current.Server.MapPath("~/App_Data/Users.xml");
        private static readonly string xmlPath1 = HttpContext.Current.Server.MapPath("~/App_Data/Member.xml");
        private static readonly string xmlPath2 = HttpContext.Current.Server.MapPath("~/App_Data/Staff.xml");

        public static void RegisterUser(string username, string passwordHash, string role)
        {
            XDocument doc;
            if (File.Exists(xmlPath))
            {
                doc = XDocument.Load(xmlPath);
            }
            else
            {
                doc = new XDocument(new XElement("Users"));
            }

            doc.Element("Users").Add(new XElement("User",
                new XElement("Username", username),
                new XElement("Password", passwordHash),
                new XElement("Role", role)));
            doc.Save(xmlPath);
        }

        public static string ValidateUser(string username, string passwordHash)
        {

            var combinedList = Enumerable.Empty<XElement>();
            combinedList = combinedList.Concat(XDocument.Load(xmlPath1).Descendants("User"));
            combinedList = combinedList.Concat(XDocument.Load(xmlPath2).Descendants("User"));

            var user = combinedList.FirstOrDefault(u =>
                (string)u.Element("Username") == username && (string)u.Element("Password") == passwordHash);

            return user != null ? (string)user.Element("Role") : null;
        }
    }
}