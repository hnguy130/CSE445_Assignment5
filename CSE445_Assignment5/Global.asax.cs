using System;
using System.Web;

namespace CSE445_Assignment5
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // initialize
            Application["TotalVisitors"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // lock the application
            Application.Lock();

            if (Application["TotalVisitors"] != null)
            {
                // bump up the total
                Application["TotalVisitors"] = (int)Application["TotalVisitors"] + 1;
            }
            else
            {
                Application["TotalVisitors"] = 1;
            }

            Application.UnLock();
        }
    }
}