using CleanArchitecture.Borders.Repositories;
using CleanArchitecture.Repositories;

namespace CleanArchitecture.Api.Configurations
{
    public static class RepositoryConfig
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddSingleton<IStateRepository, StateRepository>();
        }
    }
}
