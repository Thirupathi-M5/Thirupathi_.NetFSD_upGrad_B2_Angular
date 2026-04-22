using System;

namespace Solids
{
    // Singleton Class
    public class ConfigurationManager
    {
        private static ConfigurationManager instance;

        // Properties
        public string ApplicationName { get; set; }
        public string Version { get; set; }
        public string DatabaseConnectionString { get; set; }

        // Private Constructor 
        private ConfigurationManager()
        {
            ApplicationName = "InventoryApp";
            Version = "1.0";
            DatabaseConnectionString = "Server=.;Database=AppDB;";
        }

        // Public Method to get single instance
        public static ConfigurationManager GetInstance()
        {
            if (instance == null)
            {
                instance = new ConfigurationManager();
            }
            return instance;
        }
    }

    //  (Main Execution)
    internal class SingletonPattern
    {
        public static void Main(string[] args)
        {
            // Get instance multiple times
            ConfigurationManager config1 = ConfigurationManager.GetInstance();
            ConfigurationManager config2 = ConfigurationManager.GetInstance();

            // Print values
            Console.WriteLine("App Name: " + config1.ApplicationName);
            Console.WriteLine("Version: " + config2.Version);

            // Check if both are same instance
            if (Object.ReferenceEquals(config1, config2))
            {
                Console.WriteLine("Same instance (Singleton works)");
            }
            else
            {
                Console.WriteLine("Different instances (Error)");
            }

            Console.ReadLine();
        }
    }
}