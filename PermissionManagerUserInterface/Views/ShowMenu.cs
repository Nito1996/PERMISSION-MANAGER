using System;
using PermissionManager.UserInterface.Enums;

namespace PermissionManager.UserInterface.Views
{
    public class ShowMenu
    {
        public static void Menu()
        {
            Console.WriteLine("Welcome to the PERMISSION PROGRAM\nWhich action would you like to perform?\n");
            Console.WriteLine($"1. {MainMenu.CreatePermission}\n2. {MainMenu.ReadPermission}\n" +
            $"3. {MainMenu.UpdatePermission}\n4. {MainMenu.DeletePermission}\n5. {MainMenu.Exit}\n");
        }
    }
}
