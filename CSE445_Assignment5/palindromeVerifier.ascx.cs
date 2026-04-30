using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace defaultPage
{
    public partial class palindromeVerifier : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Take input
            String input = TextBox1.Text;

            //If input is empty
            if (TextBox1.Text.Length == 0)
                TextBox2.Text = "Please input a string";
            //If input is not empty
            else
            {
                //Write reverse string
                int length = TextBox1.Text.Length;
                string reverseInput = "";
                for(int i = length - 1; i >= 0; i--)
                {
                    reverseInput += input[i];
                }

                //Compare input and reverse string to see if they are palindromes
                if (input.Equals(reverseInput))
                    TextBox2.Text = "Input is a palindrome";
                else
                    TextBox2.Text = "Input is not a palindrome";
            }
        }
    }
}