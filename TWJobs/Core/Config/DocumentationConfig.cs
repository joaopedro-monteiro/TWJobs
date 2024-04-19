using Microsoft.OpenApi.Models;

namespace TWJobs.Core.Config
{
    public static class DocumentationConfig
    {
        public static void RegisterDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TWJobs API",
                    Description = "API de um portal de vagas de emprego",
                    Contact = new OpenApiContact
                    {
                        Name = "João Pedro Monteiro",
                        Url = new Uri("https://www.linkedin.com/in/joaopedro-monteiro/"),
                        Email = "joaopedrobdmgbr@gmail.com"
                    }
                });
            });
        }
    }
}
