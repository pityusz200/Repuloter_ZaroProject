using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace repuloterProject.Services
{
    public static class Hash
    {
        /// <summary>
        /// Titkosítja a jelszavakat
        /// </summary>
        /// <param name="felhasználó név (salt)"></param>
        /// <param name="jelszó"></param>
        /// <returns></returns>
        public static string Encrypt(string text1, string text2)
        {

            byte[] textBytes = Encoding.UTF8.GetBytes(text1 + text2);
            byte[] hash = SHA512.Create().ComputeHash(textBytes);

            string hashedPwd = string.Empty;

            for (int i = 0; i < hash.Length; i++)
            {
                hashedPwd += hash[i].ToString("X2");
            }
            return hashedPwd;

        }

    }
}
