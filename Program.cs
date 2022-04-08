using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = "server=https://rocket-elevators-rest-aspnet.herokuapp.com; database = weverMysql; user = wevertr; password = 3090";

builder.Services.AddDbContext<weverMysqlContext>(options =>
               options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

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

app.MapControllers();

app.Run();
