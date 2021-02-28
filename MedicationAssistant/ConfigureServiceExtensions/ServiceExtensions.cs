using MedicationAssistant.ServiceLayer.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace MedicationAssistant.ConfigureServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddConfig(this IServiceCollection services)
        {

            services.AddScoped<IAlertRepository, AlertRepository>();
            services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
            services.AddScoped<MedicationRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddAutoMapper(typeof(AppProfile));

            return services;
        }
    }
}