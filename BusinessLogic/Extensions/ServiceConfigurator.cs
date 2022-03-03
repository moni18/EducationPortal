using BusinessLogic.Base;
using BusinessLogic.Services.Hospital;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Extensions
{
    public static class ServiceConfigurator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IReceptionService, ReceptionService>();

            return services;
        }
    }
}
