using Business.Abstract;
using DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")] //Kullanıcı Kaydetme İsteği (veritabanına ekleme)
        public IActionResult Register(CreateUserRequest register)
        {
            var response = _userService.Register(register);//Kayıt başarılı olduktan sonra şifreniz mail adresinize otomatik gelecektir.
            return Ok(response);
        }

        [HttpPut("Update")] //Kullanıcı Güncelleme İsteği 
        public IActionResult Update(UpdateUserRequest register)
        {
            var response = _userService.Update(register);
            return Ok(response);
        }

        [HttpDelete("Delete")] //Kullanıcı Silme İsteği 
        public IActionResult Delete(DeleteUserRequest register)
        {
            var response = _userService.Delete(register);
            return Ok(response);
        }

        [HttpGet("ListAllUsers")] //Tüm Kullanıcıları listeleme isteği 
        public IActionResult GetAll()
        {
            var responseData = _userService.GetAll();
            return Ok(responseData);
        }

    }
}
