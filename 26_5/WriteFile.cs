using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _26_5
{
    public class WtriteFile
    {
        private static string GetText()
        {
            Console.WriteLine("Enter text to write: ");
            string text = Console.ReadLine();
            return text;
        }

        private static string GetFileName()
        {
            Console.WriteLine("Enter a file name: ");
            string fileName = Console.ReadLine();
            return fileName;
        }

        private static void WritetoFile(string fileName, string text)
        {
            try
            {
                string path = "./" + fileName + ".text";
                File.WriteAllText(path, text);
                Console.WriteLine($"file created in: {path}");
            }

            catch
            {
                Console.WriteLine("Error");
            }
            
        }

        private static bool IsValidFileName(string path)
        {
            return File.Exists(path);
        }


        private static void ReadFromFile(string filePath)
        {
            if (IsValidFileName(filePath))
            {
                string fileText = File.ReadAllText(filePath);
                Console.WriteLine(fileText);
            }
            else
            {
                Console.WriteLine("Error file not exists");
            }
        }

        private static bool IsValidChoice(string choice)
        {
            if(choice == "1" || choice == "2" || choice == "0")
            {
                return true;
            }
            else
            {
                Console.WriteLine("enter valid choice");
                return false;
            }
        }

        private static string ShowMenue()
        {
            Console.WriteLine("====Menue====\n"+
                "***enter 1 to creat file***\n" +
                "***enter 2 to read from file\n" +
                "***enter 0 to exit***\n");
            string choice = Console.ReadLine();
            return choice;

        }

        private static string GetChoice()
        {
            string choice = ShowMenue();
            while (!IsValidChoice(choice))
            {
                choice = ShowMenue();
            }
            return choice;
        }
        public static void RunMenu()
        {
            bool run = true;
            while (run)
            {
                string choice = GetChoice();

                switch(choice)
                {
                    case "0":
                        run = false;
                        break;
                    case "1":
                        string text = GetText();
                        string fileName = GetFileName();
                        WritetoFile(fileName, text);
                        continue;
                    case "2":
                        string filePath = GetFileName();
                        ReadFromFile(filePath);
                        continue;
                }
            }
        }

    }
}
