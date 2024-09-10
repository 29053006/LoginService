using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LoginService.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9@._-]*$",
         ErrorMessage = "Usuario invalido: solo se permiten usuarios con las siguientes caracteristicas(mayúsculas-minúsculas, números, @, ., _, -)")]
        public string UserName { get; set; }
        
        [RegularExpression(@"^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,16}$",
         ErrorMessage = "La contraseña debe tener al entre 8 y 16 caracteres, al menos un dígito, al menos una minúscula y al menos una mayúscula.\r\nPuede tener otros símbolos.")]
        public string Password { get; set; }
        public string PasswodConfirmed { get; set; } = string.Empty;
        public string Email { get; set; }
        public string EmailConfirmed { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; } = string.Empty;
        public Guid RolId { get; set; }
        public string RolName { get; set; } = string.Empty;

    }
}
