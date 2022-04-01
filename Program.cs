using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = "server=codeboxx.cq6zrczewpu2.us-east-1.rds.amazonaws.com; port = 3306; database = MichaelDamico; user = codeboxx; password = Codeboxx1!";

builder.Services.AddDbContext<myapp_developmentContext>(options =>
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
