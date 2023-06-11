using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Entitites.Entities;
using Infrascture.Configuration;
using Infrascture.Repository.Generics;
using Infrascture.Repository.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebAPIs.Models;
using WebAPIs.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// SWAGGER
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Bearer {token}",
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<String>()
        }
    });
});

//configService
builder.Services.AddDbContext<ContextBase>(x => x.UseMySql(
                    builder.Configuration.GetConnectionString("DataBase"),
                    ServerVersion.Parse("8.0.28")
                ));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Interface e Repositorio
builder.Services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerecs<>));
builder.Services.AddSingleton<IMessage, RepositoryMessage>();

//Serviço dominio
builder.Services.AddSingleton<IServiceMessage, ServiceMessage>();

//JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(option =>
      {
          option.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = false,
              ValidateAudience = false,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,

              ValidIssuer = "Teste.Securiry.Bearer",
              ValidAudience = "Teste.Securiry.Bearer",
              IssuerSigningKey = JwtSecurityKey.Create("10o1=2lx2grk8ajfiu4-lrojo=4t0wd9=4(pv=o7g763s3ou7h")
          };

          option.Events = new JwtBearerEvents
          {
              OnAuthenticationFailed = context =>
              {
                  Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                  return Task.CompletedTask;
              },
              OnTokenValidated = context =>
              {
                  Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                  return Task.CompletedTask;
              }
          };
      });

//Mapping
var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<MessageViewModel, Message>();
    cfg.CreateMap<Message, MessageViewModel>();
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//CORS
//var urlDev = "https://dominiodocliente.com.br";
//var urlHML = "https://dominiodocliente2.com.br";
//var urlPROD = "https://dominiodocliente3.com.br";

//app.UseCors(b => b.WithOrigins(urlDev, urlHML, urlPROD));

//var devClient = "http://localhost:4200";
var devClient = "http://localhost:3000";
app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader().WithOrigins(devClient));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseSwaggerUI();

app.Run();
