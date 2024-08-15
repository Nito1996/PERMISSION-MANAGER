using System;

namespace PermissionManager.UserInterface.Views
{
    public class HandleRead
    {
        public static void Read()
        {
            Console.WriteLine("OFFICIAL PERMISSIONS:");
            for (int i = 0; i < Services.PermissionManager.handler.Read().Count; i++)
            {
                if (Services.PermissionManager.handler.Read()[i].CustomDescription != null)
                {
                    Console.WriteLine($"{i + 1}. " +
                    $"{Services.PermissionManager.handler.Read()[i].PermissionDateTime} " +
                    $"{Services.PermissionManager.handler.Read()[i].Name.ToUpper()} " +
                    $"{Services.PermissionManager.handler.Read()[i].LastName.ToUpper()} " +
                    $"{Services.PermissionManager.handler.Read()[i].Type.ToString().ToUpper()}: {Services.PermissionManager.handler.Read()[i].CustomDescription.ToUpper()}");
                    continue;
                }

                Console.WriteLine($"{i + 1}. " +
                $"{Services.PermissionManager.handler.Read()[i].PermissionDateTime} " +
                $"{Services.PermissionManager.handler.Read()[i].Name.ToUpper()} " +
                $"{Services.PermissionManager.handler.Read()[i].LastName.ToUpper()}: " +
                $"{Services.PermissionManager.handler.Read()[i].Type.ToString().ToUpper()}.");

            }
            Console.WriteLine("----------------------------------------------");

            if (Services.PermissionManager.handler.Read().Count == 0) Console.WriteLine("There's not granted permissions yet.");
        }
    }
}
