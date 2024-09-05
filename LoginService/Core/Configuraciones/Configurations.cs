using Microsoft.Extensions.Configuration;

namespace LoginService.Core.Configuraciones
{
    public class Configurations(IConfiguration _configuration): IConfigurations
    {
        public string getSetting(string setting)
        {
            return _configuration.GetSection(setting).Value ?? "";
        }
    }
}
