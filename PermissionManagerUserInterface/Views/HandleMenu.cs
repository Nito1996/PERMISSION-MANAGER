using System;
using PermissionManager.UserInterface.Enums;
using PermissionManager.UserInterface.Utilities;

namespace PermissionManager.UserInterface.Views
{
    public class HandleMenu
    {
        public static void Menu()
        {
            string userInput = Console.ReadLine();
            if ((!UserInputValidator.ValidateUserInput(userInput, @"^[1-5]$")))
            {
                Console.WriteLine("Invalid Input. Please enter a valid numeric value from 1 to 4.\n");
                return;
            }

            MainMenu option = (MainMenu)Enum.Parse(typeof(MainMenu), userInput);

            switch (option)
            {
                case MainMenu.CreatePermission:
                    HandleCreate.Create();
                    break;
                case MainMenu.ReadPermission:
                    HandleRead.Read();
                    break;
                case MainMenu.UpdatePermission:
                    HandleUpdate.Update();
                    break;
                case MainMenu.DeletePermission:
                    HandleDelete.Delete();
                    break;
                case MainMenu.Exit:
                    HandleLogOut.LogOut();
                    break;
            }
            Console.WriteLine();
        }
    }
}
