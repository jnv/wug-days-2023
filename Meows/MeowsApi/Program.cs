using System.Text.Json.Serialization;
using MeowsApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
    {
        options.Filters.Add(new ProducesAttribute("application/json"));
        options.Filters.Add(new ConsumesAttribute("application/json"));
    })
    .AddJsonOptions(opts =>
    {
        var enumConverter = new JsonStringEnumConverter();
        opts.JsonSerializerOptions.Converters.Add(enumConverter);
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("myKey", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.ApiKey,
        Name = "Api-Key",
        In = ParameterLocation.Header,
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "myKey" }
            },
            Array.Empty<string>()
        }
    });
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Meows API",
            Version = "v1",
            Description = "A sample API",
            TermsOfService = new Uri("http://example.org/toc"),
            Contact = new OpenApiContact
            {
                Name = "Meow Meowson",
                Email = "api@example.org"
            },
            License = new OpenApiLicense
            {
                Name = "Unlicense",
                Url = new Uri("https://spdx.org/licenses/Unlicense.html")
            }
        }
    );
});
builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IApplicationModelProvider, ProduceResponseTypeModelProvider>());
var app = builder.Build();

app.UseSwagger(c =>
{
    c.PreSerializeFilters.Add((swagger, httpReq) =>
    {
        swagger.Servers = new List<OpenApiServer>
        {
            new() { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}", Description = "Current server" },
            new() { Url = "https://example.dev", Description = "Sandbox" },
            new()
            {
                Url = "https://{region}.example.com", Variables = new Dictionary<string, OpenApiServerVariable>
                {
                    { "region", new OpenApiServerVariable { Default = "eu", Enum = new List<string> { "eu", "us", "in" } } }
                }
            }
        };
    });
});
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();