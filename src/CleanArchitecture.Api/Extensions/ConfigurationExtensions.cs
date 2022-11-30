using CleanArchitecture.Shared.Configurations;

namespace CleanArchitecture.Api.Extensions
{
    public static class ConfigurationExtensions
    {
        public static ApplicationConfig LoadConfiguration(this IConfiguration source)
        {
            var applicationConfig = source.Get<ApplicationConfig>();

            applicationConfig.CorsOrigins = source.GetSection("CorsOrigins").Get<string[]>();
            applicationConfig.ViaCepDataHub = source.GetSection("ViaCepDataHub").Get<ApiConfig>();            

            return applicationConfig;
        }
    }
}
