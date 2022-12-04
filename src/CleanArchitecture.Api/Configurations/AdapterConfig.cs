using CleanArchitecture.Borders.Adapters;
using CleanArchitecture.Borders.Adapters.Interfaces;

namespace CleanArchitecture.Api.Configurations
{
    public static class AdapterConfig
    {
        public static void ConfigureAdapter(this IServiceCollection services)
        {
            services.AddScoped<IAddressResponseAdapter, AddressResponseAdapter>();
        }
    }
}
