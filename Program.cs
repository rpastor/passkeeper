using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassKeeper
{
    class PassKeeper
    {
        string[] getPasswordList()
        {
            return new string[] {"Error, not implemented"};
        }

        string GetPassword(string serviceName, string encryptedUnlockSecret)
        {
            return "Error, method not yet implemented.";
        }

        void AddPassword(string serviceName, string encryptedServicePassword)
        {

        }

        void UpdatePassword(string serviceName, string encryptedServicePassword, string encryptedUnlockSecret)
        {

        }

        void DeletePassword(string serviceName, string encryptedUnlockSecret)
        {

        }

    }

    namespace EncryptDecrypt
    {
        class EncryptDecrypt
        {

            static void EncryptFile(string inputFile,
            string outputFile,
            string secretKey)
            {

            }
            static void DecryptFile(string inputFile,
                string outputFile,
                string secretKey)
            {

            }
        }
    }



    public class Program
    {
        public static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                string arg = "";
                for (int i = 0, len = args.Length; i < len; i++)
                {
                    arg += args[i] + ", ";
                }
                Console.WriteLine("You supplied the following arguments:  {0}", arg);
            }
            Console.WriteLine("PassKeeper v0.1\nPress a key to exit...");
            Console.ReadKey();
        }
    }
}
