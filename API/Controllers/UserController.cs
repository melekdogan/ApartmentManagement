using Business.Abstract;
using DTOs.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
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
            var response = _userService.Register(register);
            return Ok(response);
        }

        [HttpGet("ListAllUsers")] //Tüm Kullanıcıları listeleme isteği 
        public IActionResult GetAll()
        {
            var data = _userService.GetAll();
            return Ok(data);
        }
    }
}
