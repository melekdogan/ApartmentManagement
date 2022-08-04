using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.User
{
    public class CreateUserRequestDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string UserPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public UserRole Role { get; set; }
    }
}
