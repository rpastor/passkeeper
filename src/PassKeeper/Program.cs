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
                Initialize();
            }
            catch (Exception ex)
            {
                Usage();

                LogExceptionToConsole(ex);
            }
        }

        public static ProgramOptions GetOptions(string[] args) 
        {
            var options = new ProgramOptions();
            options.CommandType = GetCommandType(args[0]);

            // TODO: Fill the rest of the options

            return options;
        }

        public static CommandType GetCommandType(string command) 
        {
            switch (command.ToLower()) {
                case "help":
                    return CommandType.Help;
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

        private static void LogExceptionToConsole(Exception e)
        {
            Console.WriteLine();
            Console.WriteLine("Exception Details: ---------------------------");
            Console.WriteLine(e.ToString());
        }

        private static void Initialize()
        {
            bool isWindows = false;
            
            // TODO:  Add other supported platforms.

            isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows);
            // If Windows, check if %appdata%/PassKeeper directory exists.
            if (isWindows)
            {
                try
                {
                    string dataPath = "";
                    string passkeeperDataPath = "\\PassKeeper\\data";
                    string appdata = Environment.GetEnvironmentVariable("APPDATA");

                    dataPath = (appdata + passkeeperDataPath);

                    if (System.IO.Directory.Exists(dataPath))
                    {
                        Console.WriteLine("Path exists at {0}.", dataPath);
                        return;
                    }

                    System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(dataPath);
                    Console.WriteLine("Directory created at:  {0}.", System.IO.Directory.GetCreationTime(dataPath));
                }
                catch (Exception ex)
                {
                    // TODO: Handle the execeptions.
                    LogExceptionToConsole(ex);
                }
            }
        }
    }
}
