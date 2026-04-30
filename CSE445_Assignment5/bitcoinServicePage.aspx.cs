using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace tryitpages
{
    public partial class wsdl_elective_service : System.Web.UI.Page
    {

        public static CSE445_Assignment5.bitcoinService.WebService1SoapClient client 
            = new CSE445_Assignment5.bitcoinService.WebService1SoapClient();

        public static string splitResult(string result)
        {

            return null;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonSignUp_Click(object sender, EventArgs e)
        {
            string result = client.createAccount(newAccount.Text, newPassword.Text);
            signUpResult.Text = result;
        }

        protected void buttonSignIn_Click(object sender, EventArgs e)
        {
            string result = client.signIn(existingAccount.Text, existingPassword.Text);
            

            if (result.Equals("wrong sign in details"))
            {
                signInResult.Text = result;
                return;
            }
                
            else
            {
                signInResult.Text = "Successfully signed in";
                cookie.Text = result;
            }
        }

        protected void buttonViewBalance_Click(object sender, EventArgs e)
        {
            string[] result = client.viewBalance(existingAccount.Text, existingPassword.Text, cookie.Text).ToArray();

            if(result[1].Equals("wrong session details"))
            {
                cookie.Text = "";
                balance.Text = "";
                signInResult.Text = "please log in again";
                return;
            }
            else
            {
                cookie.Text = result[0];
                balance.Text = result[1];
            }
        }

        protected void buttonIncreaseBalance_Click(object sender, EventArgs e)
        {
            string[] result = client.addBalance(existingAccount.Text, existingPassword.Text, cookie.Text, Convert.ToDouble(increaseBalanceAmount.Text)).ToArray();

            if (result[1].Equals("wrong session details"))
            {
                cookie.Text = "";
                balance.Text = "";
                signInResult.Text = "please log in again";
                return;
            }
            else
            {
                cookie.Text = result[0];
                balance.Text = result[1];
            }
        }

        protected void buttonWithdrawBalance_Click(object sender, EventArgs e)
        {
            string[] result = client.withdrawBalance(existingAccount.Text, existingPassword.Text, cookie.Text, Convert.ToDouble(withdrawBalanceAmount.Text)).ToArray();

            if (result[1].Equals("wrong session details"))
            {
                cookie.Text = "";
                balance.Text = "";
                signInResult.Text = "please log in again";
                return;
            }
            else
            {
                cookie.Text = result[0];
                balance.Text = result[1];
            }
        }
    }
}