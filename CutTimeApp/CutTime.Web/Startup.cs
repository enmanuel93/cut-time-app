using CutTime.Domain.Models;
using CutTime.Web.Helpers;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Razor.Runtime;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using CutTime.Domain.Validations;

namespace CutTime.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddDbContext<CutTimeContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CutTimeContext")));

            // Add services to the container.
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            #region Services
            services.AddServices();

            services.AddFluentValidationAutoValidation();
            services.AddScoped<IValidator<User>, UserValidator>();
            //services.AddFluentValidators();
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Authentication}/{action=Login}");
            });            
        }
    }
}
