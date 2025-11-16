using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Deploy.Cachorro.Api.Extensoes.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options) 
        { 
            foreach(var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        public void Configure(string? name, SwaggerGenOptions options)
        {
           Configure(options);
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription desc)
        {
            var info = new OpenApiInfo()
            {
                Title="Cachorro WebAPI - .NET 9",
                Version = desc.GroupName,
                Description = "WebApi criada no canal D.E.P.L.O.Y",
                Contact = new OpenApiContact()
                {
                    Email = "cirillo.nathan@gmail.com",
                    Name = "Nathan Cirillo"
                }
            };

            if(desc.IsDeprecated)
            {
                info.Description += "Endpoint depreciado. Pesquisa e use a nova versão";
            }

            return info;
        }
    }
}
