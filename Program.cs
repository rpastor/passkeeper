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
            try 
            {
                var options = GetOptions(args);

                // DEBUG
                Console.WriteLine("Command: " + options.CommandType.ToString());

                // TODO:
                // Initialize Passkeeper and Storage
                // Handle command
            }
            catch (Exception ex)
            {
                Usage();

                Console.WriteLine();
                Console.WriteLine("Exception Details: ---------------------------");
                Console.WriteLine(ex.ToString());
            }
        }

        private static ProgramOptions GetOptions(string[] args) 
        {
            var options = new ProgramOptions();
            options.CommandType = GetCommandType(args[0]);

            // TODO: Fill the rest of the options

            return options;
        }

        private static CommandType GetCommandType(string command) 
        {
            switch (command.ToLower()) {
                case "list":
                    return CommandType.List;
                case "add":
                    return CommandType.Add;
                case "get":
                    return CommandType.Get;
                case "update":
                    return CommandType.Update;
                case "delete":
                    return CommandType.Delete;
                default:
                    throw new ArgumentException("Unrecognized command: " + command);
            }
        }

        private static void Usage()
        {
            Console.WriteLine("Incorrect usage: refer to documentation.");
        }
    }
}
