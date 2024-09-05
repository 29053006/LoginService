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
            var autentication = _loginServices.Authentication(login);
            if (autentication == null)
            {
                BadRequest(Constants.Constants.INVALID_CREDENTIALS);
            }
            return Ok(autentication.token);
        }
        [HttpPut("ResetPassword")]
        public IActionResult ResetPassword(string userName, string newPassword)
        {
           var mailModel = _loginServices.ValidateUser(userName);

            if (!_notifiServices.SendMail(mailModel))
            {
                BadRequest(Constants.Constants.SEND_MAIL_FAILD);
                return Ok();
            }
            _loginServices.ResetPassword(userName, newPassword);
            return Ok();
        }

        [HttpPost("UserRegistration")]
        public IActionResult UserRegistration(UserModel login)
        {
            _loginServices.RegistredUser(login);
            return Ok();
        }
    }
}
