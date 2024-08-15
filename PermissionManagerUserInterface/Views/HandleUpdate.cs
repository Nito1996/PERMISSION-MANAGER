using System;
using PermissionManager.UserInterface.Utilities;

namespace PermissionManager.UserInterface.Views
{
    public class HandleUpdate
    {
        public static void Update()
        {
            HandleRead.Read();
            if (Services.PermissionManager.handler.Read().Count == 0) return;

            Console.WriteLine("\nWhich permission would you like to update?");
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

            Console.WriteLine("\nPlease enter a valid name.");
            string name = Console.ReadLine();
            if (!UserInputValidator.ValidateUserInput(name, @"^[a-zA-Z]{2,10}$"))
            {
                Console.WriteLine("\nInvalid Input. Please enter a valid name.");
                return;
            }

            Console.WriteLine("\nPlease enter a valid lastName.");
            string lastName = Console.ReadLine();
            if (!UserInputValidator.ValidateUserInput(lastName, @"^[a-zA-Z]{2,10}$"))
            {
                Console.WriteLine("\nInvalid Input. Please enter a valid lastName.");
                return;
            }

            Console.WriteLine("\nPlease select a valid PermissionType.");
            Console.WriteLine($"1. {DataAccess.Enums.PermissionType.Disease}\n2. {DataAccess.Enums.PermissionType.Errands}\n3. {DataAccess.Enums.PermissionType.Others}\n");

            string permissionType = Console.ReadLine();
            if (!UserInputValidator.ValidateUserInput(permissionType, @"^[1-3]$"))
            {
                Console.WriteLine("\nInvalid Input. Please enter a valid numeric value from 1 to 3.");
                return;
            }

            var type = Enum.Parse<DataAccess.Enums.PermissionType>(permissionType);

            if (permissionType == "3")
            {
                string customDescription;
                string input;
                do
                {
                    Console.WriteLine("\nPlease, feel free to describe openly which kind of permission you're asking for.");
                    customDescription = Console.ReadLine();
                    Console.WriteLine($"\nAre you sure the next explanation is okay to you?\nOTHERS: {customDescription}\n1. YES / 2. NO / 3. EXIT\n");
                    input = Console.ReadLine();
                }
                while (input != "1" && input != "3");

                if (input == "3") return;
                if (input == "1")
                {
                    Console.WriteLine($"\nOperation Succeeded.\n{Services.PermissionManager.handler.Read()[userChoice - 1].PermissionDateTime} {Services.PermissionManager.handler.Read()[userChoice - 1].Name.ToUpper()} {Services.PermissionManager.handler.Read()[userChoice - 1].LastName.ToUpper()}: {Services.PermissionManager.handler.Read()[userChoice - 1].Type.ToString().ToUpper()}\nHAS BEEN UPDATED TO:\n{DateTime.Now}{name.ToUpper()} {lastName.ToUpper()}: {type.ToString().ToUpper()}");
                    Services.PermissionManager.handler.Update(userChoice - 1, name, lastName, permissionType, customDescription);
                    return;
                }
            }

            Console.WriteLine($"\nOperation Succeeded.\n{Services.PermissionManager.handler.Read()[userChoice - 1].PermissionDateTime} {Services.PermissionManager.handler.Read()[userChoice - 1].Name.ToUpper()} {Services.PermissionManager.handler.Read()[userChoice - 1].LastName.ToUpper()}: {Services.PermissionManager.handler.Read()[userChoice - 1].Type.ToString().ToUpper()}\nHAS BEEN UPDATED TO:\n{DateTime.Now}{name.ToUpper()} {lastName.ToUpper()}: {type.ToString().ToUpper()}");
            Services.PermissionManager.handler.Update(userChoice - 1, name, lastName, permissionType);
        }
    }
}
