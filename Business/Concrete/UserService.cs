using Business.Abstract;
using BusinessLayer.Configuration.Response;
using DTOs.User;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public CommandResponse Register(CreateUserRequestDTO register)
        {

            return new CommandResponse()
            {
                Message = "Kullanıcı başarılı şekilde kaydedildi",
                Status = true
            };
        }
    }
}
