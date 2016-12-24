using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassKeeper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter Encryption Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Press a key to exit...");
            Console.ReadKey();
        }
    }
}
