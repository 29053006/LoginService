using System.ComponentModel.DataAnnotations;

namespace LoginService.Models
{
    public class LoginDataModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9@._-]*$",
         ErrorMessage = "Usuario invalido.")]
        public string userName { get; set; }
        [Required] 
        public string password { get; set; }
    }

}
