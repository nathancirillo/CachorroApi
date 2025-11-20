using Deploy.Cachorro.Api.Extensoes.Swagger;
using Deploy.Cachorro.Api.Extensoes.Telemetria;
using Deploy.Cachorro.Repository;
using Microsoft.EntityFrameworkCore;

namespace Deploy.Cachorro.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            //DB config
            builder.Services.AddDbContext<CachorroContext>(options => {
                options.UseInMemoryDatabase("Cachorros");
            });            
            
            //Extensions
            builder.Logging.AddLogging(builder.Configuration);

            builder.Services.AddTelemetria(builder.Configuration);

            builder.Services.AddSwagger();



            var app = builder.Build();

            //Extensions
            app.UseSwaggerDEPLOY();
            


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
