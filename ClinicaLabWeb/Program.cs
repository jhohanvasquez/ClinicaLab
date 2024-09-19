using Microsoft.EntityFrameworkCore;
using SistemaClinicaLab.Models;
using SistemaClinicaLab.Repository.Contratos;
using SistemaClinicaLab.Repository.Implementacion;
using System;
using SistemaClinicaLab.Utilidades;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMemoryCache();

builder.Services.AddSingleton<DBPacientesLabContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IDepartamentoPacienteRepositorio, DepartamentoPacienteRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
