using System;
using PermissionManager.UserInterface.Utilities;

namespace PermissionManager.UserInterface.Views
{
    public class HandleCreate
    {
        public static void Create()
        {
            Console.WriteLine("Please enter a valid name.\n");
            string name = Console.ReadLine();
            if (!UserInputValidator.ValidateUserInput(name, @"^[a-zA-Z]{2,10}$"))
            {
                Console.WriteLine("Invalid Input. Please enter a valid name.");
                return;
            }

            Console.WriteLine("Please enter a valid lastName.\n");
            string lastName = Console.ReadLine();
            if (!UserInputValidator.ValidateUserInput(lastName, @"^[a-zA-Z]{2,10}$"))
            {
                Console.WriteLine("Invalid Input. Please enter a valid lastName.");
                return;
            }
   
            Console.WriteLine("Please select a valid PermissionType.\n");
            Console.WriteLine($"1. {DataAccess.Enums.PermissionType.Disease}\n2. {DataAccess.Enums.PermissionType.Errands}\n3. {DataAccess.Enums.PermissionType.Others}\n");

            string permissionType = Console.ReadLine();
            if (!UserInputValidator.ValidateUserInput(permissionType, @"^[1-3]$"))
            {
                Console.WriteLine("Invalid Input. Please enter a valid numeric value from 1 to 3.");
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

                    Services.PermissionManager.handler.Create(name, lastName, permissionType, customDescription);
                    Console.WriteLine($"Operation Succeeded: The new permission {type.ToString().ToUpper()}: {customDescription.ToUpper()}\nfor {name.ToUpper()} {lastName.ToUpper()} has been successfully requested on date: {DateTime.Now}");
                    return;
                }
            }
            Services.PermissionManager.handler.Create(name, lastName, permissionType);
            Console.WriteLine($"Operation Succeeded: The new permission {type.ToString().ToUpper()} for {name.ToUpper()} {lastName.ToUpper()}\nhas been successfully requested on date: {DateTime.Now}");
        }
    }


}
