using LoginService.Models;
using LoginService.Repositories;

namespace LoginService.Services
{
    public class LoginServices(IRepositories _repositories) : ILoginServices
    {
        public bool Authentication(LoginDataModel login)
        {
            var response = _repositories.Authentication(login);
            if (response == null)
            {
                return false;
            }
            GenerationToken(response);
            return true;
        }
        public bool RegistredUser(LoginDataModel login)
        {
            var response = _repositories.CreateUser(login);

            return true;
        }
        public bool ResetPassword(string UserName, string NewPassword)
        {
            var response = _repositories.ResetPassword(UserName, NewPassword);
            return true;
        }
        private string GenerationToken(UserResponse infoUser)
        {


            return "";
        }

    }
}
