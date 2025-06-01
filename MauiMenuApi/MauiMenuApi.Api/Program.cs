using MauiMenuApi.Api.Extensions;
using MauiMenuApi.Api.Middlewares;
using MauiMenuApi.BusinessLayer.Extensions;
using MauiMenuApi.DataAccessLayer.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddPresentation(builder.Configuration, builder.Host)
    .AddDatabaseLayer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .AddBusinessLayer();

builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<GlobalExceptionMiddleware>();

// Configure the HTTP request pipeline.

// Enable Swagger middleware in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
