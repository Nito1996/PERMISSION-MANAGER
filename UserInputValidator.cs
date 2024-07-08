using System.Text.RegularExpressions;

namespace PermissionManager
{
    public class UserInputValidator
    {
        public static bool ValidateUserInput(string input, string regex)
        {
            return Regex.IsMatch(input, regex);
        }
    }
}
