using LoginService.Models;

namespace LoginService.Services.Notifications
{
    public interface INotifiServices
    {
        public bool SendMail(MailModel mail);
    }
}
