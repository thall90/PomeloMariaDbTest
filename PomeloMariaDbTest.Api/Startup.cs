namespace PomeloMariaDbTest.Api;

public static class Startup
{
    internal static IServiceCollection AddServices(
        this WebApplicationBuilder builder,
        IConfigurationRoot configuration)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder.Services
            .RegisterLoggingProvider()
            .RegisterDbContexts(configuration);
    }

    internal static WebApplication AddApplicationServices(
        this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }

    internal static IConfigurationRoot SetupConfiguration()
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var b = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        return b.Build();
    }
}
