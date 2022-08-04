using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public UserPassword Password { get; set; }
        public int UserRoleId { get; set; }
        [ForeignKey("UserRoleId")]
        public UserRole UserRole { get; set; }
        public Vehicle Vehicle { get; set; }
        public Tenant Tenant { get; set; }
    }
}
