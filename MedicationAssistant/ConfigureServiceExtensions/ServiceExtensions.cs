using MedicationAssistant.Services;
using MedicationAssistant.Shared.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationAssistant.ConfigureServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddConfig(
            this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IAlert, PrescriptionItemAlert>();
            services.AddScoped<IAlertService, AlertService>();

            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IPrescriptionService, PrescriptionService>();

            return services;
        }
    }

}
