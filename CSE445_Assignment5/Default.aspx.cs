using System;
using EncryptionLibrary;

namespace CSE445_Assignment5
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // pull the total visitor count
            if (Application["TotalVisitors"] != null)
            {
                visitorCountLbl.Text = Application["TotalVisitors"].ToString();
            }
        }

        protected void executeHashBtn_Click(object sender, EventArgs e)
        {
            // grab the text
            string rawInput = plainTextBox.Text;
            hashOutputLbl.Text = "Hash: " + Hashing.GetHash(rawInput);
        }

        protected void executeServiceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // connect to the WCF
                MyService remoteService = new MyService();
                string reversed = remoteService.ReverseString(serviceInputBox.Text);
                serviceOutputLbl.Text = "Reversed Output: " + reversed;
            }
            catch (Exception ex)
            {
                serviceOutputLbl.Text = "Execution Fault: " + ex.Message;
            }
        }
    }
}