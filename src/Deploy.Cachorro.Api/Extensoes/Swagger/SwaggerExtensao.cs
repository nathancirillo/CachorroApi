using Asp.Versioning;
using Asp.Versioning.ApiExplorer;


namespace Deploy.Cachorro.Api.Extensoes.Swagger
{
    public static class SwaggerExtensao
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;

            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV"; 
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGen();

            services.ConfigureOptions<ConfigureSwaggerOptions>();
        }


        public static void UseSwaggerDEPLOY(this WebApplication app)
        {
            var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {                
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }
            });
        }
    }
    
}
