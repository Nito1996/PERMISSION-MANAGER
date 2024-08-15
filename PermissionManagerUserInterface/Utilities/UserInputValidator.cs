using System.Text.RegularExpressions;

namespace PermissionManager.UserInterface.Utilities
{
    public class UserInputValidator
    {
        public static bool ValidateUserInput(string input, string regex)
        {
            return Regex.IsMatch(input, regex);
        }
    }
}
