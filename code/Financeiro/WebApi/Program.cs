using Domain.Interfaces.Generics;
using Domain.Interfaces.ICategory;
using Domain.Interfaces.IExpense;
using Domain.Interfaces.IFinancialSystem;
using Domain.Interfaces.InterfaceService;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Domain.Services;
using Entities.Entities;
using Infra.Config;
using Infra.Repository;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>(options =>
               options.UseSqlServer(
                   builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();

// interface and repository
builder.Services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<InterfaceCategory, CategoryRepository>();
builder.Services.AddSingleton<InterfaceExpense, ExpenseRepository>();
builder.Services.AddSingleton<InterfaceFinancialSistem, FinancialSystemRepository>();
builder.Services.AddSingleton<InterfaceUsuarioSistemaFinanceiro, UsuarioSistemaFinanceiroRepository>();

// services and domain
builder.Services.AddSingleton<ICategoryService, CategoryServices>();
builder.Services.AddSingleton<IExpenseService, ExpenseServices>();
builder.Services.AddSingleton<IFinancialSystemService, FinancialSystemServices>();
builder.Services.AddSingleton<IUsuarioSistemaFinanceiroService, UsuarioSistemaFinanceiroServices>();

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
