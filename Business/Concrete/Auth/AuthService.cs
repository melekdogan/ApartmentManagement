using Business.Abstract.Auth;
using Business.Configuration.Auth;
using BusinessLayer.Configuration.Response;
using DataAccess.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }


        public AccessToken Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public CommandResponse VerifyPassword(string email, string password)
        {
            var user2 = _userRepository.GetUserWithPassword(email);//Verdiğimiz emaile sahip kullanıcıyı bulup şifresiyle beraber çeker. 

            //Şifrenin, parametrede verilen şifre ile eşleşip eşleşmediğine göre bilgi mesajı döndürür ve metot sonlanır.
            if (HashHelper.VerifyPasswordHash(password, user2.Password.PasswordHash, user2.Password.PasswordSalt))
            {
                return new CommandResponse()
                {
                    Status = true,
                    Message = "Şifre Doğru"
                };
            }

            return new CommandResponse()
            {
                Status = false,
                Message = "Şifre Hatalı!"
            }; 
        }
    }
}
