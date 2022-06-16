using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using PomeloMariaDbTest.Api.Constants;
using PomeloMariaDbTest.Data.Context.Interfaces;
using PomeloMariaDbTest.Data.Context.Test;
using PomeloMariaDbTest.Data.Context.Test2;

namespace PomeloMariaDbTest.Api.Extensions;

public static class EntityFrameworkContextRegistrationExtensions
{
    public static IServiceCollection RegisterDbContexts(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.RegisterDbContext<ITestContext, TestContext>(
            configuration,
            ConnectionStringConstants.TestDatabaseConnectionName);

        services.RegisterDbContext<ITest2Context, Test2Context>(
            configuration,
            ConnectionStringConstants.Test2DatabaseConnectionName);

        return services;
    }

    private static void RegisterDbContext<TInterface, TContext>(
        this IServiceCollection services,
        IConfiguration configuration,
        string connectionStringName,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        where TContext : DbContext, TInterface, IDbContext
    {
        var connectionString = configuration.GetConnectionString(connectionStringName);

        services.AddDbContext<TInterface, TContext>((_, options) =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), x =>
            {
                x.MigrationsAssembly(AssemblyConstants.MigrationsAssembly);
                x.SchemaBehavior(MySqlSchemaBehavior.Translate, (schema, entity) =>
                {
                    return $"{schema.ToLowerInvariant() ?? "dbo"}_{entity.ToLower()}";
                });
            });
        }, serviceLifetime);
    }
}
