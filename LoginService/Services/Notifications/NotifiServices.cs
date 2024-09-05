using LoginService.Core.Configuraciones;
using LoginService.Models;
using System.Net.Mail;

namespace LoginService.Services.Notifications
{
    public class NotifiServices(IConfigurations _configuration) : INotifiServices
    {
        private readonly string fromMail = _configuration.getSetting("PathMail");
        private readonly string passwordMail = _configuration.getSetting("PasswordMail");


        string correoDestino = "notifiservicesdev356@gmail.com";

        public bool SendMail(MailModel mail)
        {
            try
            {
                mail.TO = correoDestino;
                mail.Subject = "Email Prueba";
                mail.Body = "<b>Body Correo<b>";

                if (string.IsNullOrEmpty(fromMail) || string.IsNullOrEmpty(passwordMail))
                {
                    Console.Write("Verificar el correo origen o la Contraseña.");
                    return false;
                }
                if (string.IsNullOrEmpty(mail.TO))
                {
                    Console.Write("El correo destino es obligatorio.");
                    return false;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }


    }
}
