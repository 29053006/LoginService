using LoginService.Models;
using Microsoft.AspNetCore.Mvc;
using LoginService.Constants;
using LoginService.Services;
using LoginService.Services.Notifications;
using Microsoft.AspNetCore.Authorization;
using LoginService.Services.Hash;
using LoginService.Core.CustomException;
using System.Text.Json.Serialization;

namespace LoginService.Controllers
{
    [Route("User")]
    [ApiController]
    public class LoginController(ILoginServices _loginServices,
                                 INotifiServices _notifiServices,
                                 IHashingServices _hashingServices) : ControllerBase
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
        [HttpPost("SendEmailResetPassword")]
        public IActionResult SendEmailResetPassword(string userName)
        {
            var user = _loginServices.ValidateUser(userName);
            CustomException.NotNull(user, string.Format(Constants.Constants.USER_NOT_EXIST, userName));
            CustomException.Isvalid(_notifiServices.SendMail(user), Constants.Constants.SEND_MAIL_FAILD);

            return Ok($"UserName: {userName}");
        }

        [HttpPut("ResetPassword")]
        public IActionResult ResetPassword(string userName, string newPassword)
        {
            var newPasswordHash = _hashingServices.hashing(newPassword);
            _loginServices.ResetPassword(userName, newPasswordHash);

            return Ok();
        }

        [HttpPost("UserRegistration")]
        public IActionResult UserRegistration(UserModel newUser)
        {
            newUser.Password = _hashingServices.hashing(newUser.Password);

            _loginServices.RegistredUser(newUser);
            return Ok();
        }
    }
}
