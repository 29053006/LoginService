using LoginService.Models;
using Microsoft.AspNetCore.Mvc;
using LoginService.Constants;
using LoginService.Services;

namespace LoginService.Controllers
{
    [Route("DevFood")]
    [ApiController]
    public class LoginController(ILoginServices _loginServices) : ControllerBase
    {
        [HttpPost("Login")]
        public IActionResult login(LoginDataModel login)
        {
            if (!_loginServices.Authentication(login))
            {
                BadRequest(Constants.Constants.INVALID_CREDENTIALS);
            }
            return Ok();
        }
        [HttpPost("UserRegistration")]
        public IActionResult UserRegistration(LoginDataModel login)
        {
            _loginServices.RegistredUser(login);
            return Ok();
        }
    }
}
