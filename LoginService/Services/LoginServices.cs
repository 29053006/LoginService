using LoginService.Constants;
using LoginService.Core.CustomException;
using LoginService.Models;
using LoginService.Repositories;
using LoginService.Services.Hash;
using LoginService.Services.jwt;

namespace LoginService.Services
{
    public class LoginServices(IRepositories _repositories,
                               IJwtService _jwtService,
                               IHashingServices _hashingServices) : ILoginServices
    {
        public LoginResultData Authentication(LoginDataModel login)
        {
            var response = _repositories.Authentication(login);
            bool verificarionPassword = _hashingServices.verifyHash(response.Password, login.password, response.ExpiratePassword);
            if (!verificarionPassword)
            {
                throw new Exception(Constants.Constants.INVALID_CREDENTIALS);
            }
            var token = _jwtService.GenerationToken(response);
            LoginResultData LoginResultData = new LoginResultData()
            {
                token = token,
                UserName = response.UserName,
                rolName = response.RolName,
            };
            return LoginResultData;
        }
        public bool RegistredUser(UserModel login)
        {
            var response = _repositories.CreateUser(login);
            CustomException.NotExist(response, Constants.Constants.USER_EXIST);
            return response;

        }
        public bool ResetPassword(string userName, string newPassword)
        {
            var response = _repositories.ResetPassword(userName, newPassword);
            return true;
        }
        public MailModel ValidateUser(string userName)
        {
            var response = _repositories.ValidateUser(userName);
            return new MailModel { TO = response.Email, Subject = "Reset Password" };
        }
    }
}
