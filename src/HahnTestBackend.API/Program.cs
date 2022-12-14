using HahnTestBackend.Domain.Interfaces.Repositories;
using HahnTestBackend.Infra.Data.Context;
using HahnTestBackend.Infra.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("X-Pagination"));
});

builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sample Library ",
        Version = "v1",
    });
});


builder.Services.AddDbContext<myDBContext>(options => options.UseSqlServer(builder.Configuration["ApplicationOptions:ConnectionString"]));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HahnTestBackend");
    c.DocExpansion(DocExpansion.None);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();


app.Run();

