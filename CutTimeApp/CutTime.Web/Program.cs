using CutTime.Domain.Models;
using CutTime.Web.Helpers;
using Microsoft.AspNetCore.Razor.Runtime;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CutTimeContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CutTimeContext")));

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

#region Services
builder.Services.AddServices();
#endregion

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
    pattern: "{controller=Authentication}/{action=Login}/{id?}");

app.Run();
