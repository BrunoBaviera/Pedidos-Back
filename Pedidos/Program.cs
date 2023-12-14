using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Pedidos.Global.Api.ApiConfig;
using Pedidos.Global.Api.AutoMapperConfig;
using Pedidos.Global.Api.DataBase;
using Pedidos.Global.Api.DependencyInjection;
using Pedidos.Global.Api.SwaggerConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configuração de Bancos de Dados
builder.Services.AddDataBaseConfiguration(builder.Configuration);

// Configuração do AutoMapper
builder.Services.AddAutoMapperConfiguration();

// Configuração Geral e Versionamento
builder.Services.AddApiConfiguration();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfiguration();

builder.Services.AddDependencyInjectionConfiguration();

var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseApiConfiguration(app.Environment);

app.UseSwaggerConfiguration(apiVersionDescriptionProvider);

app.Run();
