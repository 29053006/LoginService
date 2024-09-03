using System.ComponentModel.DataAnnotations;

namespace LoginService.Models
{
    public class LoginDataModel
    {
        [Required]
        public string userName { get; set; }
        [Required] 
        public string password { get; set; }
        public string? rol {  get; set; }
    }
}
