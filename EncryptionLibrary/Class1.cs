using System.Text;
using System.Security.Cryptography;

namespace EncryptionLibrary
{
    public class Hashing
    {
        public static string GetHash(string inputData)
        {
            if (string.IsNullOrEmpty(inputData))
                return string.Empty;

            using (SHA256 cryptoProvider = SHA256.Create())
            {
                // convert the input text
                byte[] rawBytes = cryptoProvider.ComputeHash(Encoding.UTF8.GetBytes(inputData));
                StringBuilder hexBuilder = new StringBuilder();
                // loop through the hashed bytes
                for (int k = 0; k < rawBytes.Length; k++)
                {
                    hexBuilder.Append(rawBytes[k].ToString("x2"));
                }

                return hexBuilder.ToString();
            }
        }
    }
}