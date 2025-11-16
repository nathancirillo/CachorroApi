namespace Deploy.Cachorro.Api.Extensoes.Telemetria
{
    public static class LoggingExtensao
    {
        public static void AddLogging(this ILoggingBuilder logging, ConfigurationManager configuration)
        {
            logging.ClearProviders();
            logging.AddConsole();
            logging.AddDebug();

            logging.AddApplicationInsights(
                 configureTelemetryConfiguration: (config) =>
                 {
                     config.ConnectionString = configuration.GetSection("ConnectionsString:ApplicationInsights").Value;
                 },
                 configureApplicationInsightsLoggerOptions: (options) =>
                 {

                 }
            );
        }
    }
}
