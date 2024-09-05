using LoginService.Models;

namespace LoginService.Services.Notifications
{
    public interface INotifiServices
    {
        public void SendMail(MailModel mail);
    }
}
