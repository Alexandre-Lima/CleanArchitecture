using CleanArchitecture.Borders.Repositories;
using CleanArchitecture.Repositories;
using CleanArchitecture.Shared.Configurations;
using System.Net.Mime;

namespace CleanArchitecture.Api.Configurations
{
    public static class HttpRepositoryConfig
    {
        public static void ConfigureHttpRepository(this IServiceCollection services,
            ApplicationConfig applicationConfig)
        {

            services.AddHttpClient<IZipCodeRepository, ZipCodeRepository>(client =>
            {
                client.BaseAddress = new Uri(applicationConfig.ViaCepDataHub.Url);
                client.DefaultRequestHeaders.Add("Accept", MediaTypeNames.Application.Json);
            });
        }
    }
}
