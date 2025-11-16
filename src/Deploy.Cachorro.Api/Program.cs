
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.QuickPulse;

namespace Deploy.Cachorro.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Logging.AddApplicationInsights(
                configureTelemetryConfiguration: (config) =>
                {
                    config.ConnectionString = builder.Configuration.GetSection("ConnectionsString:ApplicationInsights").Value;
                },
                configureApplicationInsightsLoggerOptions: (options) =>
                {

                }
            );


            builder.Services.AddApplicationInsightsTelemetry(options =>
            {
               options.ConnectionString = builder.Configuration.GetSection("ConnectionsString:ApplicationInsights").Value;
            })
           .ConfigureTelemetryModule<QuickPulseTelemetryModule>((module, o) =>
            {
                module.AuthenticationApiKey = builder.Configuration.GetSection("ApplicationInsights:Api-Key").Value;
            });

            var app = builder.Build();


            // if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.MapOpenApi();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
