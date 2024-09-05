using LoginService.Models;
using Microsoft.AspNetCore.Mvc;
using LoginService.Constants;
using LoginService.Services;
using LoginService.Services.Notifications;

namespace LoginService.Controllers
{
    [Route("User")]
    [ApiController]
    public class LoginController(ILoginServices _loginServices, INotifiServices _notifiServices) : ControllerBase
    {
        [HttpPost("Login")]
        public IActionResult login(LoginDataModel login)
        {
            MailModel mailModel = new MailModel();
            _notifiServices.SendMail(mailModel);
            if (!_loginServices.Authentication(login))
            {
                BadRequest(Constants.Constants.INVALID_CREDENTIALS);
            }
            return Ok();
        }
        [HttpPut("ResetPassword")]
        public IActionResult ResetPassword(string userName,string newPassword)
        {

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
