using BusinessLogic.Services.Hospital;
using Common.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Extensions
{
    public static class ServiceConfigurator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ReceptionService>();
            services.AddScoped<DoctorService>();
            services.AddScoped<PatientService>();
            services.AddScoped<HospitalService>();
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            return services;
        }
    }
}
