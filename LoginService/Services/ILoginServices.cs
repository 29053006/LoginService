using LoginService.Models;

namespace LoginService.Services
{
    public interface ILoginServices
    {
        public bool Authentication(LoginDataModel login);
        public bool RegistredUser(LoginDataModel login);
        public bool ResetPassword(string UserName, string NewPassword);
    }
}
