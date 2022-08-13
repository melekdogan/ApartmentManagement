using AutoMapper;
using BackgroundJobs.Abstract;
using Business.Abstract;
using Configurations.Auth;
using Configurations.Helper;
using Configurations.Validator.FluentValidation.UserValidations;
using Configurations.Extensions;
using Configurations.Response;
using DataAccess.Abstract;
using DTOs.User;
using Microsoft.Extensions.Caching.Distributed;
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
        private readonly IDistributedCache _distributedCache;
        private readonly IJob _job;
        public UserService(IUserRepository userRepository, IMapper mapper/*, IJob hangfireJob*/, IDistributedCache distributedCache, IJob job)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _distributedCache = distributedCache;
            _job = job;
        }

        public CommandResponse Delete(DeleteUserRequest deleteUser)
        {
            var user = _mapper.Map<User>(deleteUser);
            _userRepository.Delete(user);
            return new CommandResponse()
            {
                Message = "Kullanıcı Başarıyla Silindi",
                Status = true
            };
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public CommandResponse Register(CreateUserRequest register)
        {
            #region Validate User
            var validator = new CreateUserRequestValidator();
            validator.Validate(register).ThrowIfException();
            #endregion

            byte[] passwordHash, passwordSalt;
            var password=PasswordHelper.CreateRandomPassword();           
            HashHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);// out kelimesi ile gönderdiğimiz değişkenin gösterdiği referans içini değiştirip geri gönderiyor. Yani değişkendeki değeri güncelleyip/doldurup bize geri döndürür. 

            var user = _mapper.Map<User>(register);//Gelen CreateUserRequest nesnesini User türüne dönüştürüyor (mapliyor) ve user nesnesine atıyor.

            user.Password = new UserPassword()// Kayda eklenmeye hazırlanmış password bilgilerini userın bilgilerine atıyor.
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            #region email mevcut mu kontrolü

             if (DoesEmailExist(register.EMail))
             {
                 return new CommandResponse()
                 {
                     Message = "Bu Email ile kayıtlı bir kullanıcı var!",
                     Status = false
                 };
             }
            #endregion

            //Kullanıcıyı ekleyip, eklediği kullanıcıyı veritabanına kaydediyor ve gereken bilgilendirme nesnesini geri döndürüyor. 
            _userRepository.Add(user);
            _userRepository.SaveChanges();
            _job.FireAndForget(register.Name, register.EMail, password);
            //_hangfireJob.FireAndForget(user.UserId, user.Name);
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
        private bool DoesEmailExist(string email)
        {
            var result= _userRepository.Get(u => u.EMail == email);
            if (result == null) return false;
            return true;
        }
        
    }
}
