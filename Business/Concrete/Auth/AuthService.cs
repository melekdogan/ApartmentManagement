using Business.Abstract.Auth;
using Configurations.Auth;
using Configurations.Helper;
using Configurations.Response;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IDistributedCache _distributedCache;
        public AuthService(IUserRepository userRepository, IConfiguration configuration, IDistributedCache distributedCache)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _distributedCache = distributedCache;
        }
        public AccessToken Login(string email, string password)
        {
            var verifyPassword = VerifyPassword(email, password);//Parametre olarak verilen email bilgisine sahip kullanıcının, yine parametre olarak verilen şifre ile kendi şifresi eşleşiyor mu?--- Eşleşirse true, eşleşmezse false döner. 

            var user = _userRepository.Get(u=>u.EMail==email);//gönderilen email bilgisine sahip kullanıcıyı aldık.

            #region Token
            if (verifyPassword.Status)//Eğer şifre doğruysa
            {
                var tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOption>();

                var expireDate = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration);
                var claims = new Claim[]
                {
                    //Claimleri mümkün olduğunca az kullanmak gerekir. Token boyutunu büyütür ve belli boyuttan sonra server a giden isteklerimiz bad request olarak dönebilir. Gönderdiğimiz requestler kabul edilmeyebilir!!!
                    new Claim(ClaimTypes.Email, user.EMail),
                    new Claim(ClaimTypes.GivenName, user.Name),
                    new Claim(ClaimTypes.Role,user.UserRole.ToString()),
                    new Claim("ForCache",StringHelper.CreateCacheKey(user.Name,user.UserId))
                };

                SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey));
                var jwtToken = new JwtSecurityToken(
                    issuer: tokenOptions.Issuer,
                    audience: tokenOptions.Audience,
                    claims: claims,
                    expires: expireDate,
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
                );

                var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            #endregion

            #region Cache
            //kullanıcının id ile USR_kullanıcıID key oluşup token kaydedilecek
            _distributedCache.SetString($"USR_{user.UserId}", token);
            #endregion

            return new AccessToken()
            {
                Token = token,
                ExpireDate = expireDate
            };
        }

            return new AccessToken()
        {

        };
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
