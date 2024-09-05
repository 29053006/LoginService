using System.ComponentModel.DataAnnotations;

namespace LoginService.Models
{
    public class MailModel
    {
        [Required]
        public string TO {  get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
