using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassKeeper
{
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

    class Storage
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

    public class Program
    {
        public static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Error, required arguments missing.");
            }
            Console.WriteLine("Press a key to exit...");
            Console.ReadKey();
        }
    }
}
