using System.Collections.Generic;
using System.Security;

namespace PermissionManager
{
    public interface IPermissionOperation
    {
        public void Create(Permission permission);
        public IList<Permission> Read();
        public void Update(int index, Permission permission);
        public void Delete(int index);

    }
    public class PermissionOperation : IPermissionOperation
    {
        public static IList<Permission> permissionsList = new List<Permission>();
        public void Create(Permission permission)
        {
            permissionsList.Add(permission);
        }
        public IList<Permission> Read()
        {
            return permissionsList;
        }
        public void Update(int index, Permission permission)
        {
            permissionsList[index] = permission;
        }
        public void Delete(int index)
        {
            permissionsList.RemoveAt(index);
        }
    }
}
