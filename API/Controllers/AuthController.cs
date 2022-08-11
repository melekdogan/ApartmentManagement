using Business.Abstract.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet("Login")]
        public IActionResult Login(string email, string password)
        {
            var response=_authService.Login(email,password);
            return Ok(response);
        }
    }
}
