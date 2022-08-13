


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }   
        public string Name { get; set; }   
        ICollection<UserPermission> UserPermissions { get; set; }
    }
}
