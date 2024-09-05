using LoginService.Models;

namespace LoginService.Services
{
    public interface ILoginServices
    {
        public LoginResultData Authentication(LoginDataModel login);
        public bool RegistredUser(UserModel login);
        public bool ResetPassword(string userName, string newPassword);
        public MailModel ValidateUser(string userName);
    }
}
