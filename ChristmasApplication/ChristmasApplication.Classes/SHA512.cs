using System;
using System.Security.Cryptography;

namespace ChristmasApplication.Classes
{
    public class SHA512 
    {
        public static string GetSHA512(string String)
        {
            byte[] hashValue;
            byte[] message = System.Text.Encoding.UTF8.GetBytes(String);

            SHA512Managed hashString = new SHA512Managed();
            string hex = "";

            hashValue = hashString.ComputeHash(message);

            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }

            return hex;
        }
    }
}

