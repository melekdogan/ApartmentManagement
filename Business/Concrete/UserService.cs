using AutoMapper;
using Business.Abstract;
using Business.Configuration.Auth;
using Business.Configuration.Helper;
using Business.Configuration.Validator.FluentValidation.UserValidations;
using BusinessLayer.Configuration.Extensions;
using BusinessLayer.Configuration.Response;
using DataAccess.Abstract;
using DTOs.User;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public CommandResponse Delete(DeleteUserRequest deleteUser)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll(Expression<Func<User, bool>> expression = null)
        {
            return _userRepository.GetAll(expression);
        }

        public CommandResponse Register(CreateUserRequest register)
        {
            #region Validate User
            var validator = new CreateUserRequestValidator();
            validator.Validate(register).ThrowIfException();
            #endregion

            byte[] passwordHash, passwordSalt;
            HashHelper.CreatePasswordHash(PasswordHelper.CreateRandomPassword(), out passwordHash, out passwordSalt);// out kelimesi ile gönderdiğimiz değişkenin gösterdiği referans içini değiştirip geri gönderiyor. Yani değişkendeki değeri güncelleyip/doldurup bize geri döndürür. 

            var user = _mapper.Map<User>(register);//Gelen CreateUserRequest nesnesini User türüne dönüştürüyor (mapliyor) ve user nesnesine atıyor.

            user.Password = new UserPassword()// Kayda eklenmeye hazırlanmış password bilgilerini userın bilgilerine atıyor.
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };            

            //Kullanıcıyı ekleyip, eklediği kullanıcıyı veritabanına kaydediyor ve gereken bilgilendirme nesnesini geri döndürüyor. 
            _userRepository.Add(user);
            _userRepository.SaveChanges();
            return new CommandResponse()
            {
                Message = "Kullanıcı başarılı şekilde kaydedildi",
                Status = true
            };
          
        }

        public CommandResponse Update(UpdateUserRequest updateUser)
        {
            var user = _mapper.Map<User>(updateUser);
            _userRepository.Update(user);
            _userRepository.SaveChanges();
            return new CommandResponse()
            {
                Message = "Kullanıcı başarılı şekilde güncellendi",
                Status = true
            };
        }
    }
}
