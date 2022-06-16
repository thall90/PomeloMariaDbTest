using PomeloMariaDbTest.Api;
using PomeloMariaDbTest.Data.Context.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var configuration = Startup.SetupConfiguration();

builder.AddServices(configuration);

var app = builder.Build();

using var scope = app.Services
    .GetRequiredService<IServiceScopeFactory>()
    .CreateScope();

var context1 = scope.ServiceProvider.GetRequiredService<ITestContext>();
var context2 = scope.ServiceProvider.GetRequiredService<ITest2Context>();

context1.Database.Migrate();
context2.Database.Migrate();

app.AddApplicationServices();

app.Run();
