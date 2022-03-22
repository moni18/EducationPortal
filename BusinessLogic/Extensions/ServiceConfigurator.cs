using BusinessLogic.Services.Hospital;
using BusinessLogic.Services.Hospital.Base;
using Common.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Extensions
{
    public static class ServiceConfigurator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IReceptionService, ReceptionService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IHospitalService, HospitalService>();
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            return services;
        }
    }
}
