using Demokrata.SystemSettings.Application.Common.Interfaces;
using Demokrata.SystemSettings.Persistance.Configuration;
using Demokrata.SystemSettings.Infraestructure.Configuration;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseDemokrataCoreLog();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddDemokrataCore(typeof(IDataContext).Assembly);

bool isTest = builder.Environment.IsEnvironment("Test");

if (!isTest)
{
    builder.Services.AddPersistence(builder.Configuration);
}

builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy())
    .AddMySql(builder.Configuration.GetConnectionString("Default"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDemokrataCore();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapHealthChecks("/hc", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

if (!isTest)
{
    ApplyMigrations();
}

app.Run();

void ApplyMigrations()
{
    using var scope = app.Services.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<IDataContext>();
    if (dataContext is not null && dataContext.Database.GetPendingMigrations().Any())
    {
        dataContext.Database.Migrate();
    }
}

public partial class Program { }