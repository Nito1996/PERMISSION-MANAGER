using System;
using PermissionManager.UserInterface.Utilities;

namespace PermissionManager.UserInterface.Views
{
    public class HandleDelete
    {
        public static void Delete()
        {
            HandleRead.Read();
            if (Services.PermissionManager.handler.Read().Count == 0) return;

            Console.WriteLine("\nWhich permission would you like to delete?");
            string index = Console.ReadLine();
            if (!UserInputValidator.ValidateUserInput(index, @"^[1-9]\d*$"))
            {
                Console.WriteLine("\nInvalid Input. Please enter a valid numeric value.");
                return;
            }

            var userChoice = int.Parse(index);
            if (userChoice <= 0 || userChoice > Services.PermissionManager.handler.Read().Count)
            {
                Console.WriteLine("\nInvalid Input. That permission hasn't been granted in this Matrix");
                return;
            }

            string input;
            do
            {
                Console.WriteLine($"\nAre you sure you want to delete {Services.PermissionManager.handler.Read()[userChoice - 1].PermissionDateTime} {Services.PermissionManager.handler.Read()[userChoice - 1].Name.ToUpper()} {Services.PermissionManager.handler.Read()[userChoice - 1].LastName.ToUpper()} {Services.PermissionManager.handler.Read()[userChoice - 1].Type.ToString().ToUpper()}?\n1. YES / 2. NO");
                input = Console.ReadLine();
            }
            while (input != "1" && input != "2");

            if (input == "2") return;

            Console.WriteLine($"\nOperation Succeeded: " +
            $"{Services.PermissionManager.handler.Read()[userChoice - 1].PermissionDateTime} " +
            $"{Services.PermissionManager.handler.Read()[userChoice - 1].Name.ToUpper()} " +
            $"{Services.PermissionManager.handler.Read()[userChoice - 1].LastName.ToUpper()}: " +
            $"{Services.PermissionManager.handler.Read()[userChoice - 1].Type.ToString().ToUpper()} have been successfully deleted.");

            Services.PermissionManager.handler.Delete(userChoice - 1);
        }
    }
}
