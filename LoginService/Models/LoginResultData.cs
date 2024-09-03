using System.ComponentModel.DataAnnotations;

namespace LoginService.Models
{
    public class LoginResultData
    {
        public string UserName { get; set; }
        public string rol { get; set; }
        public string token { get; set; }
        public string Error { get; set; }

    }
}
