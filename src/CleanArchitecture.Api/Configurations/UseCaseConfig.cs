using CleanArchitecture.Borders.UseCases;
using CleanArchitecture.UseCases.Addressses;

namespace CleanArchitecture.Api.Configurations
{
    public static class UseCaseConfig
    {
        public static void ConfigureUseCase(this IServiceCollection services)
        {
            services.AddScoped<IGetAddressByZipCodeUseCase, GetAddressByZipCodeUseCase>();
        }
    }
}
