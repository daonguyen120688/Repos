using FirstApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstApp.Ultilities
{
    public static class AppSettingConfig
    {
        public static void RegisterConfigurations(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenManagement>(configuration.GetSection("tokenManagement"));
            services.Configure<Environment>(configuration.GetSection("Environment"));
        }
    }
}
