using CovidAnalysis.API.Middlewares;
using CovidAnalysis.Core;
using CovidAnalysis.Core.Models;
using CovidAnalysis.Infrastructure.Data.EF;
using CovidAnalysis.Infrastructure.Data.EF.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CovidDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));//Faço a connectionString
builder.Services.AddMediatR(typeof(CovidStatistic).Assembly);//Registo o MediastR
builder.Services.AddScoped<ICovidStatisticRepository, CovidStatisticRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseCors(options => 
//{ 
//    options.AllowAnyHeader(); 
//    options.AllowAnyMethod();
//    options.AllowAnyOrigin();
//});

//app.UseMiddleware<RequestValidatorMiddleware>();//vou utilizar o middleware

app.MapControllers();

app.Run();
