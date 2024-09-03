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
        private string GenerationToken(LoginResultData infoUser)
        {

            return "";
        }

    }
}
