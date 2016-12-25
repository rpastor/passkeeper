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
