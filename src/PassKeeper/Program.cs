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
                FileStorage storage = new FileStorage();
                PassKeeper passkeeper = new PassKeeper(storage);

                switch (options.CommandType)
                {
                    case CommandType.Help:
                        Usage();
                        break;
                    case CommandType.List:
                        string[] list = passkeeper.GetPasswordList();
                        foreach (string serviceName in list)
                        {
                            Console.WriteLine(serviceName);
                        }
                        break;
                    case CommandType.Add:
                        passkeeper.AddPassword(options.ServiceName, options.ServicePassword);
                        break;
                    case CommandType.Get:
                        string password = passkeeper.GetPassword(options.ServiceName, options.UnlockSecret);
                        Console.WriteLine(password);
                        break;
                    case CommandType.Update:
                       passkeeper.UpdatePassword(options.ServiceName, options.ServicePassword, options.UnlockSecret);
                       break;
                    case CommandType.Delete:
                       passkeeper.DeletePassword(options.ServiceName, options.UnlockSecret);
                       break;
                    default:
                        throw new ArgumentException("Unrecognized command: " + options.CommandType);
                }

                // DEBUG
                // Console.WriteLine("DEBUG MSG: Press a key to exit...");
                // Console.ReadKey();
            }
            catch (Exception ex)
            {
                // Usage();

                LogExceptionToConsole(ex);
            }
        }

        public static ProgramOptions GetOptions(string[] args) 
        {
            var options = new ProgramOptions();
            options.CommandType = GetCommandType(args[0]);

            if (args.Length > 1) {
                for (var i = 1; i < args.Length; i++) {
                    switch (args[i]) {
                        case "-s":
                            options.ServiceName = args[++i];
                            break;
                        case "-p":
                            options.ServicePassword = args[++i];
                            break;
                        case "-u":
                            options.UnlockSecret = args[++i];
                            break;
                    }
                }
            }

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
            bool isWindows  = false;
            bool isOSX      = false;
            
            // TODO:  Add other supported platforms.

            isWindows   = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows);
            isOSX       = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX);
            // If Windows, check if %appdata%/PassKeeper directory exists.
            if (isWindows)
            {
                try
                {
                    string path = "";
                    string appPath = "\\PassKeeper\\data";
                    string basePath = Environment.GetEnvironmentVariable("APPDATA");

                    path = (basePath + appPath);

                    if (System.IO.Directory.Exists(path))
                    {
                        // DEBUG
                        Console.WriteLine("DEBUG MSG:\nPath already exists at {0}.", path);

                        return;
                    }

                    System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(path);

                    // DEBUG
                    Console.WriteLine("DEBUG MSG:\nDirectory created at:  {0}.", System.IO.Directory.GetCreationTime(path));
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
