using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
