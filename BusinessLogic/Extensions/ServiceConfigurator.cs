using BusinessLogic.Base;
using BusinessLogic.Services.Education;
using Common.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Extensions
{
    public static class ServiceConfigurator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IStudentService, StudentService>();

            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            return services;
        }
    }
}
