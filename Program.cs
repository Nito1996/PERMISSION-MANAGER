using System;
using System.Collections.Generic;
using System.Security;

namespace PermissionManager
{
    public class Program
    {
        public static bool exitRequested = false;
        public static IPermissionOperation permissionOperation = new PermissionOperation();
        public static IList<Permission> permissionsList = permissionOperation.Read();
        public enum MainMenu
        {
            CreatePermission = 1,
            ReadPermission,
            UpdatePermission,
            DeletePermission,
            Exit
        }
        static void Main()
        {
            do
            {
                ShowMenu();
                HandleMenuSelection();
            } while (!exitRequested);
        }
        public static void ShowMenu()
        {
            Console.WriteLine("Welcome to the PERMISSION PROGRAM\nWhich action would you like to perform?\n");
            Console.WriteLine($"1. {MainMenu.CreatePermission}\n2. {MainMenu.ReadPermission}\n3. {MainMenu.UpdatePermission}\n4. {MainMenu.DeletePermission}\n5. {MainMenu.Exit}\n");
        }
        public static void HandleMenuSelection()
        {
            string userInput = Console.ReadLine();
            if ((!UserInputValidator.ValidateUserInput(userInput, @"^[1-5]$")))
            {
                Console.WriteLine("Invalid Input. Please enter a valid numeric value from 1 to 4.\n");
                return;
            }

            MainMenu option = Enum.Parse<MainMenu>(userInput);

            switch (option)
            {
                case MainMenu.CreatePermission:
                    HandleCreate();
                    break;
                case MainMenu.ReadPermission:
                    HandleRead();
                    break;
                case MainMenu.UpdatePermission:
                    HandleUpdate();
                    break;
                case MainMenu.DeletePermission:
                    HandleDelete();
                    break;
                case MainMenu.Exit:
                    HandleLogOut();
                    break;
            }
            Console.WriteLine();
        }
        public static void HandleCreate()
        {
            Console.WriteLine("Please enter a valid name.\n");
            string name = Console.ReadLine();
            if ((!UserInputValidator.ValidateUserInput(name, @"^[a-zA-Z]{2,10}$")))
            {
                Console.WriteLine("Invalid Input. Please enter a valid name.");
                return;
            }

            Console.WriteLine("Please enter a valid lastName.\n");
            string lastName = Console.ReadLine();
            if ((!UserInputValidator.ValidateUserInput(lastName, @"^[a-zA-Z]{2,10}$")))
            {
                Console.WriteLine("Invalid Input. Please enter a valid lastName.");
                return;
            }

            Console.WriteLine("Please select a valid PermissionType.\n");
            Console.WriteLine($"1. {PermissionType.Disease}\n2. {PermissionType.Errands}\n3. {PermissionType.Others}\n");

            string permissionType = Console.ReadLine();
            if (!UserInputValidator.ValidateUserInput(permissionType, @"^[1-3]$"))
            {
                Console.WriteLine("Invalid Input. Please enter a valid numeric value from 1 to 3.");
                return;
            }

            var type = Enum.Parse<PermissionType>(permissionType);

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
                    permissionOperation.Create(new Permission(name, lastName, type, customDescription));
                    Console.WriteLine($"Operation Succeeded: The new permission {type.ToString().ToUpper()}: {customDescription.ToUpper()}\nfor {name.ToUpper()} {lastName.ToUpper()} has been successfully requested on date: {DateTime.Now}");
                    return;
                }
            }
            permissionOperation.Create(new Permission(name, lastName, type));
            Console.WriteLine($"Operation Succeeded: The new permission {type.ToString().ToUpper()} for {name.ToUpper()} {lastName.ToUpper()}\nhas been successfully requested on date: {DateTime.Now}");
        }
        public static void HandleRead()
        {
            Console.WriteLine("OFFICIAL PERMISSIONS:");
            for (int i = 0; i < permissionsList.Count; i++)
            {
                if (permissionsList[i].CustomDescription != null)
                {
                    Console.WriteLine($"{i + 1}. " +
                    $"{permissionsList[i].PermissionDateTime} " +
                    $"{permissionsList[i].Name.ToUpper()} " +
                    $"{permissionsList[i].LastName.ToUpper()} " +
                    $"{permissionsList[i].Type.ToString().ToUpper()}: {permissionsList[i].CustomDescription.ToUpper()}");
                    continue;
                }

                Console.WriteLine($"{i + 1}. " +
                $"{permissionsList[i].PermissionDateTime} " +
                $"{permissionsList[i].Name.ToUpper()} " +
                $"{permissionsList[i].LastName.ToUpper()}: " +
                $"{permissionsList[i].Type.ToString().ToUpper()}.");

            }
            Console.WriteLine("----------------------------------------------");

            if (permissionsList.Count == 0) Console.WriteLine("There's not granted permissions yet.");
        }
        public static void HandleUpdate()
        {
            HandleRead();
            if (permissionsList.Count == 0) return;

            Console.WriteLine("\nWhich permission would you like to update?");
            string index = Console.ReadLine();
            if ((!UserInputValidator.ValidateUserInput(index, @"^[1-9]\d*$")))
            {
                Console.WriteLine("\nInvalid Input. Please enter a valid numeric value.");
                return;
            }

            var userChoice = int.Parse(index);
            if (userChoice <= 0 || userChoice > permissionsList.Count)
            {
                Console.WriteLine("\nInvalid Input. That permission hasn't been granted in this Matrix");
                return;
            }

            Console.WriteLine("\nPlease enter a valid name.");
            string name = Console.ReadLine();
            if ((!UserInputValidator.ValidateUserInput(name, @"^[a-zA-Z]{2,10}$")))
            {
                Console.WriteLine("\nInvalid Input. Please enter a valid name.");
                return;
            }

            Console.WriteLine("\nPlease enter a valid lastName.");
            string lastName = Console.ReadLine();
            if ((!UserInputValidator.ValidateUserInput(lastName, @"^[a-zA-Z]{2,10}$")))
            {
                Console.WriteLine("\nInvalid Input. Please enter a valid lastName.");
                return;
            }

            Console.WriteLine("\nPlease select a valid PermissionType.");
            Console.WriteLine($"1. {PermissionType.Disease}\n2. {PermissionType.Errands}\n3. {PermissionType.Others}\n");

            string permissionType = Console.ReadLine();
            if (!UserInputValidator.ValidateUserInput(permissionType, @"^[1-3]$"))
            {
                Console.WriteLine("\nInvalid Input. Please enter a valid numeric value from 1 to 3.");
                return;
            }

            var type = Enum.Parse<PermissionType>(permissionType);

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
                    Console.WriteLine($"\nOperation Succeeded.\n{permissionsList[userChoice - 1].PermissionDateTime} {permissionsList[userChoice - 1].Name.ToUpper()} {permissionsList[userChoice - 1].LastName.ToUpper()}: {permissionsList[userChoice - 1].Type.ToString().ToUpper()}\nHAS BEEN UPDATED TO:\n{DateTime.Now}{name.ToUpper()} {lastName.ToUpper()}: {type.ToString().ToUpper()}");
                    permissionOperation.Update(userChoice - 1, new Permission(name, lastName, type, customDescription));
                    return;
                }
            }

            Console.WriteLine($"\nOperation Succeeded.\n{permissionsList[userChoice - 1].PermissionDateTime} {permissionsList[userChoice - 1].Name.ToUpper()} {permissionsList[userChoice - 1].LastName.ToUpper()}: {permissionsList[userChoice - 1].Type.ToString().ToUpper()}\nHAS BEEN UPDATED TO:\n{DateTime.Now}{name.ToUpper()} {lastName.ToUpper()}: {type.ToString().ToUpper()}");
            permissionOperation.Update(userChoice - 1, new Permission(name, lastName, type));
        }
        public static void HandleDelete()
        {
            HandleRead();
            if (permissionsList.Count == 0) return;

            Console.WriteLine("\nWhich permission would you like to delete?");
            string index = Console.ReadLine();
            if ((!UserInputValidator.ValidateUserInput(index, @"^[1-9]\d*$")))
            {
                Console.WriteLine("\nInvalid Input. Please enter a valid numeric value.");
                return;
            }

            var userChoice = int.Parse(index);
            if (userChoice <= 0 || userChoice > permissionsList.Count)
            {
                Console.WriteLine("\nInvalid Input. That permission hasn't been granted in this Matrix");
                return;
            }

            string input;
            do
            {
                Console.WriteLine($"\nAre you sure you want to delete {permissionsList[userChoice - 1].PermissionDateTime} {permissionsList[userChoice - 1].Name.ToUpper()} {permissionsList[userChoice - 1].LastName.ToUpper()} {permissionsList[userChoice - 1].Type.ToString().ToUpper()}?\n1. YES / 2. NO");
                input = Console.ReadLine();
            }
            while (input != "1" && input != "2");

            if (input == "2") return;

            Console.WriteLine($"\nOperation Succeeded: " +
            $"{PermissionOperation.permissionsList[userChoice - 1].PermissionDateTime} " +
            $"{PermissionOperation.permissionsList[userChoice - 1].Name.ToUpper()} " +
            $"{PermissionOperation.permissionsList[userChoice - 1].LastName.ToUpper()}: " +
            $"{PermissionOperation.permissionsList[userChoice - 1].Type.ToString().ToUpper()} have been successfully deleted.");

            permissionOperation.Delete(userChoice - 1);
        }
        public static void HandleLogOut()
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
                exitRequested = true;
            }
            return;
        }
    }
}