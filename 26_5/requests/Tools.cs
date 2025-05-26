using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26_5
{
    public class Tools
    {
        public static bool IsValidID(string id)
        {
            if (int.TryParse(id, out _))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int GetIdNum()
        {
            string idStr = "";
            do
            {
                Console.WriteLine("Please enter ID in range 1-100:");
                idStr = Console.ReadLine();
            }
            while (!IsValidID(idStr));
            return int.Parse(idStr);
        }

        public static string GetString()
        {
            string userInput = Console.ReadLine();

            while (userInput.Length == 0)
            {
                Console.WriteLine("please enter a valid value");
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        public static int GetUserId()
        {
            Console.WriteLine("Enter your user id: ");
            string userId = Console.ReadLine();

            while (!int.TryParse(userId, out _))
            {
                Console.WriteLine("please enter a valid number: ");
                userId = Console.ReadLine();
            }

            return int.Parse(userId);
        }
    }
}
