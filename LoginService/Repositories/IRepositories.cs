using LoginService.Models;

namespace LoginService.Repositories
{
    public interface IRepositories
    {
        public LoginResultData Authentication(LoginDataModel login);
        public bool CreateUser(LoginDataModel login);
    }
}
