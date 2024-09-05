using LoginService.Models;

namespace LoginService.Repositories
{
    public interface IRepositories
    {
        public UserResponse Authentication(LoginDataModel login);
        public bool CreateUser(LoginDataModel login);
        public bool ResetPassword(string UserName, string Password);
    }
}
