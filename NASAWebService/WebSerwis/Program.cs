using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NASAWebService;
using NASAWebService.Base;
using NASAWebService.Services;
using AutoMapper;

using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Linq;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterType<ApodService>().As<IApodService>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<OsdrService>().As<IOsdrService>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<SatelliteService>().As<ISatelliteService>().InstancePerLifetimeScope();

    containerBuilder.Register(context =>
        new MapperConfiguration(cfg =>
            cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies())
        ).CreateMapper()
    ).As<IMapper>().InstancePerLifetimeScope();
});

builder.Services.AddHttpClient();
builder.Services.Configure<NasaApiOptions>(builder.Configuration.GetSection("NASA"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "NASA Web Service API",
        Version = "v1",
        Description = "API integrujπce us≥ugi NASA."
    });

    c.AddSecurityDefinition("ClientToken", new OpenApiSecurityScheme
    {
        Name = "Client-Token",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Description = "Wprowadü token autoryzacyjny.",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ClientToken"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "NASA Web Service v1");
        var clientToken = builder.Configuration["ClientToken"];
        c.InjectJavascript($"document.querySelector('.swagger-ui').addEventListener('DOMContentLoaded', function () {{ sessionStorage.setItem('clientToken', '{clientToken}'); }})");
    });
}
app.UseMiddleware<ClientTokenMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

