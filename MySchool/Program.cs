using MySchool.Infrastructure;
using Prometheus;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Instrumentation.AspNetCore;
using OpenTelemetry.Instrumentation.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


//add service infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

//add service open telemetry
builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource
        .AddService(
            serviceName: "myschool-api",
            serviceVersion: "1.0.0"))
    .WithMetrics(metrics => metrics
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddRuntimeInstrumentation()
        .AddPrometheusExporter());



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//metriks request http
app.UseHttpMetrics();
app.UseRouting();
app.MapMetrics();

// Endpoint scraping OpenTelemetry
//app.MapPrometheusScrapingEndpoint();


app.UseAuthorization();

app.MapControllers();

app.Run();
