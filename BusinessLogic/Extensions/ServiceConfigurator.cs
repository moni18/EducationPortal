using BusinessLogic.Base;
using BusinessLogic.Services.Education;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Extensions
{
    public static class ServiceConfigurator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ISchoolService, SchoolService>();

            return services;
        }
    }
}
