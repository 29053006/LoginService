using System.ComponentModel.DataAnnotations;

namespace LoginService.Models
{
    public class LoginResultData
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid rolId { get; set; }
        public string rolName { get; set; }
        public string token { get; set; } = string.Empty;
        public string Error { get; set; } = string.Empty;

    }
    public class responseLogin
    {
        public string rol {  get; set; }
        public string token { get; set; }
        public string userName { get; set; }

    }
}
