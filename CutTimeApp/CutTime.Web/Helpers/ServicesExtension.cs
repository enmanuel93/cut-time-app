using CutTime.Domain.Contracts;
using CutTime.Infrastructure.Services;

namespace CutTime.Web.Helpers
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            return services;
        }
    }
}
