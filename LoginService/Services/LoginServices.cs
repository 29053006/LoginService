using LoginService.Models;
using LoginService.Repositories;
using LoginService.Services.jwt;

namespace LoginService.Services
{
    public class LoginServices(IRepositories _repositories, IJwtService _jwtService) : ILoginServices
    {
        public LoginResultData Authentication(LoginDataModel login)
        {
            var response = _repositories.Authentication(login);
            var token = _jwtService.GenerationToken(response);
            LoginResultData LoginResultData = new LoginResultData()
            {
                token = token,
                UserId = response.UserId,
                UserName = response.UserName,
                rolId = response.RolId, 
                rolName = response.RolName,
            };
            return LoginResultData;
        }
        public bool RegistredUser(UserModel login)
        {
            var response = _repositories.CreateUser(login);

            return true;
        }
        public bool ResetPassword(string userName, string newPassword)
        {
            var response = _repositories.ResetPassword(userName, newPassword);
            return true;
        }
        public MailModel ValidateUser(string userName)
        {
            return _repositories.ValidateUser(userName);
        }
    }
}
