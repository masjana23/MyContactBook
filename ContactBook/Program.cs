using ContactBook.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("Default");

// Add services to the container.
builder.Services.AddDbContext<ContactBookContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(5, 6, 30))));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ContactBook}/{action=Index}/{id?}");

app.Run();
