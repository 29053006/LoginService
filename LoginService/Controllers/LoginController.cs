using LoginService.Models;
using Microsoft.AspNetCore.Mvc;
using LoginService.Constants;
using LoginService.Services;
using LoginService.Services.Notifications;
using Microsoft.AspNetCore.Authorization;
using LoginService.Services.Hash;
using LoginService.Core.CustomException;
using System.Text.Json.Serialization;
using Serilog;

namespace LoginService.Controllers
{
    [Route("User")]
    [ApiController]
    public class LoginController(ILoginServices _loginServices) : ControllerBase
    {
        [HttpPost("Login")]
        public IActionResult login(LoginDataModel login)
        {
            var autentication = _loginServices.Authentication(login);

            CustomException.NotNull(autentication, "Acceso denegado", 401);
            responseLogin loginResultData = new responseLogin()
            {
                rol = autentication.rolName,
                token = autentication.token,
                userName = autentication.UserName
            };

            return Ok(loginResultData);
        }
    }
}
