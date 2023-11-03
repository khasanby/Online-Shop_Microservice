var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Host.ConfigureLogging((context, logBuilder) =>
{
    logBuilder.AddConfiguration(builder.Configuration.GetSection("Logging"));
    logBuilder.AddConsole();
    logBuilder.AddDebug();
});

app.Logger.LogInformation("Starting OcelotApiGateway");
app.MapGet("/", () => "Hello World!");

app.Run();