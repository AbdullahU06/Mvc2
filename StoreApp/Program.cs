using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using Services;
using StoreApp.Models;
using StoreApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureSession();
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();





app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseSession();
app.ConfigureAndCheckMigration();
app.ConfigureLocalization();

app.ConfigureRouting();

app.MapRazorPages();




app.Run();

