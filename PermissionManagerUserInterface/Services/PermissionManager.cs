using PermissionManager.BusinessLogic.Interfaces;
using PermissionManager.BusinessLogic.Models;

namespace PermissionManager.UserInterface.Services
{
    class PermissionManager
    {
        public static IPermissionOperation handler = new PermissionOperation();
    }
}
