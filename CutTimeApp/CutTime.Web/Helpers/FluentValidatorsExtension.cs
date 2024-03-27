using CutTime.Domain.Models;
using CutTime.Domain.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CutTime.Web.Helpers
{
    public static class FluentValidatorsExtension
    {
        public static IServiceCollection AddFluentValidators(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation();
            services.AddScoped<IValidator<User>, UserValidator>();

            return services;
        }
    }
}
