using BusinessLayer.Configuration.Response;
using DTOs.User;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        CommandResponse Register(CreateUserRequestDTO register);
        IEnumerable<User> GetAll();
    }
}
