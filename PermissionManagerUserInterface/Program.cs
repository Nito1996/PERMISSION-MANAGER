using PermissionManager.UserInterface.Views;

namespace PermissionManager.UserInterface
{
    public class Program
    {
        public static bool exitRequested = false;
        static void Main()
        {
            do
            {
                ShowMenu.Menu();
                HandleMenu.Menu();
            } while (!exitRequested);
        }
    }
}
