using System;
using System.Collections.Generic;
using PermissionManager.BusinessLogic.Interfaces;
using PermissionManager.DataAccess.Enums;
using PermissionManager.DataAccess.Models;

namespace PermissionManager.BusinessLogic.Models
{
    public class PermissionOperation : IPermissionOperation
    {
        public void Create(string name, string lastName, string permissionType, string customDescription = null)
        {
            Data.permissionsList.Add(new Permission(name, lastName, Enum.Parse<PermissionType>(permissionType), customDescription));
        }
        public IList<Permission> Read()
        {
            return Data.permissionsList;
        }
        public void Update(int index, string name, string lastName, string permissionType, string customDescription = null)
        {
            Data.permissionsList[index] = new Permission(name, lastName, Enum.Parse<PermissionType>(permissionType), customDescription);
        }
        public void Delete(int index)
        {
            Data.permissionsList.RemoveAt(index);
        }
    }
}
