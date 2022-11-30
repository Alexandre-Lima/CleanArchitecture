using CleanArchitecture.Api.Configurations;
using CleanArchitecture.Api.Extensions;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Api
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var appConfig = Configuration.LoadConfiguration();

            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            services.AddAuthorization();

            services.ConfigureCors(appConfig);
            services.ConfigureHttpRepository(appConfig);
            services.ConfigureUseCase();
            services.ConfigureSwagger(appConfig);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            ILogger<Startup> logger)
        {
            app.UseCors();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
            }

            app.UseAuthentication();            
            app.UseRouting();
            app.UseAuthorization();
            app.UseSwaggerExtensions();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

    }
}
