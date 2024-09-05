using LoginService.Models;

namespace LoginService.Repositories
{
    public interface IRepositories
    {
        public UserModel Authentication(LoginDataModel login);
        public bool CreateUser(UserModel login);
        public bool ResetPassword(string UserName, string Password);
        public MailModel ValidateUser(string userName);
    }
}
