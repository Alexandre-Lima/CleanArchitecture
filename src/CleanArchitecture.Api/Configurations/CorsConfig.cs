using CleanArchitecture.Shared.Configurations;

namespace CleanArchitecture.Api.Configurations
{
    public static class CorsConfig
    {
        public static void ConfigureCors(this IServiceCollection services, ApplicationConfig applicationConfig)
        {
            if (applicationConfig.CorsOrigins?.Length > 0)
            {
                services.AddCors(options =>
                {
                    options.AddDefaultPolicy(
                        builder =>
                        {
                            builder.WithOrigins(applicationConfig.CorsOrigins)
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        });
                });
            }
        }
    }
}
