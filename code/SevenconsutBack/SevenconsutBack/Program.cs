using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SevenconsutBack.Data;
using SevenconsutBack.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClientRepository, ClientRepository>();

// Connection with database
builder.Services.AddDbContext<BaseContext>(x => x.UseMySql(
    builder.Configuration.GetConnectionString("DataBase"),
    ServerVersion.Parse("8.0.28")
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//var devClient = "http://localhost:4200";
var devClient = "http://localhost:3000";
app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader().WithOrigins(devClient));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
