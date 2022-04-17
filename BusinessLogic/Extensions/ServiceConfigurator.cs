using BusinessLogic.Services.Education;
using Common.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Extensions
{
    public static class ServiceConfigurator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped< UniversityService>();
            services.AddScoped< ManagerService>();
            services.AddScoped< StudentService>();

            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            return services;
        }
    }
}
