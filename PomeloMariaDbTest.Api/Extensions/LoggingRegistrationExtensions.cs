namespace PomeloMariaDbTest.Api.Extensions;

public static class LoggingRegistrationExtensions
{
    public static IServiceCollection RegisterLoggingProvider(this IServiceCollection serviceCollection)
    {
        var serilogLogger = new LoggerConfiguration()
            .WriteTo.Console(theme: AnsiConsoleTheme.Code)
            .CreateLogger();

        serviceCollection.AddLogging(builder =>
        {
            builder.SetMinimumLevel(LogLevel.Debug);
            builder.AddSerilog(logger: serilogLogger, dispose: true);
        });

        return serviceCollection;
    }
}
