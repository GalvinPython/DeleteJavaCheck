/// <summary>
/// DeleteJavaCheck-rewritten is an improved version from my original DeleteJavaCheck program with more automation
/// Current Version: 2.0.1
/// Changelog:
/// - Rereleased V2.0, but with the missing packages
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace DeleteJavaCheck_Rewritten
{

    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("DeleteJavaCheck 2.0 (Assembly: {0}) Running!", Assembly.GetEntryAssembly().GetName().Version);

            string targetFile = @"\javacheck.jar";
            bool checkCustom = ReadSettings();

            DestroyOld(targetFile);
            DestroyNew(targetFile);
            if (checkCustom)
            {
                DestroyCustom(targetFile);
            }
            EndProgram();
        }

        static bool ReadSettings()
        {
            try
            {
                System.Collections.Specialized.NameValueCollection appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty. Will not check custom installs!");
                }
                else
                {
                    string directoryPath = appSettings[0];
                    if (Directory.Exists(directoryPath))
                    {
                        Console.WriteLine("Will check: {0}", directoryPath);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Custom installation directory: '{0}' is not valid", directoryPath);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
            return false;
        }

        static void WriteSetting()
        {
            Console.WriteLine("Enter the new directory (that ends with \\game)");
            string dir = Console.ReadLine();
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                settings["customLocation"].Value = dir;
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings!");
            }
        }

        static void WriteSection(string phrase, char character)
        {
            string border = new string(character, phrase.Length + 4);
            Console.WriteLine(border);
            Console.WriteLine("{0} {1} {0}", character, phrase);
            Console.WriteLine(border);
        }

        // destroys javacheck.jar in the current launcher, but the one that doesn't support Bedrock
        static void DestroyOld(string targetFile)
        {
            Console.WriteLine("\n");
            WriteSection("Checking Old Launcher", "=".ToCharArray()[0]);
            string targetDir = @"C:\Program Files (x86)\Minecraft Launcher\game";
            if (Directory.Exists(targetDir))
            {
                Console.WriteLine("Java Launcher Exists!");
                targetDir += targetFile;
                if (File.Exists(targetDir))
                {
                    File.Delete(targetDir);
                    Console.WriteLine("File deleted!");
                }
                else
                {
                    Console.WriteLine("File already deleted!");
                }
            }
            else
            {
                Console.WriteLine("Java Laucher doesn't exist or you have a custom installation location!");
            }
        }

        // destroys javacheck.jar in the new Microsoft Store launcher
        static void DestroyNew(string targetFile)
        {
            Console.WriteLine("\n");
            WriteSection("Checking New Launcher", "=".ToCharArray()[0]);
            string targetDir = @"%LOCALAPPDATA%\Packages\Microsoft.4297127D64EC6_8wekyb3d8bbwe\LocalCache\Local\game";
            targetDir = Environment.ExpandEnvironmentVariables(targetDir);
            if (Directory.Exists(targetDir))
            {
                Console.WriteLine("Bedrock Launcher Exists!");
                targetDir += targetFile;
                if (File.Exists(targetDir))
                {
                    File.Delete(targetDir);
                    Console.WriteLine("File deleted!");
                }
                else
                {
                    Console.WriteLine("File already deleted!");
                }
            }
            else
            {
                Console.WriteLine("Bedrock Laucher Doesn't Exist!");
            }
        }

        // destroys javacheck.jar in the user's custom install
        static void DestroyCustom(string targetFile)
        {
            Console.WriteLine("\n");
            WriteSection("Checking Custom Launcher", "=".ToCharArray()[0]);
            string targetDir = ConfigurationManager.AppSettings[0];
            targetDir += targetFile;
            if (File.Exists(targetDir))
            {
                File.Delete(targetDir);
                Console.WriteLine("File deleted!");
            }
            else
            {
                Console.WriteLine("File already deleted!");
            }
        }

        static void EndProgram()
        {
            Console.WriteLine("\nProgram completed. Enter one of the following options:");
            Console.WriteLine("1: Enter/update custom file directory");
            Console.WriteLine("Enter: Quit");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                WriteSetting();
            }
        }
    }
}