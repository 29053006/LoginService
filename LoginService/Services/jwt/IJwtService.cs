using LoginService.Models;

namespace LoginService.Services.jwt
{
    public interface IJwtService
    {
        public string GenerationToken(UserModel infoUser);
    }
}
