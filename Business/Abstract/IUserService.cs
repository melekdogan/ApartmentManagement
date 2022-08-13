using Configurations.Response;
using DTOs.Apartment;
using DTOs.User;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        CommandResponse Delete(DeleteUserRequest deleteUser);
        CommandResponse Update(UpdateUserRequest updateUser);
        CommandResponse Register(CreateUserRequest register);
        IEnumerable<User> GetAll();
    }
}
