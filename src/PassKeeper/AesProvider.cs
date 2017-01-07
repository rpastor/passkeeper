using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PassKeeper
{
    static class AesProvider
    {
        internal const string CryptoKey = "DCE57B6982596DDFAB9332D121305F81";
        internal const string Salt = CryptoKey;
        internal const Int32 KeySize = 256;
        internal const Int32 BlockSize = 128;

        public static string Encrypt(string text)
        {
            if(string.IsNullOrEmpty(text))
                throw new ArgumentNullException("text");
            
            var provider = CreateProvider(Salt);

            var encryptor = provider.CreateEncryptor(provider.Key, provider.IV);
            using(var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(text);
                }
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
        public static string Decrypt(string cipherText)
        {
            if(string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");

            string text;

            var provider = CreateProvider(Salt);
            var decryptor = provider.CreateDecryptor(provider.Key, provider.IV);
            var cipher = Convert.FromBase64String(cipherText);

            using (var msDecrypt = new MemoryStream(cipher))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        text = srDecrypt.ReadToEnd();
                    }
                }
            }

            return text;
        }

        private static Aes CreateProvider(string salt)
        {
            if(salt == null) throw new ArgumentNullException("salt");
            var saltBytes = Encoding.ASCII.GetBytes(salt);
            var key = new Rfc2898DeriveBytes(CryptoKey, saltBytes);

            var provider = Aes.Create();
            provider.BlockSize = BlockSize;
            provider.KeySize = KeySize;
            provider.Key = key.GetBytes(provider.KeySize / 8);
            provider.IV = key.GetBytes(provider.BlockSize / 8);

            return provider;
        }
    }
}
