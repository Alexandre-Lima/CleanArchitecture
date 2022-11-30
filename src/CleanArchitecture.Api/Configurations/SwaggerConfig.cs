using CleanArchitecture.Shared.Configurations;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CleanArchitecture.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static void ConfigureSwagger(this IServiceCollection services, ApplicationConfig applicationConfig)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CleanArchitecture.Api",
                    Version = "v1",
                    Description = "REST API C# .NET 7 a fim de experimento com práticas Clean Architecture respeitando os princípios SOLID.\r\n\r\n"
                });

                var xmlFiles = Directory
                   .GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly)
                   .ToList();
                xmlFiles.ForEach(xmlFile => c.IncludeXmlComments(xmlFile));

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                    c.IncludeXmlComments(xmlPath);

            });

        }
        public static void UseSwaggerExtensions(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitecture.Api V1.0");
            });

        }
    }
}
