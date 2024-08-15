using System;

namespace PermissionManager.UserInterface.Views
{
    public class HandleLogOut
    {
        public static void LogOut()
        {
            string input;
            do
            {
                Console.WriteLine("Are you sure you want to log out?\n1. YES / 2. NO");
                input = Console.ReadLine();
                Console.WriteLine();
            }
            while (input != "1" && input != "2");

            if (input == "1")
            {
                Console.WriteLine("Logging out...\nThank you for using our services. You have a great day!");
                Program.exitRequested = true;
            }
            return;
        }
    }
}
