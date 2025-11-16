using Deploy.Cachorro.Api.Extensoes.Swagger;
using Deploy.Cachorro.Api.Extensoes.Telemetria;

namespace Deploy.Cachorro.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

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
