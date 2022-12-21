using System;
using System.IO;

namespace DeleteJavaCheck;

internal class Program
{
    private static string f;

    static void Main(string[] args)
    {
        Console.WriteLine("DeleteJavaCheck Running");

        String[] lines = File.ReadAllLines(@"location.txt");
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i][..1] != "#")
            {
                f = (lines[i])+"\\JavaCheck.jar";
                if (File.Exists(f))
                {
                    File.Delete(f);
                    Console.WriteLine("File deleted!");
                } else
                {
                    Console.WriteLine("File doesn't exist, and couldn't be deleted.");
                }
            }
        }

        Console.WriteLine("Program completed. Press enter to terminate app");
        Console.ReadKey();
    }
}
