using System.Collections.Generic;
using PermissionManager.DataAccess.Models;

namespace PermissionManager.BusinessLogic.Interfaces
{
    public interface IPermissionOperation
    {
        public void Create(string name, string lastName, string permissionType, string customDescription = null);
        public IList<Permission> Read();
        public void Update(int index, string name, string lastName, string permissionType, string customDescription = null);
        public void Delete(int index);
    }
}
