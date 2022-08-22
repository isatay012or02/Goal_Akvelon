using Microsoft.Extensions.DependencyInjection;
using Goals.Persistence;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{

    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<GoalsDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exception)
    {

    }
}

app.MapGet("/", () => "Hello World!");

app.Run();
