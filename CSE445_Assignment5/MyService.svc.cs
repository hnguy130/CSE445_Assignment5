using System;

namespace CSE445_Assignment5
{
    public class MyService : IMyService
    {
        public string ReverseString(string textInput)
        {
            if (string.IsNullOrEmpty(textInput))
            {
                return string.Empty;
            }
            // break the string
            char[] characters = textInput.ToCharArray();
            Array.Reverse(characters);
            return new string(characters);
        }

        public int GetStringLength(string textInput)
        {
            if (string.IsNullOrEmpty(textInput))
            {
                return 0;
            }
            // quickly grab the total number
            return textInput.Length;
        }
    }
}