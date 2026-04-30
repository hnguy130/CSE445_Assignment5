using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.IO;
using System.Web.Hosting;

namespace wsdl_elective_service
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class User
    {
        //C# requires get, set to be able to do commands like user.account = string
        public string account { get; set; }
        public string password { get; set; }
        public string cookie { get; set; }
        public double balance { get; set; }
    }

    public class WebService1 : System.Web.Services.WebService
    {
        // create a new variable to prevent having to create a variable repeatedly in methods
        public static List<User> database = new List<User>();
        //database file is database.json in project folder
        public static string pathToFile = HostingEnvironment.MapPath("~/database.json");

        //read data from central database.json into client/class static variable(database)
        public static void readDatabase()
        {
            string database_string = File.ReadAllText(pathToFile);

            JavaScriptSerializer ser = new JavaScriptSerializer();
            database = ser.Deserialize<List<User>>(database_string);
        }

        //write data from client/class static variable(database) into central database.json
        public static void writeDatabase()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            File.WriteAllText(pathToFile, ser.Serialize(database));
        }

        //To create an account 
        [WebMethod]
        public string createAccount(String account, String password)
        {
            //know the current database situation to check against database
            readDatabase();

            //scan every single user inside database
            if (database.Any(user => user.account == account))
            {
                return "User account already exists";
            }

            database.Add(new User
            {
                account = account,
                password = password,
                cookie = "",
                balance = 0
            });

            writeDatabase();

            return "Successfully created account " + account;
        }

        //create a cookie every time a method/action is called related to bitcoin
        public string createCookie()
        {
            Random random = new Random();

            string cookie = random.Next(1000, 9999).ToString();

            return cookie;
        }

        [WebMethod]
        public string signIn(string account, string password)
        {
            //know the current database situation to check against database
            readDatabase();

            //scan every single user inside database
            User user = database.FirstOrDefault(
                anyUser => anyUser.account == account &&
                anyUser.password == password);

            //if user isnt available
            if (user == null)
            {
                return "Wrong sign in details";
            }
            user.cookie = createCookie();

            writeDatabase();

            return user.cookie;
        }

        [WebMethod]

        public string[] viewBalance(string account, string password, string cookie)
        {

            string[] result = new string[2];

            //know the current database situation to check against database
            readDatabase();

            //scan every single user inside database
            User user = database.FirstOrDefault(
                anyUser => anyUser.account == account &&
                anyUser.password == password &&
                anyUser.cookie == cookie);

            //if user isnt available
            if (user == null)
            {

                result[0] = "";
                result[1] = "wrong session details";

                return result;
            }

            user.cookie = createCookie();
            writeDatabase();

            result[0] = user.cookie;
            result[1] = user.balance.ToString();

            return result;
        }

        [WebMethod]
        public string[] addBalance(string account, string password, string cookie, double amount)
        {
            string[] result = new string[2];
            //know the current database situation to check against database
            readDatabase();
            //scan every single user inside database
            User user = database.FirstOrDefault(
                anyUser => anyUser.account == account &&
                anyUser.password == password &&
                anyUser.cookie == cookie);
            //if user isnt available
            if (user == null)
            {

                result[0] = "";
                result[1] = "wrong session details";

                return result;
            }
            user.balance += amount;
            user.cookie = createCookie();
            writeDatabase();

            result[0] = user.cookie;
            result[1] = user.balance.ToString();

            return result;
        }

        [WebMethod]
        public string[] withdrawBalance(string account, string password, string cookie, double amount)
        {

            string[] result = new string[2];

            //know the current database situation to check against database
            readDatabase();

            //scan every single user inside database
            User user = database.FirstOrDefault(
                anyUser => anyUser.account == account &&
                anyUser.password == password &&
                anyUser.cookie == cookie);

            //if user isnt available
            if (user == null)
            {

                result[0] = "";
                result[1] = "wrong session details";

                return result;
            }

            user.cookie = createCookie();

            //only deduct balance if balance has enough bitcoin to deduct
            if (user.balance >= amount)
            {
                user.balance -= amount;
            }
            writeDatabase();

            result[0] = user.cookie;
            result[1] = user.balance.ToString();

            return result;
        }

    }
}
