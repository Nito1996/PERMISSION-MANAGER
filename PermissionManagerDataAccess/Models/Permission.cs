using System;
using PermissionManager.DataAccess.Enums;

namespace PermissionManager.DataAccess.Models
{
    public class Permission
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public PermissionType Type { get; set; }
        public DateTime PermissionDateTime { get; set; }
        public string CustomDescription { get; set; }
        public Permission(string name, string lastName, PermissionType type, string customDescription)
        {
            Name = name;
            LastName = lastName;
            Type = type;
            PermissionDateTime = DateTime.Now;
            CustomDescription = customDescription;
        }
    }
}
