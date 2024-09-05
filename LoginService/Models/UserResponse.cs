namespace LoginService.Models
{
    public class UserResponse
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswodConfirmed { get; set; } = string.Empty;
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailConfirmed { get; set; } = string.Empty;
        public string PhoneNumberConfirmed { get; set; } = string.Empty;
        public Guid RolId { get; set; }
        public string RolName { get; set; }

    }
}
