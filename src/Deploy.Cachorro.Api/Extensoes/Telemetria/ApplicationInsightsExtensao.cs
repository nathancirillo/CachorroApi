using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.QuickPulse;

namespace Deploy.Cachorro.Api.Extensoes.Telemetria
{
    public static class ApplicationInsightsExtensao
    {
        public static void AddTelemetria(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddApplicationInsightsTelemetry(options =>
            {
                options.ConnectionString = configuration.GetSection("ConnectionsString:ApplicationInsights").Value;
            })
           .ConfigureTelemetryModule<QuickPulseTelemetryModule>((module, o) =>
           {
               module.AuthenticationApiKey = configuration.GetSection("ApplicationInsights:Api-Key").Value;
           });
        }
    }
}
