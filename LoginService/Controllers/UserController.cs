using LoginService.Core.CustomException;
using LoginService.Models;
using LoginService.Services.Hash;
using LoginService.Services.Notifications;
using LoginService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginService.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController(ILoginServices _loginServices,
                                 INotifiServices _notifiServices,
                                 IHashingServices _hashingServices) : ControllerBase
    {
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
