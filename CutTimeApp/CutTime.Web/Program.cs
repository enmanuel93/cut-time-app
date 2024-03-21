using CutTime.Web;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

using System.Configuration;
using System.Xml.Xsl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews(options => options.Filters.Add(typeof(UsuarioInfoActionFilter)))
    .AddRazorRuntimeCompilation();

builder.Services.AddDbContext<CutTimeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CT_Context")));
builder.Services.AddSession(options => { options.Cookie.Name = "CutTime"; options.IdleTimeout = TimeSpan.FromMinutes(30); });

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

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authentication}/{action=Login}/{id?}");

app.Run();
