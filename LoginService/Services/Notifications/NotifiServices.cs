using LoginService.Core.Configuraciones;
using LoginService.Core.CustomException;
using LoginService.Models;
using System.Data;
using System.Net.Mail;

namespace LoginService.Services.Notifications
{
    public class NotifiServices(IConfigurations _configuration) : INotifiServices
    {
        private readonly string fromMail = _configuration.getSetting("PathMail");
        private readonly string passwordMail = _configuration.getSetting("PasswordMail");



        public bool SendMail(MailModel mail)
        {
            if (!string.IsNullOrEmpty(mail.TO))
            {
                mail.Body = "<b>Body Correo<b>";

                if (string.IsNullOrEmpty(fromMail) || string.IsNullOrEmpty(passwordMail))
                {
                    Console.WriteLine("Verificar el correo origen o la Contraseña.");
                }
                MailMessage message = new MailMessage(fromMail, mail.TO, mail.Subject, mail.Body);

                message.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential(fromMail, passwordMail);
                smtpClient.Send(message);
                smtpClient.Dispose();
                return true;
            }
            CustomException.IsNullOrEmpty(mail.TO, Constants.Constants.VERIFY_MAIL);
            return false;
        }
    }
}
