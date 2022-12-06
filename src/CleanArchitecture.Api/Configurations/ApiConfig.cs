using CleanArchitecture.Api.Models;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CleanArchitecture.Api.Configurations
{
    public static class ApiConfig
    {
        public static void ConfigureApi(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IActionResultConverter, ActionResultConverter>();

        }
    }
}
